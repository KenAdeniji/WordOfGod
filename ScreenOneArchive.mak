all: bin\ScreenOne.dll ScreenOne.exe

bin\ScreenOne.dll: ScreenOne.cs
 csc /define:DEBUG /debug:full /out:bin\ScreenOne.dll /target:library ScreenOne.cs

ScreenOne.exe: ScreenOne.cs
 csc /define:DEBUG /debug:full /out:ScreenOne.exe /target:exe ScreenOne.cs