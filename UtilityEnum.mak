all: UtilityEnum.exe

UtilityEnum.exe: UtilityEnum.cs
 csc /debug:full /main:WordEngineering.UtilityEnum /out:UtilityEnum.exe /target:exe UtilityEnum.cs
