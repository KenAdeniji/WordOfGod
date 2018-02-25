all: ScriptureReference.exe ScriptureReferenceSearchPage.aspx.cs.dll

ScriptureReference.exe: BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ScriptureReferenceDocumentation.xml /main:WordEngineering.ScriptureReference /out:ScriptureReference.exe /target:exe BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs 
 
ScriptureReferenceSearchPage.aspx.cs.dll: BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs ScriptureReferenceSearchPage.aspx.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ScriptureReferenceSearchPageDocumentation.xml /out:bin\ScriptureReferenceSearchPage.aspx.cs.dll /target:library BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceBookChapterVersePrePost.cs ScriptureReferenceSearchPage.aspx.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs
 
Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation 