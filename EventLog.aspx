<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.EventLogPage"
%>

<html>
 <head runat="server" id="PageHead">
  <title runat="server" id="PageTitle">Event Log</title>
 </head>
 <body>
  <form 
   runat="server"
   ID="FormEventLog" 
   enctype="multipart/form-data"    
   autocomplete="on"
   defaultbutton="ButtonSubmit"
   defaultfocus="DropDownListLogName"
  >

   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left">
       <asp:Label
        runat="server"
        id="LabelLogName"
        Text="Log:"
        AccessKey="L"
        AssociatedControlId="DropDownListLogName"
       />
      </td>
      <td align="left"> 
       <asp:DropDownList
        runat="Server"
        ID="DropDownListLogName"
        OnPreRender="DropDownListLogName_PreRender"
       />        
      </td>
     </tr>
     <tr align="center">
      <td align="left">
       <asp:Label
        runat="server"       
        id="LabelMachineName"
        Text="Machine:"
        AccessKey="M"
        AssociatedControlId="TextBoxMachineName"
       />
      </td>
      <td align="left">       
       <asp:TextBox
        ID="TextBoxMachineName"
        runat="Server"
        Text="."
       />        
      </td>
     </tr>
    </tbody>
    <tfooter>
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonSubmit"  onclick="ButtonSubmit_Click"     runat="server"   Text="Submit"/>
       <asp:Button id="ButtonReset"   onclick="ButtonReset_Click"      runat="server"   Text="Reset"/>
      </td>      
     </tr>        
    </tfooter>
   </table>

   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td>
       <asp:GridView
        id="GridViewEventLog" 
        runat="server" 
        AllowPaging=True
        AllowSorting=True 
        AutoGenerateColumns=True
        OnPageIndexChanging="GridView_PageIndexChanging"
        OnSorting="GridView_Sorting"
       >
        <pagersettings mode="Numeric"
         position="Bottom"           
         pagebuttoncount="10"
        />
        <pagerstyle backcolor="LightBlue"
         height="30px"
         verticalalign="Bottom"
         horizontalalign="Center"
        />
       </asp:GridView>
      </td>
     </tr>
    </tbody>
   </table>

   <table align="center" border="0">
    <tbody>
     <tr>
      <td align="center" colspan="2">
       <asp:Literal 
        id="LiteralFeedback" 
        runat="server" 
        EnableViewState=False
       />
      </td>
     </tr>    
    </tbody>
   </table>

  </form>
 </body>
</html>
