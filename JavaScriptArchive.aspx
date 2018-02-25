<html>
 <head>
  <title>
    JavaScript
  </title>  
  
  <!--
  <META  HTTP-EQUIV="EXPIRES" CONTENT="0">
  <META  HTTP-EQUIV="PRAGMA" CONTENT="NO-CACHE">
  -->
  
  <style type="text/css" >
   .prompt 
   {
    font-family: verdana;
    font-weight:bold;
    color: #8b6952;
    background-color:#d3c75e;
    font-size:18pt
   }
  </style>
  <script language="JavaScript">
   <!--
   function JavaScriptAnchor() 
   {
    window.alert("JavaScriptAnchor")
   }
   //-->
  </SCRIPT>
 </head>
 <body 
  runat="Server" 
  id="BodyHTML"
 >
  <form runat="server" id="FormHTML" enctype="multipart/form-data">
   <table>
    <tr>
     <td>
      <asp:button runat="server" OnClientClick = "ArrayMonth()" Text="ArrayMonth" />
	  <asp:button runat="server" OnClientClick = "document.bgColor='d0d0a9'" Text="Background Color" />
      <asp:button runat="server" OnClientClick = "Hexadecimal()" Text="Hexadecimal" />
      <asp:button runat="server" OnClientClick = "Interactive()" Text="Interactive" />
      <asp:button runat="server" OnClientClick = "Mathematics()" Text="Mathematics" />
      <asp:button runat="server" OnClientClick = "Movie()" Text="Movie" />
	  <asp:button runat="server" OnClientClick = "String()" Text="String" />
	  <asp:button runat="server" OnClientClick = "TypeOf()" Text="TypeOf" />
      <asp:button runat="server" OnClientClick = "WindowClose()" Text="Close" />
      <asp:button runat="server" OnClientClick = "WindowLocation('Software.aspx')" Text="Software.aspx" />
      <asp:button runat="server" OnClientClick = "WindowOpen('Remember.aspx')" Text="Remember.aspx" />
      <asp:button runat="server" OnClientClick = "WindowStatus('KnowledgeBase.aspx')" Text="Window.Status" />
      <a href="javaScript:JavaScriptAnchor()">Anchor</a>
      <!--
      <a href=# onClick="JavaScriptAnchor()">Anchor</a>
      -->
     </td>
    </tr>
   </table>
   <table>       
    <tr>
     <td>
      <span runat="server" ID="Feedback" />
     </td> 
    </tr>
   </table>
  </form>
 </body>
</html>

<script language='javaScript' src='Utility.js'>
</script>

<script language="javascript">

<!--

 function ArrayMonth()
 {
  var month = new Array(12)
  month[0] = "January"
  month[1] = "February"
  month[2] = "March"
  month[3] = "April"
  month[4] = "May"
  month[5] = "June"
  month[6] = "July"
  month[7] = "August"
  month[8] = "September"
  month[9] = "October"
  month[10] = "November"
  month[11] = "December"
  for (monthIndex = 0; monthIndex < month.length; monthIndex++)
  {
   document.write(month[monthIndex] + " ")
  }
  document.write("<br/>")
  month.sort()
  document.write(month.join(" "));
  document.write("<br/>")
  month.reverse()
  document.write(month.join(" "));
 }

 function Browser()
 {
  alert("Browser Name: " + navigator.appName);
  alert("Browser Version: " + navigator.appVersion);
 }

 function DateTime()
 {
  var weekday=new Array(7)
  weekday[0]="Sunday"
  weekday[1]="Monday"
  weekday[2]="Tuesday"
  weekday[3]="Wednesday"
  weekday[4]="Thursday"
  weekday[5]="Friday"
  weekday[6]="Saturday"

  var SystemDate = new Date()
  alert( SystemDate )

  var SystemDay = SystemDate.getDay()
  alert("Weekday: " + weekday[SystemDay] )
 }

 function Hexadecimal()
 {
  document.write("0xfeed + 0xdeed = " + (0xfeed + 0xdeed).toString(16))
 }

 function Interactive()
 {
  var userName
  userName = prompt("Enter your name:", "Name")
  document.write("Hello " + userName);
 }

 function Mathematics()
 {
 
  lineBreak = "<br/>";
   
  var maximumNumber = Math.max(70, 90);
  document.write("Maximum number between 70 and 90 is: " + maximumNumber + lineBreak);  

  var minimumNumber = Math.min(70, 90);
  document.write("Minimum number between 70 and 90 is: " + minimumNumber + lineBreak);  
  
  var parseNumber = parseFloat("70.97281") + parseInt("98.5201");
  document.write("parseFloat(\"70.97281\") + parseInt(\"98.5201\")" + parseNumber + lineBreak);
  
  var randomNumber = Math.random();
  document.write("Random number: " + randomNumber + lineBreak);  

  var roundNumber = Math.round(70.9);
  document.write("Rounding 70.9 to the nearest whole number: " + roundNumber + lineBreak);  
 }

 function Movie()
 {
  var movie = new Object();
  var movie = { role: "Conductor", star:"John Doe" };
  document.write("Movie role: " + movie.role + " | star: " + movie.star);
 }

 function String()
 {
  var hello = "Hello"
  var world = "World"
  var helloWorld = "Hello World"

  /*
  alert("Hello World, Length: " + helloWorld.length)
  Feedback.innerHTML = "Hello World, Length: " + helloWorld.length
  alert("helloWorld.indexOf(\"World\"): " + helloWorld.indexOf("World"))
  alert("helloWorld.lastIndexOf(\"World\"): " + helloWorld.lastIndexOf("World"))
  alert("helloWorld.match(\"World\"): " + helloWorld.match("World"))
  alert("helloWorld.substr(3,4): " + helloWorld.substr(3,4))
  alert("helloWorld.substring(3,7): " + helloWorld.substring(3,7))
  alert("helloWorld.toLowerCase(): " + helloWorld.toLowerCase())
  alert("helloWorld.toUpperCase(): " + helloWorld.toUpperCase())
  */

  document.write(helloWorld.anchor("HelloWorld"))  
  document.write("helloWorld.big()".big())
  document.write("helloWorld.blink()".blink())
  document.write("helloWorld.bold()".bold())
  document.write("HelloWorld charAt(6)" + helloWorld.charAt(6))
  document.write("HelloWorld charCodeAt(6)" + helloWorld.charCodeAt(6))
  document.write("hello.concat(\" \", world)" + hello.concat(" ", world))
  document.write("helloWorld.fontcolor(\"red\")".fontcolor("red"))
  document.write("helloWorld.fontsize(16)".fontsize(16))
  document.write("Hello World".link("JavaScript.aspx")) 
  document.write("helloWorld.search(\"lo W\")" + helloWorld.search("lo W"))
  document.write("helloWorld.slice(2,5)" + helloWorld.slice(2,5))
  document.write("helloWorld.small()".small())
  document.write("helloWorld.split(\"l\")")
  helloWorldSplit = helloWorld.split("l")
  for (splitIndex = 0; splitIndex < helloWorldSplit.length; splitIndex++) { document.write(helloWorldSplit[splitIndex] + " ") }
  document.write("helloWorld.strike".strike())
  document.write("helloWorldSubscript".sub())
 }

 function TypeOf()
 {
  document.write("1 " + typeof(1) + "<br/>")
  document.write("One " + typeof("One") + "<br/>")
  document.write("true " + typeof(true) + "<br/>")
  var newObject = new Object();
  document.write("newObject " + typeof(newObject) + "<br/>")
  document.write("TypeOf " + typeof(TypeOf) + "<br/>")
  var unknown
  document.write("unknown " + typeof(unknown) + "<br/>")
  var nullValue = null
  document.write("nullValue " + typeof(nullValue) + "<br/>")
  }
 
 function WindowAlert(message)
 {
  alert(message)
 }

 function WindowClose()
 {
  window.close()
 }

 function WindowLocation(uri)
 {
  window.location = uri
 }

 function WindowOpen(uri)
 {
  window.open(uri)
 }

 function WindowStatus(status)
 {
  window.status = status
 }
//-->
</script>