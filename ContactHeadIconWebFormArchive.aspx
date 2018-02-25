<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.ContactHeadIconPage" 
%>

 
<html>
 <head>
  <script language="JavaScript">
   function newDocument() 
   {
    document.open();
    document.write("<p>This is a New Document.</p>");
    document.close();
   }
   
   function openDocument(documentFilename)
   {
    documentOpen = window.open( documentFilename, "content");
   }
  </script>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>
     <tr align=left>
      <td align=left>
       <a id='AnchorNew' 
         runat='server'
         OnServerClick='Image_Click'
         onClick="openDocument('ContactGridViewWebForm.aspx')"
       >
        <img 
         src='GIF\MicrosoftHotmail.com_-_i.p.cont.individual.gif'
         border=0
        >
       </a>
       <a id='AnchorDelete' 
         runat='server'
         OnServerClick='Image_Click'
       >
        <img 
         src='GIF\MicrosoftHotmail.com_-_i.p.delete.gif'
         border=0
        >
       </a>
       <a id='AnchorEdit'
         runat='server'
         OnServerClick='Image_Click'
       >
        <img 
         src='GIF\MicrosoftHotmail.com_-_i.p.edit.gif'
         border=0
        >
       </a>
       <a id='AnchorPutInGroup'
         runat='server'
         OnServerClick='Image_Click'
       >
        <img 
         src='GIF\MicrosoftHotmail.com_-_i.p.putingrp.gif'
         border=0
        >
       </a>
       <a id='AnchorSend'
         runat='server'
         OnServerClick='Image_Click'
       >
        <img 
         src='GIF\MicrosoftHotmail.com_-_i.p.send.gif'
         border=0
        >
       </a>
       <a id='AnchorSynchronize'
         runat='server'
         OnServerClick='Image_Click'
       >
        <img 
         src='GIF\MicrosoftHotmail.com_-_i.p.sync.gif'
         border=0
        >
       </a>
       <a id='AnchorCardView'
         runat='server'
         OnServerClick='Image_Click'
       >
        <img 
         src='GIF\MicrosoftHotmail.com_-_i.p.persoinfo.gif'
         border=0
        >
       </a>
       <a id='AnchorPrintView'
         runat='server'
         OnServerClick='Image_Click'
       >
        <img 
         src='GIF\MicrosoftHotmail.com_-_i.p.printv.gif'
         border=0
        >
       </a>
      </td>
     </tr>  
     <tr>
      <td align="left" colspan="1"><asp:Literal id="LiteralFeedback" runat="server" /></td>
     </tr>    
    </tbody>    
   </table>    
  </form>
 </body>
</html>