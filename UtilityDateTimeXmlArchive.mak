all: UtilityDateTimeXml.exe TimeSpanPage.aspx.cs.dll

UtilityDateTimeXml.exe: UtilityDateTimeXml.cs
 csc /define:DEBUG /debug:full /doc:..\WordOfGodDocumentation\UtilityDateTimeXmlDocumentation.xml /main:WordEngineering.UtilityDateTimeXml /out:UtilityDateTimeXml.exe /target:exe UtilityDateTimeXml.cs

TimeSpanPage.aspx.cs.dll: TimeSpanPage.aspx.cs UtilityDateTimeXml.cs
 csc /define:DEBUG /debug:full /doc:..\WordOfGodDocumentation\TimeSpanPageDocumentation.xml /out:bin\TimeSpanPage.aspx.cs.dll /target:library TimeSpanPage.aspx.cs UtilityDateTimeXml.cs 

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation
