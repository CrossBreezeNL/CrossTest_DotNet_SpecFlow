using System;
using System.Collections.Generic;
using CrossBreeze.CrossTest.SpecFlow.Configuration.Process;
using CrossBreeze.CrossTest.Process.Ssis;
using CrossBreeze.CrossTest.Process.Adf;

namespace CrossBreeze.CrossTest.SpecFlow.Helpers
{
    public static class ETLHelper
    {

        public static void ExecuteProcess(ProcessType processType, String projectName, String processName, Dictionary<string, string> parameters = null)
        {
            switch (processType)
            {
                //case ProcessType.SSIS:
                //    SsisExecutor.ExecuteSsisProcess(projectName, processName, parameters);
                //    break;

                case ProcessType.SSIS:
                    AdfExecutor.ExecuteAdfProcess(projectName, processName, parameters);
                    break;
            }
        }
    }
}
