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
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace WordEngineering
{

 /// <summary>ShaheedAliArgument http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnxml/html/sysxmlvs05.asp Mark Fussell: What's New in System.Xml for Visual Studio 2005 and the .NET Framework 2.0 Release</summary>
 public class ShaheedAliArgument
 {
  ///<summary>filenameXMLDocument</summary>  
  public String[] filenameXMLDocument          =  null;

  ///<summary>filenameXMLSchema</summary>  
  public String[] filenameXMLSchema            =  null;

  ///<summary>files</summary>
  [DefaultCommandLineArgument(CommandLineArgumentType.MultipleUnique)]
  public String[] files;

  /// <summary>Constructor.</summary>
  public ShaheedAliArgument()
  {
  }//public ShaheedAliArgument()
  
  /// <summary>Constructor.</summary>
  public ShaheedAliArgument
  (
   String[] filenameXMLDocument,
   string[] filenameXMLSchema
  )
  {
   this.filenameXMLDocument = filenameXMLDocument;
   this.filenameXMLSchema   = filenameXMLSchema;
  }//public ShaheedAliArgument()

 }//public class ShaheedAliArgument

 ///<summary>URIWordEngineering</summary>
 public class URIWordEngineering
 {
  ///<summary>uri</summary>
  public string   uri;
  
  ///<summary>title</summary>
  public string   title;
  
  ///<summary>dated</summary>  
  public DateTime dated; 
   	
 }//public class URIWordEngineering
 
 ///<summary>ShaheedAli</summary>
 ///<remarks>ShaheedAli /theWordId:539 /dated:20040701</remarks>
 public class ShaheedAli
 {

  /// <summary>The database connection string.</summary>
  public static  String     DatabaseConnectionString                                 =  @"Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";
 
  /// <summary>The configuration XML filename.</summary>
  public static  String     FilenameConfigurationXml                                 =  @"WordEngineering.config";

  /// <summary>The XMLProcessingInstructionStyleSheet</summary>
  public const   String     XMLProcessingInstructionStyleSheet                       =  @"type='text/xsl' href='{0}'";
  
  /// <summary>The XPath database connection string.</summary>
  public const   String     XPathDatabaseConnectionString                            = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";
  
  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main
  (
   String[] argv
  )
  {
   Boolean                       booleanParseCommandLineArguments  =  false;
   String                        exceptionMessage                  =  null;

   ShaheedAliArgument            shaheedAliArgument                =  null;
   
   shaheedAliArgument = new ShaheedAliArgument();
   
   booleanParseCommandLineArguments =  UtilityParseCommandLineArgument.ParseCommandLineArguments
   ( 
    argv, 
    shaheedAliArgument
   );

   if ( booleanParseCommandLineArguments == false )
   {
    // error encountered in arguments. Display usage message
    System.Console.Write
    (
     UtilityParseCommandLineArgument.CommandLineArgumentsUsage( typeof ( ShaheedAliArgument ) )
    );
    return;
   }//if ( booleanParseCommandLineArguments  == false )

   #if (DEBUG)
    System.Console.WriteLine
    (
     "Argument filenameXMLDocument: {0} | filenameXMLSchema: {1} Files: {2}",
     shaheedAliArgument.filenameXMLDocument,
     shaheedAliArgument.filenameXMLSchema,
     shaheedAliArgument.files
    );
   #endif

   UtilityShaheedAli
   (
    ref FilenameConfigurationXml,
    ref DatabaseConnectionString,
    ref shaheedAliArgument,
    ref exceptionMessage
   );
   
  }//static void Main( String[] argv ) 

  ///<summary>UtilityShaheedAli</summary>
  public static void UtilityShaheedAli
  (
   ref String              filenameConfigurationXml,
   ref String              databaseConnectionString,
   ref ShaheedAliArgument  shaheedAliArgument,
   ref String              exceptionMessage
  )
  {
   
   string               title;
   string               uri;
   
   DateTime             dated;
   
   XmlReaderSettings    xmlReaderSettings    =  null;
   XmlReader            xmlReader            =  null;

   URIWordEngineering   uRIWordEngineering   =  null;
   
   try
   {
    for ( int filenameXMLSchemaCount = 0; filenameXMLSchemaCount < shaheedAliArgument.filenameXMLSchema.Length; ++filenameXMLSchemaCount)
    {
     System.Console.WriteLine
     (
      "FilenameXMLSchema[{0}]: {1}",
      filenameXMLSchemaCount,
      shaheedAliArgument.filenameXMLSchema[ filenameXMLSchemaCount ]
     );
    }//for ( int filenameXMLSchemaCount = 0; filenameXMLSchemaCount < shaheedAliArgument.filenameXMLSchema.Length; ++filenameXMLSchemaCount)

    for ( int filenameXMLDocumentCount = 0; filenameXMLDocumentCount < shaheedAliArgument.filenameXMLDocument.Length; ++filenameXMLDocumentCount)
    {
     System.Console.WriteLine
     (
      "FilenameXMLDocument[{0}]: {1}",
      filenameXMLDocumentCount,
      shaheedAliArgument.filenameXMLDocument[ filenameXMLDocumentCount ]
     );
    }//for ( int filenameXMLDocumentCount = 0; filenameXMLDocumentCount < shaheedAliArgument.filenameXMLDocument.Length; ++filenameXMLDocumentCount)

    xmlReaderSettings = new XmlReaderSettings();
   
    foreach( string xmlSchema in shaheedAliArgument.filenameXMLSchema )
    {
   	 //xmlReaderSettings.Schemas.Add( xmlSchema );
    }

    //The XmlReader and XmlWriter implementations returned by the static Create methods are conformant by default. The XmlReader created by default has a ConformanceLevel set to "Document," meaning that it attempts to read the XML as a document. You can also set the ConformanceLevel to "Auto," meaning that it automatically attempts to either read the XML as a document or a fragment depending on the type of nodes encountered.
    xmlReaderSettings.ConformanceLevel = ConformanceLevel.Auto;

    //xmlReaderSettings.DtdValidate    = true;

    xmlReaderSettings.IgnoreWhitespace = true;
    
    //xmlReaderSettings.XsdValidate    = true;
    xmlReaderSettings.ValidationType   = ValidationType.Schema;
   
    xmlReaderSettings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

    /*
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent=true;
    settings.NewLineOnAttributes=true;
    XmlWriter writer = XmlWriter.Create(@"c:\output.xml",settings);
    */

    foreach( string xmlDocument in shaheedAliArgument.filenameXMLDocument )
    {
     xmlReader = XmlReader.Create( xmlDocument );
     xmlReader = XmlReader.Create( xmlDocument, xmlReaderSettings );  

     /*
     while ( xmlReader.Read() ) 
     {
      if ( xmlReader.NodeType == XmlNodeType.Element )
      {
       switch ( xmlReader.Name )
       {
        case "uri":
         uri = xmlReader.ReadInnerXml();
         System.Console.WriteLine("uri: {0}", uri);
         break;
         
        case "title":
         title = xmlReader.ReadInnerXml();
         System.Console.WriteLine("title: {0}", title);
         break;
         
        case "dated":
         dated = XmlConvert.ToDateTime( xmlReader.ReadInnerXml() );
         System.Console.WriteLine("dated: {0}", dated);
         break;
       }//switch ( xmlReader.Name )  
      }//if ( xmlReader.NodeType == XmlNodeType.Element )
     }//while ( xmlReader.Read())
     */

     while ( xmlReader.Read() )
     {
      if (xmlReader.IsStartElement() && xmlReader.Name == "uri")
      {
       uri = xmlReader.ReadElementString();
       System.Console.WriteLine("uri: {0}", uri);
      } 

      if (xmlReader.IsStartElement() && xmlReader.Name == "title")
      {
       title = xmlReader.ReadElementString();
       System.Console.WriteLine("title: {0}", title);
      }

      if (xmlReader.IsStartElement() && xmlReader.Name == "dated")
      {
       dated = XmlConvert.ToDateTime( xmlReader.ReadElementString() );
       System.Console.WriteLine("dated: {0}", dated);
      }

     }//while ( xmlReader.Read() )
     
     /*
     xmlReader.MoveToContent(); 
     if (xmlReader.ReadToDescendant("URIWordEngineering"))
     {
      do
      {
       uRIWordEngineering = (URIWordEngineering)(xmlReader.ReadAsObject(typeof(URIWordEngineering)));
       System.Console.WriteLine("uri: {0}", uri);
       System.Console.WriteLine("title: {0}", title);
       System.Console.WriteLine("dated: {0}", dated);        
      }while (xmlReader.ReadToNextSibling("URIWordEngineering")); 
     }//if (xmlReader.ReadToDescendant("URIWordEngineering"))
     */

    }//foreach( string xmlDocument in shaheedAliArgument.filenameXMLDocument )
   }//try
   catch (System.Xml.XmlException e) 
   {
    System.Console.WriteLine(e.Message);
   }
   catch (Exception e) 
   {
    System.Console.WriteLine(e.Message);
   }
  }//public static void UtilityShaheedAli  	

  /// <summary>ValidationEventHandler</summary>
  static void ValidationEventHandler
  (
   object sender, 
   ValidationEventArgs e
  )
  {
   if (e.Severity == XmlSeverityType.Warning)
   {
    System.Console.Write("WARNING: ");
    System.Console.WriteLine(e.Message);
   }
   else if (e.Severity == XmlSeverityType.Error)
   {
    System.Console.Write("ERROR: ");
    System.Console.WriteLine(e.Message);
   }
  }//static void ValidationEventHandler
 
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
  
  static ShaheedAli()
  {
   ConfigurationXml();
  }//static ShaheedAli()
  
 }//public class ShaheedAli
 
}//namespace WordEngineering