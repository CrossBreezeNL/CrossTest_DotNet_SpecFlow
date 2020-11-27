using CrossBreeze.CrossTest.SpecFlow.Helpers;
using System.Data;
using CrossBreeze.CrossTest.Database.Helpers;
using CrossBreeze.CrossTest.Database.Configuration;

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

        public void SetDefaultDatabaseConnection(DatabaseServerType serverType, string connectionString, DatabaseServerConfig dbServerConfig)
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

            DatabaseConnection = DatabaseServerHelper.GetConnection(serverType, connectionString);
        }

        public void BeginTransaction()
        {
            // Begin the transaction with Serializable isolation level.
            DatabaseTransaction = DatabaseConnection.BeginTransaction(IsolationLevel.Serializable);
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

        public static DatabaseContext GetDatabaseContext()
        {
            if (!ScenarioContextHelper.HasScenarioContextObject(ScenarioContextHelper.ScenarioObjectType.DatabaseContext))
                ScenarioContextHelper.SetScenarioContextObject(ScenarioContextHelper.ScenarioObjectType.DatabaseContext, new DatabaseContext());
            return ScenarioContextHelper.GetScenarioContextObject(ScenarioContextHelper.ScenarioObjectType.DatabaseContext) as DatabaseContext;
        }
    }
}
