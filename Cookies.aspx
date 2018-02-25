<%@ Page Language="C#" debug="true" %>
<%@ import Namespace="System.Net" %>
<html>
 <head runat="server" id="htmlHead">
  <title runat="server" id="htmlTitle">Cookies</title>
  <script runat="server" language="C#">

   protected void Page_Load(Object sender, EventArgs e)
   {
    HttpCookie cookie = Request.Cookies["WordEngineering"];
    if ( cookie != null )
    {
     Engineering.Text = cookie["Engineering"];
    }
   }

   protected void Store_Click(Object sender, EventArgs e)
   {
    HttpCookie cookie = Request.Cookies["WordEngineering"];
    if ( cookie == null )
    {
     cookie = new HttpCookie("WordEngineering");
    }
    cookie["Engineering"] = Engineering.Text;
    cookie.Expires = DateTime.Now.AddYears(1);

    Response.Cookies.Add(cookie);
   }
  </script>
 </head>
 <body>
  <form runat="server" id="htmlForm"> 
   <asp:TextBox runat="server" ID="Engineering" />
   <asp:button runat="server" ID="Store" Text="Store" OnClick="Store_Click" />
  </form>
 </body>
</html>