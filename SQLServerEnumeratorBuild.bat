@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE SQLServerEnumerator.mak
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation