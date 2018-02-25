<%@ Page Language="C#" AutoEventWireup="true" Inherits="GreetingCard" CodeFile="GreetingCard.aspx.cs" %>
<html>
 <head runat="server">
  <title runat="server">Greeting Card</title>
 </head>
 <body>
  <form runat="server">
   <div>
    Background color: <asp:DropDownList runat="server" id="BackgroundColor" />
    Font: <asp:DropDownList runat="server" id="FontName" />
    Font Size: <asp:TextBox runat="server" id="FontSize" />
    Border Style: <asp:DropDownList runat="server" id="Border_Style" />
    Greeting: <asp:TextBox runat="server" id="Greeting" TextMode="MultiLine" />
    <asp:Button runat="server" id="Generate" OnClick="Generate_Click" Text="Generate" />
   </div>
   <asp:Panel runat="server" id="pnlCard" style="Z-INDEX:101; LEFT: 313px; POSITION absolute; TOP: 16px" Width="339px" Height="481px" HorizontalAlign="Center">
    <asp:Label runat="server" id="Greet" />
   </asp:Panel>
  </form>
 </body>
</html>