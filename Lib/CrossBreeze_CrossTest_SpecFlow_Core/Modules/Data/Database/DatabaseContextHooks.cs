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
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            // If the default database server connection is set and open, close the SQL Connection.
            if (DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseConnection != null && DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseConnection.State == ConnectionState.Open)
            {
                // If a transaction exists, do a rollback.
                if (DatabaseContext.GetDatabaseContext(scenarioContext).IsTransactionOpen())
                    DatabaseContext.GetDatabaseContext(scenarioContext).RollbackTransaction();

                // Close the connection.
                DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseConnection.Close();
            }
        }
        #endregion Hooks
    }
}
