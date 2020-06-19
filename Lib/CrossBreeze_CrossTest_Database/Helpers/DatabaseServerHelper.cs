using CrossBreeze.CrossTest.Database.Configuration;
using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CrossBreeze.CrossTest.Database.Helpers
{
    public static class DatabaseServerHelper
    {
        public static IDbConnection GetConnection(DatabaseServerType serverType, String connectionString)
        {
            // Create the connection based on the server type.
            switch (serverType)
            {
                case DatabaseServerType.MsSql:
                    return new SqlConnection(connectionString);
                case DatabaseServerType.MsSsas:
                    return new AdomdConnection(connectionString);
                default:
                    throw new Exception(string.Format("The database connection type '{0}' is not supported.", Enum.GetName(typeof(DatabaseServerType), serverType)));
            }
        }
    }
}
