<%@ Page 
 Language="C#"
 Inherits="WordEngineering.CreateUserWizardPage" 
 Debug="True" 
%>
 
<html>
 <head>
  <title>Create User Wizard</title>
 </head>
 <body>
  <form 
   enctype="multipart/form-data" 
   runat="server"
   autocomplete="on"
   defaultbutton=""
   defaultfocus="CreateUserWizardMembership"
  >
   <table align="center" border="0">
    <tbody>

     <tr>
      <td align="left" colspan="1">
       <asp:CreateUserWizard 
        ID="CreateUserWizardMembership" 
        Runat="server" 
        OnSendingMail="CreateUserWizard_SendingMail"
        OnSendMailError="CreateUserWizard_SendMailError"
       > 
        <MailDefinition 
         BodyFileName="~\RegistrationEmail.html"
         Subject="Create User Wizard"
        />
       </asp:CreateUserWizard>
      </td>
     </tr>

     <tr>
      <td align="left" colspan="2"><asp:Literal id="LiteralFeedback" runat="server" /></td>
     </tr>    

    </tbody>    
   </table>    
  </form>
 </body>
</html>