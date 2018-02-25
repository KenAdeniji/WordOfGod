<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.GutenbergKoreanEnglishDictionaryPage" 
 debug="true"
%>

<html>
 <head>
  <title>Gutenberg Korean English Dictionary Web Form</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">English:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxEnglishWord" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Korean:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxKoreanWord" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonSubmit"  onclick="ButtonSubmit_Click"     runat="server"   Text="Submit"/>
       <asp:Button id="ButtonReset"   onclick="ButtonReset_Click"      runat="server"   Text="Reset"/>
      </td>      
     </tr>        
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonKoreanConsonant"  onclick="ButtonKoreanConsonant_Click"     runat="server"   Text="KoreanConsonant"/>
       <asp:Button id="ButtonKoreanVowel"      onclick="ButtonKoreanVowel_Click"         runat="server"   Text="KoreanVowel"/>
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
 document.forms[0].TextBoxTextBoxEnglishWord.focus();
</script>