all: ControlPage.aspx.cs.dll

ControlPage.aspx.cs.dll: ControlPage.aspx.cs UtilityControl.cs UtilityDebug.cs UtilityJavaScript.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ControlPage.xml /out:bin\ControlPage.aspx.cs.dll /target:library ControlPage.aspx.cs UtilityControl.cs UtilityDebug.cs UtilityJavaScript.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation