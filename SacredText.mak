all: bin\SacredTextGridViewPage.aspx.cs.dll
 
bin\SacredTextGridViewPage.aspx.cs.dll: SacredTextGridViewPage.aspx.cs CommandLineArguments.cs UtilityCommandLineArgument.cs UtilityCollection.cs UtilityDebug.cs UtilityDirectory.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\SacredTextGridViewPageDocumentation.xml /out:bin\SacredTextGridViewPage.aspx.cs.dll /target:library SacredTextGridViewPage.aspx.cs CommandLineArguments.cs UtilityCommandLineArgument.cs UtilityCollection.cs UtilityDebug.cs UtilityDirectory.cs UtilityFile.cs UtilityXml.cs

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation 