@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE Contact.mak
DEL *.pdb XmlDocumentation /F /S /Q
RD XmlDocumentation