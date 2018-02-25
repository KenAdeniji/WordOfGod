all: PieChartPage.aspx.cs.dll

PieChartPage.aspx.cs.dll: PieChartPage.aspx.cs PieChart.cs UtilityDatabase.cs UtilityClass.cs UtilityCollection.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs UtilityJavaScript.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\PieChartPageDocumentation.xml /out:bin\PieChartPage.aspx.cs.dll /target:library PieChartPage.aspx.cs PieChart.cs UtilityDatabase.cs UtilityClass.cs UtilityCollection.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityXml.cs UtilityJavaScript.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation