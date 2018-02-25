@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE Honed.mak
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation