using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;

namespace WordEngineering
{

 /// <summary>EternalArgument</summary>
 public class EternalArgument
 {
  ///<summary>date</summary>
  public bool     date                         =  Eternal.Date;
 	
  ///<summary>sqlQuery</summary>
  public String   sqlQuery                     =  null;

  ///<summary>filenameXml</summary>
  public String   filenameXml                  =  null;
  
  ///<summary>filenameStylesheet</summary>  
  public String   filenameStylesheet           =  null;
  
  ///<summary>files</summary>
  [DefaultCommandLineArgument(CommandLineArgumentType.MultipleUnique)]
  public String[] files;

  /// <summary>Constructor.</summary>
  public EternalArgument()
  {
  }//public EternalArgument()
  
  /// <summary>Constructor.</summary>
  public EternalArgument
  (
   bool      date,
   String    sqlQuery,
   String    filenameXml,
   String    filenameStylesheet
  )
  {
   this.date                =  date;
   this.sqlQuery            =  sqlQuery;
   this.filenameXml         =  filenameXml;
   this.filenameStylesheet  =  filenameStylesheet;
  }//public EternalArgument()

 }//public class EternalArgument

 /// <summary>Eternal.</summary>
 public class Eternal
 {

  /// <summary>Date</summary>
  public const bool    Date = false;
 	
  /// <summary>The class name.</summary>
  public const string  ClassName                                   = "Eternal";

  /// <summary>The database connection string.</summary>
  public const string  DatabaseConnectionString                    = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public const string   FilenameConfigurationXml                    = @"WordEngineering.config";

  /// <summary>The SQL Update statement for the ScriptureReferenceURI.</summary>  
  public const string   SQLUpdateScriptureReferenceURI              = " UPDATE {0} SET ScriptureReferenceURI = '{1}' WHERE UniqueId = '{2}'";

  /// <summary>The SQL Select.</summary>  
  public const string   SQLSelect                                   = " SELECT * FROM {0} ";

  /// <summary>eventLog</summary>
  public static System.Diagnostics.EventLog  EventLogCurrent;
  
  ///<summary>The entry point for the application.</summary>
  public static void Main
  (
   string[] argv
  )
  {
   Boolean          booleanParseCommandLineArguments  =  false;
   String           exceptionMessage                  =  null;
   EternalArgument  eternalArgument                   =  null;

   eternalArgument = new EternalArgument();
   booleanParseCommandLineArguments =  UtilityParseCommandLineArgument.ParseCommandLineArguments
   ( 
    argv, 
    eternalArgument
   );
   if ( booleanParseCommandLineArguments  == false )
   {
    // error encountered in arguments. Display usage message
    System.Console.Write
    (
     UtilityParseCommandLineArgument.CommandLineArgumentsUsage( typeof ( EternalArgument ) )
    );
    return;
   }//if ( booleanParseCommandLineArguments  == false )
   EternalXml( ref eternalArgument, ref exceptionMessage );
  }
  
  /// <summary>EternalXml</summary>
  public static void EternalXml
  (
   ref EternalArgument  eternalArgument,
   ref string           exceptionMessage
  )
  {
   DataSet         dataSet                           = null;
   ArrayList       databaseName                      = null;
   ArrayList       sqlStatementUnion                 = null;
   ArrayList       objectName                        = null;
   ArrayList       ownerName                         = null;
   ArrayList       unionIndex                        = null;
   String          filenameXml                       = null;
   try
   {
    UtilityDatabase.DatabaseQuery
    (
         DatabaseConnectionString,
     ref exceptionMessage,
     ref dataSet,
         eternalArgument.sqlQuery,
         CommandType.Text
    );
    if ( exceptionMessage != null )
    {
     return;
    };
    UtilityDatabase.SQLSelectParse
    (
         eternalArgument.sqlQuery,
     ref unionIndex,
     ref sqlStatementUnion,
     ref databaseName,
     ref ownerName,    
     ref objectName,
     ref exceptionMessage
    );
    if ( exceptionMessage != null )
    {
     return;
    };
    if ( dataSet.Tables.Count < 1 )
    {
   	 return;
    }//if ( dataSet.Tables.Count < 1 )	
    dataSet.DataSetName = (String) databaseName[0];
    for ( int objectNameCount = 0; objectNameCount < objectName.Count; ++objectNameCount )
    {
   	 dataSet.Tables[objectNameCount].TableName = (String) objectName[ objectNameCount ];
    }//for ( int objectNameCount = 0; objectNameCount < objectName.Count; ++objectNameCount )
    ScriptureReference.ScriptureReferenceURI
    (
         DatabaseConnectionString,
         FilenameConfigurationXml,
     ref exceptionMessage,
     ref dataSet
    );
    if ( exceptionMessage != null )
    {
     return;
    };
    if ( eternalArgument.date )
    {
     filenameXml = UtilityFile.DatePostfix( eternalArgument.filenameXml );
    }
    else
    {
     filenameXml = eternalArgument.filenameXml;
    }
    UtilityXml.WriteXml
    (
         dataSet,
     ref exceptionMessage,
     ref filenameXml,
     ref eternalArgument.filenameStylesheet
    );
    if ( exceptionMessage != null )
    {
     return;
    };
   }
   catch ( Exception exception ) { UtilityException.ExceptionLog( exception, exception.GetType().Name, ref exceptionMessage ); }
  }
  
  static Eternal()
  {
  }//static Eternal()

 }//public class Eternal.
}//namespace WordEngineering
