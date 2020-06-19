using CrossBreeze.CrossDoc.CustomAttributes;
using CrossBreeze.CrossTest.Database.Configuration;
using System.Configuration;

namespace CrossBreeze.CrossTest.SpecFlow.Configuration.Database
{
    [XDoc(Description = "A collection of database server configurations.")]
    public class DatabaseConfig : ConfigurationElement
    {
        // Servers
        [ConfigurationProperty("servers")]
        [ConfigurationCollection(typeof(ServersConfigCollection), AddItemName = "server")]
        [XDoc(Title ="Database servers",
              Description = "A list of database servers that are used in test scenario's."  
            )]
        public ServersConfigCollection Servers => this["servers"] as ServersConfigCollection;

        // ServersConfigElementCollection
        public class ServersConfigCollection : ConfigurationElementCollection
        {
            public new DatabaseServerConfig this[string Name] => (DatabaseServerConfig)BaseGet(Name);

            protected override ConfigurationElement CreateNewElement()
            {
                return new DatabaseServerConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((DatabaseServerConfig)element).Name;
            }
        }
    }
}
