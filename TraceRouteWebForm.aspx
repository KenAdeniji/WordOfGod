<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.TraceRoutePage" 
%>
 
<html>
 <head>
  <title>TraceRoute Web Form</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr>
      <td align="left" colspan="1">Hostname:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxHostname" runat="server" text="127.0.0.1" /></td>
     </tr>
     <tr>
      <td align="left" colspan="1">Maximum hops:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxMaximumHops" runat="server" /></td>
     </tr>
     <tr>
      <td align="left" colspan="1">Timeout Reply:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxTimeoutReply" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonTraceRoute"  onclick="ButtonTraceRoute_Click"     runat="server" Text="TraceRoute"/>
       <asp:Button id="ButtonReset"       onclick="ButtonReset_Click"          runat="server" Text="Reset"/>
      </td>      
     </tr>        
     <tr>
      <td align="center" colspan="2"><asp:Literal id="LiteralFeedback" runat="server"/></td>
     </tr>    
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxHostnameTarget.focus();
</script> 