<%@ Page 
 Language="C#" 
 debug=true
%>

<html>
 <head>
  <title>Print</title>
 </head>
 <body>
  <form 
   ID="formPrint" 
   runat="server"
   enctype="multipart/form-data"    
   autocomplete="on"
   defaultbutton="ButtonPrint"
   defaultfocus="ButtonPrint"
  >
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="center">
       <asp:Button runat="server" id="ButtonPrint" OnClientClick="return window.print()" Text="Print" />
      </td>
     </tr>
     <tr>
      <td align="center"><asp:Literal id="LiteralFeedback" runat="server" EnableViewState=false /></td>
     </tr>    
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="C#" runat=server>
 public void Page_Load(object sender, EventArgs e)
 {
  ButtonPrint.Attributes.Add("onClick", "javascript:window.print();");
 }
</script>

<script language="javascript">
 //window.print(); 
</script>

<script language="Javascript" event="onbeforeprint" for="window"> 
 document.forms[0].ButtonPrint.style.visibility = 'hidden'; 
</script>

<script language="Javascript" event="onafterprint" for="window"> 
 document.forms[0].ButtonPrint.style.visibility = 'visible'; 
</script>