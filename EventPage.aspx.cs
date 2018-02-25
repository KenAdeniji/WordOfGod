using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>EventPage</summary>
 public class EventPage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>GridViewEvent</summary>
  protected System.Web.UI.WebControls.GridView               GridViewEvent;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceEvent</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceEvent;
	
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
    GridViewEvent.Focus();
    Page.SetFocus( GridViewEvent );
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
   GridViewEvent.DataBind();   
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

  /// <summary>GridViewEventInsert</summary>
  public void GridViewEventInsert
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
    value = (( System.Web.UI.WebControls.TextBox ) GridViewEvent.FooterRow.FindControl("TextBoxGridViewEventFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceEvent.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewEvent.FooterRow.FindControl("TextBoxGridViewEventFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceEvent.InsertParameters["dated"].DefaultValue = value;
    }
    commentary = ( ( System.Web.UI.WebControls.TextBox ) GridViewEvent.FooterRow.FindControl("TextBoxGridViewEventFooterTemplateCommentary")).Text;
    SqlDataSourceEvent.InsertParameters["Commentary"].DefaultValue = commentary;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewEvent.FooterRow.FindControl("TextBoxGridViewEventFooterTemplateContactId")).Text;
    if ( Int32.TryParse( value, out contactId ) )
    {
     SqlDataSourceEvent.InsertParameters["contactId"].DefaultValue = value;
    }
    SqlDataSourceEvent.Insert();
    GridViewEvent.DataBind();
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