using CrossBreeze.CrossTest.SpecFlow.Helpers;
using System.Data;
using CrossBreeze.CrossTest.Database.Helpers;
using CrossBreeze.CrossTest.Database.Configuration;
using TechTalk.SpecFlow;

namespace CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Context
{
    public class DatabaseContext
    {
        #region Variables
        public IDbConnection DatabaseConnection;
        // Docs: https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/ms191440(v=sql.105)
        public IDbTransaction DatabaseTransaction;
        private DatabaseServerConfig databaseServerConfig;
        #endregion Variables

        public void SetDefaultDatabaseConnection(ScenarioContext scenarioContext, DatabaseServerConfig dbServerConfig, string connectionString)
        {
            //Store the databaseServer config entry
            this.databaseServerConfig = dbServerConfig;
            // If a database connection is set, while there is already a connection specified, close it.
            if (DatabaseConnection != null)
            {
                if (DatabaseConnection.State == ConnectionState.Open)
                {
                    // If there is still a transaction going on, do a rollback.
                    if (DatabaseTransaction != null)
                        DatabaseTransaction.Rollback();

                    DatabaseConnection.Close();
                }
            }

            DatabaseConnection = DatabaseServerHelper.GetConnection(dbServerConfig, connectionString);
        }

        public void BeginTransaction(ScenarioContext scenarioContext)
        {
            // Begin the transaction with configured isolation level.
            DatabaseTransaction = DatabaseConnection.BeginTransaction((IsolationLevel)System.Enum.Parse(typeof(IsolationLevel), this.databaseServerConfig.IsolationLevel));
        }

        public bool IsTransactionOpen()
        {
            return this.DatabaseTransaction != null;
        }

        public IDbCommand CreateDbCommand()
        {
            IDbCommand dbCommand = DatabaseConnection.CreateCommand();
            // Set the command timeout
            dbCommand.CommandTimeout = databaseServerConfig.CommandTimeout;

            // If there is a transaction, run the command within the transaction.
            if (IsTransactionOpen())
                dbCommand.Transaction = DatabaseTransaction;
            return dbCommand;
        }

        public void RollbackTransaction()
        {
            DatabaseTransaction.Rollback();
        }

        public static DatabaseContext GetDatabaseContext(ScenarioContext scenarioContext)
        {
            if (!ScenarioContextHelper.HasScenarioContextObject(scenarioContext, ScenarioContextHelper.ScenarioObjectType.DatabaseContext))
                ScenarioContextHelper.SetScenarioContextObject(scenarioContext, ScenarioContextHelper.ScenarioObjectType.DatabaseContext, new DatabaseContext());
            return ScenarioContextHelper.GetScenarioContextObject(scenarioContext, ScenarioContextHelper.ScenarioObjectType.DatabaseContext) as DatabaseContext;
        }
    }
}
