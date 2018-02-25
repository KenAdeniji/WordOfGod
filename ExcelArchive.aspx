<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.ExcelPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadExcel">
  <title runat="Server" id="TitleExcel">Excel</title>
 </head>
 <body runat="server" id="BodyExcel">
  <asp:Panel
   runat="server"
   id="PanelExcel"
  >
   <form 
    ID="FormExcel" 
    runat="server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultbutton="ButtonSave"
    defaultfocus="TextBoxSQL"
   >
    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelSQL"
         Text="SQL:"
         AccessKey="S"
         AssociatedControlId="SQL"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="SQL"
         TabIndex="1"
        />        
       </td>
      </tr>

      <tr align="center">       
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelFilenameExcel"
         Text="Excel:"
         AccessKey="E"
         AssociatedControlId="FilenameExcel"
        />
       </td>
       <td align="left">       
        <asp:FileUpload
         runat="Server"
         ID="FilenameExcel"
         TabIndex="2"
        />        
       </td>
      </tr>
      <tr align="center">
       <td align="center" colspan="2">
        <asp:Button runat="server" id="ButtonOpen"   onclick="ButtonOpen_Click"   Text="Open"   TabIndex="3" />
        <asp:Button runat="server" id="ButtonSave"   onclick="ButtonSave_Click"   Text="Submit" TabIndex="4" />
        <asp:Button runat="server" id="ButtonReset"  onclick="ButtonReset_Click"  Text="Reset"  TabIndex="5" />
       </td>      
      </tr>
     </tbody>
    </table>

    <table align="center" border="0">
     <tbody> 
      <tr align="center">
       <td align="center">
        <asp:GridView
         id="GridViewExcel" 
         runat="server" 
        />
       </td>
      </tr>
     </tbody>    
    </table>

    <table align="center" border="0">
     <tbody> 
      <tr align="center">
       <td align="center">
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
  </asp:Panel>
 </body>
</html>
