all: KnowledgeBasePage.aspx.cs.dll

KnowledgeBasePage.aspx.cs.dll: KnowledgeBasePage.aspx.cs
 csc /define:DEBUG /debug:full /doc:XmlDocumentation\KnowledgeBasePageDocumentation.xml /out:bin\KnowledgeBasePage.aspx.cs.dll /target:library KnowledgeBasePage.aspx.cs

Clean:
 DEL XmlDocumentation /F /S /Q
 RD XmlDocumentation