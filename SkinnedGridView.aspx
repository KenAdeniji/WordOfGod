<%@ Page Theme="OrangeTheme" %>
<html>
<head runat="server">
    <title>Skinned GridView</title>
</head>
<body>
    <form id="form1" runat="server">

    <asp:GridView
        ID="GridView1"
        DataSourceID="ProductSource"
        Runat="Server" />
    
    <asp:SqlDataSource
        ID="ProductSource"
        ConnectionString="Server=localhost;Trusted_Connection=true;Database=Northwind"
        SelectCommand="Select ProductName,UnitPrice,UnitsInStock FROM Products"
        Runat="Server" />
        
    </form>
</body>
</html>