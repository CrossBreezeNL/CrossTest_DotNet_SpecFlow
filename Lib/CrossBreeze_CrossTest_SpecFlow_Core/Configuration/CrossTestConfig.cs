using System.Configuration;
using CrossBreeze.CrossTest.SpecFlow.Configuration.Database;
using CrossBreeze.CrossTest.SpecFlow.Configuration.Process;
using CrossBreeze.CrossTest.SpecFlow.Configuration.Test;
using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.SpecFlow.Configuration
{
    [XDoc(Description = "The CrossTest configuration to configure all information needed for the steps to execute.")]
    public class CrossTestConfig : ConfigurationSection
    {
        public static CrossTestConfig GetConfig()
        {
            return (CrossTestConfig)System.Configuration.ConfigurationManager.GetSection("crossTest") ?? new CrossTestConfig();
        }

        // Test
        [ConfigurationProperty("test")]
        [XDoc(Description ="Configuration of test specifics such as default values, naming conventions etc")]
        public TestConfig Test => this["test"] as TestConfig;

        // Database
        [ConfigurationProperty("database")]
        [XDoc(Description ="Database configurations")]
        public DatabaseConfig Database => this["database"] as DatabaseConfig;
    }
}
