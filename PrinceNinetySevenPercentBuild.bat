@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE PrinceNinetySevenPercent.mak
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation