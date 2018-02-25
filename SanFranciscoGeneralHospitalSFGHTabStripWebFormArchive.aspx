<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.SanFranciscoGeneralHospitalSFGHTabStripPage" 
 debug="true"
%>

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
     <!--
     <asp:Label><b>Core Data</b></asp:Label>
     -->
     
     <table>
 
      <tr>
       <td><asp:Label>(1) Medical Record:</asp:Label></td>
       <td><asp:TextBox runat="server" id="TextBoxMedicalRecordPatientNo" /></td>
       <td><asp:Label>Account No.</asp:Label></td>
       <td><asp:TextBox runat="server" id="TextBoxAccountNo" /></td>
       <td><asp:Label>(2) Alt MRN</asp:Label></td>
       <td><asp:TextBox runat="server" id="TextBoxAltMRN" /></td>
       <td><asp:Button id="ButtonOpen" onclick="ButtonOpen_Click" runat="Server"  Text="Open" /></td>
      </tr> 

      <tr>
       <td><asp:Label>(3) Name (last):</asp:Label></td>
       <td><asp:TextBox runat="server" id="TextBoxNameLast" /></td>
       <td><asp:Label>(4) Name (first):</asp:Label></td>
       <td><asp:TextBox runat="server" id="TextBoxNameFirst" /></td>
      </tr>
      
      <tr>
       <td>(5)Service Category:</td>
       <td><asp:TextBox runat="server" id="TextBoxServiceCategory" columns="1" /></td>
       <td>[1]Trauma</td>
       <td>[2]Elective</td>
       <td>[3]Consult</td>
      </tr>

      <tr>
       <td>(5)Trauma Name (last):</td>
       <td><asp:TextBox runat="server" id="TextBoxTraumaNameLast" /></td>
       <td>(6)Trauma Name (first):</td>
       <td><asp:TextBox runat="server" id="TextBoxTraumaNameFirst" /></td>
      </tr>
      
      <tr>
       <td>(15)Age:</td>
       <td><asp:TextBox runat="server" id="TextBoxAge" columns="3" /></td>
       <td>(16)Date of Birth:</td>
       <td><asp:TextBox runat="server" id="TextBoxDateOfBirth" /></td>
      </tr>

      <tr>
       <td>(17)Gender:</td>
       <td><asp:TextBox runat="server" id="TextBoxGender" columns="1" /></td>
       <td>[1]Male</td>
       <td>[2]Female</td>
       <td>[3]Other</td>       
      </tr>

      <tr>
       <td>(18)Admitting Diagnosis:</td>
       <td colspan="3"><asp:TextBox runat="server" id="TextAdmittingDiagnosis" TextMode="MultiLine" Rows="4" Columns="50" /></td>
      </tr>
      
      <tr>
       <td>(31)Date of Admit:</td>
       <td><asp:TextBox runat="server" id="TextBoxDateOfAdmit" /></td>
       <td>(32)Hospital Arrival Time:</td>
       <td><asp:TextBox runat="server" id="TextBoxHospitalArrivalTime" /></td>
      </tr>

      <tr>
       <td>(33)Admitting Service:</td>
       <td><asp:TextBox runat="server" id="TextBoxAdmittingService" columns="1" /></td>
       <td>[1]Neurosurgery</td>
       <td>[2]Trauma A</td>
       <td>[3]Trauma B</td>
       <td>[4]Neurology</td>
      </tr>
      <tr>
       <td />
       <td>[5]Medicine</td>
       <td>[6]Pediatrics</td>
       <td>[7]Orthopedics</td>
       <td>[8]Other</td>
       <td><asp:TextBox runat="server" id="TextBoxAdmittingServiceOther" /></td>
      </tr>
      
      <tr>
       <td>(34)Admitting Neurosurgery Attending:</td>
       <td><asp:TextBox runat="server" id="TextBoxAdmittingNeurosurgeryAttending" columns="1" /></td>
       <td>[1]Manley</td>
       <td>{2]Holland</td>
       <td>[3]Gauger</td>
      </tr>
      <tr>
       <td />
       <td>[4]Other</td>
       <td><asp:TextBox runat="server" id="TextBoxAdmittingNeurosurgeryAttendingOther" /></td>
      </tr>

      <tr>
       <td>(34)Admitting Neurosurgery Chief:</td>
       <td><asp:TextBox runat="server" id="TextBoxAdmittingNeurosurgeryChief"  /></td>
      </tr>
      
      <tr>
       <td>(55)Ward Admitted to:</td>
       <td><asp:TextBox runat="server" id="TextBoxWardAdmittedTo" columns="1" /></td>
      </tr>
      <tr>
       <td>[1]4E</td>
       <td>[2]5E</td>
       <td>[3]5R</td>
       <td>[4]4B</td>
       <td>[5]4D</td>
      </tr> 
      <tr>
       <td>[6]5A</td>
       <td>[7]5C</td>
       <td>[8]5D</td>
       <td>[9]6A</td>
       <td>[10]7D</td>
      </tr> 
      <tr>
       <td>[11]PACU</td>
       <td>[12]Other</td>
       <td><asp:TextBox runat="server" id="TextBoxWardAdmittedToOther" /></td>
       <td>[13]Maintained in ER Waiting for Bed on:</td>
       <td><asp:TextBox runat="server" id="TextBoxMaintainedInERWaitingForBedOn" /></td>
      </tr> 

      <tr>
       <td colspan="3">(56)If maintained in ER, length of time until bed available (hrs):<td>
       <td><asp:TextBox runat="server" id="TextBoxIfMaintainedInERLengthOfTimeUntilBedAvailable" columns="4" /></td>
      </tr>
       
      <tr> 
       <td><asp:Button id="ButtonSubmit"  onclick="ButtonSubmit_Click"  runat="server"   Text="Submit"/></td>
       <td><asp:Button id="ButtonReset"   onclick="ButtonReset_Click"   runat="server"   Text="Reset"/></td>
      </tr>
      
      <tr> 
       <td><asp:Literal id="LiteralFeedback" runat="server"/></td>
      </tr>
     
     </table>  
          
    </ie:PageView>
   <ie:PageView id="page2">
    (7) Homeless [1] Yes [2] No <asp:TextBox runat="server" id="TextBoxHomeless" />
     <table>
      <tr>
       <td>(19) Race<td>
       <td align=left><asp:TextBox runat="server" id="TextBoxRace"  columns="1" /></td>
      </tr> 
      <tr>
       <td />
       <td>[1]White<td>
       <td>[5]American Indian/Alaska Native</td>
      </tr>
      <tr>
       <td />
       <td>[2]Hispanic/Latino<td>
       <td>[6]Asian</td>
      </tr>
      <tr>
       <td />
       <td>[3]Black/African American<td>
       <td>[7]Native Hawiian/Pacific Islander</td>
      </tr>
      <tr>
       <td />
       <td>[4]More than one race<td>
       <td>[8]Other/ Not Reported</td>
      </tr>
     </table> 
     
     <table>
      <tr>
       <td>(21)County <asp:TextBox runat="server" id="TextBoxCounty"  columns="1" /> </td>
       <td>[1]San Francisco</td>
       <td>[4]San Mateo</td>
       <td>[6]Alameda</td>
      </tr>
      <tr>
       <td />
       <td>[2]Contra Costa</td>
       <td>[5]Sonoma</td>
       <td>[7]Marin</td>
      </tr>
      <tr>
       <td />
       <td>[3]Other <asp:TextBox runat="server" id="TextBoxCountyOther" /></td>
      </tr>
     </table>
     
   </ie:PageView>
   
   <ie:PageView id="page3">

    <!--
     <asp:Label><b>Prehospital Information</b></asp:Label>
    -->

    Mechanism of Injury:
    <table border = 1>
     <tr>
      <td>
       <table>
        <tr>
         <td>(1)<td>
         <td><asp:TextBox runat="server" id="TextBoxMVAEcode" /></td>
         <td><b>MVA (Ecode)</b></td>
        </tr>
        <tr> 
        <td colspan=3>Function of Injured</td>
        </tr>
        <tr>
         <td/>
         <td>(1.1)</td>
         <td><asp:TextBox runat="server" id="TextBoxFunctionOfInjuredDriverEcode" /></td>
         <td>Driver <b>(ECode)</b></td>
        </tr>
        <tr>
         <td/>
         <td>(1.2)</td>
         <td><asp:TextBox runat="server" id="TextBoxFunctionOfInjuredPassFrontEcode" /></td>
         <td>Pass/Front <b>(ECode)</b></td>
        </tr>
        <tr>
         <td/>
         <td>(1.3)</td>
         <td><asp:TextBox runat="server" id="TextBoxFunctionOfInjuredPassRearEcode" /></td>
         <td>Pass/Rear <b>(ECode)</b></td></td>
        </tr>
        <tr>
         <td/>
         <td>(1.4)</td>
         <td><asp:TextBox runat="server" id="TextBoxFunctionOfInjuredUnknownEcode" /></td>
         <td>Unknown <b>(ECode)</b></td>
        </tr>
        <tr>
         <td/>
         <td>(1.5)</td>
         <td><asp:TextBox runat="server" id="TextBoxFunctionOfInjuredOtherEcode" /> 
         <td>Other <b>(ECode)</b></td>
        </tr>
       </table>
      </td>
      <td>

      <td>
       <table>
        <tr>
         <td>(4)</td>
         <td><asp:TextBox runat="server" id="TextBoxPedestrian" /></td>
         <td>Pedestrian</td>
        </tr> 
        <tr>
         <td />
         <td>(4.1)</td> 
         <td><asp:TextBox runat="server" id="TextBoxPedestrianPedvsAuto" /></td>
         <td>Ped vs Auto</td>
        </tr>
        <tr>
         <td />
         <td>(4.2)</td> 
         <td><asp:TextBox runat="server" id="TextBoxPedestrianPedvsBusMuni" /></td>
         <td>Ped vs Bus/Muni</td>
        </tr>
        <tr>
         <td />
         <td>(4.3)</td>
         <td><asp:TextBox runat="server" id="TextBoxPedestrianPedvsBike" /></td>
         <td>Ped vs Bike</td>
        </tr>
        <tr>
         <td />
         <td>(4.4)</td>
         <td><asp:TextBox runat="server" id="TextBoxPedestrianPedvsOther" /></td>
         <td>Ped vs Other</td>
        </tr>
       </table>
       </td>
      <td>

      <td>
       <table>
        <tr>
         <td>(8)</td>
         <td><asp:TextBox runat="server" id="TextBoxRollerSport" /></td>
         <td>RollerSport</td>
        </tr> 
        <tr>
         <td />
         <td>(8.1)</td>
         <td><asp:TextBox runat="server" id="TextBoxRollerSkateboard" /></td>
         <td>Skateboard</td>
        </tr>
        <tr>
         <td />
         <td>(8.2)</td>
         <td><asp:TextBox runat="server" id="TextBoxRollerBlades" />Roller Blades</td>
        </tr>
        <tr>
         <td />
         <td>(8.3)</td>
         <td><asp:TextBox runat="server" id="TextBox" /> Scooter</td>
        </tr>
       </table>
       </td>
      <td>
      </table>   
   </ie:PageView>
</ie:MultiPage>

  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxMedicalRecordPatientNo.focus();
</script>