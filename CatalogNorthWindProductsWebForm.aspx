<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.CatalogNorthWindProductsPage"
 debug="true"
%>

<html>
 <head>
  <title>CatalogNorthWindProducts Web Form</title>
 </head>
 <body>
  <form runat="server">

   <table align="center" border="0">
    <tbody>
     <tr  align="center">
      <td align="center">
       <asp:GridView 
        id="GridViewCatalogNorthWindProducts" 
        runat="server" 
        AutoGenerateColumns="True"
       />
      </td>
     </tr>     
     <tr>
      <td align="center"><asp:Literal id="LiteralFeedback" runat="server"/></td>
     </tr>
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].GridViewCatalogNorthWindProducts.focus();
</script>