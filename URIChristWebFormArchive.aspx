<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.URIChristPage" 
%>
 
<html>
 <head>
  <title>URIChrist Web Form</title>
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
      <!-- 
       ms-help://MS.NETFrameworkSDKv1.1/cpgenref/html/cpcondatagridwebservercontrol.htm 
       http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpref/html/frlrfsystemwindowsformsdatagridclassdatasourcetopic.asp
      -->
      <asp:DataGrid 
           id="DataGridURI"
           runat="server"
           AllowPaging="True"
           AllowSorting="True"           
           AutoGenerateColumns="true"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="1"
           OnCancelCommand="DataGridURI_Cancel"
           OnDeleteCommand="DataGridURI_Delete"
           OnEditCommand="DataGridURI_Edit"
           OnItemCommand="DataGridURI_Command"
           OnUpdateCommand="DataGridURI_Update"
           >
           <HeaderStyle BackColor="#00aaaa" />
           
           <Columns>
            <asp:EditCommandColumn
                 ButtonType="LinkButton"
                 CancelText="Cancel"
                 EditText="Edit"
                 SortExpression="DataSourceFieldToSortBy"
                 UpdateText="Update"
                 Visible="True"/>
            <asp:ButtonColumn Text="Delete"
                 CommandName="Delete"/>
           </Columns>
       </asp:DataGrid>
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