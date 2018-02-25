<html>
 <head>
  <title>Environment</title>
 </head>
 <body> 
  <%
   Response.Write("The TEMP environment variable is: " + Environment.GetEnvironmentVariable("TEMP") + "<br/>");
   Response.Write("ASP.NET is running as the account: " + Environment.UserName + "<br/>"); 
   Response.Write("The USERPROFILE environment variable is: " + Environment.GetEnvironmentVariable("USERPROFILE") + "<br/>");
   Response.Write("The Working Set is " + System.Environment.WorkingSet.ToString() + " bytes" + "<br/>");
   Response.Write("The System Directory is " + System.Environment.SystemDirectory.ToString() + "<br/>");
   Response.Write("The MachineName is " + System.Environment.MachineName.ToString() + "<br/>");
   Response.Write("The OS Version is " + System.Environment.OSVersion.ToString() + "<br/>");
   Response.Write("The .NET version is " + System.Environment.Version.ToString() + "<br/>");
  %>
 </body>
</html>