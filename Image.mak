all: ImagePage.aspx.cs.dll

ImagePage.aspx.cs.dll: ImagePage.aspx.cs UtilityJavaScript.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ImagePageDocumentation.xml /out:bin\ImagePage.aspx.cs.dll /target:library ImagePage.aspx.cs UtilityJavaScript.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation