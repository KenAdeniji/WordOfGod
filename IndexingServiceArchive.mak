all: UtilityIndexingService.exe IndexingServicePage.aspx.cs.dll

UtilityIndexingService.exe: UtilityIndexingService.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityIndexingServiceDocumentation.xml /main:WordEngineering.UtilityIndexingService /out:UtilityIndexingService.exe /target:exe UtilityIndexingService.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs

IndexingServicePage.aspx.cs.dll: IndexingServicePage.aspx.cs UtilityIndexingService.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\IndexingServiceWebFormDocumentation.xml /out:bin\IndexingServicePage.aspx.cs.dll /target:library IndexingServicePage.aspx.cs UtilityIndexingService.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation