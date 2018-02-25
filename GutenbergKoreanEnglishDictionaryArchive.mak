all: GutenbergKoreanEnglishDictionary.exe GutenbergKoreanEnglishDictionaryPage.aspx.cs.dll

GutenbergKoreanEnglishDictionary.exe: GutenbergKoreanEnglishDictionary.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\GutenbergKoreanEnglishDictionary.xml /main:WordEngineering.GutenbergKoreanEnglishDictionary /out:GutenbergKoreanEnglishDictionary.exe /target:exe GutenbergKoreanEnglishDictionary.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs

GutenbergKoreanEnglishDictionaryPage.aspx.cs.dll: GutenbergKoreanEnglishDictionaryPage.aspx.cs GutenbergKoreanEnglishDictionary.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityImpersonate.cs UtilityJavaScript.cs UtilityProcess.cs UtilityProperty.cs UtilityXml.cs
 csc /doc:XmlDocumentation\GutenbergKoreanEnglishDictionaryWebFormDocumentation.xml /out:bin\GutenbergKoreanEnglishDictionaryPage.aspx.cs.dll /target:library GutenbergKoreanEnglishDictionaryPage.aspx.cs GutenbergKoreanEnglishDictionary.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityImpersonate.cs UtilityJavaScript.cs UtilityProcess.cs UtilityProperty.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation