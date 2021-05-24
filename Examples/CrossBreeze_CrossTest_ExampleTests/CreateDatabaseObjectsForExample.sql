USE [ExampleDatabase]
GO

Create table [ExampleStagingTable] (
	[ExampleColumn] varchar(100),
	[StageDateTime] datetime2(3)
)
GO

Create function [dbo].[GetExampleStagingTable]() Returns TABLE
AS 
	Return
		Select [ExampleColumn], [StageDateTime]
		FROM [ExampleStagingTable]
GO

Create Schema [Schema With Space]
GO

Create table [ExampleStagingTableWith Space] (
	[ExampleColumnWith Space] varchar(100),
	[StageDateTime] datetime2(3)
)
GO

Create function [dbo].[GetExampleStagingTableWith Space]() Returns TABLE
AS 
	Return
		Select [ExampleColumnWith Space], [StageDateTime]
		FROM [ExampleStagingTableWith Space]
GO