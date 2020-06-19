using CrossBreeze.CrossDoc.CustomAttributes;
using CrossBreeze.CrossTest.Process.Ssis.Configuration;
using System.Configuration;

namespace CrossBreeze.CrossTest.SpecFlow.Configuration.Process
{
    [XDoc(Description ="A collection of process configurations.")]
    public class ProcessConfig : ConfigurationElement
    {
        // Projects
        [ConfigurationProperty("projects")]
        [ConfigurationCollection(typeof(ProcessProjectsConfigElementCollection), AddItemName = "project")]
        [XDoc(Title ="Process configurations", Description ="A list of process configurations that can be used in test scenario's.")]
        public ProcessProjectsConfigElementCollection Projects => this["projects"] as ProcessProjectsConfigElementCollection;

        // ProjectsConfigElementCollection
        public class ProcessProjectsConfigElementCollection : ConfigurationElementCollection
        {
            public new ProcessProjectConfig this[string Name] => (ProcessProjectConfig)BaseGet(Name);

            protected override ConfigurationElement CreateNewElement()
            {
                return new ProcessProjectConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((ProcessProjectConfig)element).Name;
            }
        }
    }
}

