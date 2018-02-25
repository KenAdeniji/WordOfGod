all: EventPage.aspx.cs.dll

EventPage.aspx.cs.dll: EventPage.aspx.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\EventPageDocumentation.xml /out:bin\EventPage.aspx.cs.dll /target:library EventPage.aspx.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation