<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.GutenbergWebsterUnabridgedDictionaryPage" 
%>
 
<html>
 <head>
  <title>Project Gutenberg Webster's Unabridged Dictionary</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr><td colspan="3">
      2004-03-02T00:00:00.0000000-08:00 It only comes into your mind to call one customer and gift, 
      <a target='_blank' href='http://www.gutenberg.net'>Gutenberg.net</a>
      737
      (
      <a target='_blank' href='http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Genesis+27%3A9%2C+Isaiah+58%2C+Job+17%2C+James+5%3A11&amp;section=0&amp;version=nkj&amp;language=en'>Genesis 27:9, Isaiah 58, Job 17, James 5:11</a>
      )
     </td></tr>
     <tr>
      <td align="left">Word: </td>
      <td align="left"><asp:TextBox id="TextBoxDictionaryWord" Columns="50" ontextchanged="ButtonSearch_Click" autopostback="true" runat="server" /></td>
      <td align="left"><asp:Button id="ButtonSearch" onclick="ButtonSearch_Click" runat="server" Text="Search"/></td>
     </tr>     
     <tr>
      <td colspan="3">
       <Span
        id="HtmlGenericControlSearchResult" 
        runat="server"/>        
      </td>
     </tr> 
     <tr>
      <td align="center" colspan="3"><asp:Literal id="LiteralFeedback" runat="server"/></td>
     </tr>    
    </tbody>    
   
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxDictionaryWord.focus();
</script> 