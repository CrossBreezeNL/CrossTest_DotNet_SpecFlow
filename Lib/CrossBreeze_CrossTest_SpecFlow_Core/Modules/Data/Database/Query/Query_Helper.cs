using CrossBreeze.CrossTest.Database.Execution;
using CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Context;
using CrossBreeze.CrossTest.SpecFlow.Result.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.IO;
using TechTalk.SpecFlow;
using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Query
{
    public static class Query_Helper
    {

        /// <summary>
        /// The list of supported languages.
        /// </summary>
        public enum QueryLanguage
        {
            SQL,
            MDX
        }

        /// <summary>
        /// Execute a query of a certain type.
        /// </summary>
        /// <param name="queryLanguage">The query language</param>
        /// <param name="queryText">The query text</param>
        /// <returns></returns>
        private static DataTable ExecuteQueryHelper(
            ScenarioContext scenarioContext, QueryLanguage queryLanguage, String queryText)
        {
            switch (queryLanguage)
            {
                case QueryLanguage.SQL:
                    return QueryExecutor.ExecuteQueryAndGetResults(DatabaseContext.GetDatabaseContext(scenarioContext).CreateDbCommand(), queryText);
                case QueryLanguage.MDX:
                    return QueryExecutor.ExecuteQueryAndGetResults(DatabaseContext.GetDatabaseContext(scenarioContext).CreateDbCommand(), queryText);
                default:
                    throw new Exception(string.Format("The query language {0} is not supported yet!", Enum.GetName(typeof(QueryLanguage), queryLanguage)));
            }
        }

        private static String GetQueryFileText(
            ScenarioContext scenarioContext, String filePath)
        {
            string directory = Directory.GetParent(Environment.CurrentDirectory).ToString();
            string newDir = Path.GetFullPath(Path.Combine(directory, @"..\"));
            string fileLocation = Path.GetFullPath(Path.Combine(newDir, filePath));

            return File.ReadAllText(fileLocation);
        }

        #region DatabaseQuerySteps

        public static void ExecuteQuery
        (
            ScenarioContext scenarioContext,
            string queryLanguageName,
            string queryText
        )
        {
            QueryLanguage.TryParse(queryLanguageName, out QueryLanguage queryLanguage);
            // Assert the query language is supported.
            Assert.IsNotNull(queryLanguage, string.Format("The given query language is not valid ({0})", queryLanguageName));

            // Get the results of the query.
            DataTable queryResults = ExecuteQueryHelper(scenarioContext, queryLanguage, queryText);
            // Assert there are query results.
            Assert.IsNotNull(queryResults, "No query results returned!");
            // Store the results.
            ResultContext.GetResultContext(scenarioContext).SetResultTable(queryResults);
        }

        
        public static void ExecuteQueryFromFile(
            ScenarioContext scenarioContext,
            string queryLanguageName,
            string filePath
        )
        {
            // Execute the query.
            ExecuteQuery(scenarioContext, queryLanguageName, GetQueryFileText(scenarioContext, filePath));
        }
        #endregion

    }
}
