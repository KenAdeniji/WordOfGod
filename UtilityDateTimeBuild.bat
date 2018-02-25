@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE UtilityDateTime.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation