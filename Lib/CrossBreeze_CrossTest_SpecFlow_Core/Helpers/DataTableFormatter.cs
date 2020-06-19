using CrossBreeze.CrossTest.SpecFlow.Utils;
using System;
using System.Data;
using System.Text;

namespace CrossBreeze.CrossTest.SpecFlow.Helpers
{
    public class DataTableFormatter
    {
        /// <summary>
        /// Get a string representation of a DataTable.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static string GetTextualRepresentation(DataTable dataTable)
        {
            StringBuilder output = new StringBuilder();

            var columnsWidths = new int[dataTable.Columns.Count];

            // Get column widths
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    var length = GetCellString(row[i], dataTable.Columns[i].DataType).Length;
                    if (columnsWidths[i] < length)
                        columnsWidths[i] = length;
                }
            }

            // Get Column Titles
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var length = dataTable.Columns[i].ColumnName.Length;
                if (columnsWidths[i] < length)
                    columnsWidths[i] = length;
            }

            // Write Column titles
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                output.Append('|');
                AppendPaddedColumn(output, dataTable.Columns[i].ColumnName, columnsWidths[i] + 2);
            }
            output.Append("|\n" + new string('=', output.Length) + "\n");

            // Write Rows
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    output.Append('|');
                    AppendPaddedColumn(output, GetCellString(row[i], dataTable.Columns[i].DataType), columnsWidths[i] + 2);
                }
                output.Append("|\n");
            }
            return output.ToString();
        }

        /// <summary>
        /// Get the string representation of a cell value.
        /// </summary>
        /// <param name="cellValue"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private static string GetCellString(object cellValue, Type dataType)
        {
            // If the cell value is DBNull, return an emtpy string.
            if (cellValue.GetType().Equals(typeof(System.DBNull)))
                return String.Empty;
            // If the datatype is DataTableComparisonResult, return the of the Enum element.
            else if (dataType == typeof(DataTableComparisonResult))
                return Enum.GetName(typeof(DataTableComparisonResult), cellValue);
            // If the dataType is a byte array, return the string representation of the array. 
            else if (dataType == typeof(byte[]))
                return DataTypeUtils.ByteArrayToString((byte[])cellValue);
            // If the dataType is a string, return a quoted string.
            else if (dataType == typeof(string))
                return string.Format("'{0}'", cellValue);
            // Otherwise, return the string representation of the cell value.
            else
                return cellValue.ToString();
        }

        /// <summary>
        /// Append the specified text aligned left to the stringBuilder.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        private static void AppendPaddedColumn(StringBuilder stringBuilder, string text, int maxLength)
        {
            stringBuilder.Append(' ').Append(text).Append(' ', maxLength - text.Length);
        }
    }
}
