<%@ Page 
    CodeFile="AmazonSearchPage.aspx.cs"
    Inherits="WordEngineering.AmazonSearchPage"
    Language="C#"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>Search:</td>
                <td><asp:TextBox ID="keyword" runat="server" columns="25" /></td>
            </tr>
            <tr>
                <td>Locale:</td>
                <td><asp:DropDownList ID="locale" runat="server"/></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
