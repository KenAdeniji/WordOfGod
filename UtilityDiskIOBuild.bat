@ECHO OFF
NMAKE UtilityDiskIO.mak
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation