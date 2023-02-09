using System.Configuration;
using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.Process.Ssis.Configuration
{
    public class SsisProcessesConfig : ConfigurationSection
    {
        public static SsisProcessesConfig GetConfig()
        {
            return (SsisProcessesConfig)System.Configuration.ConfigurationManager.GetSection("crossTestSsis") ?? new SsisProcessesConfig();
        }

        // Process
        [ConfigurationProperty("SsisProcesses")]
        [ConfigurationCollection(typeof(SsisProcessConfigElementCollection), AddItemName = "SsisProcess")]
        [XDoc(Title = "Process configurations", Description = "A list of process configurations that can be used in test scenarios.")]
        public SsisProcessConfigElementCollection SsisProcesses => this["SsisProcesses"] as SsisProcessConfigElementCollection;

        // ProjectsConfigElementCollection
        public class SsisProcessConfigElementCollection : ConfigurationElementCollection
        {
            public new SsisProcessProjectConfig this[string Name] => (SsisProcessProjectConfig)BaseGet(Name);

            protected override ConfigurationElement CreateNewElement()
            {
                return new SsisProcessProjectConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((SsisProcessProjectConfig)element).Name;
            }
        }
    }
}
