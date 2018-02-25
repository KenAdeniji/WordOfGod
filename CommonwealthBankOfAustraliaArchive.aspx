<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.CommonwealthBankOfAustraliaPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadCommonwealthBankOfAustralia">
  <title runat="Server" id="TitleCommonwealthBankOfAustralia">Commonwealth Bank of Australia</title>
 </head>
 <body runat="server" id="BodyCommonwealthBankOfAustralia">
  <asp:Panel
   runat="server"
   id="PanelCommonwealthBankOfAustraliaTransaction"
  >
   <form 
    ID="FormCommonwealthBankOfAustralia" 
    runat="server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultbutton="ButtonSubmit"
    defaultfocus="TextBoxClientNumber"
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
         id="LabelClientNumber"
         Text="Client Number:"
         AccessKey="C"
         AssociatedControlId="TextBoxClientNumber"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxClientNumber"
         TabIndex="1"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelAccountNumber"
         Text="Account Number:"
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
         id="LabelDate"
         Text="Date:"
         AccessKey="T"
         AssociatedControlId="TextBoxDateFrom"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxDateFrom"
         TabIndex="3"
        />
        -
        <asp:TextBox
         runat="Server"
         ID="TextBoxDateTo"
         TabIndex="4"
        />        
       </td>
      </tr>


      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelDRCR"
         Text="Debit/Credit:"
         AccessKey="D"
         AssociatedControlId="DropDownListTransactionDRCR"
        />
       </td>
       <td align="left">
        <asp:DropDownList
         runat="Server"
         ID="DropDownListTransactionDRCR"
         TabIndex="5"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelDebitCredit"
         Text="Debit/Credit:"
         AccessKey="A"
         AssociatedControlId="TextBoxDebitCreditFrom"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxDebitCreditFrom"
         TabIndex="6"
        />
        -
        <asp:TextBox
         runat="Server"
         ID="TextBoxDebitCreditTo"
         TabIndex="7"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelTransactionDescription"
         Text="Transaction Description:"
         AccessKey="D"
         AssociatedControlId="TextBoxTransactionDescription"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxTransactionDescription"
         TabIndex="8"
        />
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelBalance"
         Text="Balance:"
         AccessKey="B"
         AssociatedControlId="TextBoxBalanceFrom"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxBalanceFrom"
         TabIndex="9"
        />
        -
        <asp:TextBox
         runat="Server"
         ID="TextBoxBalanceTo"
         TabIndex="10"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="center" colspan="4">
        <asp:Button runat="server" id="ButtonSubmit"  onclick="ButtonSubmit_Click"  Text="Submit" TabIndex="11" />
        <asp:Button runat="server" id="ButtonReset"   onclick="ButtonReset_Click"   Text="Reset"  TabIndex="12" />
       </td>      
       </tr>
     </tbody>
    </table>

    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td>
        <asp:SqlDataSource
         ID="SqlDataSourceCommonwealthBankOfAustraliaTransaction"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE CommonwealthBankOfAustraliaTransaction WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspCommonwealthBankOfAustraliaTransactionInsert @sequenceOrderId, @dated, @ClientNumber, @transactionDate, @transactionEffectiveDate, @DebitCredit, @transactionDRCR, @description"
         SelectCommand="EXEC uspCommonwealthBankOfAustraliaTransactionSelect @ClientNumber, @AccountNumber, @DateFrom, @DateTo, @TransactionDescription, @TransactionDRCR, @DebitCreditFrom, @DebitCreditTo, @BalanceFrom, @BalanceTo"
         UpdateCommand="UPDATE CommonwealthBankOfAustraliaTransaction SET dated = @dated, ClientNumber = @ClientNumber, transactionDate = @transactionDate, transactionEffectiveDate = @transactionEffectiveDate, DebitCredit = @DebitCredit, transactionDRCR = @transactionDRCR, description = @description WHERE sequenceOrderId = @sequenceOrderId"
        >

         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="ClientNumber" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="transactionDate" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="transactionEffectiveDate" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="DebitCredit" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="transactionDRCR" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="description" ConvertEmptyStringToNull=true Type="string" />
         </insertparameters>
         <selectparameters>
          <asp:controlparameter name="ClientNumber" controlid="TextBoxClientNumber" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="InputOutput" Defaultvalue="-1" />
          <asp:controlparameter name="AccountNumber" controlid="TextBoxAccountNumber" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="InputOutput" Defaultvalue="-1" />
          <asp:controlparameter name="DateFrom" controlid="TextBoxDateFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "1/1/1753" />
          <asp:controlparameter name="DateTo" controlid="TextBoxDateTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "12/31/9999" />
          <asp:controlparameter name="TransactionDescription" controlid="TextBoxTransactionDescription" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" DefaultValue = "|" />
          <asp:controlparameter name="TransactionDRCR" controlid="DropDownListTransactionDRCR" PropertyName="SelectedValue" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" DefaultValue = "|" />
          <asp:controlparameter name="DebitCreditFrom" controlid="TextBoxDebitCreditFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="Decimal" Direction="InputOutput" DefaultValue = "-1.00" />
          <asp:controlparameter name="DebitCreditTo" controlid="TextBoxDebitCreditTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="Decimal" Direction="InputOutput" DefaultValue = "-1" />
          <asp:controlparameter name="BalanceFrom" controlid="TextBoxBalanceFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="Decimal" Direction="InputOutput" DefaultValue = "-1" />
          <asp:controlparameter name="BalanceTo" controlid="TextBoxBalanceTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="Decimal" Direction="InputOutput" DefaultValue = "-1.00" />
         </selectparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewCommonwealthBankOfAustraliaTransaction" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         Caption="Transaction "
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceCommonwealthBankOfAustraliaTransaction"
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
           SortExpression="Dated"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewCommonwealthBankOfAustraliaTransactionItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewCommonwealthBankOfAustraliaTransactionEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Transaction Description"
           SortExpression="TransactionDescription"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewCommonwealthBankOfAustraliaTransactionItemTemplateTransactionDescription" 
             Text='<%# Eval("TransactionDescription") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewCommonwealthBankOfAustraliaTransactionEditItemTemplateTransactionDescription" 
             Text='<%# Bind("TransactionDescription") %>'
            />
           </EditItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Debit/Credit"
           SortExpression="DebitCredit"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewCommonwealthBankOfAustraliaTransactionItemTemplateDebitCredit" 
             Text='<%# Eval("DebitCredit") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewCommonwealthBankOfAustraliaTransactionEditItemTemplateDebitCredit" 
             Text='<%# Bind("DebitCredit") %>'
            />
           </EditItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Balance"
           SortExpression="Balance"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewCommonwealthBankOfAustraliaTransactionItemTemplateBalance" 
             Text='<%# PostfixDRCR( Eval("Balance") ) %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewCommonwealthBankOfAustraliaTransactionEditItemTemplateBalance" 
             Text='<%# Bind("Balance") %>'
            />
           </EditItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="SequenceOrderId"
           SortExpression="SequenceOrderId"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewCommonwealthBankOfAustraliaTransactionItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewCommonwealthBankOfAustraliaTransactionEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
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
