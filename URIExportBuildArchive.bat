@Echo Off
Md XmlDocumentation
NMake URIExport.mak
Del   *.pdb XmlDocumentation /F /S /Q
Rd XmlDocumentation
