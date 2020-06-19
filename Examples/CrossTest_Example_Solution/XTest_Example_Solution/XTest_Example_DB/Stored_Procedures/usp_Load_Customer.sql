CREATE PROCEDURE [DWH].[usp_Load_Customer]
	(@BatchID as int)
AS
BEGIN
	Truncate table DWH.Customer;

	INSERT INTO DWH.Customer 
		(	
			[CustomerId],
			[CustomerName], 
			[DateOfBirth],
			[TotalSalesAmount],
			[BatchId]
		)
	SELECT	[Customer].[CustomerId],
			[CustomerName], 
			[DateOfBirth],
			ISNULL(SUM([TotalAmount]),0),
			@BatchID
	FROM [Staging].[Customer]
	LEFT JOIN [Staging].[SalesOrder]
		ON [Customer].[CustomerId] = [SalesOrder].[CustomerId]
	GROUP BY [Customer].[CustomerId],
			[CustomerName], 
			[DateOfBirth]

END