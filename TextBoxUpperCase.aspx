<html>
 <head>
  <title>Uppercase</title>
 </head>
 <body>
  <form runat="server" id="FormTextBoxUpperCase">
   <asp:TextBox runat="server" id="TextBoxUpperCase" />
  </form>
 </body>
</html>

<script language="C#" runat="server">
 public void Page_Load
 (
  object    sender, 
  EventArgs e
 )
 {
  TextBoxUpperCase.Attributes.Add("onKeyUp", "this.value=this.value.toUpperCase();");
  //TextBoxUpperCase.Attributes.Add("OnFocus", "document.FormTextBoxUpperCase.TextBoxUpperCase.Value='';");
 }
</script>