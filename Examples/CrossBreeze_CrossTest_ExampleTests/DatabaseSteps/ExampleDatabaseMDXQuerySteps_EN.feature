@SSAS
#language en
Feature: Example MDX Query steps

Background: 
Given the ExampleMsSsasServer database server is used
And the ClosedContracts database is used

Scenario: Running a MDX query
When I execute the following MDX query:
"""
SELECT ([Measures].[Quantity_Remaining]) On Columns
FROM [Model]
"""

Then I expect the following results:
| [Measures].[Quantity_Remaining] |
|10|

Scenario: Running an MDX query via linked server
Given the ExampleMsSqlServer database server is used
And the Tempdb database is used

When I execute the following SQL query:
"""
select *
from openquery(ClosedContracts, 'SELECT NON EMPTY { [Measures].[Quantity_Remaining] } 
	ON COLUMNS, NON EMPTY { ([DIM_Trader_Contract].[Trader_Name].[Trader_Name].ALLMEMBERS ) }
	DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM [Model] ')
"""

Then I expect the following results:
|[DIM_Trader_Contract].[Trader_Name].[Trader_Name].[MEMBER_CAPTION]|	[DIM_Trader_Contract].[Trader_Name].[Trader_Name].[MEMBER_UNIQUE_NAME]	|[Measures].[Quantity_Remaining]|
|  | [DIM_Trader_Contract].[Trader_Name].& | 10 |