#language: en
Feature: Database table test steps in a transaction

Background:
	Given the ExampleMsSqlServer database server is used
	And the ExampleDatabase database is used
	When I execute the following SQL query:
		"""
		IF OBJECT_ID('dbo.xt_transaction_test') IS NULL
		BEGIN
		CREATE TABLE dbo.[xt_transaction_test] (
			[Id] int,
			[Description] varchar(50)
		)
		END
		"""

Scenario: Simple insert 
	When the test is being executed within a transaction
	Given the table [xt_transaction_test] is loaded with the following data:
	| Id | Description  |
	| 1  | Test         |
	| 2  | Another test |

	When I retrieve the contents of the [dbo].[xt_transaction_test] table
	Then I expect the following results:
	| Id | Description  |
	| 1  | Test         |
	| 2  | Another test |

Scenario: Another Simple insert 
	When the test is being executed within a transaction
	Given the table [xt_transaction_test] is loaded with the following data:
	| Id | Description  |
	| 3  | Test         |
	| 4  | Another test |

	When I retrieve the contents of the [dbo].[xt_transaction_test] table
	Then I expect the following results:
	| Id | Description  |
	| 3  | Test         |
	| 4  | Another test |