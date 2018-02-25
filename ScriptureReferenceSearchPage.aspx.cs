using  System;
using  System.Collections;
using  System.Web.UI;
using  System.Web.UI.HtmlControls;
using  System.Web.UI.WebControls;
using  System.Data;
using  System.Data.OleDb;
using  System.Data.SqlClient;
using  System.Text;

using System.Threading;
using SpeechTypeLib;

using  WordEngineering;

namespace WordEngineering
{
 /// <summary>Scripture reference search page.</summary>
 /// <remarks>Scripture reference search page.</remarks>
 public class ScriptureReferenceSearchPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string databaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Bible;";
  
  /// <summary>The configuration XML filename.</summary>
  public string filenameConfigurationXml = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string serverMapPath                  = null;

  /// <summary>The server map path.</summary>
  public static string CrosswalkBibleURI = "http://bible.crosswalk.com";

  /// <summary>The search button.</summary>
  protected Button             ButtonSearch;

  /// <summary>The data grid.</summary>
  protected DataGrid           DataGridScriptureReference;
  
  /// <summary>The exception message.</summary>  
  protected Literal            LiteralFeedback;
  
  /// <summary>The TextToSpeech linkbutton.</summary>
  protected LinkButton			LinkButtonTextToSpeech;
  
  /// <summary>The Crosswalk URI HTML.</summary>  
  protected HyperLink          HyperLinkCrosswalkURIHTML;
  
  /// <summary>The Crosswalk URI XML.</summary>
  protected HyperLink          HyperLinkCrosswalkURIXML;  

  /// <summary>The Scripture Reference Text..</summary>
  protected HtmlGenericControl HtmlGenericControlScriptureReferenceText;
  
  /// <summary>The Scripture Reference.</summary>  
  protected TextBox            TextBoxScriptureReferenceSearch;
     
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   string exceptionMessage = null;
   
   serverMapPath = this.MapPath("");
   if ( serverMapPath != null)
   {
    filenameConfigurationXml = serverMapPath + @"\" + filenameConfigurationXml;
   }//if ( serverMapPath != null)
   ScriptureReference.ConfigurationXml
   (
        filenameConfigurationXml,
    ref exceptionMessage,
    ref databaseConnectionString
   );
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 
   
   if ( Page.IsPostBack )
   {
    PageSubmit();
   } 
   
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
   int                                          scriptureReferenceVerseCount                       = -1;
   string                                       exceptionMessage                                   = null;
   string                                       scriptureReference                                 = ScriptureReferenceSearch;
   string[][]                                   scriptureReferenceArray                            = null;

   StringBuilder                                scriptureReferenceText                             = null;  
   StringBuilder                                uriCrosswalkHtml                                   = null;
   StringBuilder                                uriCrosswalkXml                                    = null;   
   StringBuilder[]                              scriptureReferenceBookChapterVersePrePostCondition = null;
   StringBuilder[]                              scriptureReferenceBookChapterVersePrePostSelect    = null;
   StringBuilder                                scriptureReferenceBookChapterVersePrePostQuery     = null;

   IDataReader                                  iDataReader                                        = null;
   ScriptureReferenceBookChapterVersePrePost[]  scriptureReferenceBookChapterVersePrePost          = null;

   if ( scriptureReference == null || scriptureReference == string.Empty )
   {
    PageReset();
    return;
   }//if ( scriptureReference == null ) 

   try
   {

    ScriptureReference.ScriptureReferenceParser
    (  
         new string[] { scriptureReference },
         databaseConnectionString,
     ref exceptionMessage,
     ref scriptureReferenceBookChapterVersePrePost,
     ref scriptureReferenceArray,
     ref uriCrosswalkHtml,
     ref uriCrosswalkXml
    );	

    ScriptureReference.ScriptureReferenceQuery
    ( 
         databaseConnectionString,
     ref exceptionMessage,
     ref scriptureReferenceBookChapterVersePrePost,
     ref iDataReader,
     ref scriptureReferenceVerseCount,
     ref scriptureReferenceText,
     ref scriptureReferenceBookChapterVersePrePostCondition,
     ref scriptureReferenceBookChapterVersePrePostSelect,
     ref scriptureReferenceBookChapterVersePrePostQuery
    );
   
    if ( exceptionMessage != null )
    {
     Feedback = exceptionMessage;
    }//if ( exceptionMessage != null ) 
 
   }//try 
   catch (Exception exception) 
   {
    Feedback = exception.Message;
   }//catch
   finally 
   { 
    if ( iDataReader != null )
    {
     iDataReader.Close();
    }//if ( iDataReader != null ) 
   }//finally
   
   if ( scriptureReferenceVerseCount == 0 )
   {
    CrosswalkURIHtml = CrosswalkBibleURI;
    CrosswalkURIXml  = CrosswalkBibleURI;
    ScriptureReferenceResultSet = "";
   }//if ( scriptureReferenceVerseCount == 0 )
   else
   {
    CrosswalkURIHtml = uriCrosswalkHtml.ToString();
    CrosswalkURIXml  = uriCrosswalkXml.ToString();
    ScriptureReferenceResultSet = scriptureReferenceText.ToString();
   }//if ( scriptureReferenceVerseCount == 0 )
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
    Response.Write( Feedback );
    LiteralFeedback.Text = value;
   }
  }//public string public string Feedback

  /// <summary>Crosswalk URI Html.</summary>
  public string CrosswalkURIHtml
  {
   get
   {
    return ( HyperLinkCrosswalkURIHTML.NavigateUrl );
   } 
   set
   {
    HyperLinkCrosswalkURIHTML.NavigateUrl = value;
   }
  }//public string CrosswalkURIHtml

  /// <summary>Crosswalk URI Xml.</summary>
  public string CrosswalkURIXml
  {
   get
   {
    return ( HyperLinkCrosswalkURIXML.NavigateUrl );
   } 
   set
   {
    HyperLinkCrosswalkURIXML.NavigateUrl = value;
   }
  }//public string CrosswalkURIHtml

  /// <summary>PageReset().</summary>
  public void PageReset()
  {
   CrosswalkURIHtml = CrosswalkBibleURI;
   CrosswalkURIXml = CrosswalkBibleURI;   
   ScriptureReferenceResultSet = null; 
  }//public static void PageReset()

	/// <summary>LinkButtonTextToSpeech_Click.</summary>
	public void LinkButtonTextToSpeech_Click
	(
		object     sender, 
		EventArgs  e
	) 
	{
		if (ScriptureReferenceSearch == "")
		{
			return;
		}	
		ScriptureAudio();
	}
	
	/// <summary>LinkButtonMark_Click.</summary>
	public void LinkButtonMark_Click
	(
		object     sender, 
		EventArgs  e
	) 
	{
		if (ScriptureReferenceSearch == "")
		{
			return;
		}	
		ScriptureMark();
	}

	public void ScriptureAudio()
	{
		int                                          scriptureReferenceVerseCount                       = -1;
		string                                       exceptionMessage                                   = null;
		string[][]                                   scriptureReferenceArray                            = null;

		StringBuilder                                scriptureReferenceText                             = null;  
		StringBuilder                                uriCrosswalkHtml                                   = null;
		StringBuilder                                uriCrosswalkXml                                    = null;   
		StringBuilder[]                              scriptureReferenceBookChapterVersePrePostCondition = null;
		StringBuilder[]                              scriptureReferenceBookChapterVersePrePostSelect    = null;
		StringBuilder                                scriptureReferenceBookChapterVersePrePostQuery     = null;

		IDataReader                                  iDataReader                                        = null;
		ScriptureReferenceBookChapterVersePrePost[]  scriptureReferenceBookChapterVersePrePost          = null;
		
		ScriptureReference.ConfigurationXml
		(
			filenameConfigurationXml,
			ref exceptionMessage,
			ref databaseConnectionString
		);
		
		ScriptureReference.ScriptureReferenceParser
		(  
			new string[] { ScriptureReferenceSearch },
			databaseConnectionString,
			ref exceptionMessage,
			ref scriptureReferenceBookChapterVersePrePost,
			ref scriptureReferenceArray,
			ref uriCrosswalkHtml,
			ref uriCrosswalkXml
		);
		
		ScriptureReference.ScriptureReferenceQuery
		(
				databaseConnectionString,
			ref exceptionMessage,
			ref scriptureReferenceBookChapterVersePrePost,
			ref iDataReader,
			ref scriptureReferenceVerseCount,
			ref scriptureReferenceText,
			ref scriptureReferenceBookChapterVersePrePostCondition,
			ref scriptureReferenceBookChapterVersePrePostSelect,
			ref scriptureReferenceBookChapterVersePrePostQuery
		);

		if ( iDataReader != null )
		{
			iDataReader.Close();
		}

		DataSet dataSet = new DataSet();
		
		UtilityDatabase.DatabaseQuery
		(
				databaseConnectionString,
			ref exceptionMessage,
			ref dataSet,
				scriptureReferenceBookChapterVersePrePostQuery.ToString(),
				CommandType.Text
		);
		
		StringBuilder sbScriptureReferenceVerseText = new StringBuilder();
		
		foreach ( DataTable dataTable in dataSet.Tables )
		{
			foreach ( DataRow dataRow in dataTable.Rows )
			{
				sbScriptureReferenceVerseText.Append(dataRow["verseText"]);
			}
		}			
		
		System.Console.WriteLine(sbScriptureReferenceVerseText);
					
		SpVoice spVoice = new SpVoice();
		spVoice.Speak
		(
			sbScriptureReferenceVerseText.ToString(),
			SpeechVoiceSpeakFlags.SVSFlagsAsync
		);
		spVoice.WaitUntilDone(Timeout.Infinite);
	}
	
	public void ScriptureMark()
	{
		int                                          scriptureReferenceVerseCount                       = -1;
		string                                       exceptionMessage                                   = null;
		string[][]                                   scriptureReferenceArray                            = null;

		StringBuilder                                scriptureReferenceText                             = null;  
		StringBuilder                                uriCrosswalkHtml                                   = null;
		StringBuilder                                uriCrosswalkXml                                    = null;   
		StringBuilder[]                              scriptureReferenceBookChapterVersePrePostCondition = null;
		StringBuilder[]                              scriptureReferenceBookChapterVersePrePostSelect    = null;
		StringBuilder                                scriptureReferenceBookChapterVersePrePostQuery     = null;

		IDataReader                                  iDataReader                                        = null;
		ScriptureReferenceBookChapterVersePrePost[]  scriptureReferenceBookChapterVersePrePost          = null;

		StringBuilder				     scriptureReferenceBookChapterVersePrePostMinMax	= null;									
		ScriptureReference.ConfigurationXml
		(
			filenameConfigurationXml,
			ref exceptionMessage,
			ref databaseConnectionString
		);
		
		ScriptureReference.ScriptureReferenceParser
		(  
			new string[] { ScriptureReferenceSearch },
			databaseConnectionString,
			ref exceptionMessage,
			ref scriptureReferenceBookChapterVersePrePost,
			ref scriptureReferenceArray,
			ref uriCrosswalkHtml,
			ref uriCrosswalkXml
		);
		
		ScriptureReference.ScriptureReferenceQuery
		(
				databaseConnectionString,
			ref exceptionMessage,
			ref scriptureReferenceBookChapterVersePrePost,
			ref iDataReader,
			ref scriptureReferenceVerseCount,
			ref scriptureReferenceText,
			ref scriptureReferenceBookChapterVersePrePostCondition,
			ref scriptureReferenceBookChapterVersePrePostSelect,
			ref scriptureReferenceBookChapterVersePrePostQuery
		);

		if ( iDataReader != null )
		{
			iDataReader.Close();
		}

		DataSet dataSet = new DataSet();
		
		scriptureReferenceBookChapterVersePrePostMinMax = new StringBuilder();
		for (int index = 0; index < scriptureReferenceBookChapterVersePrePostCondition.Length; ++index)
		{
			scriptureReferenceBookChapterVersePrePostMinMax.AppendFormat
			(
				ScriptureReferenceBookChapterVersePrePost.SQLSelectChapterVerseIdSequenceMinimumMaximum,
				scriptureReferenceBookChapterVersePrePostCondition[index]
			); 				
		}

		UtilityDatabase.DatabaseQuery
		(
			databaseConnectionString,
			ref exceptionMessage,
			ref dataSet,
			scriptureReferenceBookChapterVersePrePostMinMax.ToString(),
			CommandType.Text
		);
		
		StringBuilder chapterVerseIdSequenceMinimumMaximum = new StringBuilder();
		
		int verseIdSequenceMinimum , verseIdSequenceMaximum;
		int chapterIdSequenceMinimum, chapterIdSequenceMaximum;

		foreach ( DataTable dataTable in dataSet.Tables )
		{
			foreach ( DataRow dataRow in dataTable.Rows )
			{
				verseIdSequenceMinimum = Convert.ToInt32(dataRow["verseIdSequenceMinimum"]);
				verseIdSequenceMaximum = Convert.ToInt32(dataRow["verseIdSequenceMaximum"]);
				chapterIdSequenceMinimum = Convert.ToInt32(dataRow["chapterIdSequenceMinimum"]);
				chapterIdSequenceMaximum = Convert.ToInt32(dataRow["chapterIdSequenceMaximum"]);

				chapterVerseIdSequenceMinimumMaximum.AppendFormat
				(
					ScriptureReferenceBookChapterVersePrePost.ChapterVerseIdSequenceMinimumMaximumFormat,
					chapterIdSequenceMinimum,
					100 * chapterIdSequenceMinimum / ScriptureReferenceBookChapterVersePrePost.ChapterIdSequenceMaximum,
					verseIdSequenceMinimum,
					100 * verseIdSequenceMinimum / ScriptureReferenceBookChapterVersePrePost.VerseIdSequenceMaximum
				);

				if (verseIdSequenceMinimum != verseIdSequenceMaximum)
				{
					chapterVerseIdSequenceMinimumMaximum.Append("  ");
					chapterVerseIdSequenceMinimumMaximum.AppendFormat
					(
						ScriptureReferenceBookChapterVersePrePost.ChapterVerseIdSequenceMinimumMaximumFormat,
						chapterIdSequenceMaximum,
						100 * chapterIdSequenceMaximum / ScriptureReferenceBookChapterVersePrePost.ChapterIdSequenceMaximum,
						verseIdSequenceMaximum,
						100 * verseIdSequenceMaximum / ScriptureReferenceBookChapterVersePrePost.VerseIdSequenceMaximum
					);
				}

				chapterVerseIdSequenceMinimumMaximum.Append("<br />");
			}
		}			
		
		//Response.Write(chapterVerseIdSequenceMinimumMaximum.ToString());

		ScriptureReferenceResultSet = chapterVerseIdSequenceMinimumMaximum.ToString();					
	}

  /// <summary>Scripture Reference Search.</summary>
  public string ScriptureReferenceSearch
  {
   get
   {
    return ( TextBoxScriptureReferenceSearch.Text.Trim() );
   } 
   set
   {
    TextBoxScriptureReferenceSearch.Text = value;
   }
  }//public string ScriptureReferenceSearch

  /// <summary>Scripture Reference ResultSet.</summary>
  public string ScriptureReferenceResultSet
  {
   get
   {
    return ( HtmlGenericControlScriptureReferenceText.InnerHtml.Trim() );
   } 
   set
   {
    HtmlGenericControlScriptureReferenceText.InnerHtml = value;
   }
  }//public string ScriptureReferenceResultSet
  	
 }//ScriptureReferenceSearchPage class.
}//WordEngineering namespace.