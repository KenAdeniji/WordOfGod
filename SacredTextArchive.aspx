<%@ Page 
 Language="C#" 
 debug=true
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadSacredText">
  <title runat="Server" id="TitleSacredText">Sacred Text</title>
   <script language="C#" runat="server">
    public void ImageButton_Command(Object sender, CommandEventArgs e) 
    {
     Response.Write(e.CommandName.ToString() + e.CommandArgument.ToString());
    }
   </script>
 </head>
 <body runat="server" id="BodySacredText">
  <form 
   ID="FormSacredText" 
   runat="server"
   enctype="multipart/form-data"    
   autocomplete="on"
  >
   <asp:SqlDataSource
    ID="SqlDataSourceSacredText"
    Runat="server"
    ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
    SelectCommand="SELECT sequenceOrderId, title, scriptureReference FROM SacredText ORDER BY Title, ScriptureReference"
   />
   
   <asp:Repeater id=RepeaterSacredText runat="server" DataSourceID="SqlDataSourceSacredText">
    <HeaderTemplate>
     <table border=1>
      <tr>
       <td><b>Title</b></td>
       <td><b>Scripture Reference</b></td>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
     <tr>
      <td> <%# DataBinder.Eval(Container.DataItem, "Title") %> </td>
      <td> <%# DataBinder.Eval(Container.DataItem, "ScriptureReference") %> </td>
      <!--
      <td> <asp:imagebutton 
		runat="server" 
		id="btn_close" 
		ImageUrl="close.gif" 
		AlternateText="Close" 
		OnCommand="ImageButton_Command"
		CommandArgument='<%# DataBinder.Eval(Container,"DataItem.SequenceOrderId")%>'
		CommandName="Close"
	   />
      </td>
      -->
     </tr>
    </ItemTemplate>
            
    <FooterTemplate>
     </table>
    </FooterTemplate>
             
   </asp:Repeater>
      		
  </form>
 </body>
</html>
  

