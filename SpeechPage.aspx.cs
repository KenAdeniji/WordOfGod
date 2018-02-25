using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

using SpeechTypeLib;

namespace WordEngineering
{
 /// <summary>SpeechPage</summary>
 public class SpeechPage : Page
 {
  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>ImpersonateDomainName</summary>
  public string ImpersonateDomainName          =  null;

  /// <summary>ImpersonatePassword</summary>
  public string ImpersonatePassword            =  null;
   
  /// <summary>ImpersonateUserName</summary>
  public string ImpersonateUserName            =  null;

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>ButtonReset</summary>
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>CheckBoxXml</summary>  
  protected System.Web.UI.WebControls.CheckBox               CheckBoxXml;

  /// <summary>FileUploadAudio</summary>  
  protected System.Web.UI.WebControls.FileUpload             FileUploadAudio;

  /// <summary>FileUploadSource</summary>  
  protected System.Web.UI.WebControls.FileUpload             FileUploadSource;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>PanelSpeech</summary>
  protected System.Web.UI.WebControls.Panel                  PanelSpeech;

  /// <summary>TextBoxText</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxText;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   string  exceptionMessage  =  null;
   ServerMapPath = this.MapPath("");
   FilenameConfigurationXml = Path.Combine( ServerMapPath, FilenameConfigurationXml );
   UtilityImpersonate.GetUsernamePasswordDomainName
   (
    ref FilenameConfigurationXml,
    ref ImpersonateDomainName,
    ref ImpersonatePassword,
    ref ImpersonateUserName,
    ref exceptionMessage
   );
   if ( exceptionMessage != null ) { Feedback = exceptionMessage; return; }
   if ( !Page.IsPostBack )
   {
    TextBoxText.Focus();
    Page.SetFocus( TextBoxText );
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
  }//public String Feedback

  /// <summary>ButtonReset_Click()</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   CheckBoxXml.Checked  =  false;
   Feedback             =  null;
   TextBoxText          =  null;
   TextBoxText.Focus();   
  }//public void ButtonReset_Click()

  /// <summary>ButtonSubmit_Click()</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   SpVoiceSpeak();   
  }//public void ButtonSubmit_Click()

  /// <summary>SpVoiceSpeak</summary>
  public void SpVoiceSpeak()
  {
   bool                         impersonateValidUser         =  false;
   string                       exceptionMessage             =  null;
   WindowsImpersonationContext  windowsImpersonationContext  =  null;
   UtilitySpeechArgument        utilitySpeechArgument        =  null;
   utilitySpeechArgument = new UtilitySpeechArgument
   (
    CheckBoxXml.Checked,
    new string[] { FileUploadSource.PostedFile.FileName },
    FileUploadAudio.PostedFile.FileName,
    new string[] { TextBoxText.Text },
    null   //voice
   );
   try
   {
    impersonateValidUser = UtilityImpersonate.ImpersonateValidUser
    (
     ref ImpersonateDomainName,
     ref ImpersonatePassword,
     ref ImpersonateUserName,     
     ref windowsImpersonationContext,
     ref exceptionMessage
    );
    if ( exceptionMessage != null ) { Feedback = exceptionMessage; return; }
    if ( impersonateValidUser == false ) { return; }
    UtilitySpeech.SpVoiceSpeak
    (
     ref utilitySpeechArgument,
     ref exceptionMessage
    );
    UtilityImpersonate.UndoImpersonation
    (
     ref windowsImpersonationContext,
     ref exceptionMessage
    );
   }//try
   catch ( Exception exception ) { exceptionMessage = exception.Message; }
   if ( exceptionMessage != null ) { Feedback = exceptionMessage; }
  }//public static void SpVoiceSpeak()
 
 }//SpeechPage class.
}//WordEngineering namespace.
