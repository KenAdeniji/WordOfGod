CREATE DATABASE [WordEngineering]  ON (NAME = N'WordEngineering_Data', FILENAME = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Data.MDF' , SIZE = 42, FILEGROWTH = 10%) LOG ON (NAME = N'WordEngineering_Log', FILENAME = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Log.LDF' , SIZE = 176, FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER DATABASE [WordEngineering] ADD FILEGROUP [INDEX] 
GO
ALTER DATABASE [WordEngineering] ADD FILE(NAME = N'WordEngineering_Index', FILENAME = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Index_Data.NDF' , SIZE = 4, FILEGROWTH = 10%) TO FILEGROUP [INDEX]
GO
ALTER DATABASE [WordEngineering] ADD FILEGROUP [TEXT] 
GO
ALTER DATABASE [WordEngineering] ADD FILE(NAME = N'WordEngineering_Text', FILENAME = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Text_Data.NDF' , SIZE = 6, FILEGROWTH = 10%) TO FILEGROUP [TEXT]
GO
ALTER DATABASE [WordEngineering] ADD FILEGROUP [IMAGE] 
GO
ALTER DATABASE [WordEngineering] ADD FILE(NAME = N'WordEngineering_Image', FILENAME = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Image_Data.NDF' , SIZE = 1, FILEGROWTH = 10%) TO FILEGROUP [IMAGE]
GO
ALTER DATABASE [WordEngineering] ADD FILEGROUP [XML] 
GO
ALTER DATABASE [WordEngineering] ADD FILE(NAME = N'WordEngineering_Xml', FILENAME = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Xml_Data.NDF' , SIZE = 1, FILEGROWTH = 10%) TO FILEGROUP [XML]
GO

exec sp_dboption N'WordEngineering', N'autoclose', N'false'
GO

exec sp_dboption N'WordEngineering', N'bulkcopy', N'false'
GO

exec sp_dboption N'WordEngineering', N'trunc. log', N'false'
GO

exec sp_dboption N'WordEngineering', N'torn page detection', N'true'
GO

exec sp_dboption N'WordEngineering', N'read only', N'false'
GO

exec sp_dboption N'WordEngineering', N'dbo use', N'false'
GO

exec sp_dboption N'WordEngineering', N'single', N'false'
GO

exec sp_dboption N'WordEngineering', N'autoshrink', N'false'
GO

exec sp_dboption N'WordEngineering', N'ANSI null default', N'false'
GO

exec sp_dboption N'WordEngineering', N'recursive triggers', N'false'
GO

exec sp_dboption N'WordEngineering', N'ANSI nulls', N'false'
GO

exec sp_dboption N'WordEngineering', N'concat null yields null', N'false'
GO

exec sp_dboption N'WordEngineering', N'cursor close on commit', N'false'
GO

exec sp_dboption N'WordEngineering', N'default to local cursor', N'false'
GO

exec sp_dboption N'WordEngineering', N'quoted identifier', N'false'
GO

exec sp_dboption N'WordEngineering', N'ANSI warnings', N'false'
GO

exec sp_dboption N'WordEngineering', N'auto create statistics', N'true'
GO

exec sp_dboption N'WordEngineering', N'auto update statistics', N'true'
GO

if( (@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 724) )
	exec sp_dboption N'WordEngineering', N'db chaining', N'false'
GO

use [WordEngineering]
GO

if not exists (select * from master.dbo.syslogins where loginname = N'HOLYSPIRIT\Administrator')
	exec sp_grantlogin N'HOLYSPIRIT\Administrator'
	exec sp_defaultdb N'HOLYSPIRIT\Administrator', N'master'
	exec sp_defaultlanguage N'HOLYSPIRIT\Administrator', N'us_english'
GO

if not exists (select * from master.dbo.syslogins where loginname = N'HOLYSPIRIT\ASPNET')
	exec sp_grantlogin N'HOLYSPIRIT\ASPNET'
	exec sp_defaultdb N'HOLYSPIRIT\ASPNET', N'CommunityStarterKit'
	exec sp_defaultlanguage N'HOLYSPIRIT\ASPNET', N'us_english'
GO

if not exists (select * from master.dbo.syslogins where loginname = N'WordEngineering')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'master', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'WordEngineering', null, @logindb, @loginlang
END
GO

exec sp_addsrvrolemember N'HOLYSPIRIT\Administrator', sysadmin
GO

exec sp_addsrvrolemember N'HOLYSPIRIT\ASPNET', sysadmin
GO

exec sp_addsrvrolemember N'WordEngineering', sysadmin
GO

exec sp_addsrvrolemember N'HOLYSPIRIT\ASPNET', securityadmin
GO

exec sp_addsrvrolemember N'HOLYSPIRIT\ASPNET', serveradmin
GO

exec sp_addsrvrolemember N'HOLYSPIRIT\ASPNET', setupadmin
GO

exec sp_addsrvrolemember N'HOLYSPIRIT\ASPNET', processadmin
GO

exec sp_addsrvrolemember N'HOLYSPIRIT\ASPNET', diskadmin
GO

exec sp_addsrvrolemember N'HOLYSPIRIT\ASPNET', dbcreator
GO

exec sp_addsrvrolemember N'HOLYSPIRIT\ASPNET', bulkadmin
GO

if not exists (select * from dbo.sysusers where name = N'WordEngineering' and uid < 16382)
	EXEC sp_grantdbaccess N'WordEngineering', N'WordEngineering'
GO

CREATE TABLE [dbo].[ActorRelationship] (
	[UniqueId] [uniqueidentifier] NOT NULL ,
	[Dated] [datetime] NOT NULL ,
	[ActorNameFirst] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ActorNameSecond] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ActorRelationshipFirst] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ActorRelationshipSecond] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ScriptrureReference] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Commentary] [varchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AlphabetSequence] (
	[Dated] [datetime] NOT NULL ,
	[Word] [varchar] (600) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[AlphabetSequence] [int] NOT NULL ,
	[ScriptureReferenceVerseForward] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ScriptureReferenceChapterForward] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ScriptureReferenceChapterBackward] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ScriptureReferenceVerseBackward] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Behavior] (
	[Dated] [datetime] NOT NULL ,
	[Keyword] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SequenceOrder] [int] NOT NULL ,
	[ScriptureReference] [varchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Actor] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Commentary] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[URI] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Calendar] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CalendarYear] [int] NULL ,
	[CalendarMonth] [int] NULL ,
	[CalendarDay] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CalendarEstadosUnidos] (
	[Dated] [datetime] NOT NULL ,
	[ScriptureReference] [varchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Commentary] [varchar] (1024) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Country] (
	[dated] [datetime] NULL ,
	[countryName] [char] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[fullCountryName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[area] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[population] [int] NOT NULL ,
	[capitalCity] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[capitalCityPopulation] [int] NOT NULL ,
	[people] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[language] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[religion] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[government] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[president] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[currency] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[majorIndustries] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Cry] (
	[Dated] [datetime] NOT NULL ,
	[Commentary] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PoliceId] [uniqueidentifier] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Error] (
	[Dated] [datetime] NOT NULL ,
	[Commentary] [varchar] (1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Forum] (
	[Dated] [datetime] NOT NULL ,
	[thread] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[keyword] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[post] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[reply] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[uri] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GodTitle] (
	[Id] [uniqueidentifier] NOT NULL ,
	[Title] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Comment] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[OrderSequence] [int] NULL ,
	[Dated] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Noise] (
	[Dated] [datetime] NOT NULL ,
	[Commentary] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PoliceId] [uniqueidentifier] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Police] (
	[PoliceId] [uniqueidentifier] NOT NULL ,
	[PoliceReportId] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Dated] [datetime] NOT NULL ,
	[DateFrom] [datetime] NOT NULL ,
	[DateTo] [datetime] NOT NULL ,
	[Address] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PoliceName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PoliceNo] [int] NOT NULL ,
	[PoliceRank] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Commentary] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Role] (
	[Dated] [datetime] NOT NULL ,
	[Role] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SequenceOrder] [int] NOT NULL ,
	[ScriptureReference] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ScriptureRegion] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Actor] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Commentary] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[scriptureReferenceFirst] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[scriptureReferenceLast] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[genealogy] [varchar] (8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[genealogyParent] [int] NULL ,
	[genealogyOffspring] [int] NULL ,
	[AgeCommence] [int] NULL ,
	[AgeComplete] [int] NULL ,
	[Longevity] [int] NULL ,
	[BiblicalCalendarCategory] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[BiblicalCalendarTimeSpan] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Software] (
	[Dated] [datetime] NOT NULL ,
	[Commentary] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ScriptureReference] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[WeightMeasure] (
	[BiblicalUnit] [char] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[MeasureUnit] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[MetricUnit] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[AmericanUnit] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[WordEngineeringPlace] (
	[dated] [datetime] NOT NULL ,
	[place] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[sequenceIndex] [int] NOT NULL ,
	[scriptureReference] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[scriptureReferenceFirstMention] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[commentary] [varchar] (4000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[keyword] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AlphabetSequence] WITH NOCHECK ADD 
	CONSTRAINT [PK_AlphabetSequence] PRIMARY KEY  CLUSTERED 
	(
		[Word]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Behavior] WITH NOCHECK ADD 
	CONSTRAINT [PK_Behavior] PRIMARY KEY  CLUSTERED 
	(
		[Keyword],
		[SequenceOrder]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CalendarEstadosUnidos] WITH NOCHECK ADD 
	CONSTRAINT [PK_CalendarEstadosUnidos] PRIMARY KEY  CLUSTERED 
	(
		[Dated]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Forum] WITH NOCHECK ADD 
	CONSTRAINT [PK_Forum] PRIMARY KEY  CLUSTERED 
	(
		[uri]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[WordEngineeringPlace] WITH NOCHECK ADD 
	CONSTRAINT [PK_WordEngineeringPlace] PRIMARY KEY  CLUSTERED 
	(
		[place]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[AlphabetSequence] ADD 
	CONSTRAINT [DF_AlphabetSequence_Dated] DEFAULT (getdate()) FOR [Dated]
GO

ALTER TABLE [dbo].[Behavior] ADD 
	CONSTRAINT [DF_Behavior_Dated] DEFAULT (getdate()) FOR [Dated]
GO

ALTER TABLE [dbo].[CalendarEstadosUnidos] ADD 
	CONSTRAINT [DF_CalendarEstadosUnidos_Dated] DEFAULT (getdate()) FOR [Dated]
GO

ALTER TABLE [dbo].[Cry] ADD 
	CONSTRAINT [DF_Cry_Dated] DEFAULT (getdate()) FOR [Dated],
	CONSTRAINT [PK_Cry] PRIMARY KEY  NONCLUSTERED 
	(
		[Dated]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Error] ADD 
	CONSTRAINT [DF_Error_Dated] DEFAULT (getdate()) FOR [Dated],
	CONSTRAINT [PK_Error] PRIMARY KEY  NONCLUSTERED 
	(
		[Dated]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Forum] ADD 
	CONSTRAINT [DF_Forum_Dated] DEFAULT (getdate()) FOR [Dated]
GO

ALTER TABLE [dbo].[Noise] ADD 
	CONSTRAINT [DF_Noise_Dated] DEFAULT (getdate()) FOR [Dated],
	CONSTRAINT [PK_Noise] PRIMARY KEY  NONCLUSTERED 
	(
		[Dated]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Police] ADD 
	CONSTRAINT [DF_Police_EventId] DEFAULT (newid()) FOR [PoliceId],
	CONSTRAINT [DF_Police_Dated] DEFAULT (getdate()) FOR [Dated],
	CONSTRAINT [DF_Police_DateFrom] DEFAULT (getdate()) FOR [DateFrom],
	CONSTRAINT [DF_Police_DateTo] DEFAULT (getdate()) FOR [DateTo],
	CONSTRAINT [PK_Police] PRIMARY KEY  NONCLUSTERED 
	(
		[PoliceId]
	) WITH  FILLFACTOR = 90  ON [INDEX] 
GO

ALTER TABLE [dbo].[Software] ADD 
	CONSTRAINT [DF_Software_Dated] DEFAULT (getdate()) FOR [Dated],
	CONSTRAINT [PK_Software] PRIMARY KEY  NONCLUSTERED 
	(
		[Dated]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[WordEngineeringPlace] ADD 
	CONSTRAINT [DF_WordEngineeringPlace2_Dated] DEFAULT (getdate()) FOR [dated]
GO

 CREATE  INDEX [IX_WordEngineeringPlace_ScriptureReferenceFirstMention] ON [dbo].[WordEngineeringPlace]([scriptureReferenceFirstMention]) WITH  FILLFACTOR = 90 ON [INDEX]
GO

 CREATE  INDEX [IX_WordEngineeringPlace_SequenceIndex] ON [dbo].[WordEngineeringPlace]([sequenceIndex]) WITH  FILLFACTOR = 90 ON [INDEX]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE [dbo].[BibleDictionaryCount] AS

Select Count(*) As BibleDatabaseBiblicalNameCount   From BibleDatabaseBiblicalName  ( NoLock )
Select Count(*) As BibleDatabaseEastonCount         From BibleDatabaseEaston        ( NoLock )
Select Count(*) As BibleFoundationEastonCount       From BibleFoundationEaston      ( NoLock )
Select Count(*) As BibleFoundationJamesStrongCount  From BibleFoundationJamesStrong ( NoLock )
Select Count(*) As BibleFoundationCount             From BibleFoundationNave        ( NoLock )
Select Count(*) As BibleFoundationTorrey            From BibleFoundationTorrey      ( NoLock )

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE BibleFoundationPopulateEaston
 @dictionaryId        int           = null,
 @dictionaryWord      varchar(50)   = null,
 @commentary          varchar(8000) = null
AS
BEGIN

 /*
 CREATE TABLE [dbo].[BibleFoundationEaston] 
 (
	[DictionaryId] [int] NOT NULL ,
	[DictionaryWord] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Commentary] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
 ) ON [PRIMARY] TEXTIMAGE_ON [TEXT]

 ALTER TABLE [dbo].[BibleFoundationEaston] WITH NOCHECK ADD 
	CONSTRAINT [PK_BibleFoundationEaston] PRIMARY KEY  CLUSTERED 
	(
		[DictionaryId]
	)  ON [PRIMARY] 

 ALTER TABLE [dbo].[BibleFoundationEaston] WITH NOCHECK ADD 
	CONSTRAINT [IX_BibleFoundationEaston_DictionaryWord] UNIQUE  NONCLUSTERED 
	(
		[DictionaryWord]
	)  ON [INDEX] 
 */
 /* 
  When SET NOCOUNT is ON, the count (indicating the number of rows 
  affected by a Transact-SQL statement) is not returned. When SET 
  NOCOUNT is OFF, the count is returned.
 */
 SET NOCOUNT ON

 SELECT TOP 1
  dictionaryId
 FROM
  BibleFoundationEaston
 WHERE
  DictionaryId = @dictionaryId
 
 --If Found then update the record, else insert the record
 IF @@ROWCOUNT > 0
 BEGIN
  UPDATE
  BibleFoundationEaston
   SET
     DictionaryWord = @dictionaryWord,
     Commentary     = @commentary
   WHERE
     DictionaryId   = @dictionaryId
 END --End Insert
 ELSE
 BEGIN
  INSERT
  BibleFoundationEaston
   (
     DictionaryId,
     DictionaryWord,
     Commentary
   )
   VALUES
   (
     @DictionaryId,
     @DictionaryWord,
     @Commentary
   )
 END --End Insert
 --RETURN @@ROWCOUNT
END  --End Procedure


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE BibleFoundationPopulateJamesStrong
 @languageGreekHebrew char(1)       = null,
 @jamesStrongNumber   int           = null,
 @originalWord        varchar(255)  = null,
 @pronounce           varchar(255)  = null,
 @commentary          varchar(8000) = null
AS
BEGIN

 /*
  Select
   languageGreekHebrew,
   Count( languageGreekHebrew ) As countLanguageGreekHebrew,
   Max( JamesStrongNumber )     As maxJamesStrongNumber,
   Max(OriginalWord )           As maxOriginalWord
  From
   BibleFoundationJamesStrong (NoLock)
   Group By
     languageGreekHebrew
 */

 /* 
  When SET NOCOUNT is ON, the count (indicating the number of rows 
  affected by a Transact-SQL statement) is not returned. When SET 
  NOCOUNT is OFF, the count is returned.
 */
 SET NOCOUNT ON
 SELECT TOP 1
  originalWord 
 FROM
  BibleFoundationJamesStrong
 WHERE
  LanguageGreekHebrew = @languageGreekHebrew AND
  JamesStrongNumber   = @jamesStrongNumber
 
 --If Found then update the record, else insert the record
 IF @@ROWCOUNT > 0
 BEGIN
  UPDATE
  BibleFoundationJamesStrong
   SET
     OriginalWord = @originalWord,
     Pronounce    = @pronounce,
     Commentary   = @commentary
   WHERE
     LanguageGreekHebrew = @LanguageGreekHebrew AND
     JamesStrongNumber   = @JamesStrongNumber
 END --End Insert
 ELSE
 BEGIN
  INSERT
  BibleFoundationJamesStrong
   (
     LanguageGreekHebrew,
     JamesStrongNumber,
     OriginalWord,
     Pronounce,
     Commentary
   )
   VALUES
   (
     @LanguageGreekHebrew,
     @JamesStrongNumber,
     @OriginalWord,
     @Pronounce,
     @Commentary
   )
 END --End Insert
 --RETURN @@ROWCOUNT
END  --End Procedure


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE BibleFoundationPopulateNave
 @dictionaryId        int           = null,
 @dictionaryWord      varchar(50)   = null,
 @commentary          varchar(8000) = null
AS
BEGIN

 /*
 CREATE TABLE [dbo].[BibleFoundationNave] 
 (
	[DictionaryId] [int] NOT NULL ,
	[DictionaryWord] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Commentary] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
 ) ON [PRIMARY] TEXTIMAGE_ON [TEXT]

 ALTER TABLE [dbo].[BibleFoundationNave] WITH NOCHECK ADD 
	CONSTRAINT [PK_BibleFoundationNave] PRIMARY KEY  CLUSTERED 
	(
		[DictionaryId]
	)  ON [PRIMARY] 

 ALTER TABLE [dbo].[BibleFoundationNave] WITH NOCHECK ADD 
	CONSTRAINT [IX_BibleFoundationNave_DictionaryWord] UNIQUE  NONCLUSTERED 
	(
		[DictionaryWord]
	)  ON [INDEX] 
 */
 /* 
  When SET NOCOUNT is ON, the count (indicating the number of rows 
  affected by a Transact-SQL statement) is not returned. When SET 
  NOCOUNT is OFF, the count is returned.
 */

/*
Check for Duplicate DictionaryWord.
Select
  DictionaryWord,
  Count ( DictionaryWord ) As DictionaryWordCount
From
  BibleFoundationNave
Group By
  DictionaryWord
Having
  Count ( DictionaryWord ) > 1
*/

 SET NOCOUNT ON

 SELECT TOP 1
  dictionaryId
 FROM
  BibleFoundationNave
 WHERE
  DictionaryId = @dictionaryId
 
 --If Found then update the record, else insert the record
 IF @@ROWCOUNT > 0
 BEGIN
  UPDATE
  BibleFoundationNave
   SET
     DictionaryWord = @dictionaryWord,
     Commentary     = @commentary
   WHERE
     DictionaryId   = @dictionaryId
 END --End Insert
 ELSE
 BEGIN
  INSERT
  BibleFoundationNave
   (
     DictionaryId,
     DictionaryWord,
     Commentary
   )
   VALUES
   (
     @DictionaryId,
     @DictionaryWord,
     @Commentary
   )
 END --End Insert
 --RETURN @@ROWCOUNT
END  --End Procedure

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE BibleFoundationPopulateTorrey
 @dictionaryId        int           = null,
 @dictionaryWord      varchar(50)   = null,
 @commentary          varchar(8000) = null
AS
BEGIN

 /*
 CREATE TABLE [dbo].[BibleFoundationTorrey] 
 (
	[DictionaryId] [int] NOT NULL ,
	[DictionaryWord] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Commentary] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
 ) ON [PRIMARY] TEXTIMAGE_ON [TEXT]

 ALTER TABLE [dbo].[BibleFoundationTorrey] WITH NOCHECK ADD 
	CONSTRAINT [PK_BibleFoundationTorrey] PRIMARY KEY  CLUSTERED 
	(
		[DictionaryId]
	)  ON [PRIMARY] 

 ALTER TABLE [dbo].[BibleFoundationTorrey] WITH NOCHECK ADD 
	CONSTRAINT [IX_BibleFoundationTorrey_DictionaryWord] UNIQUE  NONCLUSTERED 
	(
		[DictionaryWord]
	)  ON [INDEX] 
 */
 /* 
  When SET NOCOUNT is ON, the count (indicating the number of rows 
  affected by a Transact-SQL statement) is not returned. When SET 
  NOCOUNT is OFF, the count is returned.
 */

/*
Check for Duplicate DictionaryWord.
Select
  DictionaryWord,
  Count ( DictionaryWord ) As DictionaryWordCount
From
  BibleFoundationTorrey
Group By
  DictionaryWord
Having
  Count ( DictionaryWord ) > 1
*/

 SET NOCOUNT ON

 SELECT TOP 1
  dictionaryId
 FROM
  BibleFoundationTorrey
 WHERE
  DictionaryId = @dictionaryId
 
 --If Found then update the record, else insert the record
 IF @@ROWCOUNT > 0
 BEGIN
  UPDATE
  BibleFoundationTorrey
   SET
     DictionaryWord = @dictionaryWord,
     Commentary     = @commentary
   WHERE
     DictionaryId   = @dictionaryId
 END --End Insert
 ELSE
 BEGIN
  INSERT
  BibleFoundationTorrey
   (
     DictionaryId,
     DictionaryWord,
     Commentary
   )
   VALUES
   (
     @DictionaryId,
     @DictionaryWord,
     @Commentary
   )
 END --End Insert
 --RETURN @@ROWCOUNT
END  --End Procedure


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE [dbo].[ChristURIDuplicate] AS

-- ChristURIDuplicate.sql
/*
Select
  *
From
  ChristURI
Where 
  TitleDictionarySortOrder IN ('Hammond, Fred', 'Weeks, Hilary', 'Williams, Michelle')
Order By
  TitleDictionarySortOrder
*/

Select
  TitleDictionarySortOrder,
  Count( TitleDictionarySortOrder ) TitleDictionarySortOrderCount
From
  ChristURI
Group By
  TitleDictionarySortOrder
Having
  Count( TitleDictionarySortOrder ) > 1

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.LoginAdd  AS

-- AddLogin.sql

EXEC sp_revokedbaccess 
     @name_in_db = 'UserLogin'

-- Drop the Login
EXEC sp_dropLogin
     @loginame  =  'UserLogin'

-- Create the Login, UserLogin
EXEC sp_addLogin
     @loginame  =  'UserLogin',
     @passwd    =  'UserPassword',
     @defdb     =  'Master'

-- Adds a login as a member of a fixed server role.
EXEC sp_addsrvrolemember 
     @loginame  =  'UserLogin',
     @rolename  =  'sysadmin'

EXEC sp_grantdbaccess 
     @loginame = 'UserLogin'

-- Add the SQL Server user, UserLogin, to the following roles:
--  db_accessadmin, db_owner, public 
EXEC 
     sp_addrolemember 
     @rolename    =  'db_accessadmin',
     @membername  =  'UserLogin'

EXEC 
     sp_addrolemember 
     @rolename    =  'db_owner',
     @membername  =  'UserLogin'

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE PopulateForum
 @dated           datetime      = null,
 @keyword         varchar(255)  = null,
 @post            varchar(8000) = null,
 @reply           varchar(8000) = null,
 @thread          varchar(8000) = null,
 @URI             varchar(255)  = null
AS
BEGIN

 /* 
  When SET NOCOUNT is ON, the count (indicating the number of rows 
  affected by a Transact-SQL statement) is not returned. When SET 
  NOCOUNT is OFF, the count is returned.
 */
 SET NOCOUNT ON
 SET @keyword = LTRIM(RTRIM(@keyword))
 SET @post = LTRIM(RTRIM(@post))
 SET @reply = LTRIM(RTRIM(@reply))
 SET @thread = LTRIM(RTRIM(@thread))
 SET @uri = LTRIM(RTRIM(@uri))
 SELECT TOP 1
  keyword
 FROM
  Forum
 WHERE
  URI = @URI
 
 --If Found then update the record, else insert the record
 IF @@ROWCOUNT > 0
 BEGIN --Begin Update
  UPDATE  Forum
  SET
   keyword = @keyword,
   post = @post,
   reply = @reply,
   thread = @thread
  WHERE
   URI      =  @uri
 END --End Update
 ELSE
 BEGIN --Begin Insert
  INSERT
  Forum
  (
   dated,
   keyword,
   post,
   reply,
   thread,
   uri
   )
   VALUES
   (
    @dated,
    @keyword,
    @post,
    @reply,
    @thread,
    @uri
   )
 END --End Insert
 --RETURN @@ROWCOUNT
END  --End Procedure


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.UtilityDatabaseAttach AS

--UtilityDatabaseAttach.sql

EXEC sp_attach_db 
   @dbname    = N'Comforter', 
   @filename1 = N'D:\SQLServerDataFiles\Comforter\Comforter_Data.MDF', 
   @filename2 = N'D:\SQLServerDataFiles\Comforter\Comforter_Log.LDF',
   @filename3 = N'D:\SQLServerDataFiles\Comforter\Comforter_Index_Data.NDF', 
   @filename4 = N'D:\SQLServerDataFiles\Comforter\Comforter_Text_Data.NDF',
   @filename5 = N'D:\SQLServerDataFiles\Comforter\Comforter_Xml_Data.NDF', 
   @filename6 = N'D:\SQLServerDataFiles\Comforter\Comforter_Image_Data.NDF'

EXEC sp_attach_db 
   @dbname    = N'WordEngineering', 
   @filename1 = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Data.MDF', 
   @filename2 = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Log.LDF',
   @filename3 = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Index_Data.NDF', 
   @filename4 = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Text_Data.NDF',
   @filename5 = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Xml_Data.NDF', 
   @filename6 = N'D:\SQLServerDataFiles\WordEngineering\WordEngineering_Image_Data.NDF'

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.UtilityDatabaseShrink AS

-- UtilityDatabaseShrink.sql

-- Database: Comforter

DBCC SHRINKDATABASE ( Comforter )

DBCC SHRINKFILE
(
 'Comforter_Log',
 TRUNCATEONLY
)

-- Database: WordEngineering

--Use WordEngineering
 
DBCC SHRINKDATABASE ( WordEngineering )

DBCC SHRINKFILE
(
 'WordEngineering_Log',
 TRUNCATEONLY
)



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE uspAlphabetSequence
 @word                               VARCHAR(600)  OUTPUT,
 @alphabetSequence                   INT           OUTPUT,
 @scriptureReferenceVerseForward     VARCHAR(600)  OUTPUT,
 @scriptureReferenceChapterForward   VARCHAR(600)  OUTPUT,
 @scriptureReferenceChapterBackward  VARCHAR(600)  OUTPUT,
 @scriptureReferenceVerseBackward    VARCHAR(600)  OUTPUT,
 @scriptureReference                 VARCHAR(600)  OUTPUT,
 @verseForward                       VARCHAR(600)  OUTPUT,
 @chapterForward                     VARCHAR(600)  OUTPUT,
 @chapterBackward                    VARCHAR(600)  OUTPUT,
 @verseBackward                      VARCHAR(600)  OUTPUT
AS 
BEGIN  -- Stored Procedure Begin

/*
 DECLARE
 @alphabetSequence                   INT,
 @scriptureReferenceVerseForward     VARCHAR(600),
 @scriptureReferenceChapterForward   VARCHAR(600),
 @scriptureReferenceChapterBackward  VARCHAR(600),
 @scriptureReferenceVerseBackward    VARCHAR(600),
 @scriptureReference                 VARCHAR(600),
 @word                               VARCHAR(600),
 @chapterBackward                    VARCHAR(600),
 @chapterForward                     VARCHAR(600),
 @verseBackward                      VARCHAR(600),
 @verseForward                       VARCHAR(600)

 SELECT
 @word                               = NULL,
 @alphabetSequence                   = 1,
 @scriptureReferenceVerseForward     = NULL,
 @scriptureReferenceChapterForward   = NULL,
 @scriptureReferenceChapterBackward  = NULL,
 @scriptureReferenceVerseBackward    = NULL,
 @scriptureReference                 = NULL,
 @verseForward                       = NULL,
 @chapterForward                     = NULL,
 @chapterBackward                    = NULL,
 @verseBackward                      = NULL

 EXEC uspAlphabetSequence
 @word                               OUTPUT,
 @alphabetSequence                   OUTPUT,
 @scriptureReferenceVerseForward     OUTPUT,
 @scriptureReferenceChapterForward   OUTPUT,
 @scriptureReferenceChapterBackward  OUTPUT,
 @scriptureReferenceVerseBackward    OUTPUT,
 @scriptureReference                 OUTPUT,
 @verseForward                       OUTPUT,
 @chapterForward                     OUTPUT,
 @chapterBackward                    OUTPUT,
 @verseBackward                      OUTPUT

 PRINT @scriptureReferenceVerseForward
 PRINT @scriptureReferenceChapterForward
 PRINT @scriptureReferenceChapterBackward
 PRINT @scriptureReferenceVerseBackward

 PRINT @scriptureReference
 PRINT @verseForward
 PRINT @chapterForward
 PRINT @chapterBackward
 PRINT @verseBackward

*/

/*
And the evening and the morning were the third day (Genesis 1:13).
Genesis 13
Revelation 10
Then saith he unto me, See thou do it not: for I am thy fellowservant, and of thy brethren the prophets, and of them which keep the sayings of this book: worship God (Revelation 22:9).
*/

SET NOCOUNT ON

DECLARE
  @chapterMaximum  INT,
  @verseMaximum    INT,
  @wordCount       INT

SELECT
  @chapterMaximum = Max( chapterIdSequence ),
  @verseMaximum   = Max( verseIdSequence )
FROM
  Bible..KJV ( NOLOCK )

SELECT
  @verseForward = LTRIM( RTRIM( verseTextWithScriptureReference ) ),
  @scriptureReferenceVerseForward = scriptureReferenceWithoutBracket
FROM 
  Bible..KJV ( NOLOCK )
WHERE 
  verseIdSequence = @alphabetSequence

SELECT
  @chapterForward = LTRIM( RTRIM( bookTitle ) ) + ' ' + LTRIM( RTRIM( CONVERT( VARCHAR, chapterId ) ) ) + '.',
  @scriptureReferenceChapterForward = bookTitle + ' ' + CONVERT( VARCHAR, chapterId )
FROM 
  Bible..KJV ( NOLOCK )
WHERE 
  chapterIdSequence = @alphabetSequence

SELECT
  @chapterBackward = LTRIM( RTRIM( bookTitle ) ) + ' ' + LTRIM( RTRIM( CONVERT( VARCHAR, chapterId ) ) ) + '.',
  @scriptureReferenceChapterBackward = bookTitle + ' ' + CONVERT( VARCHAR, chapterId )
FROM 
  Bible..KJV ( NOLOCK )
WHERE 
  chapterIdSequence = @chapterMaximum + 1 - @alphabetSequence

SELECT
  @verseBackward = LTRIM( RTRIM(  verseTextWithScriptureReference ) ),
  @scriptureReferenceVerseBackward = scriptureReferenceWithoutBracket
FROM 
  Bible..KJV ( NOLOCK )
WHERE 
  verseIdSequence = @verseMaximum + 1 - @alphabetSequence

SELECT
  @wordCount = Count(*)
FROM
  WordEngineering..AlphabetSequence
 
IF ( @wordCount = 0 )
BEGIN
 INSERT WordEngineering..AlphabetSequence
 (
  Word,
  AlphabetSequence,
  ScriptureReferenceVerseForward,
  ScriptureReferenceChapterForward,
  ScriptureReferenceChapterBackward,
  ScriptureReferenceVerseBackward
 )
 VALUES
 (
  @word,
  @alphabetSequence,
  @scriptureReferenceVerseForward,
  @scriptureReferenceChapterForward,
  @scriptureReferenceChapterBackward,
  @scriptureReferenceVerseBackward
 )
END

SELECT  @scriptureReference = 
                              @scriptureReferenceVerseForward    + ', ' +
                              @scriptureReferenceChapterForward  + ', ' +
                              @scriptureReferenceChapterBackward + ', ' +
                              @scriptureReferenceVerseBackward

/*
SELECT
 @word,
 @alphabetSequence,
 @scriptureReference,
 @verseForward,
 @chapterForward,
 @chapterBackward,
 @verseBackward
*/

/*
PRINT @scriptureReference
PRINT @verseForward
PRINT @chapterForward
PRINT @chapterBackward
PRINT @verseBackward
*/

END  -- Stored Procedure End.


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE uspAlphabetSequence
 @word                               VARCHAR(600)  OUTPUT,
 @alphabetSequence                   INT           OUTPUT,
 @scriptureReferenceVerseForward     VARCHAR(600)  OUTPUT,
 @scriptureReferenceChapterForward   VARCHAR(600)  OUTPUT,
 @scriptureReferenceChapterBackward  VARCHAR(600)  OUTPUT,
 @scriptureReferenceVerseBackward    VARCHAR(600)  OUTPUT,
 @scriptureReference                 VARCHAR(600)  OUTPUT,
 @verseForward                       VARCHAR(600)  OUTPUT,
 @chapterForward                     VARCHAR(600)  OUTPUT,
 @chapterBackward                    VARCHAR(600)  OUTPUT,
 @verseBackward                      VARCHAR(600)  OUTPUT
AS 
BEGIN  -- Stored Procedure Begin

/*
 DECLARE
 @alphabetSequence                   INT,
 @scriptureReferenceVerseForward     VARCHAR(600),
 @scriptureReferenceChapterForward   VARCHAR(600),
 @scriptureReferenceChapterBackward  VARCHAR(600),
 @scriptureReferenceVerseBackward    VARCHAR(600),
 @scriptureReference                 VARCHAR(600),
 @word                               VARCHAR(600),
 @chapterBackward                    VARCHAR(600),
 @chapterForward                     VARCHAR(600),
 @verseBackward                      VARCHAR(600),
 @verseForward                       VARCHAR(600)

 SELECT
 @word                               = NULL,
 @alphabetSequence                   = 1,
 @scriptureReferenceVerseForward     = NULL,
 @scriptureReferenceChapterForward   = NULL,
 @scriptureReferenceChapterBackward  = NULL,
 @scriptureReferenceVerseBackward    = NULL,
 @scriptureReference                 = NULL,
 @verseForward                       = NULL,
 @chapterForward                     = NULL,
 @chapterBackward                    = NULL,
 @verseBackward                      = NULL

 EXEC uspAlphabetSequence
 @word                               OUTPUT,
 @alphabetSequence                   OUTPUT,
 @scriptureReferenceVerseForward     OUTPUT,
 @scriptureReferenceChapterForward   OUTPUT,
 @scriptureReferenceChapterBackward  OUTPUT,
 @scriptureReferenceVerseBackward    OUTPUT,
 @scriptureReference                 OUTPUT,
 @verseForward                       OUTPUT,
 @chapterForward                     OUTPUT,
 @chapterBackward                    OUTPUT,
 @verseBackward                      OUTPUT

 PRINT @scriptureReferenceVerseForward
 PRINT @scriptureReferenceChapterForward
 PRINT @scriptureReferenceChapterBackward
 PRINT @scriptureReferenceVerseBackward

 PRINT @scriptureReference
 PRINT @verseForward
 PRINT @chapterForward
 PRINT @chapterBackward
 PRINT @verseBackward

*/

/*
And the evening and the morning were the third day (Genesis 1:13).
Genesis 13
Revelation 10
Then saith he unto me, See thou do it not: for I am thy fellowservant, and of thy brethren the prophets, and of them which keep the sayings of this book: worship God (Revelation 22:9).
*/

SET NOCOUNT ON

DECLARE
  @chapterMaximum  INT,
  @verseMaximum    INT,
  @wordCount       INT

SELECT
  @chapterMaximum = Max( chapterIdSequence ),
  @verseMaximum   = Max( verseIdSequence )
FROM
  Bible..KJV ( NOLOCK )

SELECT
  @verseForward = LTRIM( RTRIM( verseTextWithScriptureReference ) ),
  @scriptureReferenceVerseForward = scriptureReferenceWithoutBracket
FROM 
  Bible..KJV ( NOLOCK )
WHERE 
  verseIdSequence = @alphabetSequence

SELECT
  @chapterForward = LTRIM( RTRIM( bookTitle ) ) + ' ' + LTRIM( RTRIM( CONVERT( VARCHAR, chapterId ) ) ) + '.',
  @scriptureReferenceChapterForward = bookTitle + ' ' + CONVERT( VARCHAR, chapterId )
FROM 
  Bible..KJV ( NOLOCK )
WHERE 
  chapterIdSequence = @alphabetSequence

SELECT
  @chapterBackward = LTRIM( RTRIM( bookTitle ) ) + ' ' + LTRIM( RTRIM( CONVERT( VARCHAR, chapterId ) ) ) + '.',
  @scriptureReferenceChapterBackward = bookTitle + ' ' + CONVERT( VARCHAR, chapterId )
FROM 
  Bible..KJV ( NOLOCK )
WHERE 
  chapterIdSequence = @chapterMaximum + 1 - @alphabetSequence

SELECT
  @verseBackward = LTRIM( RTRIM(  verseTextWithScriptureReference ) ),
  @scriptureReferenceVerseBackward = scriptureReferenceWithoutBracket
FROM 
  Bible..KJV ( NOLOCK )
WHERE 
  verseIdSequence = @verseMaximum + 1 - @alphabetSequence

SELECT
  @wordCount = Count(*)
FROM
  WordEngineering..AlphabetSequence
 
IF ( @wordCount = 0 )
BEGIN
 INSERT WordEngineering..AlphabetSequence
 (
  Word,
  AlphabetSequence,
  ScriptureReferenceVerseForward,
  ScriptureReferenceChapterForward,
  ScriptureReferenceChapterBackward,
  ScriptureReferenceVerseBackward
 )
 VALUES
 (
  @word,
  @alphabetSequence,
  @scriptureReferenceVerseForward,
  @scriptureReferenceChapterForward,
  @scriptureReferenceChapterBackward,
  @scriptureReferenceVerseBackward
 )
END

SELECT  @scriptureReference = 
                              @scriptureReferenceVerseForward    + ', ' +
                              @scriptureReferenceChapterForward  + ', ' +
                              @scriptureReferenceChapterBackward + ', ' +
                              @scriptureReferenceVerseBackward

/*
SELECT
 @word,
 @alphabetSequence,
 @scriptureReference,
 @verseForward,
 @chapterForward,
 @chapterBackward,
 @verseBackward
*/

/*
PRINT @scriptureReference
PRINT @verseForward
PRINT @chapterForward
PRINT @chapterBackward
PRINT @verseBackward
*/

END  -- Stored Procedure End.


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE uspBehaviorQuery
 @datedFrom           AS varchar(50)    =  null,
 @datedTo             AS varchar(50)    =  null,
 @keyword             AS varChar(50)    =  null,
 @sequenceOrderFrom   AS integer        =  null,
 @sequenceOrderTo     AS integer        =  null,
 @scriptureReference  AS varchar(8000)  =  null,
 @actor               AS varchar(8000)  =  null,
 @commentary          AS varchar(8000)  =  null
AS
BEGIN

 --uspBehaviorQuery @keyword = 'God Title'
 --uspBehaviorQuery @datedFrom = '20020925', @datedTo = '20020927'
 --uspBehaviorQuery @scriptureReference = 'Genesis 22'
 --uspBehaviorQuery @actor = 'God'
 --uspBehaviorQuery @commentary = 'Jesus Christ'
 --uspBehaviorQuery @sequenceOrderFrom = 2
 --uspBehaviorQuery @sequenceOrderTo   = 5
 --uspBehaviorQuery @sequenceOrderFrom = 3, @sequenceOrderTo = 7

 DECLARE  @sql        AS nvarchar(4000)
 DECLARE  @and        AS varchar(5) 
 DECLARE  @from       AS varchar(4000)
 DECLARE  @select     AS varchar(4000)
 DECLARE  @where      AS varchar(8000)
 DECLARE  @orderBy    AS varchar(8000)
 
 SET      @select     =  'SELECT  ' +
--                       ' Dated, '
                         ' Keyword, SequenceOrder, ScriptureReference, Actor, Commentary '
 SET      @and        =  ' AND '
 SET      @from       =  ' FROM Behavior '
 SET      @where      =  ' WHERE ' + SPACE(5)
 SET      @orderBy    =  ' ORDER BY Keyword, SequenceOrder '  

 IF @datedFrom <> null
 BEGIN
  SET @where = @where + ' Dated >= ''' + @datedFrom + '''' + @and
 END

 IF @datedTo <> null
 BEGIN
  SET @where = @where + ' Dated <= ''' + @datedTo + '''' + @and
 END

 IF @keyword <> null
 BEGIN
  SET @where = @where + ' keyword Like ''%' + @keyword + '%''' + @and
 END

 IF @sequenceOrderFrom <> null
 BEGIN
  SET @where = @where + ' sequenceOrder >= ' + CONVERT( VarChar, @sequenceOrderFrom ) + @and
 END

 IF @sequenceOrderTo <> null
 BEGIN
  SET @where = @where + ' sequenceOrder <= ' + CONVERT( VarChar, @sequenceOrderTo ) + @and
 END

 IF @scriptureReference <> null
 BEGIN
  SET @where = @where + ' scriptureReference Like ''%' + @scriptureReference + '%''' + @and
 END

 IF @actor <> null
 BEGIN
  SET @where = @where + ' actor Like ''%' + @actor + '%''' + @and
 END

 IF @commentary <> null
 BEGIN
  SET @where = @where + ' commentary Like ''%' + @commentary + '%''' + @and
 END

 Print @where

 SET @where = LEFT( @where, LEN(@where) - LEN(@and) )

 SET @sql = @select + @from + @where + @orderBy

 EXECUTE sp_executesql @sql

 PRINT @sql

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE uspBibleDictionaryQuery
 @bibleFoundationJamesStrongDictionaryWord AS varchar(50)    =  null
AS
BEGIN

 --uspBibleDictionaryQuery @bibleFoundationJamesStrongDictionaryWord = 'God'
 --uspBibleDictionaryQuery @bibleFoundationJamesStrongDictionaryWord = 'David'

 DECLARE  @sql        AS nvarchar(4000)
 DECLARE  @and        AS varchar(5) 
 DECLARE  @from       AS varchar(4000)
 DECLARE  @select     AS varchar(4000)
 DECLARE  @where      AS varchar(8000)
 DECLARE  @orderBy    AS varchar(8000)
 
 SET      @select     =  'SELECT  ' +
                         ' BibleFoundationJamesStrongDictionaryWord, ' +
                         ' BibleDatabaseBiblicalNameCommentary, '      +
                         ' BibleDatabaseEastonCommentary, '            +
                         ' BibleFoundationEastonCommentary, '          +
                         ' BibleFoundationJamesStrongCommentary, '     +
                         ' BibleFoundationNaveCommentary, '            +
                         ' BibleFoundationTorreyCommentary '

 SET      @and        =  ' AND '
 SET      @from       =  ' FROM Bible..BibleDictionary '
 SET      @where      =  ' WHERE ' + SPACE(5)
 SET      @orderBy    =  ' ORDER BY BibleFoundationJamesStrongDictionaryWord '  

 IF @bibleFoundationJamesStrongDictionaryWord <> null
 BEGIN
  SET @where = @where + ' BibleFoundationJamesStrongDictionaryWord Like ''%' + @bibleFoundationJamesStrongDictionaryWord + '%''' + @and
 END

 SET @where = LEFT( @where, LEN(@where) - LEN(@and) )

 SET @sql = @select + @from + @where + @orderBy

 EXECUTE sp_executesql @sql

 PRINT @sql

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE uspChapterMaximum
AS 
BEGIN  -- Stored Procedure Begin

SET NOCOUNT ON

SELECT
  Max( chapterIdSequence )
FROM
  Bible..KJV ( NOLOCK )

END  -- Stored Procedure End.



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE uspKJVUpdate
AS 
BEGIN  -- Stored Procedure Begin

-- EXEC uspKJVUpdate

SET NOCOUNT ON

DECLARE
  @bookId                            int,
  @chapterId                         int,
  @verseId                           int,
  @verseText                         varChar(550),
  @bookTitle                         varChar(50),
  @scriptureReferenceWithoutBracket  varChar(50),
  @scriptureReferenceWithBracket     varChar(50),
  @verseTextWithScriptureReference   varChar(600),
  @sequenceIdChapter                 int,
  @sequenceIdVerse                   int,
  @bookIdCurrent                     int,
  @bookTitleCurrent                  varChar(50),
  @chapterIdCurrent                  int,
  @sequenceIdChapterCurrent          int,
  @sequenceIdVerseCurrent            int

DECLARE cursorKJV CURSOR FOR 
SELECT 
  bookId,
  chapterId,
  verseId,
  verseText,
  bookTitle,
  scriptureReferenceWithoutBracket,
  scriptureReferenceWithBracket,  
  verseTextWithScriptureReference,
  sequenceIdChapter,
  sequenceIdVerse
FROM 
  Bible..KJV
ORDER BY 
  bookId, chapterId, verseId

SELECT
  @bookIdCurrent            = 0,
  @bookTitleCurrent         = '',
  @chapterIdCurrent         = 0,
  @sequenceIdChapterCurrent = 0,
  @sequenceIdVerseCurrent   = 0

OPEN cursorKJV

FETCH NEXT FROM cursorKJV INTO 
  @bookId,
  @chapterId,
  @verseId,
  @verseText,
  @bookTitle,
  @scriptureReferenceWithoutBracket,
  @scriptureReferenceWithBracket,  
  @verseTextWithScriptureReference,
  @sequenceIdChapter,
  @sequenceIdVerse

WHILE @@FETCH_STATUS = 0
BEGIN

   IF @bookId <> @bookIdCurrent
   BEGIN
      SET @bookIdCurrent    = @bookId
      SET @bookTitleCurrent = @bookTitle
   END

   IF @chapterId <> @chapterIdCurrent
   BEGIN
      SET @chapterIdCurrent   = @chapterId
      SET @sequenceIdChapterCurrent = @sequenceIdChapterCurrent + 1
   END

   SET @sequenceIdVerseCurrent = @sequenceIdVerseCurrent + 1

   SET @scriptureReferenceWithoutBracket = @bookTitleCurrent + 
                                           ' ' +
                                           CONVERT( varChar, @chapterId ) +
                                           ':' +
                                           CONVERT( varChar, @verseId ) 

   SET @scriptureReferenceWithBracket    = '(' + 
                                           @scriptureReferenceWithoutBracket +  
                                           ')'

   SET @verseTextWithScriptureReference  = LEFT ( @verseText, LEN( @verseText ) - 1 ) + 
                                           ' ' + 
                                           @scriptureReferenceWithBracket + 
                                           '.'

   UPDATE  Bible..KJV
   SET     
     scriptureReferenceWithoutBracket  =  @scriptureReferenceWithoutBracket,
     scriptureReferenceWithBracket     =  @scriptureReferenceWithBracket,  
     verseTextWithScriptureReference   =  @verseTextWithScriptureReference,
     sequenceIdChapter                 =  @sequenceIdChapterCurrent,
     sequenceIdVerse                   =  @sequenceIdVerseCurrent
   WHERE CURRENT OF cursorKJV

   -- Get the next verse
   FETCH NEXT FROM cursorKJV INTO 
    @bookId,
    @chapterId,
    @verseId,
    @verseText,
    @bookTitle,
    @scriptureReferenceWithoutBracket,
    @scriptureReferenceWithBracket,  
    @verseTextWithScriptureReference,
    @sequenceIdChapter,
    @sequenceIdVerse

END

CLOSE cursorKJV
DEALLOCATE cursorKJV

END  -- Stored Procedure End.


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE uspNoiseQuery
 @datedFrom           AS varchar(50)       =  null,
 @datedTo             AS varchar(50)       =  null,
 @commentary          AS varchar(8000)     =  null,
 @noiseId             AS uniqueidentifier  =  null,
 @policeId            AS uniqueidentifier  =  null
AS
BEGIN

 --uspNoiseQuery @datedFrom = '20030101', @datedTo = '20031231'
 --uspNoiseQuery @commentary = '%'

 /*
 CREATE TABLE [dbo].[Noise] (
	[NoiseId] [uniqueidentifier] NOT NULL ,
	[Dated] [datetime] NOT NULL ,
	[Commentary] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PoliceId] [uniqueidentifier] NULL 
 ) ON [PRIMARY]
 */

 DECLARE  @sql        AS nvarchar(4000)
 DECLARE  @and        AS varchar(5) 
 DECLARE  @from       AS varchar(4000)
 DECLARE  @select     AS varchar(4000)
 DECLARE  @where      AS varchar(8000)
 DECLARE  @orderBy    AS varchar(8000)

 /*
 SET      @select     =  'SELECT  ' +
                         ' CONVERT(VARCHAR, Dated, 20) AS Dated, ' +
                         ' ISNULL(Commentary, "")  AS Commentary'
 */

 SET      @select     =  'SELECT Dated, Commentary '

 SET      @and        =  '  AND  '
 SET      @from       =  ' FROM Noise (NOLOCK) '
 SET      @where      =  ' WHERE ' + SPACE(7)
 SET      @orderBy    =  ' ORDER BY Dated '  

 SET @commentary = LTRIM( RTRIM( @commentary ) )
 SET @datedFrom = LTRIM( RTRIM( @datedFrom ) )
 SET @datedTo = LTRIM( RTRIM( @datedTo ) )

 IF @commentary = ''
 BEGIN
  SET @commentary = null
 END

 IF @datedFrom = ''
 BEGIN
  SET @datedFrom = null
 END

 IF @datedTo = ''
 BEGIN
  SET @datedTo = null
 END

 IF @datedFrom <> null
 BEGIN
  SET @where = @where + ' Dated >= ''' + @datedFrom + '''' + @and
 END

 IF @datedTo <> null
 BEGIN
  SET @where = @where + ' Dated <= ''' + @datedTo + '''' + @and
 END

 IF @commentary <> null
 BEGIN
  SET @where = @where + ' commentary Like ''%' + @commentary + '%''' + @and
 END

 IF @noiseId <> null
 BEGIN
  SET @where = @where + ' noiseId = ' + CONVERT( VARCHAR, @noiseId ) + @and
 END

 IF @policeId <> null
 BEGIN
  SET @where = @where + ' policeId = ' + CONVERT( VARCHAR, @policeId ) + @and
 END

 --Print @where

 SET @where = LEFT( @where, LEN(@where) - LEN(@and) )

 SET @sql = @select + @from + @where + @orderBy

 EXECUTE sp_executesql @sql

 --PRINT @sql

END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE uspScriptureReferenceRetrieval 
 @scriptureReference AS VarChar(8000)
AS

 --Exec uspScriptureReferenceRetrieval @scriptureReference = 'Genesis 22'
 --Exec uspScriptureReferenceRetrieval @scriptureReference = 'John 3:15'
 --Exec uspScriptureReferenceRetrieval @scriptureReference = 'Daniel 9:24-27'
 
 DECLARE @CharacterSeparatorChapterVerse                 CHAR
 DECLARE @CharacterSeparatorFromTo                       CHAR
 DECLARE @CharacterSeparatorScriptureReferenceComma      CHAR
 DECLARE @CharacterSeparatorScriptureReferenceSemicolon  CHAR
 DECLARE @CharacterSpace                                 CHAR

 DECLARE @scriptureReferenceCharacter       CHAR

 DECLARE @scriptureReferenceLength          INT
 DECLARE @scriptureReferencePosition        INT
 DECLARE @scriptureReferenceBook            INT

 DECLARE @scriptureReferenceContextBook     INT
 DECLARE @scriptureReferenceContextFromTo   BIT
 DECLARE @scriptureReferenceContextChapter  INT
 DECLARE @scriptureReferenceContextVerse    INT
 DECLARE @scriptureReferenceContextCurrent  INT

 DECLARE @scriptureReferenceFromBook        VarChar(8000)
 DECLARE @scriptureReferenceFromChapter     VarChar(8000)
 DECLARE @scriptureReferenceFromSet         VarChar(8000)
 DECLARE @scriptureReferenceFromVerse       VarChar(8000)

 DECLARE @scriptureReferenceSubset          BIT

 DECLARE @scriptureReferenceToBook          VarChar(8000)
 DECLARE @scriptureReferenceToChapter       VarChar(8000)
 DECLARE @scriptureReferenceToSet           VarChar(8000)
 DECLARE @scriptureReferenceToVerse         VarChar(8000)

 BEGIN

  SET @CharacterSeparatorChapterVerse                = ':'
  SET @CharacterSeparatorFromTo                      = '-'
  SET @CharacterSeparatorScriptureReferenceComma     = ','
  SET @CharacterSeparatorScriptureReferenceSemicolon = ';'
  SET @CharacterSpace                                = ' '

  SET @scriptureReferenceLength         = LEN( @scriptureReference )
  SET @scriptureReferencePosition       = 0
  
  SET @scriptureReferenceContextBook    = 1
  SET @scriptureReferenceContextChapter = 2
  SET @scriptureReferenceContextVerse   = 3

  SET @scriptureReferenceContextBook    = @scriptureReferenceContextCurrent
  SET @scriptureReferenceContextFromTo  = 0

  SET @scriptureReferenceFromBook       = ''
  SET @scriptureReferenceFromChapter    = ''
  SET @scriptureReferenceFromSet        = ''
  SET @scriptureReferenceFromVerse      = ''

  SET @scriptureReferenceSubset         = 0

  SET @scriptureReferenceToBook         = ''
  SET @scriptureReferenceToChapter      = ''
  SET @scriptureReferenceToSet          = ''
  SET @scriptureReferenceToVerse        = ''

  WHILE @scriptureReferencePosition <= @scriptureReferenceLength
  BEGIN
   SET @scriptureReferencePosition  = @scriptureReferencePosition + 1
   SET @scriptureReferenceCharacter = SUBSTRING( @scriptureReference, @scriptureReferencePosition, 1 )

   IF @scriptureReferenceCharacter = @CharacterSeparatorFromTo 
   BEGIN
     SET @scriptureReferenceContextFromTo = 1 -- Scripture Reference Context To.
     CONTINUE
   END

   IF @scriptureReferenceCharacter = @CharacterSeparatorScriptureReferenceComma OR
      @scriptureReferenceCharacter = @CharacterSeparatorScriptureReferenceSemiColon
   BEGIN
      SET @scriptureReferenceSubset = 1
   END

   IF @scriptureReferenceContextFromTo = 0 -- Scripture Reference Context From.
   BEGIN
     SET @scriptureReferenceFromSet = @scriptureReferenceFromSet + @scriptureReferenceCharacter
   END 
   ELSE -- Scripture Reference Context To.
   BEGIN
     SET @scriptureReferenceToSet = @scriptureReferenceToSet + @scriptureReferenceCharacter
   END 

  END --WHILE @scriptureReferencePosition <= @scriptureReferenceLength

  PRINT 'Scripture Reference From: ' + @scriptureReferenceFromSet
  PRINT 'Scripture Reference To:   ' + @scriptureReferenceToSet

 END --Stored Procedure Begin


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE PROCEDURE uspScriptureRetrievalReference
  @scriptureReference varChar(4000) 
AS 
BEGIN  -- Stored Procedure Begin
  /* 
  Exec uspScriptureRetrievalReference @scriptureReference = 'Genesis 1:1-2:13' --200209061322
  Exec uspScriptureRetrievalReference @scriptureReference = 'John 3:14' 
  Exec uspScriptureRetrievalReference @scriptureReference = 'Isaiah 53'
  Exec uspScriptureRetrievalReference @scriptureReference = 'Daniel 9:24-27'  
  Exec uspScriptureRetrievalReference @scriptureReference = 'Isaiah 52:13-53:12'  
  Exec uspScriptureRetrievalReference @scriptureReference = '2 Samuel 21:20'  
  Exec uspScriptureRetrievalReference @scriptureReference = 'Genesis 1:1-2:13, John 3:14, Isaiah 53, Daniel 9:24-27, Isaiah 52:13-53:12'  
  */

  DECLARE  @scriptureReferenceBookId                                AS  integer
  DECLARE  @scriptureReferenceBookTitle                             AS  char(20)
  DECLARE  @scriptureReferenceDelimiter                             AS  char
  DECLARE  @scriptureReferenceSubset                                AS  varChar(4000)
  DECLARE  @scriptureReferenceLength                                AS  integer
  DECLARE  @scriptureReferenceDelimiterLocationEnd                  AS  integer
  DECLARE  @scriptureReferenceDelimiterLocationStart                AS  integer
  
  DECLARE  @scriptureReferenceSeparatorChapterVerse                 AS  char
  DECLARE  @scriptureReferenceSeparatorFromTo                       AS  char

  DECLARE  @scriptureReferenceSubsetLength                          AS  integer
  DECLARE  @scriptureReferenceSubsetPosition                        AS  integer
  DECLARE  @scriptureReferenceSubsetDelimiterPosition               AS  integer 

  DECLARE  @soundexDifference                                       AS  integer
  DECLARE  @soundexBookId                                           AS  integer
  DECLARE  @soundexBookTitle                                        AS  char(20)

  DECLARE  @scriptureReferenceSubsetBookId                          AS  integer
  DECLARE  @scriptureReferenceSubsetBookTitle                       AS  char(20)
  DECLARE  @scriptureReferenceSubsetCurrentCharacter                AS  char
  DECLARE  @scriptureReferenceSubsetChapter                         AS  integer
  DECLARE  @scriptureReferenceSubsetChapterFrom                     AS  integer
  DECLARE  @scriptureReferenceSubsetChapterTo                       AS  integer
  DECLARE  @scriptureReferenceSubsetVerseFrom                       AS  integer
  DECLARE  @scriptureReferenceSubsetVerseTo                         AS  integer

  DECLARE  @sqlStatement                                            AS  nVarChar(4000)
  DECLARE  @sqlStatementSelect                                      AS  varChar(255)
  DECLARE  @sqlStatementFrom                                        AS  varChar(255)
  DECLARE  @sqlStatementWhere                                       AS  varChar(4000)
  DECLARE  @sqlStatementOrderBy                                     AS  varChar(255)

  DECLARE  @verseReference                                          AS  varChar(50)
  DECLARE  @verseText                                               AS  varChar(550)
  DECLARE  @verseTextConcatenate                                    AS  varChar(8000)
  DECLARE  @verseTextConcatenateWithReference                       AS  varChar(8000)

  DECLARE  @verseLimitLow                                           AS  int
  DECLARE  @verseLimitHigh                                          AS  int

  DECLARE  @sequenceIdVerseFrom                                     AS  int
  DECLARE  @sequenceIdVerseTo                                       AS  int

-- SET @scriptureReference                       = UPPER( @scriptureReference )
  SET @scriptureReferenceLength                 = LEN( @scriptureReference )
  SET @scriptureReferenceDelimiter              = ','
  SET @scriptureReferenceSeparatorChapterVerse  = ':'
  SET @scriptureReferenceSeparatorFromTo        = '-'

  SET @scriptureReferenceDelimiterLocationEnd   = 1
  SET @scriptureReferenceDelimiterLocationStart = 1

  SET @scriptureReferenceSubsetBookTitle        = null
  SET @scriptureReferenceSubsetCurrentCharacter = null
  SET @scriptureReferenceSubsetChapter          = 0
  SET @scriptureReferenceSubsetChapterFrom      = 0
  SET @scriptureReferenceSubsetChapterTo        = 0
  SET @scriptureReferenceSubsetVerseFrom        = 0
  SET @scriptureReferenceSubsetVerseTo          = 0

  SET @sqlStatement                             = ''
  SET @sqlStatementSelect                       = ' Select ' +
                                                  ' sequenceIdVerse, ' +
                                                  ' verseTextWithScriptureReference  AS verseTextWithScriptureReference '
  SET @sqlStatementFrom                         = ' FROM  Bible..KJV ( NoLock ) '
  SET @sqlStatementWhere                        = ' WHERE ' +
                                                  ' sequenceIdVerse Between   ' +
                                                  ' @sequenceIdVerseBegin AND ' +
                                                  ' @sequenceIdVerseEnd       ' 
  SET @sqlStatementOrderBy                      = ' ORDER BY sequenceIdVerse  '
  SET @verseTextConcatenate                     = ''
  SET @verseTextConcatenateWithReference        = ''

  SET @verseLimitLow                            = 1
  SET @verseLimitHigh                           = 1000

  SET @sequenceIdVerseFrom                      = 0
  SET @sequenceIdVerseTo                        = 0

  -- While not the last scripture reference.
  WHILE @scriptureReferenceDelimiterLocationEnd > 0  
  BEGIN

    IF    @sqlStatement <> ''
    BEGIN
          SET @sqlStatement = @sqlStatement + ' UNION '
    END

    SET @scriptureReferenceSubsetBookTitle        = null
    SET @scriptureReferenceSubsetCurrentCharacter = null
    SET @scriptureReferenceSubsetChapter          = 0
    SET @scriptureReferenceSubsetChapterFrom      = 0
    SET @scriptureReferenceSubsetChapterTo        = 0
    SET @scriptureReferenceSubsetVerseFrom        = 0
    SET @scriptureReferenceSubsetVerseTo          = 0

    -- Determine the end position for this particular
    -- scripture reference subset.
    SET @scriptureReferenceDelimiterLocationEnd = CHARINDEX
      (
        @scriptureReferenceDelimiter,
        @scriptureReference,
        @scriptureReferenceDelimiterLocationStart
      )

    -- If there is no more scripture reference delimiter,
    -- then process this scripture reference as the
    -- last scripture reference.
    IF  @scriptureReferenceDelimiterLocationEnd = 0
    BEGIN
        SET @scriptureReferenceSubset = SUBSTRING
            (
              @scriptureReference,
              @scriptureReferenceDelimiterLocationStart,
              @scriptureReferenceLength - 
              @scriptureReferenceDelimiterLocationStart
              + 1
            )
    END  -- This is the last scripture reference.
    -- If this is not the last scripture reference delimiter,
    -- then retrieve this particular scripture reference
    -- subset within the entire scripture reference set.
    ELSE
    BEGIN
        SET @scriptureReferenceSubset = SUBSTRING
            (
              @scriptureReference,
              @scriptureReferenceDelimiterLocationStart,
              @scriptureReferenceDelimiterLocationEnd - 
              @scriptureReferenceDelimiterLocationStart
            )
    END  -- This is not the last scripture reference.

    SET  @scriptureReferenceDelimiterLocationStart  =
         @scriptureReferenceDelimiterLocationEnd + 1

    -- The Scripture Reference Subset Length
    SET @scriptureReferenceSubsetLength = LEN( @scriptureReferenceSubset )

    -- Parse the Scripture Reference Subset. 
    -- Retrieve the book, chapter, and verse.
    SET  @scriptureReferenceSubsetBookId            = 0
    SET  @scriptureReferenceSubsetBookTitle         = '' 
    SET  @scriptureReferenceSubsetChapter           = 0
    SET  @scriptureReferenceSubsetChapterFrom       = 0
    SET  @scriptureReferenceSubsetChapterTo         = 0
    SET  @scriptureReferenceSubsetDelimiterPosition = 1
    SET  @scriptureReferenceSubsetPosition          = 1

    WHILE @scriptureReferenceSubsetPosition <= @scriptureReferenceSubsetLength
    BEGIN

      SET  @scriptureReferenceSubsetCurrentCharacter = SUBSTRING
           ( 
             @scriptureReferenceSubset,
             @scriptureReferenceSubsetPosition,
             1
           )

      IF ( @scriptureReferenceSubsetCurrentCharacter < 'A'   OR
           @scriptureReferenceSubsetCurrentCharacter > 'Z' ) AND
           @scriptureReferenceSubsetBookTitle = '' 
      BEGIN
        SET @scriptureReferenceSubsetBookTitle = LEFT
           ( 
             @scriptureReferenceSubset, 
             @scriptureReferenceSubsetPosition - 1
           )
        SET @scriptureReferenceSubsetDelimiterPosition = 
            @scriptureReferenceSubsetPosition
      END

      -- Separator ChapterVerse.
      IF ( @scriptureReferenceSubsetCurrentCharacter = 
           @scriptureReferenceSeparatorChapterVerse )
      BEGIN

        SET @scriptureReferenceSubsetChapter = CONVERT( INT, SUBSTRING
            ( 
              @scriptureReferenceSubset,              
              @scriptureReferenceSubsetDelimiterPosition + 1,
              @scriptureReferenceSubsetPosition - 
              @scriptureReferenceSubsetDelimiterPosition - 1
            ) )

        IF  @scriptureReferenceSubsetChapterFrom <= 0
        BEGIN
            SET @scriptureReferenceSubsetChapterFrom = 
                @scriptureReferenceSubsetChapter
        END
        ELSE
        BEGIN
            SET @scriptureReferenceSubsetChapterTo = 
                @scriptureReferenceSubsetChapter
        END
        SET @scriptureReferenceSubsetDelimiterPosition = 
            @scriptureReferenceSubsetPosition
      END

      -- Separator FromTo.
      IF ( @scriptureReferenceSubsetCurrentCharacter = 
           @scriptureReferenceSeparatorFromTo )
      BEGIN
        SET @scriptureReferenceSubsetVerseFrom = CONVERT( INT, SUBSTRING
            ( 
              @scriptureReferenceSubset,              
              @scriptureReferenceSubsetDelimiterPosition + 1,
              @scriptureReferenceSubsetPosition - 
              @scriptureReferenceSubsetDelimiterPosition - 1
            ) )
        SET @scriptureReferenceSubsetDelimiterPosition = 
            @scriptureReferenceSubsetPosition
      END

      SET  @scriptureReferenceSubsetPosition = 
           @scriptureReferenceSubsetPosition + 1

    END  -- Parse the Scripture Reference Subset.

    SET @scriptureReferenceSubsetVerseTo = CONVERT( INT, SUBSTRING
        ( 
          @scriptureReferenceSubset,
          @scriptureReferenceSubsetDelimiterPosition + 1, 
          @scriptureReferenceSubsetLength - 
          @scriptureReferenceSubsetDelimiterPosition
         ) )

    SET @scriptureReferenceSubset = LTRIM( RTRIM ( @scriptureReferenceSubset ) )
    SET @scriptureReferenceSubsetBookTitle = LTRIM ( RTRIM ( @scriptureReferenceSubsetBookTitle ) )

    -- Determine the book id and title for the current scripture reference using Soundex.
    SELECT TOP 1 
      @scriptureReferenceSubsetBookId = bookId
    FROM Bible..BibleBook ( NoLock )
    WHERE bookTitle = @scriptureReferenceSubsetBookTitle

    -- Determine the book id and title for the current scripture reference using Soundex.
    /*
    SELECT TOP 1 
      @soundexDifference = DIFFERENCE( bookTitle, @scriptureReferenceSubsetBookTitle ), 
      @soundexBookId     = bookId, 
      @soundexBookTitle  = bookTitle
    FROM Bible..BibleBook ( NoLock )
    ORDER BY DIFFERENCE( bookTitle, @scriptureReferenceSubsetBookTitle ) DESC
    */

    -- Genesis 1:1-2:13 Patch.
    IF @scriptureReferenceSubsetChapterFrom > 0 AND
       @scriptureReferenceSubsetVerseFrom   > 0 AND
       @scriptureReferenceSubsetChapterTo   > 0 AND
       @scriptureReferenceSubsetVerseTo     > 0 
    BEGIN
       SELECT 
           @verseReference                    = @scriptureReferenceSubsetBookTitle +
                                                ' ' +
                                                CONVERT( varChar, @scriptureReferenceSubsetChapterFrom ) +
                                                ':' +
                                                CONVERT( varChar, @scriptureReferenceSubsetVerseFrom ) +
                                                '-' +
                                                CONVERT( varChar, @scriptureReferenceSubsetChapterTo ) +
                                                ':' +
                                                CONVERT( varChar, @scriptureReferenceSubsetVerseTo ) 
    END
    -- John 3:14 Patch.
    ELSE IF @scriptureReferenceSubsetChapterFrom > 0 AND
       @scriptureReferenceSubsetVerseFrom   = 0 AND
       @scriptureReferenceSubsetChapterTo   = 0 AND
       @scriptureReferenceSubsetVerseTo     > 0 
    BEGIN
       SELECT 
           @scriptureReferenceSubsetChapterTo = @scriptureReferenceSubsetChapterFrom,
           @scriptureReferenceSubsetVerseFrom = @scriptureReferenceSubsetVerseTo,
           @verseReference                    = @scriptureReferenceSubsetBookTitle +
                                                ' ' +
                                                CONVERT( varChar, @scriptureReferenceSubsetChapterFrom ) +
                                                ':' +
                                                CONVERT( varChar, @scriptureReferenceSubsetVerseFrom ) 
    END

    -- Isaiah 53 Patch.
    ELSE IF @scriptureReferenceSubsetChapterFrom = 0 AND
       @scriptureReferenceSubsetVerseFrom   = 0 AND
       @scriptureReferenceSubsetChapterTo   = 0 AND
       @scriptureReferenceSubsetVerseTo     > 0 
    BEGIN
       SELECT 
           @scriptureReferenceSubsetChapterFrom = @scriptureReferenceSubsetVerseTo,
           @scriptureReferenceSubsetChapterTo   = @scriptureReferenceSubsetVerseTo,
           @scriptureReferenceSubsetVerseFrom   = @verseLimitLow,
           @scriptureReferenceSubsetVerseTo     = @verseLimitHigh,
           @verseReference                      = @scriptureReferenceSubsetBookTitle +
                                                  ' ' +
                                                  CONVERT( varChar, @scriptureReferenceSubsetChapterFrom ) 
    END

    -- Daniel 9:24-27 Patch
    ELSE IF @scriptureReferenceSubsetChapterFrom > 0 AND
       @scriptureReferenceSubsetVerseFrom   > 0 AND
       @scriptureReferenceSubsetChapterTo   = 0 AND
       @scriptureReferenceSubsetVerseTo     > 0 
    BEGIN
       SELECT 
           @scriptureReferenceSubsetChapterTo   = @scriptureReferenceSubsetChapterFrom,
           @verseReference                      = @scriptureReferenceSubsetBookTitle +
                                                  ' ' +
                                                  CONVERT( varChar, @scriptureReferenceSubsetChapterFrom ) +
                                                  ':' +
                                                  CONVERT( varChar, @scriptureReferenceSubsetVerseFrom ) +
                                                  '-' +
                                                  CONVERT( varChar, @scriptureReferenceSubsetVerseTo ) 
    END

    /*
    PRINT 'Book Id:                ' + CONVERT( VarChar, @scriptureReferenceSubsetBookId )
    PRINT 'Book Title:             ' + @scriptureReferenceSubsetBookTitle
    PRINT 'Chapter From:           ' + CONVERT( VarChar, @scriptureReferenceSubsetChapterFrom )
    PRINT 'Verse   From:           ' + CONVERT( VarChar, @scriptureReferenceSubsetVerseFrom )    
    PRINT 'Chapter To:             ' + CONVERT( VarChar, @scriptureReferenceSubsetChapterTo )
    PRINT 'Verse   To:             ' + CONVERT( VarChar, @scriptureReferenceSubsetVerseTo )    
    */

    SELECT TOP 1
          @sequenceIdVerseFrom = sequenceIdVerse
    FROM    
          Bible..KJV ( NoLock )
    WHERE
          bookId    = @scriptureReferenceSubsetBookId       AND
          chapterId = @scriptureReferenceSubsetChapterFrom  AND
          verseId   = @scriptureReferenceSubsetVerseFrom

    SELECT TOP 1
          @sequenceIdVerseTo = sequenceIdVerse
    FROM    
          Bible..KJV ( NoLock )
    WHERE
          bookId    = @scriptureReferenceSubsetBookId       AND
          chapterId = @scriptureReferenceSubsetChapterTo    AND
          verseId   = @scriptureReferenceSubsetVerseTo

    IF @sequenceIdVerseTo = 0
    BEGIN
      SELECT TOP 1
          @sequenceIdVerseTo = sequenceIdVerse
      FROM    
          Bible..KJV ( NoLock )
      WHERE
          bookId    = @scriptureReferenceSubsetBookId       AND
          chapterId = @scriptureReferenceSubsetChapterTo
      ORDER BY
          verseId DESC
    END

    SET   @sqlStatement = @sqlStatement + @sqlStatementSelect + @sqlStatementFrom + 
                          ' WHERE sequenceIdVerse BETWEEN ' +
                          CONVERT( varChar, @sequenceIdVerseFrom ) +
                          ' AND ' +
                          CONVERT( varChar, @sequenceIdVerseTo ) 


  END  -- While not the last scripture reference.

  SET   @sqlStatement = @sqlStatement + @sqlStatementOrderBy

  EXEC sp_executesql  @sqlStatement

END  -- Stored Procedure End.



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE uspUtilDatabaseRecoverySimple AS
-- uspUtilDatabaseRecoverySimple.sql

/*
<recovery_options>
Controls database recovery options. 
RECOVERY FULL | BULK_LOGGED | SIMPLE 
If FULL is specified, complete protection against media failure is provided. If a data file is damaged, media recovery can restore all committed transactions. 
If BULK_LOGGED is specified, protection against media failure is combined with the best performance and least amount of log memory usage for certain large scale or bulk operations. These operations include SELECT INTO, bulk load operations (bcp and BULK INSERT), CREATE INDEX, and text and image operations (WRITETEXT and UPDATETEXT).
Under the bulk-logged recovery model, logging for the entire class is minimal and cannot be controlled on an operation-by-operation basis.
If SIMPLE is specified, a simple backup strategy that uses minimal log space is provided. Log space can be automatically reused when no longer needed for server failure recovery.
Important  The simple recovery model is easier to manage than the other two models but at the expense of higher data loss exposure if a data file is damaged. All changes since the most recent database or differential database backup are lost and must be re-entered manually.
The default recovery model is determined by the recovery model of the model database. To change the default for new databases, use ALTER DATABASE to set the recovery option of the model database.
*/

Alter Database Master                  Set Recovery Simple
Alter Database Model                   Set Recovery Simple
Alter Database Comforter              Set Recovery Simple
Alter Database URI                       Set Recovery Simple
Alter Database WordEngineering  Set Recovery Simple

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

