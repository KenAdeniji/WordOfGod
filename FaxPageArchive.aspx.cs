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
 /// <summary>Fax page.</summary>
 public class FaxPage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Fax;";

  /// <summary>The DatabaseFile.</summary>
  public String DatabaseFile                   = null;

  /// <summary>DefaultFaxServerName</summary>
  public String DefaultFaxServerName           = null;

  /// <summary>DefaultFaxNumber</summary>
  public String DefaultFaxNumber               = null;

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

  /// <summary>TextBoxFaxServerName.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxFaxServerName;

  /// <summary>TextBoxFaxNumber.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxFaxNumber;

  /// <summary>HtmlInputFileFaxDocument.</summary>  
  protected System.Web.UI.HtmlControls.HtmlInputFile     HtmlInputFileFaxDocument;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String  exceptionMessage  =  null;
   
   String  faxServerName     =  null;
   String  faxNumber         =  null;

   ServerMapPath = this.MapPath("");

   /* 
   FilenameConfigurationXml = Server.MapPath( FilenameConfigurationXml );
   */

   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

   UtilityFax.ConfigurationXml
   (
    ref FilenameConfigurationXml,
    ref exceptionMessage,
    ref DatabaseConnectionString,
    ref faxServerName,
    ref faxNumber
   );

   DefaultFaxNumber      =  faxNumber;
   DefaultFaxServerName  =  faxServerName;
      
   FaxServerName =  faxServerName;
   FaxNumber     =  faxNumber;

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   	return;
   }//if ( exceptionMessage != null )   	

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

  /// <summary>FaxDocument.</summary>
  public String FaxDocument
  {
   get
   {
    return ( HtmlInputFileFaxDocument.PostedFile.FileName  );
   } 
   set
   {
    //HtmlInputFileFaxDocument.PostedFile.FileName = value;
   }
  }//public String FaxDocument

  /// <summary>FaxNumber.</summary>
  public String FaxNumber
  {
   get
   {
    return ( TextBoxFaxNumber.Text.Trim() );
   }//get 
   set
   {
    TextBoxFaxNumber.Text = value;
   }//set
  }//public String FaxNumber

  /// <summary>FaxServerName.</summary>
  public String FaxServerName
  {
   get
   {
    return ( TextBoxFaxServerName.Text.Trim() );
   }//get 
   set
   {
    TextBoxFaxServerName.Text = value;
   }//set
  }//public String FaxServerName

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   String                exceptionMessage    =  null;
   UtilityFaxArgument    utilityFaxArgument  =  null;

   utilityFaxArgument = new UtilityFaxArgument
   (
    FaxDocument,
    FaxServerName,
    FaxNumber
   );
   
   UtilityFax.FaxSend
   (
    ref utilityFaxArgument,    
    ref exceptionMessage
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   	return;
   }//if ( exceptionMessage != null )
   
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback        =  null;
   
   FaxDocument     =  null;
   FaxNumber       =  DefaultFaxNumber;
   FaxServerName   =  DefaultFaxServerName;
   
   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxFaxServerName
   );

  }//public void ButtonReset_Click()
  
 }//FaxPage class.
}//Fax namespace.