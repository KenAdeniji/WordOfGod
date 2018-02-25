all: Eternal.exe ServiceEternal.exe
 
Eternal.exe: BibleBookTitle.cs Eternal.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs TheWord.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityException.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\EternalDocumentation.xml /main:WordEngineering.Eternal /out:Eternal.exe /target:exe BibleBookTitle.cs Eternal.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs TheWord.cs TheWordSerialization.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityException.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs

ServiceEternal.exe: ServiceEternal.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ServiceEternalDocumentation.xml /main:WordEngineering.ServiceEternal /out:ServiceEternal.exe /target:exe ServiceEternal.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs
 
Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation 