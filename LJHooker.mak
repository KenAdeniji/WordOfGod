all: LJHookerPage.aspx.cs.dll

LJHookerPage.aspx.cs.dll: LJHookerPage.aspx.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\LJHookerPageDocumentation.xml /out:bin\LJHookerPage.aspx.cs.dll /target:library LJHookerPage.aspx.cs


Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation
