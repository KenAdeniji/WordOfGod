all: ChurchCalendar.exe

ChurchCalendar.exe: ChurchCalendar.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\DocumentationChurchCalendar.xml /main:WordEngineering.ChurchCalendar /out:ChurchCalendar.exe /target:exe ChurchCalendar.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation