@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE Event.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation