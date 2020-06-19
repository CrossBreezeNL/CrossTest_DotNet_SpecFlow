using CrossBreeze.CrossDoc.CustomAttributes;
using System.Configuration;

namespace CrossBreeze.CrossTest.Process.Ssis.Configuration
{
    [XDoc(Title ="Connection", Description = "Connection used in an SSIS package.")]
    public class SsisProjectConnection : ConfigurationElement
    {
        // Name
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        [XDoc(Description ="The name of the connection.")]
        public string Name => this["name"] as string;

        // ConnectionName
        [ConfigurationProperty("connectionName", IsRequired = true)]
        [XDoc(Description ="Name of connection that this SSIS connection refers to, should be an existing connectionstring defined in the configuration.")]
        public string ConnectionName => this["connectionName"] as string;

        public string ConnectionString
        {
            get
            {
                // Get the connection string from the ConfigurationManager.
                ConnectionStringSettings connStringSetting = ConfigurationManager.ConnectionStrings[this.ConnectionName];
                if (connStringSetting != null)
                    return connStringSetting.ConnectionString;

                return null;
            }
        }
    }
}
