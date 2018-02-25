<%@ Page Language="C#" %>
<script language="C#" runat="server">
 public void Page_Load(Object sender, EventArgs e)
 {
  //Header.LinkedStyleSheets.Add("Styles.css");
  stylesheet.Href = "Styles.css";
  Header.Title = "Header.Title";
 }
</script>   
<head runat="server">
 <link href="Styles.css" type="text/css" rel="stylesheet" id="stylesheet" />
</head>
