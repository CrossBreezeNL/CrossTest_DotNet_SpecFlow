using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
// For Ssis execution.
using CrossBreeze.CrossTest.Process.Ssis.Configuration;
using System.Configuration;
using System.Data.SqlClient;

namespace CrossBreeze.CrossTest.Process.Ssis
{
    public static class SsisExecutor
    {
        /// <summary>
        /// The Ssis Operation Message types.
        /// As defined in the catalog.operation_messages table:
        ///  - https://docs.microsoft.com/en-us/sql/integration-services/system-views/catalog-operation-messages-ssisdb-database?view=sql-server-2017#remarks
        /// </summary>
        private enum SsisOperationMessageType : short
        {
             Unknown = -1
            ,Error = 120
            ,Warning = 110
            ,Information = 70
            ,PreValidate = 10
            ,PostValidate = 20
            ,PreExecute = 30
            ,PostExecute = 40
            ,Progress = 60
            ,StatusChange = 50
            ,QueryCancel = 100
            ,TaskFailed = 130
            ,Diagnostic = 90
            ,Custom = 200
            ,DiagnosticEx = 140
        }

        public static void ExecuteSsisProcess(string projectName, string packageName, Dictionary<string, string> parameters = null)
        {
            // Check whether the SSIS process config exists
            if (crossTestSsisConfig.GetConfig() == null)
                throw new Exception(string.Format("No SSIS process configuration exists!"));

            // Get the SSIS project configuration for the given project name.
            SsisProcessConfig ssisProjectConfig = crossTestSsisConfig.GetConfig().SsisProcesses[projectName];
            if (ssisProjectConfig == null)
                throw new Exception(string.Format("The specified SSIS process config '{0}' doens't exist!", projectName));

            // Based on the process type, start the execution.
            switch (ssisProjectConfig.ProcessType)
            {
                case SsisProcessType.ISPac:
                    // To execute a Ssis package in project deployment model, we can execute it from an IsPac file.

                    // Get the build output directory.
                    string directory = Directory.GetParent(Environment.CurrentDirectory).ToString();
                    // Go up 3 directories to get to the project root.
                    string projectRootDir = Path.GetFullPath(Path.Combine(directory, @"..\..\..\"));
                    // Construct the ispac file location.
                    string ispacFileLocation = Path.GetFullPath(Path.Combine(projectRootDir, ssisProjectConfig.IsPacFileLocation));

                    // Create a dictionary for the project connections.
                    Dictionary<string, string> projectConnections = new Dictionary<string, string>();
                    // If the parameters are specified, copy them into a Dictionary.
                    if (parameters != null)
                    {
                        foreach (SsisProjectConnection ssisProjectConnection in ssisProjectConfig.Connections)
                        {
                            projectConnections.Add(ssisProjectConnection.Name, ssisProjectConnection.ConnectionString);
                        }
                    }

                    // Execute the package in the ispac file.
                    ExecuteISPacPackage(ispacFileLocation, string.Format("{0}.dtsx", packageName), parameters, projectConnections);
                    break;
                    
                case SsisProcessType.ISServer:
                    // To execute a SSIS package in project deployment model, you need to know the Folder, Project and Package
                    // And also the connection to the SSISDB catalog.
                    // When the package is known, a reference to the environment can be made.
                    // To support the above, we need to get the Folder and Environment reference from the configuration.

                    // Get the connection string setting from the App.config.
                    ConnectionStringSettings ssisConnectionSettings = ConfigurationManager.ConnectionStrings[ssisProjectConfig.SsisConnectionName];
                    // If the settings exist, set the returnvalue to the connectionstring found.
                    if (ssisConnectionSettings == null)
                        throw new Exception(string.Format("The specified SSIS connection '{0}' doens't exist!", ssisProjectConfig.SsisConnectionName));

                    ExecuteISServerPackage(ssisConnectionSettings.ConnectionString, ssisProjectConfig.SsisFolder, ssisProjectConfig.SsisProject, string.Format("{0}.dtsx", packageName), parameters, ssisProjectConfig.SsisEnvironmentFolder, ssisProjectConfig.SsisEnvironmentName, ssisProjectConfig.Use32RuntimeOn64);
                    break;

                case SsisProcessType.FileSystem:
                    // To execute a SSIS package in file deployment model, you need to known the path to the SSIS package.
                    // We could split his up in the folder for a SSIS project and the SSIS package.
                    // Using the projectName parameter we can look in the config to find the path to the project folder.
                    // We concat it with the processName and we have the full path to the SSIS package.
                    string packagePath = string.Format("{0}\\{1}.dtsx", ssisProjectConfig.SsisFilePath, packageName);
                    ExecuteFileSystemPackage(packagePath, parameters);
                    break;

                default:
                    throw new Exception(string.Format("The SSIS Process Type {0} is not supported yet!", ssisProjectConfig.ProcessType.ToString()));
            }
        }

        /// <summary>
        /// Execute a SSIS package which resides in an IsPac file.
        /// </summary>
        /// <param name="isPacPath">The full path to the IsPac file</param>
        /// <param name="packageName">The name of the package to execute</param>
        /// <param name="parameters">The parameters to use for the package execution</param>
        /// <param name="projectConnections">The list of project connections with their connection string</param>
        private static void ExecuteISPacPackage(string isPacPath, string packageName, Dictionary<string, string> parameters, Dictionary<string, string> projectConnections)
        {
            // By setting the accessmode to Read, the file is not locked and can be accessed in parallel.
            Microsoft.SqlServer.Dts.Runtime.Project ispacProj = Microsoft.SqlServer.Dts.Runtime.Project.OpenProject(isPacPath, Microsoft.SqlServer.Dts.Runtime.Project.AccessMode.Read, null, null);

            // Loop through the configured project connections, and set its connection strings.
            foreach (string projectConnectionName in projectConnections.Keys) {
                string projectConnectionStreamName = string.Format("{0}.conmgr", projectConnectionName);
                // If the connection doesn't exist, throw an exception.
                if (!ispacProj.ConnectionManagerItems.Contains(projectConnectionStreamName))
                    throw new Exception(string.Format("The SSIS project doesn't contain a connection '{0}' ({1})", projectConnectionStreamName, isPacPath));

                // Set the connection string for the connection manager.
                ispacProj.ConnectionManagerItems[projectConnectionStreamName].ConnectionManager.ConnectionString = projectConnections[projectConnectionName];
            }

            // Find the package to execute in the ispac.
            Microsoft.SqlServer.Dts.Runtime.PackageItem packageItemToExecute = ispacProj.PackageItems[packageName];
            if (packageItemToExecute == null)
                throw new Exception(string.Format("The package {0} doens't exist in the ispac {1}", packageName, isPacPath));
            // Load the package object.
            Microsoft.SqlServer.Dts.Runtime.Package ispacPackage = packageItemToExecute.LoadPackage(null);

            // Execute the package with the specified parameters.
            ExecutePackage(ispacPackage, parameters);
        }

        /// <summary>
        /// Execute a SSIS package which resides in a SQL Server catalog.
        /// </summary>
        /// <param name="serverAndInstanceName">The server and instance name of the SSIS catalog</param>
        /// <param name="folderName">The folder the package resides in</param>
        /// <param name="projectName">The project the package resides in</param>
        /// <param name="packageName">The name of the package to execute</param>
        /// <param name="parameters">The parameters to use for the package execution</param>
        private static void ExecuteISServerPackage(string ssisConnectionString, string folderName, string projectName, string packageName, Dictionary<string, string> parameters, string environmentFolderName, string environmentName, bool? use32RuntimeOn64)
        {
            // Create a connection to SSIS SQL Server.
            using (SqlConnection ssisConnection = new SqlConnection(ssisConnectionString))
            {
                // Create the IntegrationServices object.
                Microsoft.SqlServer.Management.IntegrationServices.IntegrationServices ssis = new Microsoft.SqlServer.Management.IntegrationServices.IntegrationServices(ssisConnection);

                // Get the Integration Services catalog
                Microsoft.SqlServer.Management.IntegrationServices.Catalog ssisCatalog = ssis.Catalogs["SSISDB"];

                // Get the SSIS folder.
                Microsoft.SqlServer.Management.IntegrationServices.CatalogFolder ssisFolder = ssisCatalog.Folders[folderName];
                if (ssisFolder == null)
                    throw new Exception(string.Format("The specified SSIS folder '{0}' doesn't exist!", folderName));

                // Get the SSIS project.
                Microsoft.SqlServer.Management.IntegrationServices.ProjectInfo ssisProject = ssisFolder.Projects[projectName];
                if (ssisProject == null)
                    throw new Exception(string.Format("The specified SSIS project '{0}/{1}' doesn't exist!", folderName, projectName));

                // Get the SSIS package.
                Microsoft.SqlServer.Management.IntegrationServices.PackageInfo ssisPackage = ssisProject.Packages[packageName];
                if (ssisPackage == null)
                    throw new Exception(string.Format("The specified SSIS package '{0}/{1}/{2}' doesn't exist!", folderName, projectName, packageName));

                // Create an environment reference object.
                Microsoft.SqlServer.Management.IntegrationServices.EnvironmentReference environmentReference = null;
                // If the environment is specified, assign the reference.
                if (environmentName != null && environmentName.Length > 0)
                {
                    // Get the environment reference.
                    environmentReference = ssisProject.References[environmentName, environmentFolderName];
                    if (environmentReference == null)
                        throw new Exception(string.Format("The environment reference '{0}/{1}' doesn't exist for project {2}/{3}!", environmentFolderName, environmentName, folderName, projectName));
                }

                // Create an empty collection of parameter value sets.
                System.Collections.ObjectModel.Collection<Microsoft.SqlServer.Management.IntegrationServices.PackageInfo.ExecutionValueParameterSet> packageExecutionParameters = new System.Collections.ObjectModel.Collection<Microsoft.SqlServer.Management.IntegrationServices.PackageInfo.ExecutionValueParameterSet>();
                // If the parameters are given, add them to the collection.
                if (parameters != null)
                {
                    // Loop through the specified parameters to create the execution parameter set.
                    foreach (String parameterName in parameters.Keys)
                    {
                        // Get information about the package parameter.
                        Microsoft.SqlServer.Management.IntegrationServices.ParameterInfo parameterInfo = ssisPackage.Parameters[parameterName];
                        if (parameterInfo == null)
                            throw new Exception(string.Format("The specified parameter '{0}' doesn't exist in package {1}/{2}/{3}!", parameterName, folderName, projectName, packageName));

                        // Add the constructed parameter so to the collection for execution.
                        packageExecutionParameters.Add(new Microsoft.SqlServer.Management.IntegrationServices.PackageInfo.ExecutionValueParameterSet
                        {
                            // Set the name and type of the parameter to the parameter info object.
                            ParameterName = parameterInfo.Name,
                            ObjectType = parameterInfo.ObjectType,
                            // Set the value of the parameter to the value given.
                            ParameterValue = GetTypedValue(parameterInfo.DataType, parameters[parameterName])
                        });
                    }
                }

                // Set whether to run in 32 bits, false by default.
                bool runIn32BitMode = false;
                // If the use32RuntimeOn64 is specified, use the value.
                if (use32RuntimeOn64.HasValue)
                    runIn32BitMode = use32RuntimeOn64.Value;

                // Execute the package asynchronously.
                // Note: there is a default timeout on the SSIS connection of 30 seconds.
                //       So if the execution takes more then 30 seconds the following execution of the package will fail.
                //       This is why packages are always executed asynchronously and afterwards the status is check in a while.
                // Add the parameter for executing packages SYNCHRONIZED.
                //packageExecutionParameters.Add(new Microsoft.SqlServer.Management.IntegrationServices.PackageInfo.ExecutionValueParameterSet { ParameterName = "SYNCHRONIZED", ParameterValue = 1, ObjectType = 50  });
                long exectionId = ssisPackage.Execute(runIn32BitMode, environmentReference, packageExecutionParameters);

                // Get the operation information using the executionId.
                Microsoft.SqlServer.Management.IntegrationServices.ExecutionOperation ssisOperation = ssisCatalog.Executions[exectionId];

                // Wait till the package has completed.
                while (!ssisOperation.Completed)
                {
                    // Sleep for 1 second.
                    System.Threading.Thread.Sleep(1000);
                    // Refresh the operation status object.
                    ssisOperation.Refresh();
                }

                // Check whether the operation successed or not.
                if (!ssisOperation.Status.Equals(Microsoft.SqlServer.Management.IntegrationServices.Operation.ServerOperationStatus.Success))
                {
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.AppendLine(string.Format("An error occured while executing the SSIS Process (operationId={0}, status={1}):", exectionId, ssisOperation.Status.ToString()));
                    // Only include errors in the output.
                    ssisOperation.Messages.Where(m => m.MessageType.HasValue && ((SsisOperationMessageType)m.MessageType).Equals(SsisOperationMessageType.Error)).ToList().ForEach(m => strBuilder.AppendLine(m.Message));
                    // Throw the exception.
                    throw new Exception(strBuilder.ToString());
                }
            }
        }

        /// <summary>
        /// Execute a SSIS package file.
        /// </summary>
        /// <param name="ssisPackagePath">The full ssis package file path</param>
        /// <param name="parameters">The parameters to use for the package execution</param>
        public static void ExecuteFileSystemPackage(string ssisPackagePath, Dictionary<string, string> parameters)
        {
            // Create a new application context.
            Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();
            // Load the ssis file to a Package object.
            Microsoft.SqlServer.Dts.Runtime.Package p = app.LoadPackage(ssisPackagePath, null);
            // Execute the SSIS file package.
            ExecutePackage(p, parameters);
        }

        /// <summary>
        /// Generic procedure to execute a package with the given parameters.
        /// </summary>
        /// <param name="p">The package to execute</param>
        /// <param name="parameters">The parameters for the package execution</param>
        private static void ExecutePackage(Microsoft.SqlServer.Dts.Runtime.Package p, Dictionary<string, string> parameters)
        {
            // If the parameters are set, loop through them and set the package parameters.
            if (parameters != null)
            {
                foreach (string parameterName in parameters.Keys)
                {
                    // If the package doesn't have a parameter with the specified name, throw an exception.
                    if (!p.Parameters.Contains(parameterName))
                        throw new Exception(string.Format("The package {0} doesn't have a parameter named {1}.", p.Name, parameterName));

                    Microsoft.SqlServer.Dts.Runtime.Parameter packageParameter = p.Parameters[parameterName];
                    // Set the type parameter value.
                    packageParameter.Value = GetTypedValue(packageParameter.DataType, parameters[parameterName]);
                }
            }

            // Execute the package.
            Microsoft.SqlServer.Dts.Runtime.DTSExecResult result = p.Execute();

            // If the result is failure, collect the failure information.
            if (result == Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine(string.Format("An error occured while executing the SSIS Process (status={0}):", p.ExecutionStatus.ToString()));
                foreach (Microsoft.SqlServer.Dts.Runtime.DtsError err in p.Errors)
                {
                    strBuilder.Append(err.Description);
                }
                throw new Exception(strBuilder.ToString());
            }
        }

        /// <summary>
        /// Get the typed value using the TypeCode and the valueString.
        /// </summary>
        /// <param name="typeCode">The type code of the required output type.</param>
        /// <param name="valueString">The string containting the textual version of the value.</param>
        /// <returns></returns>
        private static object GetTypedValue(TypeCode typeCode, string valueString)
        {
            // Get the package parameter datatype to choose how to parse the value.
            switch (typeCode)
            {
                // Boolean
                case TypeCode.Boolean:
                    return Boolean.Parse(valueString);
                case TypeCode.DateTime:
                    return DateTime.Parse(valueString);
                case TypeCode.Decimal:
                    return Decimal.Parse(valueString);
                case TypeCode.Double:
                    return Double.Parse(valueString);
                // Int16
                case TypeCode.Int16:
                    return Int16.Parse(valueString);
                // Int32
                case TypeCode.Int32:
                    return Int32.Parse(valueString);
                // Int64
                case TypeCode.Int64:
                    return Int64.Parse(valueString);
                // UInt16
                case TypeCode.UInt16:
                    return UInt16.Parse(valueString);
                // UInt32
                case TypeCode.UInt32:
                    return UInt32.Parse(valueString);
                // UInt64
                case TypeCode.UInt64:
                    return UInt64.Parse(valueString);
                default:
                    return valueString;
            }
        }
    }
}
