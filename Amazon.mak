all: AmazonSearchService.cs bin\AmazonSearchPage.aspx.cs.dll AmazonSearch.exe

AmazonSearchService.cs: AmazonWebServices.wsdl
 WSDL /language:cs http://soap.amazon.com/schemas3/AmazonWebServices.wsdl

bin\AmazonSearchPage.aspx.cs.dll: AmazonSearch.cs AmazonSearchPage.aspx.cs AmazonSearchService.cs CommandLineArguments.cs
 csc /debug:full /out:bin\AmazonSearchPage.aspx.cs.dll /target:library AmazonSearch.cs AmazonSearchPage.aspx.cs AmazonSearchService.cs CommandLineArguments.cs

AmazonSearch.exe: AmazonSearch.cs AmazonSearchService.cs CommandLineArguments.cs 
 csc /define:DEBUG /main:WordEngineering.AmazonSearch /out:AmazonSearch.exe /target:exe AmazonSearch.cs AmazonSearchService.cs CommandLineArguments.cs

