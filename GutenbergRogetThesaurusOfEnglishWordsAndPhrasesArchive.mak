all: GutenbergRogetThesaurusOfEnglishWordsAndPhrases.exe GutenbergRogetThesaurusOfEnglishWordsAndPhrasesPage.aspx.cs.dll

GutenbergRogetThesaurusOfEnglishWordsAndPhrases.exe: GutenbergRogetThesaurusOfEnglishWordsAndPhrases.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\GutenbergRogetThesaurusOfEnglishWordsAndPhrases.xml /main:WordEngineering.GutenbergRogetThesaurusOfEnglishWordsAndPhrases /out:GutenbergRogetThesaurusOfEnglishWordsAndPhrases.exe /target:exe GutenbergRogetThesaurusOfEnglishWordsAndPhrases.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs

GutenbergRogetThesaurusOfEnglishWordsAndPhrasesPage.aspx.cs.dll: GutenbergRogetThesaurusOfEnglishWordsAndPhrasesPage.aspx.cs GutenbergRogetThesaurusOfEnglishWordsAndPhrases.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\GutenbergRogetThesaurusOfEnglishWordsAndPhrasesPage.xml /main:WordEngineering.GutenbergRogetThesaurusOfEnglishWordsAndPhrases /out:bin\GutenbergRogetThesaurusOfEnglishWordsAndPhrasesPage.aspx.cs.dll /target:exe GutenbergRogetThesaurusOfEnglishWordsAndPhrasesPage.aspx.cs GutenbergRogetThesaurusOfEnglishWordsAndPhrases.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation