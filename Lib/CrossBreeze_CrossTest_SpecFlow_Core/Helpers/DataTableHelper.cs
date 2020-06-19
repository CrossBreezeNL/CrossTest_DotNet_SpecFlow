using CrossBreeze.CrossTest.SpecFlow.Providers;
using CrossBreeze.CrossTest.SpecFlow.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CrossBreeze.CrossTest.SpecFlow.Helpers
{
    public class DataTableHelper
    {
        const string DATATABLE_COMPARE_RESULT_COLUMN = "ComparisonResult";
        const string DATATABLE_COMPARE_HASH_COLUMN = "_RecordHash";

        /// <summary>
        /// Creates comma-separated list of column names from DataTable object. This string could be used in a SQL select statement instead of "Select *.."
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></return
        public static string GetSelectedColumnsStringFromTable(DataTable dataTable)
        {
            var columnString = new StringBuilder();

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {

                columnString.AppendFormat("[{0}]", dataTable.Columns[i].ColumnName);

                // Skip comma after the last column
                if (i < dataTable.Columns.Count - 1)
                    columnString.Append(", ");
            }

            return columnString.ToString();
        }

        /// <summary>
        /// Compare the exepectedDataTable with the actualDataTable and return the result of the comparison in a DataTable, or null of no differences were found.
        /// </summary>
        /// <param name="expectedDataTable"></param>
        /// <param name="actualDataTable"></param>
        /// <returns></returns>
        public static DataTable CompareDataTables(DataTable expectedDataTable, DataTable actualDataTable)
        {
            bool differencesFound = false;

            // Create a DataColumn array for all columns of both data tables.
            DataColumn[] expectedDataColumns = expectedDataTable.Columns.Cast<DataColumn>().ToArray();

            // Check the columns to compare in the actual table.
            foreach (DataColumn expectedColumn in expectedDataColumns)
            {
                // Contains is case insensitive here, so no need to upper or lower.
                if (!actualDataTable.Columns.Contains(expectedColumn.ColumnName))
                    throw new Exception(string.Format("The actual dataset doesn't contain the expected column '{0}'.", expectedColumn.ColumnName));

                // Store a reference to the actual column.
                DataColumn actualColumn = actualDataTable.Columns[expectedColumn.ColumnName];
                // Check whether the expected and actual column have the same datatype.
                if (!actualColumn.DataType.Equals(expectedColumn.DataType))
                    throw new Exception(string.Format("The data type of the actual column '{0}' doesn't match the expected datatype '{1}'.", actualColumn.DataType.Name, expectedColumn.DataType.Name));
            }

            // Add a RecordHash to both tables to created the CompareRelation on.
            String[] columnsToHash = expectedDataColumns.Select(ec => ec.ColumnName).ToArray<String>();
            DataColumn expectedRecordHashColumn = AddRecordHashColumn(expectedDataTable, columnsToHash);
            DataColumn actualRecordHashColumn = AddRecordHashColumn(actualDataTable, columnsToHash);

            // When running in debug mode, write the actual results to the console.
            System.Diagnostics.Debug.WriteLine("Expected results:");
            System.Diagnostics.Debug.WriteLine(DataTableFormatter.GetTextualRepresentation(expectedDataTable));

            // When running in debug mode, write the actual results to the console.
            System.Diagnostics.Debug.WriteLine("Actual results:");
            System.Diagnostics.Debug.WriteLine(DataTableFormatter.GetTextualRepresentation(actualDataTable));

            // We add a column to store the comparison result.
            DataColumn comparisonResultColumn = expectedDataTable.Columns.Add(DATATABLE_COMPARE_RESULT_COLUMN, typeof(DataTableComparisonResult));
            // Move the column to the first position.
            comparisonResultColumn.SetOrdinal(0);
            // First we accept all changes, so we are sure no changes are marked.
            expectedDataTable.AcceptChanges();

            // Create a DataSet for both datasets.
            DataSet allDataSet = new DataSet("ExpectedAndActualDataSet");
            allDataSet.Tables.Add(expectedDataTable);
            allDataSet.Tables.Add(actualDataTable);
            // Disable enforing constraints, so the when a parent row doesn't exists when applying the FK from the child to the parent it doesn't throw a exception.
            allDataSet.EnforceConstraints = false;
            // Accept the changes on all datasets.
            allDataSet.AcceptChanges();

            // Create a relation between both datasets on all columns (to be able to compare).
            DataRelation compareRelation = new DataRelation("CompareRelation", expectedRecordHashColumn, actualRecordHashColumn);
            // Add the relation to the dataset.
            allDataSet.Relations.Add(compareRelation);
            // Accept changes on all datasets.
            allDataSet.AcceptChanges();

            // Loop through all rows to check the relation with the actual dataset.
            foreach (DataRow expectedRow in expectedDataTable.Rows)
            {
                DataRow[] actualRows = expectedRow.GetChildRows(compareRelation);
                if (actualRows.Length == 0)
                {
                    // The current row was not found, so we set the state to Deleted.
                    expectedRow.SetField<DataTableComparisonResult>(comparisonResultColumn, DataTableComparisonResult.ExpectedNotFound);
                    differencesFound = true;
                }
                // If there is one or more actual rows, delete the first actual row.
                else
                {
                    // Set the status of the expected row to matched.
                    expectedRow.SetField<DataTableComparisonResult>(comparisonResultColumn, DataTableComparisonResult.Matched);
                    // Delete the first matched actual row.
                    actualRows[0].Delete();
                }
            }

            // Accept all changes on the actual dataset.
            actualDataTable.AcceptChanges();

            // Loop through the actual set and add all rows (which where not related to the expected) with status NotExpected.
            foreach (DataRow actualRow in actualDataTable.Rows)
            {
                // Create a row in the expected data table for the 'NotExpected' row in the actual data table.
                DataRow notExpectedDataRow = expectedDataTable.NewRow();
                foreach (DataColumn expectedDataColumn in expectedDataTable.Columns)
                {
                    // If the column is the comparison column, set the value to NotExpected.
                    if (expectedDataColumn.Equals(comparisonResultColumn))
                    {
                        notExpectedDataRow.SetField<DataTableComparisonResult>(comparisonResultColumn, DataTableComparisonResult.NotExpected);
                    }
                    // Otherwise, copy the value from the actual data row.
                    else
                    {
                        notExpectedDataRow[expectedDataColumn] = actualRow[expectedDataColumn.ColumnName];
                    }
                }
                // Add the new data row.
                expectedDataTable.Rows.Add(notExpectedDataRow);
                // Accept the changes on the expected table.
                expectedDataTable.AcceptChanges();

                // Set differencesFound to true.
                differencesFound = true;
            }

            if (differencesFound)
                return expectedDataTable;
            else
                return null;
        }

        /// <summary>
        /// Procedure to add the RecordHash column to the DataTable and compute the hashes.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="columnsToHashInOrder"></param>
        /// <returns></returns>
        private static DataColumn AddRecordHashColumn(DataTable dataTable, string[] columnsToHashInOrder)
        {
            Assert.IsFalse(dataTable.Columns.Contains(DATATABLE_COMPARE_HASH_COLUMN), string.Format("Can't compare results, the column '{0}' already exists!", DATATABLE_COMPARE_HASH_COLUMN));

            // Add the comparison result column.
            DataColumn RecordHashColumn = dataTable.Columns.Add(DATATABLE_COMPARE_HASH_COLUMN, typeof(byte[]));

            // Loop through the rows to create the hash value.
            foreach (DataRow rowToHash in dataTable.Rows)
            {
                using (MemoryStream hashMemoryStream = new MemoryStream())
                {
                    // Loop through the columns in the order they must be hashed to append the bytes to hash.
                    foreach (string columnToHash in columnsToHashInOrder)
                    {
                        var cellValueToHash = rowToHash[columnToHash];
                        Type cellValueType = cellValueToHash.GetType();

                        // If the cell value is a byte array, write the bytes into the stream directly.
                        if (cellValueType == typeof(byte[]))
                        {
                            MemoryStreamUtils.WriteBytes(hashMemoryStream, (byte[])cellValueToHash);
                        }
                        // If the cell value is a byte, write the byte into the stream directly.
                        else if (cellValueType == typeof(byte))
                        {
                            hashMemoryStream.WriteByte((byte)cellValueToHash);
                        }
                        // If the type of the cell value is a primitive type or a Decimal, use the hash code.
                        else if (cellValueType.IsPrimitive || cellValueType == typeof(Decimal))
                        {
                            // Append the cell hash bytes to the hash memory stream.
                            MemoryStreamUtils.WriteInt(hashMemoryStream, cellValueToHash.GetHashCode());
                        }
                        // If the value is a string, get the string bytes.
                        else if (cellValueType == typeof(string))
                        {
                            MemoryStreamUtils.WriteString(hashMemoryStream, (string)cellValueToHash);
                        }
                        // Otherwise, serialize the object using the BinaryFormatter.
                        // TODO: Test whether this really works for comparing objects.
                        else
                        {
                            BinaryFormatterProvider.BinaryFormatter.Serialize(hashMemoryStream, cellValueToHash);
                        }
                    }
                    // Create a hash and store it in the RecordHash column.
                    rowToHash[RecordHashColumn] = GetMD5Hash(hashMemoryStream.GetBuffer());
                }
            }

            return RecordHashColumn;
        }

        /// <summary>
        /// Compute the MD5 hash for a string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static byte[] GetMD5Hash(byte[] input)
        {
            return HashAlgorithmProvider.HashAlgorithm.ComputeHash(input);
        }
    }
}
