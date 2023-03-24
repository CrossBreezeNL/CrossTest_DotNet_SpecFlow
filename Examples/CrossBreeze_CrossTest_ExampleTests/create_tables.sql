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

Create or alter function [dbo].[GetExampleStagingTableWithParameter](@ExampleColumn varchar(100)= 'Some data') Returns TABLE
AS 
	Return
		Select [ExampleColumn], [StageDateTime]
		FROM [ExampleStagingTable]
		Where [ExampleColumn]=@ExampleColumn
GO

Create Schema [Schema With Space]
GO

Create table [Schema With Space].[ExampleStagingTableWith Space] (
	[ExampleColumnWith Space] varchar(100),
	[StageDateTime] datetime2(3)
)
GO

Create function [dbo].[GetExampleStagingTableWith Space]() Returns TABLE
AS 
	Return
		Select [ExampleColumnWith Space], [StageDateTime]
		FROM [Schema With Space].[ExampleStagingTableWith Space]
GO

CREATE Schema [TestDB]
GO

/****** Object:  Schema [Source]    Script Date: 2020-04-16 10:11:04 PM ******/
CREATE SCHEMA [Source]
GO
/****** Object:  Schema [Target]    Script Date: 2020-04-16 10:11:04 PM ******/
CREATE SCHEMA [Target]
GO
/****** Object:  Table [TestDB].[CUST_CLASS_SAT]    Script Date: 2020-04-16 10:11:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TestDB].[CUST_CLASS_SAT](
	[CUST_ID] [int] NOT NULL,
	[CUST_REGION] [varchar](100) NULL,
	[CUST_CLASS] [varchar](20) NULL,
	[CUST_RATING] [decimal](3, 1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [TestDB].[CUST_HUB]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TestDB].[CUST_HUB](
	[CUST_ID] [int] NOT NULL,
	[CREATE_DD] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [TestDB].[CUST_SAT]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TestDB].[CUST_SAT](
	[CUST_ID] [int] NOT NULL,
	[CUST_NAME] [varchar](100) NULL,
	[CUST_DOB] [date] NULL,
	[CUS_LANG] [char](5) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [TestDB].[DIM_Product]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TestDB].[DIM_Product](
	[ProductID] [int] NOT NULL,
	[ProductGroup] [varchar](10) NULL,
	[ProductCategory] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Source].[AB_RH_INS_POLCY]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Source].[AB_RH_INS_POLCY](
	[INS_POLCY_SQN] [int] NULL,
	[INS_POLCY_BK] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Source].[CUST_CLASS_SAT]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Source].[CUST_CLASS_SAT](
	[CUST_ID] [int] NOT NULL,
	[CUST_REGION] [varchar](100) NULL,
	[CUST_CLASS] [varchar](20) NULL,
	[CUST_RATING] [decimal](3, 1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Source].[CUST_HUB]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Source].[CUST_HUB](
	[CUST_ID] [int] NOT NULL,
	[CREATE_DD] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Source].[CUST_SAT]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Source].[CUST_SAT](
	[CUST_ID] [int] NOT NULL,
	[CUST_NAME] [varchar](100) NULL,
	[CUST_DOB] [date] NULL,
	[CUS_LANG] [char](5) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Source].[Customer]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Source].[Customer](
	[Customer_ID] [int] NOT NULL,
	[Customer_Name] [varchar](100) NULL,
	[Country] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Target].[Customer]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Target].[Customer](
	[Customer_ID] [int] NOT NULL,
	[Customer_Name] [varchar](100) NULL,
	[Country] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
