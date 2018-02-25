@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE DarkBrownCarpet.mak
DEL XmlDocumentation /F /S /Q
Rd XmlDocumentation