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

 /// <summary>AccountChartArgument</summary>
 public class AccountChartArgument
 {

  ///<summary>dataFile</summary>
  public String[] dataFile                =  null;

  ///<summary>files</summary>
  [DefaultCommandLineArgument(CommandLineArgumentType.MultipleUnique)]
  public String[] files                    =  null;

  ///<summary>tableTruncate</summary>
  public bool     tableTruncate            =  AccountChart.TableTruncate;

  ///<summary>accountTitle</summary>
  public String[] accountTitle             =  null;

  ///<summary>accountNumber</summary>
  public int[]    accountNumber            =  null;

  ///<summary>normalBalance</summary>
  public String[] normalBalance            =  null;

  ///<summary>definition</summary>
  public String[] definition               =  null;

  /// <summary>Constructor.</summary>
  public AccountChartArgument():this
  (
   null, //AccountChart.DataFile,
   null, //files
   AccountChart.TableTruncate,
   null, //accountTitle
   null, //accountNumber
   null, //normalBalance
   null  //definition
  )
  {
  }//public AccountChartArgument()

  /// <summary>Constructor.</summary>
  public AccountChartArgument
  (
   String[]  accountTitle,
   int[]     accountNumber,
   String[]  normalBalance,
   String[]  definition   
  ):this
  (
   null, //AccountChart.DataFile,
   null, //files
   AccountChart.TableTruncate,
   accountTitle,
   accountNumber,
   normalBalance,
   definition
  )
  {
  }//public AccountChartArgument()

  /// <summary>Constructor.</summary>
  public AccountChartArgument
  (
   String[]  dataFile,
   String[]  files,
   bool      tableTruncate,
   String[]  accountTitle,
   int[]     accountNumber,
   String[]  normalBalance,
   String[]  definition   
  )
  {
   this.dataFile              =  dataFile;
   this.files                 =  files;
   this.tableTruncate         =  tableTruncate;
   this.accountTitle          =  accountTitle;
   this.accountNumber         =  accountNumber;
   this.normalBalance         =  normalBalance;
   this.definition            =  definition;   
  }//public AccountChartArgument()

  ///<summary>Property.</summary>
  ///<value>AccountNumber.</value>
  public int[] AccountNumber
  {
   get 
   {
    return ( accountNumber );
   }//get
   set 
   {
    accountNumber = value;
   }//set
  }//AccountNumber

  ///<summary>Property.</summary>
  ///<value>AccountTitle.</value>
  public String[] AccountTitle
  {
   get 
   {
    return ( accountTitle );
   }//get
   set 
   {
    accountTitle = value;
   }//set
  }//AccountTitle

  ///<summary>Property.</summary>
  ///<value>Definition.</value>
  public String[] Definition
  {
   get 
   {
    return ( definition );
   }//get
   set 
   {
    definition = value;
   }//set
  }//Definition

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
  ///<value>NormalBalance.</value>
  public String[] NormalBalance
  {
   get 
   {
    return ( normalBalance );
   }//get
   set 
   {
    normalBalance = value;
   }//set
  }//NormalBalance

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
    
 }//public class AccountChartArgument

 /// <summary>AccountChart.</summary>
 /// <remarks>AccountChart.</remarks>
 public class AccountChart
 {

  ///<summary>TableTruncate.</summary>
  public static   bool       TableTruncate                           = false;

  ///<summary>SQLStatementAttributeIndexAccountTitle.</summary>
  public static   int        SQLStatementAttributeIndexAccountTitle   = 0;

  ///<summary>SQLStatementAttributeIndexAccountNumber.</summary>
  public static   int        SQLStatementAttributeIndexAccountNumber  = 1;

  ///<summary>SQLStatementAttributeIndexNormalBalance.</summary>
  public static   int        SQLStatementAttributeIndexNormalBalance  = 2;

  ///<summary>SQLStatementAttributeIndexDefinition.</summary>
  public static   int        SQLStatementAttributeIndexDefinition     = 3;

  ///<summary>SQLStatementAttributeRankName.</summary>
  public static   int        SQLStatementAttributeRankName           = 0;

  ///<summary>SQLStatementAttributeRankAlias.</summary>
  public static   int        SQLStatementAttributeRankAlias          = 1;

  ///<summary>The connection String database.</summary>
  public static   String     DatabaseConnectionString                = @"Provider=SQLOLEDB; Data Source=localhost; Integrated Security=SSPI; Initial Catalog=Account";

  ///<summary>The connection String database.</summary>
  public static   String     DataFile                                = @"..\Documentation\FinancialManagementServiceTreasurywww.FMS.Treasury.Gov\FinancialManagementServiceUSTreasurywww.FMS.Treasury.Gov_-_USGovernmentStandardGeneralLedgerSection2AccountDefinition.txt";

  /// <summary>The XML configuration file.</summary>
  public static   String     FilenameConfigurationXml                = @"WordEngineering.config";

  ///<summary>The XPath for the database connection String.</summary>  
  public static   String     XPathDatabaseConnectionString           = @"/word/database/sqlServer/account/databaseConnectionString";

  ///<summary>The XPath for the DataFile.</summary>  
  public static   String     XPathDataFile                           = @"/word/account/accountChart/dataFile";

  ///<summary>SQLStatementFormat.</summary>
  public static   String     SQLStatementFormat                      = "AccountTitle: {0} | AccountNumber {1} | NormalBalance {2} | Definition {3}";

  ///<summary>SQLStatementFrom.</summary>
  public static   String     SQLStatementFrom                        = " FROM English ( NOLOCK ) ";

  ///<summary>SQLStatementOrder.</summary>
  public static   String     SQLStatementOrder                       = " ORDER By accountTitle ";

  ///<summary>SQLStatementSelect.</summary>
  public static   String     SQLStatementSelect                      = "SELECT AccountTitle, AccountNumber, NormalBalance, Definition ";

  ///<summary>SQLStatementUpdate.</summary>
  public static   String     SQLStatementUpdate                      = "IF NOT EXISTS ( SELECT {3} FROM {0} ( NOLOCK ) WHERE {3} = {1} ) BEGIN INSERT {0} ( {2}, {3}, {4}, {5} ) VALUES ( '{6}', {1}, '{7}', '{8}' ) END; ELSE BEGIN UPDATE {0} SET {2} = '{6}', {4} = '{7}', {5} = '{8}' WHERE {3} = {1} END;";

  ///<summary>SQLStatementClass.</summary>
  public static   String     SQLStatementClass                       = "AccountChart";

  /// <summary>SQLStatementAttribute.</summary>
  public static   String[][] SQLStatementAttribute                   = new String [][]
                                                                     {
                                                                      new String[] { "Account Title",  "AccountTitle" },
                                                                      new String[] { "Account Number", "AccountNumber" },
                                                                      new String[] { "Normal Balance", "NormalBalance" },
                                                                      new String[] { "Definition",     "Commentary" }
                                                                     };                                                                   	

  ///<summary>SQLStatementTruncate.</summary>
  public static   String   SQLStatementTruncate                    = "TRUNCATE TABLE {0}; DBCC CHECKIDENT ({0}, RESEED, 1);";

  ///<summary>SQLStatementWhere.</summary>
  public static   String   SQLStatementWhere                       = " Where ";

  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of arguments</param>
  public static void Main( String[] argv )
  {
   Boolean                         booleanParseCommandLineArguments   =  false;
   String                          exceptionMessage                   =  null;
   
   StringBuilder                   internetDictionaryProjectIDPSQL    =  null;
   StringBuilder                   internetDictionaryProjectIDPQuery  =  null;
   
   IDataReader                     iDataReader                        =  null; 

   AccountChartArgument  accountChartArgument    =  null;
   
   accountChartArgument = new AccountChartArgument();
   
   booleanParseCommandLineArguments =  UtilityParseCommandLineArgument.ParseCommandLineArguments
   ( 
    argv, 
    accountChartArgument
   );
   
   if ( booleanParseCommandLineArguments  == false )
   {
    // error encountered in arguments. Display usage message
    UtilityDebug.Write
    (
     UtilityParseCommandLineArgument.CommandLineArgumentsUsage( typeof ( AccountChartArgument ) )    
    );  
    return;
   }//if ( booleanParseCommandLineArguments  == false )
   
   if ( accountChartArgument.DataFile != null && accountChartArgument.DataFile.Length != 0 )
   {
    FileImport
    (
     ref DatabaseConnectionString,
     ref accountChartArgument,
     ref exceptionMessage
    );
   }//if ( accountChartArgument.DataFile != null && accountChartArgument.DataFile != String.Empty )  
   
   /*
   Query
   (
    ref DatabaseConnectionString,
    ref exceptionMessage,
    ref accountChartArgument,
    ref internetDictionaryProjectIDPSQL,
    ref internetDictionaryProjectIDPQuery,
    ref iDataReader
   );
   */
   
  }//main()

  ///<summary>Stub.</summary>
  public static void FileImport
  (
   ref String                databaseConnectionString,
   ref AccountChartArgument  accountChartArgument,
   ref String                exceptionMessage
  )
  {

   int              dataFileIndex                         =  0;
   int              sQLStatementAttributeIndex            =  -1;
   int              sQLStatementAttributeIndexCurrent     =  -1;
   int              streamRecordIndex                     =  0;

   String           databaseStatementUpdate               =  null;   
   String           databaseStatementTruncate             =  null;

   String           directoryNameRoot                     =  null;
   String           fileNameCurrent                       =  null;
   String           fileNamePattern                       =  null; 
   String           streamColumn                          =  null;
   String           streamRecord                          =  null;


   StringBuilder[]  stringBuilderStreamColumn             =  null;
   
   ArrayList        arrayListDirectoryName                =  null;
   ArrayList        arrayListFileName                     =  null;

   OleDbConnection  oleDbConnection                       =  null;
   
   stringBuilderStreamColumn = new StringBuilder[ SQLStatementAttribute.Length ];

   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
   ( 
        databaseConnectionString,
    ref exceptionMessage 
   );

   if ( accountChartArgument.TableTruncate )
   {
    databaseStatementTruncate = String.Format
    (
     SQLStatementTruncate,
     SQLStatementClass
    ); 

    UtilityDebug.Write( databaseStatementTruncate );

    UtilityDatabase.DatabaseNonQuery
    (
         oleDbConnection,
     ref exceptionMessage,
         databaseStatementTruncate
    );
   }//if ( accountChartArgument.TableTruncate )

   try 
   {

    for ( dataFileIndex = 0; dataFileIndex < accountChartArgument.dataFile.Length; ++dataFileIndex )
    {
     UtilityDirectory.Dir
     (
      ref accountChartArgument.dataFile[dataFileIndex],
      ref directoryNameRoot,
      ref fileNamePattern,
      ref arrayListDirectoryName,
      ref arrayListFileName
     );

     UtilityDebug.Write
     (
      String.Format
      (
       "accountChartArgument.dataFile[{0}]: {1}",
       dataFileIndex,
       accountChartArgument.dataFile[dataFileIndex]
      )
     );

     foreach ( object fileNameObject in arrayListFileName )
     {
      fileNameCurrent = fileNameObject.ToString();

      UtilityDebug.Write
      (
       String.Format
       (
        "fileNameCurrent: {0}",
        fileNameCurrent
       )
      );
        	
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

        /*
        UtilityDebug.Write
        (
         String.Format
         (
          "streamRecord: {0}",
          streamRecord
         )
        );
        */
       
        for 
        ( 
         sQLStatementAttributeIndex  = 0; 
         sQLStatementAttributeIndex  < SQLStatementAttribute.Length;
         ++sQLStatementAttributeIndex
        )
        {
         streamRecordIndex = streamRecord.IndexOf
         ( 
          SQLStatementAttribute[ sQLStatementAttributeIndex ][ SQLStatementAttributeRankName ] 
         );

         if ( streamRecordIndex == 0 )
         {
          sQLStatementAttributeIndexCurrent = sQLStatementAttributeIndex;
          break;
         }//if ( streamRecordIndex == 0 )
         
        }//for

        if ( sQLStatementAttributeIndexCurrent == -1 )
        {
         continue;
        }//if ( sQLStatementAttributeIndexCurrent == -1 )

        streamRecord = streamRecord.Trim();

        streamRecord = streamRecord.Replace("'", "''");

        if ( sQLStatementAttributeIndex < SQLStatementAttribute.Length )
        {
         streamColumn = streamRecord.Substring( SQLStatementAttribute[ sQLStatementAttributeIndexCurrent ][ SQLStatementAttributeRankName ].Length + 1 );
         streamColumn = streamColumn.Trim();
         stringBuilderStreamColumn[ sQLStatementAttributeIndexCurrent ] = new StringBuilder( streamColumn );
        }
        else
        {
         streamColumn = streamRecord.Trim();
         stringBuilderStreamColumn[ sQLStatementAttributeIndexCurrent ].Append( streamColumn );
        }

        /*
        UtilityDebug.Write
        (
         String.Format
         (
          "Name: {0} | Value: {1}",
          SQLStatementAttribute[ sQLStatementAttributeIndexCurrent ][ SQLStatementAttributeRankName ],
          stringBuilderStreamColumn[ sQLStatementAttributeIndexCurrent ]
         )
        );
        */  

        if ( sQLStatementAttributeIndexCurrent != SQLStatementAttribute.Length - 1 )
        {
       	 continue;
        }//if ( sQLStatementAttributeIndexCurrent < SQLStatementAttribute.Length - 1 )
       
        databaseStatementUpdate = String.Format
        (
         SQLStatementUpdate,
         SQLStatementClass,
         stringBuilderStreamColumn[SQLStatementAttributeIndexAccountNumber],
         SQLStatementAttribute[SQLStatementAttributeIndexAccountTitle][SQLStatementAttributeRankAlias],
         SQLStatementAttribute[SQLStatementAttributeIndexAccountNumber][SQLStatementAttributeRankAlias],
         SQLStatementAttribute[SQLStatementAttributeIndexNormalBalance][SQLStatementAttributeRankAlias],
         SQLStatementAttribute[SQLStatementAttributeIndexDefinition][SQLStatementAttributeRankAlias],
         stringBuilderStreamColumn[SQLStatementAttributeIndexAccountTitle],
         stringBuilderStreamColumn[SQLStatementAttributeIndexNormalBalance],
         stringBuilderStreamColumn[SQLStatementAttributeIndexDefinition]
        ); 

        /*
        UtilityDebug.Write( databaseStatementUpdate );
        */

        UtilityDatabase.DatabaseNonQuery
        ( 
             oleDbConnection,
         ref exceptionMessage,
             databaseStatementUpdate
        );

        if ( exceptionMessage != null )
        {
         UtilityDebug.Write
         (
          String.Format
          (
           "databaseStatementUpdate: {0}",
           databaseStatementUpdate
          )
         );
        }

       }//while ( true )
      }//using (StreamReader streamReader = new StreamReader(fileNameCurrent))
     }//foreach ( object fileNameCurrent in arrayListFileName )
    }//for ( dataFileIndex = 0; dataFileIndex < accountChartArgument.dataFile.Length; ++dataFileIndex )
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

  static AccountChart()
  {
   ConfigurationXml();
  }//static()
  
 }//public class AccountChart.
}//namespace WordEngineering
