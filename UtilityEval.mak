all: UtilityEval.exe

UtilityEval.exe: UtilityEval.cs C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\Microsoft.JScript.dll
 csc /debug:full /main:WordEngineering.UtilityEval /out:UtilityEval.exe /target:exe UtilityEval.cs /reference:C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\Microsoft.JScript.dll
