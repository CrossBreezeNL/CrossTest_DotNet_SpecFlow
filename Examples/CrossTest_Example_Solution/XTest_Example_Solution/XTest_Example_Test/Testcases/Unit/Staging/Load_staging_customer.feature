Feature: Load_staging_customer
#Load the customer staging table 

Background: 
#For each scnenario, set database and server and clear the source and destination tables

Given the LocalServer database server is used
And the XTest_Example_DB database is used
And the table [Source].[Customer] is empty
And the table [Staging].[Customer] is empty

Scenario: Load the customer table
#Check for functional attributes
Given the table [Source].[Customer] is loaded with the following data:
	| CustomerId | CustomerName | DateOfBirth |
	| 1          | Mr. Smith    | 1980-05-02  |
	| 2          | Ms. Jones    | 1981-03-20  |

When the load_staging_customer SSIS process in the Staging project is being executed
And I retrieve the contents of the [Staging].[Customer] table
Then I expect the following results:
	| CustomerId | CustomerName | DateOfBirth |
	| 1          | Mr. Smith    | 1980-05-02  |
	| 2          | Ms. Jones    | 1981-03-20  |


Scenario: Load the customer table with default stage datetime from config
#Check that the SSIS package variable for stage datetime is used when inserting stage data

Given the table [Source].[Customer] is loaded with the following data:
	| CustomerId | CustomerName | DateOfBirth |
	| 1          | Mr. Smith    | 1980-05-02  |
	| 2          | Ms. Jones    | 1981-03-20  |

When the load_staging_customer staging_load SSIS process in the Staging project is being executed 
And I retrieve the contents of the [Staging].[Customer] table
Then I expect the following results:
	| CustomerId | CustomerName | DateOfBirth | StageDateTime |
	| 1          | Mr. Smith    | 1980-05-02  | 2000-01-01    |
	| 2          | Ms. Jones    | 1981-03-20  | 2000-01-01    | 