<html>
 <head>
  <title>SessionWrite</title>
 </head>
 <body> 
  <%
   ArrayList ArrayListAccount = new ArrayList();
   ArrayListAccount.Add("1");
   ArrayListAccount.Add("11");
   ArrayListAccount.Add("101");
   Session["Account"] = ArrayListAccount;
   Response.Redirect("SessionRead.aspx");
  %>
 </body>
</html>