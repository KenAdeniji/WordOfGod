<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.SQLDMOPage" 
%>
 
<html>
 <head>
  <title>SQLDMO</title>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>

     <tr>
      <td align="center" colspan="1">
       SQLDMO Admonish:
       <asp:ListBox 
        id="ListBoxSQLDMOAdmonish" 
        runat="server"
        AutoPostBack="True" 
        OnSelectedIndexChanged="ListBoxSQLDMOAdmonish_SelectedIndexChanged"
        Rows="1"
        SelectionMode="Multiple"
       />
      </td>
     </tr>    

     <tr align="center">
      <td align="center" colspan="1">
       <asp:Button id="ButtonAdmonish"    onclick="ButtonAdmonish_Click"    runat="server"  Text="Submit"/>
       <asp:Button id="ButtonAdminister"  onclick="ButtonAdminister_Click"  runat="server"  Text="Cancel"/>
      </td>      
     </tr>        

     <tr>
      <td align="center" colspan="1"><asp:Literal id="LiteralFeedback" runat="server" /></td>
     </tr>    

    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].ListBoxSQLDMOAdmonish.focus();
</script>