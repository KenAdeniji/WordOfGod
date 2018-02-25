using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>ItsCalledTheSetupScreenOfScreenOnePage</summary>
 public class ItsCalledTheSetupScreenOfScreenOnePage : Page
 {
  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>GridViewItsCalledTheSetupScreenOfScreenOne</summary>
  protected System.Web.UI.WebControls.GridView               GridViewItsCalledTheSetupScreenOfScreenOne;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceItsCalledTheSetupScreenOfScreenOne</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceItsCalledTheSetupScreenOfScreenOne;
	
  /// <summary>TextBoxScreenOne</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxScreenOne;
  
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
    GridViewItsCalledTheSetupScreenOfScreenOne.Focus();
    Page.SetFocus( GridViewItsCalledTheSetupScreenOfScreenOne );
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
   GridViewItsCalledTheSetupScreenOfScreenOne.DataBind();   
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Feedback = null;
   TextBoxScreenOne.Text = null;
   TextBoxDatedFrom.Text = null;
   TextBoxDatedTo.Text = null;   
   Page.SetFocus( TextBoxScreenOne );
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

  /// <summary>GridViewItsCalledTheSetupScreenOfScreenOneInsert()</summary>
  public void GridViewItsCalledTheSetupScreenOfScreenOneInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   string    screenOne;
   string    exceptionMessage = null;
   string    value;   
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewItsCalledTheSetupScreenOfScreenOne.FooterRow.FindControl("TextBoxGridViewItsCalledTheSetupScreenOfScreenOneFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceItsCalledTheSetupScreenOfScreenOne.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewItsCalledTheSetupScreenOfScreenOne.FooterRow.FindControl("TextBoxGridViewItsCalledTheSetupScreenOfScreenOneFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceItsCalledTheSetupScreenOfScreenOne.InsertParameters["dated"].DefaultValue = value;
    }
    screenOne = ( ( System.Web.UI.WebControls.TextBox ) GridViewItsCalledTheSetupScreenOfScreenOne.FooterRow.FindControl("TextBoxGridViewItsCalledTheSetupScreenOfScreenOneFooterTemplateScreenOne")).Text;
    SqlDataSourceItsCalledTheSetupScreenOfScreenOne.InsertParameters["ScreenOne"].DefaultValue = screenOne;
    SqlDataSourceItsCalledTheSetupScreenOfScreenOne.Insert();
    GridViewItsCalledTheSetupScreenOfScreenOne.DataBind();
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
