<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.URIXMLPage" 
%>
 
<html>
 <head>
  <title>URI Web Form</title>
 </head>
 <body>
  <form enctype="multipart/form-data" runat="server">
   <table align="center" border="0">
    <tbody>
     <tr>
      <td align="center" colspan="1">
       URI File:
       <input id="HtmlInputFileURI" 
              type="file" 
              runat="server" />
      </td>
     </tr>
     <tr>
      <td align="center" colspan="1">
       <asp:PlaceHolder id="PlaceHolderURI" runat="server"/>
      </td>
     </tr>
     <tr>
      <td align="center" colspan="1">
       <asp:Xml 
        id="XmlURI" 
        runat="server"
        DocumentSource="Comforter_-_URIChrist.xml"
        TransformSource="Comforter_-_URI.xslt"
       />
      </td>
     </tr>
     <tr align="center">
      <td align="center" colspan="1">
       <asp:Button id="ButtonNew"     onclick="ButtonNew_Click"     runat="server" Text="New"/>
       <asp:Button id="ButtonAdd"     onclick="ButtonAdd_Click"     runat="server" Text="Add"/>
       <asp:Button id="ButtonOpen"    onclick="ButtonOpen_Click"    runat="server" Text="Open"/>       
       <asp:Button id="ButtonSave"    onclick="ButtonSave_Click"    runat="server" Text="Save"/>
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