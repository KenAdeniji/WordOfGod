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
 /// <summary>Gutenberg Webster's Unabridged Dictionary.</summary>
 /// <remarks>Gutenberg Webster's Unabridged Dictionary.</remarks>
 public class GutenbergWebsterUnabridgedDictionary
 {

  const  int      IndexHWWordStart = 4; //7;
  
  const  string   AnchorEndHW                    = "</hw>";

  ///<summary>The database connection string.</summary>  
  public static string   DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=Gutenberg;Integrated Security=SSPI;";

  /*
  ///<summary>DictionaryWordReplace</summary>  
  public static string[] DictionaryWordReplace          = new string []
                                                  {  
  	                                               "||", 
  	                                               "*",
  	                                               "-",
  	                                               "\"",
  	                                               "`",
  	                                               "\'",
  	                                              }; 
  */  	                                              

  ///<summary>DictionaryWordReplace</summary>
  public static string[][] DictionaryWordReplace  = new string [][]
                                                  {  
  	                                               new string[] { "'", "''" },
  	                                               new string[] { "`", "" }
  	                                              }; 

  static  string   DirectorynameSource            = "..\\ProjectGutenberg";
  static  string   ExceptionMessage               = null;
  static  string   FileSearchPattern              = "ProjectGutenberg_-_Webster'sUnabridgedDictionary*.txt";

  ///<summary>The XPath for database connection string.</summary>  
  public const  string XPathDatabaseConnectionString               = @"/word/database/sqlServer/gutenberg/databaseConnectionString";  

  /// <summary>The XML configuration file.</summary>
  public static   string FilenameConfigurationXml  = @"WordEngineering.config";  

  const  string   HTMLTable                      = "<TABLE></TABLE>;";
  const  string   HTMLTableColumn                = "<TD>{0}</TD>;";
  const  string   HTMLTableRow                   = "<TR></TR>;";  
  
  const  string   ParagraphPage                  = "<page=";
  const  string   ParagraphPoint26               = "<point26>";
  const  string   ParagraphHW                    = "<hw>";
  const  string   SQLStatementDictionaryInsert   = "INSERT WebsterUnabridgedDictionary( DictionaryWord, Commentary ) VALUES ( '{0}', '{1}' );";
  const  string   SQLStatementDictionarySelect   = "SELECT DictionaryWord, Commentary FROM WebsterUnabridgedDictionary ( NOLOCK ) WHERE DictionaryWord LIKE '{0}';";  
  const  string   SQLStatementDictionaryTruncate = "TRUNCATE TABLE WebsterUnabridgedDictionary; DBCC CHECKIDENT (WebsterUnabridgedDictionary, RESEED, 1)";  
  
  
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
  	
   int                                indexEntryStart                               = -1;
   int                                indexEntryEnd                                 = -1;   
   int                                indexParagraphPage                            = -1;
   int                                indexPoint26                                  = -1;
   int                                indexWordEnd                                  = -1;   
  	
   string                             filenameDictionary                            = null;
   string                             dictionaryFile                                = null;
   string                             exceptionMessage                              = null;
   string                             indexEntry                                    = null;
   string                             indexWord                                     = null;
      
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
       sbDictionary.Append(line);
       //System.Console.WriteLine(line);
      }//while ((line = sr.ReadLine()) != null)
     }//using (StreamReader sr = new StreamReader("TestFile.txt")) 

     dictionaryFile = sbDictionary.ToString();
     indexPoint26   = dictionaryFile.IndexOf( ParagraphPoint26 );
     #if (DEBUG)
      System.Console.WriteLine("ParagraphPoint26: {0}", indexPoint26);
     #endif

     indexEntryStart = dictionaryFile.IndexOf( ParagraphHW, indexPoint26 );

     while ( indexEntryStart > 0 )
     {
      indexEntryEnd = dictionaryFile.IndexOf( ParagraphHW, indexEntryStart + 1 );

      if ( indexEntryEnd > 0 )
      {
       indexEntry = dictionaryFile.Substring( indexEntryStart, indexEntryEnd - indexEntryStart );
      }	
      else
      {
       indexEntry = dictionaryFile.Substring( indexEntryStart );
       indexParagraphPage = indexEntry.LastIndexOf( ParagraphPage );
       if ( indexParagraphPage >= 0 )
       {
       	indexEntry = indexEntry.Substring( indexEntry.Length - indexParagraphPage );
       }	
       break;
      }//if ( indexEntryEnd <= 0 )
      
      indexWordEnd = indexEntry.IndexOf( AnchorEndHW );
      if ( indexWordEnd < 0 ) 
      {
       indexEntryStart = indexEntryEnd;
       continue;
      }       
      indexWord    = indexEntry.Substring( IndexHWWordStart, indexWordEnd - IndexHWWordStart );
      for ( int indexReplace = 0; indexReplace < DictionaryWordReplace.Length; ++indexReplace )
      {
       indexWord = indexWord.Replace
       ( 
        DictionaryWordReplace[indexReplace][0],
        DictionaryWordReplace[indexReplace][1]
       ); 
       indexEntry = indexEntry.Replace
       ( 
        DictionaryWordReplace[indexReplace][0],
        DictionaryWordReplace[indexReplace][1]
       ); 
      }
      
      #if (DEBUG)
       System.Console.WriteLine
       (
        "Index Entry Start: {0} | End: {1} | Word: {2} | Entry: {3}", 
        indexEntryStart, 
        indexEntryEnd, 
        indexWord,
        indexEntry
       );
      #endif

      SQLStatement = new StringBuilder();
      SQLStatement.AppendFormat
      (
       SQLStatementDictionaryInsert,
       indexWord,
       indexEntry
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
  
      indexEntryStart = indexEntryEnd;

     }//while ( indexEntryStart > 0 )

    }//try
    catch (Exception e) 
    {
     System.Console.WriteLine( e.Message );
    }
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
   DataSet              dataSet              = null;
   HttpContext          httpContext          = HttpContext.Current;
   OleDbConnection      oleDbConnection      = null;
   StringBuilder        SQLStatement         = null;     
   
   sbResultElement                           = new StringBuilder();
   
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
    sbResultElement.Append("<TABLE align='center'>");    	
    foreach(DataRow dataRow in dataTable.Rows)
    {
     sbResultElement.Append("<TR>");
     /*
     foreach (DataColumn dataColumn in dataTable.Columns)
     {
      sbResultElement.AppendFormat
      (
       HTMLTableColumn, 
       dataRow[dataColumn] 
      );
     }//foreach (DataColumn dataColumn in dataTable.Columns) 
     */
     sbResultElement.AppendFormat
     (
      HTMLTableColumn, 
      dataRow["Commentary"] 
     );
     sbResultElement.Append("</TR>");
    }//foreach(DataRow dataRow in dataTable.Rows)
    sbResultElement.Append("</TABLE>");    	    
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

  static GutenbergWebsterUnabridgedDictionary()
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
  
 }//public class GutenbergWebsterUnabridgedDictionary.
}//namespace WordEngineering
