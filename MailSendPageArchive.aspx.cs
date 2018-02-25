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
 /// <summary>MailSend page.</summary>
 public class MailSendPage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>DefaultSmtpPort</summary>
  public int    DefaultSmtpPort                = UtilityMail.SmtpPort;

  /// <summary>DefaultSmtpServer</summary>
  public String DefaultSmtpServer              = UtilityMail.SmtpServer;

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

  /// <summary>TextBoxSmtpPort</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxSmtpPort;

  /// <summary>TextBoxSmtpServer.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxSmtpServer;

  /// <summary>TextBoxFrom.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxFrom;

  /// <summary>TextBoxTo.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxTo;

  /// <summary>TextBoxCc.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxCc;

  /// <summary>TextBoxBcc.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxBcc;

  /// <summary>TextBoxSubject.</summary>
  protected System.Web.UI.WebControls.TextBox            TextBoxSubject;

  /// <summary>TextBoxBody.</summary>
  protected System.Web.UI.WebControls.TextBox            TextBoxBody;
  
  /// <summary>TextBoxUserState.</summary>
  protected System.Web.UI.WebControls.TextBox            TextBoxUserState;

  /// <summary>HtmlInputFileAttachment.</summary>
  protected System.Web.UI.HtmlControls.HtmlInputFile     HtmlInputFileAttachment;

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

   UtilityMail.ConfigurationXml
   (
        FilenameConfigurationXml,
    ref exceptionMessage,
    ref DatabaseConnectionString,
    ref DefaultSmtpPort,
    ref DefaultSmtpServer
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

   SmtpPort    =  DefaultSmtpPort;
   SmtpServer  =  DefaultSmtpServer;

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

  /// <summary>SmtpPort</summary>
  public int SmtpPort
  {
   get
   {
    int  smtpPort  =  -1;
    Int32.TryParse( TextBoxSmtpPort.Text, out smtpPort );
    return ( smtpPort );
   }//get 
   set
   {
    TextBoxSmtpPort.Text = value.ToString();
   }//set
  }//public String SmtpPort

  /// <summary>SmtpServer</summary>
  public String SmtpServer
  {
   get
   {
    return ( TextBoxSmtpServer.Text );
   }//get 
   set
   {
    TextBoxSmtpServer.Text = value;
   }//set
  }//public String SmtpServer

  /// <summary>From.</summary>
  public String From
  {
   get
   {
    return ( TextBoxFrom.Text );
   }//get 
   set
   {
    TextBoxFrom.Text = value;
   }//set
  }//public String From

  /// <summary>To.</summary>
  public String To
  {
   get
   {
    return ( TextBoxTo.Text );
   }//get 
   set
   {
    TextBoxTo.Text = value;
   }//set
  }//public String To

  /// <summary>Cc.</summary>
  public String Cc
  {
   get
   {
    return ( TextBoxCc.Text );
   }//get 
   set
   {
    TextBoxCc.Text = value;
   }//set
  }//public String Cc

  /// <summary>Bcc.</summary>
  public String Bcc
  {
   get
   {
    return ( TextBoxBcc.Text );
   }//get 
   set
   {
    TextBoxBcc.Text = value;
   }//set
  }//public String Bcc

  /// <summary>Subject.</summary>
  public String Subject
  {
   get
   {
    return ( TextBoxSubject.Text );
   }//get 
   set
   {
    TextBoxSubject.Text = value;
   }//set
  }//public String Subject

  /// <summary>Body.</summary>
  public String Body
  {
   get
   {
    return ( TextBoxBody.Text );
   }//get 
   set
   {
    TextBoxBody.Text = value;
   }//set
  }//public String Body

  /// <summary>Attachment.</summary>
  public String Attachment
  {
   get
   {
    return ( HtmlInputFileAttachment.Value );
   }//get 
  }//public String Attachment

  /// <summary>UserState.</summary>
  public String UserState
  {
   get
   {
    return ( TextBoxUserState.Text );
   }//get 
   set
   {
    TextBoxUserState.Text = value;
   }//set
  }//public String UserState

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   int       smtpPort          =  -1;
   String    exceptionMessage  =  null;

   String    smtpServer        =  null;
   String    from              =  null;
   String    to                =  null;
   String    cc                =  null;
   String    bcc               =  null;
   String    subject           =  null;
   String    body              =  null;
   String[]  attachment        =  null;
   String    userState         =  null;

   UtilityMailArgument           utilityMailArgument               =  null;
   
   smtpPort                  =  SmtpPort;
   smtpServer                =  SmtpServer;
   from                      =  From;
   to                        =  To;
   cc                        =  Cc;
   bcc                       =  Bcc;
   subject                   =  Subject;
   body                      =  Body;
   attachment                =  new String[] { Attachment };
   userState                 =  UserState;

   utilityMailArgument = new UtilityMailArgument
   (
    smtpPort,
    smtpServer,
    from,
    to,
    cc,
    bcc,
    subject,
    body,
    attachment,
    userState
   );

   UtilityMail.MailSend
   (
    ref utilityMailArgument,
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

   Feedback               =  null;
   
   SmtpPort    =  UtilityMail.SmtpPort;
   SmtpServer  =  UtilityMail.SmtpServer;
   From        =  null;
   To          =  null;
   Cc          =  null;
   Bcc         =  null;
   Subject     =  null;
   Body        =  null;
  }//public void ButtonReset_Click()
  
 }//MailSendPage class.
}//WordEngineering namespace.