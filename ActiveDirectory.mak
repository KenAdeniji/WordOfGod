all: ActiveDirectoryPage.aspx.cs.dll UtilityActiveDirectory.exe

ActiveDirectoryPage.aspx.cs.dll: ActiveDirectoryPage.aspx.cs
 csc /define:DEBUG /debug:full /out:bin\ActiveDirectoryPage.aspx.cs.dll /target:library ActiveDirectoryPage.aspx.cs UtilityActiveDirectory.cs

UtilityActiveDirectory.exe: UtilityActiveDirectory.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\UtilityActiveDirectoryDocumentation.xml /main:WordEngineering.UtilityActiveDirectory /out:UtilityActiveDirectory.exe /target:exe UtilityActiveDirectory.cs
