<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.FaxPage" 
 debug="true"
%>

<html>
 <head>
  <title>Fax Web Form</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">Fax Server Name:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxFaxServerName" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Fax Number:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxFaxNumber" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Filename:</td>
      <td align="left" colspan="1">
       <input 
        id="HtmlInputFileFaxDocument" 
        type="file" 
        runat="server" 
       />
      </td>
     </tr>      
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonSubmit"  onclick="ButtonSubmit_Click"     runat="server"   Text="Submit"/>
       <asp:Button id="ButtonReset"   onclick="ButtonReset_Click"      runat="server"   Text="Reset"/>
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
 document.forms[0].TextBoxFaxServerName.focus();
</script>