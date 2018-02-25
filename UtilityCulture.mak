all: bin\UtilityCulture.dll UtilityCulture.exe
 
bin\UtilityCulture.dll: UtilityCulture.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityCultureDocumentation.xml /out:bin\UtilityCulture.dll /target:library UtilityCulture.cs

UtilityCulture.exe: UtilityCulture.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityCultureDocumentation.xml /main:WordEngineering.UtilityCulture /out:UtilityCulture.exe /target:exe UtilityCulture.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation 