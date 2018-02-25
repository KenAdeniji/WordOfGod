using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>IHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouPage</summary>
 public class IHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouPage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou</summary>
  protected System.Web.UI.WebControls.GridView               GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou;
	
  /// <summary>TextBoxCommentary</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxCommentary;
  
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
    GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou.Focus();
    Page.SetFocus( GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou );
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
   GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou.DataBind();   
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

  /// <summary>GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouInsert()</summary>
  public void GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   string    commentary;
   string    exceptionMessage = null;
   string    value;   
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou.FooterRow.FindControl("TextBoxGridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou.FooterRow.FindControl("TextBoxGridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou.InsertParameters["dated"].DefaultValue = value;
    }
    commentary = ( ( System.Web.UI.WebControls.TextBox ) GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou.FooterRow.FindControl("TextBoxGridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYouFooterTemplateCommentary")).Text;
    SqlDataSourceIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou.InsertParameters["Commentary"].DefaultValue = commentary;
    SqlDataSourceIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou.Insert();
    GridViewIHaveBroughtSomethingAgainstYouButDontWorryIAmWithYou.DataBind();
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