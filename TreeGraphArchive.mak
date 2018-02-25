all: TreeGraph.exe

TreeGraph.exe: TreeGraph.cs 
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\TreeGraph.xml /reference:skmDataStructures.dll /main:WordEngineering.TreeGraph /out:TreeGraph.exe /target:exe TreeGraph.cs

Clean:
 DEL *.pdb XmlDocumentation /F /S /Q
 RD XmlDocumentation