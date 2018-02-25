<%@ Page Theme="OrangeTheme" %>
<html>
<head runat="server">
    <title>Skinned TextBoxes</title>
</head>
<body>
    <form id="form1" runat="server">

    <asp:TextBox
        id="TextBox1"
        Runat="Server" />

    <br />

    <asp:TextBox
        id="TextBox2"
        SkinID="BlueTextBox"
        Runat="Server" />

    <br />

    <asp:TextBox
        id="TextBox3"
        SkinID="RedTextBox"
        Runat="Server" />

    </form>
</body>
</html>
