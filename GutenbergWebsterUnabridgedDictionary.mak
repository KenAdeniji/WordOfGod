all: GutenbergWebsterUnabridgedDictionary.exe GutenbergWebsterUnabridgedDictionaryPage.aspx.cs.dll

GutenbergWebsterUnabridgedDictionary.xsd: ..\Translatum\wb1913_a.html
 Xcopy ..\Translatum\wb1913_a.html ..\Translatum\wb1913_a.xml /C /D /E /I /R /S /Y  
 xsd ..\Translatum\wb1913_a.xml /outputdir:..\Translatum\
 
wb1913_a.xml: ..\Translatum\wb1913_a.html
 ..\DaveRaggett\DaveRaggett_-_Tidy04aug00.exe ..\Translatum\wb1913_a.html ..\Translatum\wb1913_a.xml
 
ProjectGutenberg_-_GutenbergWebster'sUnabridgedDictionaryABComforter.xsd: ProjectGutenberg_-_GutenbergWebster'sUnabridgedDictionaryABComforter.xml
 xsd.exe ..\ProjectGutenberg\ProjectGutenberg_-_GutenbergWebster'sUnabridgedDictionaryABComforter.xml /outputdir:..\ProjectGutenberg

GutenbergWebsterUnabridgedDictionary.exe: GutenbergWebsterUnabridgedDictionary.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\GutenbergWebsterUnabridgedDictionary.xml /main:WordEngineering.GutenbergWebsterUnabridgedDictionary /out:GutenbergWebsterUnabridgedDictionary.exe /target:exe GutenbergWebsterUnabridgedDictionary.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs

GutenbergWebsterUnabridgedDictionaryPage.aspx.cs.dll: GutenbergWebsterUnabridgedDictionaryPage.aspx.cs GutenbergWebsterUnabridgedDictionary.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\GutenbergWebsterUnabridgedDictionaryPage.xml /main:WordEngineering.GutenbergWebsterUnabridgedDictionary /out:bin\GutenbergWebsterUnabridgedDictionaryPage.aspx.cs.dll /target:exe GutenbergWebsterUnabridgedDictionaryPage.aspx.cs GutenbergWebsterUnabridgedDictionary.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation