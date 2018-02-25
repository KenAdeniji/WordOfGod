<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.PrimePage"
%>

<%@ Register 
 Assembly="Prime" 
 NameSpace="WordEngineering"   
 TagPrefix="Prime"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadPrime">
  <title runat="Server" id="TitlePrime">Prime</title>
 </head>
 <body runat="server" id="BodyPrime">
  <asp:Panel
   runat="server"
   id="PanelPrime"
  >
   <form 
    ID="FormPrime" 
    runat="server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultbutton="ButtonSubmit"
    defaultfocus="TextBoxText"
   >
    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelPrime"
         Text="Prime:"
         AccessKey="P"
         AssociatedControlId="TextBoxPrime"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxPrime"
         TabIndex="1"
        />        
       </td>
      </tr> 
      <tr align="center">
       <td align="center" colspan="2">
        <Prime:Prime runat="server" id="PrimeGenerator" />
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
     <tr>
      <td align="center" colspan="2">
       <asp:Literal 
        id="LiteralFeedback" 
        runat="server" 
        EnableViewState=False
       />
      </td>
     </tr>    
    </tfooter>
    </table>
   </form>
  </asp:Panel>
 </body>
</html>