using CrossBreeze.CrossDoc.CustomAttributes;
using System;
using System.Configuration;

namespace CrossBreeze.CrossTest.Process.Ssis.Configuration
{
    [XDoc(Title ="Process configuration", Description ="A configuration for a type of process.")]
    public class ProcessProjectConfig : ConfigurationElement
    {

        // Name
        [ConfigurationProperty("name", IsKey = true)]
        [XDoc(Description ="Name of the process configuration, used to refer to this configuration from test scenario's.")]
        public string Name => this["name"] as string;

        // ProcessType
        [ConfigurationProperty("processType", IsRequired = true, DefaultValue = SsisProcessType.ISPac)]
        public SsisProcessType ProcessType => (SsisProcessType)this["processType"];

        // IsPacFileLocation (only used when processType=IsPac)
        [ConfigurationProperty("isPacFileLocation")]
        [XDoc("In case of a process configuration where processType is ISPac, the isPacFileLocation needs to be specified.")]
        public string IsPacFileLocation => this["isPacFileLocation"] as string;

        // SsisConnectionName (only used when processType=SqlServer or ISServer)
        [ConfigurationProperty("ssisConnectionName")]
        [XDoc("In case of a process configuration where processType is SqlServer or ISServer, the ssisConnectionName needs to be specified, referring to a connectionstring that is defined in the config elsewhere.")]
        public string SsisConnectionName => this["ssisConnectionName"] as string;

        // SsisFolder (only used when processType=SqlServer)
        [ConfigurationProperty("ssisFolder")]
        [XDoc("In case of a process configuration where processType is SqlServer the ssisFolder needs to be specified.")]
        public string SsisFolder => this["ssisFolder"] as string;

        // SsisProject (only used when processType=SqlServer)
        [ConfigurationProperty("ssisProject")]
        [XDoc("In case of a process configuration where processType is SqlServer the ssisProject needs to be specified.")]
        public string SsisProject => this["ssisProject"] as string;

        // SsisEnvironmentFolder (only used when processType=SqlServer)
        [ConfigurationProperty("ssisEnvironmentFolder")]
        [XDoc("In case of a process configuration where processType is SqlServer the ssisEnvironmentFolder needs to be specified.")]
        public string SsisEnvironmentFolder => this["ssisEnvironmentFolder"] as string;

        // SsisEnvironmentName (only used when processType=SqlServer)
        [ConfigurationProperty("ssisEnvironmentName")]
        [XDoc("In case of a process configuration where processType is SqlServer the ssisEnvironmentName needs to be specified.")]
        public string SsisEnvironmentName => this["ssisEnvironmentName"] as string;

        // Use32RuntimeOn64
        [ConfigurationProperty("use32RuntimeOn64")]
        [XDoc("In case of a process configuration where a SSIS processType is used (ISPac, ISServer) this property can be used to use the 32 bits runtime on 64 bits servers.")]
        public bool? Use32RuntimeOn64 => this["use32RuntimeOn64"] as bool?;

        // SsisFilePath (only used when processType=FileSystem)
        [ConfigurationProperty("ssisFilePath")]
        [XDoc("In case of a process configuration where processType is FileSystem the ssisFilePath needs to be specified.")]
        public string SsisFilePath => this["ssisFilePath"] as string;

        // Connections
        [ConfigurationProperty("connections")]
        [ConfigurationCollection(typeof(SsisProjectsConnectionsCollection), AddItemName = "connection")]
        [XDoc("A collection of connections used in the process configuration, for example source/target connections for SSIS packages.")]
        public SsisProjectsConnectionsCollection Connections => this["connections"] as SsisProjectsConnectionsCollection;

        // SsisProjectsConnectionsConfigElementCollection
        public class SsisProjectsConnectionsCollection : ConfigurationElementCollection
        {
            public new SsisProjectConnection this[string Name] => (SsisProjectConnection)BaseGet(Name);

            protected override ConfigurationElement CreateNewElement()
            {
                return new SsisProjectConnection();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((SsisProjectConnection)element).Name;
            }
        }
    }
}
