@Echo  Off
MD     XmlDocumentation
NMAKE  ChurchCalendar.mak
Del    *.pdb XmlDocumentation /F /S /Q
RD     XmlDocumentation