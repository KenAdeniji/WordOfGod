@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMake UtilityDNS.mak
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation