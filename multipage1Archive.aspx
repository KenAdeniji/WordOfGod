<%@ import namespace="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="mymultipage" 
    Namespace="Microsoft.Web.UI.WebControls" 
    Assembly="Microsoft.Web.UI.WebControls" 
%>
<HEAD></HEAD>

<BODY>
  <FORM runat="server">
   <mymultipage:multipage runat="server" selectedindex="1">
    <mymultipage:pageview><p>This is page number one</p></mymultipage:pageview>
    <mymultipage:pageview><p>This is page number two, and this page view is selected!</p></mymultipage:pageview>
   </mymultipage:multipage>
  </FORM>
</BODY>

