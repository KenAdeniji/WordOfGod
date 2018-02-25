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
 /// <summary>CommonwealthBankOfAustraliaPage</summary>
 public class CommonwealthBankOfAustraliaPage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>DropDownListTransactionDRCR</summary>  
  protected System.Web.UI.WebControls.DropDownList           DropDownListTransactionDRCR;

  /// <summary>GridViewCommonwealthBankOfAustraliaTransaction</summary>
  protected System.Web.UI.WebControls.GridView               GridViewCommonwealthBankOfAustraliaTransaction;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceCommonwealthBankOfAustraliaTransaction</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceCommonwealthBankOfAustraliaTransaction;

  /// <summary>TextBoxAccountNumber</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxAccountNumber;

  /// <summary>TextBoxBalanceFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxBalanceFrom;

  /// <summary>TextBoxBalanceTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxBalanceTo;
  
  /// <summary>TextBoxTransactionDescription</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxTransactionDescription;
  
  /// <summary>TextBoxClientNumber</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxClientNumber;

  /// <summary>TextBoxDateFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDateFrom;

  /// <summary>TextBoxDateTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDateTo;

  /// <summary>TextBoxDebitCreditFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDebitCreditFrom;

  /// <summary>TextBoxDebitCreditTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDebitCreditTo;

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
    GridViewCommonwealthBankOfAustraliaTransaction.Focus();
    Page.SetFocus( GridViewCommonwealthBankOfAustraliaTransaction );
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
   GridViewCommonwealthBankOfAustraliaTransaction.DataBind();
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Feedback                            =  null;
   TextBoxClientNumber.Text            =  null;
   TextBoxAccountNumber.Text	       =  null;
   TextBoxDateFrom.Text		       =  null;
   TextBoxDateTo.Text		       =  null;
   TextBoxTransactionDescription.Text  =  null;
   DropDownListTransactionDRCR.Text    =  null;
   TextBoxDebitCreditFrom.Text	       =  null;
   TextBoxDebitCreditTo.Text	       =  null;
   TextBoxBalanceFrom.Text             =  null;
   TextBoxBalanceTo.Text               =  null;   
   Page.SetFocus( DropDownListTransactionDRCR );
  }//public void ButtonReset_Click()

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
  
 }//CommonwealthBankOfAustraliaPage class.
}//WordEngineering namespace.