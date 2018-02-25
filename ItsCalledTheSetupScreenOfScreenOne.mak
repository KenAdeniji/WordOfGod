all: ItsCalledTheSetupScreenOfScreenOnePage.aspx.cs.dll

ItsCalledTheSetupScreenOfScreenOnePage.aspx.cs.dll: ItsCalledTheSetupScreenOfScreenOnePage.aspx.cs
 csc /define:DEBUG /debug:full /out:bin\ItsCalledTheSetupScreenOfScreenOnePage.aspx.cs.dll /target:library ItsCalledTheSetupScreenOfScreenOnePage.aspx.cs