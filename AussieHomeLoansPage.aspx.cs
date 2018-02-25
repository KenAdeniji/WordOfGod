using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>AussieHomeLoansPage</summary>
 public class AussieHomeLoansPage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>DropDownListTransactionDRCR</summary>  
  protected System.Web.UI.WebControls.DropDownList           DropDownListTransactionDRCR;

  /// <summary>GridViewAussieHomeLoansAccountBalance</summary>
  protected System.Web.UI.WebControls.GridView               GridViewAussieHomeLoansAccountBalance;

  /// <summary>GridViewAussieHomeLoansStatement</summary>
  protected System.Web.UI.WebControls.GridView               GridViewAussieHomeLoansStatement;
  
  /// <summary>GridViewAussieHomeLoansTransactionHistory</summary>
  protected System.Web.UI.WebControls.GridView               GridViewAussieHomeLoansTransactionHistory;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceAussieHomeLoansAccountBalance</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceAussieHomeLoansAccountBalance;

  /// <summary>SqlDataSourceAussieHomeLoansStatement</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceAussieHomeLoansStatement;

  /// <summary>SqlDataSourceAussieHomeLoansTransactionHistory</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceAussieHomeLoansTransactionHistory;

  /// <summary>TextBoxTransactionAmountFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxTransactionAmountFrom;

  /// <summary>TextBoxTransactionAmountTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxTransactionAmountTo;
  
  /// <summary>TextBoxDescription</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDescription;
  
  /// <summary>TextBoxLoanNumber</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxLoanNumber;

  /// <summary>TextBoxTransactionDateFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxTransactionDateFrom;

  /// <summary>TextBoxTransactionDateTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxTransactionDateTo;

  /// <summary>TextBoxTransactionEffectiveDateFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxTransactionEffectiveDateFrom;

  /// <summary>TextBoxTransactionEffectiveDateTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxTransactionEffectiveDateTo;

  /// <summary>DRCR</summary>
  public static string[] DRCR = new string[] { "Debit", "Credit" };

  /// <summary>EmptyDRCR</summary>
  public static string[] EmptyDRCR = new string[] { " ", "Debit", "Credit" };
  
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  )
  {
   if ( !Page.IsPostBack )
   {
    DropDownListTransactionDRCR.DataSource = EmptyDRCR;
    DropDownListTransactionDRCR.DataBind();
    GridViewAussieHomeLoansTransactionHistory.Focus();
    Page.SetFocus( GridViewAussieHomeLoansTransactionHistory );
   }
  }

  /// <summary>Feedback.</summary>
  public String Feedback
  {
   get
   {
    return ( LiteralFeedback.Text);
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public String public String Feedback

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   GridViewAussieHomeLoansTransactionHistory.DataBind();
   GridViewAussieHomeLoansAccountBalance.DataBind();   
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Feedback                                  =  null;
   TextBoxDescription.Text                   =  null;
   TextBoxLoanNumber.Text                    =  null;
   TextBoxTransactionAmountFrom.Text         =  null;
   TextBoxTransactionAmountTo.Text           =  null;   
   TextBoxTransactionDateFrom.Text           =  null;
   TextBoxTransactionDateTo.Text             =  null;   
   TextBoxTransactionEffectiveDateFrom.Text  =  null;
   TextBoxTransactionEffectiveDateTo.Text    =  null;   
   Page.SetFocus( DropDownListTransactionDRCR );
  }//public void ButtonReset_Click()

  /// <summary>GridView_RowUpdated</summary>
  public void GridView_RowUpdated
  (
   Object                    sender, 
   GridViewUpdatedEventArgs  e
  )
  {
   // Use the Exception property to determine whether an exception
   // occurred during the insert operation.
   if ( e.Exception != null )
   {
    // Insert the code to handle the exception.
    Feedback = e.Exception.Message;

    // Use the ExceptionHandled property to indicate that the 
    // exception is already handled.
    e.ExceptionHandled = true;

    // When an exception occurs, keep the GridView
    // control in edit mode.
    e.KeepInEditMode = true;
   }//if ( GridViewUpdatedEventArgs.Exception != null )
  }

  /// <summary>
  ///  GridViewAussieHomeLoansAccountBalanceInsert()
  /// </summary>
  public void GridViewAussieHomeLoansAccountBalanceInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       loanNumber;
   int       sequenceOrderId;
   DateTime  dated;
   DateTime  nextDueDateRepayment;   
   Decimal   currentBalance;
   Decimal   interestRate;
   Decimal   redrawAvailable;   
   Decimal   repaymentAmount;
   string    loanType;
   string    exceptionMessage = null;
   string    repaymentFrequency;
   string    value;   
 
   try
   {
   	value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansAccountBalance.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceAussieHomeLoansAccountBalance.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansAccountBalance.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceAussieHomeLoansAccountBalance.InsertParameters["dated"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansAccountBalance.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateLoanNumber")).Text;
    if ( Int32.TryParse( value, out loanNumber ) )
    {
     SqlDataSourceAussieHomeLoansAccountBalance.InsertParameters["loanNumber"].DefaultValue = value;
    }
    loanType = ( ( System.Web.UI.WebControls.DropDownList ) GridViewAussieHomeLoansAccountBalance.FooterRow.FindControl("DropDownListGridViewAussieHomeLoansAccountBalanceFooterTemplateLoanType")).SelectedValue;
    SqlDataSourceAussieHomeLoansAccountBalance.InsertParameters["loanType"].DefaultValue = loanType;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansAccountBalance.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateInterestRate")).Text;
    if ( Decimal.TryParse( value, out interestRate ) )
    {
     SqlDataSourceAussieHomeLoansAccountBalance.InsertParameters["interestRate"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansAccountBalance.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateCurrentBalance")).Text;
    if ( Decimal.TryParse( value, out currentBalance ) )
    {
     SqlDataSourceAussieHomeLoansAccountBalance.InsertParameters["currentBalance"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansAccountBalance.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateRedrawAvailable")).Text;
    if ( Decimal.TryParse( value, out redrawAvailable ) )
    {
     SqlDataSourceAussieHomeLoansAccountBalance.InsertParameters["redrawAvailable"].DefaultValue = value;
    }
    repaymentFrequency  =  ( ( System.Web.UI.WebControls.DropDownList ) GridViewAussieHomeLoansAccountBalance.FooterRow.FindControl("DropDownListGridViewAussieHomeLoansAccountBalanceFooterTemplateRepaymentFrequency")).SelectedValue;
    SqlDataSourceAussieHomeLoansAccountBalance.InsertParameters["repaymentFrequency"].DefaultValue = repaymentFrequency;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansAccountBalance.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateRepaymentAmount")).Text;
    if ( Decimal.TryParse( value, out repaymentAmount ) )
    {
     SqlDataSourceAussieHomeLoansAccountBalance.InsertParameters["repaymentAmount"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansAccountBalance.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansAccountBalanceFooterTemplateNextDueDateRepayment")).Text;
    if ( DateTime.TryParse( value, out nextDueDateRepayment ) )
    {
     SqlDataSourceAussieHomeLoansAccountBalance.InsertParameters["nextDueDateRepayment"].DefaultValue = value;
    }
    SqlDataSourceAussieHomeLoansAccountBalance.Insert();
    GridViewAussieHomeLoansAccountBalance.DataBind();
   }
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   	return;
   }
  }

  /// <summary>
  ///  GridViewAussieHomeLoansStatementInsert()
  /// </summary>
  public void GridViewAussieHomeLoansStatementInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       loanNumber;
   int       sequenceOrderId;
   DateTime  date;
   DateTime  dated;
   Decimal   balance;
   Decimal   credit;
   Decimal   debit;
   string    description;
   string    exceptionMessage = null;
   string    value;
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansStatement.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansStatementFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceAussieHomeLoansStatement.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansStatement.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansStatementFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceAussieHomeLoansStatement.InsertParameters["dated"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansStatement.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansStatementFooterTemplateLoanNumber")).Text;
    if ( Int32.TryParse( value, out loanNumber ) )
    {
     SqlDataSourceAussieHomeLoansStatement.InsertParameters["loanNumber"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansStatement.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansStatementFooterTemplateDate")).Text;
    if ( DateTime.TryParse( value, out date ) )
    {
     SqlDataSourceAussieHomeLoansStatement.InsertParameters["date"].DefaultValue = value;
    }
    //description = (( System.Web.UI.WebControls.DropDownList ) GridViewAussieHomeLoansStatement.FooterRow.FindControl("DropDownListGridViewAussieHomeLoansStatementFooterTemplateDescription")).SelectedValue;
    description = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansStatement.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansStatementFooterTemplateDescription")).Text;
    SqlDataSourceAussieHomeLoansStatement.InsertParameters["description"].DefaultValue = description;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansStatement.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansStatementFooterTemplateDebit")).Text;
    if ( Decimal.TryParse( value, out debit ) )
    {
     SqlDataSourceAussieHomeLoansStatement.InsertParameters["debit"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansStatement.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansStatementFooterTemplateCredit")).Text;
    if ( Decimal.TryParse( value, out credit ) )
    {
     SqlDataSourceAussieHomeLoansStatement.InsertParameters["credit"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansStatement.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansStatementFooterTemplateBalance")).Text;
    if ( Decimal.TryParse( value, out balance ) )
    {
     SqlDataSourceAussieHomeLoansStatement.InsertParameters["balance"].DefaultValue = value;
    }
    SqlDataSourceAussieHomeLoansStatement.Insert();
    GridViewAussieHomeLoansStatement.DataBind();
   }
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   	return;
   }
  }

  /// <summary>
  ///  GridViewAussieHomeLoansTransactionHistoryInsert
  /// </summary>
  public void GridViewAussieHomeLoansTransactionHistoryInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       loanNumber;
   int       sequenceOrderId;
   DateTime  dated;
   DateTime  transactionDate;
   DateTime  transactionEffectiveDate;
   Decimal   transactionAmount;
   string    description;
   string    exceptionMessage = null;
   string    transactionDRCR;
   string    value;             
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansTransactionHistory.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceAussieHomeLoansTransactionHistory.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansTransactionHistory.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceAussieHomeLoansTransactionHistory.InsertParameters["dated"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansTransactionHistory.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateLoanNumber")).Text;
    if ( Int32.TryParse( value, out loanNumber ) )
    {
     SqlDataSourceAussieHomeLoansTransactionHistory.InsertParameters["loanNumber"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansTransactionHistory.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateTransactionDate")).Text;
    if ( DateTime.TryParse( value, out transactionDate ) )
    {
     SqlDataSourceAussieHomeLoansTransactionHistory.InsertParameters["transactionDate"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansTransactionHistory.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateTransactionEffectiveDate")).Text;
    if ( DateTime.TryParse( value, out transactionEffectiveDate ) )
    {
     SqlDataSourceAussieHomeLoansTransactionHistory.InsertParameters["transactionEffectiveDate"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewAussieHomeLoansTransactionHistory.FooterRow.FindControl("TextBoxGridViewAussieHomeLoansTransactionHistoryFooterTemplateTransactionAmount")).Text;
    if ( Decimal.TryParse( value, out transactionAmount ) )
    {
     SqlDataSourceAussieHomeLoansTransactionHistory.InsertParameters["transactionAmount"].DefaultValue = value;
    }
    transactionDRCR  =  ( ( System.Web.UI.WebControls.DropDownList ) GridViewAussieHomeLoansTransactionHistory.FooterRow.FindControl("DropDownListGridViewAussieHomeLoansTransactionHistoryFooterTemplateTransactionDRCR")).SelectedValue;
    SqlDataSourceAussieHomeLoansTransactionHistory.InsertParameters["transactionDRCR"].DefaultValue = transactionDRCR;
    description  =  ( ( System.Web.UI.WebControls.DropDownList ) GridViewAussieHomeLoansTransactionHistory.FooterRow.FindControl("DropDownListGridViewAussieHomeLoansTransactionHistoryFooterTemplateDescription")).SelectedValue;
    SqlDataSourceAussieHomeLoansTransactionHistory.InsertParameters["description"].DefaultValue = description;
    SqlDataSourceAussieHomeLoansTransactionHistory.Insert();
    GridViewAussieHomeLoansTransactionHistory.DataBind();
   }
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   	return;
   }
  }

  ///<summary>PostfixDRCR</summary>
  public static object PostfixDRCR( object value )
  {
   object  postfixDRCR = value;
   Decimal number;
   string format = "{0}";
   if ( Decimal.TryParse( value.ToString(), out number ) )
   {
    if ( number > 0 ) { format = "{0}CR"; }
    else if ( number < 0 ) { format = "{0}DR";  }
    postfixDRCR = String.Format(format, Math.Abs( number ) );    
   }
   return ( postfixDRCR );
  }
  
 }//AussieHomeLoansPage class.
}//WordEngineering namespace.
