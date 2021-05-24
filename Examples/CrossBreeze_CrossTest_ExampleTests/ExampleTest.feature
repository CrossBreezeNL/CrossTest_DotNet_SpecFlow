Feature: ExampleTest
	This is an example test to show how to populate a (typed) table, execute a function and test its output.

Background:
	Given the ExampleMsSqlServer database server is used
	And the ExampleDatabase database is used
	And the test has been executed within a transaction

Scenario: Fill a typed table and test function
	Given the staging-storage table [dbo].[ExampleStagingTable] is loaded with the following data:
		| ExampleColumn |
		| Some data     |
	When I execute the [dbo].[GetExampleStagingTable] function
	Then I expect the following results:
		| ExampleColumn | StageDateTime          |
		| Some data     | 2000-01-01 00:00:00.00 |

Scenario: Spaces in SQL schema, table, function and column names are working properly
	Given the staging-storage table [Schema With Space].[ExampleStagingTableWith Space] is loaded with the following data:
		| ExampleColumnWith Space|
		| Some data     |
	When I retrieve the contents of the [Schema With Space].[ExampleStagingTableWith Space] table
	Then I expect the following results:
		| ExampleColumnWith Space |
		| Some data     |