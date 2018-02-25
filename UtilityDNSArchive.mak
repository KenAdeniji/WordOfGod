all: UtilityDNS.exe

UtilityDNS.exe: UtilityDNS.cs UtilityRegistry.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityDNSDocumentation.xml /main:WordEngineering.UtilityDNS /out:UtilityDNS.exe /target:exe UtilityDNS.cs UtilityRegistry.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation 