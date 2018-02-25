@Echo  Off
MD     XmlDocumentation
NMAKE  TheWordAlphabetSequence.mak
REM    Del   *.pdb XmlDocumentation /F /S /Q
RD     XmlDocumentation