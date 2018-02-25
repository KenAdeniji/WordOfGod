<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.FileUploadImagePage"
 debug="true"
%>

<html>
 <head>
  <title>File Upload Image Web Form</title>
 </head>
 <body>
  <form 
   enctype="multipart/form-data" 
   runat="server"
   autocomplete="on"
   defaultbutton="ButtonSubmit"
   defaultfocus="HtmlInputFileSource"
  >
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">Filename Upload Source:</td>
      <td align="left" colspan="1"><input id="HtmlInputFileSource" type="file" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonSubmit"  onclick="ButtonSubmit_Click"     runat="server"   Text="Submit"   ValidationGroup="ValidationGroupFile" />
       <asp:Button id="ButtonReset"   onclick="ButtonReset_Click"      runat="server"   Text="Reset"/>
      </td>      
     </tr>        
     <tr>
      <td align="center" colspan="2"><asp:Literal id="LiteralFeedback" runat="server"/></td>
     </tr>

     <asp:RequiredFieldValidator 
      ID="RequiredFieldValidatorFilenameSource"
      Runat="server" 
      ControlToValidate="HtmlInputFileSource"
      ErrorMessage="RequiredFieldValidator"
      SetFocusOnError="True"
      ValidationGroup="ValidationGroupFile"
     >
      Filename Upload Source required.
     </asp:RequiredFieldValidator>

    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].HtmlInputFileSource.focus();
</script>