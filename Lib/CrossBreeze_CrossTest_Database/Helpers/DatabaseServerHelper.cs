using CrossBreeze.CrossTest.Database.Configuration;
using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CrossBreeze.CrossTest.Database.Helpers
{
    public static class DatabaseServerHelper
    {
        public static IDbConnection GetConnection(DatabaseServerConfig dbServerConfig, String connectionString)
        {
            // Create the connection based on the server type.
            switch (dbServerConfig.Type)
            {
                case DatabaseServerType.MsSql:
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    // If the access token is set in the db server config, set it on the SqlClient object.
                    if (dbServerConfig.AccessToken != null && dbServerConfig.AccessToken.Length > 0)
                        sqlConnection.AccessToken = dbServerConfig.AccessToken;
                    return sqlConnection;
                case DatabaseServerType.MsSsas:
                    return new AdomdConnection(connectionString);
                default:
                    throw new Exception(string.Format("The database connection type '{0}' is not supported.", Enum.GetName(typeof(DatabaseServerType), dbServerConfig.Type)));
            }
        }
    }
}
