@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMake InternetDictionaryProjectIDP.mak
Rem Del *.pdb XmlDocumentation /F /S /Q
Rem Rd XmlDocumentation