USE ExampleDatabase
GO

Create table ExampleStagingTable (
	ExampleColumn varchar(100),
	StageDateTime datetime2(3)
)
GO

Create function dbo.GetExampleStagingTable() Returns TABLE
AS 
	Return
		Select ExampleColumn, StageDateTime
		FROM ExampleStagingTable