<%@ Page 
 Language="C#" 
%>
 
<html>
 <head>
  <title>Login</title>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>

     <tr>
      <td align="left" colspan="1">
       <asp:ChangePassword
        ID="ChangePasswordLogin" 
        Runat="server" 
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