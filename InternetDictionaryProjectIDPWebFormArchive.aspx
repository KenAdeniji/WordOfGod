<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.InternetDictionaryProjectIDPPage" 
 debug="true"
%>

<html>
 <head>
  <title>Internet Dictionary Project (IDP) Web Form</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="left" colspan="1">English:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxEnglish" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">French:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxFrench" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">German:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxGerman" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Italian:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxItalian" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Latin:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxLatin" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Portuguese:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxPortuguese" runat="server" /></td>
     </tr>
     <tr align="center">
      <td align="left" colspan="1">Spanish:</td>
      <td align="left" colspan="1"><asp:TextBox id="TextBoxSpanish" runat="server" /></td>
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
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Repeater id="RepeaterInternetDictionaryProjectIDP" runat=server>
        <HeaderTemplate>
         <table border=1>
        </HeaderTemplate>
        <ItemTemplate>
         <tr>
          <td>
           English:
           <%# DataBinder.Eval(Container.DataItem, "EnglishWord") %> 
           <br/>

           French:
           <%# DataBinder.Eval(Container.DataItem, "FrenchCommentary") %> 
           <br/>
           
           German:
           <%# DataBinder.Eval(Container.DataItem, "GermanCommentary") %> 
           <br/>

           Italian:
           <%# DataBinder.Eval(Container.DataItem, "ItalianCommentary") %>
           <br/>

           Latin:
           <%# DataBinder.Eval(Container.DataItem, "LatinCommentary") %>
           <br/>

           Portuguese:
           <%# DataBinder.Eval(Container.DataItem, "PortugueseCommentary") %>
           <br/>

           Spanish:
           <%# DataBinder.Eval(Container.DataItem, "spanishCommentary") %>
           <br/>
           
          </td>
         </tr>
        </ItemTemplate>
        <FooterTemplate>
         </table>
        </FooterTemplate>
       </asp:Repeater>
      </td>
     </tr>
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxEnglish.focus();
</script>