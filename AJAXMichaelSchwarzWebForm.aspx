<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.AJAXMichaelSchwarzPage"
 validateRequest=false
%>

<html>
 <head>

  <title>AJAX Michael Schwarz Web Form</title>
 </head>
 <body>
  <form 
   ID="formAJAXMichaelSchwarz" 
   runat="server"
   enctype="multipart/form-data"    
   autocomplete="on"
   defaultbutton=""
   defaultfocus=""
  >

   <script language="javascript">

    var response = AJAXMichaelSchwarzPage.ServerSideAdd( 100,99, ServerSideAdd_CallBack );

    function ServerSideAdd_CallBack( response )
    {
     if ( response.error != null )
     {
      alert( response.error );
      return;
     }
     alert(response.value);
    }//function ServerSideAdd_CallBack( response )

   </script>
  </form>
 </body>
</html>