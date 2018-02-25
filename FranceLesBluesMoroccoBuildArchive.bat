@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE FranceLesBluesMorocco.mak
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation