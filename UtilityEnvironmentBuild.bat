@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE UtilityEnvironment.mak
Del XmlDocumentation /F /S /Q
Rd XmlDocumentation