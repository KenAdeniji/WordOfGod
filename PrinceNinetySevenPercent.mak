all: PrinceNinetySevenPercent.exe PrinceNinetySevenPercentPage.aspx.cs.dll

PrinceNinetySevenPercent.exe: PrinceNinetySevenPercent.cs UtilityCommandLineArgument.cs UtilityDebug.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\PrinceNinetySevenPercent.xml /main:WordEngineering.PrinceNinetySevenPercent /out:PrinceNinetySevenPercent.exe /target:exe /unsafe PrinceNinetySevenPercent.cs UtilityCommandLineArgument.cs UtilityDebug.cs

PrinceNinetySevenPercentPage.aspx.cs.dll: PrinceNinetySevenPercentPage.aspx.cs PrinceNinetySevenPercent.cs UtilityCommandLineArgument.cs UtilityDebug.cs UtilityJavaScript.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\PrinceNinetySevenPercentPageDocumentation.xml /out:bin\PrinceNinetySevenPercentPage.aspx.cs.dll /target:library /unsafe PrinceNinetySevenPercentPage.aspx.cs PrinceNinetySevenPercent.cs UtilityCommandLineArgument.cs UtilityDebug.cs UtilityJavaScript.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation