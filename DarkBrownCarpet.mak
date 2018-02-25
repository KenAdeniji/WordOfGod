all: bin\DarkBrownCarpet.dll DarkBrownCarpet.exe

bin\DarkBrownCarpet.dll: DarkBrownCarpet.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\DarkBrownCarpetDocumentation.xml /out:bin\DarkBrownCarpet.dll /target:library DarkBrownCarpet.cs

DarkBrownCarpet.exe: DarkBrownCarpet.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\DarkBrownCarpetDocumentation.xml /out:DarkBrownCarpet.exe /target:exe DarkBrownCarpet.cs

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation