@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE CatalogNorthWindProducts.mak
Del *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation