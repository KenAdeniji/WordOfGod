using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Security;
using System.Xml;
using System.Xml.Serialization;

namespace WordEngineering
{
 /// <summary>TheWordAlphabetSequence.</summary>
 public class TheWordAlphabetSequence
 {

  ///<summary>The argument filename import.</summary>
  public static int    ArgumentFilenameImport               = 0;

  ///<summary>The argument filename export.</summary>
  public static int    ArgumentFilenameExport               = 1;

  ///<summary>The argument scripture reference associates.</summary>
  public static int    ArgumentScriptureReferenceAssociates = 2;

  /// <summary>The database connection string.</summary>
  public static string DatabaseConnectionString             = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  ///<summary>The datarelation name alphabetsequence.</summary>
  public static string DataRelationNameAlphabetSequence     = "AlphabetSequence";

  ///<summary>The datarelation name child column.</summary>
  public static string DataRelationChildColumn              = "SequenceOrderId";

  ///<summary>The datarelation name parent column.</summary>
  public static string DataRelationParentColumn             = "TheWordId";

  ///<summary>The dataset name.</summary>
  public static string DataSetName                          = "wordOfGod";

  ///<summary>The datatable name.</summary>
  public static string DataTableNameAlphabetSequence        = "AlphabetSequence";

  ///<summary>The datatable name.</summary>
  public static string DataTableNameTheWord                 = "TheWord";

  /// <summary>The configuration XML filename.</summary>
  public static string filenameConfigurationXml                    = @"WordEngineering.config";

  /// <summary>The XPath database connection string.</summary>
  public const string   XPathDatabaseConnectionString                = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">Command-line parameters.</param>
  public static void Main
  (
   string[] argv
  )
  {
   int    argumentTotal                = argv.Length;

   string exceptionMessage             = null;
   string filenameImport               = null;
   string filenameExport               = null;
   string scriptureReferenceAssociates = null;

   if ( ArgumentFilenameImport < argumentTotal )
   {
    filenameImport = argv[ ArgumentFilenameImport ];
   }
   if ( ArgumentFilenameExport < argumentTotal )
   {
    filenameExport = argv[ ArgumentFilenameExport ];
   }
   if ( ArgumentScriptureReferenceAssociates < argumentTotal )
   {
    scriptureReferenceAssociates = argv[ ArgumentScriptureReferenceAssociates ];
   }
   #if (DEBUG)
    System.Console.WriteLine("Filename Import: {0}", filenameImport);
    System.Console.WriteLine("Filename Export: {0}", filenameExport);
   #endif

   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,         
         XPathDatabaseConnectionString,
     ref DatabaseConnectionString
   );

   #if (DEBUG)
    System.Console.WriteLine("Database Connection String: {0}", DatabaseConnectionString);
   #endif

   ImportExport
   ( 
    filenameImport, 
    filenameExport,
    scriptureReferenceAssociates 
   );
  }//public static void Main.

  ///<summary>ImportExport.</summary>
  ///<param name="filenameImport">The filename import.</param>
  ///<param name="filenameExport">The filename export.</param>
  ///<param name="scriptureReferenceAssociates">The alphabet sequence associates.</param>
  public static void ImportExport
  (
   string filenameImport,
   string filenameExport,
   string scriptureReferenceAssociates
  )
  {

   int[]                                 alphabetSequenceIndex              = null;
   int                                   dataRowIndex                       = -1;

   string exceptionMessage                                                  = null;
   string fileNameWithoutExtension                                          = null;
   string record                                                            = null;
   string[]                              word                               = null;

   System.Data.DataColumn                dataColumn                         = null;
   System.Data.DataColumn                dataColumnForeignKey               = null;
   System.Data.DataColumn                dataColumnPrimaryKey               = null;

   System.Data.DataRelation              dataRelation                       = null;
   System.Data.DataRow                   dataRow                            = null;
   System.Data.DataSet                   dataSet                            = null;

   System.Data.DataTable                 dataTableAlphabetSequence          = null;
   System.Data.DataTable                 dataTableTheWord                   = null;

   StreamReader                          streamReader                       = null;

   ScriptureReferenceAlphabetSequence[]  scriptureReferenceAlphabetSequence = null;

   StringBuilder                         sbTitle                            = null;

   sbTitle = new StringBuilder();

   try
   {
    if (!File.Exists(filenameImport))
    {
     System.Console.WriteLine("File not found: {0}", filenameImport); 
     return;
    }
    fileNameWithoutExtension = Path.GetFileNameWithoutExtension( filenameImport ); 
    dataSet = new DataSet();
    dataSet.DataSetName = TheWord.NodeRoot;
    // Create an instance of StreamReader to read from a file.
    // The using statement also closes the StreamReader.
     
    streamReader = new StreamReader(filenameImport); 

    // Create a new DataTable.
    dataTableTheWord = new DataTable(DataTableNameTheWord);

    dataColumn                =  new DataColumn();
    dataColumn.ColumnName     =  "SequenceOrderId";
    dataColumn.DataType       =  System.Type.GetType("System.Int32");
    dataColumn.DefaultValue   =  null;
    dataTableTheWord.Columns.Add( dataColumn );
    dataColumnPrimaryKey      = dataTableTheWord.Columns["SequenceOrderId"];

    dataColumn                = new DataColumn();
    dataColumn.ColumnName     = "Dated";
    dataColumn.DataType       = System.Type.GetType("System.DateTime");
    dataTableTheWord.Columns.Add( dataColumn );

    dataColumn                = new DataColumn();
    dataColumn.ColumnName     = "ScriptureReference";
    dataColumn.DataType       = System.Type.GetType("System.String");
    dataTableTheWord.Columns.Add( dataColumn );

    dataColumn                = new DataColumn();
    dataColumn.ColumnName     = "Title";
    dataColumn.DataType       = System.Type.GetType("System.String");
    dataTableTheWord.Columns.Add( dataColumn );

    dataSet.Tables.Add( dataTableTheWord );

    dataRow                   = dataTableTheWord.NewRow();
    dataRow["Dated"]          = System.DateTime.Today;

    dataTableTheWord.Rows.Add( dataRow );

    // Create a new DataTable.
    dataTableAlphabetSequence = new DataTable(DataTableNameAlphabetSequence);

    dataColumn = new DataColumn();
    dataColumn.ColumnName    = "TheWordId";
    dataColumn.DataType      = System.Type.GetType("System.Int32");
    dataColumn.DefaultValue  = null;
    dataTableAlphabetSequence.Columns.Add( dataColumn );
    dataColumnForeignKey     = dataTableAlphabetSequence.Columns["TheWordId"];

    dataColumn               = new DataColumn();
    dataColumn.ColumnName    = "SequenceOrderId";
    dataColumn.DataType      = System.Type.GetType("System.Int32");
    dataTableAlphabetSequence.Columns.Add( dataColumn );

    dataColumn               = new DataColumn();
    dataColumn.ColumnName    = "Word";
    dataColumn.DataType      = System.Type.GetType("System.String");
    dataTableAlphabetSequence.Columns.Add( dataColumn );

    dataColumn               = new DataColumn();
    dataColumn.ColumnName    = "AlphabetSequenceIndex";
    dataColumn.DataType      = System.Type.GetType("System.Int32");
    dataTableAlphabetSequence.Columns.Add( dataColumn );

    dataColumn               = new DataColumn();
    dataColumn.ColumnName    = "Commentary";
    dataColumn.DataType      = System.Type.GetType("System.String");
    dataColumn.DefaultValue  = null;
    dataTableAlphabetSequence.Columns.Add( dataColumn );

    dataColumn               = new DataColumn();
    dataColumn.ColumnName    = "ScriptureReference";
    dataColumn.DataType      = System.Type.GetType("System.String");
    dataTableAlphabetSequence.Columns.Add( dataColumn );

    dataSet.Tables.Add( dataTableAlphabetSequence );

    #if (DEBUG)   
     System.Console.WriteLine("Data Column Primary Key: {0}", dataColumnPrimaryKey);
     System.Console.WriteLine("Data Column Foreign Key: {0}", dataColumnForeignKey);
    #endif 
    
    dataRelation = new DataRelation
    (
      DataRelationNameAlphabetSequence, 
      dataColumnPrimaryKey,
      dataColumnForeignKey
    );

    dataRelation.Nested = true;
    dataSet.Relations.Add( dataRelation );

    // Read and display lines from the file until the end of 
    // the file is reached.
      
    while ( true ) 
    {
     record = streamReader.ReadLine();

     if ( record == null )
     {
      break;
     }

     dataRow = dataTableAlphabetSequence.NewRow();
     dataRow["Word"] = record;
     sbTitle.Append( record );
     sbTitle.Append( Environment.NewLine );
     dataTableAlphabetSequence.Rows.Add( dataRow );
    }//while ( true ) 

    alphabetSequenceIndex              = new int[dataTableAlphabetSequence.Rows.Count];
    scriptureReferenceAlphabetSequence = new ScriptureReferenceAlphabetSequence[dataTableAlphabetSequence.Rows.Count];
    word                               = new String[dataTableAlphabetSequence.Rows.Count];

    dataRowIndex = 0;
    foreach ( DataRow dataRowCurrent in dataTableAlphabetSequence.Rows )
    {
     word[dataRowIndex]                = ( string ) dataRowCurrent["Word"];
     System.Console.WriteLine( dataRowCurrent["Word"] );
     ++dataRowIndex;
    }//foreach ( DataRow dataRowCurrent in dataTableAlphabetSequence.Rows )

    UtilityDatabase.DataSetTableRowColumn
    (
     dataSet,
     "TheWord",
     0,
     "Title",
     sbTitle.ToString()
    );

    AlphabetSequence.AlphabetSequenceQuery
    (
     ref  DatabaseConnectionString,
     ref  exceptionMessage,
     ref  word,
          scriptureReferenceAssociates,
     ref  alphabetSequenceIndex,
     ref  scriptureReferenceAlphabetSequence
    );

    for ( dataRowIndex = 0; dataRowIndex < dataTableAlphabetSequence.Rows.Count; ++dataRowIndex )
    {

     UtilityDatabase.DataSetTableRowColumn
     (
      dataSet,
      DataTableNameAlphabetSequence,
      dataRowIndex,
      "AlphabetSequenceIndex",
      scriptureReferenceAlphabetSequence[ dataRowIndex ].AlphabetSequence
     );

     UtilityDatabase.DataSetTableRowColumn
     (
      dataSet,
      DataTableNameAlphabetSequence,
      dataRowIndex,
      "ScriptureReference",
      scriptureReferenceAlphabetSequence[ dataRowIndex ].ScriptureReferenceCurrent
     );

     UtilityDatabase.DataSetTableRowColumn
     (
      dataSet,
      DataTableNameAlphabetSequence,
      dataRowIndex,
      "SequenceOrderId",
      scriptureReferenceAlphabetSequence[ dataRowIndex ].SequenceOrderId
     );

    }//foreach ( DataRow dataRowCurrent in dataTableAlphabetSequence.Rows )

    ScriptureReference.ScriptureReferenceURI
    (
         TheWord.DatabaseConnectionString,
         TheWord.FilenameConfigurationXml,
     ref exceptionMessage,
     ref dataSet
    );//ScriptureReference.ScriptureReferenceURI

    UtilityXml.WriteXml
    (
         dataSet,
     ref exceptionMessage,
     ref filenameExport,
     ref TheWord.FilenameXslt
    );
   }//try
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: ", exception.Message);
   }//catch (Exception exception)
   finally
   {
   }//finally
  }//public static void ImportExport

  ///<summary>TheWordAlphabetSequence.</summary>
  public TheWordAlphabetSequence()
  {
  }

 }//public class TheWordAlphabetSequence.
}//namespace WordEngineering