all: bin\EventLogPage.aspx.cs.dll UtilityEventLog.exe

bin\EventLogPage.aspx.cs.dll: EventLogPage.aspx.cs UtilityWebControl.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\EventLogPageDocumentation.xml /out:bin\EventLogPage.aspx.cs.dll /target:library EventLogPage.aspx.cs UtilityWebControl.cs
 
UtilityEventLog.exe: UtilityEventLog.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityEventLogDocumentation.xml /main:WordEngineering.UtilityEventLog /out:UtilityEventLog.exe /target:exe UtilityEventLog.cs

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation 