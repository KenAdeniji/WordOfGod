DROP ASSEMBLY AsposeCells

use CLR
go

exec sp_configure 'clr enabled', 1
go

reconfigure
go

CREATE ASSEMBLY [Aspose.Cells]
FROM 
'C:\Progra~1\Aspose\Aspose.Cells\Bin\Net2.0\Aspose.Cells.dll'
WITH PERMISSION_SET = UNSAFE
go

DROP ASSEMBLY EphAspose1

CREATE ASSEMBLY EphAspose1
FROM 
'C:\DanielAdeniji\SQLScripts\PGE\CLR\20080515\Lab2\EphAspose1.dll'
WITH PERMISSION_SET = UNSAFE
go

CREATE PROC usp_EphAspose1
as EXTERNAL NAME
EphAspose1.[EphAspose].tryAspose
;
go

exec usp_EphAspose1
