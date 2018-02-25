@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMake Image.mak
Rem Del *.pdb XmlDocumentation /F /S /Q
Rem Rd XmlDocumentation