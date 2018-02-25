all: ProfilePage.aspx.cs.dll 

ProfilePage.aspx.cs.dll: ProfilePage.aspx.cs
 csc /define:DEBUG /debug:full /out:bin\ProfilePage.aspx.cs.dll /target:library ProfilePage.aspx.cs

Clean:
