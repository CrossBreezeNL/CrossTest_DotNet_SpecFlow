Feature: Run a SQL agent job
	#Note: This scenario is included to illustrate how to define a test for a SQL agent job. The job that is being invoked is not part of the test solution

Scenario: Run SQL agent job
	Given the ExampleMsSqlServer database server is used
	And the ExampleDatabase database is used
	When The SQL agent job testjob is being executed
