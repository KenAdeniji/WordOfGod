<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.SpeechPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadSpeech">
  <title runat="Server" id="TitleSpeech">Speech</title>
 </head>
 <body runat="server" id="BodySpeech">
  <asp:Panel
   runat="server"
   id="PanelSpeech"
  >
   <form 
    ID="FormSpeech" 
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
         id="LabelText"
         Text="Text:"
         AccessKey="F"
         AssociatedControlId="TextBoxText"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxText"
         Columns="50"
         TabIndex="1"
         TextMode="MultiLine"
         Rows="5"
        />        
       </td>
      </tr> 
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelSource"
         Text="Source:"
         AccessKey="S"
         AssociatedControlId="FileUploadSource"
        />
       </td>
       <td align="left">
        <asp:FileUpload
         runat="Server"
         ID="FileUploadSource"
        />        
       </td>
      </tr> 
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelAudio"
         Text="Audio:"
         AccessKey="A"
         AssociatedControlId="FileUploadAudio"
        />
       </td>
       <td align="left">
        <asp:FileUpload
         runat="Server"
         ID="FileUploadAudio"
        />        
       </td>
      </tr> 
      <tr align="center">
       <td align="center" colspan="2">
        <asp:CheckBox 
         runat="server"
         id=CheckBoxXml
         Text="Xml"
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