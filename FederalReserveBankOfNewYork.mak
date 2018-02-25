all: FederalReserveBankOfNewYork.exe

FederalReserveBankOfNewYork.exe: FederalReserveBankOfNewYork.cs
 csc /debug:full /main:WordEngineering.FederalReserveBankOfNewYork /out:FederalReserveBankOfNewYork.exe /target:exe FederalReserveBankOfNewYork.cs
