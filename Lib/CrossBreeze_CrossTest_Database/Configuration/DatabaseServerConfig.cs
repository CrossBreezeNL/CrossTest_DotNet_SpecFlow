using CrossBreeze.CrossDoc.CustomAttributes;
using System;
using System.Configuration;

namespace CrossBreeze.CrossTest.Database.Configuration
{
    // DatabaseServerConfigElement
    [XDoc(Title ="Database server configuration", Description = "A configuration for a database server")]
    public class DatabaseServerConfig : ConfigurationElement
    {
        // Name
        [ConfigurationProperty("name")]
        [XDoc(Description ="The connection name that can be used in test scenario's to refer to this connection")]
        public string Name => this["name"] as string;

        // Type
        [ConfigurationProperty("type")]        
        public DatabaseServerType Type
        {
            get
            {
                if (!Enum.TryParse<DatabaseServerType>(this["type"].ToString(), out DatabaseServerType serverType))
                    throw new Exception(string.Format("The specified server type is not supported ({0})", this["type"].ToString()));

                return serverType;
            }
        }

        // AccessToken
        [ConfigurationProperty("accessToken")]
        [XDoc(Description = "The access token to use for the connection.")]
        public string AccessToken => this["accessToken"] as string;

        // CommandTimeout
        // ConnectionName
        [ConfigurationProperty("commandTimeout")]
        [XDoc(Description = "Timeout on queries and statements in seconds.")]
        public int CommandTimeout {
            get
            {
                Int32? cmdt = this["commandTimeout"] as Int32?;
                if (cmdt != null)
                {
                    return cmdt.Value;
                } else
                {
                    //default command timeout to 30 seconds
                    return 30;
                }
            }
        }

        // ConnectionName
        [ConfigurationProperty("connectionName")]
        [XDoc(Description ="The name of the connection string defined in the config, that this database server config refers to.")]
        public string ConnectionName => this["connectionName"] as string;

        // Transaction isolation level
        [ConfigurationProperty("transactionIsolationLevel", DefaultValue = "Serializable")]
        [XDoc(Description = "The type of isolation level that is applied when running tests in a transaction.")]
        public string TransactionIsolationLevel => this["transactionIsolationLevel"] as string;


    }
}
