using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace WordEngineering
{
 ///<remarks>
 ///ms-help://MS.NETFrameworkSDK/cpguidenf/html/cpconreadingwritingtofiles.htm
 ///File Template
 ///  $$T0000001
 ///  \A\
 ///  Alpha, the first letter of the Greek alphabet, as Omega is the
 ///  last. These letters occur in the text of Rev. 1:8,11; 21:6;
 ///  22:13, and are represented by "Alpha" and "Omega" respectively
 ///  (omitted in R.V., 1:11). They mean "the first and last." (Comp.
 ///  Heb. 12:2; Isa. 41:4; 44:6; Rev. 1:11,17; 2:8.) In the symbols
 ///  of the early Christian Church these two letters are frequently
 ///  combined with the cross or with Christ's monogram to denote his
 ///  divinity.
 ///</remarks>
 public class PopulateBibleFoundationEaston
 {
  
  public const char    LanguageGreek            = 'G';
  public const char    LanguageHebrew           = 'H';
  public static char   languageGreekHebrew      = ' ';

  public static int    number                   = 0;
  public static int    CommandLineArgumentSourceDirectory = 0;
  
  public const string DatabaseConnectionString  = "Data Source=localhost; Integrated Security=SSPI;" +
                                                  "Initial Catalog=BibleDictionary";
  public const string         FileSearchPattern = "*.";
  public const string         StoredProcedure   = "PopulateBibleFoundationEaston";
  public const string         SourceDirectory   = @"C:\unzipped\BibleFoundation_-_Easton";  
  
  public static SqlCommand    sqlCommand       = null;
  public static SqlConnection sqlConnection    = null;
  
  public static SqlParameter  dictionaryIdSqlParameter         = null;
  public static SqlParameter  dictionaryWordSqlParameter       = null;
  public static SqlParameter  dictionaryCommentarySqlParameter = null;
  
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
   string sourceFile
  )
  {
  
   int           dictionaryWordDelimiterEnd = 0;
   
   string        contentCommentary          = null;
   
   string        dictionaryId               = null;
   string        dictionaryIdNext           = null;
   string        dictionaryWord             = null;
   
   StreamReader  sourceStreamReader         = null;
   StringBuilder dictionaryCommentary       = null;

   try
   {
    //Open the James Strong File.
    sourceStreamReader = new StreamReader
    (
      (System.IO.Stream)File.OpenRead(sourceFile),
      System.Text.Encoding.ASCII
    ); 
    
    //Begin process the stream reader at the beginning-of-file (BOF)
    sourceStreamReader.BaseStream.Seek
    (
     0,
     SeekOrigin.Begin
    );
     
    //Read and extract the Dictionary Id.
    dictionaryId = sourceStreamReader.ReadLine();
    dictionaryId = dictionaryId.Substring(3);

    //Process the stream reader until the end-of-file (EOF).
    while (sourceStreamReader.Peek() > -1)
    {
    
     //Read the Dictionary Word.
     dictionaryWord = sourceStreamReader.ReadLine();
     dictionaryWordDelimiterEnd = dictionaryWord.LastIndexOf('\\');
     
     dictionaryWord = dictionaryWord.Substring(1, dictionaryWordDelimiterEnd - 1);
    
     //Read the Dictionary Commentary
     dictionaryCommentary = new StringBuilder();
     while (sourceStreamReader.Peek() > -1)
     {
       contentCommentary = sourceStreamReader.ReadLine();   
       
       if ( contentCommentary.Length >= 3 )
       {
        if ( contentCommentary.Substring(0,3) == "$$T" ) 
        {
         dictionaryIdNext = contentCommentary.Substring(3);
         break;
        } 
        else
        {
         dictionaryCommentary.Append( contentCommentary );
         dictionaryCommentary.Append( ' ' );
        }//if ( contentCommentary.Substring(0,3) == "$$T" )
       }//if ( contentCommentary.Length >= 3 )
        
     }//Process the commentary line.
     
     /*
     System.Console.WriteLine("Dictionary Id:         {0}", dictionaryId);
     System.Console.WriteLine("Dictionary Word:       {0}", dictionaryWord);     
     System.Console.WriteLine("Dictionary Commentary: {0}", dictionaryCommentary);
     */

     DatabaseWrite
     ( 
      Convert.ToInt32(dictionaryId),
      dictionaryWord, 
      dictionaryCommentary 
     );
     
     //Retrieve the next Dictionary Id.
     dictionaryId = dictionaryIdNext;
    
    }//Process the stream reader until the end-of-file (EOF) 
  
   }//try
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }//catch
   finally
   {
    //Close the James Strong File.
    sourceStreamReader.Close();
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
    
    dictionaryIdSqlParameter          = sqlCommand.Parameters.Add("@dictionaryId",   SqlDbType.Int);
    dictionaryWordSqlParameter        = sqlCommand.Parameters.Add("@dictionaryWord", SqlDbType.VarChar, 50);
    dictionaryCommentarySqlParameter  = sqlCommand.Parameters.Add("@commentary",     SqlDbType.Text);
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
   int            dictionaryId,
   string         dictionaryWord,
   StringBuilder  dictionaryCommentary
  ) 
  {
   try
   {

    dictionaryIdSqlParameter.Value          = dictionaryId;
    dictionaryWordSqlParameter.Value        = dictionaryWord;
    dictionaryCommentarySqlParameter.Value  = dictionaryCommentary.ToString();
                
    sqlCommand.ExecuteNonQuery();
    
   }
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
    System.Console.WriteLine
    (
     "Dictionary Id: {0} | Word: {1} | Commentary: {2}", dictionaryId, dictionaryWord, dictionaryCommentary
    );    
   }
  }//DatabaseWrite()
 
 }//PopulateBibleFoundationEaston class.
}//WordEngineering Namespace.
