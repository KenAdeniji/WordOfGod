<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.PrinceNinetySevenPercentPage" 
 debug="true"
%>

<html>
 <head>
  <title>Prince ninety seven percent Web Form</title>
 </head>
 <body>
  <form runat="server">

   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">Dated From:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxDatedFrom" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Dated Until:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxDatedUntil" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Percent From:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxPercentFrom" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Percent Until:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxPercentUntil" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Obliterate:</td>
      <td align="left" colspan="1">
       <asp:ListBox 
        id="ListBoxObliterate" 
        runat="server" 
        Rows="1" 
        SelectedMode="Single" 
       />
      </td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Beans:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxBeans" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonSubmit"  onclick="ButtonSubmit_Click"     runat="server"   Text="Submit"/>
       <asp:Button id="ButtonReset"   onclick="ButtonReset_Click"      runat="server"   Text="Reset"/>
      </td>      
     </tr>        
     <tr>
      <td align="center" colspan="2"><asp:Literal id="LiteralFeedback" runat="server"/></td>
     </tr>

     <tr  align="center">
      <td align="center" colspan="2">
       <asp:GridView 
        id="GridViewPrinceNinetySevenPercent" 
        runat="server" 
        AutoGenerateColumns="False"
       >
        <Columns>

         <asp:BoundField
          DataField="Dated" 
          HeaderText="Dated"  
          SortExpression="Dated"
          DataFormatString="{0:d}"
         />

         <asp:BoundField
          DataField="Percent" 
          HeaderText="Percent" 
          SortExpression="Percent"
         />

        </Columns>
       </asp:GridView>
      </td>
     </tr>     
     
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxDatedFrom.focus();
</script>