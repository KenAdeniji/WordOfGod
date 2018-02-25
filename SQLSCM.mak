all: SQLSCMTypeLib.dll

SQLSCMTypeLib.dll: "C:\Program Files\Microsoft SQL Server\90\Tools\binn\SQLSCM90.DLL"
 TLBIMP "C:\Program Files\Microsoft SQL Server\90\Tools\binn\SQLSCM90.DLL" /Out:SQLSCMTypeLib.dll
 ILDASM SQLSCMTypeLib.dll
 Xcopy SQLSCMTypeLib.dll bin /C /D /E /I /R /S /Y /Z

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation