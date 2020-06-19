Feature: Load_Customer_Integration

Background:
Given the LocalServer database server is used
And the XTest_Example_DB database is used
And the table [Source].[Customer] is empty
And the table [Staging].[Customer] is empty
And the table [Source].[SalesOrder] is empty
And the table [Staging].[SalesOrder] is empty
And the table [DWH].[Customer] is empty

Scenario: Run from source to DWH

Given the table [Source].[Customer] is loaded with the following data:
	| CustomerId | CustomerName | DateOfBirth |
	| 1          | Mr. Smith    | 1980-05-02  |
	| 2          | Ms. Jones    | 1981-03-20  |

And the table [Source].[SalesOrder] is loaded with the following data:
	| SalesOrderId | CustomerId | DateOfSale | TotalAmount |
	| 1            | 2          | 2018-10-2  | 25.00       |
	| 2            | 2          | 2018-11-3  | 10          |
	| 3            | 1          | 2019-01-01 | 120         | 

When the load_staging_customer SSIS process in the Staging project is being executed
And the load_staging_salesorder SSIS process in the Staging project is being executed
And I execute the following SQL query:
"""
Exec DWH.usp_Load_Customer 1
"""
And I retrieve the contents of the [DWH].[Customer] table
Then I expect the following results:
         | CustomerId | CustomerName | DateOfBirth | TotalSalesAmount  |
         | 1          | Mr. Smith    | 1980-05-02  | 120               |
         | 2          | Ms. Jones    | 1981-03-20  | 35                |
