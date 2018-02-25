<%@ Page language='c#' debug='true' trace='false' %>

<HTML>
  <HEAD>
     <TITLE>ASP.NET Browser Capabilities</TITLE>
  </HEAD>
  <BODY>
     <TABLE width="350" border="0" cellspacing="1" cellpadding="3" bgcolor="#000000">
        <TR bgcolor="#FFFFFF">
           <TD>Beta Version Software</TD>
           <TD><% =Request.Browser.Beta %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Browser Name (User-Agent)</TD>
           <TD><% =Request.Browser.Browser %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Browser Supports VBScript</TD>
           <TD><% =Request.Browser.VBScript %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Browser Version</TD>
           <TD><% =Request.Browser.MajorVersion + "." + Request.Browser.MinorVersion %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Client Browser Type</TD>
           <TD><% =Request.Browser.Type %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Client Browser Version</TD>
           <TD><% =Request.Browser.Version %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Common Language Runtime Version (CLR)</TD>
           <TD><% =Request.Browser.ClrVersion %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Cookies Available</TD>
           <TD><% =Request.Browser.Cookies %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>JavaScript (ECMAScript) Version Supported</TD>
           <TD><% =Request.Browser.EcmaScriptVersion %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Microsoft XML Document Object Model (DOM) Version</TD>
           <TD><% =Request.Browser.MSDomVersion %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Operating System Platform</TD>
           <TD><% =Request.Browser.Platform %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>W3C HTML Document Object Model (DOM) Version</TD>
           <TD><% =Request.Browser.W3CDomVersion %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Running 16-bit Windows?</TD>
           <TD><% =Request.Browser.Win16 %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Running 32-bit Windows?</TD>
           <TD><% =Request.Browser.Win32 %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Supports ActiveX Controls</TD>
           <TD><% =Request.Browser.ActiveXControls %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Supports American Online (AOL)</TD>
           <TD><% =Request.Browser.AOL %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Supports Background Sounds</TD>
           <TD><% =Request.Browser.BackgroundSounds %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Supports Channel Definition Format (CDF)</TD>
           <TD><% =Request.Browser.CDF %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Supports Client-Side Java</TD>
           <TD><% =Request.Browser.JavaApplets %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Support Frames</TD>
           <TD><% =Request.Browser.Frames %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Supports HTML Tables</TD>
           <TD><% =Request.Browser.Tables %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Supports JavaScript (ECMAScript)</TD>
           <TD><% =Request.Browser.JavaScript %></TD>
        </TR>
        <TR bgcolor="#FFFFFF">
           <TD>Web Search Engine (&quot;crawler&quot;)</TD>
           <TD><% =Request.Browser.Crawler %></TD>
        </TR>
<%--
        <TR bgcolor="#FFFFFF">
           <TD>Request.UrlReferrer</TD>
           <TD><% =Request.UrlReferrer %></TD>
        </TR>
--%>
<%--
        <TR bgcolor="#FFFFFF">
           <TD>Request.UrlReferrer</TD>
           <TD><% =Request.ServerVariables["HTTP_REFERER"] %></TD>
        </TR>
--%>
    </TABLE>
  </BODY>
</HTML>