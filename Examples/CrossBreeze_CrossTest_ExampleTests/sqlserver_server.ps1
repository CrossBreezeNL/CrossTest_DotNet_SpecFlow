#Ensure the container with the same name is not running and does not exist
docker stop 'crosstest_sql_latest'
docker rm 'crosstest_sql_latest'

# Start sql server in docker for running database and sql agent for tests
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test1234_' -e 'MSSQL_AGENT_ENABLED=True' -p 1433:1433 -d -v ${PWD}:/scripts --name 'crosstest_sql_latest' mcr.microsoft.com/mssql/server

# Sql Server Agent needs to start first
Start-Sleep -s 10

# Execute sql script needed to run tests on the server
docker exec crosstest_sql_latest /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P Test1234_ -i /scripts/prepare_docker_db.sql
