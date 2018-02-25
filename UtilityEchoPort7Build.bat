@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE UtilityEchoPort7.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation