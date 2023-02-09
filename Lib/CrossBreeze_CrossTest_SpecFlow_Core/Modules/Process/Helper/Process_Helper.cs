using CrossBreeze.CrossTest.SpecFlow.Configuration.Test;
using CrossBreeze.CrossTest.SpecFlow.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CrossBreeze.CrossTest.SpecFlow.Modules.Process
{
    public static class Process_Helper
    {

        public static void ExecuteProcess(string processName,string processType, string projectName)
        {
            ExecuteProcessHelper(null, processName, null, processType, projectName, null);
        }

        public static void ExecuteProcessWithParameters(string processName, string processType, string projectName, Table parameterTable)
        {
            ExecuteProcessHelper(null,processName,null,processType,projectName,parameterTable);
        }

        public static void ExecuteTemplatedProcess(string processName, string objectTemplateName, string processType, string projectName)
        {
            ExecuteProcessHelper(null, processName, objectTemplateName, processType, projectName, null);
        }

        public static void ExecuteTemplatedProcessWithParameters(string processName, string objectTemplateName, string processType, string projectName, Table parameterTable)
        {
            ExecuteProcessHelper(null, processName, objectTemplateName, processType, projectName, parameterTable);
        }

        public static void ExecuteProcessAsRole(
            string roleName,
            string processName,
            string processType,
            string projectName
         )
        {
            ExecuteProcessHelper(roleName, processName, null, processType, projectName, null);
        }

        public static void ExecuteTemplatedProcessAsRole(
            string roleName,
            string processName,
            string objectTemplateName,
            string processType,
            string projectName
           )
        {
            ExecuteProcessHelper(roleName, processName, objectTemplateName, processType, projectName, null);
        }

        public static void ExecuteProcessWithParametersAsRole(
            string roleName,
            string processName,
            string processType,
            string projectName,
            Table parameterTable)
        {
            ExecuteProcessHelper(roleName, processName, null, processType, projectName, parameterTable);
        }

        public static void ExecuteTemplatedProcessAsRoleWithParameters(
            string roleName,
            string processName,
            string objectTemplateName,
            string processType,
            string projectName,
            Table parameterTable
        )
        {
            ExecuteProcessHelper(roleName, processName, objectTemplateName, processType, projectName, parameterTable);
        }

        #region Helpers
        /// <summary>
        /// Execute a process.
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="processName"></param>
        /// <param name="objectTemplateName"></param>
        /// <param name="processType"></param>
        /// <param name="projectName"></param>
        /// <param name="parameterTable"></param>
        private static void ExecuteProcessHelper(string roleName, string processName, string objectTemplateName, string processType, string projectName, Table parameterTable)
        {
            // Initialize the fully qualified process name.
            string fqProcessName = processName;
            // Convert the SpecFlow parameters table to a dictionary.
            Dictionary<string, string> parameters = TableHelper.ToDictionary(parameterTable);

            // If the process template name is specified, create the parameters from the config.
            if (objectTemplateName != null)
            {
                // Get the table template config.
                ObjectTemplateConfig objectTemplateConfig = ConfigurationHelper.GetTestConfig().ObjectTemplates[objectTemplateName];

                // Assert the table template is known.
                Assert.IsNotNull(objectTemplateConfig, string.Format("The object template '{0}' is not found in the config!", objectTemplateName));

                // Construct the fully qualified function name.
                fqProcessName = string.Format("{0}{1}{2}", objectTemplateConfig.Prefix, processName, objectTemplateConfig.Suffix);

                // Process the template parameter specified in the config.
                ConfigurationHelper.AddTemplateAttributes(parameters, objectTemplateConfig);
            }

            // Execute the process.
            ETLHelper.ExecuteProcess((Configuration.Process.ProcessType)Enum.Parse(typeof(Configuration.Process.ProcessType), processType), projectName, fqProcessName, parameters);
        }
        #endregion

    }
}
