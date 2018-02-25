using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>SoftwarePage</summary>
 public class SoftwarePage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>GridViewSoftware</summary>
  protected System.Web.UI.WebControls.GridView               GridViewSoftware;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceSoftware</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceSoftware;
	
  /// <summary>TextBoxCommentary</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxCommentary;

  /// <summary>TextBoxCommentary</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxContactId;
  
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
    GridViewSoftware.Focus();
    Page.SetFocus( GridViewSoftware );
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
   GridViewSoftware.DataBind();   
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Feedback = null;
   TextBoxCommentary.Text = null;
   TextBoxContactId.Text = null;
   TextBoxDatedFrom.Text = null;
   TextBoxDatedTo.Text = null;   
   Page.SetFocus( TextBoxCommentary );
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

  /// <summary>GridViewSoftwareInsert</summary>
  public void GridViewSoftwareInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       contactId;
   int       sequenceOrderId;
   DateTime  dated;
   string    commentary;
   string    exceptionMessage = null;
   string    value;
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewSoftware.FooterRow.FindControl("TextBoxGridViewSoftwareFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceSoftware.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewSoftware.FooterRow.FindControl("TextBoxGridViewSoftwareFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceSoftware.InsertParameters["dated"].DefaultValue = value;
    }
    commentary = ( ( System.Web.UI.WebControls.TextBox ) GridViewSoftware.FooterRow.FindControl("TextBoxGridViewSoftwareFooterTemplateCommentary")).Text;
    SqlDataSourceSoftware.InsertParameters["Commentary"].DefaultValue = commentary;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewSoftware.FooterRow.FindControl("TextBoxGridViewSoftwareFooterTemplateContactId")).Text;
    if ( Int32.TryParse( value, out contactId ) )
    {
     SqlDataSourceSoftware.InsertParameters["contactId"].DefaultValue = value;
    }
    SqlDataSourceSoftware.Insert();
    GridViewSoftware.DataBind();
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