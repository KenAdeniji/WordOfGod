<%@ page language="C#" %>
<%@ import namespace="System.Data" %>
<%@ import namespace="System.Data.Common" %>
<%@ import namespace="System.Data.SqlClient" %>

<script runat="server">
 void Page_Load(object sender, EventArgs e)
 {
  DataTable providers = DbProviderFactories.GetFactoryClasses();
  provList.DataSource = providers;
  provList.DataBind();
 }
</script>

<html>
<head runat="server"><title>DbProviderFactories.GetFactoryClasses();</title></head>
<body>
 <form runat="server">
  <asp:GridView runat="server" id="provList" />
 </form>
</body>