#language: en
Feature: Database function test steps (EN)

Background: 
	Given the ExampleMsSqlServer database server is used
	And the ExampleDatabase database is used
	And the table [dbo].[ExampleStagingTable] is empty

Scenario: Execute function
	Given the staging-storage table [dbo].[ExampleStagingTable] is loaded with the following data:
			| ExampleColumn |
			| Some data     |
			| Some data2    |
	When I execute the [dbo].[GetExampleStagingTable] function
	Then I expect the following results:
		| ExampleColumn | StageDateTime          |
		| Some data     | 2000-01-01 00:00:00.00 |
		| Some data2    | 2000-01-01 00:00:00.00 |

Scenario: Execute templated function
	Given the staging-storage table [dbo].[ExampleStagingTable] is loaded with the following data:
			| ExampleColumn |
			| Some data     |
			| Some data2    |
	When I execute the GetExampleStagingTable dbo function
	Then I expect the following results:
		| ExampleColumn | StageDateTime          |
		| Some data     | 2000-01-01 00:00:00.00 |
		| Some data2    | 2000-01-01 00:00:00.00 |

Scenario: Execute function with parameters
	Given the staging-storage table [dbo].[ExampleStagingTable] is loaded with the following data:
			| ExampleColumn |
			| Some data2    |
	When I execute the [dbo].[GetExampleStagingTableWithParameter] function with the following parameter:
		| Parameter     | Value        |
		| ExampleColumn | 'Some data2' |
	Then I expect the following results:
		| ExampleColumn | StageDateTime          |
		| Some data2    | 2000-01-01 00:00:00.00 |

Scenario: Execute function with convetion and parameters
	Given the staging-storage table [dbo].[ExampleStagingTable] is loaded with the following data:
			| ExampleColumn |
			| Some data2    |
	When I execute the GetExampleStagingTableWithParameter dbo2 function with the following parameter:
		| Parameter     | Value        |
		| ExampleColumn | 'Some data2' |
	Then I expect the following results:
		| ExampleColumn | StageDateTime          |
		| Some data2    | 2000-01-01 00:00:00.00 |

Scenario: Execute function with parameters from template
Given the staging-storage table [dbo].[ExampleStagingTable] is loaded with the following data:
			| ExampleColumn |
			| Some data2    |
	When I execute the GetExampleStagingTableWithParameter dbo2 function
	Then I expect the following results:
		| ExampleColumn | StageDateTime          |
		| Some data2    | 2000-01-01 00:00:00.00 |