all: URIExport.exe 

URIExport.exe: UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs URIExport.cs UtilityXml.cs
 csc /doc:XmlDocumentation\URIExportDocumentation.xml /main:WordEngineering.URIExport /out:URIExport.exe /target:exe UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs URIExport.cs UtilityXml.cs