<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.MailSendPage" 
 debug="true"
%>

<html>
 <head>
  <title>MailSend Web Form</title>
 </head>
 <body>
  <form enctype="multipart/form-data" runat="server">
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">Smtp Server:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxSmtpServer" runat="server" text="localhost" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Smtp Port:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxSmtpPort" runat="server" text="25" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">From:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxFrom" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">To:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxTo" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Cc:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxCc" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Bcc:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxBcc" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Subject:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxSubject" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Body:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxBody" runat="server" TextMode="MultiLine" Columns="50" Rows="5" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Attachment:</td>
      <td align="left" colspan="1"><input id="HtmlInputFileAttachment" type="file" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">User State:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxUserState" runat="server" /></td>
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
 document.forms[0].TextBoxSmtpServer.focus();
</script> 