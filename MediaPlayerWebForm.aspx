<%@ Page 
 Language="C#" 
 Debug="true"
%>

<!--
<%@ Register 
 Src="SteveOrrNetMediaControl.ascx"
 Tagprefix="UCMedia" 
 Tagname="MediaUserControl" 
%>
-->

<!--
http://msdn2.microsoft.com/library/12yydcke(en-us,vs.80).aspx
Walkthrough: Creating a Basic Control Designer for a Web Server Control
-->
<%@ Register 
 Assembly="SteveOrrNetMediaControl" 
 Namespace="MediaPlayers" 
 TagPrefix="UCMedia" 
%>

<html>

<head runat="server">
 <title runat="server">Media Player</title>
</head>

<body>

 <form 
  runat="server" 
  id="formMediaPlayer"
  enctype="multipart/form-data" 
  autocomplete="on"
 >
  <table cellspacing="0" cellpadding="0" border="0">
   <tr>
    <td valign="top">
     <UCMedia:MediaUserControl 
      runat="server"
      id="WindowsMediaPlayerUserControl"
      Filename = "/Audio/Christian/1NC/1NC_-_Free.mp3"
      autoStart=true
      ButtonsVisible=true
      EnableContextMenu=true
      fullScreen=false 
      Invisible=false
      Volume=100
     />
    </td>
   </tr>
  </table>
 </form>
</body>

</html>