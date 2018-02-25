<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.AlphabetSequencePage" 
%>

<html>
 <head>
  <title>Alphabet Sequence</title>
 </head>
 <body style="FONT-FAMILY: arial">
  <form runat="server">
   <table align="center" border="1">
    <theader>
     <tr align="center"><th align="center" colspan="2">Alphabet Sequence</th></tr>
    </theader>
    <tbody>
    
     <tr align="center">
      <td align="left">
       <asp:Label id="LabelWord" runat="server">Word:</asp:Label>
      </td>     
      <td align="left">
       <asp:TextBox id="TextBoxWord" runat="server"/>
      </td>     
     </tr>     

     <tr align="center">
      <td align="left">
       <asp:Label id="LabelScriptureReferenceAssociates" runat="server">Scripture Reference Associates:</asp:Label>
      </td>     
      <td align="left">
       <asp:TextBox id="TextBoxScriptureReferenceAssociates" runat="server"/>
      </td>     
     </tr>     
     
     <tr align="center">
      <td align="center" colspan="2"><asp:Button id="ButtonQuery" onclick="ButtonQuery_Click" runat="server" Text="Query"/></td>
     </tr>     

     <!--
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonDatabaseQueryChapterMaximum" onclick="ButtonDatabaseQueryChapterMaximum_Click" runat="server" Text="Query"/>
      </td>
     </tr>     
     -->
     
     <tr align="center">
      <td align="left">
       <asp:Label id="LabelAlphabetSequence" runat="server">Alphabet Sequence:</asp:Label>
      </td>     
      <td align="left">
       <asp:TextBox id="TextBoxAlphabetSequence" runat="server"></asp:TextBox>
      </td>     
     <tr align="center">
      <td align="left">
       <asp:Label id="LabelScriptureReference" runat="server">Scripture Reference:</asp:Label>
      </td>     
      <td align="left">
       <asp:TextBox id="TextBoxScriptureReference" runat="server"></asp:TextBox>
      </td>     
     </tr>     
     <tr align="center">
      <td align="left">
       <asp:Label id="LabelVerseForward" runat="server">Verse Forward:</asp:Label>
      </td>     
      <td align="left">
       <asp:TextBox id="TextBoxVerseForward" runat="server"></asp:TextBox>
      </td>     
     </tr>     
     <tr align="center">
      <td align="left">
       <asp:Label id="LabelChapterForward" runat="server">Chapter Forward:</asp:Label>
      </td>     
      <td align="left">
       <asp:TextBox id="TextBoxChapterForward" runat="server"></asp:TextBox>
      </td>     
     </tr>     
     <tr align="center">
      <td align="left">
       <asp:Label id="LabelChapterBackward" runat="server">Chapter Backward:</asp:Label>
      </td>     
      <td align="left">
       <asp:TextBox id="TextBoxChapterBackward" runat="server"></asp:TextBox>
      </td>     
     </tr>     
     <tr align="center">
      <td align="left">
       <asp:Label id="LabelVerseBackward" runat="server">Verse Backward:</asp:Label>
      </td>     
      <td align="left">
       <asp:TextBox id="TextBoxVerseBackward" runat="server"></asp:TextBox>
      </td>     
     </tr>     
     <tr align="center">
      <td colspan="2">
       <asp:Repeater id="RepeaterAlphabetSequence" runat=server>
        <HeaderTemplate>
         <table border=1>
        </HeaderTemplate>
        <ItemTemplate>
         <tr>
          <td>
           Word:
           <%# DataBinder.Eval(Container.DataItem, "Word") %> 
           <br/>
           Alphabet Sequence:
           <%# DataBinder.Eval(Container.DataItem, "AlphabetSequence") %> 
           <br/>
           Scripture Reference:
           <%# DataBinder.Eval(Container.DataItem, "ScriptureReferenceCurrent") %> 
           <br/>
           Verse Forward:
           <%# DataBinder.Eval(Container.DataItem, "VerseForward") %> 
           <br/>
           Chapter Forward:
           <%# DataBinder.Eval(Container.DataItem, "ChapterForward") %> 
           <br/>
           Chapter Backward:
           <%# DataBinder.Eval(Container.DataItem, "ChapterBackward") %> 
           <br/>
           Verse Backward:
           <%# DataBinder.Eval(Container.DataItem, "VerseBackward") %> 
           <br/>
           Scripture Reference Verse Forward:
           <%# DataBinder.Eval(Container.DataItem, "ScriptureReferenceVerseForward") %> 
           <br/>
           Scripture Reference Chapter Forward:
           <%# DataBinder.Eval(Container.DataItem, "ScriptureReferenceChapterForward") %> 
           <br/>
           Scripture Reference Chapter Backward:
           <%# DataBinder.Eval(Container.DataItem, "ScriptureReferenceChapterBackward") %> 
           <br/>
           Scripture Reference Verse Backward:
           <%# DataBinder.Eval(Container.DataItem, "ScriptureReferenceVerseBackward") %> 
          </td>
         </tr>
        </ItemTemplate>
        <FooterTemplate>
         </table>
        </FooterTemplate>
       </asp:Repeater>
      </td>
     </tr>
     <tr align="center">
      <td align="center" colspan="2">
       <asp:Label id="LabelExceptionMessage" runat="server"/>
      </td>     
     </tr>
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxWord.focus ();
</script> 
