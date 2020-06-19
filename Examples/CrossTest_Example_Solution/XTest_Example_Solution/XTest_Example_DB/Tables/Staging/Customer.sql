CREATE TABLE [Staging].[Customer]
(
	[CustomerId] INT NOT NULL PRIMARY KEY, 
    [CustomerName] VARCHAR(100) NULL, 
    [DateOfBirth] DATE NULL,
	[StageDateTime] DateTime2(3) NOT NULL
)
