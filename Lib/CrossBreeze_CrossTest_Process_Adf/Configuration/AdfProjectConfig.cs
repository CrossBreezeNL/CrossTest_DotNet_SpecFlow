using CrossBreeze.CrossDoc.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace CrossBreeze.CrossTest.Process.Adf.Configuration
{
    [XDoc(Title = "Process configuration", Description = "A configuration for a type of process.")]
    public class AdfProcessProjectConfig : ConfigurationElement
    {
        // Name
        [ConfigurationProperty("name", IsKey = true)]
        [XDoc(Description = "Name of the process configuration, used to refer to this configuration from test scenario's.")]
        public string Name => this["name"] as string;

        // ProcessType
        [ConfigurationProperty("processType", IsRequired = true, DefaultValue = AdfProcessType.AdfPipeline)]
        [XDoc(Description = "Only \"AdfPipeline\" is allowed at this moment.")]
        public AdfProcessType ProcessType => (AdfProcessType)this["processType"];

        // tenantID 
        [ConfigurationProperty("tenantID", IsRequired = true)]
        [XDoc("The ID of the azure environment you want to connect with.")]
        public string tenantID => this["tenantID"] as string;

        // subscriptionId 
        [ConfigurationProperty("subscriptionId", IsRequired = true)]
        [XDoc("The ID of the azure subscription on which the datafactory is located")]
        public string subscriptionId => this["subscriptionId"] as string;

        // applicationId (This app should be registered on Azure active directory and should have the role to write on ADF)
        [ConfigurationProperty("applicationId", IsRequired = true)]
        [XDoc("The ID of the app that got registered to Azure AD and has access to the datafactory on which the pipeline is located")]
        public string applicationId => this["applicationId"] as string;

        // clientSecret (this secret should be created on the application and can have a maximum lifetime of 2 years)
        [ConfigurationProperty("clientSecret", IsRequired = true)]
        [XDoc("The secret of the application")]
        public string clientSecret => this["clientSecret"] as string;

        // resourceGroupName 
        [ConfigurationProperty("resourceGroupName", IsRequired = true)]
        [XDoc("The resourceGroup on which the datafactory is located")]
        public string resourceGroupName => this["resourceGroupName"] as string;

        // dataFactoryName
        [ConfigurationProperty("dataFactoryName", IsRequired = true)]
        [XDoc("The datafactory on which the pipeline is located")]
        public string dataFactoryName => this["dataFactoryName"] as string;

        //// pipelineName 
        //[ConfigurationProperty("pipelineName", IsRequired = true)]
        //[XDoc("The pipelineName which should be run should be specified")]
        //public string pipelineName => this["pipelineName"] as string;

        // parameters 
        [ConfigurationProperty("parameters", IsRequired = false)]
        [XDoc("In case of a pipeline with parameters, The parameters of the pipeline need be specified")]
        public IDictionary<string, string> parameters => this["parameters"] as IDictionary<string, string>;


        // AdfProjectsConnectionsConfigElementCollection
        public class AdfProjectsConnectionsCollection : ConfigurationElementCollection
        {
            public new AdfProjectConnection this[string Name] => (AdfProjectConnection)BaseGet(Name);

            protected override ConfigurationElement CreateNewElement()
            {
                return new AdfProjectConnection();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((AdfProjectConnection)element).Name;
            }
        }
    }
}
