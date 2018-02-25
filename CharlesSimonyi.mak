all: CharlesSimonyiPage.aspx.cs.dll

CharlesSimonyiPage.aspx.cs.dll: CharlesSimonyiPage.aspx.cs bin\DarkBrownCarpet.dll
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\CharlesSimonyiPageDocumentation.xml /out:bin\CharlesSimonyiPage.aspx.cs.dll /reference:bin\DarkBrownCarpet.dll /target:library CharlesSimonyiPage.aspx.cs

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation
