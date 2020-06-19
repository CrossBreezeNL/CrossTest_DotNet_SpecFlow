Feature: FirstTest

Scenario: Check msdb version with identifier
    # Make sure the ExampleMsSqlServer server is used.
    Given the ExampleMsSqlServer database server is used
    # Use the msdb database.
    And the msdb database is used
    # Get the data from the dbo.msdb_version table
    When I retrieve the contents of the [dbo].[msdb_version] table
    # Check whether the result of the table is as expected.
    Then I expect the following results:
        | version_major | version_minor |
        | 15            | 0             |

Scenario: Check msdb version without identifier
    # Make sure the ExampleMsSqlServer server is used.
    Given the ExampleMsSqlServer database server is used
    # Use the msdb database.
    And the msdb database is used
    # Get the data from the dbo.msdb_version table
    When I retrieve the contents of the dbo.msdb_version table
    # Check whether the result of the table is as expected.
    Then I expect the following results:
        | version_major | version_minor |
        | 15            | 0             |