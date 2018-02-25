using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management;
using System.Security;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;

namespace WordEngineering
{

 /// <summary>TheWordSerializationArgument</summary>
 public class TheWordSerializationArgument
 {
  ///<summary>words</summary>  
  public int    theWordId                    =  -1;

  ///<summary>dated</summary>
  public string dated                        =  null;
  
  ///<summary>filenameXmlDocument</summary>  
  public string filenameXmlDocument          =  null;

  ///<summary>filenameXmlDocumentGenerate</summary>  
  public string filenameXmlDocumentGenerate  =  null;

  ///<summary>filenameStylesheet</summary>  
  public string filenameStylesheet           =  null;
  
  ///<summary>files</summary>
  //[DefaultCommandLineArgument(CommandLineArgumentType.MultipleUnique)]
  public string[] files;

  /// <summary>Constructor.</summary>
  public TheWordSerializationArgument()
  {
  }//public TheWordSerializationArgument()
  
  /// <summary>Constructor.</summary>
  public TheWordSerializationArgument
  (
   int     theWordId,
   String  dated,
   String  filenameXmlDocument,
   String  filenameXmlDocumentGenerate,
   String  filenameStylesheet
  )
  {
   if ( dated == String.Empty )
   {
    dated = null;
   }//if ( dated == String.Empty )

   if ( filenameStylesheet == null || filenameStylesheet == String.Empty )
   {
    filenameStylesheet = TheWord.FilenameXslt;
   }//if ( filenameXmlDocument == null || filenameXmlDocument == String.Empty )

   this.theWordId                    =  theWordId;
   this.dated                        =  dated;
   this.filenameXmlDocument          =  filenameXmlDocument;
   this.filenameXmlDocumentGenerate  =  filenameXmlDocumentGenerate;
   this.filenameStylesheet           =  filenameStylesheet;
  }//public TheWordSerializationArgument()

 }//public class TheWordSerializationArgument

 ///<summary>TheWordSerialization</summary>
 ///<remarks>TheWordSerialization /theWordId:539 /dated:20040701</remarks>
 public class TheWordSerialization
 {

  /// <summary>TheWordSerializationArgumentFilenameXmlDocument.</summary>
  public static  int        TheWordSerializationArgumentFilenameXmlDocument          =  0;

  /// <summary>TheWordSerializationArgumentFilenameXmlDocumentGenerate.</summary>
  public static  int        TheWordSerializationArgumentFilenameXmlDocumentGenerate  =  1;

  /// <summary>TheWordSerializationArgumentFilenameStylesheet.</summary>
  public static  int        TheWordSerializationArgumentFilenameStylesheet           =  2;

  /// <summary>The database connection string.</summary>
  public static  String     DatabaseConnectionString                                 =  @"Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";
 
  /// <summary>The configuration XML filename.</summary>
  public static  String     FilenameConfigurationXml                                 =  @"WordEngineering.config";

  /// <summary>The XMLProcessingInstructionStyleSheet</summary>
  public const   String     XMLProcessingInstructionStyleSheet                       =  @"type='text/xsl' href='{0}'";
  
  /// <summary>The XPath database connection string.</summary>
  public const   String     XPathDatabaseConnectionString                            = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";
  
  /// <summary>Constructor.</summary>
  public TheWordSerialization()
  {

  }
  
  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main
  (
   String[] argv
  )
  {
   Boolean                       booleanParseCommandLineArguments  =  false;
   String                        exceptionMessage                  =  null;

   DataSet                       dataSetTheWord                    =  null;
   TheWordSerializationArgument  theWordSerializationArgument      =  null;
   
   theWordSerializationArgument = new TheWordSerializationArgument();
   
   booleanParseCommandLineArguments =  UtilityParseCommandLineArgument.ParseCommandLineArguments
   ( 
    argv, 
    theWordSerializationArgument
   );
   
   if ( booleanParseCommandLineArguments  == false )
   {
    // error encountered in arguments. Display usage message
    System.Console.Write
    (
     UtilityParseCommandLineArgument.CommandLineArgumentsUsage( typeof ( TheWordSerializationArgument ) )
    );
    return;
   }//if ( booleanParseCommandLineArguments  == false )

   if ( theWordSerializationArgument.files.Length > TheWordSerializationArgumentFilenameXmlDocument )
   {
    theWordSerializationArgument.filenameXmlDocument = theWordSerializationArgument.files[TheWordSerializationArgumentFilenameXmlDocument];
   }//if ( theWordSerializationArgument.files.Length > TheWordSerializationArgumentFilenameXmlDocument )

   if ( theWordSerializationArgument.files.Length > TheWordSerializationArgumentFilenameXmlDocumentGenerate )
   {
    theWordSerializationArgument.filenameXmlDocumentGenerate = theWordSerializationArgument.files[TheWordSerializationArgumentFilenameXmlDocumentGenerate];
   }//if ( theWordSerializationArgument.files.Length > TheWordSerializationArgumentFilenameXmlDocumentGenerate )

   if ( theWordSerializationArgument.files.Length > TheWordSerializationArgumentFilenameStylesheet )
   {
    theWordSerializationArgument.filenameStylesheet = theWordSerializationArgument.files[TheWordSerializationArgumentFilenameStylesheet];    
   }//if ( theWordSerializationArgument.files.Length > TheWordSerializationArgumentFilenameStylesheet )

   #if (DEBUG)
    System.Console.WriteLine
    (
     "Argument TheWordId: {0} | Dated: {1} | FilenameXmlDocument: {2} | FilenameXmlDocumentGenerate: {3} | FilenameStylesheet: {4} | Files: {5}", 
     theWordSerializationArgument.theWordId,
     theWordSerializationArgument.dated,
     theWordSerializationArgument.filenameXmlDocument,
     theWordSerializationArgument.filenameXmlDocumentGenerate,
     theWordSerializationArgument.filenameStylesheet,
     theWordSerializationArgument.files
    );
   #endif

   TheWord.UtilitySerialization
   (
    ref FilenameConfigurationXml,
    ref DatabaseConnectionString,
    ref theWordSerializationArgument,
    ref dataSetTheWord,
    ref exceptionMessage
   );
  
  }//static void Main( String[] argv ) 

  ///<summary>Stub.</summary>
  public static void Stub()
  {
   TheWord.UtilitySerialization();   
  }
  
  /// <summary>Read the XML Configuration file.</summary>
  public static void ConfigurationXml()
  {  
   string exceptionMessage = null;
   
   ConfigurationXml
   (
        FilenameConfigurationXml,
    ref exceptionMessage,
    ref DatabaseConnectionString
   );
   
  }//public static void ConfigurationXml()

  /// <summary>Read the XML Configuration file.</summary>
  /// <param name="filenameConfigurationXml">The XML Configuration file.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="databaseConnectionString">The database connection string.</param>  
  public static void ConfigurationXml
  (
       string filenameConfigurationXml,
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
  
  static TheWordSerialization()
  {
   ConfigurationXml();
  }//static TheWordSerialization()
  
 }//public class TheWordSerialization
 
}//namespace WordEngineering