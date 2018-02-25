@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE SQLSCM.mak
REM ILDASM SQLSCMTypeLib.dll
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation