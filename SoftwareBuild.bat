@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE Software.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation