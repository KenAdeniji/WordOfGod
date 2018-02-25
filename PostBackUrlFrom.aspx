<%@ Page Language="C#" AutoEventWireup="true" %>
<html>
 <head runat="server">
  <title runat="server">PostBackUrlFrom</title>
 </head>
 <body>
  <form runat="server">
   <asp:TextBox runat="server" id="PostBackUrlFrom" />
   <asp:Button runat="server" id="PostBackUrl" Text="PostBackUrl" PostBackUrl="PostBackUrlTo.aspx" />
  </form>
 </body>
</html>