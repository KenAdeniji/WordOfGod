@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE AccountChart.mak
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation