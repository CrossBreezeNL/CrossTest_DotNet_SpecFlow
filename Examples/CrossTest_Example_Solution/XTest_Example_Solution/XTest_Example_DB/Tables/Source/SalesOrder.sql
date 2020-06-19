CREATE TABLE [Source].[SalesOrder]
(
	[SalesOrderId] INT NOT NULL PRIMARY KEY, 
	[CustomerId] INT NOT NULL,
    [DateOfSale] DATE NULL, 
    [TotalAmount] DECIMAL(15, 2) NULL
)
