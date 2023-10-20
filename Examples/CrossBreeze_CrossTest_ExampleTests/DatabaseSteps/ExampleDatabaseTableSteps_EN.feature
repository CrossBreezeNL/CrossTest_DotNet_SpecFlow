#language: en
Feature: Database table test steps (EN)

Background:
	Given the ExampleMsSqlServer database server is used
	And the ExampleDatabase database is used
	When I execute the following SQL query:
		"""
		CREATE TABLE [#testTable] (
			[Id] int,
			[Description] varchar(50),
			[StageDateTime] datetime2(2)
		)
		"""
	And I execute the following SQL query:
		"""
		CREATE TABLE [#testTableIdentity] (
			[Id] int NOT NULL IDENTITY(1,1),
			[Description] varchar(50),
			[StageDateTime] datetime2(2)
		)
		"""

Scenario: Load data into table
	Given the table [dbo].[#testTable] is loaded with the following data:
		| Id | Description |
		| 1  | 'FirstRow'  |
		| 2  | 'SecondRow' |
	When I retrieve the contents of the [dbo].[#testTable] table
	Then I expect the following results:
		| Id | Description |
		| 1  | 'FirstRow'  |
		| 2  | 'SecondRow' |

Scenario: Load data into templated table
	Given the staging-storage table [dbo].[#testTable] is loaded with the following data:
		| Id | Description |
		| 1  | 'FirstRow'  |
		| 2  | 'SecondRow' |
	When I retrieve the contents of the [dbo].[#testTable] table
	Then I expect the following results:
		| Id | Description | StageDateTime          |
		| 1  | 'FirstRow'  | 2000-01-01 00:00:00.00 |
		| 2  | 'SecondRow' | 2000-01-01 00:00:00.00 |

Scenario: Delete data from table
	Given the table [dbo].[#testTable] is empty
	When I retrieve the contents of the [dbo].[#testTable] table
	Then I expect the following results:
		| Id | Description | StageDateTime |

Scenario: Load data into a table with identity column, specify identity column
	Given the table [dbo].[#testTableIdentity] is loaded with the following data:
		| Id | Description |
		| 10 | 'FirstRow'  |
		| 20 | 'SecondRow' |
	
	When I retrieve the contents of the [dbo].[#testTableIdentity] table
	Then I expect the following results:
		| Id | Description |
		| 10 | 'FirstRow'  |
		| 20 | 'SecondRow' |

Scenario: Load data into a table with identity column, do not specify the identity column
	Given the table [dbo].[#testTableIdentity] is loaded with the following data:
		| Description |
		| 'FirstRow'  |
		| 'SecondRow' |
	When I retrieve the contents of the [dbo].[#testTableIdentity] table
	Then I expect the following results:
		| Id | Description |
		| 1  | 'FirstRow'  |
		| 2  | 'SecondRow' |
