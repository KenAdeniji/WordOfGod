<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.SQLServerManagementObjectsSMOPage"
%>

<html>
 <head>
  <title>SQL Server Management Objects (SMO)</title>
 </head>
 <body>
  <form 
   ID="formSQLServerManagementObjectsSMO" 
   runat="server"
   enctype="multipart/form-data"    
   autocomplete="on"
   defaultbutton="ButtonSubmit"
   defaultfocus="ListBoxServer"
  >
   <table align="center" border="0">
    <tbody>

     <tr align="center">
      <td align="left" colspan="1">SQL Server:</td>
      <td align="left" colspan="1">
       <asp:ListBox
        runat="server"
        id="ListBoxServer"
        Rows=1
        SelectionMode="Multiple"
        OnSelectedIndexChanged="Server_Index_Changed"
        AutoPostBack=True
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">Database:</td>
      <td align="left" colspan="1">
       <asp:ListBox
        runat="server"
        id="ListBoxDatabase"
        Rows=1
        SelectionMode="Multiple"
        OnSelectedIndexChanged="Database_Index_Changed"
        AutoPostBack=True
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">Default:</td>
      <td align="left" colspan="1">
       <asp:ListBox
        runat="server"
        id="ListBoxDefault"
        Rows=1
        SelectionMode="Multiple"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">Rule:</td>
      <td align="left" colspan="1">
       <asp:ListBox
        runat="server"
        id="ListBoxRule"
        Rows=1
        SelectionMode="Multiple"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">Stored Procedure:</td>
      <td align="left" colspan="1">
       <asp:ListBox
        runat="server"
        id="ListBoxStoredProcedure"
        Rows=1
        SelectionMode="Multiple"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">Table:</td>
      <td align="left" colspan="1">
       <asp:ListBox
        runat="server"
        id="ListBoxTable"
        Rows=1
        SelectionMode="Multiple"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">Trigger:</td>
      <td align="left" colspan="1">
       <asp:ListBox
        runat="server"
        id="ListBoxTrigger"
        Rows=1
        SelectionMode="Multiple"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">User Defined Data Type:</td>
      <td align="left" colspan="1">
       <asp:ListBox
        runat="server"
        id="ListBoxUserDefinedDataType"
        Rows=1
        SelectionMode="Multiple"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">User Defined Function:</td>
      <td align="left" colspan="1">
       <asp:ListBox
        runat="server"
        id="ListBoxUserDefinedFunction"
        Rows=1
        SelectionMode="Multiple"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">View:</td>
      <td align="left" colspan="1">
       <asp:ListBox
        runat="server"
        id="ListBoxView"
        Rows=1
        SelectionMode="Multiple"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">Backup Directory:</td>
      <td align="left" colspan="1">
       <asp:TextBox
        runat="server"
        id="TextBoxBackupDirectory"
        Columns="35"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">Maintenance Directory:</td>
      <td align="left" colspan="1">
       <asp:TextBox
        runat="server"
        id="TextBoxMaintenanceDirectory"
        Columns="35"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">Script Directory:</td>
      <td align="left" colspan="1">
       <asp:TextBox
        runat="server"
        id="TextBoxScriptDirectory"
        Columns="35"        
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">SQL Server Login User Name:</td>
      <td align="left" colspan="1">
       <asp:TextBox
        runat="server"
        id="TextBoxSqlServerLoginUserName"
        Columns="35"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="left" colspan="1">SQL Server Password:</td>
      <td align="left" colspan="1">
       <asp:TextBox
        runat="server"
        id="TextBoxSqlServerPassword"
        Columns="35"
        TextMode="password"
       />
      </td>
     </tr>

     <tr align="center">
      <td align="center" colspan="2">
       <asp:CheckBox 
        runat="server"
        id=CheckBoxBackup
        Text="Backup"
       />
       <asp:CheckBox 
        runat="server"
        id=CheckBoxMaintenance
        Text="Maintenance"
       />
       <asp:CheckBox 
        runat="server"
        id=CheckBoxScript
        Text="Script"
       />
       <asp:CheckBox 
        runat="server"
        id=CheckBoxSystem
        Text="System"
       />
       <asp:CheckBox 
        runat="server"
        id=CheckBoxUser
        Text="User"
        Checked=true
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
      <td align="center" colspan="2"><asp:Literal id="LiteralFeedback" runat="server" EnableViewState=false /></td>
     </tr>    
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].ListBoxServer.focus();
</script>