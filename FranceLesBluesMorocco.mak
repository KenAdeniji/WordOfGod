all: ContactBrowsePage.aspx.cs.dll ContactDetailPage.aspx.cs.dll ContactDetailsViewPage.aspx.cs.dll ContactEditPage.aspx.cs.dll ContactGridViewPage.aspx.cs.dll ContactGridViewObjectDataSourcePage.aspx.cs.dll ContactGridViewObjectDataSourceTypeName.cs ContactHeadIconPage.aspx.cs.dll UtilityContact.exe

UtilityContact.exe: UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityContact.xml /main:WordEngineering.UtilityContact /out:UtilityContact.exe /target:exe /unsafe UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs

ContactBrowsePage.aspx.cs.dll: ContactBrowsePage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ContactBrowsePageDocumentation.xml /out:bin\ContactBrowsePage.aspx.cs.dll /target:library /unsafe ContactBrowsePage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs

ContactDetailPage.aspx.cs.dll: ContactDetailPage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ContactDetailPageDocumentation.xml /out:bin\ContactDetailPage.aspx.cs.dll /target:library /unsafe ContactDetailPage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs

ContactDetailsViewPage.aspx.cs.dll: ContactDetailsViewPage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ContactDetailsViewPageDocumentation.xml /out:bin\ContactDetailsViewPage.aspx.cs.dll /target:library /unsafe ContactDetailsViewPage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs

ContactEditPage.aspx.cs.dll: ContactEditPage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ContactEditPageDocumentation.xml /out:bin\ContactEditPage.aspx.cs.dll /target:library /unsafe ContactEditPage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs

ContactGridViewPage.aspx.cs.dll: ContactGridViewPage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ContactGridViewPageDocumentation.xml /out:bin\ContactGridViewPage.aspx.cs.dll /target:library /unsafe ContactGridViewPage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs

ContactGridViewObjectDataSourcePage.aspx.cs.dll: ContactGridViewObjectDataSourcePage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs
  csc /define:DEBUG /debug:full /doc:XmlDocumentation\ContactGridViewObjectDataSourcePageDocumentation.xml /out:bin\ContactGridViewObjectDataSourcePage.aspx.cs.dll /target:library /unsafe ContactGridViewObjectDataSourcePage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs  UtilityXml.cs
  
ContactHeadIconPage.aspx.cs.dll: ContactHeadIconPage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ContactHeadIconPageDocumentation.xml /out:bin\ContactHeadIconPage.aspx.cs.dll /target:library /unsafe ContactHeadIconPage.aspx.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs

ContactGridViewObjectDataSourceTypeName: ContactGridViewObjectDataSourceTypeName.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs
  csc /define:DEBUG /debug:full /doc:XmlDocumentation\ContactGridViewObjectDataSourceTypeName.cs.xml /out:bin\ContactGridViewObjectDataSourceTypeName.cs.dll /target:library ContactGridViewObjectDataSourceTypeName.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs
  
Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation