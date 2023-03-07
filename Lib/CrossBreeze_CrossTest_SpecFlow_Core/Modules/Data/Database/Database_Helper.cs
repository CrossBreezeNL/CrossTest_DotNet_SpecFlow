using CrossBreeze.CrossTest.Database.Helpers;
using CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Context;
using System;
using TechTalk.SpecFlow;
namespace CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database
{
    public static class Database_Helper
    {

        public static void ExecuteSqlAgentJob(
            ScenarioContext scenarioContext,
            string jobName
        )
        {
            ExecuteSqlAgentJobHelper(scenarioContext, jobName);
        }

        // Present time
        // SomeoneExecutesSqlAgentJob
        public static void ExecuteSqlAgentJobAsRole(
            ScenarioContext scenarioContext,
            string roleName,
            string jobName
        )
        {
            ExecuteSqlAgentJobHelper(scenarioContext, jobName);
        }

        /// <summary>
        /// Execute a SQL Agent job.
        /// </summary>
        /// <param name="jobName"></param>
        private static void ExecuteSqlAgentJobHelper(
            ScenarioContext scenarioContext, String jobName)
        {
            DataHelper.ExecuteSQLAgentJob(DatabaseContext.GetDatabaseContext(scenarioContext).DatabaseConnection, jobName);
        }

    }
}
