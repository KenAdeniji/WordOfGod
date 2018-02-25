<%@ Register TagPrefix="ie" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>

<html>
 <body>
  <form id="tabstrip" runat="server" method="post">
   <ie:TabStrip runat="server" targetID="MultiPage1"
    TabDefaultStyle="background-color:#000000;font-family:verdana;font-weight:bold;font-size:8pt;color:#ffffff;width:79;height:21;text-align:center"
    TabHoverStyle="background-color:#777777"
    TabSelectedStyle="background-color:#ffffff;color:#000000">
    <ie:Tab Text="Core Data"/>
    <ie:Tab Text="Social Demographics"/>
    <ie:Tab Text="Prehospital Information"/>
    <ie:Tab Text="Emergency Department"/>
    <ie:Tab Text="Inpatient Care"/>
    <ie:Tab Text="Operations"/>
    <ie:Tab Text="ICU Information"/>
    <ie:Tab Text="Instrumentation"/>
    <ie:Tab Text="Floor Information"/>
    <ie:Tab Text="Discharge Information"/>
    <ie:Tab Text="Diagnoses and Procedures"/>
    <ie:Tab Text="Complications"/>
    <ie:Tab Text="Spinal Cord Injury Information"/>
    <ie:Tab Text="QA Data"/>
    <ie:Tab Text="Follow-up"/>
   </ie:TabStrip>

   <ie:MultiPage id="MultiPage1" runat="server">
    <ie:PageView id="page1">
     This is page one
    </ie:PageView>
   <ie:PageView id="page2">
   This is page two
   </ie:PageView>
   <ie:PageView id="page3">
   This is page three
   </ie:PageView>
</ie:MultiPage>

  </form>
 </body>
</html>

