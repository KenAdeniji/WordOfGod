<%--	ClientWebBrowserCapabilities.aspx	-->
<%@	Page Language="C#" %>

<script	runat="server">


	void	PrintTableLine(String name,String value)
	{
		Response.Write("<tr><td><b>" + name + "</b></td><td>" + value + "</td></tr>");
	}
			
	void	PrintTableLine( String name, bool yesOrNo )
	{
		string	value = "No";
		
		if ( yesOrNo == true ) 
		{
			value	=	"Yes";
		}
			
		Response.Write("<tr><td><b>" + name + "</b></td><td>" + value + "</td></tr>");
	}
	
	void Page_Load(Object sender, EventArgs e) 
	{
		HttpBrowserCapabilities bc = Request.Browser;
		Response.Write("<p>Browser Capabilities:</p>");
		Response.Write("Type = " + bc.Type + "<br>");
		Response.Write("Name = " + bc.Browser + "<br>");
		Response.Write("Version = " + bc.Version + "<br>");
		Response.Write("Major Version = " + bc.MajorVersion + "<br>");
		Response.Write("Minor Version = " + bc.MinorVersion + "<br>");
		Response.Write("Platform = " + bc.Platform + "<br>");
		Response.Write("Is Beta = " + bc.Beta + "<br>");
		Response.Write("Is Crawler = " + bc.Crawler + "<br>");
		Response.Write("Is AOL = " + bc.AOL + "<br>");
		Response.Write("Is Win16 = " + bc.Win16 + "<br>");
		Response.Write("Is Win32 = " + bc.Win32 + "<br>");
		Response.Write("Supports Frames = " + bc.Frames + "<br>");
		Response.Write("Supports Tables = " + bc.Tables + "<br>");
		Response.Write("Supports Cookies = " + bc.Cookies + "<br>");
		Response.Write("Supports VB Script = " + bc.VBScript + "<br>");
		Response.Write("Supports JavaScript = " + bc.JavaScript + "<br>");
		Response.Write("Supports Java Applets = " + bc.JavaApplets + "<br>");
		Response.Write("Supports ActiveX Controls = " + bc.ActiveXControls + "<br>");
		Response.Write("CDF = " + bc.CDF + "<br>");
	}
	
</script>

<html>
<head>

</head>

<body>	
<table>

<%
	HttpBrowserCapabilities bc = Request.Browser;
	PrintTableLine("Browser Type",			bc.Type);
	PrintTableLine("Browser Name",			bc.Browser);
	PrintTableLine("Browser Version",		bc.Version + " " + bc.MajorVersion + " " + bc.MinorVersion);
	PrintTableLine("Operating System",		bc.Platform);
	PrintTableLine("Beta Version",			bc.Beta);
	PrintTableLine("Web Crawler",			bc.Crawler);
	PrintTableLine("AOL User",			bc.AOL);
	PrintTableLine("Frames Compatible",		bc.Frames);
	PrintTableLine("Tables Compatible",		bc.Tables);
	PrintTableLine("Cookies Compatible",		bc.Cookies);
	PrintTableLine("VB Script Compatible",		bc.VBScript);
	PrintTableLine("Java Script Compatible",	bc.JavaScript);
	PrintTableLine("Java Applets Compatible",	bc.JavaApplets);
	PrintTableLine("ActiveX Compatible",		bc.ActiveXControl);
%>

</table>
</body>
</html>

	
