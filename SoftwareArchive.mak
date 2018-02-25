all: SoftwarePage.aspx.cs.dll

SoftwarePage.aspx.cs.dll: SoftwarePage.aspx.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\SoftwarePageDocumentation.xml /out:bin\SoftwarePage.aspx.cs.dll /target:library SoftwarePage.aspx.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation