@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE UtilityEncrypt.mak
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation