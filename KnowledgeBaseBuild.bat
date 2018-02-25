@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE KnowledgeBase.mak
DEL XmlDocumentation /F /S /Q
RD XmlDocumentation