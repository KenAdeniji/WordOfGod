<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.LJHookerPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadLJHooker">
  <title runat="Server" id="TitleLJHooker">L.J. Hooker</title>
 </head>
 <body runat="server" id="BodyLJHooker">
  <asp:Panel
   runat="server"
   id="PanelLJHookerTaxInvoice"
  >
   <form 
    ID="FormLJHooker" 
    runat="server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultbutton="ButtonSubmit"
    defaultfocus="TextBoxDX"
   >
    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td align="center" colspan=4>
        Search Query
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelDX"
         Text="DX:"
         AccessKey="D"
         AssociatedControlId="TextBoxDX"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxDX"
         TabIndex="1"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelAccountNumber"
         Text="Account:"
         AccessKey="A"
         AssociatedControlId="TextBoxAccountNumber"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxAccountNumber"
         TabIndex="2"
        />        
       </td>
      </tr>

      <tr align="center">       
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelReference"
         Text="Reference:"
         AccessKey="R"
         AssociatedControlId="TextBoxReferenceFrom"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxReferenceFrom"
         TabIndex="3"
        />
        -
        <asp:TextBox
         runat="Server"
         ID="TextBoxReferenceTo"
         TabIndex="4"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelDetails"
         Text="Details:"
         AccessKey="D"
         AssociatedControlId="TextBoxDetails"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxDetails"
         TabIndex="5"
        />
       </td>
      </tr>

      <tr align="center">
       <td align="center" colspan="4">
        <asp:Button runat="server" id="ButtonSubmit"  onclick="ButtonSubmit_Click"  Text="Submit" TabIndex="10" />
        <asp:Button runat="server" id="ButtonReset"   onclick="ButtonReset_Click"   Text="Reset"  TabIndex="11" />
       </td>      
       </tr>
     </tbody>
    </table>

    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td>
        <asp:SqlDataSource
         ID="SqlDataSourceLJHookerTaxInvoice"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE LJHookerTaxInvoice WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspLJHookerTaxInvoiceInsert @sequenceOrderId, @dated, @DX, @AccountNumber, @Reference, @Details, @Debit, @DebitIncGST, @Credit, @CreditIncGST"
         SelectCommand="EXEC uspLJHookerTaxInvoiceSelect @DX, @AccountNumber"
         UpdateCommand="SET DATEFORMAT dmy; UPDATE LJHookerTaxInvoice SET dated = @dated, DX = @DX, AccountNumber = @AccountNumber, Reference = @Reference, Details = @Details, Debit = @Debit, DebitIncGST = @DebitIncGST, Credit = @Credit, CreditIncGST = @CreditIncGST WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="DX" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="accountNumber" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="Reference" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="Details" ConvertEmptyStringToNull=true Type="string" />          
          <asp:parameter name="Debit" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="DebitIncGST" ConvertEmptyStringToNull=true Type="Decimal" />          
          <asp:parameter name="Credit" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="CreditIncGST" ConvertEmptyStringToNull=true Type="Decimal" />
         </insertparameters>
         <selectparameters>
          <asp:controlparameter name="DX" controlid="TextBoxDX" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" DefaultValue = "|" />
          <asp:controlparameter name="AccountNumber" controlid="TextBoxAccountNumber" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="InputOutput" DefaultValue = "-1" />
<%--
          <asp:controlparameter name="ReferenceFrom" controlid="TextBoxReferenceFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "1/1/1753" />
          <asp:controlparameter name="ReferenceTo" controlid="TextBoxReferenceTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "12/31/9999" />
          <asp:controlparameter name="Details" controlid="TextBoxDetails" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" DefaultValue = "|" />
--%>
         </selectparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewLJHookerTaxInvoice" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         AutoGenerateDeleteButton=True
         AutoGenerateEditButton=True
         Caption="Tax Invoice"
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceLJHookerTaxInvoice"
         OnRowUpdated="GridView_RowUpdated"
         SelectedIndex=0
         ShowFooter=True
        >
         <HeaderStyle
          BackColor='#CCCC99'/>

         <RowStyle
          BackColor='#eeeeee'/>
			
         <AlternatingRowStyle
          BackColor='#ffffe8'/>

         <Columns>

          <asp:TemplateField
           HeaderText="DX"
           SortExpression="DX"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewLJHookerTaxInvoiceItemTemplateDX" 
             Text='<%# Eval("DX") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceEditItemTemplateDX" 
             Text='<%# Bind("DX") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceFooterTemplateDX"
             Text='<%# Bind("DX") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Account"
           SortExpression="AccountNumber"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewLJHookerTaxInvoiceItemTemplateAccountNumber" 
             Text='<%# Eval("AccountNumber") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceEditItemTemplateAccountNumber" 
             Text='<%# Bind("AccountNumber") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceFooterTemplateAccountNumber"
             Text='<%# Bind("AccountNumber") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Reference"
           SortExpression="Reference"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewLJHookerTaxInvoiceItemTemplateReference" 
             Text='<%# Eval("Reference", "{0:d/M/yy}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceEditItemTemplateReference" 
             Text='<%# Bind("Reference", "{0:d/M/yy}") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceFooterTemplateReference"
             Text='<%# Bind("Reference","{0:d/M/yy}") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Details"
           SortExpression="Details"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewLJHookerTaxInvoiceItemTemplateDetails" 
             Text='<%# Eval("Details") %>'             
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceEditItemTemplateDetails" 
             Text='<%# Bind("Details") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceFooterTemplateDetails"
             Text='<%# Bind("Details") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Debit"
           SortExpression="Debit"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewLJHookerTaxInvoiceItemTemplateDebit" 
             Text='<%# Eval("Debit", "{0:c}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceEditItemTemplateDebit" 
             Text='<%# Bind("Debit") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceFooterTemplateDebit"
             Text='<%# Bind("Debit") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="inc-GST"
           SortExpression="DebitIncGST"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewLJHookerTaxInvoiceItemTemplateDebitIncGST" 
             Text='<%# Eval("DebitIncGST", "{0:c}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceEditItemTemplateDebitIncGST" 
             Text='<%# Bind("DebitIncGST") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceFooterTemplateDebitIncGST"
             Text='<%# Bind("DebitIncGST") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Credit"
           SortExpression="Credit"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewLJHookerTaxInvoiceItemTemplateCredit" 
             Text='<%# Eval("Credit", "{0:c}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceEditItemTemplateCredit" 
             Text='<%# Bind("Credit") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceFooterTemplateCredit"
             Text='<%# Bind("Credit") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="inc-GST"
           SortExpression="CreditIncGST"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewLJHookerTaxInvoiceItemTemplateCreditIncGST" 
             Text='<%# Eval("CreditIncGST", "{0:c}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceEditItemTemplateCreditIncGST" 
             Text='<%# Bind("CreditIncGST") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceFooterTemplateCreditIncGST"
             Text='<%# Bind("CreditIncGST") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Dated"
           SortExpression="Dated"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewLJHookerTaxInvoiceItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceFooterTemplateDated"
             Text='<%# Bind("Dated") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="SequenceOrderId"
           SortExpression="SequenceOrderId"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewLJHookerTaxInvoiceItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewLJHookerTaxInvoiceFooterTemplateSequenceOrderId"
             Text='<%# Bind("SequenceOrderId") %>'
            />
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewLJHookerTaxInvoiceFooterTemplateAdd"
             OnClick="GridViewLJHookerTaxInvoiceInsert"
             Text="Add"
            />
           </FooterTemplate>
          </asp:TemplateField>
         
         </Columns>
         <pagersettings 
          mode="Numeric"
          position="Bottom"           
          pagebuttoncount="10"
         />
         <pagerstyle 
          backcolor="LightBlue"
          height="30px"
          verticalalign="Bottom"
          horizontalalign="Center"
         />
        </asp:GridView>
       </td>
      </tr>
     </tbody>
    </table>

    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td>
        <asp:SqlDataSource
         ID="SqlDataSourceNobleHomesLevyNotice"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE NobleHomesLevyNotice WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspNobleHomesLevyNoticeInsert @sequenceOrderId, @dated, @date, @description, @admin, @sinking, @misc, @total, @balance"
         SelectCommand="EXEC uspNobleHomesLevyNoticeSelect"
         UpdateCommand="SET DATEFORMAT dmy; UPDATE NobleHomesLevyNotice SET dated = @dated, date = @date, description = @description, admin = @admin, sinking = @sinking, misc = @misc, total = @total, balance = @balance WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="date" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="description" ConvertEmptyStringToNull=true Type="String" />
          <asp:parameter name="Admin" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="Sinking" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="Misc" ConvertEmptyStringToNull=true Type="Decimal" />          
          <asp:parameter name="Total" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="Balance" ConvertEmptyStringToNull=true Type="Decimal" />
         </insertparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewNobleHomesLevyNotice" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         AutoGenerateDeleteButton=True
         AutoGenerateEditButton=True
         Caption="Noble Homes Levy Notice"
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceNobleHomesLevyNotice"
         OnRowUpdated="GridView_RowUpdated"
         SelectedIndex=0
         ShowFooter=True
        >
         <HeaderStyle
          BackColor='#CCCC99'/>

         <RowStyle
          BackColor='#eeeeee'/>
			
         <AlternatingRowStyle
          BackColor='#ffffe8'/>

         <Columns>

          <asp:TemplateField
           HeaderText="Date"
           SortExpression="Date"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewNobleHomesLevyNoticeItemTemplateDate" 
             Text='<%# Eval("Date", "{0:dd/MM/yy}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeEditItemTemplateDate" 
             Text='<%# Bind("Date", "{0:dd/MM/yy}") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeFooterTemplateDate"
             Text='<%# Bind("Date","{0:dd/MM/yy}") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Description"
           SortExpression="Description"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewNobleHomesLevyNoticeItemTemplateDescription" 
             Text='<%# Eval("Description") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeEditItemTemplateDescription" 
             Text='<%# Bind("Description") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeFooterTemplateDescription"
             Text='<%# Bind("Description") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Admin"
           SortExpression="Admin"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewNobleHomesLevyNoticeItemTemplateAdmin" 
             Text='<%# Eval("Admin", "{0:N}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeEditItemTemplateAdmin" 
             Text='<%# Bind("Admin") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeFooterTemplateAdmin"
             Text='<%# Bind("Admin") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Sinking"
           SortExpression="Sinking"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewNobleHomesLevyNoticeItemTemplateSinking" 
             Text='<%# Eval("Sinking", "{0:N}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeEditItemTemplateSinking" 
             Text='<%# Bind("Sinking") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeFooterTemplateSinking"
             Text='<%# Bind("Sinking") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Misc"
           SortExpression="Misc"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewNobleHomesLevyNoticeItemTemplateMisc" 
             Text='<%# Eval("Misc", "{0:N}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeEditItemTemplateMisc" 
             Text='<%# Bind("Misc") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeFooterTemplateMisc"
             Text='<%# Bind("Misc") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Total"
           SortExpression="Total"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewNobleHomesLevyNoticeItemTemplateTotal" 
             Text='<%# Eval("Total", "{0:N}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeEditItemTemplateTotal" 
             Text='<%# Bind("Total") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeFooterTemplateTotal"
             Text='<%# Bind("Total") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Balance"
           SortExpression="Balance"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewNobleHomesLevyNoticeItemTemplateBalance" 
             Text='<%# Eval("Balance", "{0:N}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeEditItemTemplateBalance" 
             Text='<%# Bind("Balance") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeFooterTemplateBalance"
             Text='<%# Bind("Balance") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Dated"
           SortExpression="Dated"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewNobleHomesLevyNoticeItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeFooterTemplateDated"
             Text='<%# Bind("Dated") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="SequenceOrderId"
           SortExpression="SequenceOrderId"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewNobleHomesLevyNoticeItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewNobleHomesLevyNoticeFooterTemplateSequenceOrderId"
             Text='<%# Bind("SequenceOrderId") %>'
            />
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewNobleHomesLevyNoticeFooterTemplateAdd"
             OnClick="GridViewNobleHomesLevyNoticeInsert"
             Text="Add"
            />
           </FooterTemplate>
          </asp:TemplateField>
         
         </Columns>
         <pagersettings 
          mode="Numeric"
          position="Bottom"           
          pagebuttoncount="10"
         />
         <pagerstyle 
          backcolor="LightBlue"
          height="30px"
          verticalalign="Bottom"
          horizontalalign="Center"
         />
        </asp:GridView>
       </td>
      </tr>
     </tbody>
    </table>    

    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td>
        <asp:SqlDataSource
         ID="SqlDataSourceJAFlevarisRealtyTrustReceipt"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE JAFlevarisRealtyTrustReceipt WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspJAFlevarisRealtyTrustReceiptInsert @sequenceOrderId, @dated, @date, @description, @admin, @sinking, @unallocated, @outstanding, @interest, @paid"
         SelectCommand="EXEC uspJAFlevarisRealtyTrustReceiptSelect"
         UpdateCommand="SET DATEFORMAT dmy; UPDATE JAFlevarisRealtyTrustReceipt SET dated = @dated, date = @date, description = @description, admin = @admin, sinking = @sinking, unallocated = @unallocated, outstanding = @outstanding, interest = @interest, paid = @paid WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="date" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="description" ConvertEmptyStringToNull=true Type="String" />
          <asp:parameter name="Admin" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="Sinking" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="unallocated" ConvertEmptyStringToNull=true Type="Decimal" />          
          <asp:parameter name="outstanding" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="interest" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="paid" ConvertEmptyStringToNull=true Type="Decimal" />
         </insertparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewJAFlevarisRealtyTrustReceipt" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         AutoGenerateDeleteButton=True
         AutoGenerateEditButton=True
         Caption="J.A. Flevaris Realty Trust Receipt"
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceJAFlevarisRealtyTrustReceipt"
         OnRowUpdated="GridView_RowUpdated"
         SelectedIndex=0
         ShowFooter=True
        >
         <HeaderStyle
          BackColor='#CCCC99'/>

         <RowStyle
          BackColor='#eeeeee'/>
			
         <AlternatingRowStyle
          BackColor='#ffffe8'/>

         <Columns>

          <asp:TemplateField
           HeaderText="Date"
           SortExpression="Date"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewJAFlevarisRealtyTrustReceiptItemTemplateDate" 
             Text='<%# Eval("Date", "{0:dd/MM/yy}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptEditItemTemplateDate" 
             Text='<%# Bind("Date", "{0:dd/MM/yy}") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateDate"
             Text='<%# Bind("Date","{0:dd/MM/yy}") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Description"
           SortExpression="Description"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewJAFlevarisRealtyTrustReceiptItemTemplateDescription" 
             Text='<%# Eval("Description") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptEditItemTemplateDescription" 
             Text='<%# Bind("Description") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateDescription"
             Text='<%# Bind("Description") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Admin"
           SortExpression="Admin"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewJAFlevarisRealtyTrustReceiptItemTemplateAdmin" 
             Text='<%# Eval("Admin", "{0:c}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptEditItemTemplateAdmin" 
             Text='<%# Bind("Admin") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateAdmin"
             Text='<%# Bind("Admin") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Sinking"
           SortExpression="Sinking"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewJAFlevarisRealtyTrustReceiptItemTemplateSinking" 
             Text='<%# Eval("Sinking", "{0:c}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptEditItemTemplateSinking" 
             Text='<%# Bind("Sinking") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateSinking"
             Text='<%# Bind("Sinking") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Unallocated"
           SortExpression="unallocated"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewJAFlevarisRealtyTrustReceiptItemTemplateunallocated" 
             Text='<%# Eval("unallocated", "{0:c}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptEditItemTemplateunallocated" 
             Text='<%# Bind("unallocated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateunallocated"
             Text='<%# Bind("unallocated") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Outstanding"
           SortExpression="outstanding"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewJAFlevarisRealtyTrustReceiptItemTemplateoutstanding" 
             Text='<%# Eval("outstanding", "{0:c}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptEditItemTemplateoutstanding" 
             Text='<%# Bind("outstanding") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateoutstanding"
             Text='<%# Bind("outstanding") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Interest"
           SortExpression="interest"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewJAFlevarisRealtyTrustReceiptItemTemplateinterest" 
             Text='<%# Eval("interest", "{0:c}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptEditItemTemplateinterest" 
             Text='<%# Bind("interest") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateinterest"
             Text='<%# Bind("interest") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Paid"
           SortExpression="paid"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewJAFlevarisRealtyTrustReceiptItemTemplatepaid" 
             Text='<%# Eval("paid", "{0:c}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptEditItemTemplatepaid" 
             Text='<%# Bind("paid") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplatepaid"
             Text='<%# Bind("paid") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Dated"
           SortExpression="Dated"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewJAFlevarisRealtyTrustReceiptItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateDated"
             Text='<%# Bind("Dated") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="SequenceOrderId"
           SortExpression="SequenceOrderId"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewJAFlevarisRealtyTrustReceiptItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateSequenceOrderId"
             Text='<%# Bind("SequenceOrderId") %>'
            />
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewJAFlevarisRealtyTrustReceiptFooterTemplateAdd"
             OnClick="GridViewJAFlevarisRealtyTrustReceiptInsert"
             Text="Add"
            />
           </FooterTemplate>
          </asp:TemplateField>
         
         </Columns>
         <pagersettings 
          mode="Numeric"
          position="Bottom"           
          pagebuttoncount="10"
         />
         <pagerstyle 
          backcolor="LightBlue"
          height="30px"
          verticalalign="Bottom"
          horizontalalign="Center"
         />
        </asp:GridView>
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
         runat="server" 
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
