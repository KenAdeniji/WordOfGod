all: AccountChart.exe AccountChartPage.aspx.cs.dll

AccountChart.exe: AccountChart.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\AccountChart.xml /main:WordEngineering.AccountChart /out:AccountChart.exe /target:exe AccountChart.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilitySerialize.cs UtilityXml.cs

AccountChartPage.aspx.cs.dll: AccountChartPage.aspx.cs AccountChart.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityImpersonate.cs UtilityJavaScript.cs UtilityProcess.cs UtilityProperty.cs UtilityXml.cs
 csc /doc:XmlDocumentation\AccountChartWebFormDocumentation.xml /out:bin\AccountChartPage.aspx.cs.dll /target:library AccountChartPage.aspx.cs AccountChart.cs UtilityClass.cs UtilityCollection.cs UtilityCommandLineArgument.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityImpersonate.cs UtilityJavaScript.cs UtilityProcess.cs UtilityProperty.cs UtilityXml.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation