using System;
using System.Reflection;

namespace CrossTestDocumenter
{
    class CrossTestDocumenter
    {
        public static readonly string CROSSTEST_NAMESPACE = "CrossBreeze.CrossTest.";

        static void Main(string[] args)
        {

            // Load CrossBreeze CrossTest assembly
            // Loading from the CrossTestdocumenter debug folder otherwise the getCustomAttribute stepDocAttribute cannot be loaded
            Assembly configAssembly = Assembly.LoadFrom("C:\\GIT\\Repos\\CrossBreeze\\CrossTest\\Crosstest_DotNet_SpecFlow\\Lib\\CrossBreeze_CrossTest_SpecFlow_Core\\bin\\Debug\\CrossBreeze.CrossTest.SpecFlow.Core.dll");

            //Assembly databaseConfigAssembly = Assembly.LoadFrom("C:\\GIT\\Repos\\CrossBreeze\\CrossTest\\CrossTest\\CrossTestDocumenter\\bin\\Debug\\CrossBreeze.CrossTest.Database.dll");
            //Assembly ssisProcessConfigAssembly = Assembly.LoadFrom("C:\\GIT\\Repos\\CrossBreeze\\CrossTest\\CrossTest\\CrossTestDocumenter\\bin\\Debug\\CrossBreeze.CrossTest.Process.Ssis.dll");

            // Get the Config type.
            Type configType = configAssembly.GetType("CrossBreeze.CrossTest.SpecFlow.Configuration.CrossTestConfig");

            //Type databaseConfigType = configAssembly.GetType("CrossBreeze.CrossTest.Database.Configuration.DatabaseServerConfig");
            //Type ssisProcessType = configAssembly.GetType("CrossBreeze.CrossTest.SpecFlow.Configuration.CrossTestConfig");

            // Create the specflow config documentation.
            new CrossTestConfigDocumenter().CreateConfigDocumentation
            (
                configType,
                "C:\\GIT\\Repos\\CrossBreeze\\CrossTest\\CrossTest\\Generation\\Model\\CrossTestConfig.xml"
            );

            // Create the Specflow Steps documentation.
            // Replaced by documentation from PDM
            /*new CrossTestStepsDocumenter().CreateSpecflowDocumentation(
                configAssembly,
                "C:\\GIT\\Repos\\CrossBreeze\\CrossTest\\CrossTest\\Documentation\\generator\\Model\\CrossTestSpec.xml"
            );
            */

        }

    }
}
