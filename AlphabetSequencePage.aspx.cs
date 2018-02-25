using  System;
using  System.Collections;
using  System.Web.UI;
using  System.Web.UI.WebControls;
using  System.Data;
using  System.Data.OleDb;
using  System.Data.SqlClient;
using  System.Text;

using  WordEngineering;

namespace WordEngineering
{
 /// <summary>AlphabetSequencePage.</summary>
 public class AlphabetSequencePage : Page
 {
  /// <summary>The database connection string.</summary>
  protected string    databaseConnectionString      = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Bible;";
  
  /// <summary>The exception message.</summary>
  protected string    exceptionMessage              = null;
  
  /// <summary>The XML Configuration file name.</summary>  
  protected string    filenameConfigurationXml      = @"WordEngineering.config";
  
  /// <summary>The server map path.</summary>
  protected string    serverMapPath                 = null;

  /// <summary>The query button.</summary>
  protected Button    ButtonQuery;

  /// <summary>The Alphabet Sequence label.</summary>
  protected Label     LabelAlphabetSequence;
  
  /// <summary>The exception message label.</summary>
  protected Label     LabelExceptionMessage;

  /// <summary>The Scripture Reference Associates label.</summary>
  protected Label     LabelScriptureReferenceAssociates;
  
  /// <summary>The word label.</summary>  
  protected Label     LabelWord;
  
  /// <summary>The word textbox.</summary>
  protected TextBox   TextBoxWord;
  
  /// <summary>The alphabet sequence textbox.</summary>
  protected TextBox   TextBoxAlphabetSequence;

  /// <summary>The scripture reference textbox.</summary>
  protected TextBox   TextBoxScriptureReference;

  /// <summary>The Scripture Reference Associates textbox.</summary>
  protected TextBox   TextBoxScriptureReferenceAssociates;
  
  /// <summary>The verse forward textbox.</summary>
  protected TextBox   TextBoxVerseForward;
  
  /// <summary>The chapter forward textbox.</summary>
  protected TextBox   TextBoxChapterForward;
  
  /// <summary>The chapter backward textbox.</summary>  
  protected TextBox   TextBoxChapterBackward;
  
  /// <summary>The verse backward textbox.</summary>    
  protected TextBox   TextBoxVerseBackward;
  
  /// <summary>The scripture reference for the Crosswalk URI HTML textbox.</summary>
  protected TextBox   TextBoxScriptureReferenceCrosswalkURIHtml;
  
  /// <summary>The scripture reference for the Crosswalk URI XML textbox.</summary>  
  protected TextBox   TextBoxScriptureReferenceCrosswalkURIXml;
  
  /// <summary>The alphabet sequence repeater.</summary>  
  protected Repeater  RepeaterAlphabetSequence;

  /// <summary>Page_Load</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
  
   serverMapPath = this.MapPath("");
   AlphabetSequence.ConfigurationXml
   (
        serverMapPath + @"\" + filenameConfigurationXml,
    ref exceptionMessage,
    ref databaseConnectionString
   );

   if ( exceptionMessage != null )
   {
    LabelExceptionMessage.Text = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 

   if (!Page.IsPostBack) 
   {
   }//if (!Page.IsPostBack)  
  
  }//Page_Load

  /// <summary>ButtonQuery_Click</summary>
  public void ButtonQuery_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   int[]                                 alphabetSequence                   = new int[1];
   string[]                              word                               = new string[1];
   string                                scriptureReferenceAssociates       = "Genesis 1";
   ScriptureReferenceAlphabetSequence[]  scriptureReferenceAlphabetSequence = new ScriptureReferenceAlphabetSequence[1];

   word[0] = TextBoxWord.Text.Trim();
   scriptureReferenceAssociates = TextBoxScriptureReferenceAssociates.Text.Trim();
   try
   {

    AlphabetSequence.DatabaseQuery
    ( 
     ref databaseConnectionString,
     ref exceptionMessage,
         word,
         scriptureReferenceAssociates,
     ref alphabetSequence, 
     ref scriptureReferenceAlphabetSequence
    );
    
    if ( exceptionMessage != null )
    {
     LabelExceptionMessage.Text = "if ( exceptionMessage != null )";
     Response.Write("if ( exceptionMessage != null )");
    }//if ( exceptionMessage != null ) 

    TextBoxAlphabetSequence.Text                   = Convert.ToString( alphabetSequence[0] );
   
    TextBoxAlphabetSequence.Text                   = Convert.ToString( scriptureReferenceAlphabetSequence[0].AlphabetSequence );
    TextBoxScriptureReference.Text                 = scriptureReferenceAlphabetSequence[0].ScriptureReferenceCurrent;
    TextBoxVerseForward.Text                       = scriptureReferenceAlphabetSequence[0].VerseForward;
    TextBoxChapterForward.Text                     = scriptureReferenceAlphabetSequence[0].ChapterForward;
    TextBoxChapterBackward.Text                    = scriptureReferenceAlphabetSequence[0].ChapterBackward;
    TextBoxVerseBackward.Text                      = scriptureReferenceAlphabetSequence[0].VerseBackward;

    RepeaterAlphabetSequence.DataSource = scriptureReferenceAlphabetSequence;
    RepeaterAlphabetSequence.DataBind();

   }//try 
   catch (Exception exception) 
   {
    LabelExceptionMessage.Text = exception.Message;	
   }//catch
   finally 
   { 

   }//finally    
  }//ButtonQuery_Click

  /// <summary>ButtonDatabaseQueryChapterMaximum_Click</summary>
  public void ButtonDatabaseQueryChapterMaximum_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   int    chapterMaximum      = -1;
   
   object databaseReturnValue = null;
   string word                = TextBoxWord.Text.Trim();
   
   databaseReturnValue = UtilityDatabase.DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage, 
        "uspChapterMaximum",
        CommandType.StoredProcedure    
   );

   if ( exceptionMessage != null )
   {
    LabelExceptionMessage.Text = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 
   
   chapterMaximum = (Int32) databaseReturnValue;
   TextBoxAlphabetSequence.Text = System.Convert.ToString( chapterMaximum );
  }//ButtonDatabaseQueryChapterMaximum_Click
  
 }//AlphabetSequencePage
}//WordEngineering namespace.