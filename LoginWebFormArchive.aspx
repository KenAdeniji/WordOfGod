<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.LoginPage" 
%>

<html>
 <head>
  <title>Login</title>
 </head>
 <body>
  <form 
   enctype="multipart/form-data" 
   runat="server"
   autocomplete="on"
   defaultbutton=""
   defaultfocus="LoginUser"
  >
   <table align="center" border="0">
    <tbody>

     <tr>
      <td align="left" colspan="1">
       <asp:Login 
        ID="LoginUser" 
        Runat="server" 
        CreateUserUrl="~\CreateUserWizardWebForm.aspx"
        HideWhenLoggedIn=true
        OnLoggedIn="OnLoggedIn"
        PasswordRecoveryUrl=true
        VisibleWhenLoggedIn=false
       />
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:LoginStatus 
        ID="LoginStatusUser" 
        Runat="server" 
       />
      </td>
     </tr>
     
     <tr>
      <td align="left" colspan="1">
       <asp:hyperlink 
        id="HyperLinkCreateUserWizard" 
        runat="server" 
        navigateurl="~\CreateUserWizardWebForm.aspx"
       >
       Create User Wizard
       </asp:hyperlink>
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:hyperlink 
        id="HyperLinkChangePassword" 
        runat="server" 
        navigateurl="~\ChangePasswordWebForm.aspx"
       >
       Change Password
       </asp:hyperlink>
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:hyperlink 
        id="HyperLinkPasswordRecovery" 
        runat="server" 
        navigateurl="~\PasswordRecoveryWebForm.aspx"
       >
       Password Recovery
       </asp:hyperlink>
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