@ECHO OFF
MD XmlDocumentation
NMAKE SanFranciscoGeneralHospitalSFGH.mak
Del *.pdb XmlDocumentation /F /S /Q
RD XmlDocumentation