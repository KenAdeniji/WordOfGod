@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMake TheWordSerialization.mak
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation