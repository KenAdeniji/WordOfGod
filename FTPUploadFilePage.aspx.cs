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
 /// <summary>FTPUploadFile page.</summary>
 public class FTPUploadFilePage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>HtmlInputFileSource.</summary>
  protected System.Web.UI.HtmlControls.HtmlInputFile     HtmlInputFileSource;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonReset;

  /// <summary>ButtonSubmit.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonSubmit;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal            LiteralFeedback;

  /// <summary>TextBoxURITarget.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxURITarget;

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
        UtilityFTP.XPathDatabaseConnectionString,
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
    TextBoxURITarget.Attributes.Add("autocomplete", "on");
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

  /// <summary>URITarget.</summary>
  public String URITarget
  {
   get
   {
    return ( TextBoxURITarget.Text );
   }//get 
   set
   {
    TextBoxURITarget.Text = value;
   }//set
  }//public String URITarget

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   String               exceptionMessage      =  null;

   String               filenameSource        =  null;
   String               uriTarget             =  null;

   UtilityFTPArgument   utilityFTPArgument    =  null;
   
   filenameSource                             =  FilenameSource;
   uriTarget                                  =  URITarget;

   /*
   if( sender == ButtonSubmit )
   {
    Response.Write ( "ButtonSubmit" );
    Feedback = "ButtonSubmit";
   }
   */

   utilityFTPArgument = new UtilityFTPArgument
   (
    filenameSource,
    null, //filenameTarget
    null, //uriSource
    uriTarget
   );

   UtilityFTP.FTPUploadFile
   (
    ref utilityFTPArgument,
    ref exceptionMessage
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
   
   URITarget        =  null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    HtmlInputFileSource
   );
  }//public void ButtonReset_Click()
  
 }//FTPUploadFilePage class.
}//WordEngineering namespace.