all: bin\SimpleComponent.dll bin\SimpleComponent.tlb

bin\SimpleComponent.dll: SimpleComponent.cs
 csc /keyfile:WordEngineering.snk /out:bin\SimpleComponent.dll /target:library SimpleComponent.cs
 gacutil -i SimpleComponent.dll
 
bin\SimpleComponent.tlb: bin\SimpleComponent.dll 
 regasm /tlb:bin\SimpleComponent.tlb bin\SimpleComponent.dll