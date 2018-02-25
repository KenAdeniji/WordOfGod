<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.ContactBrowsePage" 
%>
 
<html>
 <head>
  <title>Contact Browse</title>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>
    
     <tr>
      <td align="left" colspan="4">
       <asp:Repeater id="RepeaterContact" runat="server">
        <ItemTemplate>
         <asp:HyperLink 
          id=HyperLink1 
          Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' 
          NavigateUrl='<%# "ContactDetailWebForm.aspx?SequenceOrderId=" + HttpUtility.UrlEncode(DataBinder.Eval(Container.DataItem,"SequenceOrderId").ToString()) %>' 
          runat="server" />
         <br/>
        </ItemTemplate>
       </asp:Repeater>
      </td>
     </tr>
     
     <tr>
      <td align="left" colspan="4"><asp:Literal id="LiteralFeedback" runat="server" /></td>
     </tr>    

    </tbody>    
   </table>    
  </form>
 </body>
</html>