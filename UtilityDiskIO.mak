all: UtilityDiskIO.dll

UtilityDiskIO.dll: UtilityDiskIO.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityDiskIO.xml /out:UtilityDiskIO.dll /target:library UtilityDiskIO.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation