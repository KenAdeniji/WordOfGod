all: UtilityDynamicHostConfigurationProtocolDHCP.exe

UtilityDynamicHostConfigurationProtocolDHCP.exe: UtilityCommandLineArgument.cs UtilityDynamicHostConfigurationProtocolDHCP.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityDynamicHostConfigurationProtocolDHCPDocumentation.xml /main:WordEngineering.UtilityDynamicHostConfigurationProtocolDHCP /out:UtilityDynamicHostConfigurationProtocolDHCP.exe /target:exe UtilityCommandLineArgument.cs UtilityDynamicHostConfigurationProtocolDHCP.cs

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation
