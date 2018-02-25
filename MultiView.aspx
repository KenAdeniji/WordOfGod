<%@ Page Language="C#" %>
<script language="C#" runat="server">
 public void Page_Load(Object sender, EventArgs e)
 {
  //Table.ActiveViewIndex = 0;
 }
 public void ChoiceSelected(Object sender, EventArgs e)
 {
  Table.ActiveViewIndex = Choice.SelectedIndex;
 }
</script>   

<form runat="server">
<asp:MultiView runat="server" id="Table" ActiveViewIndex=0>
 <asp:View runat="server" id="employee">
  <asp:Label>Employee</asp:Label>
 </asp:View>
 <asp:View runat="server" id="product">
  <asp:Label>Product</asp:Label>
 </asp:View>
 <asp:View runat="server" id="customer">
  <asp:Label>Customer</asp:Label> 
 </asp:View>
</asp:MultiView>

<asp:ListBox runat="server" id="Choice" OnSelectedIndexChanged="ChoiceSelected" autopostback="True"> 
 <asp:ListItem Selected value=0>Employee</asp:ListItem>
 <asp:ListItem value=1>Product</asp:ListItem>
 <asp:ListItem value=2>Customer</asp:ListItem> 
</asp:ListBox>
</form>