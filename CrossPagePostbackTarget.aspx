<%@ page language="C#" %>
<script runat="server">
 void Page_Load(object sender, EventArgs e)
 {
  if ( PreviousPage == null )
  {
   Response.Write("Cross page posting required");
   Response.End();
   return;
  }
  TextBox txt = (TextBox) PreviousPage.FindControl("Data");
  Response.Write("You passed:" + txt.Text);
 } 
</script>
<html>
 <head runat="server">
  <title>Target page</title>
 </head>
 <body>
 </body>
</html>