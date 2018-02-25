using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>ActiveDirectoryPage</summary>
 public class ActiveDirectoryPage : Page
 {

  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button  ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button  ButtonSubmit;

  /// <summary>ActiveDirectoryAuthenticationType</summary>
  protected System.Web.UI.WebControls.DropDownList  ActiveDirectoryAuthenticationType;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal  LiteralFeedback;

  /// <summary>SpanActiveDirectory</summary>
  protected System.Web.UI.HtmlControls.HtmlContainerControl SpanActiveDirectory;

  /// <summary>ActiveDirectoryPath</summary>
  protected System.Web.UI.WebControls.TextBox  ActiveDirectoryPath;

  /// <summary>ActiveDirectoryPassword</summary>
  protected System.Web.UI.WebControls.TextBox  ActiveDirectoryPassword;

  /// <summary>ActiveDirectoryUsername</summary>
  protected System.Web.UI.WebControls.TextBox  ActiveDirectoryUsername;

  /// <summary>DirectorySearcherFilter</summary>
  protected System.Web.UI.WebControls.TextBox  DirectorySearcherFilter;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  )
  {
   ActiveDirectoryAuthenticationType.DataSource = UtilityActiveDirectory.ListDirectoryServicesAuthenticationTypes;
   ActiveDirectoryAuthenticationType.DataBind();
   //ActiveDirectoryPath.Attributes.Add("onchange", "ActiveDirectoryPathChange(this);");
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
  }

  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   String exceptionMessage;
   StringBuilder sb;
   SearchResultCollection searchResultCollection;
   searchResultCollection = UtilityActiveDirectory.DirectoryEntrySearcher
   (
        ActiveDirectoryPath.Text, 
        ActiveDirectoryUsername.Text,
        ActiveDirectoryPassword.Text,
        DirectorySearcherFilter.Text,
    out sb,
    out exceptionMessage
   );
   if ( exceptionMessage == null )
   {
    //SpanActiveDirectory.InnerText = sb.ToString();
    Feedback = sb.ToString();
   }
   else
   {
    Feedback = exceptionMessage;
   }
  }

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   ActiveDirectoryPath.Text = null;
   ActiveDirectoryPassword = null;
   ActiveDirectoryUsername = null;
   DirectorySearcherFilter = null;
   Feedback = null;
   Page.SetFocus( ActiveDirectoryPath );
  }
  
 }
}