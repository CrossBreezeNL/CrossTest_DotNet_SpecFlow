using CrossBreeze.CrossTest.Database.Helpers;
using System.Data;

namespace CrossBreeze.CrossTest.Database.Execution
{
    public static class QueryExecutor
    {
        public static DataTable ExecuteQueryAndGetResults(IDbCommand dbCommand, string dbQuery)
        {
            // Set the command type to Text.
            dbCommand.CommandType = CommandType.Text;
            // Set the Command text.
            dbCommand.CommandText = dbQuery;
            // Execute the query.
            IDataReader queryDataReader = dbCommand.ExecuteReader();
            // Store the results in a DataTable.
            DataTable queryResultsTable = DataHelper.GetDataTableFromDataReader(queryDataReader);
            // Close the data reader.
            queryDataReader.Close();
            // Return the DataTable.
            return queryResultsTable;
        }
    }
}
