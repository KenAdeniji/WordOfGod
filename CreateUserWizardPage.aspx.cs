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
 /// <summary>CreateUserWizardPage</summary>
 public partial class CreateUserWizardPage : System.Web.UI.Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>CreateUserWizardMembership</summary>  
  protected System.Web.UI.WebControls.CreateUserWizard       CreateUserWizardMembership;

  /// <summary>LiteralFeedback</summary>  
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

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

   /*
   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        UtilityImage.XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );
   */

   if ( exceptionMessage != null )
   {
    Response.Write( exceptionMessage );
    return;
   }//if ( exceptionMessage != null )

  }//Page_Load

  /// <summary>CreateUserWizard_SendingMail</summary>
  public void CreateUserWizard_SendingMail
  (
   object               sender, 
   MailMessageEventArgs e
  )
  {

   // Set MailMessage fields.
   //e.Message.IsBodyHtml = true;

   // Replace placeholder text in message body with information provided by the user.
   e.Message.Body.Replace("<%PasswordQuestion%>", CreateUserWizardMembership.Question);
   e.Message.Body.Replace("<%PasswordAnswer%>",   CreateUserWizardMembership.Answer);
   
  }//public void CreateUserWizard_SendingMail()

  /// <summary>CreateUserWizard_SendingMailError</summary>
  public void CreateUserWizard_SendMailError
  (
   object                  sender, 
   SendMailErrorEventArgs  sendMailErrorEventArgs
  )
  {
   UtilityEventLog.WriteEntry
   (
    "Application", //Log
    null,          //Machine name
    "Membership",  //Source
    "Sending mail via SMTP failed with the following error: " + 
    sendMailErrorEventArgs.Exception.Message.ToString(), 
    System.Diagnostics.EventLogEntryType.Error
   );
   sendMailErrorEventArgs.Handled = true;
  }//public void CreateUserWizard_SendMailError()
  
 }//CreateUserWizardPage class.
}//WordEngineering namespace.