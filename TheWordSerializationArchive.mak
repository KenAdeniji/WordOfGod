all: TheWordSerialization.exe  TheWordSerializationPage.aspx.cs.dll

TheWordSerialization.exe: TheWordSerialization.cs BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs TheWord.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\TheWordSerialization.xml /main:WordEngineering.TheWordSerialization /out:TheWordSerialization.exe /target:exe /unsafe TheWordSerialization.cs BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs TheWord.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs

TheWordSerializationPage.aspx.cs.dll: TheWordSerializationPage.aspx.cs TheWordSerialization.cs BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs TheWord.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\TheWordSerializationPageDocumentation.xml /out:bin\TheWordSerializationPage.aspx.cs.dll /target:library /unsafe TheWordSerializationPage.aspx.cs TheWordSerialization.cs BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs TheWord.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs 

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation