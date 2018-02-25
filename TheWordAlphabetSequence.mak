all: TheWordAlphabetSequence.exe

TheWordAlphabetSequence.exe: AlphabetSequence.cs BibleBookTitle.cs  ScriptureReference.cs ScriptureReferenceAlphabetSequence.cs ScriptureReferenceBookChapterVersePrePost.cs TheWord.cs TheWordAlphabetSequence.cs  TheWordSerialization.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\TheWordDocumentation.xml /main:WordEngineering.TheWordAlphabetSequence /out:TheWordAlphabetSequence.exe /target:exe ScriptureReferenceBookChapterVersePrePost.cs AlphabetSequence.cs BibleBookTitle.cs  ScriptureReference.cs ScriptureReferenceAlphabetSequence.cs TheWord.cs TheWordSerialization.cs TheWordAlphabetSequence.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation