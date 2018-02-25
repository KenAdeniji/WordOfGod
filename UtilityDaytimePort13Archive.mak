all: UtilityDaytimePort13.exe

UtilityDaytimePort13.exe: UtilityDaytimePort13.cs bin\ScreenOne.dll
 csc /define:DEBUG /debug:full /out:UtilityDaytimePort13.exe /reference:bin\ScreenOne.dll /target:exe UtilityDaytimePort13.cs