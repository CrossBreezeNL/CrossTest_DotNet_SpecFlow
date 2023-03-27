Feature: FirstTest

Scenario: Check master version with identifier
    # Make sure the MasterMsSqlServer server is used.
    Given the MasterMsSqlServer database server is used
    # Use the master database.
    And the master database is used
    # Get the version data from the SERVERPROPERTY function
    When I execute the following SQL query:
    """
	SELECT SERVERPROPERTY ('ProductMajorVersion')  AS 'version_major'
    ,  SERVERPROPERTY ('ProductMinorVersion')   AS 'version_minor'
	"""
    # Check whether the result of the table is as expected.
    Then I expect the following results:
        | version_major | version_minor |
        | 12            | 0             |

Scenario: Check master version without identifier
    # Make sure the MasterMsSqlServer server is used.
    Given the MasterMsSqlServer database server is used
    # Use the master database.
    And the master database is used
    # Get the version data from the SERVERPROPERTY function
    When I execute the following SQL query:
    """
	SELECT SERVERPROPERTY ('ProductMajorVersion')  AS 'version_major'
    ,  SERVERPROPERTY ('ProductMinorVersion')   AS 'version_minor'
	"""
    # Check whether the result of the table is as expected.
    Then I expect the following results:
        | version_major | version_minor |
        | 12            | 0             |