using System.Configuration;
using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.Process.Adf.Configuration
{
    public class AdfProcessesConfig : ConfigurationSection
    {
        public static AdfProcessesConfig GetConfig()
        {
            return (AdfProcessesConfig)System.Configuration.ConfigurationManager.GetSection("crossTestAdf") ?? new AdfProcessesConfig();
        }

        // Process
        [ConfigurationProperty("AdfProcesses")]
        [ConfigurationCollection(typeof(AdfProcessConfigElementCollection), AddItemName = "AdfProcess")]
        [XDoc(Title = "Process configurations", Description = "A list of process configurations that can be used in test scenarios.")]
        public AdfProcessConfigElementCollection AdfProcesses => this["AdfProcesses"] as AdfProcessConfigElementCollection;

        // ProjectsConfigElementCollection
        public class AdfProcessConfigElementCollection : ConfigurationElementCollection
        {
            public new AdfProcessProjectConfig this[string Name] => (AdfProcessProjectConfig)BaseGet(Name);

            protected override ConfigurationElement CreateNewElement()
            {
                return new AdfProcessProjectConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((AdfProcessProjectConfig)element).Name;
            }
        }
    }
}
