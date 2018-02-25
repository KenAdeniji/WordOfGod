all: bin\Prime.dll bin\PrimePage.aspx.cs.dll

bin\Prime.dll: Prime.cs Sieve.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\PrimeDocumentation.xml /out:bin\Prime.dll /target:library Sieve.cs Prime.cs 

bin\PrimePage.aspx.cs.dll: PrimePage.aspx.cs bin\Prime.dll
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\PrimePageDocumentation.xml /out:bin\PrimePage.aspx.cs.dll /reference:bin\Prime.dll /target:library PrimePage.aspx.cs 

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation