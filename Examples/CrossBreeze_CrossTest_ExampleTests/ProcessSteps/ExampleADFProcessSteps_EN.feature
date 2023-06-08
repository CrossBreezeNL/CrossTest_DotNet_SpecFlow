#language: en
@ADF
Feature: Run Example ADF proces (EN)

Background:
	Given the ExampleMsSqlServer database server is used
	And the ExampleDatabase database is used
	When I execute the following SQL query:
        """
        IF (object_ID('testTable') IS NOT NULL)
		BEGIN
			DROP TABLE testTable
		END

		CREATE TABLE testTable (id INT, description VARCHAR(50))
		
		insert into  [dbo].[testTable] values (1, 'FirstRow')
        """

Scenario: Run ADF proces
	When the CrossTestPipeline ADF process in the ExampleAdfPipeline project is being executed
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |


Scenario: Run typed ADF proces
	When the CrossTestPipelineWithParameters adfTemplate ADF process in the ExampleAdfPipeline project is being executed
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Run ADF proces with parameters
	When the CrossTestPipelineWithParameters ADF process in the ExampleAdfPipeline project is being executed with the following parameter:
		| Parameter     | Value						|
		| baseUrl		| https://x-test.nl/		|
		| uri			| DotNet					|
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |

Scenario: Run typed ADF proces with parameters
	When the CrossTestPipelineWithParameters adfTemplate ADF process in the ExampleAdfPipeline project is being executed with the following parameter:
		| Parameter     | Value		|
		| uri			| Java		|
	And I retrieve the contents of the [dbo].[testTable] table
	Then I expect the following results:
        | id | description |
		| 1  | 'FirstRow'  |