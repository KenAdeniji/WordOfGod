all: UtilityEchoPort7Client.exe UtilityEchoPort7Server.exe

UtilityEchoPort7Client.exe: UtilityEchoPort7Client.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityEchoPort7ClientDocumentation.xml /main:WordEngineering.UtilityEchoPort7Client /out:UtilityEchoPort7Client.exe /target:exe UtilityEchoPort7Client.cs

UtilityEchoPort7Server.exe: UtilityEchoPort7Server.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityEchoPort7ServerDocumentation.xml /main:WordEngineering.UtilityEchoPort7Server /out:UtilityEchoPort7Server.exe /target:exe UtilityEchoPort7Server.cs

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation