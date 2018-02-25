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
 /// <summary>IndexingService page.</summary>
 public class IndexingServicePage : Page
 {

  /// <summary>The database connection string.</summary>
  public string ConnectionStringDatabase       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonReset;

  /// <summary>ButtonSubmit.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonSubmit;

  /// <summary>GridViewIndexingServiceDocument</summary>
  protected System.Web.UI.WebControls.GridView           GridViewIndexingServiceDocument;

  /// <summary>HyperLinkIndexingServiceDocument</summary>
  protected System.Web.UI.WebControls.HyperLink          HyperLinkIndexingServiceDocument;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal            LiteralFeedback;

  /// <summary>TextBoxCatalogName.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxCatalogName;

  /// <summary>TextBoxFreeText.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxFreeTextSearch;

  /// <summary>RepeaterIndexingServiceDocument.</summary>  
  protected System.Web.UI.WebControls.Repeater           RepeaterIndexingServiceDocument;

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

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

  }//Page_Load

  /// <summary>Feedback.</summary>
  public string Feedback
  {
   get
   {
    return ( LiteralFeedback.Text);
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public string public string Feedback

  /// <summary>CatalogName.</summary>
  public String CatalogName
  {
   get
   {
    return ( TextBoxCatalogName.Text );
   }//get 
   set
   {
    TextBoxCatalogName.Text = value;
   }//set
  }//public string CatalogName

  /// <summary>FreeTextSearch.</summary>
  public String FreeTextSearch
  {
   get
   {
    return ( TextBoxFreeTextSearch.Text );
   }//get 
   set
   {
    TextBoxFreeTextSearch.Text = value;
   }//set
  }//public String FreeTextSearch

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   String                              catalogName                            =  CatalogName;

   String                              connectionStringDatabase               =  UtilityIndexingService.ConnectionStringDatabase;
   String                              connectionStringFormatIndexingService  =  UtilityIndexingService.ConnectionStringFormatIndexingService;
   StringBuilder                       connectionStringIndexingService        =  null;

   String                              exceptionMessage                       =  null;
   String                              freeTextSearch                         =  FreeTextSearch;
   StringBuilder                       catalogQuery                           =  new StringBuilder();

   DataSet                             dataSet                                =  null;
   IDataReader                         iDataReader                            =  null;
   UtilityIndexingServiceArgument      utilityIndexingServiceArgument         =  null;
   
   utilityIndexingServiceArgument = new UtilityIndexingServiceArgument
   (
    catalogName,
    freeTextSearch
   );

   UtilityIndexingService.ConfigurationXml
   (
    ref FilenameConfigurationXml,
    ref exceptionMessage,
    ref connectionStringDatabase,
    ref connectionStringFormatIndexingService
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   	return;
   }//if ( exceptionMessage != null )   	

   UtilityIndexingService.Query
   (
    ref connectionStringDatabase,
    ref connectionStringFormatIndexingService,
    ref connectionStringIndexingService,
    ref exceptionMessage,
    ref utilityIndexingServiceArgument,
    ref catalogQuery,
    ref iDataReader,
    ref dataSet
   );

   if ( exceptionMessage != null || iDataReader == null )
   {
    Feedback = exceptionMessage;
   	return;
   }//if ( exceptionMessage != null || iDataReader == null )
   
   /*
   RepeaterIndexingServiceDocument.DataSource = dataSet;
   RepeaterIndexingServiceDocument.DataBind();
   */

   GridViewIndexingServiceDocument.DataSource = dataSet;
   GridViewIndexingServiceDocument.DataBind();

  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback             =  null;
   CatalogName          =  UtilityIndexingService.CatalogName;
   FreeTextSearch       =  null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxCatalogName
   );
  }//public void ButtonReset_Click()
 }//IndexingServicePage class.
}//WordEngineering namespace.