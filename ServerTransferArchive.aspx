<%@ Page 
 Language="C#" 
 debug="true"
%>

<html>
 <head>
  <title>Server Transfer</title>
 </head>
 <body>
  <form runat="server">
  </form>
 </body>
</html>

<script runat=server language=C#>

 ///<summary>Page_Load()</summary>
 public void Page_Load() 
 {
  Server.Transfer
  ( 
   @"Comforter_-_WordEngineeringIndex.xml?" + Request.QueryString, 
   true /* Pass the view state and set enable the page directive EnableViewState=false to issue the Request.Form() method. To populate the controls, share the same control ids. <%@ Page Language="C#" EnableViewStateMac="False"%>  */
  );
 }
</script>