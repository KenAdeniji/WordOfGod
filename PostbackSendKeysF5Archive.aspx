<%@ Page 
 Language="C#" 
 debug="true"
%>

<%@ Import Namespace="System.Windows.Forms" %>

<html>
 <head>
  <!-- <META HTTP-EQUIV="Refresh" CONTENT="1"> -->
  <title>PostbackSendKeysF5</title>
 </head>
 <body>
  <form runat="server">
  </form>
 </body>
</html>

<script runat=server language=C#>
 ///<summary>Page_Load()</summary>
 ///<remarks>http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpref/html/frlrfSystemWindowsFormsSendKeysClassTopic.asp</remarks>
 void Page_Load()
 {
  //SendKeys.Send("{F5}");
  //Response.Redirect( Request.RawUrl );   // RawUrl contains the full url, including parameters.
  //Response.AppendHeader("Refresh", "1");  // Units are in seconds
 }//void Page_Load()
</script>