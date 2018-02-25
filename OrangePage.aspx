<%@ Page Theme="OrangeTheme" %>
<html>
<head runat="server">
    <title>Orange Page</title>
</head>
<body>
    <form id="form1" runat="server">

    Enter your name:
    <br />
    <asp:TextBox
        ID="txtName" 
        Runat="Server" />

    <br /><br />

    <asp:Button
        ID="btnSubmit" 
        Text="Submit Name" 
        Runat="Server" />
    
    </form>
</body>
</html>