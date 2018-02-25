<%@ Page StyleSheetTheme="OrangeTheme" %>
<html>
<head runat="server">
    <title>Style Sheet Themed TextBox</title>
</head>
<body>
    <form id="form1" runat="server">

    <b>First Name:</b>
    <asp:TextBox
        ID="txtFirstName"
        Runat="Server" />
        
    <br /><br />

    <b>Last Name:</b>
    <asp:TextBox
        ID="txtLastName"
        BackColor="Yellow"
        Runat="Server" />
        
    <br /><br />
    
    <asp:Button
        Text="Submit"
        Runat="Server" />

    </form>
</body>
</html>