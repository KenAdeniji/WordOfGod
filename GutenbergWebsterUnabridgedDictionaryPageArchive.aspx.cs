using  System;
using  System.Collections;
using  System.Web.UI;
using  System.Web.UI.HtmlControls;
using  System.Web.UI.WebControls;
using  System.Data;
using  System.Data.OleDb;
using  System.Data.SqlClient;
using  System.Text;

using  WordEngineering;

namespace WordEngineering
{
 /// <summary>Gutenberg Webster Unabridged Dictionary Web Form Page.</summary>
 public class GutenbergWebsterUnabridgedDictionaryPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string databaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=Gutenberg;Integrated Security=SSPI;";
  
  /// <summary>The configuration XML filename.</summary>
  public string filenameConfigurationXml = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string serverMapPath                  = null;

  /// <summary>The search button.</summary>
  protected Button                  ButtonSearch;
 
  /// <summary>The Search result.</summary>
  protected HtmlGenericControl      HtmlGenericControlSearchResult;

  /// <summary>The exception message.</summary>  
  protected Literal                 LiteralFeedback;

  /// <summary>With all of the words.</summary>  
  protected TextBox                 TextBoxDictionaryWord;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   string              exceptionMessage                = null;
 
   serverMapPath = this.MapPath("");
   if ( serverMapPath != null)
   {
    filenameConfigurationXml = serverMapPath + @"\" + filenameConfigurationXml;
   }//if ( serverMapPath != null)
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,         
         GutenbergRogetThesaurusOfEnglishWordsAndPhrases.XPathDatabaseConnectionString,
     ref GutenbergRogetThesaurusOfEnglishWordsAndPhrases.DatabaseConnectionString
   );
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 
  }//Page_Load

  /// <summary>ButtonSearch_Click().</summary>
  public void ButtonSearch_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   PageSubmit();
  }
  
  /// <summary>PageSubmit().</summary>
  public void PageSubmit()
  {
   string        dictionaryWordQuery = DictionaryWord;
   string        exceptionMessage    = null;
   StringBuilder sbResultElement     = null;
   
   GutenbergWebsterUnabridgedDictionary.Search
   (
        dictionaryWordQuery,
    ref exceptionMessage,
    ref sbResultElement
   );

   if ( exceptionMessage == null )
   {
   	SearchResult = sbResultElement.ToString();
   }//if ( exceptionMessage == null )	
   else
   {
    Feedback = exceptionMessage;
   }//if ( exceptionMessage != null ) 
   
  }//public void PageSubmit()

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

  /// <summary>Search Result.</summary>
  public string SearchResult
  {
   get
   {
    return ( HtmlGenericControlSearchResult.InnerHtml.Trim() );
   } 
   set
   {
    HtmlGenericControlSearchResult.InnerHtml = value;
   }
  }//public string SearchResult

  /// <summary>Dictionary word.</summary>
  public string DictionaryWord
  {
   get
   {
    return (TextBoxDictionaryWord.Text);
   } 
   set
   {
    TextBoxDictionaryWord.Text = value;
   }
  }//public string public string DictionaryWord

 }//GutenbergWebsterUnabridgedDictionaryWebFormPage class.
}//WordEngineering namespace.