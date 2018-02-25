@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE UtilityCompress.mak
Del XmlDocumentation /F /S /Q
Rd XmlDocumentation