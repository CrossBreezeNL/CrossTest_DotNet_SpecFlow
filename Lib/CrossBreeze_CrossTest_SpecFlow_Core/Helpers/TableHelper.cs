
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CrossBreeze.CrossTest.SpecFlow.Helpers
{
    public static class TableHelper
    {
        /// <summary>
        /// Convert a SpecFlow parameters table to a Dictionary<string, string>
        /// </summary>
        /// <param name="parameterTable">The specflow parameters table.</param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(Table parameterTable)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            // If the parameterTable is given, fill the parameters dictionary.
            if (parameterTable != null)
            {
                // Validate the table and add the entries to the dictionary.
                // Assert the parameter table columns exist.
                Assert.IsTrue(parameterTable.ContainsColumn(ConfigurationHelper.GetTestConfig().NamingConvention.TableHeader.ParameterName), string.Format("The parameter table must contain the column '{0}'", ConfigurationHelper.GetTestConfig().NamingConvention.TableHeader.ParameterName));
                Assert.IsTrue(parameterTable.ContainsColumn(ConfigurationHelper.GetTestConfig().NamingConvention.TableHeader.ParameterValue), string.Format("The parameter table must contain the column '{0}'", ConfigurationHelper.GetTestConfig().NamingConvention.TableHeader.ParameterValue));

                foreach (TableRow parameterTableRow in parameterTable.Rows)
                {
                    parameters.Add(parameterTableRow[ConfigurationHelper.GetTestConfig().NamingConvention.TableHeader.ParameterName], parameterTableRow[ConfigurationHelper.GetTestConfig().NamingConvention.TableHeader.ParameterValue]);
                }
            }

            return parameters;
        }
    }
}
