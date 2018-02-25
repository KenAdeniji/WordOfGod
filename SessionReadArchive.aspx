<html>
 <head>
  <title>SessionRead</title>
 </head>
 <body> 
  <%
   ArrayList ArrayListAccount = new ArrayList();
   ArrayListAccount = (ArrayList) Session["Account"];
   foreach(object account in ArrayListAccount)
   {
    Response.Write(account + "<br/>");
   }
  %>
 </body>
</html>