all: SanFranciscoGeneralHospitalSFGHTabStripPage.aspx.cs.dll UtilityAccess.exe

SanFranciscoGeneralHospitalSFGHTabStripPage.aspx.cs.dll: SanFranciscoGeneralHospitalSFGHTabStripPage.aspx.cs UtilityDebug.cs UtilityJavaScript.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\SanFranciscoGeneralHospitalSFGHTabStripPage.xml /out:bin\SanFranciscoGeneralHospitalSFGHTabStripPage.aspx.cs.dll /target:library SanFranciscoGeneralHospitalSFGHTabStripPage.aspx.cs UtilityDebug.cs UtilityJavaScript.cs

UtilityAccess.exe: UtilityAccess.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityAccess.xml /main:WordEngineering.UtilityAccess /out:UtilityAccess.exe /target:exe /unsafe UtilityAccess.cs UtilityClass.cs UtilityCollection.cs Contact.cs UtilityDatabase.cs UtilityDebug.cs UtilityDirectory.cs UtilityEventLog.cs UtilityFile.cs UtilityJavaScript.cs UtilityXml.cs
  
Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation