all: CatalogNorthWindProductsPage.aspx.cs.dll

CatalogNorthWindProductsPage.aspx.cs.dll: CatalogNorthWindProductsPage.aspx.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\CatalogNorthWindProductsPageDocumentation.xml /out:bin\CatalogNorthWindProductsPage.aspx.cs.dll /target:library /unsafe CatalogNorthWindProductsPage.aspx.cs UtilityClass.cs UtilityCollection.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation