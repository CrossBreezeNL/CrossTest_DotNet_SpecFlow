using System.Configuration;
using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.Process.Adf.Configuration
{
    public class crossTestAdfConfig : ConfigurationSection
    {
        public static crossTestAdfConfig GetConfig()
        {
            return (crossTestAdfConfig)System.Configuration.ConfigurationManager.GetSection("crossTestAdf") ?? new crossTestAdfConfig();
        }

        // Process
        [ConfigurationProperty("AdfProcesses")]
        [ConfigurationCollection(typeof(AdfProcessConfigElementCollection), AddItemName = "AdfProcess")]
        [XDoc(Title = "Process configurations", Description = "A list of process configurations that can be used in test scenarios.")]
        public AdfProcessConfigElementCollection AdfProcesses => this["AdfProcesses"] as AdfProcessConfigElementCollection;

        // ProjectsConfigElementCollection
        public class AdfProcessConfigElementCollection : ConfigurationElementCollection
        {
            public new AdfProcessConfig this[string Name] => (AdfProcessConfig)BaseGet(Name);

            protected override ConfigurationElement CreateNewElement()
            {
                return new AdfProcessConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((AdfProcessConfig)element).Name;
            }
        }
    }
}
