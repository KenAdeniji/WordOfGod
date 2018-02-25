all: PeterABromberg.exe

PeterABromberg.exe: SQLAdminTypeLib.dll PeterABromberg.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\PeterABrombergDocumentation.xml /reference:SQLAdmin.dll /out:PeterABromberg.exe /target:winexe PeterABromberg.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation