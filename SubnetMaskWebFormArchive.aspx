<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.SubnetMaskPage" 
%>
 
<html>
 <head>
  <title>Subnet Mask Web Form</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">Timeout Reply:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxTimeoutReply" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonSubnetMask"  onclick="ButtonSubnetMask_Click"     runat="server" Text="SubnetMask"/>
       <asp:Button id="ButtonReset"       onclick="ButtonReset_Click"          runat="server" Text="Reset"/>
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
 document.forms[0].TextBoxTimeoutReply.focus();
</script> 