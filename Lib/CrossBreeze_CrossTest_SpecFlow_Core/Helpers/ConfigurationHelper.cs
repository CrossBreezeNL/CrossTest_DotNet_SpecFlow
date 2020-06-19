using System;
using System.Collections.Generic;
// For using the app.config ConnectionStrings.
using System.Configuration;
using System.Linq;
using CrossBreeze.CrossTest.SpecFlow.Configuration;
using CrossBreeze.CrossTest.SpecFlow.Configuration.Database;
using CrossBreeze.CrossTest.SpecFlow.Configuration.Process;
using CrossBreeze.CrossTest.SpecFlow.Configuration.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using static CrossBreeze.CrossTest.SpecFlow.Configuration.Test.ObjectTemplateConfig;

namespace CrossBreeze.CrossTest.SpecFlow.Helpers
{
    static class ConfigurationHelper
    {
        public static CrossTestConfig GetConfig()
        {
            return CrossTestConfig.GetConfig();
        }

        public static TestConfig GetTestConfig()
        {
            return GetConfig().Test;
        }

        public static DatabaseConfig GetDatabaseConfig()
        {
            return GetConfig().Database;
        }

        public static ProcessConfig GetProcessConfig()
        {
            return GetConfig().Process;
        }

        /// <summary>
        /// Get the connection string for the given name of a connection.
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static String GetConnectionString(String connectionName)
        {
            string returnVal = null;

            // Get the connection string setting from the App.config.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connectionName];
            // If the settings exist, set the returnvalue to the connectionstring found.
            if (settings != null)
            {
                returnVal = settings.ConnectionString;
            }

            return returnVal;
        }

        /// <summary>
        /// Add the parameter as specified in the config.
        /// </summary>
        /// <param name="parameters">The list of parameters for the object.</param>
        /// <param name="objectTemplateConfig">The process template config to use</param>
        public static void AddTemplateAttributes(Dictionary<string, string> parameters, ObjectTemplateConfig objectTemplateConfig)
        {
            // Loop through the defined parameter in the process template and add them to the parameters list if they don't exist.
            foreach (ObjectTemplateAttributeConfig objectTemplateAttributeConfig in objectTemplateConfig.Attributes)
            {
                // Only add the parameter from the template if it doesn't exist yet.
                if (!parameters.Keys.Contains(objectTemplateAttributeConfig.Name))
                {
                    // Add the parameter name an dvalue to the dictionary with process parameters.
                    parameters.Add(objectTemplateAttributeConfig.Name, objectTemplateAttributeConfig.Value);
                }
            }

            // If the ParentTemplate is set, add the attributes from the parent(s).
            if (objectTemplateConfig.ParentTemplate != null && objectTemplateConfig.ParentTemplate != String.Empty)
            {
                ObjectTemplateConfig parentObjectTemplateConfig = ConfigurationHelper.GetTestConfig().ObjectTemplates[objectTemplateConfig.ParentTemplate];
                Assert.IsNotNull(parentObjectTemplateConfig, string.Format("The specified parent object template '{0}' doesn't exists!", objectTemplateConfig.ParentTemplate));
                // Add the columns from the parent process template (recursively).
                AddTemplateAttributes(parameters, parentObjectTemplateConfig);
            }
        }
    }
}
