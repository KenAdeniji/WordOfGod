all: UtilityEncrypt.exe

UtilityEncrypt.exe: UtilityEncrypt.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityEncrypt.xml /main:WordEngineering.UtilityEncrypt /out:UtilityEncrypt.exe /target:exe /unsafe UtilityEncrypt.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation