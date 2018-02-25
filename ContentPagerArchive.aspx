<%@ Page Language="C#" %>
<html>
 <script runat="server">
  void Page_Load(object sender, EventArgs e)
  {
   for (int i=0; i<50; i++)
   {
    TextBox txt = new TextBox();
    txt.Text = i.ToString();
    panelSample.Controls.Add(txt);
    panelSample.Controls.Add(new LiteralControl("<br/>")); 
   }
  }
 </script>
<body>
 <form runat="server">
   <asp:contentpager runat="server" id="pagerPanel" Mode="NextPreviousFirstLast" ControlToPaginate="panelSample" itemsPerPage="9" />
   <asp:panel runat="server" id="PanelSample" borderwidth="1" />
 </form>    
</body>
</html>