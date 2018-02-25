using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Security;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace WordEngineering
{
 /// <summary>TheWord.</summary>
 [Serializable]
 [XmlRoot("TheWord", IsNullable = false)] 
 public class TheWord
 {

  /// <summary>The delimiter in character array format for the split String.</summary>
  public static char[]  DelimiterSplitChar                          = null;

  /// <summary>The XML document.</summary>
  public static int      ArgumentFilenameXml                         = 0;

  /// <summary>The unique staticraint rank primary key.</summary>
  public static int      UniquestaticraintRankPrimaryKey              = 0;

  /// <summary>The unique staticraint rank identity.</summary>
  public static int      UniquestaticraintRankIdentity                = 1;

  /// <summary>The class name.</summary>
  public static String   ClassNameAlias                               = "TheWord";

  /// <summary>The database connection String.</summary>
  public static String   DatabaseConnectionString                    = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The delimiter split String.</summary>
  public static  String  DelimiterSplitString                          = "|";

  /// <summary>The configuration XML filename.</summary>
  public static String   FilenameConfigurationXml                    = @"WordEngineering.config";

  /// <summary>The filename HTML.</summary>
  public static String   FilenameHtml                                = ClassNameAlias + @".html";    

  /// <summary>The filename XML.</summary>
  public static String   FilenameXml                                 = ClassNameAlias + @".xml";

  /// <summary>The filename XSD.</summary>
  public static String   FilenameXsd                                 = ClassNameAlias + @".xsd";    

  /// <summary>The filename XSL.</summary>
  public static String   FilenameXsl                                 = ClassNameAlias + @".xsl";

  /// <summary>The filename XSLT.</summary>
  public static String   FilenameXslt                                = ClassNameAlias + @".xslt";

  /// <summary>The root node.</summary>
  public static String   NodeRoot                                    = @"wordOfGod";

  /// <summary>The XPath Column Name Dated.</summary>
  public static  String  XPathColumnDated                            = @"/word/database/column/datetime";

  /// <summary>The XPath Column Name Filename.</summary>
  public static  String  XPathColumnFilename                         = @"/word/database/column/filename";

  /// <summary>The XPath Column Name Foreign.</summary>
  public static  String  XPathColumnForeign                          = @"/word/database/column/foreign";

  /// <summary>The XPath Column Name Identity.</summary>
  public static  String  XPathColumnIdentity                         = @"/word/database/column/identity";

  /// <summary>The XPath Column Name Primary.</summary>
  public static  String  XPathColumnPrimary                          = @"/word/database/column/primary";

  /// <summary>The XPath database connection String.</summary>
  public static String   XPathDatabaseConnectionString               = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";

  /// <summary>The XPath filename HTML.</summary>
  public static String  XPathFilenameHtml                            = @"/word/theWord/filenameHtml";    

  /// <summary>The XPath filename XML.</summary>
  public static String  XPathFilenameXml                             = @"/word/theWord/filenameXml";

  /// <summary>The XPath filename XSD.</summary>
  public static String  XPathFilenameXsd                             = @"/word/theWord/filenameXsd";    

  /// <summary>The XPath filename XSL.</summary>
  public static String  XPathFilenameXsl                             = @"/word/theWord/filenameXsl";

  /// <summary>The XPath filename XSLT.</summary>
  public static String  XPathFilenameXslt                            = @"/word/theWord/filenameXslt";

  /// <summary>The XPath node root.</summary>
  public static String  XPathNodeRoot                                = @"/word/theWord/nodeRoot";

  /// <summary>The XPath source SQL.</summary>
  public static  String  XPathSourceSQL                              = @"/word/theWord/sourceSQL";
  
  /// <summary>The sequence order Id.</summary>
  [XmlElement(DataType = "int", ElementName = "sequenceOrderId")]  
  public       int      sequenceOrderId                              = -1;

  /// <summary>Keyword.</summary>
  [XmlElement(ElementName = "keyword", IsNullable = false)]  
  private      String   keyword                                      = null;

  /// <summary>Scripture Reference.</summary>
  [XmlElement(ElementName = "scriptureReference", IsNullable = false)]  
  private      String   scriptureReference                           = null;

  /// <summary>Title.</summary>
  [XmlElement(ElementName = "title", IsNullable = false)]
  private      String   title                                        = null;

  /// <summary>Dated.</summary>
  [XmlElement(ElementName = "dated", IsNullable = false)]  
  private      DateTime dated                                        = System.DateTime.Today;

  /// <summary>DataSet TheWord.</summary>
  public       DataSet  dataSetTheWord                               = null;

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">Command-line parameters.</param>
  public static void Main
  (
   String[] argv
  )
  {
   TheWord  theWordCurrent;
   
   theWordCurrent = new TheWord();
   
   theWordCurrent.ProcessFile
   (
    argv
   ); 	
  }
  
  ///<summary>Process file.</summary>
  ///<param name="argv">Command-line parameters.</param>
  public void ProcessFile
  (
   String[] argv
  )
  { 
   int          argumentTotal             = argv.Length;
   String       databaseConnectionString  = DatabaseConnectionString;
   String       exceptionMessage          = null;
   String       filenameXml               = null;
   String[]     sourceSQL                 = null;
   String[]     sourceName                = null;
   DateTime     dated                     = System.DateTime.Today;
   XmlNodeList  sourceXML                 = null;

   dataSetTheWord = new DataSet();
   //dataSet.DataSetName = NodeRoot;

   UtilityXml.XmlDocumentNodeInnerText
   (
         FilenameConfigurationXml,
     ref exceptionMessage,         
         XPathDatabaseConnectionString,
     ref databaseConnectionString
   );

   #if (DEBUG)
    System.Console.WriteLine("Database Connection String: {0}", databaseConnectionString);
   #endif

   UtilityXml.XmlDocumentNodeInnerText
   (
         FilenameConfigurationXml,
     ref exceptionMessage,         
         XPathFilenameHtml,
     ref FilenameHtml
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
         FilenameConfigurationXml,
     ref exceptionMessage,         
         XPathFilenameXml,
     ref FilenameXml
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
         FilenameConfigurationXml,
     ref exceptionMessage,         
         XPathFilenameXsd,
     ref FilenameXsd
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
         FilenameConfigurationXml,
     ref exceptionMessage,         
         XPathFilenameXsl,
     ref FilenameXsl
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
         FilenameConfigurationXml,
     ref exceptionMessage,         
         XPathFilenameXslt,
     ref FilenameXslt
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
         FilenameConfigurationXml,
     ref exceptionMessage,         
         XPathNodeRoot,
     ref NodeRoot
   );
   
   SourceSQLQuery
   (
        FilenameConfigurationXml,
    ref exceptionMessage,
    ref sourceXML,
    ref sourceSQL,
    ref sourceName
   );
   
   if ( exceptionMessage != null ) { return; }

   filenameXml = FilenameXml;
   if ( argumentTotal > ArgumentFilenameXml )
   {
   	filenameXml = argv[ArgumentFilenameXml];
   }   	

   FileOpen
   (
        databaseConnectionString,
    ref exceptionMessage,
    ref filenameXml
   );

   TheWordDataSet
   (
         databaseConnectionString,
         FilenameConfigurationXml,         
     ref exceptionMessage,
     ref filenameXml,
     ref FilenameXslt     
   );

   /*
   FileSave
   (
         databaseConnectionString,
     ref exceptionMessage,
     ref dataSet,     
     ref filenameXml,
     ref FilenameXslt
   );
   */
   
  }//public static void Main
  
  /// <summary>constructor.</summary>
  public TheWord()
  {
  }

  /// <summary>constructor.</summary>
  /// <param name="dated">Dated.</param>  
  /// <param name="sequenceOrderId">The sequence order Id.</param>
  /// <param name="keyword">The keyword.</param>    
  /// <param name="scriptureReference">The scripture reference.</param>  
  /// <param name="title">The title.</param>    
  public TheWord
  (
   DateTime dated,
   int      sequenceOrderId,
   String   keyword,
   String   scriptureReference,
   String   title
  ) 
  {
   this.dated              = dated;
   this.sequenceOrderId    = sequenceOrderId;
   this.keyword            = keyword;   
   this.scriptureReference = scriptureReference;
   this.title              = title;
  }//TheWord()

  ///<summary>DataSetTheWord property.</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public DataSet DataSetTheWord
  {
   get 
   {
    return ( dataSetTheWord );
   }//get
  }//public DataSet DataSetTheWord.
 
  ///<summary>Dated property.</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public DateTime Dated
  {
   get 
   {
    return (dated);
   }//get
  }//public DateTime Dated

  ///<summary>Keyword property.</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public String Keyword
  {
   get 
   {
    return ( keyword );
   }//get
  }//public String Keyword

  /*
  ///<summary>ScriptureReference property.</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public String ScriptureReference
  {
   get 
   {
    return ( scriptureReference );
   }//get
  }//public String ScriptureReference
  */

  ///<summary>Sequence order Id property.</summary>
  ///<value>A value tag is used to describe the property value.</value>
  [XmlIgnore]
  public int SequenceOrderId
  {
   get 
   {
    return ( sequenceOrderId );
   }//get
   set 
   {
    this.sequenceOrderId = value;
   }//get
  }//public String SequenceOrderId

  ///<summary>ScriptureReference property.</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public String Title
  {
   get 
   {
    return ( title );
   }//get
  }//public String Title

  ///<summary>DataSet Initialize.</summary>
  ///<param name="databaseConnectionString">Database connection String.</param>
  ///<param name="exceptionMessage">Exception message.</param>  
  ///<param name="nodeRoot">The root node.</param>
  ///<param name="sourceSQL">Source SQL.</param>
  ///<param name="sourceName">Source Name.</param>  
  public void DataSetInitialize
  (
       String    databaseConnectionString,
   ref String    exceptionMessage,
       String    nodeRoot,
       String[]  sourceSQL,
       String[]  sourceName
  )
  {
   int            identityValue                 = -1;

   int            tableCount                    = -1;
   int            tableTotal                    = -1;   
   int            tableRowTotal                 = -1;   

   String         dataRelationName              = null;

   DataColumn     dataColumnForeignKey          = null;
   DataColumn     dataColumnPrimaryKey          = null;

   DataRelation   dataRelation                  = null;
   
   StringBuilder  StringBuilderSQL              = null;
   
   object         databaseReturnValue           = null;

   if ( sequenceOrderId < 0 )
   {
   	SequenceOrderIdMax
   	(
         databaseConnectionString,
     ref exceptionMessage,
     ref sequenceOrderId
    );
   }
      
   StringBuilderSQL             = new StringBuilder();
   foreach ( String sourceSQLCurrent in sourceSQL )
   {
    StringBuilderSQL.AppendFormat(sourceSQLCurrent, sequenceOrderId);
    StringBuilderSQL.Append(';');
   }	
   
   System.Console.WriteLine("SQL: {0}", StringBuilderSQL.ToString());

   dataSetTheWord = new DataSet();
   dataSetTheWord.DataSetName = nodeRoot;
   UtilityDatabase.DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,
    ref dataSetTheWord,
        StringBuilderSQL.ToString(),
        CommandType.Text
   );

   try
   {
    tableCount = -1;
    tableTotal = dataSetTheWord.Tables.Count;
    #if (DEBUG)   
     System.Console.WriteLine("Tables Total: {0}", tableTotal);    
    #endif 

    databaseReturnValue = UtilityDatabase.DataSetTableRowColumn
    (
     dataSetTheWord,
     "TheWord",
     0,
     "Dated"
    );

    if ( databaseReturnValue != null && databaseReturnValue != DBNull.Value )
    {
     dated = Convert.ToDateTime( databaseReturnValue );
     System.Console.WriteLine("Dated: {0)", dated);
    }

    foreach( DataTable dataTable in dataSetTheWord.Tables )
    {
   	 ++tableCount;
     tableRowTotal = dataTable.Rows.Count;
     dataTable.TableName = sourceName[tableCount];
    
     // Define the primary key for the table as the IntegerValue 
     // column (column 0). To do this, first create an array of 
     // DataColumns to represent the primary key. The primary key can
     // consist of multiple columns, but in this example, only
     // one column is used.
     DataColumn[] keys = new DataColumn[1];
     keys[0] = dataTable.Columns["SequenceOrderId"];
     
     // Then assign the array to the PrimaryKey property of the DataTable. 
     dataTable.PrimaryKey = keys;

     databaseReturnValue = UtilityDatabase.TableIdentity
     (
          databaseConnectionString,
      ref exceptionMessage,
          dataTable.TableName
     );     

     if ( databaseReturnValue == DBNull.Value )
     {
      identityValue = -1;   	
     }
     else
     {	 
      identityValue = System.Convert.ToInt32( databaseReturnValue );
     } 

     dataTable.Columns["SequenceOrderId"].AllowDBNull       = true;
     dataTable.Columns["SequenceOrderId"].AutoIncrement     = true;     
     dataTable.Columns["SequenceOrderId"].AutoIncrementSeed = identityValue;

     dataTable.Columns["Dated"].DefaultValue                = dated;
     
     if ( identityValue == -1 )
     {
      dataTable.Columns["SequenceOrderId"].AutoIncrementStep = identityValue;
     }//if ( identityValue == -1 )	
      
     if ( tableCount == 0 )
     {
      dataColumnPrimaryKey = dataTable.Columns["SequenceOrderId"];
     }//if ( tableCount == 0 )
     else
     { 	
      /*
      dataRow = dataTable.NewRow();
      foreach( DataColumn dataColumn in dataTable.Columns )
      {
       if ( dataColumn.DataType == System.Type.GetType("System.DateTime") )
       {
        dataRow[dataColumn.ColumnName] = System.DateTime.Today;
       }//if ( dataColumn.DataType == System.Type.GetType("System.DateTime") )
      }//foreach( DataColumn dataColumn in dataTable.Columns ) 
      dataTable.Rows.Add(dataRow);
      */

      dataColumnForeignKey = dataTable.Columns["TheWordId"];
      dataRelationName = "TheWord_" + sourceName[tableCount];
      System.Console.WriteLine
      (
       "DataRelation Name: {0} | Primary Key: {1} | Foreign Key: {2}", 
       dataRelationName,
       dataColumnPrimaryKey,
       dataColumnForeignKey
      );
      dataRelation = new DataRelation
      (
       dataRelationName, 
       dataColumnPrimaryKey,
       dataColumnForeignKey
      );
      dataRelation.Nested = true;
      dataSetTheWord.Relations.Add( dataRelation );
     }//if ( tableCount != 0 )
    };//foreach(DataTable dataTable in dataSet.Tables)
   }//try
   catch (Exception exception)
   {
   	System.Console.WriteLine("Exception: {0}", exception.Message);
   }//catch (Exception exception)
  }//public static void DataSetInitialize()	

  ///<summary>DataSet Row Add.</summary>
  ///<param name="databaseConnectionString">Database connection String.</param>
  ///<param name="exceptionMessage">Exception message.</param>  
  ///<param name="dataSetTableId">The table Id includes the index, name, operation method.</param>
  ///<param name="tableId">The table Id.</param>
  ///<param name="tableName">The table name.</param>
  ///<param name="dataRowCount">The data row count.</param>
  public void DataSetRowAdd
  (
       String databaseConnectionString,
   ref String exceptionMessage,
       String dataSetTableId,
   ref int    tableId,
   ref String tableName,
   ref int    dataRowCount
  )
  {
   String[]   tableAlias           =  null;
   DataRow    dataRow              =  null;
   DataTable  dataTable            =  null;

   tableAlias = DataSetTableIdParse
   ( 
        dataSetTableId, 
    ref tableId,
    ref tableName 
   );

   dataTable  = dataSetTheWord.Tables[ tableName ];
   dataRow    = dataTable.NewRow();
   dataTable.Rows.Add(dataRow);
   dataRowCount = dataTable.Rows.Count;
  }	 

  ///<summary>DataSet Table Id Parse.</summary>
  ///<param name="dataSetTableId">The table Id includes the index, name, operation method.</param>
  ///<param name="tableId">The table Id.</param>
  ///<param name="tableName">The table name.</param>
  public String[] DataSetTableIdParse
  (
       String dataSetTableId,
   ref int    tableId,
   ref String tableName
  )
  {
   String[]   tableAlias = null;
   tableAlias = dataSetTableId.Split( DelimiterSplitChar );
   tableId    = Convert.ToInt32( tableAlias[0] );
   tableName  = tableAlias[1];
   return ( tableAlias );
  }	 

  ///<summary>DataSet New.</summary>
  public void DataSetNew()
  {

   DataRow  dataRow        = null;   

   try
   {
    dataSetTheWord.Clear();
    dataRow = dataSetTheWord.Tables["TheWord"].NewRow();
    dataSetTheWord.Tables["TheWord"].Rows.Add(dataRow);
   }//try
   catch (Exception exception)
   {
   	System.Console.WriteLine("Exception: {0}", exception.Message);
   }//catch (Exception exception)
  }//public static void DataSetNew()	

  ///<summary>FileOpen.</summary>
  ///<param name="databaseConnectionString">Database connection String.</param>
  ///<param name="exceptionMessage">Exception message.</param>  
  ///<param name="filenameXml">Filename XML.</param>
  public void FileOpen
  (
       String databaseConnectionString,
   ref String exceptionMessage,
   ref String filenameXml
  )
  {
   FileOpen
   ( 
        databaseConnectionString,
    ref exceptionMessage,
    ref dataSetTheWord, 
    ref filenameXml
   );
  }//public static void FileOpen()

  ///<summary>FileOpen.</summary>
  ///<param name="databaseConnectionString">Database connection String.</param>
  ///<param name="exceptionMessage">Exception message.</param>
  ///<param name="dataSet">DataSet.</param>  
  ///<param name="filenameXml">Filename XML.</param>
  public static void FileOpen
  (
       String  databaseConnectionString,
   ref String  exceptionMessage,
   ref DataSet dataSet,   
   ref String  filenameXml
  )
  {
   if ( filenameXml  == null || filenameXml == "" ) { filenameXml  = FilenameXml; }
   UtilityXml.ReadXml
   ( 
    ref dataSet, 
    ref exceptionMessage,
    ref filenameXml
   );
  }//public static void FileOpen()

  ///<summary>FileSave.</summary>
  public void FileSave()
  {
   String exceptionMessage   = null;	
   
   FileSave
   ( 
        DatabaseConnectionString, 
    ref exceptionMessage,
    ref FilenameXml,
    ref FilenameXslt
   );
  }//public static void FileSave()

  ///<summary>FileSave.</summary>
  ///<param name="databaseConnectionString">Database connection String.</param>
  ///<param name="exceptionMessage">Exception message.</param>
  ///<param name="filenameXml">Filename XML.</param>
  ///<param name="filenameXslt">Filename Stylesheet (XSLT).</param>
  public void FileSave
  (
       String  databaseConnectionString,
   ref String  exceptionMessage,
   ref String  filenameXml,
   ref String  filenameXslt
  )
  {
   FileSave
   ( 
        DatabaseConnectionString, 
    ref exceptionMessage,
    ref dataSetTheWord,
    ref FilenameXml,
    ref FilenameXslt
   );
  }//public void FileSave
  
  ///<summary>FileSave.</summary>
  ///<param name="databaseConnectionString">Database connection String.</param>
  ///<param name="exceptionMessage">Exception message.</param>
  ///<param name="dataSet">DataSet.</param>
  ///<param name="filenameXml">Filename XML.</param>
  ///<param name="filenameXslt">Filename Stylesheet (XSLT).</param>
  public void FileSave
  (
       String  databaseConnectionString,
   ref String  exceptionMessage,
   ref DataSet dataSet,
   ref String  filenameXml,
   ref String  filenameXslt
  )
  {

   filenameXml = (String) UtilityDatabase.DataSetTableRowColumn
   (
    dataSet,
    "TheWord",
    0,
    "Filename"
    );           

   if ( filenameXml  == null || filenameXml  == String.Empty ) { filenameXml  = FilenameXml; }
   if ( filenameXslt == null || filenameXslt == String.Empty ) { filenameXslt = FilenameXslt; }
   
   UtilityXml.WriteXml
   ( 
        dataSet, 
    ref exceptionMessage,
    ref filenameXml,
    ref filenameXslt
   );
  }//public static void FileSave()

  ///<summary>Source SQL Query.</summary>
  ///<param name="filenameXml">XML Configuraion filename.</param>
  ///<param name="exceptionMessage">Exception message.</param>  
  ///<param name="xmlNodeList">Source SQL in the XML Node List format.</param>
  ///<param name="sourceSQL">Source SQL in the ArrayList format.</param>
  ///<param name="sourceName">Source Name.</param>  
  public static void SourceSQLQuery
  (
       String      filenameXml,
   ref String      exceptionMessage,
   ref XmlNodeList xmlNodeList,
   ref String[]    sourceSQL,
   ref String[]    sourceName
  )
  {
   int          indexSQLSelectFrom           = -1;
   int          indexSQLSelectWhere          = -1;
   int          sourceNameIndex              = -1;
   int          sourceNameTotal              = -1;   

   HttpContext  httpContext                  =  HttpContext.Current;

   UtilityXml.SelectNodes
   (
        filenameXml,
    ref exceptionMessage,
        XPathSourceSQL,
    ref xmlNodeList
   );

   UtilityXml.Convert
   (
        xmlNodeList,
    ref sourceSQL,
    ref exceptionMessage
   );
   sourceNameTotal = sourceSQL.Length;
   sourceName = new String[sourceNameTotal];
   foreach ( String sourceSQLCurrent in sourceSQL )
   {
    indexSQLSelectFrom = sourceSQLCurrent.IndexOf("FROM");
    indexSQLSelectWhere = sourceSQLCurrent.IndexOf("WHERE");
    sourceName[++sourceNameIndex] = (sourceSQLCurrent.Substring( indexSQLSelectFrom + 5, indexSQLSelectWhere - indexSQLSelectFrom - 6 )).Trim();

    #if ( DEBUG )
     System.Console.WriteLine
     (
      "SourceName: {0} | SourceSQL: {1} | From: {2} | Where: {3}", 
      sourceName[sourceNameIndex], 
      sourceSQLCurrent, 
      indexSQLSelectFrom, 
      indexSQLSelectWhere 
     );
    #endif

   }//foreach ( String sourceSQLCurrent in sourceSQL )	
  }//public static void SourceSQLQuery( String filenameXml, ref String exceptionMessage, ref XmlNodeList sourceXML, ref ArrayList sourceSQL, ref ArrayList sourceName );

  /// <summary>TheWordDataSet.</summary>
  /// <param name="databaseConnectionString">The database connection String.</param>
  /// <param name="filenameConfigurationXml">The filename configuration Xml.</param>
  /// <param name="exceptionMessage">The exception message.</param>  
  /// <param name="filenameXml">The filename for xml.</param>
  /// <param name="filenameXslt">The filename for xslt.</param>
  public void TheWordDataSet
  (
       String  databaseConnectionString,
       String  filenameConfigurationXml,
   ref String  exceptionMessage,
   ref String  filenameXml,
   ref String  filenameXslt   
  )
  {
   int                                          tableRow                                  = 0;
   String                                       columnName                                = null;
   String                                       columnValue                               = null;
   String                                       columnNameDated                           = null;
   String                                       columnNameFilename                        = null;
   String                                       columnNameForeignKey                      = null;
   String                                       columnNamePrimaryKey                      = null;
   String                                       columnNameScriptureReferenceURI           = null;
   String                                       columnValuePrimaryKey                     = null;
   String                                       columnValueScriptureReferenceURI          = null;
   String                                       dated                                     = null;
   String[]                                     scriptureReferenceColumn                  = null;
   String[][]                                   scriptureReferenceArray                   = null;
   String                                       tableName                                 = null;
   String                                       tableNamePrimary                          = null;
   String                                       theWordId                                 = null;
   DataColumn                                   dataColumnAdd                             = null;
   ScriptureReferenceBookChapterVersePrePost[]  scriptureReferenceBookChapterVersePrePost = null;
   StringBuilder                                uriCrosswalkXml                           = null;
   StringBuilder                                uriCrosswalkHtml                          = null;
   StringBuilder                                SQLIdentityInsertOff                      = null;
   StringBuilder                                SQLIdentityInsertOn                       = null;
   StringBuilder                                SQLInsert                                 = null;
   StringBuilder                                SQLInsertColumnName                       = null;
   StringBuilder                                SQLInsertColumnValue                      = null;
   StringBuilder                                SQLSelect                                 = null;
   StringBuilder                                SQLSetColumn                              = null;
   StringBuilder                                SQLStatement                              = null;
   StringBuilder                                SQLUpdate                                 = null;
   StringBuilder                                SQLWhere                                  = null;
   Type                                         columnType                                = null;
   object                                       databaseReturnValue                       = null;
   OleDbCommand                                 oleDbCommand                              = null;
   OleDbConnection                              oleDbConnection                           = null;
   OleDbDataReader                              oleDbDataReader                           = null;   
   XmlNodeList                                  scriptureReferenceColumnXml               = null;

   if ( filenameXml == null )
   {
    filenameXml = (String) UtilityDatabase.DataSetTableRowColumn
    (
     dataSetTheWord,
     "TheWord",
     0,
     "FileName"
    );
   }   	

   filenameXml = filenameXml.Replace("'", "''");

   UtilityXml.XmlDocumentNodeInnerText
   (
        filenameConfigurationXml,
    ref exceptionMessage,         
        XPathColumnDated,
    ref columnNameDated
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
        filenameConfigurationXml,
    ref exceptionMessage,         
        XPathColumnFilename,
    ref columnNameFilename
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
        filenameConfigurationXml,
    ref exceptionMessage,         
        XPathColumnForeign,
    ref columnNameForeignKey
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
        filenameConfigurationXml,
    ref exceptionMessage,         
        XPathColumnPrimary,
    ref columnNamePrimaryKey
   );

   scriptureReferenceColumnXml = UtilityXml.SelectNodes
   (
        filenameConfigurationXml,
    ref exceptionMessage,
        ScriptureReference.XPathColumnScriptureReference
   );

   UtilityXml.Convert
   (
        scriptureReferenceColumnXml,
    ref scriptureReferenceColumn,
    ref exceptionMessage
   );

   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
   (
        databaseConnectionString,
    ref exceptionMessage
   );

   oleDbCommand = new OleDbCommand();
   oleDbCommand.Connection  = oleDbConnection;

   try
   {

    tableNamePrimary = dataSetTheWord.Tables[0].TableName;
    dated            = UtilityDatabase.DataSetTableRowColumn( dataSetTheWord, tableNamePrimary, 0, columnNameDated ).ToString().Trim();
    
    if ( dated == null || dated == String.Empty )
    {
     dated = System.DateTime.Today.ToString();
     UtilityDatabase.DataSetTableRowColumn( dataSetTheWord, tableNamePrimary, 0, columnNameDated, dated );
    }
    
    theWordId        = UtilityDatabase.DataSetTableRowColumn( dataSetTheWord, tableNamePrimary, 0, columnNamePrimaryKey ).ToString().Trim();
     
    #if (DEBUG)
     System.Console.WriteLine
     (
      "Table Name (Primary): {0} | Dated: {1} | Primary Key: {2}", 
      tableNamePrimary,
      dated,
      theWordId
     );
    #endif

    foreach ( DataTable dataTable in dataSetTheWord.Tables )
    {
     tableName            = dataTable.TableName;
     SQLIdentityInsertOff = new StringBuilder();
     SQLIdentityInsertOn  = new StringBuilder();
     
     SQLIdentityInsertOff.AppendFormat
     (
      UtilityDatabase.SQLPatternIdentityInsertOff,
      tableName
     );  

     SQLIdentityInsertOn.AppendFormat
     (
      UtilityDatabase.SQLPatternIdentityInsertOn,
      tableName
     );  

     tableRow = -1;
     foreach ( DataRow dataRow in dataTable.Rows )
     {
      ++tableRow;
      columnValuePrimaryKey = dataRow[columnNamePrimaryKey].ToString().Trim();
      SQLInsert             = new StringBuilder();
      SQLInsertColumnName   = new StringBuilder();
      SQLInsertColumnValue  = new StringBuilder();
      SQLSelect             = new StringBuilder();
      SQLSetColumn          = new StringBuilder();
      SQLStatement          = new StringBuilder();
      SQLUpdate             = new StringBuilder();
      SQLWhere              = new StringBuilder();
            
      SQLSelect.AppendFormat
      (
       UtilityDatabase.SQLPatternSelect,
       columnNamePrimaryKey,
       tableName,
       columnValuePrimaryKey              
      );
      
      SQLWhere.AppendFormat
      (
       UtilityDatabase.SQLPatternSetColumn,
       columnNamePrimaryKey,
       columnValuePrimaryKey
      ); 

      if ( String.Compare( tableName, tableNamePrimary, true) != 0 )
      {
       SQLWhere.Append( " AND " ); 

       SQLWhere.AppendFormat
       (
        UtilityDatabase.SQLPatternSetColumn,
        columnNameForeignKey,
        theWordId
       ); 
      }	
      
      if ( String.Compare( tableName, tableNamePrimary, true) == 0 )
      {
       SQLInsertColumnName.Append( columnNameFilename );
       SQLInsertColumnValue.AppendFormat
       ( 
        UtilityDatabase.SQLPatternColumnValue,
        filenameXml
       );

       SQLSetColumn.AppendFormat
       (
        UtilityDatabase.SQLPatternSetColumn,
        columnNameFilename,
        filenameXml
       );
      }//if ( String.Compare( tableName, tableNamePrimary, true) == 0 )
      else	
      {
       SQLInsertColumnName.Append( columnNameForeignKey );
       SQLInsertColumnValue.AppendFormat
       ( 
        UtilityDatabase.SQLPatternColumnValue,
        theWordId
       );
       SQLSetColumn.AppendFormat
       (
        UtilityDatabase.SQLPatternSetColumn,
        columnNameForeignKey,
        theWordId
       );
      }//if ( String.Compare( tableName, tableNamePrimary, true) != 0 )

      if ( UtilityDatabase.DataSetTableColumnContains( dataSetTheWord, tableName, columnNameDated ) == false )
      {
       UtilityDatabase.DataSetTableColumnAdd
       ( 
        dataSetTheWord,
        tableName,
        columnNameDated 
       );
      }

      databaseReturnValue = UtilityDatabase.DataSetTableRowColumn( dataSetTheWord, tableName, tableRow, columnNameDated );

      if ( databaseReturnValue == null || databaseReturnValue == DBNull.Value )
      {
       UtilityDatabase.DataSetTableRowColumn( dataSetTheWord, tableName, tableRow, columnNameDated, dated ); 
      }
      
      foreach ( DataColumn dataColumn in dataTable.Columns )
      {
       columnName     = dataColumn.ColumnName;

       if ( columnName.IndexOf('_') >= 0 || columnName.IndexOf( "URI") >= 0 || columnName.IndexOf( "FromUntil") >= 0 )
       {
        continue;
       } 	 

       columnType  = dataColumn.DataType;
       columnValue = System.Convert.ToString(dataRow[dataColumn.ColumnName]).Trim();
       columnValue = columnValue.Replace("'", "''");
       UtilityXml.XmlSignificantWhitespace( ref columnValue );

       if ( UtilityXml.IsValidRegexXmlSchemaDatatypeDateTime( columnValue ) )
       {
        columnValue = columnValue.Substring(0,10) + ' ' + columnValue.Substring(11,5);
       }

       #if (DEBUG)
        System.Console.WriteLine
        (
         "Column Name: {0} | Type: {1} | Value: {2}", 
         columnName,
         columnType,
         columnValue
        );      
       #endif

       if ( columnValue == String.Empty )
       {
       	columnValue = null;
       }//if ( columnValue == String.Empty )	

       if ( columnName.IndexOf('_') >= 0 || columnName.IndexOf( "URI") >= 0 )
       {
        continue;
       } 	 

       if ( Array.IndexOf( scriptureReferenceColumn, columnName ) >= 0 )
       {
        columnNameScriptureReferenceURI  = columnName + "URI";
        columnValueScriptureReferenceURI = null;
        
        if ( columnValue != null )
        {

         ScriptureReference.ScriptureReferenceParser
         (
              new String[] { columnValue },
              databaseConnectionString,
          ref exceptionMessage,
          ref scriptureReferenceBookChapterVersePrePost,
          ref scriptureReferenceArray,
          ref uriCrosswalkHtml,
          ref uriCrosswalkXml
         );//ScriptureReference.ScriptureReferenceParser()
     
         columnValueScriptureReferenceURI = uriCrosswalkHtml.ToString();
         #if (DEBUG)
          System.Console.WriteLine
          (
           "Scripture Reference Column Name: {0} | Value: {1} | Scripture Reference URI Column Name: {2} | Value: {3}",
           columnName,
           columnValue,
           columnNameScriptureReferenceURI,
           columnValueScriptureReferenceURI
          );      
         #endif
        }//if ( columnValue != null )
                
        if ( UtilityDatabase.DataSetTableColumnContains( dataSetTheWord, tableName, columnName ) == false )
        {
         dataColumnAdd = UtilityDatabase.DataSetTableColumnAdd( dataSetTheWord, tableName, columnName );
        }//if ( DataSetTableColumnContains( columnName ) == false )
        
        UtilityDatabase.DataSetTableRowColumn
        ( 
         dataSetTheWord,
         tableName,
         tableRow,
         columnNameScriptureReferenceURI, 
         columnValueScriptureReferenceURI 
        );	
        
       }//if ( scriptureReferenceColumn.IndexOf( columnName ) >= 0 )

       if ( SQLInsertColumnName != null && SQLInsertColumnName.Length > 0 )
       {
        SQLInsertColumnName.Append(',');
       }//if ( SQLInsertColumnName.Length > 0 )

       if ( SQLInsertColumnValue != null && SQLInsertColumnValue.Length > 0 )
       {
        SQLInsertColumnValue.Append(',');
       }//if ( SQLInsertColumnValue.Length > 0 )

       SQLInsertColumnName.Append( columnName );
       
       if ( columnValue == null )
       {
        SQLInsertColumnValue.Append( UtilityDatabase.SQLNull );
       }//if ( columnValue == null )
       else
       {	
        SQLInsertColumnValue.AppendFormat
        ( 
         UtilityDatabase.SQLPatternColumnValue,
         columnValue 
        );
       }//if ( columnValue != null )
       
       if ( String.Compare( columnName, columnNamePrimaryKey, true) != 0 )
       {
        if ( SQLSetColumn != null && SQLSetColumn.Length > 0 )
        {
         SQLSetColumn.Append(',');
        }//if ( SQLSetColumn.Length > 0 )

        if ( columnValue == null )
        {
         SQLSetColumn.AppendFormat
         ( 
          UtilityDatabase.SQLPatternSetColumnNull,
          columnName,          
          UtilityDatabase.SQLNull 
         );
        }//if ( columnValue == null )
        else
        {	
         SQLSetColumn.AppendFormat
         (
          UtilityDatabase.SQLPatternSetColumn,
          columnName,
          columnValue
         );
        }//if ( columnValue != null )
       }//if ( String.Compare( columnName, columnNamePrimaryKey, true) != 0 ) 
      }//foreach ( DataColumn dataColumn in dataTable.Columns )

      if ( columnValuePrimaryKey == null || columnValuePrimaryKey == String.Empty )
      {
       SQLInsert.AppendFormat
       (
        UtilityDatabase.SQLPatternInsert,
        tableName,
        SQLInsertColumnName,
        SQLInsertColumnValue,
        UtilityDatabase.SQLPatternSelectIdentity
       );
      }//if ( columnValueIdentity == null || columnValueIdentity == String.Empty )
      else
      {
       SQLInsert.AppendFormat
       (
        UtilityDatabase.SQLPatternInsertIdentity,
        SQLIdentityInsertOn,
        tableName,
        SQLInsertColumnName,
        SQLInsertColumnValue,
        SQLIdentityInsertOff
       );
      }//if ( columnValueIdentity != null && columnValueIdentity != String.Empty )	

      SQLUpdate.AppendFormat
      (
       UtilityDatabase.SQLPatternUpdate,
       tableName,
       SQLSetColumn,
       SQLWhere
      );               

      SQLStatement.AppendFormat
      (
       UtilityDatabase.SQLPatternSelectInsertUpdate,
       SQLSelect,
       SQLInsert,
       SQLUpdate
      );               

      #if (DEBUG)
       System.Console.WriteLine("Set Column:              {0}", SQLSetColumn);
       System.Console.WriteLine("Set Insert Column Name:  {0}", SQLInsertColumnName);
       System.Console.WriteLine("Set Insert Column Value: {0}", SQLInsertColumnValue);
       System.Console.WriteLine("SQL Select:              {0}", SQLSelect);
       System.Console.WriteLine("SQL Insert:              {0}", SQLInsert);       
       System.Console.WriteLine("SQL Update:              {0}", SQLUpdate);
       System.Console.WriteLine("SQL Statement:           {0}", SQLStatement);
      #endif

      oleDbCommand.CommandText = SQLStatement.ToString();

      //databaseReturnValue      = oleDbCommand.ExecuteScalar();
      databaseReturnValue      = oleDbCommand.ExecuteNonQuery();
      
      if ( databaseReturnValue != null )
      {
       if ( columnValuePrimaryKey == null || columnValuePrimaryKey == String.Empty ) 
       {
        System.Console.WriteLine("Identity: {0}", databaseReturnValue);
        dataRow[columnNamePrimaryKey] = databaseReturnValue;
        UtilityDatabase.DataSetTableRowColumn( dataSetTheWord, tableName, tableRow, columnNamePrimaryKey, databaseReturnValue );
       }//if ( columnValueIdentity == null || columnValueIdentity == String.Empty )  
      }//if ( databaseReturnValue != null ) 

     }//foreach ( DataRow dataRow in dataTable )
    }//foreach ( DataTable dataTable in dataSet ) 

    UtilityDatabase.DatabaseConnectionHouseKeeping
    (
         oleDbConnection,
     ref exceptionMessage
    );

    FileSave
    (
         databaseConnectionString,
     ref exceptionMessage,
     ref filenameXml,
     ref filenameXslt
    );

   }//try
   catch (SecurityException exception)
   {
    exceptionMessage = exception.Message;
    System.Console.WriteLine( "SecurityException: {0}", exception.Message );
   }//catch (SecurityException exception)
   catch (OleDbException exception)
   {
    exceptionMessage = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    System.Console.WriteLine("OLEDbException: {0}", exceptionMessage);
   }
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
  }//public static void TheWordDataSet()
  
  /// <summary>SequenceOrderIdMax.</summary>
  /// <param name="databaseConnectionString">The database connection String.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="sequenceOrderIdMax">The sequence order Id max.</param>
  public static void SequenceOrderIdMax
  (
       String  databaseConnectionString,
   ref String  exceptionMessage,
   ref int     sequenceOrderIdMax
  )
  {
   object         databaseReturnValue  = null;
   StringBuilder  StringBuilderSQL     = null;

   StringBuilderSQL = new StringBuilder();
   StringBuilderSQL.AppendFormat(UtilityDatabase.SQLPatternScalar, "Max", "SequenceOrderId", "TheWord");
   databaseReturnValue =  UtilityDatabase.DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,
        StringBuilderSQL.ToString()
   );

   if ( databaseReturnValue == DBNull.Value )
   {
    return;    	
   }	
   sequenceOrderIdMax = (Int32) databaseReturnValue;
  }//public static void SequenceOrderIdMax

  /// <summary>UtilitySerialization()</summary>
  public static void UtilitySerialization()
  {

   String                        exceptionMessage              =  null;
   String[]                      sourceSQL                     =  null;
   String[]                      sourceName                    =  null;

   XmlNodeList                   xmlNodeListSourceXML          =  null;
   DataSet                       dataSetTheWord                =  null;
   TheWordSerializationArgument  theWordSerializationArgument  =  null;

   UtilitySerialization
   (
    ref FilenameConfigurationXml,
    ref DatabaseConnectionString,    
    ref XPathSourceSQL,
    ref xmlNodeListSourceXML,
    ref sourceSQL,
    ref sourceName,
    ref dataSetTheWord,
    ref ClassNameAlias,
    ref theWordSerializationArgument,
    ref exceptionMessage
   );//UtilitySerialization()   
  }//UtilitySerialization()

  /// <summary>UtilitySerialization()</summary>
  public static void UtilitySerialization
  (
   ref String                            filenameConfigurationXml,
   ref String                            databaseConnectionString,
   ref TheWordSerializationArgument      theWordSerializationArgument,
   ref DataSet                           dataSetTheWord,
   ref String                            exceptionMessage
  )
  {

   object       databaseReturnValue                    =  null;

   int          filenameXmlDocumentExcludePathIndexOf  =  -1;

   String       selectColumn                           =  null;
   String       selectSource                           =  null;

   String[]     sourceName                             =  null;   
   String[]     sourceSQL                              =  null;

   String       whereColumn                            =  null;
   String       whereValue                             =  null;
   String       filenameXmlDocumentExcludePath         =  null;

   XmlNodeList  xmlNodeListSourceXML                   =  null;

   HttpContext  httpContext                            =  null;

   filenameXmlDocumentExcludePath                      =  theWordSerializationArgument.filenameXmlDocument;
   selectColumn = "SequenceOrderId";
   selectSource = ClassNameAlias;

   httpContext  =  HttpContext.Current;

   if ( filenameXmlDocumentExcludePath != null && filenameXmlDocumentExcludePath != String.Empty )
   {
    filenameXmlDocumentExcludePathIndexOf  =  filenameXmlDocumentExcludePath.LastIndexOf("\\");
    if ( filenameXmlDocumentExcludePathIndexOf > -1 )
    {
     filenameXmlDocumentExcludePath = filenameXmlDocumentExcludePath.Substring( filenameXmlDocumentExcludePathIndexOf + 1 );
    }//if ( filenameXmlDocumentExcludePathIndexOf > -1 )
   }//if ( filenameXmlDocumentExcludePath != null && filenameXmlDocumentExcludePath != String.Empty )

   if ( theWordSerializationArgument.theWordId > -1 )
   {
    whereColumn = "SequenceOrderId";
    whereValue  = Convert.ToString( theWordSerializationArgument.theWordId );
   }//if ( theWordSerializationArgument.theWordId >= 1 )
   else if ( theWordSerializationArgument.dated != null && theWordSerializationArgument.dated != String.Empty )
   {
    whereColumn = "dated";
    whereValue  = theWordSerializationArgument.dated;
   }//else if ( theWordSerializationArgument.dated != null )
   else if ( filenameXmlDocumentExcludePath != null )
   {
    whereColumn = "Filename";
    whereValue  = filenameXmlDocumentExcludePath;
   }//else if ( filenameXmlDocumentExcludePath != null )

   if ( whereColumn != null )
   {

    UtilityDatabase.DatabaseQuerySQLSelectTop1
    (
     ref databaseConnectionString,
     ref exceptionMessage,
     ref databaseReturnValue,
     ref selectColumn,
     ref selectSource,
     ref whereColumn,
     ref whereValue
    );

    if ( databaseReturnValue == null || databaseReturnValue == DBNull.Value )
    { 
     return;      	 
    }//if ( databaseReturnValue == null || databaseReturnValue == DBNull.Value )

    theWordSerializationArgument.theWordId = System.Convert.ToInt32( databaseReturnValue );

   }//if ( whereColumn != null )

   #if (DEBUG)
    if ( httpContext == null )
    {
     System.Console.WriteLine("TheWordId: {0}", theWordSerializationArgument.theWordId);
    }//if ( httpContext == null )
    else
    {
     //httpContext.Response.Write("TheWordId: " + theWordSerializationArgument.theWordId );
    }//else if ( httpContext == null )
   #endif

   UtilitySerialization
   (
    ref filenameConfigurationXml,
    ref databaseConnectionString,    
    ref XPathSourceSQL,
    ref xmlNodeListSourceXML,
    ref sourceSQL,
    ref sourceName,
    ref dataSetTheWord,
    ref ClassNameAlias,
    ref theWordSerializationArgument,
    ref exceptionMessage
   );//UtilitySerialization()   
   	
  }//public static void UtilitySerialization
  
  /// <summary>UtilitySerialization()</summary>
  public static void UtilitySerialization
  (
   ref String                        filenameConfigurationXml,
   ref String                        databaseConnectionString,
   ref String                        xPathSourceSQL,
   ref XmlNodeList                   xmlNodeListSourceXML,
   ref String[]                      sourceSQL,
   ref String[]                      sourceName,
   ref DataSet                       dataSetTheWord,
   ref String                        dataSetName,
   ref TheWordSerializationArgument  theWordSerializationArgument,
   ref String                        exceptionMessage
  )
  {
   StringBuilder  sbSQL                =  null;
   HttpContext    httpContext          =  null;

   exceptionMessage     =  null;
   sbSQL                =  new StringBuilder();
   httpContext          =  HttpContext.Current;

   //httpContext.Response.Write( "theWordSerializationArgument.theWordId: " + theWordSerializationArgument.theWordId );

   if ( theWordSerializationArgument.theWordId < 1 )
   { 

    UtilityDatabase.TableIdentity
    (
         databaseConnectionString,
     ref exceptionMessage,
         dataSetName,
     ref theWordSerializationArgument.theWordId    
    );

    //httpContext.Response.Write( "dataSetName: " + dataSetName );

    /*
    #if (DEBUG)
     if ( exceptionMessage != null )
     {
      if ( httpContext == null )
      {
       System.Console.WriteLine("Exception Message: {0}", exceptionMessage );
      }//if ( httpContext == null )
      else
      {
       httpContext.Response.Write( "Exception Message: " + exceptionMessage );
      }//else if ( httpContext == null )
      return;
     }if ( exceptionMessage != null )
    #endif
    */

    if ( exceptionMessage != null )
    {
     return;
    }//if ( exceptionMessage != null )
         	
   }//if ( theWordSerializationArgument.theWordId < 1 )
   
   SourceSQLQuery
   (
        filenameConfigurationXml,
    ref exceptionMessage,
    ref xmlNodeListSourceXML,
    ref sourceSQL,
    ref sourceName
   );

   if ( exceptionMessage != null )
   {
    return;
   }//if ( exceptionMessage != null )

   foreach ( String sourceSQLCurrent in sourceSQL )
   {
    sbSQL.AppendFormat(sourceSQLCurrent, theWordSerializationArgument.theWordId);
    sbSQL.Append(';');
   }//foreach ( String sourceSQLCurrent in sourceSQL )	
   
   #if (DEBUG)
    System.Console.WriteLine("SQL: {0}", sbSQL);
   #endif

   /*
   if (Trace.IsEnabled)
   {
    Trace.Write("SQL: " + sbSQL);
   }
   */

   Trace.Write("SQL: " + sbSQL);

   dataSetTheWord = new DataSet();
   UtilityDatabase.DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,
    ref dataSetTheWord,
        sbSQL.ToString(),
        CommandType.Text
   );

   dataSetTheWord.DataSetName = dataSetName;
   for ( int tableIdCurrent = 0; tableIdCurrent < dataSetTheWord.Tables.Count; ++tableIdCurrent )
   {
    dataSetTheWord.Tables[tableIdCurrent].TableName = sourceName[tableIdCurrent];
   }//for ( int tableIdCurrent = 0; tableIdCurrent < dataSetTheWord.Tables.Length; ++tableIdCurrent )

   if ( theWordSerializationArgument.filenameXmlDocumentGenerate == null || theWordSerializationArgument.filenameXmlDocumentGenerate == String.Empty )
   {
    if ( dataSetTheWord.Tables[ClassNameAlias].Rows.Count > 0 )
    {
     theWordSerializationArgument.filenameXmlDocumentGenerate = (String) UtilityDatabase.DataSetTableRowColumn
     (
      dataSetTheWord,
      ClassNameAlias,
      0,
      "FileName"
     );
    };//if ( dataSetTheWord.Tables[ClassNameAlias].Rows > 0 )
   }//if ( theWordSerializationArgument.filenameXmlDocumentGenerate == null || theWordSerializationArgument.filenameXmlDocumentGenerate == String.Empty )

   ScriptureReference.ScriptureReferenceURI
   (
        databaseConnectionString,
        filenameConfigurationXml,
    ref exceptionMessage,
    ref dataSetTheWord
   );//UtilityDatabase

   UtilityXml.WriteXml
   ( 
        dataSetTheWord, 
    ref exceptionMessage,
    ref theWordSerializationArgument.filenameXmlDocumentGenerate,
    ref theWordSerializationArgument.filenameStylesheet
   );
  }//public static void UtilitySerialization

  static TheWord()
  {
   DelimiterSplitChar = DelimiterSplitString.ToCharArray();
  }//static()
  
 }//public class TheWord.
}//namespace WordEngineering