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
 /// <summary>SubnetMask page.</summary>
 public class SubnetMaskPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>ButtonSubnetMask.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonSubnetMask;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonReset;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal      LiteralFeedback;

  /// <summary>TextBoxTimeoutReply.</summary>  
  protected System.Web.UI.WebControls.TextBox      TextBoxTimeoutReply;

  /// <summary>WindowsImpersonationContext.</summary>  
  public    WindowsImpersonationContext            windowsImpersonationContext  =  null; 

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   Boolean                      statusImpersonateValidUser     =  false;
   Boolean                      statusRevertToSelf             =  false;

   int                          statusLogonUserA               =  -1;
   int                          statusDuplicateToken           =  -1;

   IntPtr                       token                          =  IntPtr.Zero;
   IntPtr                       tokenDuplicate                 =  IntPtr.Zero;

   String                       domainName                     =  null;
   String                       exceptionMessage               =  null;
   String                       password                       =  null;
   String                       userName                       =  null;
   
   ServerMapPath = this.MapPath("");
   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        UtilitySubnetMask.XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

   UtilityImpersonate.Impersonate
   (
    ref FilenameConfigurationXml,
    ref userName,
    ref domainName,
    ref password,
    ref windowsImpersonationContext,
    ref exceptionMessage,
    ref statusImpersonateValidUser,
    ref statusRevertToSelf,
    ref statusLogonUserA,
    ref statusDuplicateToken,
    ref token,
    ref tokenDuplicate
   );

   if ( exceptionMessage != null )
   {
     Feedback = exceptionMessage;
     return;
   }//if ( exceptionMessage != null )

  }//Page_Load

  ///<summary>Page Unload.</summary>
  public void Page_Unload
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   String  exceptionMessage = null;

   UtilityImpersonate.UndoImpersonation
   (
    ref windowsImpersonationContext,
    ref exceptionMessage
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

  }//public void Page_Unload()

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

  /// <summary>ButtonSubnetMask_Click().</summary>
  public void ButtonSubnetMask_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   int          socketHostAvailable            =  -1;
   int          socketHostAvailableTimeElapse  =  -1;   
   int          socketHostAvailableTimeOut     =  -1;

   String       exceptionMessage  = null;
   
   IPAddress    iPAddressSubnetMask            =  null;

   UtilityICMP  utilityICMPPacketRequest       =  null;
   UtilityICMP  utilityICMPPacketResponse      =  null;

   if ( TimeoutReply != null && TimeoutReply != String.Empty )
   {
    socketHostAvailableTimeOut = System.Convert.ToInt32( TimeoutReply );
   }
   
   UtilitySubnetMask.SubnetMask
   (
    ref  exceptionMessage,
    ref  iPAddressSubnetMask,
    ref  utilityICMPPacketRequest,
    ref  utilityICMPPacketResponse,
    ref  socketHostAvailable,
    ref  socketHostAvailableTimeOut,
    ref  socketHostAvailableTimeElapse
   );

   Feedback = exceptionMessage;
   
   if ( exceptionMessage != null )
   {
    return;
   }
   
   Response.Write( iPAddressSubnetMask );
   Response.Write( utilityICMPPacketRequest );
   Response.Write( utilityICMPPacketResponse );
   Response.Write( socketHostAvailable );
   Response.Write( socketHostAvailableTimeOut );
   Response.Write( socketHostAvailableTimeElapse );

 
  }//public void ButtonSubnetMask_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   TimeoutReply   = null;
   Feedback       = null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxTimeoutReply
   );
  }
  
 }//SubnetMaskPage class.
}//WordEngineering namespace.