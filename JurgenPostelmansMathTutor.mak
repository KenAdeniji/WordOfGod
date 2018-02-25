all: JurgenPostelmansMathTutor.dll

JurgenPostelmansMathTutor.dll: JurgenPostelmansMathTutor.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\JurgenPostelmansMathTutor.xml /out:JurgenPostelmansMathTutor.dll /target:library JurgenPostelmansMathTutor.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation