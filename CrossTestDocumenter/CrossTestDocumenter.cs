using System;
using System.Reflection;

namespace CrossTestDocumenter
{
    class CrossTestDocumenter
    {
        public static readonly string CROSSTEST_NAMESPACE = "CrossBreeze.CrossTest.";

        static void Main(string[] args)
        {

            // Load CrossBreeze CrossTest Core assembly
            Assembly configAssembly = Assembly.LoadFrom("C:\\Git\\Repos\\CrossBreeze\\CrossTest\\Crosstest_DotNet_SpecFlow\\Lib\\CrossBreeze_CrossTest_SpecFlow_Core\\bin\\Debug\\CrossBreeze.CrossTest.SpecFlow.Core.dll");
            // Get the Core Config type.
            Type configType = configAssembly.GetType("CrossBreeze.CrossTest.SpecFlow.Configuration.CrossTestConfig");
            // Create the specflow config documentation.
            new CrossTestConfigDocumenter().CreateConfigDocumentation
            (
                configType,
                "C:\\Git\\Repos\\CrossBreeze\\CrossTest\\CrossTest\\Generation\\Model\\CrossTestConfig.xml"
            );

            // Load CrossBreeze CrossTest Ssis assembly
            Assembly ssisProcessConfigAssembly = Assembly.LoadFrom("C:\\Git\\Repos\\CrossBreeze\\CrossTest\\Crosstest_DotNet_SpecFlow\\Lib\\CrossBreeze_CrossTest_Process_Ssis\\bin\\Debug\\CrossBreeze.CrossTest.Process.Ssis.dll");
            // Get the Ssis Config type.
            Type ssisConfigType = ssisProcessConfigAssembly.GetType("CrossBreeze.CrossTest.Process.Ssis.Configuration.SsisProcessesConfig");
            // Create the specflow config documentation.
            new CrossTestConfigDocumenter().CreateConfigDocumentation
            (
                ssisConfigType,
                "C:\\Git\\Repos\\CrossBreeze\\CrossTest\\CrossTest\\Generation\\Model\\SsisProcessesConfig.xml"
            );

            // Load CrossBreeze CrossTest Adf assembly
            Assembly AdfProcessConfigAssembly = Assembly.LoadFrom("C:\\Git\\Repos\\CrossBreeze\\CrossTest\\Crosstest_DotNet_SpecFlow\\Lib\\CrossBreeze_CrossTest_Process_Adf\\bin\\Debug\\CrossBreeze.CrossTest.Process.Adf.dll");
            // Get the Adf Config type.
            Type AdfConfigType = AdfProcessConfigAssembly.GetType("CrossBreeze.CrossTest.Process.Adf.Configuration.AdfProcessesConfig");
            // Create the specflow config documentation.
            new CrossTestConfigDocumenter().CreateConfigDocumentation
            (
                AdfConfigType,
                "C:\\Git\\Repos\\CrossBreeze\\CrossTest\\CrossTest\\Generation\\Model\\AdfProcessesConfig.xml"
            );

        }

    }
}
