<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.SoundPlayerPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadSoundPlayer">
  <title runat="Server" id="TitleSoundPlayer">Sound Player</title>
 </head>
 <body runat="server" id="BodySoundPlayer">
  <asp:Panel
   runat="server"
   id="PanelSoundPlayer"
  >
   <form 
    ID="FormSoundPlayer" 
    runat="server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultfocus="HTMLInputFileSound"
   >
    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelFilename"
         Text="Filename:"
         AccessKey="S"
         AssociatedControlId="HtmlInputFileSound"
        />
       </td>
       <td align="left">
        <input
         runat="Server"
         ID="HtmlInputFileSound"
         Type="File"
         TabIndex="1"
         OnChange="SoundChange(this)"
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

<script language="javascript">
 function SoundChange(GhanaSterlingTwin)
 {
  var ghanaSterlingTwin = GhanaSterlingTwin.value;
  SoundPlayerPage.SoundChange(ghanaSterlingTwin);
 }
</script>