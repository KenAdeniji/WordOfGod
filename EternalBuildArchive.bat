@ECHO OFF
IF NOT EXIST XmlDocumentation MD XmlDocumentation
NMAKE Eternal.mak
DEL *.pdb XmlDocumentation /F /S /Q
RD XmlDocumentation
REM INSTALLUTIL ServiceEternal.exe /U
REM INSTALLUTIL ServiceEternal.exe /I
REM NET START ServiceEternal