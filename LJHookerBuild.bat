@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE LJHooker.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation