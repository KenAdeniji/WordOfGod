<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.URIMaintenancePage"
%>

<html>
 <head>
  <title>Image</title>
 </head>
 <body>
  <form 
   ID="formURI" 
   runat="server"
   enctype="multipart/form-data"    
   autocomplete="on"
  >
   <asp:DynamicImage runat="server" ID="ImageFileURI" ImageFile="edit.gif" />
  </form>
 </body>
</html>