using System.Configuration;
using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.Process.Ssis.Configuration
{
    public class crossTestSsisConfig : ConfigurationSection
    {
        public static crossTestSsisConfig GetConfig()
        {
            return (crossTestSsisConfig)System.Configuration.ConfigurationManager.GetSection("crossTestSsis") ?? new crossTestSsisConfig();
        }

        // Process
        [ConfigurationProperty("SsisProcesses")]
        [ConfigurationCollection(typeof(SsisProcessConfigElementCollection), AddItemName = "SsisProcess")]
        [XDoc(Title = "Process configurations", Description = "A list of process configurations that can be used in test scenarios.")]
        public SsisProcessConfigElementCollection SsisProcesses => this["SsisProcesses"] as SsisProcessConfigElementCollection;

        // ProjectsConfigElementCollection
        public class SsisProcessConfigElementCollection : ConfigurationElementCollection
        {
            public new SsisProcessConfig this[string Name] => (SsisProcessConfig)BaseGet(Name);

            protected override ConfigurationElement CreateNewElement()
            {
                return new SsisProcessConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((SsisProcessConfig)element).Name;
            }
        }
    }
}
