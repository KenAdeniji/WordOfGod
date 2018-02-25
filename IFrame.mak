all: IFramePage.aspx.cs.dll

IFramePage.aspx.cs.dll: IFramePage.aspx.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\IFramePageDocumentation.xml /out:bin\IFramePage.aspx.cs.dll /target:library IFramePage.aspx.cs

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation