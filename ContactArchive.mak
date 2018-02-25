all: ContactMaintenancePage.aspx.cs.dll

ContactMaintenancePage.aspx.cs.dll: Contact.cs ContactMaintenancePage.aspx.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityContact.cs UtilityDirectory.cs UtilityDatabase.cs UtilityDebug.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityImage.cs UtilityImpersonate.cs UtilityMail.cs UtilityResponse.cs UtilityXml.cs bin\UtilityPostback.dll bin\UtilityWebControl.dll
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\ContactMaintenancePageDocumentation.xml /out:bin\ContactMaintenancePage.aspx.cs.dll /reference:bin\UtilityPostback.dll /reference:bin\UtilityWebControl.dll /target:library Contact.cs ContactMaintenancePage.aspx.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityContact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityException.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityImage.cs UtilityImpersonate.cs UtilityMail.cs UtilityResponse.cs UtilityTcpIp.cs UtilityXml.cs

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation