CREATE DATABASE  ExampleDatabase
GO

USE [ExampleDatabase]
GO

ALTER DATABASE ExampleDatabase
SET ALLOW_SNAPSHOT_ISOLATION ON
GO

-- Create all database objects for testing in the current database.
:r prepare_sql_database.sql

-- Create all SQL Agent objects for testing.
-- SQL Agent is not running in docker container.
--:r prepare_sql_agent.sql
