﻿using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
// For Adf execution.
using CrossBreeze.CrossTest.Process.Adf.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;

namespace CrossBreeze.CrossTest.Process.Adf
{
    public static class AdfExecutor
        
    {
        const string azureLoginUrl = "https://login.microsoftonline.com/";
        const string getTokenUrl = "https://management.azure.com//.default";
        /// <summary>
        /// The Adf Operation Message types.
        /// As defined in the catalog.operation_messages table:
        ///  - https://docs.microsoft.com/en-us/sql/integration-services/system-views/catalog-operation-messages-Adfdb-database?view=sql-server-2017#remarks
        /// </summary>
        private enum AdfOperationMessageType : short
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

        public static void ExecuteAdfProcess(string projectName, string pipelineName, Dictionary<string, string> parameters = null)
        {
            // Check whether the Adf process config exists
            if (AdfProcessesConfig.GetConfig() == null)
                throw new Exception(string.Format("No Adf process configuration exists!"));

            // Get the Adf project configuration for the given project name.
            AdfProcessProjectConfig AdfProjectConfig = AdfProcessesConfig.GetConfig().AdfProcesses[projectName];
            if (AdfProjectConfig == null)
                throw new Exception(string.Format("The specified Adf process config '{0}' doens't exist!", projectName));

            if (AdfProjectConfig.parameters != null)
                foreach (var paramter in AdfProjectConfig.parameters)
                    parameters.Add(paramter.Key, paramter.Value);
            
            // Based on the process type, start the execution.
            switch (AdfProjectConfig.ProcessType)
            {   
                case AdfProcessType.AdfPipeline:
                    // beschrijving

                    ExecuteAdfPipelineAsync(AdfProjectConfig.tenantID, AdfProjectConfig.subscriptionId, AdfProjectConfig.applicationId, AdfProjectConfig.clientSecret,
                        AdfProjectConfig.resourceGroupName, AdfProjectConfig.dataFactoryName, pipelineName, parameters).Wait();
                    break;

                

                default:
                    throw new Exception(string.Format("The Adf Process Type {0} is not supported yet!", AdfProjectConfig.ProcessType.ToString()));
            }
        }
        

        /// <summary>
        /// Execute a Adf package which resides in a azure data factory.
        /// </summary>
        /// <param name="serverAndInstanceName">The server and instance name of the Adf catalog</param>
        /// <param name="folderName">The folder the package resides in</param>
        /// <param name="projectName">The project the package resides in</param>
        /// <param name="packageName">The name of the package to execute</param>
        /// <param name="parameters">The parameters to use for the package execution</param>
        private static async Task ExecuteAdfPipelineAsync(string tenantID, string subscriptionId, string applicationId, string clientSecret,
            string resourceGroupName, string dataFactoryName, string pipelineName, IDictionary<string, string> parameters)
        {
            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(applicationId)
                 .WithAuthority(azureLoginUrl + tenantID)
                 .WithClientSecret(clientSecret)
                 .WithLegacyCacheCompatibility(false)
                 .WithCacheOptions(CacheOptions.EnableSharedCacheOptions)
                 .Build();

            AuthenticationResult result = await app.AcquireTokenForClient(
              new string[] { getTokenUrl })
               .ExecuteAsync();
            ServiceClientCredentials cred = new TokenCredentials(result.AccessToken);
            var client = new DataFactoryManagementClient(cred)
            {
                SubscriptionId = subscriptionId
            };
            Dictionary<string, object> dObjectParameters = parameters.ToDictionary(k => k.Key, k => (object)k.Value);
            var run = await client.Pipelines.CreateRunWithHttpMessagesAsync(resourceGroupName, dataFactoryName, pipelineName, parameters: dObjectParameters);
            
            Console.WriteLine("Creating pipeline run...");

            Console.WriteLine("Pipeline run ID: " + run.Body.RunId);

            // Monitor the pipeline run
            Console.WriteLine("Checking pipeline run status...");
            PipelineRun pipelineRun;
            while (true)
            {
                pipelineRun = client.PipelineRuns.Get(
                    resourceGroupName, dataFactoryName, run.Body.RunId);
                Console.WriteLine("Status: " + pipelineRun.Status);
                if (pipelineRun.Status == "InProgress" || pipelineRun.Status == "Queued")
                    System.Threading.Thread.Sleep(1000);
                else
                    break;
            }

            Console.WriteLine("Press Any Key to Exit...");
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
