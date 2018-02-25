all: ClassAssociatesPage.aspx.cs.dll

ClassAssociatesPage.aspx.cs.dll: ClassAssociatesPage.aspx.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ClassAssociatesPageDocumentation.xml /out:bin\ClassAssociatesPage.aspx.cs.dll /target:library ClassAssociatesPage.aspx.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation