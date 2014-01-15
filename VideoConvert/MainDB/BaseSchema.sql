IF NOT EXISTS (select 1 From master.dbo.sysdatabases where name=N'VOD')
BEGIN
USE master;
CREATE DATABASE VOD
ON PRIMARY
(NAME='VOD', FILENAME='C:\SQLDATA\VOD.mdf', SIZE=10MB, MAXSIZE=20, FILEGROWTH=10%)
LOG ON
(NAME='VOD_log', FILENAME='C:\SQLDATA\VOD.ldf', SIZE=10MB, MAXSIZE=200, FILEGROWTH=20%);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Asset]') AND type in (N'U'))
BEGIN
USE VOD;
CREATE TABLE [dbo].[Asset](
	[AssetId] nvarchar(256) NOT NULL,
	[AssetName] nvarchar(256) NOT NULL,
	[Description] nvarchar(256) NOT NULL,
	[ProviderId] nvarchar(256) NOT NULL
)
END
GO