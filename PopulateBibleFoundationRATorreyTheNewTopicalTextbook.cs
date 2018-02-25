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
 public class PopulateBibleFoundationRATorreyTheNewTopicalTextbook
 {
  
  public static int          CommandLineArgumentSourceDirectory = 0;
  
  public const string DatabaseConnectionString                  = "Data Source=localhost; Integrated Security=SSPI;" +
                                                                  "Initial Catalog=BibleDictionary";
  public const string         FileSearchPattern                 = "*.";
  public const string         StoredProcedure                   = "PopulateBibleFoundationRATorreyTheNewTopicalTextbook";
  public const string         SourceDirectory                   = @"c:\unzipped\BibleFoundation_-_R.A.TorreyTheNewTopicalTextbook";  
  
  public static SqlCommand    sqlCommand                        = null;
  public static SqlConnection sqlConnection                     = null;
  
  public static SqlParameter  dictionaryIdSqlParameter          = null;
  public static SqlParameter  dictionaryWordSqlParameter        = null;
  public static SqlParameter  commentarySqlParameter            = null;  
  
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
   string filename
  )
  {
   int           positionDirectoryFileSeparator  = 0;      
                                                       
   string        contentBlank                    = null;
   String        contentCommentary               = null;

   String        dictionaryId                    = "";
   String        dictionaryWord                  = "";
   String        dictionaryHeader                = "";   
   
   StreamReader  streamReader                    = null;
   StringBuilder commentary                      = null;

   //Set the language parameter, either Greek or Hebrew.
   positionDirectoryFileSeparator = filename.LastIndexOf('\\');
 
   try
   {
    //Open the File.
    streamReader = new StreamReader
    (
      (System.IO.Stream)File.OpenRead(filename),
      System.Text.Encoding.ASCII
    ); 
    
    //Begin process the stream reader at the beginning-of-file (BOF)
    streamReader.BaseStream.Seek
    (
     0,
     SeekOrigin.Begin
    );
     
    //Read the dictionary header
    dictionaryHeader = streamReader.ReadLine();
        
    //Process the stream reader until the end-of-file (EOF)
    while (streamReader.Peek() > -1)
    {
     if ( dictionaryHeader.Length >= 3 )
     {
       dictionaryId  =  dictionaryHeader.Substring(3);   
     }
     
     dictionaryWord    =  streamReader.ReadLine();
     if ( dictionaryWord.Length >= 3 )
     {
       dictionaryWord  =  dictionaryWord.Substring( 1, dictionaryWord.Length - 2 );   
     }
     
     //read blank line.
     contentBlank = streamReader.ReadLine();
     
     //Process the commentary line.
     commentary        =     new StringBuilder();
     while (streamReader.Peek() > -1)
     {
       contentCommentary = streamReader.ReadLine(); 
   
       if ( contentCommentary.Length <= 1 )
       {

       }
       else if ( contentCommentary.Substring(3) == "$$T" )
       {
         dictionaryHeader =  contentCommentary;
         break;
       }  
       else
       {
        commentary.Append( contentCommentary.Substring(2) );
       }
     }//Process the commentary line.
     
     DatabaseWrite
     ( 
      Convert.ToInt32(dictionaryId),
      dictionaryWord, 
      commentary 
     );

    }//Process the stream reader until the end-of-file (EOF) 
  
   }//try
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
    System.Console.WriteLine
    (
     "Dictionary Id: {0} | Word: {1} | Commentary: {3}", dictionaryId, dictionaryWord, commentary
    );    
   }//catch
   finally
   {
    //Close the File.
    streamReader.Close();
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
    
    dictionaryIdSqlParameter         = sqlCommand.Parameters.Add("@dictionaryId",        SqlDbType.Int);
    dictionaryWordSqlParameter       = sqlCommand.Parameters.Add("@dictionaryWord",      SqlDbType.VarChar, 50);
    commentarySqlParameter           = sqlCommand.Parameters.Add("@commentary",          SqlDbType.Text);
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
   StringBuilder commentary
  ) 
  {

   if ( dictionaryId < 0 || dictionaryWord == null || dictionaryWord.Length == 0 || commentary == null || commentary.Length == 0 )
   {
     return;
   } 

   try
   {

    dictionaryIdSqlParameter.Value    =  dictionaryId;
    dictionaryWordSqlParameter.Value  =  dictionaryWord;
    commentarySqlParameter.Value      =  commentary.ToString();
                
    sqlCommand.ExecuteNonQuery();
    
   }
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
    System.Console.WriteLine
    (
     "Dictionary Id: {0} | Word: {1} | Commentary: {2}", dictionaryId, dictionaryWord, commentary
    );
   }
  }//DatabaseWrite()
 
 }//NaveGreek class.
}//WordEngineering

