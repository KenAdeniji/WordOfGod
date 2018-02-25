<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.HonedPage" 
 debug="true"
%>

<html>
 <head>
  <title>Honed Web Form</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">
       <asp:DataGrid 
        id="DataGridHoned" 
        runat="server" 
        AutoGenerateColumns="False"
       >
        <Columns>
         <asp:TemplateColumn>
          <ItemTemplate>
           <a href='javascript:<%# WindowOpen("InEveWebForm.aspx?Filename=" + DataBinder.Eval(Container.DataItem, "Name"), "scrollbars=yes,resizable=yes,width=500,height=400") %>'>
            <%# DataBinder.Eval(Container.DataItem, "Name") %>
           </a>
          </ItemTemplate>
         </asp:TemplateColumn>
        </Columns>
       </asp:DataGrid>
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
 document.forms[0].DataGridHoned.focus();
</script>