<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.GoogleAdvancedSearchPage" 
%>
 
<html>
 <head>
  <title>Google</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr>
      <td align="left"><b>Find Results</b></td>
      <td align="left">with <b>all</b> of the words</td>      
      <td align="left"><asp:TextBox id="TextBoxWithAllOfTheWords" Columns="35" runat="server" /></td>
      <td align="left">
       <asp:DropDownList id="DropDownListMaxResults" runat="server">
        <asp:ListItem Selected="True" Value="10">10 results</asp:ListItem>
        <asp:ListItem Value="20">20 results</asp:ListItem>
        <asp:ListItem Value="30">30 results</asp:ListItem>
        <asp:ListItem Value="50">50 results</asp:ListItem>
        <asp:ListItem Value="100">100 results</asp:ListItem>       
       </asp:DropDownList>
      </td>
      <td align="left"><asp:Button id="ButtonSearch" onclick="ButtonSearch_Click" runat="server" Text="Google Search"/></td>
     </tr>     
     <tr>
      <!-- "Exact phrase" -->
      <td colspan="1" /><td align="left">with the <b>exact phrase</b></td>
      <td align="left"><asp:TextBox id="TextBoxWithTheExactPhrase" Columns="35" runat="server" /></td>
      <td colspan="2" />
     </tr> 
     <tr>
      <!-- OR -->
      <td colspan="1" /><td align="left">with <b>at least one</b> of the words</td>
      <td align="left"><asp:TextBox id="TextBoxWithAtLeastOneOfTheWords" Columns="35" runat="server" /></td>
      <td colspan="2" />
     </tr> 
     <tr>
      <!-- - -->
      <td colspan="1" /><td align="left"><b>without</b> the words</td>
      <td align="left"><asp:TextBox id="TextBoxWithoutTheWords" Columns="35" runat="server" /></td>
      <td colspan="2" />
     </tr> 
     <tr>
      <td colspan="5">
       <Span
        id="HtmlGenericControlSearchResult" 
        runat="server"/>        
      </td>
     </tr> 
     <tr>
      <td align="center" colspan="4"><asp:Literal id="LiteralFeedback" runat="server"/></td>
     </tr>    
    </tbody>    
   
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxWithAllOfTheWords.focus();
</script> 