@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE UtilityControl.mak
Rem Del *.pdb XmlDocumentation /F /S /Q
Rem Rd XmlDocumentation