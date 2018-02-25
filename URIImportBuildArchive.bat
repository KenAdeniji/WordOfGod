@Echo Off
Md XmlDocumentation
NMake URIImport.mak
Del   *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation
