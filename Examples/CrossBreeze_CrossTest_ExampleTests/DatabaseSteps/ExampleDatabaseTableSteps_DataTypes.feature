#language: en
Feature: Database table test steps data type support

Background:
	Given the ExampleMsSqlServer database server is used
	And the ExampleDatabase database is used

Scenario Outline: Load data into datatype <Scenario> column
	When I execute the following SQL query:
		"""
		CREATE TABLE [#dataTypeTestTable] (
			[TestColumn] <SqlDataType>
		)
		"""
	Given the table [dbo].[#dataTypeTestTable] is loaded with the following data:
		| TestColumn     |
		| <ExampleValue> |
	When I retrieve the contents of the [dbo].[#dataTypeTestTable] table
	Then I expect the following results:
		| TestColumn     |
		| <ExampleValue> |
	Examples: 
		| Scenario                      | SqlDataType    | ExampleValue                       |
		| bit                           | bit            | 1                                  |
		| tinyint                       | tinyint        | 255                                |
		| smallint                      | smallint       | 32767                              |
		| integer                       | int            | 2147483647                         |
		| bigint                        | bigint         | 9223372036854775807                |
		| decimal                       | decimal(11,2)  | 123456789.12                       |
		| numeric                       | numeric(11,2)  | 123456789.12                       |
		| smallmoney                    | smallmoney     | 214748.3647                        |
		| money                         | money          | 922337203685477.5807               |
		| float                         | float          | 123456789.12                       |
		| real                          | real           | 123456789.12                       |
		| date-lowest                   | date           | 0001-01-01                         |
		| date-highest                  | date           | 9999-12-31                         |
		| time-lowest                   | time           | 00:00:00                           |
		| time-highest                  | time           | 23:59:59                           |
		| smalldatetime-lowest          | smalldatetime  | 1900-01-01 00:00                   |
		| smalldatetime-highest         | smalldatetime  | 2079-06-06 23:59                   |
		| datetime-without-millis       | datetime       | 1753-01-01 00:00:00                |
		| datetime-lowest               | datetime       | 1753-01-01 00:00:00.000            |
		| datetime-highest              | datetime       | 9999-12-31 23:59:59.997            |
		| datetime2-without-millis      | datetime2      | 0001-01-01 00:00:00                |
		| datetime2-lowest              | datetime2      | 0001-01-01 00:00:00.0000000        |
		| datetime2-highest             | datetime2      | 9999-12-31 23:59:59.9999999        |
		| datetimeoffset-without-millis | datetimeoffset | 0001-01-01 00:00:00 +00:00         |
		| datetimeoffset-without-offset | datetimeoffset | 0001-01-02 00:00:00.0000000        |
		| datetimeoffset-lowest         | datetimeoffset | 0001-01-01 00:00:00.0000000 +00:00 |
		| datetimeoffset-highest        | datetimeoffset | 9999-12-31 23:59:59.9999999 +00:00 |
		| char                          | char(1)        | Y                                  |
		| text                          | text           | Hoppa                              |
		| varchar                       | varchar(10)    | Hoppa                              |
		| nchar                         | nchar(1)       | Y                                  |
		| ntext                         | ntext          | Hoppa                              |
		| nvarchar                      | nvarchar(10)   | Hoppa                              |
