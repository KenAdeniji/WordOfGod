<%@ Page Language="C#" debug="true" %>
<%@ import NameSpace="System.Collections.Generic" %>
<html>
 <head runat="server" id="htmlHead">
  <title runat="server" id="htmlTitle">DataBind</title>
  <script runat="server" language="C#">
   protected int TransactionCount;
   protected void Page_Load(Object sender, EventArgs e)
   {
    TransactionCount = 10;
    this.DataBind();
    if (!this.IsPostBack)
    {
     Dictionary<int, string> fruit = new Dictionary<int, string>();
     fruit.Add(1, "Kiwi");
     fruit.Add(2, "Pear");
     fruit.Add(3, "Mango");
     fruit.Add(4, "Blueberry");
     fruit.Add(5, "Apricot");
     fruit.Add(6, "Banana");
     fruit.Add(7, "Peach");
     fruit.Add(8, "Plum");
     Fruit.DataSource = fruit; 
     Fruit.DataTextField = "Value"; 
     Fruit.DataValueField = Key; 
     Fruit.DataBind();
    }

   }
  </script>
 </head>
 <body>
  <form runat="server" id="htmlForm"> 
   Transaction Count: <%# TransactionCount %>
   Browser: <%# Request.Browser.Browser %>
   <asp:ListBox runat="server" id="Fruit" />
  </form>
 </body>
</html>