<%@ import namespace="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="mywiz" 
    Namespace="Microsoft.Web.UI.WebControls" 
    Assembly="Microsoft.Web.UI.WebControls" 
%>

<html>
 <head>
  <title>Shopping Wizard</title>
  <script language="C#" runat="server">
   public void Page_Load(Object sender, EventArgs e)
   {
    if (!IsPostBack)
    {
     SetupButtons();
    }
   }//public void Page_Load(Object sender, EventArgs e)

   public void SetupButtons()
   {
    if (Wizard.SelectedIndex == 0)
    {
     BackBtn.Visible = false;
     NextBtn.Text = "Start > ";
    }//if (Wizard.SelectedIndex == 0)
    else if (Wizard.SelectedIndex == 1)
    {
     BackBtn.Visible = true;
     NextBtn.Text = "Next >";
    }//else if (Wizard.SelectedIndex == 1)
    else if (Wizard.SelectedIndex == (Wizard.Controls.Count - 3))
    {
     NextBtn.Text = "Next >";
    }//else if (Wizard.SelectedIndex == (Wizard.Controls.Count - 3))
    else if (Wizard.SelectedIndex == (Wizard.Controls.Count - 2))
    {
     NextBtn.Text = "Finish";
    }//else if (Wizard.SelectedIndex == (Wizard.Controls.Count - 2))
    else if (Wizard.SelectedIndex == (Wizard.Controls.Count - 1))
    {
     BackBtn.Visible = false;
     NextBtn.Visible = false;
    }//else if (Wizard.SelectedIndex == (Wizard.Controls.Count - 1))
   }//public void SetupButtons()

   public void BackClick(Object sender, EventArgs e)
   {
    if (Wizard.SelectedIndex > 0)
    {
     Wizard.SelectedIndex--;
     SetupButtons();
    }//if (Wizard.SelectedIndex > 0)
   }//public void BackClick(Object sender, EventArgs e)

   public void NextClick(Object sender, EventArgs e)
   {
    if (Wizard.SelectedIndex < (Wizard.Controls.Count - 1))
    {
     Wizard.SelectedIndex++;
     SetupButtons();
     if (Wizard.SelectedIndex == (Wizard.Controls.Count - 1))
     {
      CreateReceipt();
     }//if (Wizard.SelectedIndex == (Wizard.Controls.Count - 1))
    }//if (Wizard.SelectedIndex < (Wizard.Controls.Count - 1))
   }//public void NextClick(Object sender, EventArgs e) 
   
   public void CreateReceipt()
   {
    string html = "<p>Order Number: <b>123456</b><p>Ship to:<br>";
    html += "<pre style=\"font-size:small\">" + FirstName.Text + " " + LastName.Text + "\n" + Address.Text + "</pre>";
    html += "<p>Bill to:<br>";
    if (BillShipping.Checked)
    {
     html += "<i>(Same as shipping)</i>";
    }//if (BillShipping.Checked)
    else
    {
     html += "<pre style=\"font-size:small\">" + BillFirstName.Text 
          + " " + BillLastName.Text + "\n" + BillAddress.Text + "</pre>";
    }//if !(BillShipping.Checked)
    ReceiptPane.InnerHtml = html;
   }//public void CreateReceipt()

 </script>
</head>

<body runat="server">

<h1>Sky Hooks for Sale!</h1>

<form id="theForm" runat="server">

<mywiz:MultiPage id="Wizard" runat="server" BorderWidth="1" BorderStyle="Solid" BorderColor="Gray">
<mywiz:PageView id="Cart">
<h2>Shopping Cart</h2>
<p>This is a sample checkout wizard that demonstrates the MultiPage control.</p>

<ul>
  <li>This sample not for a real application.</li>
  <li>The only thing on offer today is a Sky Hook.</li>
  <li>The shopping cart contents cannot be changed.</li>
</ul>

<p>Sky Hook (Left-hand thread)
<br>$250.00
<br>Quantity: 1
</p>
</mywiz:PageView>

<mywiz:PageView id="Shipping">
<h2>Shipping</h2>
<p>Please enter shipping information.
<table>
<tr>
<td>First Name:</td>
<td><asp:TextBox id="FirstName" runat="server" /></td>
</tr>
<tr>
<td>Last Name:</td>
<td><asp:TextBox id="LastName" runat="server" /></td>
</tr>
<tr>
<td>Address:</td>
<td><asp:TextBox id="Address" runat="server" TextMode="MultiLine" Rows="3"/></td>
</tr>
</table>
</mywiz:PageView>

<mywiz:PageView id="Billing">
<h2>Billing</h2>
<p>Please enter billing information.
<table>
<tr>
<td>Credit Card:</td>
<td><asp:TextBox id=Card runat=server /></td>
</tr>
<tr>
<td>Bill to shipping address:</td>
<td><asp:CheckBox id=BillShipping runat="server" Checked="true" /></td>
</tr>
<tr>
<td>First Name:</td>
<td><asp:TextBox id="BillFirstName" runat="server" /></td>
</tr>
<tr>
<td>Last Name:</td><td><asp:TextBox id="BillLastName" runat="server" /></td>
</tr>
<tr>
<td>Address:</td><td><asp:TextBox id="BillAddress" runat="server" TextMode="MultiLine" Rows="3"/></td>
</tr>
</table>
</mywiz:PageView>

<mywiz:PageView id="Receipt">
<h2>Receipt</h2>
<p>Sky Hook (Left-hand thread)
<br>$250.00
<br>Quantity: 1
<br>
<br>Shipping: $10.00
<br>Tax: $2.00
<br>Total: $262.00
<br>
</p>
<div id="ReceiptPane" runat="server"></div>
</mywiz:PageView>

</mywiz:MultiPage>

<asp:Button id="BackBtn" runat="server" Text="< Back" OnClick="BackClick" /> 
<asp:Button id="NextBtn" runat="server" Text="Next >" OnClick="NextClick" />

</form>
</body>