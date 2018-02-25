using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace WordEngineering
{
 /// <summary>SacredTextGridViewPage</summary>
 public class SacredTextGridViewPage : Page
 {
  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>The XPath database connection string.</summary>
  public string XPathDatabaseConnectionString  = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";

  /// <summary>ButtonRevert</summary>
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>GridViewSacredText</summary>
  protected System.Web.UI.WebControls.GridView               GridViewSacredText;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>SqlDataSourceSacredText</summary>
  protected SqlDataSource SqlDataSourceSacredText;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String  exceptionMessage  =  null;

   ServerMapPath = this.MapPath("");

   if ( ServerMapPath != null)
   {
   	FilenameConfigurationXml = Path.Combine( ServerMapPath, FilenameConfigurationXml );
   }//if ( ServerMapPath != null)

   UtilityXml.GetNodeValue
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

   if ( !Page.IsPostBack )
   {
    GridViewSacredText.Focus();
    Page.SetFocus( GridViewSacredText );
    GridViewSacredText.Attributes.Add("autocomplete", "on");
   }//if ( !Page.IsPostBack )
   	
  }//Page_Load

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
  }//public String Feedback

  /// <summary>GridViewSacredTextInsert</summary>
  public void GridViewSacredTextInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   string    commentary;
   string    exceptionMessage = null;
   string    scriptureReference;
   string    title;
   string    value;       
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewSacredText.FooterRow.FindControl("TextBoxGridViewSacredTextFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceSacredText.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewSacredText.FooterRow.FindControl("TextBoxGridViewSacredTextFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceSacredText.InsertParameters["dated"].DefaultValue = value;
    }
    scriptureReference = ( ( System.Web.UI.WebControls.TextBox ) GridViewSacredText.FooterRow.FindControl("TextBoxGridViewSacredTextFooterTemplateScriptureReference")).Text;
    SqlDataSourceSacredText.InsertParameters["scriptureReference"].DefaultValue = scriptureReference;
    title = ( ( System.Web.UI.WebControls.TextBox ) GridViewSacredText.FooterRow.FindControl("TextBoxGridViewSacredTextFooterTemplateTitle")).Text;
    SqlDataSourceSacredText.InsertParameters["title"].DefaultValue = title;
    commentary = ( ( System.Web.UI.WebControls.TextBox ) GridViewSacredText.FooterRow.FindControl("TextBoxGridViewSacredTextFooterTemplateCommentary")).Text;
    SqlDataSourceSacredText.InsertParameters["commentary"].DefaultValue = commentary;
    SqlDataSourceSacredText.Insert();
    GridViewSacredText.DataBind();
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