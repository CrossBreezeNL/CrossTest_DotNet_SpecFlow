CREATE DATABASE  ExampleDatabase
GO

USE ExampleDatabase

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

GO

CREATE DATABASE [TestDB]
GO

/****** Object:  Schema [Source]    Script Date: 2020-04-16 10:11:04 PM ******/
CREATE SCHEMA [Source]
GO
/****** Object:  Schema [Target]    Script Date: 2020-04-16 10:11:04 PM ******/
CREATE SCHEMA [Target]
GO
/****** Object:  Table [dbo].[CUST_CLASS_SAT]    Script Date: 2020-04-16 10:11:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUST_CLASS_SAT](
	[CUST_ID] [int] NOT NULL,
	[CUST_REGION] [varchar](100) NULL,
	[CUST_CLASS] [varchar](20) NULL,
	[CUST_RATING] [decimal](3, 1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUST_HUB]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUST_HUB](
	[CUST_ID] [int] NOT NULL,
	[CREATE_DD] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUST_SAT]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUST_SAT](
	[CUST_ID] [int] NOT NULL,
	[CUST_NAME] [varchar](100) NULL,
	[CUST_DOB] [date] NULL,
	[CUS_LANG] [char](5) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DIM_Product]    Script Date: 2020-04-16 10:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIM_Product](
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

USE [msdb]
GO

declare @Owner_LoginName as nvarchar(100)
set @Owner_LoginName = SYSTEM_USER


/****** Object:  Job [testjob]    Script Date: 2020-01-10 4:06:36 PM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 2020-01-10 4:06:36 PM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'testjob', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'No description available.', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name= @Owner_LoginName, @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [insert customer data]    Script Date: 2020-01-10 4:06:36 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'insert customer data', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'SELECT * FROM dbo.ExampleStagingTable', 
		@database_name=N'ExampleDatabase', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:
GO


