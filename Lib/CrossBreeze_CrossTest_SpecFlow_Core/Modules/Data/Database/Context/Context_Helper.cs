using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrossBreeze.CrossTest.Database.Configuration;
using CrossBreeze.CrossTest.SpecFlow.Helpers;

namespace CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Context
{
    public static class Context_Helper
    {

        public static void SpecifyTargetDatabaseServer(
            string databaseServerName
        )
        {
            // Find the server configuration in the config.
            DatabaseServerConfig serverConfig = ConfigurationHelper.GetDatabaseConfig().Servers[databaseServerName];
            // Assert the server config is found.
            Assert.IsNotNull(serverConfig, string.Format("The server configuration for '{0}' cannot be found!", databaseServerName));

            // Create the SQL Connection to use.
            string defaultConnectionString = ConfigurationHelper.GetConnectionString(serverConfig.ConnectionName);
            // Assert the connection string is configured.
            Assert.IsNotNull(defaultConnectionString, string.Format("The connection '{0}' is not configured!", databaseServerName));
            // Set the database connection.
            DatabaseContext.GetDatabaseContext().SetDefaultDatabaseConnection(serverConfig.Type, defaultConnectionString);

            // Open a connection to the database server.
            DatabaseContext.GetDatabaseContext().DatabaseConnection.Open();
        }

        public static void SpecifyTargetDatabase(
            string databaseName
        )
        {
            // Before we change the database, the connection must exist and be open.
            Assert.IsTrue(DatabaseContext.GetDatabaseContext().DatabaseConnection != null, "The default database server connection is not set!");
            Assert.IsTrue(DatabaseContext.GetDatabaseContext().DatabaseConnection.State == ConnectionState.Open, "The default database connection is not opened!");

            // Change the database for the current connection.
            DatabaseContext.GetDatabaseContext().DatabaseConnection.ChangeDatabase(databaseName);
        }

        public static void SpecifyTestTransaction()
        {
            // Before we can begin the transaction, the connection must exist and be open.
            Assert.IsTrue(DatabaseContext.GetDatabaseContext().DatabaseConnection != null, "The default database server connection is not set!");
            Assert.IsTrue(DatabaseContext.GetDatabaseContext().DatabaseConnection.State == ConnectionState.Open, "The default database connection is not opened!");
            Assert.IsNull(DatabaseContext.GetDatabaseContext().DatabaseTransaction, "A transaction on the database connection already exists!");

            // Begin the transaction with Serializable isolation level.
            DatabaseContext.GetDatabaseContext().BeginTransaction();
        }

    }
}
