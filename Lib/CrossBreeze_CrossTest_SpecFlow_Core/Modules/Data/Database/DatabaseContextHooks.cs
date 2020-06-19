// For SpecFlow.
using TechTalk.SpecFlow;
// For DataTable.
using System.Data;
using CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database;

namespace CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Context
{
    [Binding]
    public partial class DatabaseContextHooks
    {
        #region Hooks
        [AfterScenario]
        public void AfterScenario()
        {
            // If the default database server connection is set and open, close the SQL Connection.
            if (DatabaseContext.GetDatabaseContext().DatabaseConnection != null && DatabaseContext.GetDatabaseContext().DatabaseConnection.State == ConnectionState.Open)
            {
                // If a transaction exists, do a rollback.
                if (DatabaseContext.GetDatabaseContext().IsTransactionOpen())
                    DatabaseContext.GetDatabaseContext().RollbackTransaction();

                // Close the connection.
                DatabaseContext.GetDatabaseContext().DatabaseConnection.Close();
            }
        }
        #endregion Hooks
    }
}
