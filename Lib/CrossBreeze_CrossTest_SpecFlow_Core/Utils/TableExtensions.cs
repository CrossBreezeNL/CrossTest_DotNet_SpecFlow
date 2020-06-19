using System;
using System.Data;
using System.Text;
using TechTalk.SpecFlow;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrossBreeze.CrossTest.SpecFlow.Utils
{
    public static class TableExtensions
    {
        public static DataTable ToDataTable(Table table, Dictionary<String, Type> columnTypes)
        {
            return ToDataTable(table, columnTypes, null);
        }

        public static DataTable ToDataTable(Table table, Dictionary<String, Type> columnTypes, Dictionary<string, string> templateTableColumns)
        {
            // Create the new DataTable.
            DataTable dataTable = new DataTable();

            // Add the columns from the specified table.
            foreach (var header in table.Header)
            {
                addColumnToDataTable(dataTable, header, columnTypes.ContainsKey(header) ? columnTypes[header] : null);
                // If the template column list contains this column, remove it as it is not needed.
                if (templateTableColumns != null && templateTableColumns.ContainsKey(header))
                    templateTableColumns.Remove(header);
            }

            // Add the columns from the table template.
            if (templateTableColumns != null)
            {
                foreach (String columnName in templateTableColumns.Keys)
                {
                    // No need to check whether the column exists, because existing columns have been removed in the previous loop.
                    addColumnToDataTable(dataTable, columnName, columnTypes.ContainsKey(columnName) ? columnTypes[columnName] : null);
                }
            }

            // Copy the rows.
            foreach (var row in table.Rows)
            {
                var newRow = dataTable.NewRow();

                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    // Get the raw value.
                    string rawValue;
                    if (templateTableColumns != null && templateTableColumns.ContainsKey(dataColumn.ColumnName))
                        rawValue = templateTableColumns[dataColumn.ColumnName];
                    else
                        rawValue = row[dataColumn.ColumnName];

                    // Set the value of the table cell.
                    newRow[dataColumn.ColumnName] = TableExtensions.GetDataTypedValue(rawValue, dataColumn.DataType);
                }

                dataTable.Rows.Add(newRow);
            }

            // Return the new DataTable.
            return dataTable;
        }

        private static void addColumnToDataTable(DataTable dataTable, string columnName, Type columnType)
        {
            // ContainsKey is case insensitive here, so no need to upper or lower.
            if (columnType != null)
            {
                // Add the column using the specified column type.
                DataColumn newColumn = dataTable.Columns.Add(columnName, columnType);
            }
            else
            {
                dataTable.Columns.Add(columnName, typeof(string));
            }
        }

        public static List<string> GetSelectedColumnsStringFromTable(Table table, List<string> tableTemplateColumns)
        {
            List<string> columnNames = new List<string>();

            // Add the column names from the table.
            foreach (String headerName in table.Header)
            {
                columnNames.Add(headerName);
            }

            if (tableTemplateColumns != null)
            {
                foreach (String tableTemplateColumn in tableTemplateColumns)
                {
                    if (!columnNames.Contains(tableTemplateColumn))
                        columnNames.Add(tableTemplateColumn);
                }
            }

            return columnNames;
        }

        public static object GetDataTypedValue(String rawValue, Type valueType = null)
        {
            // If there is no value, it's null.
            if (rawValue == null || rawValue.Equals(String.Empty) || rawValue.Equals(DBNull.Value) || rawValue.Length == 0)
            {
                if (rawValue.Equals(String.Empty)) {
                    return DBNull.Value;
                }
                return String.Empty;
            }
            // Otherwise, if the value type is specified, parse the value.
            else if (valueType != null)
            {
                switch (valueType.Name)
                {
                    // String
                    case "String":
                        // If the raw value is encapsulted in quotes...
                        if (rawValue.StartsWith("'") && rawValue.EndsWith("'"))
                        {
                            // Return the value without the single quotes.
                            return rawValue.Substring(1, rawValue.Length - 2);
                        }
                        // Otherwise...
                        else
                        {
                            // Return the raw value.
                            return rawValue;
                        }

                    // Integer
                    case "Integer":
                        return int.Parse(rawValue);

                    // Decimal
                    case "Decimal":
                        return decimal.Parse(rawValue, NumberStyles.Number, CultureInfo.CurrentCulture);

                    // Boolean
                    case "Boolean":
                        return Boolean.Parse(rawValue);

                    // Byte[]
                    case "Byte[]":
                        // The length of the byte string must be even.
                        Assert.IsTrue(rawValue.Length % 2 == 0, "The length of the byte string must be even");
                        return DataTypeUtils.StringToByteArray(rawValue);

                    //// Object
                    //case "Object":
                    //    return rawValue.ToString();

                    default:
                        return rawValue;
                }
            }
            // If the value type is not set, try to derive it based on the value.
            else
            {
                // If the raw value string starts and end with a single quote, it is a string.
                if (rawValue.StartsWith("'") && rawValue.EndsWith("'"))
                {
                    // Return the value without the single quotes.
                    return rawValue.Substring(1, rawValue.Length - 2);
                }
                // If the raw value starts with 0x, it is a byte array.
                else if (rawValue.StartsWith("0x"))
                {
                    return DataTypeUtils.StringToByteArray(rawValue);
                }
                // If the raw value is an Integer.
                else if (int.TryParse(rawValue, out int intValue))
                {
                    return intValue;
                }

                else if (decimal.TryParse(rawValue, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal decimalValue))
                {
                    return decimalValue;
                }

                // If the raw value is a boolean.
                else if (Boolean.TryParse(rawValue, out bool boolValue))
                {
                    return boolValue;
                }
                // Otherwise return the raw value.
                else
                {
                    return rawValue;
                }
            }
        }
    }
}
