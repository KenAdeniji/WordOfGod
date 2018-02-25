@Echo Off
Md XmlDocumentation
NMake ScriptureReference.mak
Del   XmlDocumentation /F /S /Q
Rd XmlDocumentation