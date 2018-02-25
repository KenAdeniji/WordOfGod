<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.ControlPage" 
%>
 
<html>
 <head>
  <title>Control Web Form</title>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>
     <tr>
      <td align="left">
       <asp:label>Lastname:</asp:label>
      </td>
      <td> 
       <asp:textbox id="TextboxLastName" runat="server" text="" />
      </td>
      <td>  
       <asp:label>Firstname:</asp:label>
      </td>
      <td> 
       <asp:textbox id="TextboxFirstName" runat="server" text="" />
      </td>
     </tr>
     <tr>
      <td> 
       <asp:label>Othername:</asp:label>
      </td>
      <td> 
       <asp:textbox id="TextboxOtherName" runat="server" text="" />
      </td>
      <td> 
       <asp:label>Company:</asp:label>
      </td>
      <td> 
       <asp:textbox id="TextboxCompany" runat="server" text="" />
      </td>
     </tr>
     
     <tr>
      <td colspan=3 />
      <td align=right> 
       <asp:Button 
        id="ButtonSearch" 
        runat="server" 
        value="Search" 
        text="Search" 
        OnServerClick="SearchBtnClick" 
       />
      </td>
     </tr>
     
     <tr>
      <td align="left" colspan="4"><asp:Literal id="LiteralFeedback" runat="server" /></td>
     </tr>    

    </tbody>    
   </table>    
  </form>
 </body>
</html>