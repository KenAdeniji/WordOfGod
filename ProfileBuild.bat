@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE Profile.mak
Rem Del *.pdb XmlDocumentation /F /S /Q
Rem Rd XmlDocumentation