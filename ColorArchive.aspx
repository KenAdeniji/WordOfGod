<%@ Page Language="C#" debug="true" %>
<%@ import Namespace="System.Drawing" %>
<html>
 <head runat="server" id="htmlHead">
  <title runat="server" id="htmlTitle">Color</title>
  <script runat="server" language="C#">
   protected void Page_Load(Object sender, EventArgs e)
   {
    int alpha = 255, red = 0, green = 255, blue = 0;
    txtRed.ForeColor = Color.FromArgb(alpha, red, green, blue);
    txtRed.ForeColor = Color.Crimson;
    txtRed.ForeColor = ColorTranslator.FromHtml("Blue");
    txtRed.ForeColor = Color.FromName("Blue");
   }
  </script>
 </head>
 <body>
  <form runat="server" id="htmlForm" DefaultFocus="txtRed"> 
   <asp:TextBox ForeColor="Red" Text="Test" id="txtRed" runat="server" />
   <asp:TextBox ForeColor="#ff50ff" Text="Test" id="txtff50ff" runat="server" />
   <br/>
   <asp:TextBox Font-Name="Tahoma" Font-Size="Large" Text="Size Test" id="txtFont" runat="server" />
   <br/>
   <asp:Label runat="server" AccessKey="A" AssociatedControlID="TxtAssociate" Text="Associate:" />
   <asp:TextBox runat="server" ID="txtAssociate" />
  </form>
 </body>
</html>