<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.SimpleMailTransferProtocolSNMPPage" 
%>
 
<html>
 <head>
  <title>Simple Mail Transfer Protocol (SNMP)</title>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>

     <tr>
      <td align="center" colspan="1">
       News Server:
       <asp:TextBox id="TextBoxNewsServer" runat="server" text="news.microsoft.com" />
      </td>
     </tr>    

     <tr>
      <td align="center" colspan="1">
       News Group: 
       <asp:TextBox id="TextBoxNewsGroup" runat="server" text="microsoft.public.access" />
      </td>
     </tr>    

     <tr align="center">
      <td align="center" colspan="1">
       <asp:Button id="ButtonNewsFeed" onclick="ButtonNewsFeed_Click" runat="server" Text="NewsFeed"/>
       <asp:Button id="ButtonCancel" onclick="ButtonCancel_Click" runat="server" Text="Cancel"/>
      </td>      
     </tr>        

     <tr>
      <td align="center" colspan="1"><asp:Literal id="LiteralFeedback" runat="server" /></td>
     </tr>    

    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxNewsServer.focus();
</script>