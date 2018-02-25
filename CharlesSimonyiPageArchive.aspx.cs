using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>CharlesSimonyiPage</summary>
 public class CharlesSimonyiPage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>GridViewCharlesSimonyi</summary>
  protected System.Web.UI.WebControls.GridView               GridViewCharlesSimonyi;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceCharlesSimonyi</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceCharlesSimonyi;
	
  /// <summary>TextBoxHungarianNotation</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxHungarianNotation;
  
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
   	GridViewCharlesSimonyi.Focus();
    Page.SetFocus( GridViewCharlesSimonyi );
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
   GridViewCharlesSimonyi.DataBind();
   GridViewCharlesSimonyi.DataBind();   
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Feedback = null;
   TextBoxHungarianNotation.Text = null;
   TextBoxDatedFrom.Text = null;
   TextBoxDatedTo.Text = null;   
   Page.SetFocus( TextBoxHungarianNotation );
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

  /// <summary>GridViewCharlesSimonyiInsert()</summary>
  public void GridViewCharlesSimonyiInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   string    hungarianNotation;
   string    exceptionMessage = null;
   string    value;   
 
   try
   {
   	value = (( System.Web.UI.WebControls.TextBox ) GridViewCharlesSimonyi.FooterRow.FindControl("TextBoxGridViewCharlesSimonyiFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceCharlesSimonyi.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewCharlesSimonyi.FooterRow.FindControl("TextBoxGridViewCharlesSimonyiFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceCharlesSimonyi.InsertParameters["dated"].DefaultValue = value;
    }
    hungarianNotation = ( ( System.Web.UI.WebControls.TextBox ) GridViewCharlesSimonyi.FooterRow.FindControl("TextBoxGridViewCharlesSimonyiFooterTemplateHungarianNotation")).Text;
    SqlDataSourceCharlesSimonyi.InsertParameters["HungarianNotation"].DefaultValue = hungarianNotation;
    SqlDataSourceCharlesSimonyi.Insert();
    GridViewCharlesSimonyi.DataBind();
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
 
 }//CharlesSimonyiPage class.
}//WordEngineering namespace.
