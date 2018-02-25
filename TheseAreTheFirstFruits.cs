using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WordEngineering
{
 /// <summary>TheseAreTheFirstFruits.</summary>
 public class TheseAreTheFirstFruits
 {
  /// <summary>The database connection string.</summary>
  public static string  DatabaseConnectionString                    = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public const string   FilenameConfigurationXml                    = @"WordEngineering.config";
  
  /// <summary>The Pattern Filename.</summary>
  const        string   PatternFilename                             = @"TheseAreTheFirstFruits\{0}\{1}{2}.xml";

  /// <summary>The XPath database connection string.</summary>
  const        string   XPathDatabaseConnectionString               = @"/word/database/sqlServer/master/databaseConnectionString";

  /// <summary>The XPath import pattern filename.</summary>
  const        string   XPathImportPatternFilename                  = @"/word/theseAreTheFirstFruits/import/patternFilename";

  /// <summary>The XPath Pattern Filename.</summary>
  const        string   XPathPatternFilename                        = @"/word/theseAreTheFirstFruits/patternFilename";

  /// <summary>The XPath for the SQL table.</summary>
  const        string   XPathSQLTable                               = @"SELECT * FROM {0}..{1}";
  
  /// <summary>The XPath database(s).</summary>
  const        string   XPathTheseAreTheFirstFruitsDatabase         = @"/word/theseAreTheFirstFruits/export/database";

  /* "/word/theseAreTheFirstFruits/database/table[starts-with(..,normalize-space('{0}'))]"; */
  /// <summary>The XPath table(s).</summary>
  const        string   XPathTheseAreTheFirstFruitsTable            = @"/word/theseAreTheFirstFruits/export/database/table[starts-with(..,normalize-space('{0}'))]";

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">Command-line arguments.</param>
  public static void Main
  (
   string[] argv
  )
  {
   string databaseConnectionString  = DatabaseConnectionString;
   string exceptionMessage          = null;
   
   UtilityXml.XmlDocumentNodeInnerText
   ( 
        FilenameConfigurationXml,
    ref exceptionMessage, 
        XPathDatabaseConnectionString,
    ref databaseConnectionString 
   );

   UtilityDatabase.DatabaseMaintenance
   (
        DatabaseConnectionString,
    ref exceptionMessage,
        FilenameConfigurationXml,
        XPathTheseAreTheFirstFruitsDatabase,
        XPathTheseAreTheFirstFruitsTable,
        XPathSQLTable,
        new string[] { XPathPatternFilename, PatternFilename },
        XPathImportPatternFilename
   );
  
  }//public static void Main
  
 }//public class TheseAreTheFirstFruits.
}//namespace WordEngineering