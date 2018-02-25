all: KarlSeguinPage.aspx.cs.dll

KarlSeguinPage.aspx.cs.dll: KarlSeguinPage.aspx.cs
 csc /define:DEBUG /debug:full /out:bin\KarlSeguinPage.aspx.cs.dll /target:library KarlSeguinPage.aspx.cs