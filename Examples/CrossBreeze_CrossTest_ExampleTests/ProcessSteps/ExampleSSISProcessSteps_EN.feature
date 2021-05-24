#language: en
@SSIS
Feature: Run Example SSIS proces (EN)

Background:
	Given the ExampleMsSqlServer database server is used
	And the Tempdb database is used
	When I execute the following SQL query:
        """
        IF (object_ID('testTable') IS NOT NULL)
		BEGIN
			DROP TABLE testTable
		END

		CREATE TABLE testTable (id INT, description VARCHAR(50))
         """

Scenario: Run SSIS proces
	When the ExamplePackage SSIS process in the ExampleSsisISPacProject project is being executed
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Run typed SSIS proces
	When the ExamplePackage dwh SSIS process in the ExampleSsisISPacProject project is being executed
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Run SSIS proces with parameters
	When the ExamplePackage SSIS process in the ExampleSsisISPacProject project is being executed with the following parameter:
		| Parameter        | Value              |
		| ExampleParameter | SomeParameterValue |
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Run typed SSIS proces with parameters
	When the ExamplePackage dwh SSIS process in the ExampleSsisISPacProject project is being executed with the following parameter:
		| Parameter        | Value              |
		| ExampleParameter | SomeParameterValue |
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Run SSIS proces as role
	When the developer executes the ExamplePackage SSIS process in the ExampleSsisISPacProject project
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Run typed SSIS proces as role
	When the developer executes the ExamplePackage dwh SSIS process in the ExampleSsisISPacProject project
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Run SSIS proces with parameters as role
	When the developer executes the ExamplePackage SSIS process in the ExampleSsisISPacProject project with the following parameter:
		| Parameter        | Value              |
		| ExampleParameter | SomeParameterValue |
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Run typed SSIS proces with parameters as role
	When the developer executes the ExamplePackage dwh SSIS process in the ExampleSsisISPacProject project with the following parameter:
		| Parameter        | Value              |
		| ExampleParameter | SomeParameterValue |
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |