<%@ Page 
 Debug=True
 Language='C#' 
 Trace=False 
%>

<html>
 <head>
  <title>Identity</title>
 </head>
 <body>
  <table border=1>
   <tr>
    <td>Page.User.Identity.Name</td>
    <td><% =Page.User.Identity.Name %></td>
   </tr>
   <tr>
    <td>System.Security.Principal.WindowsIdentity.GetCurrent().Name</td>
    <td><% =System.Security.Principal.WindowsIdentity.GetCurrent().Name %></td>
   </tr>
   <tr>
    <td>System.Threading.Thread.CurrentPrincipal.Identity.Name</td>
    <td><% =System.Threading.Thread.CurrentPrincipal.Identity.Name %></td>
   </tr>
  </table>
 </body>
</html>