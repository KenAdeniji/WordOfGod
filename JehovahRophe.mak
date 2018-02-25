all: JehovahRophePage.aspx.cs.dll

JehovahRophePage.aspx.cs.dll: JehovahRophePage.aspx.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\JehovahRophePageDocumentation.xml /out:bin\JehovahRophePage.aspx.cs.dll /target:library JehovahRophePage.aspx.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation