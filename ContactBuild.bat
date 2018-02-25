@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE Contact.mak
REM DEL *.pdb XmlDocumentation /F /S /Q
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation