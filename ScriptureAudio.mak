all: ScriptureAudio.exe

ScriptureAudio.exe: bin\SpeechTypeLib.dll BibleBookTitle.cs ScriptureAudio.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /main:WordEngineering.ScriptureAudio /out:ScriptureAudio.exe /reference:SpeechTypeLib.dll /target:exe BibleBookTitle.cs ScriptureAudio.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs 
 
Clean:
 DEL XmlDocumentation /F /S /Q

 