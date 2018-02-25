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
 /// <summary>FileUploadSaveAs page.</summary>
 public class FileUploadPage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>FileUploadSource.</summary>
  protected System.Web.UI.WebControls.FileUpload         FileUploadSource;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonReset;

  /// <summary>ButtonSubmit.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonSubmit;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal            LiteralFeedback;

  /// <summary>HtmlInputFileTarget.</summary>  
  protected System.Web.UI.HtmlControls.HtmlInputFile     HtmlInputFileTarget;

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
        UtilityFileUpload.XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

   if ( !Page.IsPostBack )
   {
   	FileUploadSource.Focus();
   	Page.SetFocus( FileUploadSource );
    FileUploadSource.Attributes.Add("autocomplete", "on");
    HtmlInputFileTarget.Attributes.Add("autocomplete", "on");
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
    return ( FileUploadSource.FileName );
   }//get 
  }//public String FilenameSource

  /// <summary>FilenameTarget.</summary>
  public String FilenameTarget
  {
   get
   {
    return ( HtmlInputFileTarget.Value );
   }//get 
  }//public String FilenameTarget

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   String               exceptionMessage                    =  null;

   String               filenameSource                      =  null;
   String               filenameTarget                      =  null;

   UtilityFileUploadArgument   utilityFileUploadArgument    =  null;
   
   filenameSource                                           =  FilenameSource;
   filenameTarget                                           =  FilenameTarget;

   /*
   if( sender == ButtonSubmit )
   {
    Response.Write ( "ButtonSubmit" );
    Feedback = "ButtonSubmit";
   }
   */

   utilityFileUploadArgument = new UtilityFileUploadArgument
   (
    filenameSource,
    filenameTarget
   );

   UtilityFileUpload.FileUploadSaveAs
   (
    ref utilityFileUploadArgument,
    ref exceptionMessage,
    ref FileUploadSource
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
    FileUploadSource
   );
  }//public void ButtonReset_Click()
  
 }//FileUploadPage class.
}//WordEngineering namespace.