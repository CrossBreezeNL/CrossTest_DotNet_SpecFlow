using CrossBreeze.CrossTest.Process.Ssis;
using CrossBreeze.CrossTest.Process.Ssis.Configuration;
using System;
using System.Collections.Generic;

namespace CrossBreeze.CrossTest.SpecFlow.Helpers
{
    public static class ETLHelper
    {
        public enum ProcessType
        {
            SSIS
        }

        public static void ExecuteProcess(ProcessType processType, String projectName, String processName, Dictionary<string, string> parameters = null)
        {
            switch (processType)
            {
                case ProcessType.SSIS:
                    ProcessProjectConfig ssisProjectConfig = ConfigurationHelper.GetProcessConfig().Projects[projectName];

                    if (ssisProjectConfig == null)
                        throw new Exception(string.Format("SSIS project configuration missing for '{0}'.", projectName));

                    SsisExecutor.ExecuteSsisProcess(ssisProjectConfig, processName, parameters);
                    break;
            }
        }
    }
}
