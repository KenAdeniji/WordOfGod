<%@ page language="C#" Debug="true" %>
<script runat="server">
 void OnRate(object sender, BulletedListEventArgs e)
 {
  Rate(e.Index)
 } 
 void Rate (int index) 
 {
  string displayRate = Feedback.Items[index].Text;
  string rate = Feedback.Items[index].Value;

  string baseText = "Book's rate: {0}"
  Thanks.Text = String.Format(baseText, displayRate);

  SiteCounters.Write("Book Feedback", "Intro", rate, null, true, true);
 }
</script>

<html>
 <head runat="server">
  <title>Site Counters</title>
 </head>
 <body>
  <form 
   ID="formURI" 
   runat="server"
   enctype="multipart/form-data"    
   autocomplete="on"
  >
   <h2>Book's Rating</h2>
   <asp:bulletedList runat="Server" displayMode="LinkButton" onClick="OnRate">
    <asp:ListItem value="5">Outstanding</asp:ListItem>
    <asp:ListItem value="4">Excellent</asp:ListItem>
    <asp:ListItem value="3">Great</asp:ListItem>
   </asp:bulletedList>
   <br />
 </body>
</html> 