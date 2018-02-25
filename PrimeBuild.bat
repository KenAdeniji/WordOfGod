@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE Prime.mak
Del XmlDocumentation /F /S /Q
Rd XmlDocumentation