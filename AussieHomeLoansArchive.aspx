<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.AussieHomeLoansPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadAussieHomeLoans">
  <title runat="Server" id="TitleAussieHomeLoans">Aussie Home Loans</title>
 </head>
 <body runat="server" id="BodyAussieHomeLoans">
  <asp:Panel
   runat="server"
   id="PanelAussieHomeLoansTransactionHistory"
  >
   <form 
    ID="FormAussieHomeLoans" 
    runat="server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultbutton="ButtonSubmit"
    defaultfocus="TextBoxLoanNumber"
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
         id="LabelLoanNumber"
         Text="Loan Number:"
         AccessKey="L"
         AssociatedControlId="TextBoxLoanNumber"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxLoanNumber"
         TabIndex="1"
        />        
       </td>
      </tr>

      <tr align="center">       
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelTransactionDate"
         Text="Transaction Date:"
         AccessKey="T"
         AssociatedControlId="TextBoxTransactionDateFrom"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxTransactionDateFrom"
         TabIndex="2"
        />
        -
        <asp:TextBox
         runat="Server"
         ID="TextBoxTransactionDateTo"
         TabIndex="3"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelTransactionEffectiveDate"
         Text="Transaction Effective Date:"
         AccessKey="E"
         AssociatedControlId="TextBoxTransactionEffectiveDateFrom"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxTransactionEffectiveDateFrom"
         TabIndex="4"
        />
        -
        <asp:TextBox
         runat="Server"
         ID="TextBoxTransactionEffectiveDateTo"
         TabIndex="5"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelTransactionAmount"
         Text="Transaction Amount:"
         AccessKey="A"
         AssociatedControlId="TextBoxTransactionAmountFrom"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxTransactionAmountFrom"
         TabIndex="6"
        />
        -
        <asp:TextBox
         runat="Server"
         ID="TextBoxTransactionAmountTo"
         TabIndex="7"
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
         TabIndex="8"         
        />        
       </td>
      </tr>
      
      <tr align="center">       
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelDescription"
         Text="Description:"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxDescription"
         TabIndex="9"
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
         ID="SqlDataSourceAussieHomeLoansTransactionHistory"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE AussieHomeLoansTransactionHistory WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspAussieHomeLoansTransactionHistoryInsert @sequenceOrderId, @dated, @loanNumber, @transactionDate, @transactionEffectiveDate, @transactionAmount, @transactionDRCR, @description"
         SelectCommand="EXEC uspAussieHomeLoansTransactionHistorySelect @loanNumber, @transactionDateFrom, @transactionDateTo, @transactionEffectiveDateFrom, @transactionEffectiveDateTo, @transactionAmountFrom, @transactionAmountTo, @transactionDRCR, @description"
         UpdateCommand="UPDATE AussieHomeLoansTransactionHistory SET dated = @dated, loanNumber = @loanNumber, transactionDate = @transactionDate, transactionEffectiveDate = @transactionEffectiveDate, transactionAmount = @transactionAmount, transactionDRCR = @transactionDRCR, description = @description WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="loanNumber" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="transactionDate" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="transactionEffectiveDate" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="transactionAmount" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="transactionDRCR" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="description" ConvertEmptyStringToNull=true Type="string" />
         </insertparameters>
         <selectparameters>
          <asp:controlparameter name="loanNumber" controlid="TextBoxLoanNumber" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="InputOutput" Defaultvalue="-1" />
          <asp:controlparameter name="transactionDateFrom" controlid="TextBoxTransactionDateFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "1/1/1753" />
          <asp:controlparameter name="transactionDateTo" controlid="TextBoxTransactionDateTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "12/31/9999" />
          <asp:controlparameter name="transactionEffectiveDateFrom" controlid="TextBoxTransactionEffectiveDateFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "1/1/1753" />
          <asp:controlparameter name="transactionEffectiveDateTo" controlid="TextBoxTransactionEffectiveDateTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "12/31/9999" />
          <asp:controlparameter name="transactionAmountFrom" controlid="TextBoxTransactionAmountFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="Decimal" Direction="InputOutput" DefaultValue = "-1" />
          <asp:controlparameter name="transactionAmountTo" controlid="TextBoxTransactionAmountTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="Decimal" Direction="InputOutput" DefaultValue = "-1" />
          <asp:controlparameter name="transactionDRCR" controlid="DropDownListTransactionDRCR" PropertyName="SelectedValue" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" />
          <asp:controlparameter name="description" controlid="TextBoxDescription" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" DefaultValue = "|" />
         </selectparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewAussieHomeLoansTransactionHistory" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         AutoGenerateDeleteButton=True
         AutoGenerateEditButton=True
         Caption="Transaction History"
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceAussieHomeLoansTransactionHistory"
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
           HeaderText="Loan"
           SortExpression="LoanNumber"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansTransactionHistoryItemTemplateLoanNumber" 
             Text='<%# Eval("LoanNumber") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryEditItemTemplateLoanNumber" 
             Text='<%# Bind("LoanNumber") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateLoanNumber"
             Text='<%# Bind("LoanNumber") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Transaction"
           SortExpression="TransactionDate"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansTransactionHistoryItemTemplateTransactionDate" 
             Text='<%# Eval("TransactionDate", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryEditItemTemplateTransactionDate" 
             Text='<%# Bind("TransactionDate") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateTransactionDate"
             Text='<%# Bind("TransactionDate") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Effective"
           SortExpression="TransactionEffectiveDate"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansTransactionHistoryItemTemplateTransactionEffectiveDate" 
             Text='<%# Eval("TransactionEffectiveDate", "{0:d}") %>'             
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryEditItemTemplateTransactionEffectiveDate" 
             Text='<%# Bind("TransactionEffectiveDate") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateTransactionEffectiveDate"
             Text='<%# Bind("TransactionEffectiveDate") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Amount"
           SortExpression="TransactionAmount"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansTransactionHistoryItemTemplateTransactionAmount" 
             Text='<%# Eval("TransactionAmount") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryEditItemTemplateTransactionAmount" 
             Text='<%# Bind("TransactionAmount") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateTransactionAmount"
             Text='<%# Bind("TransactionAmount") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Debit/Credit"
           SortExpression="TransactionDRCR"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansTransactionHistoryItemTemplateTransactionDRCR" 
             Text='<%# Eval("TransactionDRCR") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:DropDownList 
             Runat="Server"
             id="DropDownListGridViewAussieHomeLoansTransactionHistoryEditItemTemplateTransactionDRCR" 
             Selectedvalue="<%# Bind('TransactionDRCR') %>"
            >
             <asp:ListItem>Debit</asp:ListItem>
             <asp:ListItem>Credit</asp:ListItem>
            </asp:DropDownList>
           </EditItemTemplate>
           <FooterTemplate>
            <asp:DropDownList 
             Runat="Server"
             id="DropDownListGridViewAussieHomeLoansTransactionHistoryFooterTemplateTransactionDRCR"
             Selectedvalue="<%# Bind('TransactionDRCR') %>"
            >
             <asp:ListItem>Debit</asp:ListItem>
             <asp:ListItem>Credit</asp:ListItem>
            </asp:DropDownList>     
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Description"
           SortExpression="Description"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansTransactionHistoryItemTemplateDescription" 
             Text='<%# Eval("Description") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:DropDownList
             Runat="Server"
             id="DropDownListGridViewAussieHomeLoansTransactionHistoryEditItemTemplateDescription"
             Selectedvalue="<%# Bind('Description') %>"
            >
             <asp:ListItem>Direct Debit Decline Fee</asp:ListItem>
             <asp:ListItem>Direct Debit Payment</asp:ListItem>
             <asp:ListItem>Dishonour Fee</asp:ListItem>
             <asp:ListItem>Interest Charge</asp:ListItem>
             <asp:ListItem>Repayment</asp:ListItem>             
            </asp:DropDownList>
           </EditItemTemplate>
           <FooterTemplate>
            <asp:DropDownList
             Runat="Server"
             id="DropDownListGridViewAussieHomeLoansTransactionHistoryFooterTemplateDescription"
             Selectedvalue="<%# Bind('Description') %>"
            >
             <asp:ListItem>Direct Debit Decline Fee</asp:ListItem>
             <asp:ListItem>Direct Debit Payment</asp:ListItem>
             <asp:ListItem>Dishonour Fee</asp:ListItem>
             <asp:ListItem>Interest Charge</asp:ListItem>
             <asp:ListItem>Repayment</asp:ListItem>             
            </asp:DropDownList>
           </FooterTemplate>
          </asp:TemplateField>
          <asp:TemplateField
           HeaderText="Dated"
           SortExpression="Dated"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansTransactionHistoryItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateDated"
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
             id="LabelGridViewAussieHomeLoansTransactionHistoryItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateSequenceOrderId"
             Text='<%# Bind("SequenceOrderId") %>'
            />
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewAussieHomeLoansTransactionHistoryFooterTemplateAdd"
             OnClick="GridViewAussieHomeLoansTransactionHistoryInsert"
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
         ID="SqlDataSourceAussieHomeLoansAccountBalance"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE AussieHomeLoansAccountBalance WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspAussieHomeLoansAccountBalanceInsert @sequenceOrderId, @dated, @loanNumber, @loanType, @interestRate, @currentBalance, @redrawAvailable, @repaymentFrequency, @repaymentAmount, @nextDueDateRepayment"
         SelectCommand="EXEC uspAussieHomeLoansAccountBalanceSelect"
         UpdateCommand="UPDATE AussieHomeLoansAccountBalance SET dated = @dated, loanNumber = @loanNumber, loanType = @loanType, interestRate = @interestRate, currentBalance = @currentBalance, redrawAvailable = @redrawAvailable, repaymentFrequency = @repaymentFrequency, repaymentAmount = @repaymentAmount, nextDueDateRepayment = @nextDueDateRepayment WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="loanNumber" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="loanType" ConvertEmptyStringToNull=true Type="String" />
          <asp:parameter name="interestRate" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="currentBalance" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="redrawAvailable" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="repaymentFrequency" ConvertEmptyStringToNull=true Type="String" />
          <asp:parameter name="repaymentAmount" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="nextDueDateRepayment" ConvertEmptyStringToNull=true Type="DateTime" />
         </insertparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewAussieHomeLoansAccountBalance" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         AutoGenerateDeleteButton=True
         AutoGenerateEditButton=True
         Caption="Account Balance"
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceAussieHomeLoansAccountBalance"
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
           HeaderText="Loan"
           SortExpression="LoanNumber"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansAccountBalanceItemTemplateLoanNumber" 
             Text='<%# Eval("LoanNumber") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceEditItemTemplateLoanNumber" 
             Text='<%# Bind("LoanNumber") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateLoanNumber"
             Text='<%# Bind("LoanNumber") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Loan Type"
           SortExpression="LoanType"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansAccountBalanceItemTemplateLoanType" 
             Text='<%# Eval("LoanType") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:DropDownList 
             Runat="Server"
             id="DropDownListGridViewAussieHomeLoansAccountBalanceEditItemTemplateLoanType" 
             Selectedvalue="<%# Bind('LoanType') %>"
            >
             <asp:ListItem>P & I Variable</asp:ListItem>
            </asp:DropDownList>
           </EditItemTemplate>
           <FooterTemplate>
            <asp:DropDownList 
             Runat="Server"
             id="DropDownListGridViewAussieHomeLoansAccountBalanceFooterTemplateLoanType" 
             Selectedvalue="<%# Bind('LoanType') %>"
            >
             <asp:ListItem>P & I Variable</asp:ListItem>
            </asp:DropDownList>
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Interest Rate"
           SortExpression="Interest Rate"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansAccountBalanceItemTemplateInterestRate" 
             Text='<%# Eval("InterestRate", "{0:C}") + "%" %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceEditItemTemplateInterestRate" 
             Text='<%# Bind("InterestRate") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateInterestRate"
             Text='<%# Bind("InterestRate") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Current Balance"
           SortExpression="Current Balance"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansAccountBalanceItemTemplateCurrentBalance" 
             Text='<%# Eval("CurrentBalance", "{0:C}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceEditItemTemplateCurrentBalance" 
             Text='<%# Bind("CurrentBalance") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateCurrentBalance"
             Text='<%# Bind("CurrentBalance") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Redraw Available"
           SortExpression="Redraw Available"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansAccountBalanceItemTemplateRedrawAvailable" 
             Text='<%# Eval("RedrawAvailable", "{0:C}") %>'             
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceEditItemTemplateRedrawAvailable" 
             Text='<%# Bind("RedrawAvailable") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateRedrawAvailable"
             Text='<%# Bind("RedrawAvailable") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Repayment Frequency"
           SortExpression="RepaymentFrequency"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansAccountBalanceItemTemplateRepaymentFrequency" 
             Text='<%# Eval("RepaymentFrequency") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:DropDownList 
             Runat="Server"
             id="DropDownListGridViewAussieHomeLoansAccountBalanceEditItemTemplateRepaymentFrequency" 
             Selectedvalue="<%# Bind('RepaymentFrequency') %>"
            >
             <asp:ListItem>Monthtly</asp:ListItem>
             <asp:ListItem>Fortnightly</asp:ListItem>
            </asp:DropDownList>
           </EditItemTemplate>
           <FooterTemplate>
            <asp:DropDownList 
             Runat="Server"
             id="DropDownListGridViewAussieHomeLoansAccountBalanceFooterTemplateRepaymentFrequency" 
             Selectedvalue="<%# Bind('RepaymentFrequency') %>"
            >
             <asp:ListItem>Monthtly</asp:ListItem>
             <asp:ListItem>Fortnightly</asp:ListItem>
            </asp:DropDownList>
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Repayment Amount"
           SortExpression="RepaymentAmount"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansAccountBalanceItemTemplateRepaymentAmount" 
             Text='<%# Eval("RepaymentAmount", "{0:C}") %>'             
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceEditItemTemplateRepaymentAmount" 
             Text='<%# Bind("RepaymentAmount") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateRepaymentAmount"
             Text='<%# Bind("RepaymentAmount") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>
          
          <asp:TemplateField
           HeaderText="Next Due Date Repayment"
           SortExpression="NextDueDateRepayment"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansAccountBalanceItemTemplateNextDueDateRepayment" 
             Text='<%# Eval("NextDueDateRepayment", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceEditItemTemplateNextDueDateRepayment" 
             Text='<%# Bind("NextDueDateRepayment") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateNextDueDateRepayment"
             Text='<%# Bind("NextDueDateRepayment") %>'
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
             id="LabelGridViewAussieHomeLoansAccountBalanceItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateDated"
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
             id="LabelGridViewAussieHomeLoansAccountBalanceItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateSequenceOrderId"
             Text='<%# Bind("SequenceOrderId") %>'
            />
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewAussieHomeLoansAccountBalanceFooterTemplateAdd"
             OnClick="GridViewAussieHomeLoansAccountBalanceInsert" 
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
         ID="SqlDataSourceAussieHomeLoansStatement"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE AussieHomeLoansStatement WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspAussieHomeLoansStatementInsert @sequenceOrderId, @dated, @loanNumber, @date, @description, @debit, @credit, @balance"
         SelectCommand="EXEC uspAussieHomeLoansStatementSelect"
         UpdateCommand="UPDATE AussieHomeLoansStatement SET dated = @dated, loanNumber = @loanNumber, date = @date, description = @description, debit = @debit, credit = @credit, balance = @balance WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="loanNumber" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="date" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="description" ConvertEmptyStringToNull=true Type="String" />
          <asp:parameter name="debit" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="credit" ConvertEmptyStringToNull=true Type="Decimal" />
          <asp:parameter name="balance" ConvertEmptyStringToNull=true Type="Decimal" />
         </insertparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewAussieHomeLoansStatement" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         AutoGenerateDeleteButton=True
         AutoGenerateEditButton=True
         Caption="Statement"
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceAussieHomeLoansStatement"
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
           HeaderText="Loan"
           SortExpression="LoanNumber"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansStatementItemTemplateLoanNumber" 
             Text='<%# Eval("LoanNumber") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementEditItemTemplateLoanNumber" 
             Text='<%# Bind("LoanNumber") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementFooterTemplateLoanNumber"
             Text='<%# Bind("LoanNumber") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Date"
           SortExpression="Date"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewAussieHomeLoansStatementItemTemplateDate" 
             Text='<%# Eval("Date", "{0:dd MMM yyyy}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementEditItemTemplateDate" 
             Text='<%# Bind("Date", "{0:dd MMM yyyy}") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementFooterTemplateDate"
             Text='<%# Bind("Date", "{0:dd MMM yyyy}") %>'
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
             id="LabelGridViewAussieHomeLoansStatementItemTemplateDescription" 
             Text='<%# Eval("Description") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
<%--       
            <asp:DropDownList 
             Runat="Server"
             id="DropDownListGridViewAussieHomeLoansStatementEditItemTemplateDescription" 
             Selectedvalue="<%# Bind('Description') %>"
            >
             <asp:ListItem>Direct Debit Payment</asp:ListItem>
             <asp:ListItem>Interest Charged</asp:ListItem>
             <asp:ListItem>Opening Balance</asp:ListItem>
             <asp:ListItem>Transaction Fee</asp:ListItem>
            </asp:DropDownList>
--%>            
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementEditItemTemplateDescription" 
             Text='<%# Bind("Description") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
<%--
            <asp:DropDownList 
             Runat="Server"
             id="DropDownListGridViewAussieHomeLoansStatementFooterTemplateDescription" 
             Selectedvalue="<%# Bind('Description') %>"
            >
             <asp:ListItem>Direct Debit Payment</asp:ListItem>
             <asp:ListItem>Interest Charged</asp:ListItem>
             <asp:ListItem>Opening Balance</asp:ListItem>
             <asp:ListItem>Transaction Fee</asp:ListItem>
            </asp:DropDownList>
--%>            
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementFooterTemplateDescription" 
             Text='<%# Bind("Description") %>'
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
             id="LabelGridViewAussieHomeLoansStatementItemTemplateDebit" 
             Text='<%# Eval("Debit", "{0:N}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementEditItemTemplateDebit" 
             Text='<%# Bind("Debit") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementFooterTemplateDebit"
             Text='<%# Bind("Debit") %>'
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
             id="LabelGridViewAussieHomeLoansStatementItemTemplateCredit" 
             Text='<%# Eval("Credit", "{0:N}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementEditItemTemplateCredit" 
             Text='<%# Bind("Credit") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementFooterTemplateCredit"
             Text='<%# Bind("Credit") %>'
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
             id="LabelGridViewAussieHomeLoansStatementItemTemplateBalance" 
             Text='<%# PostfixDRCR( Eval("Balance") ) %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementEditItemTemplateBalance" 
             Text='<%# Bind("Balance") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementFooterTemplateBalance"
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
             id="LabelGridViewAussieHomeLoansStatementItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementFooterTemplateDated"
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
             id="LabelGridViewAussieHomeLoansStatementItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewAussieHomeLoansStatementFooterTemplateSequenceOrderId"
             Text='<%# Bind("SequenceOrderId") %>'
            />
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewAussieHomeLoansStatementFooterTemplateAdd"
             onclick="GridViewAussieHomeLoansStatementInsert"
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
