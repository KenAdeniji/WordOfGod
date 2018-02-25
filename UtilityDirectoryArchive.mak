all: UtilityDirectory.exe

UtilityDirectory.exe: UtilityDirectory.cs
 csc /define:DEBUG /debug:full /doc:UtilityDirectoryDocumentation.xml /main:WordEngineering.UtilityDirectory /out:UtilityDirectory.exe /target:exe UtilityDirectory.cs
 
Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation 