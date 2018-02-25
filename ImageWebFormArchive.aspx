<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.ImagePage" 
 debug="true"
%>

<html>
 <head>
  <title>Indexing Service Web Form</title>
 </head>
 <body>
  <form enctype="multipart/form-data" runat="server">
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">
       <img 
        id="HtmlImageURI"
        src="/BibleDatabase/Palestine.gif" 
        runat="server"         
       />
      </td>
     </tr>
     <tr align="center">
      <td align="center" colspan="1">Filename:
       <input 
        id="HtmlInputFileURI" 
        type="file" 
        runat="server" 
       />
      </td>
     </tr>
     <tr align="center">
      <td align="center" colspan="1">
       <asp:Button id="ButtonSubmit"  onclick="ButtonSubmit_Click"     runat="server"   Text="Submit"/>
       <asp:Button id="ButtonReset"   onclick="ButtonReset_Click"      runat="server"   Text="Reset"/>
      </td>      
     </tr>        
     <tr>
      <td align="center" colspan="1"><asp:Literal id="LiteralFeedback" runat="server"/></td>
     </tr>    
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].HtmlInputFileURI.focus();
</script> 