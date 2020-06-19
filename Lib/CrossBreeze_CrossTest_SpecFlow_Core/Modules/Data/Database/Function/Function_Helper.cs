using CrossBreeze.CrossDoc.CustomAttributes;
using CrossBreeze.CrossTest.Database.Helpers;
using CrossBreeze.CrossTest.SpecFlow.Configuration.Test;
using CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Context;
using CrossBreeze.CrossTest.SpecFlow.Helpers;
using CrossBreeze.CrossTest.SpecFlow.Result.Context;
using CrossBreeze.CrossTest.SpecFlow.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using TechTalk.SpecFlow;
namespace CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Function
{
    public static class Function_Helper
    {

        public static void ExecuteDatabaseFunction(
            string schemaName,
            string functionName
        )
        {
            ExecuteSchemaFunctionHelper(schemaName, functionName);
        }


        public static void ExecuteDatabaseFunctionWithParameters(
            string schemaName,
            string functionName,
            Table parameterTable
        )
        {
            ExecuteSchemaFunctionHelper(schemaName, functionName, parameterTable);
        }

        public static void ExecuteTemplatedFunction(
            string functionName,
            string objectTemplateName
        )
        {
            ExecuteTemplatedFunctionHelper(functionName, objectTemplateName);
        }

        public static void ExecuteTemplatedFunctionWithParameters(
            string functionName,
            string objectTemplateName,
            Table parameterTable
        )
        {
            ExecuteTemplatedFunctionHelper(functionName, objectTemplateName, parameterTable);
        }

        private static void ExecuteFunctionHelper(
            string functionName,
            string objectTemplateName = null,
            Table parameterTable = null
        )
        {
            // Initialize the fully qualified function name.
            string fqFunctionName = functionName;
            // Convert the SpecFlow parameters table to a dictionary.
            Dictionary<string, string> parameters = TableHelper.ToDictionary(parameterTable);

            // If the object template name is set, construct the fully qualified function name using the template.
            if (objectTemplateName != null)
            {
                // Find the naming convention in the App.config.
                ObjectTemplateConfig objectTemplateConfig = ConfigurationHelper.GetTestConfig().ObjectTemplates[objectTemplateName];
                Assert.IsNotNull(objectTemplateConfig, string.Format("The object template '{0}' can't be found!", objectTemplateName));

                // Construct the fully qualified function name.
                fqFunctionName = string.Format("{0}{1}{2}", objectTemplateConfig.Prefix, functionName, objectTemplateConfig.Suffix);

                // Process the template parameter specified in the config.
                ConfigurationHelper.AddTemplateAttributes(parameters, objectTemplateConfig);
            }

            // Create the SqlCommand.
            IDbCommand sqlFunctionCallCommand = DatabaseContext.GetDatabaseContext().CreateDbCommand();
            // Set the command type to text.
            sqlFunctionCallCommand.CommandType = CommandType.Text;

            // Construct the parameter list and add the parameters to the SqlCommand.
            String textualParameterList = "";

            // Loop through the rows of the parameter dictionary and add the parameters to the function call.
            int parameterIndex = 0;
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                // Increase the parameter index.
                ++parameterIndex;

                String parameterName = String.Format("@{0}", parameter.Key);
                string parameterValue = parameter.Value;

                // Add the parameter name to the textual list of parameters.
                textualParameterList += parameterName;
                // If this is not the last parameter, add a comma.
                if (parameterIndex < parameters.Count)
                    textualParameterList += ", ";

                // Add the SqlParameter to the function call command.
                IDbDataParameter param = sqlFunctionCallCommand.CreateParameter();
                param.ParameterName = parameterName;
                param.Value = TableExtensions.GetDataTypedValue(parameterValue);
                sqlFunctionCallCommand.Parameters.Add(param);
            }

            // Construct the business rule function call.
            sqlFunctionCallCommand.CommandText = String.Format("SELECT * FROM {0}({1})", fqFunctionName, textualParameterList);

            // Execute the function.
            IDataReader functionDataReader = sqlFunctionCallCommand.ExecuteReader();
            ResultContext.GetResultContext().SetResultTable(DataHelper.GetDataTableFromDataReader(functionDataReader));
            functionDataReader.Close();
        }

        /// <summary>
        /// Execute a function using the schema and seperate function name.
        /// </summary>
        /// <param name="schemaName"></param>
        /// <param name="functionName"></param>
        /// <param name="parameterTable"></param>
        private static void ExecuteSchemaFunctionHelper(
            string schemaName,
            string functionName,
            Table parameterTable = null
        )
        {
            // Construct the fully qualified function name.
            string fqFunctionName = string.Format("[{0}].[{1}]", schemaName, functionName);

            // Execute the function.
            ExecuteFunctionHelper(fqFunctionName, null, parameterTable);
        }

        /// <summary>
        /// Execute a function using an object template.
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="objectTemplateName"></param>
        /// <param name="parameterTable"></param>
        private static void ExecuteTemplatedFunctionHelper(
            string functionName,
            string objectTemplateName,
            Table parameterTable = null
        )
        {
            // Execute the function.
            ExecuteFunctionHelper(functionName, objectTemplateName, parameterTable);
        }
    }
}
