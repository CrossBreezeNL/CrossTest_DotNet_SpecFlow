using System;
using System.Collections.Generic;
using CrossBreeze.CrossTest.SpecFlow.Configuration.Process;
using CrossBreeze.CrossTest.SpecFlow.Modules.Process;

namespace CrossBreeze.CrossTest.SpecFlow.Helpers
{
    public static class ETLHelper
    {

        public static void ExecuteProcess(ProcessType processType, String projectName, String processName, Dictionary<string, string> parameters = null)
        {
            var methodParameters = new object[3];
            methodParameters[0] = projectName;
            methodParameters[1] = processName;
            methodParameters[2] = parameters;
            switch (processType)
            {
                case ProcessType.SSIS:
                    Process_Helper.ExecuteProcess("CrossBreeze.CrossTest.Process.Ssis", "SsisExecutor", "ExecuteSsisProcess", methodParameters);
                    break;

                case ProcessType.ADF:
                    Process_Helper.ExecuteProcess("CrossBreeze.CrossTest.Process.Adf", "AdfExecutor", "ExecuteAdfProcess", methodParameters);
                    //AdfExecutor.ExecuteAdfProcess(projectName, processName, parameters);
                    break;
            }
        }
    }
}
