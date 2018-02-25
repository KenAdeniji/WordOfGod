<%@ Page Language="C#" AutoEventWireUp="true" CodeFile="Table.aspx.cs" Inherits="TableSample" %>
<html>
 <title>Table</title>
 <body>
  <form runat="server">
   Rows: <asp:TextBox runat="server" id="TableRows" />
   Columns: <asp:TextBox runat="server" id="TableColumns" />
   <asp:CheckBox runat="server" id="TableBorder" Text="Border" />
   <asp:Button runat="server" id="Create" OnClick="Create_Click" Text="Create" />
   <asp:Table runat="server" id="TblSample" />
  </form>
 </body>
</html>