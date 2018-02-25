using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Web;
using System.Reflection;
using System.Text;
using System.Xml;

namespace WordEngineering
{

 /// <summary>InternetDictionaryProjectIDPArgument</summary>
 public class InternetDictionaryProjectIDPArgument
 {

  ///<summary>tableTruncate</summary>
  public bool     tableTruncate           =  InternetDictionaryProjectIDP.TableTruncate;

  ///<summary>dataFile</summary>
  public String[] dataFile                =  null;

  ///<summary>englishWord</summary>
  public String[] englishWord             =  null;

  ///<summary>files</summary>
  [DefaultCommandLineArgument(CommandLineArgumentType.MultipleUnique)]
  public String[] files                   =  null;

  ///<summary>frenchCommentary</summary>
  public String[] frenchCommentary        =  null;

  ///<summary>germanCommentary</summary>
  public String[] germanCommentary        =  null;

  ///<summary>italianCommentary</summary>
  public String[] italianCommentary       =  null;

  ///<summary>latinCommentary</summary>
  public String[] latinCommentary         =  null;

  ///<summary>portugueseCommentary</summary>
  public String[] portugueseCommentary    =  null;

  ///<summary>spanishCommentary</summary>
  public String[] spanishCommentary       =  null;

  /// <summary>Constructor.</summary>
  public InternetDictionaryProjectIDPArgument():this
  (
   null, //InternetDictionaryProjectIDP.DataFile,
   null, //English
   null, //French
   null, //German
   null, //Italian
   null, //Latin
   null, //Portuguese
   null, //Spanish
   InternetDictionaryProjectIDP.TableTruncate
  )
  {
  }//public InternetDictionaryProjectIDPArgument()

  /// <summary>Constructor.</summary>
  public InternetDictionaryProjectIDPArgument
  (
   String englishWord,
   String frenchCommentary,
   String germanCommentary,
   String italianCommentary,
   String latinCommentary,
   String portugueseCommentary,
   String spanishCommentary
  ):this
  (
   null, //InternetDictionaryProjectIDP.DataFile,
   new String[] { englishWord },
   new String[] { frenchCommentary },
   new String[] { germanCommentary },
   new String[] { italianCommentary },
   new String[] { latinCommentary },
   new String[] { portugueseCommentary },
   new String[] { spanishCommentary },      
   InternetDictionaryProjectIDP.TableTruncate
  )
  {
  }//public InternetDictionaryProjectIDPArgument()

  /// <summary>Constructor.</summary>
  public InternetDictionaryProjectIDPArgument
  (
   String[]  dataFile,
   String[]  englishWord,
   String[]  frenchCommentary,
   String[]  germanCommentary,
   String[]  italianCommentary,
   String[]  latinCommentary,
   String[]  portugueseCommentary,
   String[]  spanishCommentary,
   bool      tableTruncate
  )
  {
   this.dataFile              =  dataFile;
   this.englishWord           =  englishWord;
   this.frenchCommentary      =  frenchCommentary;
   this.germanCommentary      =  germanCommentary;
   this.italianCommentary     =  italianCommentary;
   this.latinCommentary       =  latinCommentary;
   this.portugueseCommentary  =  portugueseCommentary;
   this.spanishCommentary     =  spanishCommentary;
   this.tableTruncate         =  tableTruncate;
  }//public InternetDictionaryProjectIDPArgument()

  ///<summary>Property.</summary>
  ///<value>DataFile.</value>
  public String[] DataFile
  {
   get 
   {
    return ( dataFile );
   }//get
   set 
   {
    dataFile = value;
   }
  }//DataFile

  ///<summary>Property.</summary>
  ///<value>EnglishWord.</value>
  public String[] EnglishWord
  {
   get 
   {
    return ( englishWord );
   }//get
   set 
   {
    englishWord = value;
   }//set
  }//EnglishWord

  ///<summary>Property.</summary>
  ///<value>FrenchCommentary.</value>
  public String[] FrenchCommentary
  {
   get 
   {
    return ( frenchCommentary );
   }//get
   set 
   {
    frenchCommentary = value;
   }//set
  }//FrenchCommentary

  ///<summary>Property.</summary>
  ///<value>GermanCommentary.</value>
  public String[] GermanCommentary
  {
   get 
   {
    return ( germanCommentary );
   }//get
   set 
   {
    germanCommentary = value;
   }//set
  }//GermanCommentary

  ///<summary>Property.</summary>
  ///<value>ItalianCommentary.</value>
  public String[] ItalianCommentary
  {
   get 
   {
    return ( italianCommentary );
   }//get
   set 
   {
    italianCommentary = value;
   }//set
  }//ItalianCommentary

  ///<summary>Property.</summary>
  ///<value>LatinCommentary.</value>
  public String[] LatinCommentary
  {
   get 
   {
    return ( latinCommentary );
   }//get
   set 
   {
    latinCommentary = value;
   }//set
  }//LatinCommentary

  ///<summary>Property.</summary>
  ///<value>PortugueseCommentary.</value>
  public String[] PortugueseCommentary
  {
   get 
   {
    return ( portugueseCommentary );
   }//get
   set 
   {
    portugueseCommentary = value;
   }//set
  }//PortugueseCommentary

  ///<summary>Property.</summary>
  ///<value>SpanishCommentary.</value>
  public String[] SpanishCommentary
  {
   get 
   {
    return ( spanishCommentary );
   }//get
   set 
   {
    spanishCommentary = value;
   }//set
  }//SpanishCommentary

  ///<summary>Property.</summary>
  ///<value>TableTruncate.</value>
  public bool TableTruncate
  {
   get 
   {
    return ( tableTruncate );
   }//get
   set 
   {
    tableTruncate = value;
   }//set
  }//TableTruncate
    
 }//public class InternetDictionaryProjectIDPArgument

 /// <summary>InternetDictionaryProjectIDP.</summary>
 /// <remarks>InternetDictionaryProjectIDP.</remarks>
 public class InternetDictionaryProjectIDP
 {

  ///<summary>TableTruncate.</summary>
  public static   bool     TableTruncate                           = false;

  ///<summary>The connection String database.</summary>
  public static   String   DatabaseConnectionString                = @"Provider=SQLOLEDB; Data Source=localhost; Integrated Security=SSPI; Initial Catalog=InternetDictionaryProjectIDP";

  ///<summary>The connection String database.</summary>
  public static   String   DataFile                                = @"D:\Software\InternetDictionaryProjectIDP\";

  /// <summary>DictionaryLanguage.</summary>
  public static   String[] DictionaryLanguage                      = new String []
                                                                   {
                                                                    "English",
                                                                    "French",
                                                                    "German",
                                                                    "Italian",
                                                                    "Latin",
                                                                    "Portuguese",
                                                                    "Spanish"
                                                                   };                                                                   	

  /// <summary>DictionaryLanguageSQLQuery.</summary>
  public static   String[] DictionaryLanguageSQLQuery             = new String []
                                                                   {
                                                                    "englishWord",
                                                                    "frenchCommentary",
                                                                    "germanCommentary",
                                                                    "italianCommentary",
                                                                    "latinCommentary",
                                                                    "portugueseCommentary",
                                                                    "spanishCommentary"
                                                                   };                                                                   	

  /// <summary>The XML configuration file.</summary>
  public static   String   FilenameConfigurationXml                = @"WordEngineering.config";

  ///<summary>The XPath for the database connection String.</summary>  
  public static   String   XPathDatabaseConnectionString           = @"/word/database/sqlServer/internetDictionaryProjectIDP/databaseConnectionString";

  ///<summary>The XPath for the DataFile.</summary>  
  public static   String   XPathDataFile                           = @"/word/database/sqlServer/internetDictionaryProjectIDP/dataFile";

  ///<summary>SQLStatementDictionaryFormat.</summary>
  public static   String   SQLStatementDictionaryFormat            = "englishWord: {0} | frenchCommentary: {1} | germanCommentary: {2} | italianCommentary: {3} | latinCommentary: {4} | portugueseCommentary: {5} | spanishCommentary: {6} ";

  ///<summary>SQLStatementDictionaryFrom.</summary>
  public static   String   SQLStatementDictionaryFrom              = " FROM EnglishDictionary ( NOLOCK ) ";

  ///<summary>SQLStatementDictionaryOrder.</summary>
  public static   String   SQLStatementDictionaryOrder             = " ORDER By englishWord ";

  ///<summary>SQLStatementDictionarySelect.</summary>
  public static   String   SQLStatementDictionarySelect            = "SELECT englishWord, frenchCommentary, germanCommentary, italianCommentary, latinCommentary, portugueseCommentary, spanishCommentary ";

  ///<summary>SQLStatementDictionaryUpdate.</summary>
  public static   String   SQLStatementDictionaryUpdate            = "IF NOT EXISTS ( SELECT {0} FROM {1} ( NOLOCK ) WHERE {0} = '{2}' ) BEGIN INSERT {1} ( {0}, {3} ) VALUES ( '{2}', '{4}' ) END; ELSE BEGIN UPDATE {1} SET {3} = '{4}' WHERE {0} = '{2}' END;";

  ///<summary>SQLStatementDictionaryWhere.</summary>
  public static   String   SQLStatementDictionaryWhere             = " Where ";

  ///<summary>SQLStatementDictionaryTruncate.</summary>
  public static   String   SQLStatementDictionaryTruncate          = "TRUNCATE TABLE {0}; DBCC CHECKIDENT ({0}, RESEED, 1);";

  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of arguments</param>
  public static void Main( String[] argv )
  {
   Boolean                         booleanParseCommandLineArguments   =  false;
   String                          exceptionMessage                   =  null;
   
   StringBuilder                   internetDictionaryProjectIDPSQL    =  null;
   StringBuilder                   internetDictionaryProjectIDPQuery  =  null;
   
   IDataReader                     iDataReader                        =  null; 

   InternetDictionaryProjectIDPArgument  internetDictionaryProjectIDPArgument    =  null;
   
   internetDictionaryProjectIDPArgument = new InternetDictionaryProjectIDPArgument();
   
   booleanParseCommandLineArguments =  UtilityParseCommandLineArgument.ParseCommandLineArguments
   ( 
    argv, 
    internetDictionaryProjectIDPArgument
   );
   
   if ( booleanParseCommandLineArguments  == false )
   {
    // error encountered in arguments. Display usage message
    UtilityDebug.Write
    (
     UtilityParseCommandLineArgument.CommandLineArgumentsUsage( typeof ( InternetDictionaryProjectIDPArgument ) )    
    );  
    return;
   }//if ( booleanParseCommandLineArguments  == false )
   
   if ( internetDictionaryProjectIDPArgument.DataFile != null && internetDictionaryProjectIDPArgument.DataFile.Length != 0 )
   {
    FileImport
    (
     ref DatabaseConnectionString,
     ref internetDictionaryProjectIDPArgument,
     ref exceptionMessage
    );
   }//if ( internetDictionaryProjectIDPArgument.DataFile != null && internetDictionaryProjectIDPArgument.DataFile != String.Empty )  

   Query
   (
    ref DatabaseConnectionString,
    ref exceptionMessage,
    ref internetDictionaryProjectIDPArgument,
    ref internetDictionaryProjectIDPSQL,
    ref internetDictionaryProjectIDPQuery,
    ref iDataReader
   );
   
  }//main()

  ///<summary>Stub.</summary>
  public static void FileImport
  (
   ref String                                databaseConnectionString,
   ref InternetDictionaryProjectIDPArgument  internetDictionaryProjectIDPArgument,
   ref String                                exceptionMessage
  )
  {

   bool[]           databaseTruncate                      = null;
   
   int              dataFileIndex                         = 0;

   int              dictionaryCommentaryIndex             = -1;
   int              dictionaryLanguageIndex               = -1;
   int              dictionaryLanguageIndexFirst          = -1;
   int              dictionaryLanguageIndexSecond         = -1;   

   int              dictionaryLanguageIndexPosition       = -1;   
   int              dictionaryLanguageIndexPositionFirst  = -1;
   int              dictionaryLanguageIndexPositionSecond = -1;

   String           databaseStatementUpdate               =  null;   
   String           databaseStatementTruncate             =  null;

   String           dictionaryWord                        =  null;
   String           dictionaryCommentary                  =  null;

   String           directoryNameRoot                     =  null;
   String           fileNameCurrent                       =  null;
   String           fileNamePattern                       =  null; 
   String           streamRecord                          =  null;
   
   ArrayList        arrayListDirectoryName                =  null;
   ArrayList        arrayListFileName                     =  null;

   OleDbConnection  oleDbConnection                       =  null;
   
   databaseTruncate = new bool[ DictionaryLanguage.Length ];
      
   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
   ( 
        databaseConnectionString,
    ref exceptionMessage 
   );

   try 
   {

    for ( dataFileIndex = 0; dataFileIndex < internetDictionaryProjectIDPArgument.dataFile.Length; ++dataFileIndex )
    {
     UtilityDirectory.Dir
     (
      ref internetDictionaryProjectIDPArgument.dataFile[dataFileIndex],
      ref directoryNameRoot,
      ref fileNamePattern,
      ref arrayListDirectoryName,
      ref arrayListFileName
     );

     foreach ( object fileNameObject in arrayListFileName )
     {
      fileNameCurrent = fileNameObject.ToString();
        	
      dictionaryLanguageIndexFirst          = -1;
      dictionaryLanguageIndexPositionFirst  = 0;
     
      dictionaryLanguageIndexSecond         = -1;
      dictionaryLanguageIndexPositionSecond = 0;
     
      for ( dictionaryLanguageIndex = 0; dictionaryLanguageIndex < DictionaryLanguage.Length; ++dictionaryLanguageIndex )
      {
       dictionaryLanguageIndexPosition = fileNameCurrent.IndexOf( DictionaryLanguage[dictionaryLanguageIndex] );
      
       if ( dictionaryLanguageIndexPosition < 0 )
       {
        continue;
       }//if ( dictionaryLanguageIndexPosition < 0 )
       else if ( dictionaryLanguageIndexFirst <= -1 )
       {
        dictionaryLanguageIndexPositionFirst  = dictionaryLanguageIndexPosition;
        dictionaryLanguageIndexFirst          = dictionaryLanguageIndex;
       }//else if ( dictionaryLanguageIndexFirst <= -1 )
       else if ( dictionaryLanguageIndexPosition < dictionaryLanguageIndexPositionFirst )
       {
        dictionaryLanguageIndexPositionSecond = dictionaryLanguageIndexPositionFirst;
        dictionaryLanguageIndexPositionFirst  = dictionaryLanguageIndexPosition;
        
        dictionaryLanguageIndexSecond         = dictionaryLanguageIndexFirst;
        dictionaryLanguageIndexFirst          = dictionaryLanguageIndex;
       }//else if ( dictionaryLanguageIndexPositionFirst < 0 )
       else
       {
        dictionaryLanguageIndexPositionSecond = dictionaryLanguageIndexPosition;
        dictionaryLanguageIndexSecond         = dictionaryLanguageIndex;
       }//else      	
      }//for ( dictionaryLanguageIndex = 0; dictionaryLanguageIndex <= DictionaryLanguage.Length; ++dictionaryLanguageIndex )

      /*
      UtilityDebug.Write
      (
       String.Format
       (
        "Language First: {0} | Second: {1} | First Position: {2} | Second Position: {3}",
        DictionaryLanguage[dictionaryLanguageIndexFirst],
        DictionaryLanguage[dictionaryLanguageIndexSecond],
        dictionaryLanguageIndexPositionFirst,
        dictionaryLanguageIndexPositionSecond
       )
      );
      */

      if ( internetDictionaryProjectIDPArgument.TableTruncate && databaseTruncate[ dictionaryLanguageIndexFirst] == false )
      {
       databaseTruncate[ dictionaryLanguageIndexFirst] = true;
       	
       databaseStatementTruncate = String.Format
       (
        SQLStatementDictionaryTruncate,
        DictionaryLanguage[dictionaryLanguageIndexFirst] + "Dictionary"
       ); 

       UtilityDebug.Write( databaseStatementTruncate );

       UtilityDatabase.DatabaseNonQuery
       (
            oleDbConnection,
        ref exceptionMessage,
            databaseStatementTruncate
       );
       
      };//if ( internetDictionaryProjectIDPArgument.TableTruncate ) 

      // Create an instance of StreamReader to read from a file.
      // The using statement also closes the StreamReader.
      using (StreamReader streamReader = new StreamReader(fileNameCurrent))
      {
       while ( true )
       {
        //Read and display lines from the file until the end of the file is reached.
        streamRecord = streamReader.ReadLine();
       
        if ( streamRecord == null )
        {
       	 break;
        }//if ( streamRecord == null )
       
        UtilityDebug.Write
        (
         String.Format
         (
          "streamRecord: {0}",
          streamRecord
         )
        );
       
        if ( streamRecord[0] == '#' )
        {
       	 continue;
        }//if ( streamRecord[0] == '#' )
       
        dictionaryCommentaryIndex = streamRecord.IndexOf('\t');
       
        if ( dictionaryCommentaryIndex <= -1 )
        {
       	 continue;
        }//if ( dictionaryCommentaryIndex <= -1 )
       
        dictionaryWord       = streamRecord.Substring(0, dictionaryCommentaryIndex);
        dictionaryCommentary = (streamRecord.Substring(dictionaryCommentaryIndex)).Trim();

        databaseStatementUpdate = String.Format
        (
         SQLStatementDictionaryUpdate,
         DictionaryLanguage[dictionaryLanguageIndexFirst] + "Word",
         DictionaryLanguage[dictionaryLanguageIndexFirst] + "Dictionary",
         dictionaryWord,
         DictionaryLanguage[dictionaryLanguageIndexSecond] + "Commentary",
         dictionaryCommentary
        ); 

        UtilityDebug.Write( databaseStatementUpdate );

        UtilityDatabase.DatabaseNonQuery
        ( 
             oleDbConnection,
         ref exceptionMessage,
             databaseStatementUpdate
        );

       }//while ( true )
      }//using (StreamReader streamReader = new StreamReader(fileNameCurrent))
     }//foreach ( object fileNameCurrent in arrayListFileName )
    }//for ( dataFileIndex = 0; dataFileIndex < internetDictionaryProjectIDPArgument.dataFile.Length; ++dataFileIndex )
   }//try
   catch ( Exception exception )
   {
    UtilityDebug.Write
    (
     String.Format
     (
      "Exception: {0}",
      exception.Message
     )
    );
   }//catch ( Exception exception )   	
    
   UtilityDatabase.DatabaseConnectionHouseKeeping
   (
        oleDbConnection,
    ref exceptionMessage
   );

  }//public static void FileImport()

  /// <summary>Query.</summary>
  public static void Query
  (
   ref String                                   databaseConnectionString,
   ref String                                   exceptionMessage,
   ref InternetDictionaryProjectIDPArgument     internetDictionaryProjectIDPArgument,
   ref StringBuilder                            internetDictionaryProjectIDPSQL,
   ref StringBuilder                            internetDictionaryProjectIDPQuery,
   ref IDataReader                              iDataReader
  )
  {

   String  internetDictionaryProjectIDPResult        =  null;
   Type    typeInternetDictionaryProjectIDPArgument  =  internetDictionaryProjectIDPArgument.GetType();

   UtilityProperty.TypeInformation
   (
        internetDictionaryProjectIDPArgument,
    ref typeInternetDictionaryProjectIDPArgument,
    ref internetDictionaryProjectIDPQuery,
    ref DictionaryLanguageSQLQuery
   );
      
   internetDictionaryProjectIDPSQL = new StringBuilder( SQLStatementDictionarySelect );

   internetDictionaryProjectIDPSQL.Append( SQLStatementDictionaryFrom );   
   
   if ( internetDictionaryProjectIDPQuery != null )
   {
    internetDictionaryProjectIDPSQL.Append( SQLStatementDictionaryWhere );
    internetDictionaryProjectIDPSQL.Append( internetDictionaryProjectIDPQuery );
   }//if ( internetDictionaryProjectIDPQuery != null ) 

   internetDictionaryProjectIDPSQL.Append( SQLStatementDictionaryOrder );
   
   UtilityDebug.Write( internetDictionaryProjectIDPSQL );
      
   try
   {
    UtilityDatabase.DatabaseQuery
    ( 
          databaseConnectionString, 
      ref exceptionMessage, 
      ref iDataReader,
          internetDictionaryProjectIDPSQL.ToString(), 
          CommandType.Text
    );

    #if (DEBUG)
    while( iDataReader.Read() )
    {
      
      internetDictionaryProjectIDPResult = String.Format
      (
       SQLStatementDictionaryFormat,
       iDataReader.GetValue(0),
       iDataReader.GetValue(1),      
       iDataReader.GetValue(2),
       iDataReader.GetValue(3),
       iDataReader.GetValue(4),      
       iDataReader.GetValue(5),
       iDataReader.GetValue(6)       
      );
      
      UtilityDebug.Write( internetDictionaryProjectIDPResult );
      
     }//while( iDataReader.Read() ) 
    #endif

   }//try
   catch (Exception exception)
   {
   	System.Console.WriteLine("Exception: {0}", exception.Message);
   }//catch (Exception exception)   	
  }//public static void Query() 

  /// <summary>Read the XML Configuration file.</summary>
  public static void ConfigurationXml()
  {  
   String  exceptionMessage  =  null;
   
   ConfigurationXml
   (
    ref FilenameConfigurationXml,
    ref exceptionMessage,
    ref DatabaseConnectionString,
    ref DataFile
   );
  }//public static void ConfigurationXml()

  /// <summary>Read the XML Configuration file.</summary>
  public static void ConfigurationXml
  (
   ref String filenameConfigurationXml,
   ref String exceptionMessage,
   ref String databaseConnectionString,
   ref String dataFile
  )
  {
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,
         XPathDatabaseConnectionString,
     ref databaseConnectionString
    );//ConfigurationXml()
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,
         XPathDataFile,
     ref dataFile
    );//ConfigurationXml()
  }//ConfigurationXml	 

  static InternetDictionaryProjectIDP()
  {
   ConfigurationXml();
  }//static()
  
 }//public class InternetDictionaryProjectIDP.
}//namespace WordEngineering
