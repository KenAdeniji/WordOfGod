<%@ Page 
 Language="C#" 
%>
 
<html>
 <head>
  <title>Change Password</title>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>

     <tr>
     
      <asp:LoginView 
       ID="LoginViewChangePassword" 
       Runat="server" 
       Visible="true"
      >
       <LoggedInTemplate>
        <asp:LoginName 
         ID="LoginNameChangePassword" 
         Runat="server" 
         FormatString="You are logged in as {0}." 
        />
        <br />
       </LoggedInTemplate>
       <AnonymousTemplate>
        You are not logged in
       </AnonymousTemplate>
      </asp:LoginView>
     <br />
     </tr>
     
     <tr>
      <td align="left" colspan="1">
       <asp:ChangePassword
        ID="ChangePassword1" 
        Runat="server" 
        BorderStyle="Solid" 
        BorderWidth="1" 
        CancelDestinationPageUrl="~/Comforter_-_WordEngineeringIndex.xml" 
        DisplayUserName="true"
        ContinueDestinationPageUrl="~/Comforter_-_WordEngineeringIndex.xml" 
       >
        
        <MailDefinition
         BodyFileName="~/ChangePasswordEmail.txt"
         Subject="Thanks for ChangePassword!"
        />
         
       </asp:ChangePassword>
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

<!--
Server Name:        Harvest
Server Port:        25
From:               Administrator
Authentication:     Basic 
Sender's User Name: 
Sender's Password:  
-->