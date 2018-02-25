@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE ActiveDIrectory.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation
