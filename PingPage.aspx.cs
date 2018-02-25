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

namespace WordEngineering
{
 /// <summary>Ping page.</summary>
 public class PingPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=URI;";

  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The LocalHost.</summary>
  public string LocalHost                      = "127.0.0.1";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>The XPath database connection string.</summary>
  const  string XPathDatabaseConnectionString  = @"/word/database/sqlServer/bible/databaseConnectionString";  

  /// <summary>ButtonPing.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonPing;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonReset;

  /// <summary>LabelPingTime.</summary>
  protected System.Web.UI.WebControls.Label        LabelPingTime;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal      LiteralFeedback;

  /// <summary>TextBoxPingHost.</summary>  
  protected System.Web.UI.WebControls.TextBox      TextBoxPingHost;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   string exceptionMessage = null;

   ServerMapPath = this.MapPath("");
   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)

   UtilityXml.XmlDocumentNodeInnerText
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

  /// <summary>PingHost.</summary>
  public string PingHost
  {
   get
   {
    return ( TextBoxPingHost.Text );
   } 
   set
   {
    TextBoxPingHost.Text = value;
   }
  }//public string PingHost

  /// <summary>PingTime.</summary>
  public string PingTime
  {
   get
   {
    return ( LabelPingTime.Text );
   } 
   set
   {
    LabelPingTime.Text = value;
   }
  }//public string PingTime

  /// <summary>SetFocus().</summary>
  private void SetFocus(System.Web.UI.Control ctrl)
  {
    // Define the JavaScript function for the specified control.
    string setFocus = "<script language='javascript'>" +
        "document.getElementById('" + ctrl.ClientID +
        "').focus();</script>";

    // Add the JavaScript code to the page.
    Page.RegisterStartupScript("SetFocus", setFocus);
  }

  /// <summary>ButtonPing_Click().</summary>
  public void ButtonPing_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   int milliSecondsPingTime = 0;

   String exceptionMessage = null;
   String targetAddress    = null;

   targetAddress = PingHost;
 
   milliSecondsPingTime = UtilityPing.GetPingTime
   (
        targetAddress,
    ref exceptionMessage
   );
   
   if ( exceptionMessage == null )
   { 
    PingTime = null;
    Feedback = exceptionMessage;
   }

   PingTime = Convert.ToString( milliSecondsPingTime );

  }//public void ButtonPing_Click()

  /// <summary>ButtonPing_Open().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   PingHost = LocalHost;
   PingTime = null;
   Feedback = null;
   SetFocus ( TextBoxPingHost );
  }
  
 }//PingPage class.
}//WordEngineering namespace.