@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE JehovahRophe.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation