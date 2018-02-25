<%@ Page Language="C#" %>
<script runat="server">
    void Page_PreInit(object sender, EventArgs e)
    {
     Page.Theme = Request["dropTheme"];
    }
</script>
<html>
<head runat="server">
    <title>Dynamic Theme</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:DropDownList
        id="dropTheme"
        AutoPostBack="true"
        Runat="Server">
        <asp:ListItem Text="YellowTheme" />
        <asp:ListItem Text="RedTheme" />
    </asp:DropDownList>

    </form>
</body>
</html>