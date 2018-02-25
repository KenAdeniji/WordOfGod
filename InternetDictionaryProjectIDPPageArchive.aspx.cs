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
 /// <summary>InternetDictionaryProjectIDP page.</summary>
 public class InternetDictionaryProjectIDPPage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=InternetDictionaryProjectIDP;";

  /// <summary>The DatabaseFile.</summary>
  public String DatabaseFile                   = null;

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

  /// <summary>TextBoxEnglish.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxEnglish;

  /// <summary>TextBoxFrench.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxFrench;

  /// <summary>TextBoxGerman.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxGerman;

  /// <summary>TextBoxItalian.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxItalian;

  /// <summary>TextBoxLatin.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxLatin;

  /// <summary>TextBoxPortuguese.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxPortuguese;

  /// <summary>TextBoxSpanish.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxSpanish;

  /// <summary>RepeaterInternetDictionaryProjectIDP.</summary>  
  protected System.Web.UI.WebControls.Repeater           RepeaterInternetDictionaryProjectIDP;

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

  /// <summary>EnglishWord.</summary>
  public String EnglishWord
  {
   get
   {
    return ( TextBoxEnglish.Text.Trim() );
   }//get 
   set
   {
    TextBoxEnglish.Text = value;
   }//set
  }//public String EnglishWord

  /// <summary>FrenchCommentary.</summary>
  public String FrenchCommentary
  {
   get
   {
    return ( TextBoxFrench.Text.Trim() );
   }//get 
   set
   {
    TextBoxFrench.Text = value;
   }//set
  }//public String FrenchCommentary

  /// <summary>GermanCommentary.</summary>
  public String GermanCommentary
  {
   get
   {
   	return ( TextBoxGerman.Text.Trim() );
   }//get 
   set
   {
    TextBoxGerman.Text = value;
   }//set
  }//public String GermanCommentary

  /// <summary>ItalianCommentary.</summary>
  public String ItalianCommentary
  {
   get
   {
    return ( TextBoxItalian.Text.Trim() );
   }//get 
   set
   {
    TextBoxItalian.Text = value;
   }//set
  }//public String ItalianCommentary

  /// <summary>LatinCommentary.</summary>
  public String LatinCommentary
  {
   get
   {
    return ( TextBoxLatin.Text.Trim() );
   }//get 
   set
   {
    TextBoxLatin.Text = value;
   }//set
  }//public String LatinCommentary

  /// <summary>PortugueseCommentary.</summary>
  public String PortugueseCommentary
  {
   get
   {
    return ( TextBoxPortuguese.Text.Trim() );
   }//get 
   set
   {
    TextBoxPortuguese.Text = value;
   }//set
  }//public String PortugueseCommentary

  /// <summary>SpanishCommentary.</summary>
  public String SpanishCommentary
  {
   get
   {
    return ( TextBoxSpanish.Text.Trim() );
   }//get 
   set
   {
    TextBoxSpanish.Text = value;
   }//set
  }//public String SpanishCommentary

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   String                                       exceptionMessage                                    =  null;
   
   StringBuilder                                internetDictionaryProjectIDPSQL                     =  null;
   StringBuilder                                internetDictionaryProjectIDPQuery                   =  null;   

   IDataReader                                  iDataReader                                         =  null;

   InternetDictionaryProjectIDPArgument         internetDictionaryProjectIDPArgument                =  null;

   internetDictionaryProjectIDPArgument = new InternetDictionaryProjectIDPArgument
   (
    EnglishWord,
    FrenchCommentary,
    GermanCommentary,
    ItalianCommentary,
    LatinCommentary,
    PortugueseCommentary,
    SpanishCommentary
   );

   InternetDictionaryProjectIDP.ConfigurationXml
   (
    ref FilenameConfigurationXml,
    ref exceptionMessage,
    ref DatabaseConnectionString,
    ref DatabaseFile
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   	return;
   }//if ( exceptionMessage != null )   	

   InternetDictionaryProjectIDP.Query
   (
    ref DatabaseConnectionString,
    ref exceptionMessage,
    ref internetDictionaryProjectIDPArgument,
    ref internetDictionaryProjectIDPSQL,
    ref internetDictionaryProjectIDPQuery,
    ref iDataReader
   );

   if ( exceptionMessage != null || iDataReader == null )
   {
    Feedback = exceptionMessage;
   	return;
   }//if ( exceptionMessage != null || iDataReader == null )
   
   RepeaterInternetDictionaryProjectIDP.DataSource = iDataReader;
   RepeaterInternetDictionaryProjectIDP.DataBind();
 
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback              =  null;
   
   EnglishWord           =  null;
   FrenchCommentary      =  null;
   GermanCommentary      =  null;
   ItalianCommentary     =  null;
   LatinCommentary       =  null;
   PortugueseCommentary  =  null;
   SpanishCommentary     =  null;
   
   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxEnglish
   );

  }//public void ButtonReset_Click()
  
 }//InternetDictionaryProjectIDPPage class.
}//InternetDictionaryProjectIDP namespace.