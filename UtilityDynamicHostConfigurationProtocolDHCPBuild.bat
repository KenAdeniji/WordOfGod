@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE UtilityDynamicHostConfigurationProtocolDHCP.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation