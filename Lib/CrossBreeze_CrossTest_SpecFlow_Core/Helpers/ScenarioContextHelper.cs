using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace CrossBreeze.CrossTest.SpecFlow.Helpers
{
    public static class ScenarioContextHelper
    {
        public enum ScenarioObjectType
        {
            Result,
            DatabaseContext
        }

        #region Object functions
        private static string getScenarioContextKey(ScenarioObjectType scenarioObjectType)
        {
            return Enum.GetName(scenarioObjectType.GetType(), scenarioObjectType);
        }

        public static object GetScenarioContextObject(ScenarioObjectType scenarioObjectType)
        {
            return ScenarioContext.Current[getScenarioContextKey(scenarioObjectType)];
        }

        public static bool HasScenarioContextObject(ScenarioObjectType scenarioObjecType)
        {
            return ScenarioContext.Current.ContainsKey(getScenarioContextKey(scenarioObjecType));
        }


        public static void SetScenarioContextObject(ScenarioObjectType scenarioObjectType, object scenarioObject)
        {
            ScenarioContext.Current.Add(getScenarioContextKey(scenarioObjectType), scenarioObject);
        }
        #endregion

        //public static SqlConnection GetScenarioContextSqlConnection(string connectionName)
        //{
        //    string sqlConnKey = GetSqlConnectionKey(connectionName);

        //    // If the connection is not used before, we create it.
        //    if (!ScenarioContext.Current.ContainsKey(sqlConnKey))
        //    {
        //        // Create the SqlConnection using the configuration connection strings.
        //        SqlConnection conn = new SqlConnection(ConfigurationHelper.GetConnectionString(connectionName));
        //        // Open the connection, so it can be used.
        //        conn.Open();
        //        // Add the connection to the scenario context collection.
        //        ScenarioContext.Current.Add(sqlConnKey, conn);
        //    }

        //    // Return the connection.
        //    return ScenarioContext.Current.Get<SqlConnection>(sqlConnKey);
        //}
    }
}
