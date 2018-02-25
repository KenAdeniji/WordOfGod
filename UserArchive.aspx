<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.UserPage"
%>

<html>
 <head>
  <title>User</title>
 </head>
 <body>
  <form 
   ID="formUser"
   runat="server"
   enctype="multipart/form-data"    
   autocomplete="on"
   defaultfocus="GridViewUser"
  >
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="center">
       <asp:GridView
        id="GridViewUser" 
        runat="server"
        AutoGenerateColumns=True
       >
        <HeaderStyle          BackColor='#CCCC99' />
        <RowStyle             BackColor='#eeeeee' />
        <AlternatingRowStyle  BackColor='#ffffe8' />
       </asp:GridView> 
      </td>
     </tr>
    </tbody>    
   </table>
  </form>
 </body>
</html>