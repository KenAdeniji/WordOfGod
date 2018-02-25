@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE CharlesSimonyi.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation