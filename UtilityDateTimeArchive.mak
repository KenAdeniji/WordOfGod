all: UtilityDateTime.exe
 
UtilityDateTime.exe: UtilityDateTime.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityDateTimeDocumentation.xml /main:WordEngineering.UtilityDateTime /out:UtilityDateTime.exe /target:exe UtilityDateTime.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation