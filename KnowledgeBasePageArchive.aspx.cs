using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>KnowledgeBasePage</summary>
 public class KnowledgeBasePage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>GridViewKnowledgeBase</summary>
  protected System.Web.UI.WebControls.GridView               GridViewKnowledgeBase;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceKnowledgeBase</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceKnowledgeBase;
	
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
    GridViewKnowledgeBase.Focus();
    Page.SetFocus( GridViewKnowledgeBase );
    //ButtonClose.Attributes.Add("onClick", "javascript:window.close();");
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
   GridViewKnowledgeBase.DataBind();   
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

  /// <summary>GridView_RowDataBound</summary>
  public void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
  {
   //e.Row.Cells[0].Visible = false;
   if ( e.Row.RowType != DataControlRowType.DataRow ) { return; }
   GridViewRow gridViewRow = e.Row;
   Label commentary = (( System.Web.UI.WebControls.Label ) gridViewRow.FindControl("LabelGridViewKnowledgeBaseItemTemplateCommentary"));
   //commentary.Visible = false;
  }

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

  /// <summary>GridViewKnowledgeBaseInsert</summary>
  public void GridViewKnowledgeBaseInsert
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
   string    uri;
   string    value;
   FileUpload  fileUploadSource = null; 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewKnowledgeBase.FooterRow.FindControl("TextBoxGridViewKnowledgeBaseFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceKnowledgeBase.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewKnowledgeBase.FooterRow.FindControl("TextBoxGridViewKnowledgeBaseFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceKnowledgeBase.InsertParameters["dated"].DefaultValue = value;
    }
    commentary = ( ( System.Web.UI.WebControls.TextBox ) GridViewKnowledgeBase.FooterRow.FindControl("TextBoxGridViewKnowledgeBaseFooterTemplateCommentary")).Text;
    SqlDataSourceKnowledgeBase.InsertParameters["Commentary"].DefaultValue = commentary;
    uri = ( ( System.Web.UI.WebControls.TextBox ) GridViewKnowledgeBase.FooterRow.FindControl("TextBoxGridViewKnowledgeBaseFooterTemplateURI")).Text;
    SqlDataSourceKnowledgeBase.InsertParameters["URI"].DefaultValue = uri;
    fileUploadSource = ( ( System.Web.UI.WebControls.FileUpload ) GridViewKnowledgeBase.FooterRow.FindControl("FileUploadGridViewKnowledgeBaseFooterTemplateSource") );
    if ( fileUploadSource != null && fileUploadSource.HasFile )
    {
     SqlDataSourceKnowledgeBase.InsertParameters["source"].DefaultValue = fileUploadSource.PostedFile.FileName;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewKnowledgeBase.FooterRow.FindControl("TextBoxGridViewKnowledgeBaseFooterTemplateContactId")).Text;
    if ( Int32.TryParse( value, out contactId ) )
    {
     SqlDataSourceKnowledgeBase.InsertParameters["contactId"].DefaultValue = value;
    }
    SqlDataSourceKnowledgeBase.Insert();
    GridViewKnowledgeBase.DataBind();
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