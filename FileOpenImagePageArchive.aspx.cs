using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Xml;

namespace WordEngineering
{
 /// <summary>FileOpenImagePage</summary>
 public class FileOpenImagePage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=ImageCarbon;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonReset;

  /// <summary>ButtonSubmit.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonSubmit;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal            LiteralFeedback;

  /// <summary>HtmlInputFileSource.</summary>  
  protected System.Web.UI.HtmlControls.HtmlInputFile     HtmlInputFileSource;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String  exceptionMessage  =  null;

   ServerMapPath = this.MapPath("");

   /* 
   FilenameConfigurationXml = Server.MapPath( FilenameConfigurationXml );
   */

   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        UtilityImage.XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

   if ( !Page.IsPostBack )
   {
   	HtmlInputFileSource.Focus();
   	Page.SetFocus( HtmlInputFileSource );
    HtmlInputFileSource.Attributes.Add("autocomplete", "on");
    HtmlInputFileSource.Attributes.Add("autocomplete", "on");
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
  }//public String public String Feedback

  /// <summary>FilenameSource.</summary>
  public String FilenameSource
  {
   get
   {
    return ( HtmlInputFileSource.Value );
   }//get 
  }//public String FilenameSource

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   String                 exceptionMessage       =  null;

   String                 filenameSource         =  null;

   UtilityImageArgument   utilityImageArgument   =  null;
   
   filenameSource  =  FilenameSource;

   /*
   if( sender == ButtonSubmit )
   {
    Response.Write ( "ButtonSubmit" );
    Feedback = "ButtonSubmit";
   }
   */

   utilityImageArgument = new UtilityImageArgument
   (
    filenameSource
   );

   UtilityImage.DatabaseSelect
   (
    ref DatabaseConnectionString,
    ref utilityImageArgument,
    ref exceptionMessage,
    ref HtmlInputFileSource
   );

   Feedback = exceptionMessage;
   
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback         =  null;
   
   UtilityJavaScript.SetFocus
   ( 
    this,
    HtmlInputFileSource
   );
  }//public void ButtonReset_Click()
  
 }//FileOpenImagePage class.
}//WordEngineering namespace.