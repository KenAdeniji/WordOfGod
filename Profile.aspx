<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.ProfilePage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadProfile">
  <title runat="Server" id="TitleProfile">Profile</title>
 </head>
 <body runat="server" id="BodyProfile">
  <asp:Panel
   runat="server"
   id="PanelProfile"
  >
   <form 
    ID="FormProfile" 
    runat="server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultbutton="ButtonSubmit"
    defaultfocus="TextBoxFirstName"
   >
    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelFirstName"
         Text="First Name:"
         AccessKey="F"
         AssociatedControlId="TextBoxFirstName"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxFirstName"
         TabIndex="1"
        />        
       </td>
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelLastName"
         Text="Last Name:"
         AccessKey="L"
         AssociatedControlId="TextBoxLastName"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxLastName"
         TabIndex="2"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="center" colspan="4">
        <asp:Button runat="server" id="ButtonSubmit"  onclick="ButtonSubmit_Click"  Text="Submit" TabIndex="17" />
        <asp:Button runat="server" id="ButtonReset"   onclick="ButtonReset_Click"   Text="Reset"  TabIndex="18" />
       </td>      
      </tr>
     </tbody>
    </table>
   </form>
  </asp:Panel>
 </body>
</html>