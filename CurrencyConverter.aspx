<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CurrencyConverter.aspx.cs" Inherits="CurrencyConverter" %>
<html>
 <head>
  <title>Currency Converter</title>
 </head>
 <body>
  <form method="post" runat="server" defaultfocus="US">
   <input type="text" id="US" runat="server"/>U.S. dollars 
   <select id="Currency" runat="server" />
   <input type="submit" value="OK" id="Convert" runat="server" OnServerClick="Convert_ServerClick" />
   <div style="font-weight: bold" id="Result" runat="server" />
  </form>
 </body>
</html>