<%@ page language="C#" Debug="true" EnableSessionState="True" %>
<script runat="server">
 protected void Page_Load(object sender, System.EventArgs e)
 {
  object sessionID = -1;
  sessionID = Session["SessionID"];
  if (sessionID == null)
  {
   sessionID = 0;
  }
  sessionID = System.Convert.ToInt32(sessionID) + 1;
  Session["SessionID"] = sessionID;
  SessionID.Text = System.Convert.ToString(sessionID);
 } 
</script>

<html>
 <head runat="server">
  <title>Session</title>
 </head>
 <body>
  <form 
   ID="formID" 
   runat="server"
   enctype="multipart/form-data"    
   autocomplete="on"
  >
   <asp:Label runat="server" id="SessionID" />
  </form> 
 </body>
</html> 