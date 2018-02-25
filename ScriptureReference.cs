using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Security;
using System.Xml;

/*
 csc /doc:ScriptureReferenceDocumentation.xml /main:WordEngineering.ScriptureReference /out:ScriptureReference.exe /target:exe BibleBookTitle.cs ScriptureReference.cs ScriptureReferenceSubset.cs UtilityCollection.cs UtilityDatabase.cs UtilityXml.cs UtilityEventLog.cs
*/
/*
 20031008 ScriptureReferenceURI() viewContact. if ( tableName.IndexOf("View" ) < 0 ) { boolView = false; SQLStatement.AppendFormat( InformationSchemaColumnNamePrimaryColumnSQL, tableName ); } else { boolView = true;	SQLStatement.AppendFormat( InformationSchemaColumnNamePrimaryColumnSQL, tableName.Substring(4) ); } columnNamePrimary = String.Concat( tableName.Substring(4), columnNamePrimary );	
*/ 
namespace WordEngineering
{
 /// <summary>Scripture Reference.</summary>
 public class ScriptureReference
 {

  /// <summary>The scripture reference book.</summary>
  public const int ScriptureReferenceBook                          = 0;

  /// <summary>The scripture reference chapter.</summary>
  public const int ScriptureReferenceChapter                       = 1;

  /// <summary>The scripture reference book pre.</summary>
  public const int ScriptureReferencePreBook                       = 0;

  /// <summary>The scripture reference chapter pre.</summary>
  public const int ScriptureReferencePreChapter                    = 1;

  /// <summary>The scripture reference element total.</summary>
  public const int ScriptureReferenceSubsetElementTotal            = 6;

  /// <summary>The scripture reference verse pre.</summary>
  public const int ScriptureReferencePreVerse                      = 2;

  /// <summary>The scripture reference book post.</summary>
  public const int ScriptureReferencePostBook                      = 3;

  /// <summary>The scripture reference chapter post.</summary>
  public const int ScriptureReferencePostChapter                   = 4;

  /// <summary>The scripture reference verse post.</summary>
  public const int ScriptureReferencePostVerse                     = 5;

  /// <summary>The scripture reference subset pre.</summary>
  public const int ScriptureReferenceSubsetPre                     = 0;

  /// <summary>The scripture reference subset post.</summary>
  public const int ScriptureReferenceSubsetPost                    = 1;

  /// <summary>The scripture reference subset pre-post post.</summary>
  public const int ScriptureReferenceSubsetPrePostPost             = 1;

  /// <summary>The scripture reference subset book and chapter.</summary>
  public const int ScriptureReferenceSubsetPrePostBookChapter      = 0;

  /// <summary>The scripture reference subset verse.</summary>
  public const int ScriptureReferenceSubsetPrePostVerse            = 1;

  /// <summary>The scripture reference verse.</summary>
  public const int ScriptureReferenceVerse                         = 2;

  /// <summary>The delimiter in character array format for the scripture reference subset</summary>
  public static char[] DelimiterCharScriptureReferenceSubset       = null;

  /// <summary>The delimiter in character array format for the scripture reference pre and post.</summary>
  public static char[] DelimiterCharScriptureReferencePrePost      = null;

  /// <summary>The delimiter in character array format for the scripture reference chapter and verse.</summary>
  public static char[] DelimiterCharScriptureReferenceChapterVerse = null;

  /// <summary>The Bible XML filename.</summary>
  public static string BibleXmlFilename                            = "Comforter_-_BibleKJV.xml";

  /// <summary>The database connection string.</summary>
  public static string DatabaseConnectionString                    = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Bible;";

  /// <summary>The delimiter string for the scripture reference subset.</summary>
  public const string DelimiterStringScriptureReferenceSubset       = ",;";

  /// <summary>The delimiter string for the scripture reference pre and post.</summary>
  public const string DelimiterStringScriptureReferencePrePost      = "-";

  /// <summary>The delimiter string for the scripture reference chapter and verse.</summary>
  public const string DelimiterStringScriptureReferenceChapterVerse = ":";
  
  /// <summary>The configuration XML filename.</summary>
  public const string FilenameConfigurationXml                      = @"WordEngineering.config";

  /// <summary>The information schema primary key column(s) query.</summary>
  public const string InformationSchemaColumnNamePrimaryColumnSQL   = "SELECT COLUMN_NAME, ORDINAL_POSITION FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS ON INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_NAME  = INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME AND INFORMATION_SCHEMA.KEY_COLUMN_USAGE.CONSTRAINT_NAME  = INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME WHERE INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE = 'PRIMARY KEY' AND   INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_NAME = '{0}' ORDER BY INFORMATION_SCHEMA.KEY_COLUMN_USAGE.ORDINAL_POSITION";

  /// <summary>Scripture Reference Column Name Postfix.</summary>  
  public const string   ScriptureReferenceColumnNamePostfix         = "ScriptureReference";

  /// <summary>Scripture Reference URI Column Name Postfix.</summary>  
  public const string   ScriptureReferenceURIColumnNamePostfix      = "ScriptureReferenceURI";
  
  /// <summary>The XPath Bible XML Filename.</summary>
  const  string XPathBibleXmlFilename                               = @"/word/bible/xmlFilename";

  /// <summary>The XPath Column Name Scripture Reference.</summary>
  public const  string  XPathColumnScriptureReference               = @"/word/database/column/scriptureReference";

  /// <summary>The XPath database connection string.</summary>
  const  string XPathDatabaseConnectionString                       = @"/word/database/sqlServer/bible/databaseConnectionString";  

  /// <summary>The URI Crosswalk Pre.</summary>
  const  string URICrosswalkPre                                     = @"http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=";  

  /// <summary>The URI Crosswalk Post.</summary>
  const  string URICrosswalkPost                                    = @"&section=0&version=nkj&language=en";  

  /// <summary>The URI Crosswalk Pre Chapter.</summary>
  const  char   URICrosswalkPreChapter                              = '+';

  /// <summary>The URI Crosswalk Pre Verse.</summary>
  const  string URICrosswalkPreVerse                                = @"%3A";

  /// <summary>The URI Crosswalk Pre Post.</summary>
  const  char   URICrosswalkPrePost                                 = '-';

  /// <summary>The URI Crosswalk Pre Subset.</summary>
  const  string URICrosswalkPreSubset                               = @"%2C+";

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">
  /// A list of scripture reference arguments. for example:
  ///  "Genesis 1", "Genesis 2:3", "Genesis 4:5-6", "Genesis 24:5-27:46"
  ///</param>
  public static void Main
  (
   string[] argv
  )
  {
   int                                          rowCount                                           = -1;
   string                                       databaseConnectionString                           = DatabaseConnectionString;
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

   ConfigurationXml( FilenameConfigurationXml, ref exceptionMessage, ref databaseConnectionString );

   ScriptureReferenceParser
   ( 
        argv,
        databaseConnectionString,
    ref exceptionMessage,
    ref scriptureReferenceBookChapterVersePrePost,
    ref scriptureReferenceArray,
    ref uriCrosswalkHtml,
    ref uriCrosswalkXml
   );	

   ScriptureReferenceQuery
   ( 
        databaseConnectionString,
    ref exceptionMessage,
    ref scriptureReferenceBookChapterVersePrePost,
    ref iDataReader,
    ref rowCount,
    ref scriptureReferenceText,
    ref scriptureReferenceBookChapterVersePrePostCondition,
    ref scriptureReferenceBookChapterVersePrePostSelect,
    ref scriptureReferenceBookChapterVersePrePostQuery
   );	

   ScriptureReferenceBookChapterVersePrePost.XPathCondition
   (
        BibleXmlFilename,
    ref exceptionMessage,
        scriptureReferenceBookChapterVersePrePost
   );
   
  }//public static void Main

  ///<summary>Scripture Reference Parser.</summary>
  ///<param name="scriptureReference">The scripture reference.</param>
  ///<param name="databaseConnectionString">The database connection string.</param>
  ///<param name="exceptionMessage">The exception message.</param>   
  ///<param name="scriptureReferenceBookChapterVersePrePost">The scripture reference book, chapter, verse, pre and post.</param>
  ///<param name="scriptureReferenceArray">The scripture reference subset.</param> 
  ///<param name="uriCrosswalkHtml">The URI for the Crosswalk HTML.</param>   
  ///<param name="uriCrosswalkXml">The URI for the Crosswalk XML.</param>
  ///<example> 
  ///<code>
  ///string       exceptionMessage   = null;
  ///string[]     scriptureReference = new string[]
  ///                                  {
  ///                                   "Genesis 1",
  ///                                   "Genesis 2:3",
  ///                                   "Genesis 4:5-6",
  ///                                   "Genesis 24:5-27:46"
  ///                                  };
  ///ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost = null;   
  ///string[][]                                  scriptureReferenceArray                   = null;
  ///StringBuilder                               uriCrosswalkHtml                          = null;
  ///StringBuilder                               uriCrosswalkXml                           = null;
  ///ScriptureReferenceParser
  /// ( 
  ///      scriptureReference,
  ///      DatabaseConnectionString,
  ///  ref exceptionMessage,
  ///  ref scriptureReferenceArray,
  ///  ref uriCrosswalkHtml,
  ///  ref uriCrosswalkXml,
  /// );	
  ///</code>  
  ///</example>   
  public static void ScriptureReferenceParser
  (
       string[]                                     scriptureReference,
       string                                       databaseConnectionString,       
   ref string                                       exceptionMessage,
   ref ScriptureReferenceBookChapterVersePrePost[]  scriptureReferenceBookChapterVersePrePost,
   ref string[][]                                   scriptureReferenceArray,
   ref StringBuilder                                uriCrosswalkHtml,
   ref StringBuilder                                uriCrosswalkXml
  )
  {
   bool             scriptureReferenceSubsetPostIncludesBook                           = false;
   int              scriptureReferenceSubsetPrePostBookChapterVerseCount               = 0;   
   int              scriptureReferenceSubsetCount                                      = 0;
   int              scriptureReferenceSubsetPrePostBookChapterZeroBasedIndex           = -1;
   int              scriptureReferenceSubsetPrePostBookChapterZeroBasedIndexLetter     = -1;
   int              scriptureReferenceSubsetPrePostBookChapterZeroBasedLength          = -1;
   int              scriptureReferenceSubsetTotal                                      = 0; 
   string[]         scriptureReferenceBookChapterVerse                                 = null;   
   string[]         scriptureReferenceCurrentSubset                                    = null;
   string[]         scriptureReferencePrePost                                          = null;   
   
   exceptionMessage                                                                    = null;
   
   foreach ( string scriptureReferenceCurrent in scriptureReference )
   {
    ++scriptureReferenceSubsetTotal;
    for ( int scriptureReferenceCurrentPosition = 0; scriptureReferenceCurrentPosition < scriptureReferenceCurrent.Length; ++scriptureReferenceCurrentPosition )
    {
     if ( scriptureReferenceCurrent[scriptureReferenceCurrentPosition] == ',' || scriptureReferenceCurrent[scriptureReferenceCurrentPosition] == ';')
     {
      ++scriptureReferenceSubsetTotal;
     }//if ( scriptureReferenceCurrent[scriptureReferenceCurrentPosition] == ',' || scriptureReferenceCurrent[scriptureReferenceCurrentPosition] == ';') 
    }//for ( int scriptureReferenceCurrentPosition = 0; scriptureReferenceCurrentPosition < scriptureReferenceCurrent.Length; ++scriptureReferenceCurrentPosition)
   }//foreach ( string scriptureReferenceCurrent in scriptureReference )
   
   scriptureReferenceArray = new string[scriptureReferenceSubsetTotal][];
  
   for ( scriptureReferenceSubsetCount = 0; scriptureReferenceSubsetCount < scriptureReferenceSubsetTotal; ++scriptureReferenceSubsetCount)
   {
    scriptureReferenceArray[scriptureReferenceSubsetCount] = new string[ScriptureReferenceSubsetElementTotal];   	
   }

   scriptureReferenceBookChapterVersePrePost = new ScriptureReferenceBookChapterVersePrePost[scriptureReferenceSubsetTotal];
   
   scriptureReferenceSubsetCount = -1;
   
   foreach ( string scriptureReferenceCurrent in scriptureReference )
   {
    scriptureReferenceCurrentSubset = scriptureReferenceCurrent.Split(DelimiterCharScriptureReferenceSubset);
    for( int scriptureReferenceCurrentSubsetCount = 0; scriptureReferenceCurrentSubsetCount < scriptureReferenceCurrentSubset.Length; ++scriptureReferenceCurrentSubsetCount ) 
    {
     ++scriptureReferenceSubsetCount;
     scriptureReferenceCurrentSubset[scriptureReferenceCurrentSubsetCount] = scriptureReferenceCurrentSubset[scriptureReferenceCurrentSubsetCount].Trim();
     scriptureReferencePrePost = scriptureReferenceCurrentSubset[scriptureReferenceCurrentSubsetCount].Split(DelimiterCharScriptureReferencePrePost);
     scriptureReferenceSubsetPostIncludesBook = false;
     for( int scriptureReferencePrePostCount = 0; scriptureReferencePrePostCount < scriptureReferencePrePost.Length; ++scriptureReferencePrePostCount )  
     {
      scriptureReferenceBookChapterVerse = scriptureReferencePrePost[scriptureReferencePrePostCount].Split(DelimiterCharScriptureReferenceChapterVerse);
      for( int scriptureReferenceBookChapterVerseCount = 0; scriptureReferenceBookChapterVerseCount < scriptureReferenceBookChapterVerse.Length; ++scriptureReferenceBookChapterVerseCount )
      {
       scriptureReferenceBookChapterVerse[scriptureReferenceSubsetPrePostBookChapterVerseCount] = scriptureReferenceBookChapterVerse[scriptureReferenceSubsetPrePostBookChapterVerseCount].Trim();
       switch ( scriptureReferenceBookChapterVerseCount )
       {
        case ScriptureReferenceSubsetPrePostBookChapter:
         scriptureReferenceSubsetPrePostBookChapterZeroBasedLength = scriptureReferenceBookChapterVerse[scriptureReferenceSubsetPrePostBookChapterVerseCount].Length - 1;
         scriptureReferenceSubsetPrePostBookChapterZeroBasedIndexLetter = -1;
         for ( scriptureReferenceSubsetPrePostBookChapterZeroBasedIndex = scriptureReferenceSubsetPrePostBookChapterZeroBasedLength; scriptureReferenceSubsetPrePostBookChapterZeroBasedIndex >= 0; scriptureReferenceSubsetPrePostBookChapterZeroBasedIndex-- )
         {
          if ( char.IsLetter( scriptureReferenceBookChapterVerse[scriptureReferenceBookChapterVerseCount][scriptureReferenceSubsetPrePostBookChapterZeroBasedIndex] ) )
          {
           scriptureReferenceSubsetPrePostBookChapterZeroBasedIndexLetter = scriptureReferenceSubsetPrePostBookChapterZeroBasedIndex;
           if ( scriptureReferencePrePostCount == ScriptureReferenceSubsetPost )
           {
            scriptureReferenceSubsetPostIncludesBook = true;
           }//if ( scriptureReferencePrePostCount == ScriptureReferenceSubsetPost ) 
           break;
          }//if ( char.IsLetter( scriptureReferenceBookChapterVerse[scriptureReferenceSubsetPrePostBookChapterVerseCount][scriptureReferenceSubsetPrePostBookChapterZeroBasedIndex] ) 
         }//for ( scriptureReferenceSubsetPrePostBookChapterZeroBasedIndex = scriptureReferenceSubsetPrePostBookChapterZeroBasedLength; scriptureReferenceSubsetPrePostBookChapterZeroBasedIndex > 0; -- scriptureReferenceSubsetPrePostBookChapterZeroBasedIndex )

         if   ( scriptureReferenceSubsetPrePostBookChapterZeroBasedLength == scriptureReferenceSubsetPrePostBookChapterZeroBasedIndexLetter )
         {
          scriptureReferenceArray[scriptureReferenceSubsetCount][3 * scriptureReferencePrePostCount + ScriptureReferenceBook] = scriptureReferenceBookChapterVerse[scriptureReferenceBookChapterVerseCount];
          scriptureReferenceArray[scriptureReferenceSubsetCount][3 * scriptureReferencePrePostCount + ScriptureReferenceChapter] = null;
         }//if ( scriptureReferenceSubsetPrePostBookChapterZeroBasedLength == scriptureReferenceSubsetPrePostBookChapterZeroBasedIndexLetter + 1 )
         else if ( scriptureReferenceSubsetPrePostBookChapterZeroBasedIndexLetter > -1 )
         {
          scriptureReferenceArray[scriptureReferenceSubsetCount][3 * scriptureReferencePrePostCount + ScriptureReferenceBook] = scriptureReferenceBookChapterVerse[scriptureReferenceBookChapterVerseCount].Substring( 0, scriptureReferenceSubsetPrePostBookChapterZeroBasedIndexLetter + 1).Trim();
          scriptureReferenceArray[scriptureReferenceSubsetCount][3 * scriptureReferencePrePostCount + ScriptureReferenceChapter] = scriptureReferenceBookChapterVerse[scriptureReferenceBookChapterVerseCount].Substring( scriptureReferenceSubsetPrePostBookChapterZeroBasedIndexLetter + 1 ).Trim();
         }//else if ( scriptureReferenceSubsetPrePostBookChapterZeroBasedIndexLetter >= -1 )
         else 
         {
          scriptureReferenceArray[scriptureReferenceSubsetCount][3 * scriptureReferencePrePostCount + ScriptureReferenceBook] = null;
          scriptureReferenceArray[scriptureReferenceSubsetCount][3 * scriptureReferencePrePostCount + ScriptureReferenceChapter] = scriptureReferenceBookChapterVerse[scriptureReferenceBookChapterVerseCount];
         }
         break;

        case ScriptureReferenceSubsetPrePostVerse:
         scriptureReferenceArray[scriptureReferenceSubsetCount][3 * scriptureReferencePrePostCount + ScriptureReferenceVerse] = scriptureReferenceBookChapterVerse[scriptureReferenceBookChapterVerseCount];
         break;
       }//switch ( scriptureReferenceBookChapterVerseCount )  
      }//for( int scriptureReferenceBookChapterVerseCount = 0; scriptureReferenceBookChapterVerse < scriptureReferenceBookChapterVerse.Length; ++scriptureReferenceBookChapterVerseCount )
      switch ( scriptureReferencePrePostCount )
      {
       case ScriptureReferenceSubsetPrePostPost:
        if 
        ( 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostBook]      != null && 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostChapter]   != null &&          
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostVerse]     != null
        )
        {
        }    
        else if 
        ( 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePreChapter]    != null  && 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePreVerse]      == null  &&          
         scriptureReferenceSubsetPostIncludesBook                                                == false && 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostChapter]   == null  &&          
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostVerse]     == null
        )
        {
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostChapter]   = scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostBook];
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostBook]      = null; 
        }
        else if 
        ( 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePreChapter]    != null  && 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePreVerse]      != null  &&          
         scriptureReferenceSubsetPostIncludesBook                                                == false && 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostChapter]   == null  &&          
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostVerse]     == null
        )
        {
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostVerse]     = scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostBook];
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostBook]      = null; 
        }
        else if 
        ( 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePreChapter]    != null  && 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePreVerse]      != null  &&          
         scriptureReferenceSubsetPostIncludesBook                                                == false && 
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostChapter]   != null  &&          
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostVerse]     == null
        )
        {
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostVerse]     = scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostChapter];
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostChapter]   = scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostBook];
         scriptureReferenceArray[scriptureReferenceSubsetCount][ScriptureReferencePostBook]      = null; 
        }
        break; 
      }//switch ( scriptureReferencePrePostCount )        
     }//for( int scriptureReferencePrePostCount = 0; scriptureReferencePrePostCount < scriptureReferencePrePost.Length; ++scriptureReferencePrePostCount )  
     /*
     #if (DEBUG)   
      System.Console.WriteLine
      (
       "ScriptureReferenceBookChapterVersePost [{0}]: {1}.", 
       scriptureReferenceSubsetCount,
       UtilityCollection.ToString( scriptureReferenceArray[scriptureReferenceSubsetCount] )
      ); 
     #endif
     */
     scriptureReferenceBookChapterVersePrePost[ scriptureReferenceSubsetCount ] = new ScriptureReferenceBookChapterVersePrePost( scriptureReferenceArray[scriptureReferenceSubsetCount] );
     #if (DEBUG)   
      System.Console.WriteLine
      (
       "ScriptureReferenceBookChapterVersePost [{0}]: {1} | {2} | SonInLaw: {3}.", 
       scriptureReferenceSubsetCount,
       scriptureReferenceBookChapterVersePrePost[ scriptureReferenceSubsetCount ],
       UtilityCollection.ToString( scriptureReferenceArray[scriptureReferenceSubsetCount] ),
       scriptureReferenceBookChapterVersePrePost[ scriptureReferenceSubsetCount ].SonInLaw
      ); 
     #endif
    }//for( int scriptureReferenceSubsetCount = 0; scriptureReferenceSubsetCount < scriptureReferenceArray.Length; ++scriptureReferenceSubsetCount ) 
   }//foreach ( string scriptureReferenceCurrent in scriptureReference )

   uriCrosswalkHtml        = ScriptureReferenceBookChapterVersePrePost.URICrosswalkHtml(scriptureReferenceBookChapterVersePrePost);
   uriCrosswalkXml         = ScriptureReferenceBookChapterVersePrePost.URICrosswalkXml(uriCrosswalkHtml);

   #if (DEBUG)   
    System.Console.WriteLine("Scripture Reference URI Crosswalk (HTML): {0}", uriCrosswalkHtml); 
    System.Console.WriteLine("Scripture Reference URI Crosswalk (XML):  {0}", uriCrosswalkXml);
   #endif
   
  }//public static void ScriptureReferenceParser

  ///<summary>Scripture Reference Query.</summary>
  ///<param name="databaseConnectionString">The database connection string.</param>
  ///<param name="exceptionMessage">The exception message.</param>
  ///<param name="scriptureReferenceText">The scripture reference text.</param>
  ///<param name="iDataReader">The data reader.</param>  
  ///<param name="rowCount">Returns the number of rows affected by the last statement.</param>
  ///<param name="scriptureReferenceBookChapterVersePrePost">The scripture reference book, chapter, verse, pre and post.</param>
  ///<param name="scriptureReferenceBookChapterVersePrePostCondition">The condition for the scripture reference book, chapter, verse, pre and post.</param>
  ///<param name="scriptureReferenceBookChapterVersePrePostSelect">The SQL statement for each scripture reference book, chapter, verse, pre and post.</param>  
  ///<param name="scriptureReferenceBookChapterVersePrePostQuery">The SQL statement for the scripture reference book, chapter, verse, pre and post.</param>    
  ///<example> 
  ///<code>
  ///int             rowCount                                           = 0;
  ///string          exceptionMessage                                   = null;
  ///StringBuilder[] scriptureReferenceBookChapterVersePrePost          = null;     
  ///StringBuilder[] scriptureReferenceBookChapterVersePrePostCondition = null;     
  ///StringBuilder[] scriptureReferenceBookChapterVersePrePostSelect    = null;
  ///StringBuilder   scriptureReferenceBookChapterVersePrePostQuery     = null;
  ///ScriptureReferenceQuery
  /// ( 
  ///      DatabaseConnectionString,
  ///  ref iDataReader,    
  ///  ref rowCount,
  ///  ref scriptureReferenceText,
  ///  ref exceptionMessage,
  ///  ref scriptureReferenceBookChapterVersePrePostCondition,
  ///  ref scriptureReferenceBookChapterVersePrePostSelect,
  ///  ref scriptureReferenceBookChapterVersePrePostQuery
  /// );	
  ///</code>  
  ///</example>   
  public static void ScriptureReferenceQuery
  (
       string                                       databaseConnectionString,
   ref string                                       exceptionMessage,
   ref ScriptureReferenceBookChapterVersePrePost[]  scriptureReferenceBookChapterVersePrePost,
   ref IDataReader                                  iDataReader,
   ref int                                          rowCount,
   ref StringBuilder                                scriptureReferenceText,
   ref StringBuilder[]                              scriptureReferenceBookChapterVersePrePostCondition,
   ref StringBuilder[]                              scriptureReferenceBookChapterVersePrePostSelect,
   ref StringBuilder                                scriptureReferenceBookChapterVersePrePostQuery
  )
  {

   exceptionMessage = null;

   ScriptureReferenceBookChapterVersePrePost.SQLStatementCondition
   (
        databaseConnectionString, 
    ref exceptionMessage,
        scriptureReferenceBookChapterVersePrePost,
    ref scriptureReferenceBookChapterVersePrePostCondition,
    ref scriptureReferenceBookChapterVersePrePostSelect,
    ref scriptureReferenceBookChapterVersePrePostQuery
   );//ScriptureReferenceBookChapterVersePrePost.SQLStatementCondition()

   if ( exceptionMessage != null )
   {
    return;
   }//if ( exceptionMessage != null )        

   ScriptureReferenceBookChapterVersePrePost.SQLStatementQuery
   (
        databaseConnectionString, 
    ref exceptionMessage,
    ref scriptureReferenceBookChapterVersePrePost,
    ref iDataReader,
    ref rowCount,
    ref scriptureReferenceText,
        scriptureReferenceBookChapterVersePrePostQuery,
        CommandType.Text
   );//ScriptureReferenceBookChapterVersePrePost.SQLStatementQuery()

  }//ScriptureReferenceQuery()
      
  /// <summary>Read the XML Configuration file.</summary>
  public static void ConfigurationXml()
  {  
   string exceptionMessage = null;
   
   ConfigurationXml
   (
        FilenameConfigurationXml,
    ref exceptionMessage,
    ref DatabaseConnectionString
   );
   
  }//public static void ConfigurationXml()

  /// <summary>Read the XML Configuration file.</summary>
  /// <param name="filenameConfigurationXml">The XML Configuration file.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="databaseConnectionString">The database connection string.</param>  
  public static void ConfigurationXml
  (
       string filenameConfigurationXml,
   ref string exceptionMessage,
   ref string databaseConnectionString
  )
  {
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,
         XPathDatabaseConnectionString,
     ref databaseConnectionString
    );

   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,
         XPathBibleXmlFilename,
     ref BibleXmlFilename
   );
  }//ConfigurationXml	 

  /// <summary>Scripture Reference URI.</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="filenameConfigurationXml">The filename configuration Xml.</param>
  /// <param name="exceptionMessage">The exception message.</param>  
  /// <param name="dataSet">The dataset.</param>
  public static void ScriptureReferenceURI
  (
       string  databaseConnectionString,
       string  filenameConfigurationXml,
   ref string  exceptionMessage,
   ref DataSet dataSet
  )
  {
   bool                                         boolView                                  = false;
   
   int                                          columnIndexScriptureReference             = -1;
   
   string                                       dataColumnName                            = null;
   string                                       scriptureReferenceColumnValue             = null;
   string                                       scriptureReferenceColumnName              = null;
   string                                       scriptureReferenceColumnNameURI           = null;
   string                                       scriptureReferenceURI                     = null;   
   string[][]                                   scriptureReferenceArray                   = null;    
   string                                       columnNamePrimary                         = null;
   string                                       columnValuePrimary                        = null; 
   string                                       tableName                                 = null;
   
   ArrayList                                    scriptureReferenceSet                     = null;
   ArrayList                                    scriptureReferenceURISet                  = null;
   ScriptureReferenceBookChapterVersePrePost[]  scriptureReferenceBookChapterVersePrePost = null;
   StringBuilder                                columnSet                                 = null;   
   StringBuilder                                uriCrosswalkXml                           = null;
   StringBuilder                                uriCrosswalkHtml                          = null;   
   StringBuilder                                SQLStatement                              = null;      
   OleDbConnection                              oleDbConnection                           = null;
   XmlNodeList                                  scriptureReferenceColumnSet               = null;

   scriptureReferenceColumnSet = UtilityXml.SelectNodes
   (
        filenameConfigurationXml,
    ref exceptionMessage,
        XPathColumnScriptureReference
   );
   try
   {
    oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
    (
         databaseConnectionString,
     ref exceptionMessage
    ); 

    foreach ( DataTable dataTable in dataSet.Tables )
    {
   
     columnIndexScriptureReference = UtilityDatabase.DataTableColumnIndex
     (
      dataTable,
      "ScriptureReference"
     ); 
     
     if ( columnIndexScriptureReference < 0 )
     {
      continue;
     }           	
    	
     tableName                = dataTable.TableName;
     scriptureReferenceSet    = new ArrayList();
     scriptureReferenceURISet = new ArrayList();
     SQLStatement = new StringBuilder();
     
     if ( tableName.IndexOf("View" ) < 0 )
     {
      boolView = false;
      SQLStatement.AppendFormat
      (
       InformationSchemaColumnNamePrimaryColumnSQL,
       tableName
      );
     }
     else
     {
      boolView = true;	
      SQLStatement.AppendFormat
      (
       InformationSchemaColumnNamePrimaryColumnSQL,
       tableName.Substring(4)
      );
     }

      #if (DEBUG)
       System.Console.WriteLine("SQLStatement: {0}", SQLStatement);
      #endif
     
     columnNamePrimary = (string) UtilityDatabase.DatabaseQuery
     (
          databaseConnectionString,
      ref exceptionMessage,
          SQLStatement.ToString(),
          CommandType.Text
     );
     
     if ( boolView == true )
     {
      columnNamePrimary = String.Concat( tableName.Substring(4), columnNamePrimary );	
     }	 

     #if (DEBUG)
      System.Console.WriteLine("ColumnNamePrimary: {0}", columnNamePrimary);
     #endif
     
     foreach ( DataColumn dataColumn in dataTable.Columns )
     {
      dataColumnName = dataColumn.ColumnName.Trim();
      /*
      #if (DEBUG)
       System.Console.WriteLine("Table Name: {0} | ColumnName: {1}", tableName, dataColumnName);
      #endif
      */
      if ( dataColumnName.IndexOf( ScriptureReferenceURIColumnNamePostfix ) >= 0 )
      {
       continue;
      }
      if ( dataColumnName.IndexOf( ScriptureReferenceColumnNamePostfix ) >= 0 )
      {
       scriptureReferenceSet.Add( dataColumnName );
       scriptureReferenceColumnName    = dataColumnName;
       scriptureReferenceColumnNameURI = scriptureReferenceColumnName + "URI";
       if ( dataTable.Columns.Contains( scriptureReferenceColumnNameURI ) == false )
       {
        /*
        #if (DEBUG)
         System.Console.WriteLine("Table Name: {0} | ColumnName: {1}", tableName, scriptureReferenceColumnNameURI);
        #endif
        */
        scriptureReferenceURISet.Add( scriptureReferenceColumnNameURI );
       }//if dataTable.Columns.Contains( scriptureReferenceColumnNameURI ) == false )
      }//if ( dataColumnName.IndexOf( ScriptureReferenceColumnNamePostfix ) >= 0 )
     }//foreach ( DataColumn dataColumn in dataTable.Columns )

     foreach ( object columnName in scriptureReferenceURISet )
     {
      scriptureReferenceColumnNameURI = columnName.ToString().Trim();
      dataTable.Columns.Add( scriptureReferenceColumnNameURI );
     }

     foreach ( DataColumn dataColumn in dataTable.Columns )
     {
      dataColumnName = dataColumn.ColumnName.Trim();
      /*
       #if (DEBUG)
        System.Console.WriteLine("Table Name: {0} | ColumnName: {1}", tableName, dataColumnName);
       #endif
      */ 
     }//foreach ( DataColumn dataColumn in dataTable.Columns )

     foreach ( DataRow dataRow in dataTable.Rows )
     {
      columnValuePrimary = dataRow[columnNamePrimary].ToString().Trim();
      columnSet = new StringBuilder();
      /*
       #if (DEBUG)
        System.Console.WriteLine("ColumnValuePrimary: {0}", columnValuePrimary);
       #endif
      */ 
      foreach ( object columnName in scriptureReferenceSet )
      {
       #if (DEBUG)
        System.Console.WriteLine("ColumnName: {0}", columnName);
       #endif
       scriptureReferenceColumnName  = columnName.ToString().Trim();
       scriptureReferenceColumnValue = dataRow[scriptureReferenceColumnName].ToString().Trim();
     
       #if (DEBUG)
        System.Console.WriteLine
        (
         "Scripture Reference Column Name: {0} | Value: {1}", 
         scriptureReferenceColumnName,
         scriptureReferenceColumnValue
        );
       #endif
       scriptureReferenceColumnNameURI = scriptureReferenceColumnName + "URI";
       if ( scriptureReferenceColumnValue != null && scriptureReferenceColumnValue != string.Empty )
       {
        ScriptureReference.ScriptureReferenceParser
        (
             new string[] { scriptureReferenceColumnValue },
             databaseConnectionString,
         ref exceptionMessage,
         ref scriptureReferenceBookChapterVersePrePost,
         ref scriptureReferenceArray,
         ref uriCrosswalkHtml,
         ref uriCrosswalkXml
        );//ScriptureReference.ScriptureReferenceParser()
        scriptureReferenceURI = uriCrosswalkHtml.ToString();
        if ( UtilityDatabase.DataSetTableColumnContains( dataSet, tableName, scriptureReferenceColumnNameURI ) == false )
        {
         UtilityDatabase.DataSetTableColumnAdd( dataSet, tableName, scriptureReferenceColumnNameURI );	
         dataRow[scriptureReferenceColumnNameURI] = scriptureReferenceURI;
         continue;
        }//if ( DataSetTableColumnContains( dataSet, dataTable, scriptureReferenceColumnNameURI ) )	
        dataRow[scriptureReferenceColumnNameURI] = scriptureReferenceURI;
        if ( scriptureReferenceURISet.IndexOf( scriptureReferenceColumnNameURI ) >= 0 )
        {
         continue;
        }

        if ( columnSet.Length != 0 )
        {
         columnSet.Append(',');
        }
        columnSet.AppendFormat
        (
         UtilityDatabase.DatabaseTemplateSQLSet,
         scriptureReferenceColumnNameURI,
         scriptureReferenceURI
        ); 
        /*
        #if (DEBUG)
         System.Console.WriteLine("columnSet: {0}", columnSet);      
        #endif
        */
        SQLStatement = new StringBuilder();
        SQLStatement.AppendFormat
        (
         UtilityDatabase.DatabaseTemplateSQLUpdateScriptureReferenceURISet,
         tableName,
         columnSet,
         columnNamePrimary,
         columnValuePrimary
        );   
        #if (DEBUG)
         System.Console.WriteLine("SQL Statement: {0}", SQLStatement.ToString() );      
        #endif
        UtilityDatabase.DatabaseNonQuery
        (
             oleDbConnection,
         ref exceptionMessage,
             SQLStatement.ToString()
        );
       }//if ( scriptureReferenceColumnValue != null && scriptureReferenceColumnValue != string.Empty )
      }//foreach ( object columnName in dataTableColumnName )
     }//foreach ( DataRow dataRow in dataTable )
    }//foreach ( DataTable dataTable in dataSet ) 
    UtilityDatabase.DatabaseConnectionHouseKeeping
    (
         oleDbConnection,
     ref exceptionMessage
    );
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = exception.Message;
    exceptionMessage = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    System.Console.WriteLine("OleDbException: {0}", exceptionMessage);
   }//catch (OleDbException exception)
   catch (SecurityException exception)
   {
    exceptionMessage = exception.Message;
    System.Console.WriteLine( "SecurityException: {0}", exception.Message );
   }//catch (SecurityException exception)
   catch (SystemException exception)
   {
    exceptionMessage = exception.Message;
    System.Console.WriteLine( "SystemException: {0}", exception.Message );
   }//catch (SystemException exception)
   catch (Exception exception)
   {
    exceptionMessage = exception.Message;   
    System.Console.WriteLine( "Exception: {0}", exception.Message );
   }//catch (Exception exception)
  }//public static void ScriptureReferenceURI()

  static ScriptureReference()
  {
   DelimiterCharScriptureReferenceSubset       = DelimiterStringScriptureReferenceSubset.ToCharArray();
   DelimiterCharScriptureReferencePrePost      = DelimiterStringScriptureReferencePrePost.ToCharArray();
   DelimiterCharScriptureReferenceChapterVerse = DelimiterStringScriptureReferenceChapterVerse .ToCharArray();   
  }//static()

 }//public class ScriptureReference
}//namespace WordEngineering