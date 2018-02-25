all: UtilitySQLServerEnumerator.exe SQLServerEnumeratorPage.aspx.cs.dll

SQLServerEnumeratorPage.aspx.cs.dll: SQLServerEnumeratorPage.aspx.cs UtilitySQLServerEnumerator.cs UtilityCollection.cs UtilityDirectory.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\SQLServerEnumeratorPageDocumentation.xml /out:bin\SQLServerEnumeratorPage.aspx.cs.dll /target:library SQLServerEnumeratorPage.aspx.cs UtilitySQLServerEnumerator.cs UtilityCollection.cs UtilityDirectory.cs UtilityFile.cs UtilityXml.cs

UtilitySQLServerEnumerator.exe: UtilitySQLServerEnumerator.cs UtilityCollection.cs UtilityDirectory.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilitySQLServerEnumerator.xml /main:WordEngineering.UtilitySQLServerEnumerator /out:UtilitySQLServerEnumerator.exe /target:exe UtilitySQLServerEnumerator.cs UtilityCollection.cs UtilityDirectory.cs UtilityFile.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation