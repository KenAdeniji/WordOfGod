<%@ Page 
 Language="C#" 
 debug="true"
%>

<script language="C#" runat="server">
 public void Page_Load
 (
  object     sender, 
  EventArgs  e
 )  
 {
  Trace.Write("Trace Category", "Trace Message");
 }
</script>