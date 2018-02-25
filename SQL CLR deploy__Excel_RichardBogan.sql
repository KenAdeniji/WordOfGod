--use master
--drop database CLR
--create database CLR
--exec sp_helpdb CLR
--exec sp_changedbowner sa
use CLR
go

alter database CLR set TRUSTWORTHY on;
go

exec sp_configure 'clr enabled', 1
reconfigure
go

drop proc TestOLEDB
go

drop ASSEMBLY TestOLEDB;
go

-- exec master.dbo.xp_cmdshell'dir \\Epicmsdev02\datastoreclr$\TestOleDb.dll'

CREATE ASSEMBLY TestOleDb
FROM 'd:\datastoreclr\TestOleDb.dll'
with PERMISSION_SET = UNSAFE;
go

CREATE PROCEDURE [dbo].[TestOleDb]
	@WithImpersonation [nvarchar](4000),
	@filePath [nvarchar](4000),
	@tabname [nvarchar](4000)
WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [TestOleDb].[StoredProcedures].[TestOleDb]
GO
EXEC sys.sp_addextendedproperty @name=N'AutoDeployed', @value=N'yes' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'PROCEDURE', @level1name=N'TestOleDb'

GO
EXEC sys.sp_addextendedproperty @name=N'SqlAssemblyFile', @value=N'TestOleDb.cs' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'PROCEDURE', @level1name=N'TestOleDb'

GO
EXEC sys.sp_addextendedproperty @name=N'SqlAssemblyFileLine', @value=10 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'PROCEDURE', @level1name=N'TestOleDb'
go

DECLARE @rc int
DECLARE @impersonate varchar(1)
DECLARE @path varchar(50)
SET @impersonate = 'Y'
IF (@@SERVERNAME = 'LTGO279503')
	SET @path = 'c:\Temp\mrtu\Forward_b.xls'
ELSE
	SET @path = 'd:\datastoreclr\AT_excel_Forward_03.xls'

BEGIN TRY
	EXEC @rc = TestOleDb @impersonate, @path, 'ContraCostaIII'
	PRINT 'TestOleDb ran successfully'
END TRY
BEGIN CATCH
	PRINT 'Error in TestOleDb'
	PRINT ERROR_MESSAGE()
END CATCH
PRINT 'End TestOleDB'


BEGIN TRY
	EXEC @rc = TestDataSource @impersonate, @path, 'ContraCostaIII'
	PRINT 'TestDataSource ran successfully'
END TRY
BEGIN CATCH
	PRINT 'Error in TestOleDb'
	PRINT ERROR_MESSAGE()
END CATCH
PRINT 'End TestDataSource'


--exec sp_addlogin 'clr', 'c1r', clr
--go

--exec sp_grantdbaccess clr