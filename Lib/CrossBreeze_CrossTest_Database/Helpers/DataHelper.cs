using System;
using System.Collections.Generic;
// For DataTable.
using System.Data;
// For IDbConnection.
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace CrossBreeze.CrossTest.Database.Helpers
{
    public static class DataHelper
    {
        // Static field names used in the QueryParameters Table.
        const string QueryParameters_FieldName_Name = "Name";
        const string QueryParameters_FieldName_Value = "Value";
        const string QueryParameters_FieldName_DataType = "DataType";

        /// <summary>
        /// Get a DataTable filled with the content of a table (tableName) in a database (using the connection with the name of connectionName)
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dbObjectName"></param>
        /// <returns></returns>
        public static IDataReader GetColumnDataFromDBObject(IDbConnection sqlConn, IDbTransaction sqlTran, string dbObjectName, string selectedColumns, string whereCondition="")
        {
            return GetDataReaderFromQuery(sqlConn, sqlTran, string.Format("SELECT {0} FROM {1}{2}", selectedColumns, dbObjectName, whereCondition));
        }

        public static IDataReader GetColumnDataFromDBObject(IDbConnection sqlConn, string dbObjectName, string selectedColumns, string whereCondition = "")
        {
            return GetColumnDataFromDBObject(sqlConn, null, dbObjectName, selectedColumns, whereCondition);
        }

        /// <summary>
        /// Execute Stored Procedure
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        public static IDataReader ExecuteStoredProcedure(IDbConnection sqlConn, string procedureName)
        {

            //TODO: Add parameter exectution from table
            return GetDataReaderFromQuery(sqlConn, string.Format("EXEC({0})", procedureName));
        }

        /// <summary>
        /// Execute Agent Job in de msdb database
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlAgentJobName"></param>
        /// <returns></returns>
        public static void ExecuteSQLAgentJob(IDbConnection sqlConn, string sqlAgentJobName)
        {
            //Execute sp call to start job and immediately close data reader since it is not used.
            SqlDataReader reader =  GetDataReaderFromQuery(sqlConn, string.Format("[msdb].[dbo].[sp_start_job] {0}", sqlAgentJobName));
            reader.Close();
            //Poll for job completion, timeout on 10 minutes
            //Retry until current job status is idle (=4)
            int jobStatus = 0;
            int attempt = 0;
            int waitSeconds = 2;
            int maxAttempts = 3600 / waitSeconds;
            do
            {
                System.Threading.Thread.Sleep(waitSeconds * 1000);
                //Read job status
                reader = GetDataReaderFromQuery(sqlConn, string.Format("exec msdb.dbo.sp_help_job @job_name = '{0}', @job_aspect='JOB'", sqlAgentJobName));
                //Go to first record
                reader.Read();
                
                jobStatus = reader.GetInt32(reader.GetOrdinal("current_execution_status"));
                attempt += 1;
                reader.Close();
                
            } while ((jobStatus != 4) && (attempt < maxAttempts * 30));

        }


        /// <summary>
        /// Execute SQL File
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        public static void ExecuteSQLFile(IDbConnection sqlConn, string filePath)
        {
            string directory = Directory.GetParent(Environment.CurrentDirectory).ToString();
            string newDir = Path.GetFullPath(Path.Combine(directory, @"..\"));
            string fileLocation = Path.GetFullPath(Path.Combine(newDir, filePath));

            string script = File.ReadAllText(fileLocation);

            ExecuteQuery(sqlConn, script);
        }

        public static DataTable GetDataTableFromDataReader(IDataReader dataReader)
        {
            // Load the DataTable with the output of the query of the SQLDataReader.
            DataTable dt = new DataTable();
            dt.Load(dataReader);

            // When there are rows in the DataTable check the columns for object datatypes.
            if (dt.Rows.Count > 0)
            {
                Dictionary<string, Type> resultColumnTypes = new Dictionary<string, Type>();
                foreach (DataColumn col in dt.Columns)
                {
                    // If the DataType is object, see whether there is a unique datatype the row.
                    if (col.DataType == typeof(object))
                    {
                        int rowIndex = 0;
                        // Set the type of the col to the type of the first row.
                        Type firstRowType = dt.Rows[rowIndex][col].GetType();
                        if (firstRowType != col.DataType) {
                            bool foundOtherTypeInCol = false;
                            // Loop through all rows after the first to check whether there are rows with a different datatype.
                            for (++rowIndex; rowIndex < dt.Rows.Count; rowIndex++)
                            {
                                Type cellDataType = dt.Rows[rowIndex].GetType();
                                if (cellDataType != firstRowType)
                                {
                                    foundOtherTypeInCol = true;
                                    break;
                                }
                            }
                            // If after the last column the datatype still equals the first column, set the datatype on the column.
                            if (!foundOtherTypeInCol)
                                resultColumnTypes.Add(col.ColumnName, firstRowType);
                        }
                    }
                }

                // If data types need to change, clone the datatable to set new data types.
                if (resultColumnTypes.Count > 0)
                {
                    // Clone the data type (so a empty datatable is created with the same data types).
                    DataTable typedDataTable = dt.Clone();
                    // Set the data types for all columns which have a new data type.
                    foreach (String columnName in resultColumnTypes.Keys)
                    {
                        // Update the data type.
                        typedDataTable.Columns[columnName].DataType = resultColumnTypes[columnName];
                    }
                    // Copy all row contains into the cloned table.
                    foreach (DataRow row in dt.Rows)
                    {
                        typedDataTable.ImportRow(row);
                    }
                    // Override the dt variable reference to the new DataTable.
                    dt = typedDataTable;
                }
            }

            // Return the DataTable.
            return dt;
        }

        public static Dictionary<string, Type> GetColumnTypesFromReader(IDataReader dataReader)
        {
            // Create case-insensitive dictionary.
            Dictionary<string, Type> columnTypes = new Dictionary<string, Type>(StringComparer.InvariantCultureIgnoreCase);

            for (int i = 0; i < dataReader.FieldCount; i++) {

                columnTypes.Add(dataReader.GetName(i), dataReader.GetFieldType(i));
            }

            return columnTypes;
        }

        public static Dictionary<string, Type> GetColumnTypesFromDataTable(DataTable dataTable)
        {
            // Create case-insensitive dictionary.
            Dictionary<String, Type> columnTypes = new Dictionary<string, Type>(StringComparer.InvariantCultureIgnoreCase);
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                columnTypes.Add(dataColumn.ColumnName, dataColumn.DataType);
            }
            return columnTypes;
        }

        public static Dictionary<string, Type> GetColumnTypesFromDBObject(IDbConnection sqlConn, IDbTransaction sqlTran, String dbObjectName, List<string> selectedColumnList)
        {
            // Create a comma seperated list of columns to select.
            String selectedColumnString = string.Join(", ", selectedColumnList.Select(col => string.Format("[{0}]", col)).ToArray<string>());
            // Get a empty resultset with all columns to fetch the data types.
            IDataReader sqlDataReader = GetColumnDataFromDBObject(sqlConn, sqlTran, dbObjectName, selectedColumnString, "WHERE 0=1");
            Dictionary<string, Type> columnTypes = GetColumnTypesFromReader(sqlDataReader);
            sqlDataReader.Close();
            return columnTypes;
        }

        public static SqlDataReader GetDataReaderFromQuery(IDbConnection sqlConn, string sqlQuery, DataTable queryParameters = null)
        {
            return (SqlDataReader)GetDataReaderFromQuery(sqlConn, null, sqlQuery, queryParameters);
        }

        /// <summary>
        /// Get a filled DataTable by executing the sqlQuery with the queryParameters on the connection (with connectionName).
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlQuery"></param>
        /// <param name="queryParameters">A DataTable with the columns [Name], [Value], [DataType]. Here the DataType should be filled with the SqlDbType (https://msdn.microsoft.com/en-us/library/system.data.sqldbtype.aspx).</param>
        /// <returns></returns>
        public static IDataReader GetDataReaderFromQuery(IDbConnection sqlConn, IDbTransaction sqlTran, string sqlQuery, DataTable queryParameters = null)
        {
            // Create the Sql Command.
            IDbCommand cmd = sqlConn.CreateCommand();
            if (sqlTran != null)
                cmd.Transaction = sqlTran;
            cmd.CommandText = sqlQuery;
            cmd.CommandType = CommandType.Text;

            // If the queryParameters are supplied, set it in the SqlCommand object.
            if (queryParameters != null)
            {
                foreach (DataRow queryParameterRow in queryParameters.Rows)
                {
                    SqlParameter sqlParam = new SqlParameter
                    {
                        ParameterName = queryParameterRow[QueryParameters_FieldName_Name].ToString(),
                        Value = queryParameterRow[QueryParameters_FieldName_Value],
                        SqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), queryParameterRow[QueryParameters_FieldName_DataType].ToString(), true)
                    };
                    cmd.Parameters.Add(sqlParam);
                }
            }

            IDataReader queryData = cmd.ExecuteReader();
            return queryData;
        }

        /// <summary>
        /// Get a filled DataTable by executing the sqlQuery with the queryParameters on the connection (with connectionName).
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlQuery"></param>
        /// <param name="queryParameters">A DataTable with the columns [Name], [Value], [DataType]. Here the DataType should be filled with the SqlDbType (https://msdn.microsoft.com/en-us/library/system.data.sqldbtype.aspx).</param>
        /// <returns></returns>
        public static void ExecuteQuery(IDbConnection sqlConn, string sqlQuery, DataTable queryParameters = null)
        {

            // Create the Sql Command.
            IDbCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlQuery;

            // If the queryParameters are supplied, set it in the SqlCommand object.
            if (queryParameters != null)
            {
                foreach (DataRow queryParameterRow in queryParameters.Rows)
                {
                    SqlParameter sqlParam = new SqlParameter
                    {
                        ParameterName = queryParameterRow[QueryParameters_FieldName_Name].ToString(),
                        Value = queryParameterRow[QueryParameters_FieldName_Value],
                        SqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), queryParameterRow[QueryParameters_FieldName_DataType].ToString(), true)
                    };
                    cmd.Parameters.Add(sqlParam);
                }
            }

            int x = cmd.ExecuteNonQuery();
        }


        /// <summary>
        /// Execute Agent Job in de msdb database
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        public static void InsertIntoSQLTable(IDbConnection sqlConn, string destinationTable, string destinationColumns, DataTable destinationValues)
        {
            // TODO: The following way of writing data into a dynamic t-SQL statement is net very neat. Refactor this into more stable code.
            string queryString = string.Format("INSERT INTO {0}({1}) VALUES ", destinationTable, destinationColumns);
            foreach (DataRow row in destinationValues.Rows)
            {
                string valueString = "";
                foreach (var item in row.ItemArray)
                {
                    valueString += "'" + item + "'" + ",";
                }
                // Remove the last comma.
                valueString = valueString.Remove(valueString.Length - 1, 1);
                // Append the valuestring to the insert statement.
                queryString += string.Format("({0}),", valueString);
            }
            // Remove the last commad from the query string.
            queryString = queryString.Remove(queryString.Length - 1, 1);
            ExecuteQuery(sqlConn, queryString);
        }


        /// <summary>
        /// Load a given table (dataToWrite) to the table with destionationTableName as name to the database with connectionName as connection.
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataToWrite"></param>
        /// <param name="destinationTableName"></param>
        public static void PutDataTable(IDbConnection dbConn, IDbTransaction IDbTransaction, DataTable dataToWrite, String destinationTableName)
        {
            if (!dbConn.GetType().Equals(typeof(SqlConnection)))
                throw new Exception("Can't perform a Put operation on a non-SqlConnection.");

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy((SqlConnection)dbConn, SqlBulkCopyOptions.Default|SqlBulkCopyOptions.KeepIdentity, (SqlTransaction)IDbTransaction))
            {
                // Specify the destination table.
                bulkCopy.DestinationTableName = destinationTableName;

                
                // Create a ColumnMappings so the columns are mapped correctly.
                foreach (DataColumn column in dataToWrite.Columns)
                {
                    // Create a one-on-one mapping based on the column name specified on the input.
                    bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }

                bulkCopy.WriteToServer(dataToWrite);
            }
        }
    }
}
