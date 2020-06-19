Feature: Run a SQL agent job
	Note: This scenario is included to illustrate how to define a test for a SQL agent job. The job that is being invoked is not part of the test solution

Scenario: Run SQL agent job
	Given the LocalServer database server is used
	And the XTest_Example_DB database is used
	And the table [Source].[Customer] is empty
	And the table [Source].[Customer] is loaded with the following data:
         | CustomerId | CustomerName | DateOfBirth |
         | 1          | Mr. Smith    | 1980-05-02  |
         | 2          | Ms. Jones    | 1981-03-20  |
		   | 3          | TEST         | 1981-05-01  |

	#The SQL agent job testjob inserts a new customer record with the next id, name = TEST and date of birth = 1981-05-01
	#When The SQL agent job testjob is being executed
	When I retrieve the contents of the [Source].[Customer] table
	Then I expect the following results:
        | CustomerId | CustomerName | DateOfBirth |
        | 1          | Mr. Smith    | 1980-05-02  |
        | 2          | Ms. Jones    | 1981-03-20  |
        | 3          | TEST         | 1981-05-01  |
