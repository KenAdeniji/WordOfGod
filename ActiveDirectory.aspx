<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.ActiveDirectoryPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="Head">
  <title runat="Server" id="Title">Active Directory</title>
 </head>
 <body runat="server" id="Body">
  <asp:Panel
   runat="server"
   id="Panel"
  >
   <form 
    ID="Form" 
    runat="server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultfocus="HTMLInputFileSound"
   >
    <table align="center" border="0">
     <tbody>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelActiveDirectoryPath"
         Text="Path:"
         AccessKey="P"
         AssociatedControlId="ActiveDirectoryPath"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="ActiveDirectoryPath"
         TabIndex="1"
        />     
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelDirectorySearcherFilter"
         Text="Searcher Filter:"
         AccessKey="F"
         AssociatedControlId="DirectorySearcherFilter"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="DirectorySearcherFilter"
         TabIndex="2"
        />     
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelActiveDirectoryUser"
         Text="User Name:"
         AccessKey="U"
         AssociatedControlId="ActiveDirectoryUsername"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="ActiveDirectoryUsername"
         TabIndex="3"
        />
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelActiveDirectoryPassword"
         Text="Password:"
         AccessKey="P"
         AssociatedControlId="ActiveDirectoryPassword"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="ActiveDirectoryPassword"
         TabIndex="4"
         TextMode="Password"
        />
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelActiveDirectoryAuthenticationType"
         Text="User:"
         AccessKey="A"
         AssociatedControlId="ActiveDirectoryAuthenticationType"
        />
       </td>
       <td align="left">
        <asp:DropDownList
         runat="Server"
         ID="ActiveDirectoryAuthenticationType"
         TabIndex="5"
        />
       </td>
      </tr>

      <tr align="center">
       <td align="center" colspan="4">
        <asp:Button runat="server" id="ButtonSubmit"  onclick="ButtonSubmit_Click"  Text="Submit" TabIndex="10" />
        <asp:Button runat="server" id="ButtonReset"   onclick="ButtonReset_Click"   Text="Reset"  TabIndex="11" />
       </td>      
      </tr>

     </tbody>
    </table>

    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td>
        <span
         id="SpanActiveDirectory" 
         runat="Server"
        />
       </td>
      </tr>
     </tbody>
    </table>
    
    <table align="center" border="0">
     <tbody> 
      <tr align="center">
       <td align="center">
        <asp:Literal 
         id="LiteralFeedback" 
         runat="server" 
         EnableViewState=False
        />
       </td>
      </tr>
     </tbody>    
    </table>

   </form>
  </asp:Panel>
 </body>
</html>