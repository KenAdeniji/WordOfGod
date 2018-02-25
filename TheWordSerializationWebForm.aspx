<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.TheWordSerializationPage" 
 debug="true"
%>

<html>
 <head>
  <title>TheWord Serialization Web Form</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">TheWord Id:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxTheWordId" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Dated:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxTheWordDated" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Filename Xml Document:</td>
      <td align="left" colspan="1"><input id="HtmlInputFileFilenameXmlDocument" type="file" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Filename Xml Document Generate:</td>
      <td align="left" colspan="1"><input id="HtmlInputFileFilenameXmlDocumentGenerate" type="file" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Filename Stylesheet:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxFilenameStylesheet" runat="server" /></td>
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
 document.forms[0].TextBoxTheWordId.focus();
</script> 