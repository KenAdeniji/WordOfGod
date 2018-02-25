<%@ Page Language="C#" AutoEventWireup="true" %>
<html>
 <head runat="server">
  <title runat="server">PostBackUrlTo</title>
  <script runat="server" language="C#">
   protected void Page_Load(Object sender, EventArgs e)
   {
    if (PreviousPage != null)
    {
     PostBackUrlTo.Text = "PreviousPage.Header.Title: " + PreviousPage.Header.Title;
     /*
     PostBackUrlFrom crossPage = (PostBackUrlFrom) PreviousPage;
     PostBackUrlFrom previousPage = PreviousPage as PostBackUrlFrom;
     */
     TextBox PostBackUrlFrom = (TextBox) Page.PreviousPage.FindControl("PostBackUrlFrom");
     PostBackUrlTo.Text += PostBackUrlFrom.Text;
    }
   }
  </script>
 </head>
 <body>
  <form runat="server">
   <asp:Label runat="server" id="PostBackUrlTo" />
  </form>
 </body>
</html>