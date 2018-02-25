<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.TheWordPage" 
%>
 
<html>
 <head>
  <title>The Word</title>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>
    
     <tr>
      <td align="left" colspan="4">
       <asp:PlaceHolder id="PlaceHolderGridView" runat="server"/>
      </td>
     </tr>
     <tr>
      <td align="center" colspan="4">
       <asp:Button id="ButtonNew"     runat="server" text="New"       OnClick="ButtonNew_Click"     AccessKey="N"  />
       <asp:Button id="ButtonOpen"    runat="server" text="Open"      OnClick="ButtonOpen_Click"    AccessKey="O"  />
       <asp:Button id="ButtonSave"    runat="server" text="Save"      OnClick="ButtonSave_Click"    AccessKey="S"  />
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