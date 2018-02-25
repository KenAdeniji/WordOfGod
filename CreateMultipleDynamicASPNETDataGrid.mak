all: CreateMultipleDynamicASPNETDataGridPage.aspx.cs.dll 

CreateMultipleDynamicASPNETDataGridPage.aspx.cs.dll: CreateMultipleDynamicASPNETDataGridPage.aspx.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\CreateMultipleDynamicASPNETDataGridPagePage.xml /out:bin\CreateMultipleDynamicASPNETDataGridPage.aspx.cs.dll /target:library CreateMultipleDynamicASPNETDataGridPage.aspx.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation 