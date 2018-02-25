<%@ Page Language="C#" %>
<%@ Register TagPrefix="ucSpinner" TagName="UserControlSpinner" 
    Src="~\UserControlSpinner.ascx" %>
<html>
<body>
<form runat="server">
    <ucSpinner:UserControlSpinner id="UserControlSpinnerID" 
        runat="server" MinValue=0 MaxValue=10  
    />
</form>
</body>