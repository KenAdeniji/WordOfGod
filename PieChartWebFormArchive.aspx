<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.PieChartPage"
 debug="true"
%>

<html>
 <head>
  <title>Pie Chart Web Form</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">SQL Select Statement:</td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxSQLSelectStatement" 
        runat="server"
        text="SELECT Tribe + Leader + Father, Census FROM WordEngineering..CampTroopArmyNumbers2IDEsIDE (NoLock) ORDER BY SequenceOrderId"
        />
      </td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Pie Chart Title:</td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxPieChartTitle" 
        runat="server"         
        text="Camp Troop Army ( Numbers 2 )"
       />
      </td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Pie Chart Width:</td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxPieChartWidth" 
        runat="server"         
        text="300"
       />
      </td>
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
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxSQLSelectStatement.focus();
</script> 