all: UtilityEnvironment.exe

UtilityEnvironment.exe: UtilityEnvironment.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityEnvironmentDocumentation.xml /out:UtilityEnvironment.exe /target:exe UtilityEnvironment.cs

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation