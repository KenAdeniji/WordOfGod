<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.IFramePage"
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="server" id="PageHead">
  <title runat="server" id="PageTitle">IFrame</title>
 </head>
 <body>
  <asp:Panel
   runat="server"
   id="PanelIFrame"
  >
   <form 
    runat="server"
    ID="FormIFrame" 
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultfocus="IFrameGeneric"
   >
    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td align="left">
        <IFrame
         runat="server"
         id="IFrameGeneric"
         scrolling="auto"
        >
        </IFrame>
       </td>
      </tr>
<%--
      <tr align="center">
       <td align="center">
        <asp:Button runat="server" id="ButtonHideFrame" Text="Hide Frame" OnClientClick="HideFrame()" />
       </td>
      </tr>
--%>      
     </tbody>
    </table>
   </form>
  </asp:Panel> 
 </body>
</html>

<script>
 function HideFrame()
 {
  window.parent.document.all["IFrameGeneric"].style.display = "NONE";
 }
</script>