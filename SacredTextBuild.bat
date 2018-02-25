@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE SacredText.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation