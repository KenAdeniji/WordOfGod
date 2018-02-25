<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.PingPage" 
%>
 
<html>
 <head>
  <title>Ping Web Form</title>
 </head>
 <body>
  <form enctype="multipart/form-data" runat="server">
   <table align="center" border="0">
    <tbody>
     <tr>
      <td align="left" colspan="1">
       Host:
      </td>
      <td align="left" colspan="1">
       <asp:TextBox id="TextBoxPingHost" runat="server" Text="127.0.0.1" />
      </td>
     </tr>
     <tr>
      <td align="left" colspan="1">
       Time (milli-seconds):
      </td>
      <td align="left" colspan="1">
       <asp:Label id="LabelPingTime" runat="server" />
      </td>
     </tr>
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonPing"  onclick="ButtonPing_Click"   runat="server" Text="Ping"/>
       <asp:Button id="ButtonReset" onclick="ButtonReset_Click"  runat="server" Text="Reset"/>
      </td>      
     </tr>        
     <tr>
      <td align="center" colspan="2"><asp:Literal id="LiteralFeedback" runat="server"/></td>
     </tr>    
    </tbody>    
   
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxPingHost.focus();
</script> 