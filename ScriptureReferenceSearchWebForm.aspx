<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.ScriptureReferenceSearchPage" 
%>
 
<html>
 <head>
  <title>Scripture Reference Search</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr>
	  <td align="center" colspan="2">
		Scripture Reference:
		<asp:TextBox id="TextBoxScriptureReferenceSearch" runat="server" AutoPostBack="true" Columns="50" />
      </td>
     </tr>     
     <tr>
      <td align="center" colspan="2">
       <asp:Button id="ButtonSearch" onclick="ButtonSearch_Click" runat="server" Text="Search"/>
      </td>
     </tr>     
     <tr>
      <td align="center" colspan="2"><asp:Label id="LabelFeedback" runat="server"/></td>
     </tr>    
     <tr>
      <td align="center" colspan="2">
       <asp:HyperLink id="HyperLinkCrosswalkURIHTML"
        NavigateUrl="http://bible.crosswalk.com"
        Text="Crosswalk URI HTML"
        Target="_new"
        runat="server"/>
       <asp:HyperLink id="HyperLinkCrosswalkURIXML"
        NavigateUrl="http://bible.crosswalk.com"
        Text="Crosswalk URI XML"
        Target="_new"
        runat="server"/>
	<asp:LinkButton id="LinkButtonTextToSpeech" 
           Text="Text-to-Speech" 
           OnClick="LinkButtonTextToSpeech_Click" 
           runat="server"/>
	<asp:LinkButton id="LinkButtonMark" 
           Text="Mark" 
           OnClick="LinkButtonMark_Click" 
           runat="server"/>
      </td>
     </tr>     
     <tr>
      <td colspan="2">
       <Span
        id="HtmlGenericControlScriptureReferenceText" 
        runat="server"/>        
      </td>
     </tr> 
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
  document.forms[0].TextBoxScriptureReferenceSearch.focus ();
</script> 