<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.TimeSpanPage" 
%>

<html>
 <head>
  <title>Comforter.org WordEngineering Time Span</title>
 </head>
 <body style="FONT-FAMILY: arial">
  <form runat="server">
   <table align="center" border="1">
    <theader>
     <tr><th align="center" colspan="2">Time Span</th></tr>
    </theader>
    <tbody>
     <tr>
      <td><asp:Label id="LabelDateTimeStart" runat="server">DateTime Start:</asp:Label></td>
      <td><asp:TextBox id="TextBoxDateTimeStart" runat="server"></asp:TextBox></td>     
     </tr>
     <tr>
      <td><asp:Label id="LabelDateTimeEnd" runat="server">DateTime End:</asp:Label></td>
      <td><asp:TextBox id="TextBoxDateTimeEnd" runat="server"></asp:TextBox></td>     
     </tr>
     <tr>
      <td align="center" colspan="2"><asp:Label id="LabelExceptionMessage" runat="server"/></td>
     </tr>
     <tr>
      <td align="center" colspan="2"><asp:Button id="ButtonQuery" onclick="Query_Click" runat="server" Text="Time Span"/></td>
     </tr>     
     <tr><td align="center" colspan="2"><asp:Label id="LabelTimeSpanStartEnd" runat="server"/></td></tr>
    </tbody>    
   </table>    
  </form>
 </body>
</html>