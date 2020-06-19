using CrossBreeze.CrossTest.Database.Helpers;
using CrossBreeze.CrossTest.SpecFlow.Configuration.Test;
using CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.Context;
using CrossBreeze.CrossTest.SpecFlow.Helpers;
using CrossBreeze.CrossTest.SpecFlow.Result.Context;
using CrossBreeze.CrossTest.SpecFlow.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TechTalk.SpecFlow;

namespace CrossBreeze.CrossTest.SpecFlow.Modules.Data.Database.DbTable
{
    public static class DbTable_Helper
    {
        #region DatabaseTableSteps

        public static void LoadDataIntoTable(
            string destinationTableName,
            Table dataToWrite
        )
        {
            // Write the data to the destionation table.
            WriteDataToTable(destinationTableName, dataToWrite);
        }

        public static void LoadDataIntoTemplatedTable(
            string objectTemplateName,
            string destinationTableName,
            Table dataToWrite
        )
        {
            // Get the table template config.
            ObjectTemplateConfig objectTemplateConfig = ConfigurationHelper.GetTestConfig().ObjectTemplates[objectTemplateName];
            // Assert the table template is known.
            Assert.IsNotNull(objectTemplateConfig, string.Format("The object template '{0}' is not found in the config!", objectTemplateName));
            // Write the data to the destionation table.
            WriteDataToTable(destinationTableName, dataToWrite, objectTemplateConfig);
        }

        public static void RetrieveDataFromTable(
            string tableOrViewSchema,
            string tableOrViewName
        )
        {
            // Create the SqlCommand.
            IDbCommand sqlFunctionCallCommand = DatabaseContext.GetDatabaseContext().CreateDbCommand();
            // Set the command type to text.
            sqlFunctionCallCommand.CommandType = CommandType.Text;

            // Construct the business rule function call.
            sqlFunctionCallCommand.CommandText = string.Format("SELECT * FROM [{0}].[{1}]", tableOrViewSchema, tableOrViewName);

            // Execute the function.
            IDataReader tableOrViewDataReader = sqlFunctionCallCommand.ExecuteReader();
            // Store the result table in the ResultContext.
            ResultContext.GetResultContext().SetResultTable(DataHelper.GetDataTableFromDataReader(tableOrViewDataReader));
            tableOrViewDataReader.Close();
        }

        public static void DeleteDataFromTable(
            string tableOrViewSchema,
            string tableOrViewName)
        {
            // Create the SqlCommand.
            IDbCommand sqlFunctionCallCommand = DatabaseContext.GetDatabaseContext().CreateDbCommand();
            // Set the command type to text.
            sqlFunctionCallCommand.CommandType = CommandType.Text;

            // Construct a statement to empty the table.
            sqlFunctionCallCommand.CommandText = string.Format("DELETE FROM [{0}].[{1}]", tableOrViewSchema, tableOrViewName);

            // Execute the function.
            int rowsDeleted = sqlFunctionCallCommand.ExecuteNonQuery();
        }
        #endregion

        #region Helpers
        private static void WriteDataToTable(String destinationTableName, Table dataToWrite, ObjectTemplateConfig objectTemplateConfig = null)
        {
            Dictionary<string, string> templateTableColumns = new Dictionary<string, string>();
            // If a table template is given, process it's columns.
            if (objectTemplateConfig != null)
                ConfigurationHelper.AddTemplateAttributes(templateTableColumns, objectTemplateConfig);

            // Derive the columns to insert.
            List<string> insertColumnsList = TableExtensions.GetSelectedColumnsStringFromTable(dataToWrite, templateTableColumns.Keys.ToList<string>());

            // Get the target column types from the target table.
            Dictionary<string, Type> targetColumnTypes = DataHelper.GetColumnTypesFromDBObject(DatabaseContext.GetDatabaseContext().DatabaseConnection, DatabaseContext.GetDatabaseContext().DatabaseTransaction, destinationTableName, insertColumnsList);

            // Convert the data to write to a DataTable using the target table columns data types.
            DataTable dataTableToWrite = TableExtensions.ToDataTable(dataToWrite, targetColumnTypes, templateTableColumns);

            DataHelper.PutDataTable(DatabaseContext.GetDatabaseContext().DatabaseConnection, DatabaseContext.GetDatabaseContext().DatabaseTransaction, dataTableToWrite, destinationTableName);
        }
        #endregion

    }
}
