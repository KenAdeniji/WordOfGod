@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE SQLDMO.mak
REM ILDASM SQLDMOTypeLib.dll
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation