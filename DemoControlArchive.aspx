<%@ page language="C#" Debug="true" %>
<script runat="server">
 void FileUploadButton_Click(object sender, EventArgs e)
 {
  if ( Uploader.HasFile )
  {
   Uploader.SaveAs(@"C:\" + Uploader.FileName);
  }
 }
 void WizardFinished(object sender, EventArgs e)
 {
  FinalMsg.Text = "Customer service finished";
 } 
</script>

<form runat="server">

<asp:panel runat="server" scrollbars="Vertical" height="105px" style="border:solix 1px;">
 0<br />1<br />2<br />3<br />4<br />5<br />6
</asp:panel>

<asp:MultiView runat="server" id="Table">
 <asp:View runat="server" id="Employee">
  <asp:Label runat="server" text="Employee" />
 </asp:View>
 <asp:View runat="server" id="Product">
 </asp:View>
 <asp:View runat="server" id="Customer">
 </asp:View>
</asp:MultiView>

<asp:Wizard runat="server" id="BookWizard" style="border:solid 1px" width="300" height="100" onfinishbuttonclick="WizardFinished">
 <wizardSteps>
  <asp:WizardStep steptype="Start">
   <h3>Thanks for choosing this book. Please proceed with payment</h3>
  </asp:WizardStep>
  <asp:WizardStep steptype="Step">
   <h3>Payment</h3>
  </asp:WizardStep>
  <asp:WizardStep steptype="Finish">
   <h3>Thank you</h3>
  </asp:WizardStep>
  <asp:WizardStep steptype="Complete">
   <asp:label runat="server" id="FinalMsg" />
  </asp:WizardStep>
 </WizardSteps>
</asp:Wizard>

 <asp:BulletedList runat="server" bulletstyle="Square">
  <asp:ListItem>One</asp:ListItem>
  <asp:ListItem>Two</asp:ListItem>
  <asp:ListItem>Three</asp:ListItem>
 </asp:BulletedList>


 <asp:FileUpload runat="server" id="Uploader" />
 <asp:Button runat="server" text="Upload" onClick="FileUploadButton_Click" />
</form>