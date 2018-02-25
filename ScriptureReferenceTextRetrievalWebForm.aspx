<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.ScriptureReferenceTextRetrievalPage" 
%>

<html>
 <head>
  <title>Comforter,org WordEngineering Scripture Reference Text Retrieval</title>
 </head>
 <body style="FONT-FAMILY: arial">
  <form runat="server">
   <table align="center" border="1">
    <theader>
     <tr><th align="center" colspan="2">Scripture Reference Text Retrieval</th></tr>
    </theader>
    <tbody>
     <tr>
      <td><asp:Label id="LabelScriptureReferenceTextRetrieval" runat="server">Scripture Reference:</asp:Label></td>
      <td><asp:TextBox id="TextBoxScriptureReferenceTextRetrieval" runat="server"></asp:TextBox></td>     
     </tr>
     <tr>
      <td colspan="2"><asp:Label id="LabelExceptionMessage" runat="server"/></td>
     </tr>
     <tr>
      <td align="center" colspan="2"><asp:Button id="ButtonQuery" onclick="ApplyFilter_Click" runat="server" Text="Query"/></td>
     </tr>     
     <tr><th colspan="2">Scripture Reference Crosswalk URI</th></tr>
     <tr>
      <td><asp:Label id="LabelScriptureReferenceCrosswalkURIHtml" runat="server">HTML:</asp:Label></td>
      <td><asp:TextBox id="TextBoxScriptureReferenceCrosswalkURIHtml" runat="server"></asp:TextBox></td>     
     </tr>     
     <tr>
      <td><asp:Label id="LabelScriptureReferenceCrosswalkURIXml" runat="server">XML:</asp:Label></td>
      <td><asp:TextBox id="TextBoxScriptureReferenceCrosswalkURIXml" runat="server"></asp:TextBox></td>     
     </tr>
     <tr>
      <td colspan="2">
       <asp:Repeater id="RepeaterScriptureReferenceTextRetrieval" runat=server>
        <HeaderTemplate>
         <table border=1>
        </HeaderTemplate>
        <ItemTemplate>
         <tr>
          <td> 
           <%# DataBinder.Eval(Container.DataItem, "ScriptureReference") %> 
           <br/>
           <%# DataBinder.Eval(Container.DataItem, "ScriptureText") %> 
          </td>
         </tr>
        </ItemTemplate>
        <FooterTemplate>
         </table>
        </FooterTemplate>
       </asp:Repeater>
      </td>
     </tr> 
    </tbody>    
   </table>    
  </form>
 </body>
</html>