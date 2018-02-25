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
 /// <summary>GutenbergKoreanEnglishDictionary page.</summary>
 public class GutenbergKoreanEnglishDictionaryPage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Gutenberg;";

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

  /// <summary>TextBoxEnglishWord.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxEnglishWord;

  /// <summary>TextBoxKoreanWord.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxKoreanWord;

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

   GutenbergKoreanEnglishDictionary.ConfigurationXml
   (
    ref FilenameConfigurationXml,
    ref exceptionMessage,
    ref DatabaseConnectionString
   );

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
    return ( TextBoxEnglishWord.Text.Trim() );
   }//get 
   set
   {
    TextBoxEnglishWord.Text = value;
   }//set
  }//public String EnglishWord

  /// <summary>KoreanWord.</summary>
  public String KoreanWord
  {
   get
   {
    return ( TextBoxKoreanWord.Text.Trim() );
   }//get 
   set
   {
    TextBoxKoreanWord.Text = value;
   }//set
  }//public String KoreanWord

  /// <summary>ButtonKoreanConsonant_Click().</summary>
  public void ButtonKoreanConsonant_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   StringBuilder  sbKoreanEnglish  =  null;
   
   GutenbergKoreanEnglishDictionary.KoreanEnglish
   (
    ref  GutenbergKoreanEnglishDictionary.KoreanConsonant,
    ref  sbKoreanEnglish,
    ref  GutenbergKoreanEnglishDictionary.KoreanTableHeaderConsonant
   );
   
   Feedback = sbKoreanEnglish.ToString();
   
  }//public void ButtonKoreanConsonant_Click()

  /// <summary>ButtonKoreanVowel_Click().</summary>
  public void ButtonKoreanVowel_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   StringBuilder  sbKoreanEnglish  =  null;
   
   GutenbergKoreanEnglishDictionary.KoreanEnglish
   (
    ref  GutenbergKoreanEnglishDictionary.KoreanVowel,
    ref  sbKoreanEnglish,
    ref  GutenbergKoreanEnglishDictionary.KoreanTableHeaderVowel
   );
   
   Feedback = sbKoreanEnglish.ToString();
   
  }//public void ButtonKoreanVowel_Click()

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   String                exceptionMessage    =  null;
   
   /*
   UtilityGutenbergKoreanEnglishDictionary.Query
   (
    ref englishWord,    
    ref koreanWord
   );
   */

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
   
   KoreanWord      =  null;
   EnglishWord     =  null;
   
   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxEnglishWord
   );

  }//public void ButtonReset_Click()
  
 }//GutenbergKoreanEnglishDictionaryPage class.
}//GutenbergKoreanEnglishDictionary namespace.