<%@ Page Language="C#" %>

<%@ Register Src="UpdatePanelUC_cs.ascx" TagName="WebUserControl" TagPrefix="uc1" %>

<script runat="server">
 protected void btnCopy_Click(object sender, EventArgs e)
 {
  lblFirstLineShipping.Text   = lblFirstLineBilling.Text;
  lblSecondLineShipping.Text  = lblSecondLineBilling.Text;
  lblThirdLineShipping.Text   = lblThirdLineBilling.Text;
 }
 protected void btnUC_Click(object sender, EventArgs e)
 {
  WebUserControl1.Text = "You entered: " + Server.HtmlEncode(txtMessage.Text);
 }
 protected void btnUCConditionalTrigger_Click(object sender, EventArgs e)
 {
  WebUserControlConditionalTrigger.Text = "You entered: " + Server.HtmlEncode(txtMessageConditionalTrigger.Text);
 }
 protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
 {
  String path = TreeView1.SelectedNode.DataPath;
  XmlDataSource2.XPath = path;
  DataList1.DataSource = XmlDataSource2;
  DataList1.DataBind();
 }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <title>UpdatePanel</title>
</head>
<body>
 <form id="form1" runat="server">
  <atlas:ScriptManager runat="server" ID="ScriptManager1" EnablePartialRendering="true" />
  <strong><span style="text-decoration: underline">Billing Address</span>:<br /></strong>
  <asp:Label ID="lblFirstLineBilling" runat="server" Font-Bold="False" Text="One Microsoft Way,"></asp:Label><br />
  <asp:Label ID="lblSecondLineBilling" runat="server" Text="Redmond,"></asp:Label><br />
  <asp:Label ID="lblThirdLineBilling" runat="server" Text="WA - 98052"></asp:Label><br />
  <br />
  <atlas:UpdatePanel runat="server" ID="UpdatePanel1">
   <ContentTemplate>
    <strong><span style="text-decoration: underline">Shipping Address</span>:</strong>
    <br />
    <asp:Label ID="lblFirstLineShipping" runat="server" Font-Bold="False"></asp:Label><br />
    <asp:Label ID="lblSecondLineShipping" runat="server"></asp:Label><br />
    <asp:Label ID="lblThirdLineShipping" runat="server"></asp:Label><br />
    <asp:Button ID="btnCopy" runat="server" Text="Same As Billing Address" OnClick="btnCopy_Click" CausesValidation="False" /><br />
   </ContentTemplate>
  </atlas:UpdatePanel>
  <br />

  Enter text in the textbox and click button to update user control content:
  <asp:TextBox ID="txtMessage" runat="server" />            
  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMessage"
    Display="Dynamic" ErrorMessage="Input is required" ValidationGroup="Always"></asp:RequiredFieldValidator><br />
  <br />
  <atlas:UpdatePanel runat="server" ID="UpdatePanel4">
   <ContentTemplate>
    <asp:Button ID="btnUC" runat="server" Text="Update UserControl" OnClick="btnUC_Click" /><br />
    <uc1:WebUserControl ID="WebUserControl1" runat="server" />
   </ContentTemplate>
  </atlas:UpdatePanel>
  <br />

 <atlas:UpdatePanel runat="server" ID="UpdatePanel5">
  <ContentTemplate>
   <table style="width: 556px">
    <tr>
     <td style="width: 255px">
      <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="UpdatePanelArtists.xml" XPath="Music/Artists/Timeline">
                        </asp:XmlDataSource>
                        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                            <DataBindings>
                                <asp:TreeNodeBinding DataMember="Timeline" SelectAction="SelectExpand" TextField="id" />
                                <asp:TreeNodeBinding DataMember="Artist" TextField="name" />
                            </DataBindings>
                        </asp:TreeView>
                    </td>
                    <td >

                                &nbsp;<asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="UpdatePanelArtists.xml">
                                </asp:XmlDataSource>
                                <asp:DataList ID="DataList1" runat="server">
                                  <ItemTemplate>
                                      <span style="font: 10pt verdana;"><u><b>Artist Details</b></u></span>
                                      <table width="350px" style="font: 8pt verdana">
                                        <tr><td><b>Name:</b></td><td><%# XPath("@name")%></td></tr>
                                        <tr><td><b>Top Hit:</b></td><td><%# XPath("@hitSingle")%></td></tr>
                                      </table>            
                                  </ItemTemplate>
                                </asp:DataList>
                            
                    </td>
                </tr>
            </table>
            </ContentTemplate>
            </atlas:UpdatePanel>            
            <br />

  Enter text in the textbox and click button to update user control content:
  <asp:TextBox ID="txtMessageConditionalTrigger" runat="server" />            
  <asp:RequiredFieldValidator ID="RequiredFieldValidatorConditionalTrigger" runat="server" ControlToValidate="txtMessageConditionalTrigger"
    Display="Dynamic" ErrorMessage="Input is required" ValidationGroup="ConditionalTrigger"></asp:RequiredFieldValidator><br />
  <asp:Button ID="btnUCConditionalTrigger" runat="server" Text="Update UserControl" OnClick="btnUCConditionalTrigger_Click" /><br />
  <br />
  <atlas:UpdatePanel runat="server" ID="UpdatePanelConditionalTrigger">
   <ContentTemplate>
    <uc1:WebUserControl ID="WebUserControlConditionalTrigger" runat="server" />
   </ContentTemplate>
   <Triggers>
    <atlas:ControlEventTrigger ControlID="btnUCConditionalTrigger" EventName="Click" />
    <atlas:ControlValueTrigger ControlID="txtMessageConditionalTrigger" PropertyName="Text" />
   </Triggers>
  </atlas:UpdatePanel>
  <br />

 </form>
</body>
</html> 