#language en
Feature: Database query test steps (EN)

Background: 
Given the ExampleMsSqlServer database server is used
	And the ExampleDatabase database is used
	
Scenario: Executing an inline SQL query EN
Given I execute the SQL query 'Select 1 as ExampleColumn'
Then I expect the following results:
         | ExampleColumn |
         | 1             |


Scenario: Executing a non-inline SQL query EN
When I execute the following SQL query:
	"""
	Select 1 as ExampleColumn
	"""

Then I expect the following results:
         | ExampleColumn |
         | 1             |

Scenario:  Executing a SQL query from file
Given I execute the SQL query file '.\DatabaseSteps\SupportFiles\testQueryFile.sql'
Then I expect the following results:
         | ExampleColumn | 
         | 1             |	