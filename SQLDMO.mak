all: SQLDMOPage.aspx.cs.dll UtilitySQLDMOTypeLib.dll UtilitySQLDMO.exe

UtilitySQLDMOTypeLib.dll: "C:\Program Files\Microsoft SQL Server\80\Tools\Binn\SQLDMO.dll"
 TLBIMP "C:\Program Files\Microsoft SQL Server\80\Tools\Binn\SQLDMO.dll" /Out:SQLDMOTypeLib.dll
 ILDASM SQLDMOTypeLib.dll
 Xcopy SQLDMOTypeLib.dll bin /C /D /E /I /R /S /Y /Z

UtilitySQLDMO.exe: UtilitySQLDMO.cs SQLDMOTypeLib.dll UtilityCollection.cs UtilityDirectory.cs UtilityFile.cs UtilityNet.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilitySQLDMO.xml /main:WordEngineering.UtilitySQLDMO /out:UtilitySQLDMO.exe /target:exe UtilitySQLDMO.cs UtilityCollection.cs UtilityDirectory.cs UtilityFile.cs UtilityNet.cs UtilityXml.cs /reference:SQLDMOTypeLib.dll

SQLDMOPage.aspx.cs.dll: SQLDMOPage.aspx.cs UtilitySQLDMO.cs UtilityCollection.cs UtilityDirectory.cs UtilityFile.cs UtilityNet.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\SQLDMOPageDocumentation.xml /out:bin\SQLDMOPage.aspx.cs.dll /target:library SQLDMOPage.aspx.cs UtilitySQLDMO.cs UtilityCollection.cs UtilityDirectory.cs UtilityFile.cs  UtilityNet.cs UtilityXml.cs /reference:SQLDMOTypeLib.dll

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation