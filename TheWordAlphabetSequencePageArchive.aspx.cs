using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>TheWordAlphabetSequencePage</summary>
 public class TheWordAlphabetSequencePage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>GridViewTheWord</summary>
  protected System.Web.UI.WebControls.GridView               GridViewTheWord;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceTheWord</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceTheWord;
	
  /// <summary>TextBoxFilename</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxFilename;
  
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
    GridViewTheWord.Focus();
    Page.SetFocus( GridViewTheWord );
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
   GridViewTheWord.DataBind();   
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Feedback = null;
   TextBoxFilename.Text = null;
   TextBoxDatedFrom.Text = null;
   TextBoxDatedTo.Text = null;   
   Page.SetFocus( TextBoxFilename );
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

  /// <summary>GridViewTheWordInsert</summary>
  public void GridViewTheWordInsert
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
   string    filename;
   string    keyword;
   string    scriptureReference;
   string    title;
   string    value;
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewTheWord.FooterRow.FindControl("TextBoxGridViewTheWordFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceTheWord.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewTheWord.FooterRow.FindControl("TextBoxGridViewTheWordFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceTheWord.InsertParameters["dated"].DefaultValue = value;
    }
    filename = ( ( System.Web.UI.WebControls.TextBox ) GridViewTheWord.FooterRow.FindControl("TextBoxGridViewTheWordFooterTemplateFilename")).Text;
    SqlDataSourceTheWord.InsertParameters["Filename"].DefaultValue = filename;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewTheWord.FooterRow.FindControl("TextBoxGridViewTheWordFooterTemplateContactId")).Text;
    if ( Int32.TryParse( value, out contactId ) )
    {
     SqlDataSourceTheWord.InsertParameters["contactId"].DefaultValue = value;
    }
    title = ( ( System.Web.UI.WebControls.TextBox ) GridViewTheWord.FooterRow.FindControl("TextBoxGridViewTheWordFooterTemplateTitle")).Text;
    SqlDataSourceTheWord.InsertParameters["title"].DefaultValue = title;
    commentary = ( ( System.Web.UI.WebControls.TextBox ) GridViewTheWord.FooterRow.FindControl("TextBoxGridViewTheWordFooterTemplateCommentary")).Text;
    SqlDataSourceTheWord.InsertParameters["Commentary"].DefaultValue = commentary;
    keyword = ( ( System.Web.UI.WebControls.TextBox ) GridViewTheWord.FooterRow.FindControl("TextBoxGridViewTheWordFooterTemplateKeyword")).Text;
    SqlDataSourceTheWord.InsertParameters["keyword"].DefaultValue = keyword;
    scriptureReference = ( ( System.Web.UI.WebControls.TextBox ) GridViewTheWord.FooterRow.FindControl("TextBoxGridViewTheWordFooterTemplatescriptureReference")).Text;
    SqlDataSourceTheWord.InsertParameters["scriptureReference"].DefaultValue = scriptureReference;
    SqlDataSourceTheWord.Insert();
    GridViewTheWord.DataBind();
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