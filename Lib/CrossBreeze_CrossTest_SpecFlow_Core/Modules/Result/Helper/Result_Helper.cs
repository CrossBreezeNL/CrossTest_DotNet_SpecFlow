using CrossBreeze.CrossTest.Database.Helpers;
using CrossBreeze.CrossTest.SpecFlow.Helpers;
using CrossBreeze.CrossTest.SpecFlow.Result.Context;
using CrossBreeze.CrossTest.SpecFlow.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using TechTalk.SpecFlow;

namespace CrossBreeze.CrossTest.SpecFlow.Modules.Result
{
    public static class Result_Helper
    {
        public static void CompareExpectedAndActualResult(
            ScenarioContext scenarioContext,
            Table expectedResultsTable
        )
        {
            // The results must be known.
            Assert.IsNotNull(ResultContext.GetResultContext(scenarioContext).ResultTable, "There are no results yet to compare with!");

            // Get the column types of the result set.
            Dictionary<String, Type> actualResultTypes = DataHelper.GetColumnTypesFromDataTable(ResultContext.GetResultContext(scenarioContext).ResultTable);

            // Convert the expected results using the column types from the actual results.
            DataTable expectedDataTable = TableExtensions.ToDataTable(expectedResultsTable, actualResultTypes);

            // Derive the delta between the two tables.
            DataTable differencesTable = DataTableHelper.CompareDataTables(expectedDataTable, ResultContext.GetResultContext(scenarioContext).ResultTable);

            if (differencesTable != null)
            {
                throw new Exception("The expected and actual results differ:\n" + DataTableFormatter.GetTextualRepresentation(differencesTable));
            }
        }
    }
}
