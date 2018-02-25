all: TheseAreTheFirstFruits.exe

TheseAreTheFirstFruits.exe: TheseAreTheFirstFruits.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:TheseAreTheFirstFruitsDocumentation.xml /main:WordEngineering.TheseAreTheFirstFruits /out:TheseAreTheFirstFruits.exe /target:exe TheseAreTheFirstFruits.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation