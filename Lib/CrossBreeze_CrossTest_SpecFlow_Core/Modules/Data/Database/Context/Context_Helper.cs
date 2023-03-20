using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrossBreeze.CrossTest.Database.Configuration;
using CrossBreeze.CrossTest.SpecFlow.Helpers;
using TechTalk.SpecFlow;

namespace CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Context
{
    public static class Context_Helper
    {

        public static void SpecifyTargetDatabaseServer(
            ScenarioContext scenarioContext,
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
            DatabaseContext.GetDatabaseContext(scenarioContext).SetDefaultDatabaseConnection(scenarioContext, serverConfig.Type, defaultConnectionString, serverConfig);

            // Open a connection to the database server.
            DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseConnection.Open();

            
            
        }

        public static void SpecifyTargetDatabase(
            ScenarioContext scenarioContext,
            string databaseName
        )
        {
            // Before we change the database, the connection must exist and be open.
            Assert.IsTrue(DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseConnection != null, "The default database server connection is not set!");
            Assert.IsTrue(DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseConnection.State == ConnectionState.Open, "The default database connection is not opened!");

            // Change the database for the current connection.
            DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseConnection.ChangeDatabase(databaseName);
        }

        public static void SpecifyTestTransaction(ScenarioContext scenarioContext)
        {
            // Before we can begin the transaction, the connection must exist and be open.
            Assert.IsTrue(DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseConnection != null, "The default database server connection is not set!");
            Assert.IsTrue(DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseConnection.State == ConnectionState.Open, "The default database connection is not opened!");
            Assert.IsNull(DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseTransaction, "A transaction on the database connection already exists!");

            // Begin the transaction with Serializable isolation level.
            DatabaseContext.GetDatabaseContext(scenarioContext).BeginTransaction(scenarioContext);
        }

    }
}
