using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Xml;

namespace WordEngineering
{
 /// <summary>TraceRoute page.</summary>
 public class TraceRoutePage : Page
 {

  /// <summary>The database connection string.</summary>
  public string DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>The XPath database connection string.</summary>
  const  string XPathDatabaseConnectionString  = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";  

  /// <summary>ButtonTraceRoute.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonTraceRoute;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonReset;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal      LiteralFeedback;

  /// <summary>TextBoxHostnameTarget.</summary>  
  protected System.Web.UI.WebControls.TextBox      TextBoxHostname;

  /// <summary>TextBoxMaximumHops.</summary>  
  protected System.Web.UI.WebControls.TextBox      TextBoxMaximumHops;

  /// <summary>TextBoxTimeoutReply.</summary>  
  protected System.Web.UI.WebControls.TextBox      TextBoxTimeoutReply;

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

  /// <summary>HostName.</summary>
  public string HostNameTarget
  {
   get
   {
    return ( TextBoxHostname.Text );
   } 
   set
   {
    TextBoxHostname.Text = value;
   }
  }//public string HostNameTarget

  /// <summary>Maximum Hops.</summary>
  public string MaximumHops
  {
   get
   {
    return ( TextBoxMaximumHops.Text );
   } 
   set
   {
    TextBoxMaximumHops.Text = value;
   }
  }//public string MaximumHops

  /// <summary>Timeout Reply.</summary>
  public string TimeoutReply
  {
   get
   {
    return ( TextBoxTimeoutReply.Text );
   } 
   set
   {
    TextBoxTimeoutReply.Text = value;
   }
  }//public string TimeoutReply

  /// <summary>ButtonTraceRoute_Click().</summary>
  public void ButtonTraceRoute_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   int          hopCount          = -1;
   int          iCMPTimeExceeded  = -1;
   int          maximumHops       = -1;
   int          timeoutReply      = -1;

   String       hostName          = null;
   String       exceptionMessage  = null;
   
   IPHostEntry  iPHostEntry       = null;

   hostName       = HostNameTarget;
   if ( MaximumHops != null && MaximumHops != String.Empty )
   {
    maximumHops = System.Convert.ToInt32( MaximumHops );
   } 
   if ( TimeoutReply != null && TimeoutReply != String.Empty )
   {
    timeoutReply = System.Convert.ToInt32( TimeoutReply );
   } 

   UtilityTraceRoute.TraceRoute
   (
    ref hostName,
    ref exceptionMessage,
    ref iPHostEntry,
    ref maximumHops,
    ref hopCount,
    ref iCMPTimeExceeded,
    ref timeoutReply
   );
 
   Feedback = exceptionMessage;

  }//public void ButtonTraceRoute_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   HostNameTarget = UtilityTraceRoute.LocalHost;
   MaximumHops    = null;
   TimeoutReply   = null;
   Feedback       = null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxHostname 
   );
  }
  
 }//TraceRoutePage class.
}//WordEngineering namespace.