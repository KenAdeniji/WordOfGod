all: IHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouPage.aspx.cs.dll

IHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouPage.aspx.cs.dll: IHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouPage.aspx.cs
 csc /define:DEBUG /debug:full /out:bin\IHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouPage.aspx.cs.dll /target:library IHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouPage.aspx.cs