all: InternetDictionaryProjectIDP.exe InternetDictionaryProjectIDPPage.aspx.cs.dll

InternetDictionaryProjectIDP.exe: InternetDictionaryProjectIDP.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityImpersonate.cs UtilityJavaScript.cs UtilityProcess.cs UtilityProperty.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\InternetDictionaryProjectIDPDocumentation.xml /main:WordEngineering.InternetDictionaryProjectIDP /out:InternetDictionaryProjectIDP.exe /target:exe InternetDictionaryProjectIDP.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityImpersonate.cs UtilityJavaScript.cs UtilityProcess.cs UtilityProperty.cs UtilityXml.cs

InternetDictionaryProjectIDPPage.aspx.cs.dll: InternetDictionaryProjectIDPPage.aspx.cs InternetDictionaryProjectIDP.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityImpersonate.cs UtilityJavaScript.cs UtilityProcess.cs UtilityProperty.cs UtilityXml.cs
 csc /doc:XmlDocumentation\InternetDictionaryProjectIDPWebFormDocumentation.xml /out:bin\InternetDictionaryProjectIDPPage.aspx.cs.dll /target:library InternetDictionaryProjectIDPPage.aspx.cs InternetDictionaryProjectIDP.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityImpersonate.cs UtilityJavaScript.cs UtilityProcess.cs UtilityProperty.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation