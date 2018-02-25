using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WordEngineering
{
 /// <summary>Alphabet Sequence.</summary>
 /// <remarks>Alphabet Sequence.</remarks>
 public class AlphabetSequence
 {

  const  int    DatabaseOutputParameterSize          =  600;   

  const  int    ResultSetOrdinalWord                               =  0;
  const  int    ResultSetOrdinalAlphabetSequence                   =  1;
  const  int    ResultSetOrdinalScriptureReferenceVerseForward     =  2;
  const  int    ResultSetOrdinalScriptureReferenceChapterForward   =  3;
  const  int    ResultSetOrdinalScriptureReferenceChapterBackward  =  4;
  const  int    ResultSetOrdinalScriptureReferenceVerseBackward    =  5;  
  const  int    ResultSetOrdinalScriptureReference                 =  6;
  const  int    ResultSetOrdinalVerseForward                       =  7;
  const  int    ResultSetOrdinalChapterForward                     =  8;
  const  int    ResultSetOrdinalChapterBackward                    =  9;
  const  int    ResultSetOrdinalVerseBackward                      =  10;            

  /// <summary>The database connection string.</summary>
  public static string DatabaseConnectionString             = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Bible;";
  
  /// <summary>The configuration XML filename.</summary>
  public static string FilenameConfigurationXml             = @"WordEngineering.config";
  
  /// <summary>The SQL select for the alphabet sequence.</summary>
  public const  string SQLSelectAlphabetSequence            = "uspAlphabetSequence";

  /// <summary>The SQL select for the maximum chapter</summary>
  public const  string SQLSelectChapterMaximum              = "uspChapterMaximum";
  
  const  string ParameterWord                               = "@word";
  const  string ParameterScriptureReferenceAssociates       = "@scriptureReferenceAssociates";  
  const  string ParameterAlphabetSequence                   = "@alphabetSequenceIndex";
  const  string ParameterScriptureReferenceVerseForward     = "@scriptureReferenceVerseForward";
  const  string ParameterScriptureReferenceChapterForward   = "@scriptureReferenceChapterForward";  
  const  string ParameterScriptureReferenceChapterBackward  = "@scriptureReferenceChapterBackward";    
  const  string ParameterScriptureReferenceVerseBackward    = "@scriptureReferenceVerseBackward";      
  const  string ParameterScriptureReference                 = "@scriptureReference";
  const  string ParameterVerseForward                       = "@verseForward";
  const  string ParameterChapterForward                     = "@chapterForward";  
  const  string ParameterChapterBackward                    = "@chapterBackward";  
  const  string ParameterVerseBackward                      = "@verseBackward";
  const  string ParameterSequenceOrderId                    = "@sequenceOrderId";  
  const  string ParameterCommentary                         = "@commentary";  
  const  string ParameterTheWordId                          = "@theWordId";  

  const  string XPathDatabaseConnectionString               = @"/word/database/sqlServer/bible/databaseConnectionString";
 
  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of arguments</param>
  public static void Main( string[] argv )
  {

   int[]                                 alphabetSequence                   = new int[ argv.Length ];
   
   string                                exceptionMessage                   = null;
   string                                scriptureReferenceAssociates       = null;   
   ScriptureReferenceAlphabetSequence[]  scriptureReferenceAlphabetSequence = new ScriptureReferenceAlphabetSequence [ argv.Length ];
   
   try
   {

    if ( argv.Length == 0 )
    {
     for ( char currentCharacter = 'A'; currentCharacter <= 'Z'; ++currentCharacter )
     {
      System.Console.WriteLine("{0} = {1}", currentCharacter, currentCharacter - 'A' + 1 );
     }
     return;
    }//if ( args.Length == 0 )

    DatabaseQuery
    ( 
     ref DatabaseConnectionString,
     ref exceptionMessage,
         argv, 
         scriptureReferenceAssociates,
     ref alphabetSequence,
     ref scriptureReferenceAlphabetSequence 
    );

    foreach ( ScriptureReferenceAlphabetSequence scriptureReferenceAlphabetSequenceCurrent in scriptureReferenceAlphabetSequence )
    {
     System.Console.WriteLine( scriptureReferenceAlphabetSequenceCurrent );
    }//foreach ( ScriptureReferenceAlphabetSequence scriptureReferenceAlphabetSequenceCurrent in scriptureReferenceAlphabetSequence )
   
   }//try 
   catch( Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }//catch( Exception exception)         
  
  }//public void Main( string[] args )

  /// <summary>The database query.</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="word">The word.</param>
  /// <param name="scriptureReferenceAssociates">The scripture reference associates.</param>  
  /// <param name="alphabetSequence">The alphabet sequence.</param>
  /// <param name="scriptureReferenceAlphabetSequence">The scripture reference alphabet sequence.</param>  
  public static void DatabaseQuery
  (
   ref string                                databaseConnectionString,
   ref string                                exceptionMessage,
       string                                word,
       string                                scriptureReferenceAssociates,
   ref int                                   alphabetSequence,
   ref ScriptureReferenceAlphabetSequence[]  scriptureReferenceAlphabetSequence
  ) 
  {
   int[] alphabetSequences = new int[] { alphabetSequence };
   DatabaseQuery
   ( 
    ref databaseConnectionString,
    ref exceptionMessage,
        new string[] { word }, 
        scriptureReferenceAssociates,
    ref alphabetSequences,
    ref scriptureReferenceAlphabetSequence
   );
  }//public static void DatabaseQuery() 

  /// <summary>The database query.</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="word">The word.</param>
  /// <param name="scriptureReferenceAssociates">The scripture reference associates.</param>  
  /// <param name="alphabetSequence">The alphabet sequence.</param>
  /// <param name="scriptureReferenceAlphabetSequence">The scripture reference alphabet sequence.</param>  
  public static void DatabaseQuery
  (
   ref string                                databaseConnectionString,
   ref string                                exceptionMessage,
       string[]                              word,
       string                                scriptureReferenceAssociates,
   ref int[]                                 alphabetSequence,
   ref ScriptureReferenceAlphabetSequence[]  scriptureReferenceAlphabetSequence
  ) 
  {

   int    wordTotal           = word.Length;

   string chapterForward                    = null;
   string chapterBackward                   = null;

   string scriptureReference                = null;
   string scriptureReferenceChapterBackward = null;   
   string scriptureReferenceChapterForward  = null;
   string scriptureReferenceVerseBackward   = null;      
   string scriptureReferenceVerseForward    = null;
   string verseForward                      = null;
   string verseBackward                     = null;


   OleDbConnection  oleDbConnection                   =  null;
   OleDbCommand     oleDbCommand                      =  null;
   
   OleDbDataReader  oleDbDataReader                   =  null;
      
   OleDbParameter   oleDbParameterWord                               =  null;
   OleDbParameter   oleDbParameterScriptureReferenceAssociates       =  null;   
   OleDbParameter   oleDbParameterAlphabetSequence                   =  null;
   OleDbParameter   oleDbParameterScriptureReferenceVerseForward     =  null;   
   OleDbParameter   oleDbParameterScriptureReferenceChapterForward   =  null;   
   OleDbParameter   oleDbParameterScriptureReferenceChapterBackward  =  null;   
   OleDbParameter   oleDbParameterScriptureReferenceVerseBackward    =  null;         
   OleDbParameter   oleDbParameterScriptureReference                 =  null;
   OleDbParameter   oleDbParameterVerseForward                       =  null;
   OleDbParameter   oleDbParameterChapterForward                     =  null;
   OleDbParameter   oleDbParameterChapterBackward                    =  null;
   OleDbParameter   oleDbParameterVerseBackward                      =  null;   

   AlphabetSequenceIndexCalculate
   (
    ref word,
    ref alphabetSequence
   );
    
   try
   {
    if ( databaseConnectionString == null )
    {
     databaseConnectionString = DatabaseConnectionString;
    }//if ( databaseConnectionString == null )
    
    oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
    (
         databaseConnectionString,
     ref exceptionMessage
    );

    if ( oleDbConnection == null || exceptionMessage != null )
    {
     return;
    }//if ( oleDbConnection == null || exceptionMessage != null )

    oleDbCommand =  new OleDbCommand( SQLSelectAlphabetSequence, oleDbConnection);
    oleDbCommand.CommandType = CommandType.StoredProcedure;

    oleDbParameterWord                                = new OleDbParameter(ParameterWord, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterScriptureReferenceAssociates        = new OleDbParameter(ParameterWord, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterAlphabetSequence                    = new OleDbParameter(ParameterAlphabetSequence, OleDbType.Integer);
    oleDbParameterScriptureReferenceVerseForward      = new OleDbParameter(ParameterScriptureReferenceVerseForward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterScriptureReferenceChapterForward    = new OleDbParameter(ParameterScriptureReferenceChapterForward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterScriptureReferenceChapterBackward   = new OleDbParameter(ParameterScriptureReferenceChapterBackward, OleDbType.VarChar, DatabaseOutputParameterSize);    
    oleDbParameterScriptureReferenceVerseBackward     = new OleDbParameter(ParameterScriptureReferenceVerseBackward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterScriptureReference                  = new OleDbParameter(ParameterScriptureReference, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterVerseForward                        = new OleDbParameter(ParameterVerseForward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterChapterForward                      = new OleDbParameter(ParameterChapterForward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterChapterBackward                     = new OleDbParameter(ParameterChapterBackward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterVerseBackward                       = new OleDbParameter(ParameterVerseBackward, OleDbType.VarChar, DatabaseOutputParameterSize);    
   
    oleDbCommand.Parameters.Add(oleDbParameterWord);
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReferenceAssociates);
    oleDbCommand.Parameters.Add(oleDbParameterAlphabetSequence);
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReferenceVerseForward);
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReferenceChapterForward);
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReferenceChapterBackward);    
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReferenceVerseBackward);        
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReference);
    oleDbCommand.Parameters.Add(oleDbParameterVerseForward);
    oleDbCommand.Parameters.Add(oleDbParameterChapterForward);
    oleDbCommand.Parameters.Add(oleDbParameterChapterBackward);
    oleDbCommand.Parameters.Add(oleDbParameterVerseBackward);

    oleDbParameterWord.Direction                               = ParameterDirection.InputOutput;
    oleDbParameterScriptureReferenceAssociates.Direction       = ParameterDirection.InputOutput;     
    oleDbParameterAlphabetSequence.Direction                   = ParameterDirection.InputOutput;
    oleDbParameterScriptureReferenceVerseForward.Direction     = ParameterDirection.Output;
    oleDbParameterScriptureReferenceChapterForward.Direction   = ParameterDirection.Output;    
    oleDbParameterScriptureReferenceChapterBackward.Direction  = ParameterDirection.Output;        
    oleDbParameterScriptureReferenceVerseBackward.Direction    = ParameterDirection.Output;            
    oleDbParameterScriptureReference.Direction                 = ParameterDirection.Output;
    oleDbParameterVerseForward.Direction                       = ParameterDirection.Output;
    oleDbParameterChapterForward.Direction                     = ParameterDirection.Output;
    oleDbParameterChapterBackward.Direction                    = ParameterDirection.Output;
    oleDbParameterVerseBackward.Direction                      = ParameterDirection.Output;  

    for ( int wordCount = 0; wordCount < wordTotal; ++wordCount )
    {

     oleDbParameterWord.Value                         =  word[wordCount];
     oleDbParameterScriptureReferenceAssociates.Value =  scriptureReferenceAssociates;
     oleDbParameterAlphabetSequence.Value             =  alphabetSequence[wordCount];

     oleDbCommand.ExecuteScalar();
     
     scriptureReferenceVerseForward    = ( oleDbParameterScriptureReferenceVerseForward.Value).ToString();
     scriptureReferenceChapterForward  = ( oleDbParameterScriptureReferenceChapterForward.Value).ToString();
     scriptureReferenceChapterBackward = ( oleDbParameterScriptureReferenceChapterBackward.Value).ToString();     
     scriptureReferenceVerseBackward   = ( oleDbParameterScriptureReferenceVerseBackward.Value).ToString();
     scriptureReference = ( oleDbParameterScriptureReference.Value).ToString();
     verseForward       = ( oleDbParameterVerseForward.Value).ToString();
     chapterForward     = ( oleDbParameterChapterForward.Value).ToString();
     chapterBackward    = ( oleDbParameterChapterBackward.Value).ToString();
     verseBackward      = ( oleDbParameterVerseBackward.Value).ToString();
     
     scriptureReferenceAlphabetSequence[wordCount] = new ScriptureReferenceAlphabetSequence
     (
      word[wordCount],
      scriptureReferenceAssociates,
      alphabetSequence[wordCount],
      scriptureReferenceVerseForward,
      scriptureReferenceChapterForward,
      scriptureReferenceChapterBackward,
      scriptureReferenceVerseBackward,
      scriptureReference,
      verseForward,
      chapterForward,
      chapterBackward,
      verseBackward
     );
    
     return;
          
    }//for ( int wordCount = 0; wordCount < word.Length; ++wordCount )

   }//try
   catch (OleDbException exception)
   {
    exceptionMessage = UtilityDatabase.DisplayOleDbErrorCollection( exception );
    System.Console.WriteLine("OleDbException: {0}", exceptionMessage);
    System.Console.WriteLine("OleDbException: {0}", oleDbParameterAlphabetSequence.Value);
    return;
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage = exception.Message; 	
    System.Console.WriteLine("Exception: {0}", exception.Message);
    return;    
   }//catch (Exception exception)
   finally
   {
    if ( oleDbDataReader != null )
    {
     oleDbDataReader.Close();
    } 
    UtilityDatabase.DatabaseConnectionHouseKeeping
    (
         oleDbConnection,
     ref exceptionMessage
    );
   }//finally
   return;
  }//AlphabetSequenceDatabaseQuery()

  /// <summary>The database query.</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="wordQuery">The word.</param>
  /// <param name="scriptureReferenceAssociates">The scripture reference associates.</param>  
  /// <param name="alphabetSequenceIndex">The alphabet sequence index.</param>
  /// <param name="scriptureReferenceAlphabetSequence">The scripture reference alphabet sequence.</param>  
  public static void AlphabetSequenceQuery
  (
   ref String                                databaseConnectionString,
   ref String                                exceptionMessage,
   ref String[]                              wordQuery,
       String                                scriptureReferenceAssociates,
   ref int[]                                 alphabetSequenceIndex,
   ref ScriptureReferenceAlphabetSequence[]  scriptureReferenceAlphabetSequence
  ) 
  {

   int    sequenceOrderId                   = -1;
   int    theWordId                         = -1;
   int    wordQueryTotal                    = wordQuery.Length;

   string chapterForward                    = null;
   string chapterBackward                   = null;
   //string commentary                        = null;

   string scriptureReference                = null;
   string scriptureReferenceChapterBackward = null;   
   string scriptureReferenceChapterForward  = null;
   string scriptureReferenceVerseBackward   = null;      
   string scriptureReferenceVerseForward    = null;
   string verseForward                      = null;
   string verseBackward                     = null;

   OleDbConnection  oleDbConnection         = null;
   OleDbCommand     oleDbCommand            = null;
   
   OleDbDataReader  oleDbDataReader         = null;
      
   OleDbParameter   oleDbParameterWord                               =  null;
   OleDbParameter   oleDbParameterScriptureReferenceAssociates       =  null;   
   OleDbParameter   oleDbParameterAlphabetSequence                   =  null;
   OleDbParameter   oleDbParameterScriptureReferenceVerseForward     =  null;   
   OleDbParameter   oleDbParameterScriptureReferenceChapterForward   =  null;   
   OleDbParameter   oleDbParameterScriptureReferenceChapterBackward  =  null;   
   OleDbParameter   oleDbParameterScriptureReferenceVerseBackward    =  null;         
   OleDbParameter   oleDbParameterScriptureReference                 =  null;
   OleDbParameter   oleDbParameterSequenceOrderId                    =  null;
   OleDbParameter   oleDbParameterVerseForward                       =  null;
   OleDbParameter   oleDbParameterChapterForward                     =  null;
   OleDbParameter   oleDbParameterChapterBackward                    =  null;
   OleDbParameter   oleDbParameterVerseBackward                      =  null;   
   OleDbParameter   oleDbParameterCommentary                         =  null;   
   OleDbParameter   oleDbParameterTheWordId                          =  null;   

   AlphabetSequenceIndexCalculate
   (
    ref wordQuery,
    ref alphabetSequenceIndex
   );
   
   try
   {
    if 
    ( 
     databaseConnectionString == null || 
     databaseConnectionString.IndexOf("Bible") < 0
    )
    {
     databaseConnectionString = DatabaseConnectionString;
    }//if ( databaseConnectionString == null )
    
    oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
    (
         databaseConnectionString,
     ref exceptionMessage
    );

    if ( oleDbConnection == null || exceptionMessage != null )
    {
     return;
    }//if ( oleDbConnection == null || exceptionMessage != null )

    oleDbCommand =  new OleDbCommand( SQLSelectAlphabetSequence, oleDbConnection);
    oleDbCommand.CommandType = CommandType.StoredProcedure;

    oleDbParameterWord                                = new OleDbParameter(ParameterWord, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterScriptureReferenceAssociates        = new OleDbParameter(ParameterWord, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterAlphabetSequence                    = new OleDbParameter(ParameterAlphabetSequence, OleDbType.Integer);
    oleDbParameterScriptureReferenceVerseForward      = new OleDbParameter(ParameterScriptureReferenceVerseForward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterScriptureReferenceChapterForward    = new OleDbParameter(ParameterScriptureReferenceChapterForward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterScriptureReferenceChapterBackward   = new OleDbParameter(ParameterScriptureReferenceChapterBackward, OleDbType.VarChar, DatabaseOutputParameterSize);    
    oleDbParameterScriptureReferenceVerseBackward     = new OleDbParameter(ParameterScriptureReferenceVerseBackward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterScriptureReference                  = new OleDbParameter(ParameterScriptureReference, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterVerseForward                        = new OleDbParameter(ParameterVerseForward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterChapterForward                      = new OleDbParameter(ParameterChapterForward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterChapterBackward                     = new OleDbParameter(ParameterChapterBackward, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterVerseBackward                       = new OleDbParameter(ParameterVerseBackward, OleDbType.VarChar, DatabaseOutputParameterSize);    
    oleDbParameterSequenceOrderId                     = new OleDbParameter(ParameterSequenceOrderId, OleDbType.Integer);
    oleDbParameterCommentary                          = new OleDbParameter(ParameterCommentary, OleDbType.VarChar, DatabaseOutputParameterSize);
    oleDbParameterTheWordId                           = new OleDbParameter(ParameterTheWordId, OleDbType.Integer);
    oleDbParameterSequenceOrderId                     = new OleDbParameter(ParameterSequenceOrderId, OleDbType.Integer);

    /*
    @word                               VARCHAR(600)  =  NULL  OUTPUT,
    @scriptureReferenceAssociates       VARCHAR(600)  =  NULL  OUTPUT,
    @alphabetSequence                   INT           =  -1    OUTPUT,
    @scriptureReferenceVerseForward     VARCHAR(600)  =  NULL  OUTPUT,
    @scriptureReferenceChapterForward   VARCHAR(600)  =  NULL  OUTPUT,
    @scriptureReferenceChapterBackward  VARCHAR(600)  =  NULL  OUTPUT,
    @scriptureReferenceVerseBackward    VARCHAR(600)  =  NULL  OUTPUT,
    @scriptureReference                 VARCHAR(600)  =  NULL  OUTPUT,
    @verseForward                       VARCHAR(600)  =  NULL  OUTPUT,
    @chapterForward                     VARCHAR(600)  =  NULL  OUTPUT,
    @chapterBackward                    VARCHAR(600)  =  NULL  OUTPUT,
    @verseBackward                      VARCHAR(600)  =  NULL  OUTPUT,
    @sequenceOrderId                    INT           =  -1    OUTPUT
    */

    oleDbCommand.Parameters.Add(oleDbParameterWord);
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReferenceAssociates);
    oleDbCommand.Parameters.Add(oleDbParameterAlphabetSequence);
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReferenceVerseForward);
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReferenceChapterForward);
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReferenceChapterBackward);    
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReferenceVerseBackward);        
    oleDbCommand.Parameters.Add(oleDbParameterScriptureReference);
    oleDbCommand.Parameters.Add(oleDbParameterVerseForward);
    oleDbCommand.Parameters.Add(oleDbParameterChapterForward);
    oleDbCommand.Parameters.Add(oleDbParameterChapterBackward);
    oleDbCommand.Parameters.Add(oleDbParameterVerseBackward);
    /*
     oleDbCommand.Parameters.Add(oleDbParameterCommentary);
     oleDbCommand.Parameters.Add(oleDbParameterTheWordId);
    */
    oleDbCommand.Parameters.Add(oleDbParameterSequenceOrderId);

    oleDbParameterWord.Direction                               = ParameterDirection.InputOutput;
    oleDbParameterScriptureReferenceAssociates.Direction       = ParameterDirection.InputOutput;     
    oleDbParameterAlphabetSequence.Direction                   = ParameterDirection.InputOutput;
    oleDbParameterScriptureReferenceVerseForward.Direction     = ParameterDirection.Output;
    oleDbParameterScriptureReferenceChapterForward.Direction   = ParameterDirection.Output;    
    oleDbParameterScriptureReferenceChapterBackward.Direction  = ParameterDirection.Output;        
    oleDbParameterScriptureReferenceVerseBackward.Direction    = ParameterDirection.Output;            
    oleDbParameterScriptureReference.Direction                 = ParameterDirection.Output;
    oleDbParameterVerseForward.Direction                       = ParameterDirection.Output;
    oleDbParameterChapterForward.Direction                     = ParameterDirection.Output;
    oleDbParameterChapterBackward.Direction                    = ParameterDirection.Output;
    oleDbParameterVerseBackward.Direction                      = ParameterDirection.Output;  
    /*
     oleDbParameterCommentary.Direction                         = ParameterDirection.InputOutput;  
     oleDbParameterTheWordId.Direction                          = ParameterDirection.InputOutput;
    */
    oleDbParameterSequenceOrderId.Direction                    = ParameterDirection.InputOutput;

    for ( int wordQueryIndex = 0; wordQueryIndex < wordQuery.Length; ++wordQueryIndex )
    {

     oleDbParameterAlphabetSequence.Value             =  alphabetSequenceIndex[wordQueryIndex];
     oleDbParameterScriptureReferenceAssociates.Value =  scriptureReferenceAssociates;
     oleDbParameterSequenceOrderId.Value              =  -1;
     oleDbParameterTheWordId.Value                    =  null;
     oleDbParameterWord.Value                         =  wordQuery[wordQueryIndex];

     oleDbCommand.ExecuteScalar();
     
     //oleDbDataReader = oleDbCommand.ExecuteReader();     

     scriptureReferenceVerseForward    = ( oleDbParameterScriptureReferenceVerseForward.Value).ToString();
     scriptureReferenceChapterForward  = ( oleDbParameterScriptureReferenceChapterForward.Value).ToString();
     scriptureReferenceChapterBackward = ( oleDbParameterScriptureReferenceChapterBackward.Value).ToString();     
     scriptureReferenceVerseBackward   = ( oleDbParameterScriptureReferenceVerseBackward.Value).ToString();

     scriptureReference = ( oleDbParameterScriptureReference.Value).ToString();
     verseForward       = ( oleDbParameterVerseForward.Value).ToString();
     chapterForward     = ( oleDbParameterChapterForward.Value).ToString();
     chapterBackward    = ( oleDbParameterChapterBackward.Value).ToString();
     verseBackward      = ( oleDbParameterVerseBackward.Value).ToString();
     sequenceOrderId    = Int32.Parse ( oleDbParameterSequenceOrderId.Value.ToString() );
     /*
      theWordId          = Int32.Parse ( oleDbParameterTheWordId.Value.ToString() );
     */
     
     scriptureReferenceAlphabetSequence[wordQueryIndex] = new ScriptureReferenceAlphabetSequence
     (
      wordQuery[wordQueryIndex],
      scriptureReferenceAssociates,
      alphabetSequenceIndex[wordQueryIndex],
      scriptureReferenceVerseForward,
      scriptureReferenceChapterForward,
      scriptureReferenceChapterBackward,
      scriptureReferenceVerseBackward,
      scriptureReference,
      verseForward,
      chapterForward,
      chapterBackward,
      verseBackward,
      sequenceOrderId
     );

     #if (DEBUG)
      System.Console.WriteLine("SequenceOrderId: {0}", sequenceOrderId);
      System.Console.WriteLine("TheWordId: {0}", theWordId);
     #endif

    
    }//for ( int wordQueryIndex = 0; wordQueryIndex < wordQueryTotal; ++wordQueryIndex )

   }//try
   catch (OleDbException exception)
   {
    exceptionMessage = UtilityDatabase.DisplayOleDbErrorCollection( exception );
    System.Console.WriteLine("OleDbException: {0}", exceptionMessage);
    System.Console.WriteLine("OleDbException: {0}", oleDbParameterAlphabetSequence.Value);
    return;
   }//catch (OleDbException exception)
   catch (Exception exception)
   {
    exceptionMessage = exception.Message; 	
    System.Console.WriteLine("Exception: {0}", exception.Message);
    return;    
   }//catch (Exception exception)
   finally
   {
    if ( oleDbDataReader != null )
    {
     oleDbDataReader.Close();
    } 
    UtilityDatabase.DatabaseConnectionHouseKeeping
    (
         oleDbConnection,
     ref exceptionMessage
    );
   }//finally
   return;
  }//AlphabetSequenceQuery()

  /// <summary>AlphabetSequenceIndexCalculate.</summary>
  public static void AlphabetSequenceIndexCalculate
  (
   ref String[]  word,
   ref int[]     alphabetSequenceIndex
  )
  {

   int      alphabetSequenceIndexCounter = 0;
   int      alphabetSequenceIndexTotal   = 0;

   try
   {
    alphabetSequenceIndex = new int[word.Length];
    for ( int wordCount = 0; wordCount < word.Length; ++wordCount )
    {
     if ( word[wordCount] == null || word[wordCount].Length == 0 )
     {
      continue;
     }//if ( word[wordCount] == null || word[wordCount].Length == 0 )           	
     word[wordCount] = word[wordCount].Trim();
    
     AlphabetSequenceIndexCalculate
     (
      ref word[wordCount],
      ref alphabetSequenceIndex[wordCount]
     );

     if ( alphabetSequenceIndex[wordCount] > 0 )
     {
      continue;
     }//if ( alphabetSequenceIndex[wordCount] > 0 )

     for ( int charCount = 0; charCount < word[wordCount].Length; ++charCount )
     {
      if ( word[wordCount][charCount] >= 'a' && word[wordCount][charCount] <= 'z' )
      {
       alphabetSequenceIndex[wordCount] += word[wordCount][charCount] - 'a' + 1;
      }//if ( word[wordCount][charCount] >= 'a' && word[wordCount][charCount] <= 'z' )
      else if ( word[wordCount][charCount] >= 'A' && word[wordCount][charCount] <= 'Z' )
      {
       alphabetSequenceIndex[wordCount] += word[wordCount][charCount] - 'A' + 1;
      }//else if ( word[wordCount][charCount] >= 'A' && word[wordCount][charCount] <= 'Z' )
     }//for ( charCount = 0; charCount <= word[wordCount].Length = 0; ++charCount ) 
    }//for ( int wordCount = 0; wordTotal < word.Length; ++wordCount )
   }//try
   catch ( ArgumentException exception )
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }//catch ( ArgumentException exception )   	
   catch ( FormatException exception )
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }//catch ( FormatException exception )   	
   catch ( OverflowException exception )
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }//catch ( OverflowException exception )   	
   catch ( Exception exception )
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }//catch ( Exception exception )   	

   #if ( DEBUG ) 
    alphabetSequenceIndexCounter = 0;
    foreach ( int alphabetSequenceIndexCurrent in alphabetSequenceIndex )
    {
     ++alphabetSequenceIndexCounter;
     alphabetSequenceIndexTotal += alphabetSequenceIndexCurrent;
     System.Console.WriteLine
     (
      "alphabetSequenceIndex[{0}]: {1}", 
      alphabetSequenceIndexCounter,
      alphabetSequenceIndexCurrent
     );
    }
    System.Console.WriteLine("alphabetSequenceIndex: {0}", alphabetSequenceIndexTotal);
   #endif

  }//public static void AlphabetSequenceIndexCalculate()

  
  /// <summary>AlphabetSequenceIndexCalculate</summary>
  public static void AlphabetSequenceIndexCalculate
  (
   ref String alphabetSequenceWord,
   ref int    alphabetSequenceIndex
  )
  {
   try
   {
    alphabetSequenceIndex = Int32.Parse( alphabetSequenceWord );
   }//try
   catch ( Exception )
   {
   }//catch ( Exception )
  }//public static void AlphabetSequenceIndexCalculate()  

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
    );//ConfigurationXml()
  }//ConfigurationXml	 
  
  static AlphabetSequence()
  {
   ConfigurationXml();
  }//static()

 }//AlphabetSequence Class.
}//WordEngineering Namespace.
