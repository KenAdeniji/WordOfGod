all: ShaheedAli.exe

ShaheedAli.exe: ShaheedAli.cs BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs TheWord.cs TheWordSerialization.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityRegularExpression.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ShaheedAli.xml /main:WordEngineering.ShaheedAli /out:ShaheedAli.exe /target:exe /unsafe ShaheedAli.cs BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs TheWord.cs TheWordSerialization.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityRegularExpression.cs UtilityFile.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation