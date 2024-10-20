#Ensure the container with the same name is not running and does not exist
docker stop 'crosstest_specflow_sqlserver'
docker rm 'crosstest_specflow_sqlserver'

# Start sql server in docker for running database and sql agent for tests
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test1234' -e 'MSSQL_AGENT_ENABLED=True' -p 1433:1433 -d -v ${PWD}:/scripts --name 'crosstest_specflow_sqlserver' -h 'crosstest_specflow_sqlserver' mcr.microsoft.com/mssql/server:2019-latest

# Sql Server Agent needs to start first
Start-Sleep -s 10

# Execute sql script needed to run tests on the server
docker exec -w /scripts crosstest_specflow_sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P Test1234 -C -i prepare_sql_docker.sql
