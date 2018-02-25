using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>LJHookerPage</summary>
 public class LJHookerPage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>GridViewJAFlevarisRealtyTrustReceipt</summary>
  protected System.Web.UI.WebControls.GridView               GridViewJAFlevarisRealtyTrustReceipt;
  
  /// <summary>GridViewLJHookerTaxInvoice</summary>
  protected System.Web.UI.WebControls.GridView               GridViewLJHookerTaxInvoice;

  /// <summary>GridViewNobleHomesLevyNotice</summary>
  protected System.Web.UI.WebControls.GridView               GridViewNobleHomesLevyNotice;
  
  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceJAFlevarisRealtyTrustReceipt</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceJAFlevarisRealtyTrustReceipt;

  /// <summary>SqlDataSourceLJHookerTaxInvoice</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceLJHookerTaxInvoice;
	
  /// <summary>SqlDataSourceNobleHomesLevyNotice</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceNobleHomesLevyNotice;
	
  /// <summary>TextBoxAccountNumber</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxAccountNumber;

  /// <summary>TextBoxDetails</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDetails;
  
  /// <summary>TextBoxDX</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDX;
  
  /// <summary>TextBoxReferenceFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxReferenceFrom;

  /// <summary>TextBoxReferenceTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxReferenceTo;
  
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  )
  {
   if ( !Page.IsPostBack )
   {
   	GridViewLJHookerTaxInvoice.Focus();
    Page.SetFocus( GridViewLJHookerTaxInvoice );
   }
   CultureAustralia();
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
   GridViewLJHookerTaxInvoice.DataBind();
   GridViewLJHookerTaxInvoice.DataBind();   
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Feedback = null;
   TextBoxAccountNumber.Text = null;
   TextBoxDX.Text = null;
   TextBoxReferenceFrom.Text = null;
   TextBoxReferenceTo.Text = null;   
   TextBoxDetails.Text = null;
   Page.SetFocus( TextBoxDX );
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

  /// <summary>GridViewLJHookerTaxInvoiceInsert()</summary>
  public void GridViewLJHookerTaxInvoiceInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       accountNumber;
   int       sequenceOrderId;
   DateTime  dated;
   DateTime  reference;
   Decimal   debit;
   Decimal   debitIncGST;
   Decimal   credit;
   Decimal   creditIncGST;
   string    details;
   string    DX;
   string    exceptionMessage = null;
   string    value;   
 
   try
   {
   	value = (( System.Web.UI.WebControls.TextBox ) GridViewLJHookerTaxInvoice.FooterRow.FindControl("TextBoxGridViewLJHookerTaxInvoiceFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceLJHookerTaxInvoice.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewLJHookerTaxInvoice.FooterRow.FindControl("TextBoxGridViewLJHookerTaxInvoiceFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceLJHookerTaxInvoice.InsertParameters["dated"].DefaultValue = value;
    }
    DX = ( ( System.Web.UI.WebControls.TextBox ) GridViewLJHookerTaxInvoice.FooterRow.FindControl("TextBoxGridViewLJHookerTaxInvoiceFooterTemplateDX")).Text;
    SqlDataSourceLJHookerTaxInvoice.InsertParameters["DX"].DefaultValue = DX;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewLJHookerTaxInvoice.FooterRow.FindControl("TextBoxGridViewLJHookerTaxInvoiceFooterTemplateAccountNumber")).Text;
    if ( Int32.TryParse( value, out accountNumber ) )
    {
     SqlDataSourceLJHookerTaxInvoice.InsertParameters["accountNumber"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewLJHookerTaxInvoice.FooterRow.FindControl("TextBoxGridViewLJHookerTaxInvoiceFooterTemplateReference")).Text;
    if ( DateTime.TryParse( value, out reference ) )
    {
     SqlDataSourceLJHookerTaxInvoice.InsertParameters["reference"].DefaultValue = value;
    }
    details  =  ( ( System.Web.UI.WebControls.TextBox ) GridViewLJHookerTaxInvoice.FooterRow.FindControl("TextBoxGridViewLJHookerTaxInvoiceFooterTemplateDetails")).Text;
    SqlDataSourceLJHookerTaxInvoice.InsertParameters["details"].DefaultValue = details;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewLJHookerTaxInvoice.FooterRow.FindControl("TextBoxGridViewLJHookerTaxInvoiceFooterTemplateDebit")).Text;
    if ( Decimal.TryParse( value, out debit ) )
    {
     SqlDataSourceLJHookerTaxInvoice.InsertParameters["debit"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewLJHookerTaxInvoice.FooterRow.FindControl("TextBoxGridViewLJHookerTaxInvoiceFooterTemplateDebitIncGST")).Text;
    if ( Decimal.TryParse( value, out debitIncGST ) )
    {
     SqlDataSourceLJHookerTaxInvoice.InsertParameters["debitIncGST"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewLJHookerTaxInvoice.FooterRow.FindControl("TextBoxGridViewLJHookerTaxInvoiceFooterTemplateCredit")).Text;
    if ( Decimal.TryParse( value, out credit ) )
    {
     SqlDataSourceLJHookerTaxInvoice.InsertParameters["credit"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewLJHookerTaxInvoice.FooterRow.FindControl("TextBoxGridViewLJHookerTaxInvoiceFooterTemplateCreditIncGST")).Text;
    if ( Decimal.TryParse( value, out creditIncGST ) )
    {
     SqlDataSourceLJHookerTaxInvoice.InsertParameters["creditIncGST"].DefaultValue = value;
    }
    SqlDataSourceLJHookerTaxInvoice.Insert();
    GridViewLJHookerTaxInvoice.DataBind();
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

  /// <summary>GridViewNobleHomesLevyNoticeInsert()</summary>
  public void GridViewNobleHomesLevyNoticeInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   DateTime  date;
   Decimal   admin;
   Decimal   sinking;
   Decimal   misc;
   Decimal   total;
   Decimal   balance;
   string    description;
   string    exceptionMessage = null;
   string    value;   
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewNobleHomesLevyNotice.FooterRow.FindControl("TextBoxGridViewNobleHomesLevyNoticeFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceNobleHomesLevyNotice.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewNobleHomesLevyNotice.FooterRow.FindControl("TextBoxGridViewNobleHomesLevyNoticeFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceNobleHomesLevyNotice.InsertParameters["dated"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewNobleHomesLevyNotice.FooterRow.FindControl("TextBoxGridViewNobleHomesLevyNoticeFooterTemplatedate")).Text;
    if ( DateTime.TryParse( value, out date ) )
    {
     SqlDataSourceNobleHomesLevyNotice.InsertParameters["date"].DefaultValue = value;
    }
    description  =  ( ( System.Web.UI.WebControls.TextBox ) GridViewNobleHomesLevyNotice.FooterRow.FindControl("TextBoxGridViewNobleHomesLevyNoticeFooterTemplatedescription")).Text;
    SqlDataSourceNobleHomesLevyNotice.InsertParameters["description"].DefaultValue = description;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewNobleHomesLevyNotice.FooterRow.FindControl("TextBoxGridViewNobleHomesLevyNoticeFooterTemplateadmin")).Text;
    if ( Decimal.TryParse( value, out admin ) )
    {
     SqlDataSourceNobleHomesLevyNotice.InsertParameters["admin"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewNobleHomesLevyNotice.FooterRow.FindControl("TextBoxGridViewNobleHomesLevyNoticeFooterTemplatesinking")).Text;
    if ( Decimal.TryParse( value, out sinking ) )
    {
     SqlDataSourceNobleHomesLevyNotice.InsertParameters["sinking"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewNobleHomesLevyNotice.FooterRow.FindControl("TextBoxGridViewNobleHomesLevyNoticeFooterTemplatemisc")).Text;
    if ( Decimal.TryParse( value, out misc ) )
    {
     SqlDataSourceNobleHomesLevyNotice.InsertParameters["misc"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewNobleHomesLevyNotice.FooterRow.FindControl("TextBoxGridViewNobleHomesLevyNoticeFooterTemplatetotal")).Text;
    if ( Decimal.TryParse( value, out total ) )
    {
     SqlDataSourceNobleHomesLevyNotice.InsertParameters["total"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewNobleHomesLevyNotice.FooterRow.FindControl("TextBoxGridViewNobleHomesLevyNoticeFooterTemplateBalance")).Text;
    if ( Decimal.TryParse( value, out balance ) )
    {
     SqlDataSourceNobleHomesLevyNotice.InsertParameters["Balance"].DefaultValue = value;
    }
    SqlDataSourceNobleHomesLevyNotice.Insert();
    GridViewNobleHomesLevyNotice.DataBind();
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

  /// <summary>GridViewJAFlevarisRealtyTrustReceiptInsert()</summary>
  public void GridViewJAFlevarisRealtyTrustReceiptInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   DateTime  date;
   Decimal   admin;
   Decimal   sinking;
   Decimal   unallocated;
   Decimal   outstanding;
   Decimal   interest;
   Decimal   paid;
   string    description;
   string    exceptionMessage = null;
   string    value;   
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewJAFlevarisRealtyTrustReceipt.FooterRow.FindControl("TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceJAFlevarisRealtyTrustReceipt.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewJAFlevarisRealtyTrustReceipt.FooterRow.FindControl("TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceJAFlevarisRealtyTrustReceipt.InsertParameters["dated"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewJAFlevarisRealtyTrustReceipt.FooterRow.FindControl("TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplatedate")).Text;
    if ( DateTime.TryParse( value, out date ) )
    {
     SqlDataSourceJAFlevarisRealtyTrustReceipt.InsertParameters["date"].DefaultValue = value;
    }
    description  =  ( ( System.Web.UI.WebControls.TextBox ) GridViewJAFlevarisRealtyTrustReceipt.FooterRow.FindControl("TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplatedescription")).Text;
    SqlDataSourceJAFlevarisRealtyTrustReceipt.InsertParameters["description"].DefaultValue = description;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewJAFlevarisRealtyTrustReceipt.FooterRow.FindControl("TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateadmin")).Text;
    if ( Decimal.TryParse( value, out admin ) )
    {
     SqlDataSourceJAFlevarisRealtyTrustReceipt.InsertParameters["admin"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewJAFlevarisRealtyTrustReceipt.FooterRow.FindControl("TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplatesinking")).Text;
    if ( Decimal.TryParse( value, out sinking ) )
    {
     SqlDataSourceJAFlevarisRealtyTrustReceipt.InsertParameters["sinking"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewJAFlevarisRealtyTrustReceipt.FooterRow.FindControl("TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateunallocated")).Text;
    if ( Decimal.TryParse( value, out unallocated ) )
    {
     SqlDataSourceJAFlevarisRealtyTrustReceipt.InsertParameters["unallocated"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewJAFlevarisRealtyTrustReceipt.FooterRow.FindControl("TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateoutstanding")).Text;
    if ( Decimal.TryParse( value, out outstanding ) )
    {
     SqlDataSourceJAFlevarisRealtyTrustReceipt.InsertParameters["outstanding"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewJAFlevarisRealtyTrustReceipt.FooterRow.FindControl("TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplateinterest")).Text;
    if ( Decimal.TryParse( value, out interest ) )
    {
     SqlDataSourceJAFlevarisRealtyTrustReceipt.InsertParameters["interest"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewJAFlevarisRealtyTrustReceipt.FooterRow.FindControl("TextBoxGridViewJAFlevarisRealtyTrustReceiptFooterTemplatepaid")).Text;
    if ( Decimal.TryParse( value, out paid ) )
    {
     SqlDataSourceJAFlevarisRealtyTrustReceipt.InsertParameters["paid"].DefaultValue = value;
    }
    SqlDataSourceJAFlevarisRealtyTrustReceipt.Insert();
    GridViewJAFlevarisRealtyTrustReceipt.DataBind();
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
  
  /// <summary>CultureAustralia</summary>
  public static void CultureAustralia()
  {
   System.Globalization.CultureInfo  cultureInfoAU;
   cultureInfoAU = new System.Globalization.CultureInfo("en-AU");
   System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfoAU;
   System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfoAU;
   System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
  }
  
 }//LJHookerPage class.
}//WordEngineering namespace.
