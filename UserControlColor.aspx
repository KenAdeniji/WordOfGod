<%@ Page Language="C#" %>
<%@ Register TagPrefix="ucColor" TagName="UserControlColor" 
    Src="~\UserControlColor.ascx" %>
<html>
<body>
<form runat="server">
    <ucColor:UserControlColor id="UserControlColorID" 
        runat="server" 
    />
</form>
</body>