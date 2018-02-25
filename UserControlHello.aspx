<%@ Page Language="C#" %>
<%@ Register TagPrefix="ucHello" TagName="UserControlHello" 
    Src="~\UserControlHello.ascx" %>
<html>
<body>
<form runat="server">
    <ucHello:UserControlHello id="UserControlHelloID" 
        runat="server" 
    />
</form>
</body>