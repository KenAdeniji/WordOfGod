<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.IISLogPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadIISLog">
  <title runat="Server" id="TitleIISLog">IIS Log</title>
 </head>
 <body 
  runat="Server" 
  id="BodyIISLog"
 >
  <asp:Panel
   runat="Server"
   id="PanelIISLog"
  >
   <form 
    ID="FormIISLog"
    runat="Server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultfocus="Server"
   >
    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="Server"       
         id="LabelComputer"
         Text="Computer:"
         AccessKey="C"
         AssociatedControlId="Computer"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="Computer"
         TabIndex="1"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="Server"       
         id="LabelSite"
         Text="Site:"
         AccessKey="S"
         AssociatedControlId="WebSite"
         AutoPostBack="True"
        />
       </td>
       <td align="left">
        <asp:DropDownList
         runat="Server"
         ID="WebSite"
         TabIndex="2"
         OnChange="LoadLog(this)"
        />
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="Server"       
         id="LabelLog"
         Text="Log:"
         AccessKey="L"
         AssociatedControlId="Log"
         AutoPostBack="True"
        />
       </td>
       <td align="left">
        <asp:DropDownList
         runat="Server"
         ID="Log"
         TabIndex="3"
         OnChange="ParseLog(this)"         
        />
       </td>
      </tr>
     </tbody>
    </table>

    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td>
        <span
         id="IISLog" 
         runat="Server" 
        />
       </td>
      </tr>
     </tbody>
    </table>

    <table align="center" border="0">
     <tbody> 
      <tr align="center">
       <td align="center">
        <asp:Literal 
         id="LiteralFeedback" 
         runat="Server" 
         EnableViewState=False
        />
       </td>
      </tr>
     </tbody>    
    </table>
   </form>
  </asp:Panel>
 </body>
</html>

<script language="javascript">
 var Computer = document.getElementById("<%=Computer.ClientID%>");
 var IISLog = document.getElementById("<%=IISLog.ClientID%>");
 var LogList = document.getElementById("<%=Log.ClientID%>"); 
 var SiteList = document.getElementById("<%=WebSite.ClientID%>");

 function ParseLog(Logs)
 {
  var log = Logs.options[Logs.selectedIndex].value;
  //log = LogList.options[LogList.selectedIndex].value;
  var site = SiteList.options[SiteList.selectedIndex].value;
  IISLogPage.ParseLog(Computer.value, log, site, ParseLog_CallBack);
 }

 function ParseLog_CallBack(response)
 {
  if ( response.error != null )
  {
   alert(response.error); 
   return;
  }
  var dataTable = response.value;
  if(dataTable != null && typeof(dataTable) == "object")
  {
   var s = new Array();
   s[s.length] = "<table border=1>";
   s[s.length] = "<theader>";
   s[s.length] = "<tr>";
   s[s.length] = "<th>date</th>";
   s[s.length] = "<th>time</th>";
   s[s.length] = "<th>s-ip</th>";
   s[s.length] = "<th>cs-method</th>";
   s[s.length] = "<th>cs-uri-stem</th>";
   s[s.length] = "<th>cs-uri-query</th>";
   s[s.length] = "<th>s-port</th>";
   s[s.length] = "<th>cs-username</th>";
   s[s.length] = "<th>c-ip</th>";
   s[s.length] = "<th>cs(User-Agent)</th>";
   s[s.length] = "<th>sc-status</th>";
   s[s.length] = "<th>sc-substatus</th>";
   s[s.length] = "<th>sc-win32-status</th>";   
   s[s.length] = "</tr>";
   s[s.length] = "</theader>";
   s[s.length] = "<tbody>";
   for( var row=0; row < dataTable.Rows.length; ++row )
   {
    s[s.length] = "<tr>";
    s[s.length] = "<td>" + dataTable.Rows[row].date + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].time + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].sip + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].csmethod + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].csuristem + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].csuriquery + "</td>";    
    s[s.length] = "<td>" + dataTable.Rows[row].sport + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].csusername + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].cip + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].csUserAgent + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].scstatus + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].scsubstatus + "</td>";
    s[s.length] = "<td>" + dataTable.Rows[row].scwin32status + "</td>";    
    s[s.length] = "</tr>";
   }
   s[s.length] = "</tbody>";
   s[s.length] = "</table>";
   IISLog.innerHTML = s.join("");
  }
 }
 
 function LoadLog(Sites)
 {
  var site = Sites.options[Sites.selectedIndex].value;
  IISLogPage.LoadLog(Computer.value, site, LoadLog_CallBack);
 }
 
 function LoadLog_CallBack(response)
 {
  if ( response.error != null )
  {
   alert(response.error); 
   return;
  }
  var log = response.value;
  if (log == null || typeof(log) != "object")
  {
   return;
  }
  LogList.options.length = 0;
  for (var i = 0; i < log.length; ++i)
  {
   LogList.options[i] = new Option(log[i]);
  }
 }
 
 function LoadWebSite(Computers)
 {
  var computer = Computers.value;
  IISLogPage.WebSite(computer, LoadWebSite_CallBack);
 }
 
 function LoadWebSite_CallBack(response)
 {
  if (response.error != null)
  {
   alert(response.error); 
   return;
  }
  var site = response.value;  
  if (site == null || typeof(site) != "object")
  {
   return;
  }
  SiteList.options.length = 0;
  for (var i = 0; i < site.length; ++i)
  {
   SiteList.options[i] = new Option(site[i]);
  }
 }
</script>
