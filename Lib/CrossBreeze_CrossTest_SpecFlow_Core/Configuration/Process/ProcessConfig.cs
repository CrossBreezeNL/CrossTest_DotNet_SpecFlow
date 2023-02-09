using System.Configuration;
using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.SpecFlow.Configuration.Process
{
    [XDoc(Description ="A collection of process configurations.")]
    public class ProcessConfig : ConfigurationElement
    {
        // Name
        [ConfigurationProperty("name", IsKey = true)]
        [XDoc(Description = "Name of the process configuration, used to refer to this configuration from test scenario's.")]
        public string Name => this["name"] as string;

        // ProcessType
        [ConfigurationProperty("processType", IsRequired = true)]
        public ProcessType ProcessType => (ProcessType)this["processType"];
    }
}

