<%@ Page Language="C#" %>
<script runat="server">

void Page_Load() {
    grdUsers.DataSource = Membership.GetAllUsers();
    grdUsers.DataBind();
}

</script>

<html>
<head runat="server">
    <title>Display Members</title>
</head>
<body>
<form runat="Server">

<asp:GridView ID="grdUsers" AutoGenerateColumns="false" Runat="Server">
<Columns>
    <asp:BoundField HeaderText="Username" DataField="Username" />
    <asp:BoundField HeaderText="Email" DataField="Email" />
    <asp:BoundField HeaderText="Last Activity Date" 
     DataField="LastActivityDate" DataFormatString="{0:d}" />
    <asp:CheckBoxField HeaderText="Is Online" DataField="IsOnline" />
</Columns>
</asp:GridView>

</form>
</body>
</html>