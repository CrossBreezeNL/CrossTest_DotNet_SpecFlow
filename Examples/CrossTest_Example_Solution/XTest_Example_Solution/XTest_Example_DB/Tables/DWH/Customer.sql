CREATE TABLE [DWH].[Customer]
(
	[CustomerId] INT NOT NULL PRIMARY KEY, 
    [CustomerName] VARCHAR(100) NULL, 
    [DateOfBirth] DATE NULL,
	[TotalSalesAmount] Decimal(20,2) NOT NULL,
	[BatchId] INT NOT NULL
)
