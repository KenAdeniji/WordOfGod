using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace WordEngineering
{
 ///<remarks>
 ///ms-help://MS.NETFrameworkSDK/cpguidenf/html/cpconreadingwritingtofiles.htm
 ///</remarks>
 public class PopulateBibleFoundationJamesStrongExhaustiveConcordanceOfHebrewAndGreekWords
 {
  
  public const char    LanguageGreek           = 'G';
  public const char    LanguageHebrew          = 'H';
  public static char   languageGreekHebrew     = ' ';

  public static int    number                  = 0;
  public static int    CommandLineArgumentSourceDirectory = 0;
  
  public const string DatabaseConnectionString = "Data Source=localhost; Integrated Security=SSPI;" +
                                                 "Initial Catalog=BibleDictionary";
  public const string         FileSearchPattern  = "*.";
  public const string         StoredProcedure  = "PopulateBibleFoundationJamesStrongExhaustiveConcordanceOfHebrewAndGreekWords";
  public const string         SourceDirectory  = @"C:\\unzipped\\BibleFoundation_-_JamesStrongExhaustiveConcordanceJamesStrongDictionariesOfHebrewAndGreekWords";  
  
  public static SqlCommand    sqlCommand       = null;
  public static SqlConnection sqlConnection    = null;
  
  public static SqlParameter  languageGreekHebrewSqlParameter = null;
  public static SqlParameter  dictionaryIdSqlParameter   = null;
  public static SqlParameter  dictionaryWordSqlParameter        = null;
  public static SqlParameter  pronounceSqlParameter           = null;
  public static SqlParameter  commentarySqlParameter          = null;  
  
  public static void Main(string[] args)
  {
   int    argumentCount   = args.Length;
   
   string sourceDirectory = "";
   
   //Retrieve the source directory from the command-line 
   //parameters, first argument.
   switch ( argumentCount )
   {
    case 0: { sourceDirectory = SourceDirectory; break; }
    case 1: { sourceDirectory = args[CommandLineArgumentSourceDirectory]; break; }
   } 
    
   //Open the database connection.
   DatabaseConnectionInitialize();
   
   //Process the files, and write into the database.
   ProcessDirectory( sourceDirectory );
   
   //Close the database connection.
   DatabaseConnectionHouseKeeping();
   
  }

  ///<Document>
  /// Process all files in the directory passed in, and recurse on any directories 
  /// that are found to process the files they contain
  ///ms-help://MS.NETFrameworkSDK/cpref/html/frlrfSystemIODirectoryClassGetDirectoriesTopic1.htm
  ///</Document>
  public static void ProcessDirectory
  (
   string sourceDirectory
  ) 
  {
   // Process the list of files found in the directory
   string [] fileEntries = Directory.GetFiles
   (
    sourceDirectory, 
    FileSearchPattern
   );
  
   foreach(string fileName in fileEntries)
   {
    ProcessFile(fileName);
   } 

   // Recurse into subdirectories of this directory
   string [] subdirectoryEntries = Directory.GetDirectories(sourceDirectory);
   
   foreach(string subdirectory in subdirectoryEntries)
   {
    ProcessDirectory(subdirectory);
   } 
  }
        
  // Real logic for processing found files would go here.
  public static void ProcessFile(string path) 
  {
    FileRead(path);
  }
  
  public static void FileRead
  (
   string filenameJamesStrong
  )
  {
   int           contentSeparatorStart          = 0;
   int           contentSeparatorIndex          = 0;
   int           positionDirectoryFileSeparator = 0;      
                                                       
   string        contentBlank                   = null;
   string        contentNumberEnglishNative     = null;
   string        contentCommentary              = null;
   string        contentSeparator               = " ";   

   string        dictionaryId              = "";
   string        dictionaryWord                   = "";
   string        pronounce                      = "";
   
   string        jamesStrongFiveDigitWordNumber = null;
   
   StreamReader  streamReaderJamesStrong        = null;
   StringBuilder commentary                     = null;

   //Set the language parameter, either Greek or Hebrew.
   positionDirectoryFileSeparator = filenameJamesStrong.LastIndexOf('\\');
   languageGreekHebrew = filenameJamesStrong[positionDirectoryFileSeparator + 1];
   languageGreekHebrewSqlParameter.Value = languageGreekHebrew;
 
   try
   {
    //Open the James Strong File.
    streamReaderJamesStrong = new StreamReader
    (
      (System.IO.Stream)File.OpenRead(filenameJamesStrong),
      System.Text.Encoding.ASCII
    ); 
    
    //Begin process the stream reader at the beginning-of-file (BOF)
    streamReaderJamesStrong.BaseStream.Seek
    (
     0,
     SeekOrigin.Begin
    );
     
    //Read the first file line, James Strong Five Digit Word Number.
    jamesStrongFiveDigitWordNumber = streamReaderJamesStrong.ReadLine();
    
    //Process the stream reader until the end-of-file (EOF)
    while (streamReaderJamesStrong.Peek() > -1)
    {
     contentNumberEnglishNative = streamReaderJamesStrong.ReadLine();
     
     contentSeparatorStart = 1;
     
     contentSeparatorIndex = contentNumberEnglishNative.IndexOf
                             (   
                              contentSeparator,
                              contentSeparatorStart
                             ); 
                             
     dictionaryId =     contentNumberEnglishNative.Substring
                             (
                              contentSeparatorStart,
                              contentSeparatorIndex - 
                              contentSeparatorStart
                             );   

     contentSeparatorStart = contentSeparatorIndex + 2;
     
     contentSeparatorIndex = contentNumberEnglishNative.IndexOf
                             (
                              contentSeparator,
                              contentSeparatorStart
                             );

     dictionaryWord    = contentNumberEnglishNative.Substring
                             (
                              contentSeparatorStart,
                              contentSeparatorIndex -
                              contentSeparatorStart
                             );     
                              
     contentSeparatorStart = contentSeparatorIndex + 2;

     pronounce     = contentNumberEnglishNative.Substring
                             (
                              contentSeparatorStart
                             ); 
                             
     //read blank line.
     contentBlank = streamReaderJamesStrong.ReadLine();
     
     //Process the commentary line.
     commentary = new StringBuilder();
     while (streamReaderJamesStrong.Peek() > -1)
     {
       contentCommentary = streamReaderJamesStrong.ReadLine(); 
   
       if ( contentCommentary.Length == 0 )
       {

       }
       else if ( contentCommentary[0] == ' ' )
       {
        commentary.Append( contentCommentary );
       }
       else
       {
        jamesStrongFiveDigitWordNumber = contentCommentary;
        break;
       } 
     }//Process the commentary line.
     
     /*
     System.Console.WriteLine("Index:      {0}", dictionaryId);
     System.Console.WriteLine("English:    {0}", dictionaryWord);
     System.Console.WriteLine("Native:     {0}", pronounce); 
     System.Console.WriteLine("Commentary: {0}", commentary);   
     */

     DatabaseWrite
     ( 
      Convert.ToInt32(dictionaryId),
      dictionaryWord, 
      pronounce, 
      commentary 
     );
    
    }//Process the stream reader until the end-of-file (EOF) 
  
   }//try
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
    System.Console.WriteLine
    (
     "Dictionary Id: {0} | Word: {1} | Pronounce: {2} | Commentary: {3}", dictionaryId, dictionaryWord, pronounce, commentary
    );    
   }//catch
   finally
   {
    //Close the James Strong File.
    streamReaderJamesStrong.Close();
   }//finally
  }//FileRead()
  
  public static void DatabaseConnectionInitialize()
  {
   SqlConnection  sqlConnection = null;
   try
   {
    sqlConnection = new SqlConnection( DatabaseConnectionString );
    sqlConnection.Open();
    
    sqlCommand    = new SqlCommand( StoredProcedure, sqlConnection );
    sqlCommand.CommandType = CommandType.StoredProcedure;
    
    languageGreekHebrewSqlParameter  =  sqlCommand.Parameters.Add("@languageGreekHebrew", SqlDbType.Char, 1);
    dictionaryIdSqlParameter         =  sqlCommand.Parameters.Add("@dictionaryId",        SqlDbType.Int);
    dictionaryWordSqlParameter       =  sqlCommand.Parameters.Add("@dictionaryWord",      SqlDbType.VarChar, 50);
    pronounceSqlParameter            =  sqlCommand.Parameters.Add("@pronounce",           SqlDbType.VarChar, 50);
    commentarySqlParameter           =  sqlCommand.Parameters.Add("@commentary",          SqlDbType.Text);
   }
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }
  }//DatabaseConnectionInitialize()
  
  public static void DatabaseConnectionHouseKeeping()
  {
   try
   {
    if ( sqlConnection != null )
    {
     sqlConnection.Close();
    } 
   }
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }
  }//DatabaseConnectionHouseKeeping()
  
  public static void DatabaseWrite
  (
   int           dictionaryId,
   string        dictionaryWord,
   string        pronounce,
   StringBuilder commentary
  ) 
  {
   try
   {

    dictionaryIdSqlParameter.Value    =  dictionaryId;
    dictionaryWordSqlParameter.Value  =  dictionaryWord;
    pronounceSqlParameter.Value       =  pronounce;
    commentarySqlParameter.Value      =  commentary.ToString();
                
    sqlCommand.ExecuteNonQuery();
    
   }
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
    System.Console.WriteLine
    (
     "Dictionary Id: {0} | Word: {1} | Pronounce: {2} | Commentary: {3}", dictionaryId, dictionaryWord, pronounce, commentary
    );    
   }
  }//DatabaseWrite()
 
 }//JamesStrongGreek class.
}//WordEngineering

