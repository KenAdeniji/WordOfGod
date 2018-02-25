using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>KarlSeguinPage</summary>
 public class KarlSeguinPage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>GridViewKarlSeguin</summary>
  protected System.Web.UI.WebControls.GridView               GridViewKarlSeguin;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceKarlSeguin</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceKarlSeguin;
	
  /// <summary>TextBoxEastBorderZeroDatabaseImplementationStephenKeshi</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxEastBorderZeroDatabaseImplementationStephenKeshi;
  
  /// <summary>TextBoxDatedFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDatedFrom;

  /// <summary>TextBoxDatedTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDatedTo;
  
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender,
   EventArgs  e
  )
  {
   if ( !Page.IsPostBack )
   {
   	GridViewKarlSeguin.Focus();
    Page.SetFocus( GridViewKarlSeguin );
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
   GridViewKarlSeguin.DataBind();
   GridViewKarlSeguin.DataBind();   
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Feedback = null;
   TextBoxEastBorderZeroDatabaseImplementationStephenKeshi.Text = null;
   TextBoxDatedFrom.Text = null;
   TextBoxDatedTo.Text = null;   
   Page.SetFocus( TextBoxEastBorderZeroDatabaseImplementationStephenKeshi );
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

  /// <summary>GridViewKarlSeguinInsert()</summary>
  public void GridViewKarlSeguinInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   string    EastBorderZeroDatabaseImplementationStephenKeshi;
   string    exceptionMessage = null;
   string    value;   
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewKarlSeguin.FooterRow.FindControl("TextBoxGridViewKarlSeguinFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceKarlSeguin.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewKarlSeguin.FooterRow.FindControl("TextBoxGridViewKarlSeguinFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceKarlSeguin.InsertParameters["dated"].DefaultValue = value;
    }
    EastBorderZeroDatabaseImplementationStephenKeshi = ( ( System.Web.UI.WebControls.TextBox ) GridViewKarlSeguin.FooterRow.FindControl("TextBoxGridViewKarlSeguinFooterTemplateEastBorderZeroDatabaseImplementationStephenKeshi")).Text;
    SqlDataSourceKarlSeguin.InsertParameters["EastBorderZeroDatabaseImplementationStephenKeshi"].DefaultValue = EastBorderZeroDatabaseImplementationStephenKeshi;
    SqlDataSourceKarlSeguin.Insert();
    GridViewKarlSeguin.DataBind();
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
 
 }
}
