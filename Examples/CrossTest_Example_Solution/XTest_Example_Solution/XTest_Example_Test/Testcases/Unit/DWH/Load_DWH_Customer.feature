Feature: Load_DWH_Customer

Background: 
#For each scnenario, set database and server and clear the source and destination tables

Given the LocalServer database server is used
And the XTest_Example_DB database is used
And the table [Staging].[Customer] is empty
And the table [Staging].[SalesOrder] is empty
And the table [DWH].[Customer] is empty

Scenario Outline: Loading DWH Customer <Scenario>
# Using a scenario outline to include multiple examples into one scenario definition

Given the staging table [Staging].[Customer] is loaded with the following data:
	| CustomerId | CustomerName | DateOfBirth |
	| 1          | Mr. Smith    | 1980-05-02  |
	| 2          | Ms. Jones    | 1981-03-20  |

And the staging table [Staging].[SalesOrder] is loaded with the following data:
	| SalesOrderId | CustomerId | DateOfSale | TotalAmount |
	| 1            | 2          | 2018-10-2  | 25.00       |
	| 2            | 2          | 2018-11-3  | <Scenario_value>       |
	| 3            | 1          | 2019-01-01 | 120         |

When I execute the following SQL query:
"""
Exec DWH.usp_Load_Customer 1
"""
And I retrieve the contents of the [DWH].[Customer] table
Then I expect the following results:
         | CustomerId | CustomerName | DateOfBirth | TotalSalesAmount  |
         | 1          | Mr. Smith    | 1980-05-02  | 120               |
         | 2          | Ms. Jones    | 1981-03-20  | <Scenario_output> |
Examples: 
	| Scenario | Scenario_value | Scenario_output |
	| Regular  | 25.00          | 50              |
	| Empty    |                | 25              |
	| Negative | -10            | 15              | 