using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Web;
using System.Text;
using System.Xml;

namespace WordEngineering
{
 /// <summary>Roget's Thesaurus of English Words and Phrases.</summary>
 /// <remarks>Roget's Thesaurus of English Words and Phrases.</remarks>
 public class GutenbergRogetThesaurusOfEnglishWordsAndPhrases
 {

  const  int DatabaseColumnRankDictionaryIdFirst      = 0;
  const  int DatabaseColumnRankDictionaryIdSecond     = 2;
  const  int DatabaseColumnRankDictionaryWordFirst    = 1;
  const  int DatabaseColumnRankDictionaryWordSecond   = 3;
  const  int DatabaseColumnRankReferenceId            = 4;
      
  static string[] DatabaseColumnSelect           = new string []
                                                   {  
                                                    "DictionaryIdFirst",
                                                    "DictionaryWordFirst",
                                                    "DictionaryIdSecond",
                                                    "DictionaryWordSecond",
                                                    "ReferenceId"
                                                   }; 

  ///<summary>The database connection string.</summary>  
  public static string   DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=Gutenberg;Integrated Security=SSPI;";
  static string[] DictionaryWordReplace          = new string []
                                                  {  
  	                                               "||", 
  	                                               "*",
  	                                               "-",
  	                                               "\"",
  	                                               "`"
  	                                              }; 

  const  string   Digits                         = "0123456789";
  static char[]   DigitsAnyOf                    = Digits.ToCharArray();

  static  string   DirectorynameSource            = "..\\ProjectGutenberg";
  static  string   ExceptionMessage               = null;
  static  string   FileSearchPattern              = "ProjectGutenberg_-_Roget'sThesaurus.txt";

  ///<summary>The XPath for database connection string.</summary>  
  public const  string XPathDatabaseConnectionString               = @"/word/database/sqlServer/gutenberg/databaseConnectionString";  

  /// <summary>The XML configuration file.</summary>
  public static   string FilenameConfigurationXml  = @"WordEngineering.config";  

  const  string   DictionaryBegin                = "A";
  const  string   DictionaryEnd                  = "Roget's Thesaurus of English Words and Phrases";  

  const  string   FormatDictionaryWord           = "<br/><b>Entry: {0}</b>";
  const  string   FormatDictionarySynonym        = "<br/><b>Synonym: </b>{0}";  

  const  string   SQLStatementDictionaryInsertWord        = "IF NOT EXISTS ( SELECT DictionaryId FROM RogetThesaurusOfEnglishWordsAndPhrases ( NOLOCK ) WHERE DictionaryWord = '{0}' ) BEGIN INSERT RogetThesaurusOfEnglishWordsAndPhrases( DictionaryWord ) VALUES ( '{0}' ); SELECT @@IDENTITY END ELSE BEGIN SELECT DictionaryId FROM RogetThesaurusOfEnglishWordsAndPhrases ( NOLOCK ) WHERE DictionaryWord = '{0}' END";
  const  string   SQLStatementDictionaryInsertReference   = "IF NOT EXISTS ( SELECT TOP 1 * FROM RogetThesaurusOfEnglishWordsAndPhrasesReference ( NOLOCK ) WHERE DictionaryId = {0} AND ThesaurusId = {1} ) BEGIN INSERT RogetThesaurusOfEnglishWordsAndPhrasesReference( DictionaryId, ThesaurusId, ReferenceId ) VALUES ( {0}, {1}, {2} ) END";
  const  string   SQLStatementDictionarySelect            = "SELECT RogetThesaurusOfEnglishWordsAndPhrasesFirst.DictionaryId    AS  DictionaryIdFirst,  RogetThesaurusOfEnglishWordsAndPhrasesFirst.DictionaryWord  AS  DictionaryWordFirst, RogetThesaurusOfEnglishWordsAndPhrasesSecond.DictionaryId   AS  DictionaryIdSecond,  RogetThesaurusOfEnglishWordsAndPhrasesSecond.DictionaryWord AS  DictionaryWordSecond, RogetThesaurusOfEnglishWordsAndPhrasesReference.ReferenceId AS  ReferenceId FROM  RogetThesaurusOfEnglishWordsAndPhrases AS RogetThesaurusOfEnglishWordsAndPhrasesFirst ( NOLOCK ) INNER JOIN   RogetThesaurusOfEnglishWordsAndPhrasesReference ( NOLOCK ) ON  RogetThesaurusOfEnglishWordsAndPhrasesFirst.DictionaryId = RogetThesaurusOfEnglishWordsAndPhrasesReference.DictionaryId INNER JOIN  RogetThesaurusOfEnglishWordsAndPhrases AS RogetThesaurusOfEnglishWordsAndPhrasesSecond ( NOLOCK ) ON  RogetThesaurusOfEnglishWordsAndPhrasesReference.ThesaurusId = RogetThesaurusOfEnglishWordsAndPhrasesSecond.DictionaryId WHERE  RogetThesaurusOfEnglishWordsAndPhrasesFirst.DictionaryWord LIKE '{0}' ORDER BY DictionaryIdFirst, DictionaryIdSecond";
  const  string   SQLStatementDictionaryTruncate          = "TRUNCATE TABLE RogetThesaurusOfEnglishWordsAndPhrases; DBCC CHECKIDENT (RogetThesaurusOfEnglishWordsAndPhrases, RESEED, 1); TRUNCATE TABLE RogetThesaurusOfEnglishWordsAndPhrasesReference;";

  const  string   ThesaurusCombinationDelimiter           = ",";
  static char[]   ThesaurusCombinationDelimiterArray      = ThesaurusCombinationDelimiter.ToCharArray();
  
  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of arguments</param>
  public static void Main( string[] argv )
  {
   string        directorynameSource = Directory.GetCurrentDirectory();
   string        dictionaryWordQuery = null;
   string        exceptionMessage    = null;

   StringBuilder sbResultElement     = null;
   
   /*
   DictionaryTextFile
   ( 
     directorynameSource,
     FileSearchPattern
   );
   */

   if ( argv.Length > 0 )
   {
   	dictionaryWordQuery = argv[0];
    Search
    ( 
         dictionaryWordQuery,
     ref exceptionMessage,
     ref sbResultElement
    );
   };//if ( argv.length > 0 ) 

  }//main()

  /// <summary>The dictionary text file.</summary>
  /// <param name="directorynameSource">The directory name, source, for example, ..\\ProjectGutenberg.</param>
  /// <param name="fileSearchPattern">The file search pattern, for example. *.txt.</param>
  public static void DictionaryTextFile
  ( 
   string directorynameSource,
   string fileSearchPattern
  )
  {

   Boolean                            dictionaryBeginFlag                           = false;  	
   Boolean                            dictionaryEndFlag                             = false;
   
   int                                dictionaryId                                  = 0;
   int                                indexDigit                                    = -1;
   int                                referenceId                                   = -1;
   int                                thesaurusId                                   = -1;
   
   double                             referenceDouble                               = 0;

   object                             commandReturn                                 = null;
 	
   string                             dictionaryWord                                = null;
   string                             exceptionMessage                              = null;
   string                             filenameDictionary                            = null;
   string                             referenceWord                                 = null;
   string[]                           thesaurusWord                                 = null;
   string                             thesaurusWordCombination                      = null;
   string                             thesaurusWordCurrentTrim                      = null;
      
   StringBuilder                      sbDictionary                                  = null;    
   StringBuilder                      SQLStatement                                  = null;  
   ArrayList                          arrayListDirectoryname                        = null;
   ArrayList                          arrayListFilename                             = null; 
   System.Collections.IEnumerator     enumeratorFilename                            = null;
   
   OleDbConnection                    oleDbConnection                               = null;
   
   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
   ( 
        DatabaseConnectionString, 
    ref exceptionMessage 
   );

   UtilityDatabase.DatabaseNonQuery
   (
        oleDbConnection,
    ref exceptionMessage,
        SQLStatementDictionaryTruncate
   );
   
   UtilityDirectory.Dir
   (
    ref DirectorynameSource,
    ref fileSearchPattern,
    ref arrayListDirectoryname,
    ref arrayListFilename
   );//UtilityDirectory.Dir

   enumeratorFilename = arrayListFilename.GetEnumerator();

   while ( enumeratorFilename.MoveNext() )
   {
   	filenameDictionary = (string) enumeratorFilename.Current;
    System.Console.WriteLine("{0}", filenameDictionary );
    sbDictionary = new StringBuilder();

    try 
    {
     // Create an instance of StreamReader to read from a file.
     // The using statement also closes the StreamReader.
     using (StreamReader sr = new StreamReader(filenameDictionary)) 
     {
      String line;
      // Read and display lines from the file until the end of 
      // the file is reached.
      while ((line = sr.ReadLine()) != null) 
      {
       if ( line.Trim().Length == 0 )       
       {
       	continue;
       }	
       if ( dictionaryBeginFlag == false )
       {
        if ( String.Compare( line.Trim(), DictionaryBegin ) == 0 )
        {
       	 dictionaryBeginFlag = true;
        }
        continue;
       } 	
       else if ( dictionaryBeginFlag == true && String.Compare( line.Trim(), DictionaryEnd ) == 0 )
       {
       	dictionaryEndFlag = true;
       	break;
       }
       if ( line[0] != ' ' )
       {
       	dictionaryWord = line.Trim();
       	dictionaryWord = dictionaryWord.Replace("'", "''");
        SQLStatement = new StringBuilder();
        SQLStatement.AppendFormat
        (
         SQLStatementDictionaryInsertWord,
         dictionaryWord
        );
        #if (DEBUG)
         System.Console.WriteLine("SQL Statement: {0}", SQLStatement.ToString() );      
        #endif
        commandReturn = UtilityDatabase.DatabaseQuery
        (
             oleDbConnection,
         ref exceptionMessage,
             SQLStatement.ToString(),
             CommandType.Text
        );
        if ( commandReturn == DBNull.Value )
        {
         dictionaryId = -1;
        }//if ( commandReturn == DBNull.Value ) 
        else
        {
         dictionaryId = System.Convert.ToInt32( commandReturn );	
        }//else if ( commandReturn != DBNull.Value ) 
       }//if ( line[0] != ' ' )
       else
       {
        line             = line.Trim();
       	indexDigit       = line.IndexOfAny(DigitsAnyOf);
       	if ( indexDigit < 0 )
       	{
         continue;
        }        	
       	referenceWord    = line.Substring( indexDigit );
       	referenceDouble  = System.Convert.ToDouble( referenceWord );       	
       	referenceId      = System.Convert.ToInt32( referenceDouble );
       	
       	thesaurusWordCombination    = line.Substring( 0, indexDigit - 1);
       	thesaurusWordCombination    = thesaurusWordCombination.Trim();
       	thesaurusWord               = thesaurusWordCombination.Split( ThesaurusCombinationDelimiterArray );
       	foreach ( String thesaurusWordCurrent in thesaurusWord )
       	{
         thesaurusWordCurrentTrim = thesaurusWordCurrent.Trim();
         SQLStatement = new StringBuilder();
         SQLStatement.AppendFormat
         (
          SQLStatementDictionaryInsertWord,
          thesaurusWordCurrent.Trim()
         );
         #if (DEBUG)
          System.Console.WriteLine("SQL Statement: {0}", SQLStatement.ToString() );      
         #endif

         commandReturn = UtilityDatabase.DatabaseQuery
         (
              oleDbConnection,
          ref exceptionMessage,
              SQLStatement.ToString(),
              CommandType.Text
         );
 
         if ( commandReturn == DBNull.Value )
         {
          thesaurusId = -1;
         }//if ( commandReturn == DBNull.Value ) 
         else
         {
          thesaurusId = System.Convert.ToInt32( commandReturn );	
         }//else if ( commandReturn != DBNull.Value ) 
         
       	 SQLStatement                = new StringBuilder();
         SQLStatement.AppendFormat
         (
          SQLStatementDictionaryInsertReference,
          dictionaryId,
          thesaurusId,
          referenceId
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
        }//foreach ( String thesaurusWordCurrent in thesaurusWord ) 
       }//else	        
      }//while ((line = sr.ReadLine()) != null)
     }//using (StreamReader sr = new StreamReader("filenameDictionary")) 
    }//try
    catch (Exception e) 
    {
     System.Console.WriteLine(e.Message);
    }//catch (Exception e) 
   }//while ( enumeratorFilename.MoveNext() )

   UtilityDatabase.DatabaseConnectionHouseKeeping
   (
        oleDbConnection,
    ref exceptionMessage
   );
   
  }//DictionaryTextFile()

  ///<summary>Search: Display the number of results.</summary>
  ///<param name="dictionaryWord">The dictionary word.</param>
  ///<param name="exceptionMessage">The exception message.</param>
  ///<param name="sbResultElement">The result element.</param>  
  public static void Search
  (
       string        dictionaryWord,
   ref string        exceptionMessage,
   ref StringBuilder sbResultElement
  )
  {
   int                  dictionaryIdFirst           = -1;
   int                  dictionaryIdFirstCurrent    =  -1;
  	
   DataSet              dataSet                     = null;
   HttpContext          httpContext                 = HttpContext.Current;
   OleDbConnection      oleDbConnection             = null;

   string               dictionaryWordFirst         = null;
   string               dictionaryWordSecond        = null;

   StringBuilder        sbSynonym                   = null;
   StringBuilder        SQLStatement                = null;
   
   sbResultElement                                  = new StringBuilder();
   
   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
   ( 
         DatabaseConnectionString, 
     ref exceptionMessage 
   );

   SQLStatement = new StringBuilder();
   SQLStatement.AppendFormat
   (
     SQLStatementDictionarySelect,
     dictionaryWord
   );   

   #if (DEBUG)
    System.Console.WriteLine("SQL Statement: {0}", SQLStatement.ToString() );      
   #endif
    
   UtilityDatabase.DatabaseQuery
   ( 
        DatabaseConnectionString, 
    ref exceptionMessage, 
    ref dataSet, 
        SQLStatement.ToString(), 
        CommandType.Text
   );

   if ( httpContext != null && exceptionMessage != null )
   {
	httpContext.Response.Write( exceptionMessage );
   }//if ( httpContext != null )      
    
   foreach(DataTable dataTable in dataSet.Tables)
   {
    /*    
    dictionaryIdFirstCurrent = (int) UtilityDatabase.DataSetTableRowColumn
    (
     dataSet,
     dataTable.TableName,
     0,
     DatabaseColumnSelect[DatabaseColumnRankDictionaryIdFirst]
    );
    */  
    
    sbSynonym = new StringBuilder();
    
    foreach(DataRow dataRow in dataTable.Rows)
    {
     dictionaryIdFirst     = (int)    dataRow[DatabaseColumnSelect[DatabaseColumnRankDictionaryIdFirst]];
     dictionaryWordFirst   = (string) dataRow[DatabaseColumnSelect[DatabaseColumnRankDictionaryWordFirst]];
     dictionaryWordSecond  = (string) dataRow[DatabaseColumnSelect[DatabaseColumnRankDictionaryWordSecond]];

     if ( dictionaryIdFirst != dictionaryIdFirstCurrent )
     {    
      dictionaryIdFirstCurrent  = dictionaryIdFirst;

      sbResultElement.AppendFormat
      (
       FormatDictionaryWord, 
       dictionaryWordFirst
      );

      sbResultElement.AppendFormat
      (
       FormatDictionarySynonym, 
       dictionaryWordSecond
      );
      
     }//if ( dictionaryIdFirst != dictionaryIdFirstCurrent )
     else
     {
      sbResultElement.Append( ", " + dictionaryWordSecond );
     }

    }//foreach(DataRow dataRow in dataTable.Rows)
   }//foreach(DataTable dataTable in dataSet.Tables)

   #if (DEBUG)
    System.Console.WriteLine("{0}", sbResultElement );
   #endif

  }//Search()

  /// <summary>Read the XML Configuration file.</summary>
  public static void ConfigurationXml()
  {  
   ConfigurationXml
   (
    ref FilenameConfigurationXml,
    ref ExceptionMessage,
    ref DatabaseConnectionString
   );
  }//public static void ConfigurationXml()

  /// <summary>Read the XML Configuration file.</summary>
  /// <param name="filenameConfigurationXml">The configuration XML filename.</param>  
  /// <param name="exceptionMessage">The exception message.</param>  
  /// <param name="databaseConnectionString">The database connection string, for example, "Provider=SQLOLEDB;Data Source=localhost;user id=WordEngineering;password=WordEngineering;Initial Catalog=Bible;"</param>  
  public static void ConfigurationXml
  (
   ref string filenameConfigurationXml,
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
    );//ConfigurationXml()
  }//ConfigurationXml	 

  static GutenbergRogetThesaurusOfEnglishWordsAndPhrases()
  {
   string       filenameConfigurationXml = FilenameConfigurationXml;
   string       serverMapPath            = null;
   HttpContext  httpContext              = HttpContext.Current;   

   if ( httpContext != null )   
   {
    serverMapPath = httpContext.Request.MapPath("");
    filenameConfigurationXml = serverMapPath + @"\" + filenameConfigurationXml;
   }

   ConfigurationXml();

  }//static()
  
 }//public class GutenbergRogetThesaurusOfEnglishWordsAndPhrases.
}//namespace WordEngineering
