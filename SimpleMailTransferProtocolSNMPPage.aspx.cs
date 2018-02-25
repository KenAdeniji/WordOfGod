using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

using  WordEngineering;

namespace WordEngineering
{
 /// <summary>Simple Mail Transfer Protocol (SMTP) page.</summary>
 /// <remarks>Simple Mail Transfer Protocol (SMTP) page.</remarks>
 public class SimpleMailTransferProtocolSNMPPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string databaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";
  
  /// <summary>The configuration XML filename.</summary>
  public string filenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string serverMapPath                  = null;

  /// <summary>The literal feedback.</summary>  
  protected System.Web.UI.WebControls.Literal     LiteralFeedback;

  /// <summary>The textbox news server.</summary>  
  protected System.Web.UI.WebControls.TextBox     TextBoxNewsServer;

  /// <summary>The textbox news group.</summary>  
  protected System.Web.UI.WebControls.TextBox     TextBoxNewsGroup;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
  
   string databaseConnectionString = null;
   string newsGroupCurrent         = null; 
   string newsServerCurrent        = null; 
     
   serverMapPath = this.MapPath("");
   if ( serverMapPath != null)
   {
    filenameConfigurationXml = serverMapPath + @"\" + filenameConfigurationXml;
   }//if ( serverMapPath != null)

   if ( !Page.IsPostBack )
   {
    UtilityNetworkNewsTransferProtocolNNTP.ConfigurationFile();

    databaseConnectionString  =  UtilityNetworkNewsTransferProtocolNNTP.DatabaseConnectionString;
    newsServerCurrent         =  UtilityNetworkNewsTransferProtocolNNTP.NewsServer;
    newsGroupCurrent          =  UtilityNetworkNewsTransferProtocolNNTP.NewsGroup;
   
    NewsServer = newsServerCurrent;
    NewsGroup  = newsGroupCurrent;

   }//if ( !Page.IsPostBack ) 
   
  }//Page_Load
  
  /// <summary>DatabaseConnectionString.</summary>
  public string DatabaseConnectionString
  {
   get
   {
    return ( databaseConnectionString );
   }//get 
  }//public string DatabaseConnectionString

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
  }//public string Feedback

  /// <summary>NewsGroup.</summary>
  public string NewsGroup
  {
   get
   {
    return ( TextBoxNewsGroup.Text.Trim() );
   } 
   set
   {
    TextBoxNewsGroup.Text = value;
   }
  }//public string NewsGroup

  /// <summary>NewsServer.</summary>
  public string NewsServer
  {
   get
   {
    return ( TextBoxNewsServer.Text.Trim());
   } 
   set
   {
    TextBoxNewsServer.Text = value;
   }
  }//public string NewsServer

  /// <summary>ButtonNewsFeed_Click().</summary>
  public void ButtonNewsFeed_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   PageSubmit();
  }

  /// <summary>ButtonCancel_Click().</summary>
  public void ButtonCancel_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   PageCancel();
  }
  
  /// <summary>PageCancel().</summary>
  public void PageCancel()
  {

   Feedback   = "";
   NewsServer = UtilityNetworkNewsTransferProtocolNNTP.NewsServer;
   NewsGroup  = UtilityNetworkNewsTransferProtocolNNTP.NewsGroup;
   
  }//PageCancel()	

  /// <summary>PageSubmit().</summary>
  public void PageSubmit()
  {
   string newsGroupCurrent  = null;
   string newsServerCurrent = null;
   
   StringBuilder sbResponse = null;
  
   newsGroupCurrent  = NewsGroup;
   newsServerCurrent = NewsServer;
   
   Feedback   = "";
   
   UtilityNetworkNewsTransferProtocolNNTP.NewsClient
   (
    ref newsServerCurrent,
    ref newsGroupCurrent,
    ref sbResponse
   );
   
   if ( sbResponse != null )
   {
   	Feedback = sbResponse.ToString();
   }
   
  }//PageSubmit()	
  
 }//SimpleMailTransferProtocolSNMPPage class.
}//WordEngineering namespace.