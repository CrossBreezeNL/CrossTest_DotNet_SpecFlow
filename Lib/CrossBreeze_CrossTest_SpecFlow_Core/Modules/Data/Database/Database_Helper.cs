using CrossBreeze.CrossTest.Database.Helpers;
using CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Context;
using System;
namespace CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database
{
    public static class Database_Helper
    {

        public static void ExecuteSqlAgentJob(
            string jobName
        )
        {
            ExecuteSqlAgentJobHelper(jobName);
        }

        // Present time
        // SomeoneExecutesSqlAgentJob
        public static void ExecuteSqlAgentJobAsRole(
            string roleName,
            string jobName
        )
        {
            ExecuteSqlAgentJobHelper(jobName);
        }

        /// <summary>
        /// Execute a SQL Agent job.
        /// </summary>
        /// <param name="jobName"></param>
        private static void ExecuteSqlAgentJobHelper(String jobName)
        {
            DataHelper.ExecuteSQLAgentJob(DatabaseContext.GetDatabaseContext().DatabaseConnection, jobName);
        }

    }
}
