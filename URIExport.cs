using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace WordEngineering
{
 ///<summary>URI Export.</summary>
 ///<remarks>Export the URI XML Files.</remarks>
 public class URIExport
 {
  
  public const int DatabaseColumnDated             = 0;
  public const int DatabaseColumnKeyword           = 1;
  public const int DatabaseColumnTitle             = 2;
  public const int DatabaseColumnUri               = 3;
    
  
  public const string AboutBlank                   = "about:blank";
  
  ///<summary>The database connection string.</summary>
  public const string DatabaseConnectionString               =  "Provider=SQLOLEDB; Data Source=localhost; Integrated Security=SSPI; Initial Catalog=URI";

  public const string filenameUriHtmlChrist                  = "Comforter_-_URIChrist.html";
  public const string filenameUriHtmlWordEngineering         = "Comforter_-_URIWordEngineering.html";

  public const string filenameUriTextChrist                  = "Comforter_-_URIChrist.txt";
  public const string filenameUriTextWordEngineering         = "Comforter_-_URIWordEngineering.txt";

  public const string filenameUriXmlChrist                   = "Comforter_-_URIChrist.xml";
  public const string filenameUriXmlWordEngineering          = "Comforter_-_URIWordEngineering.xml";

  public const string filenameUriXmlChrist2                  = "Comforter_-_URIChrist2.xml";
  public const string filenameUriXmlWordEngineering2         = "Comforter_-_URIWordEngineering2.xml";

  public const string filenameUriXsdChrist                   = "Comforter_-_URIChrist.xsd";
  public const string filenameUriXsdWordEngineering          = "Comforter_-_URIWordEngineering.xsd";

  public const string filenameUriXsltChrist                  = "Comforter_-_URI.xslt";
  public const string filenameUriXsltWordEngineering         = "Comforter_-_URI.xslt";

  public const string selectQueryUriChrist                   = "Select dated, keyword, title, uri From URIChrist (NoLock) Order by Title";
  public const string selectQueryUriWordEngineering          = "Select dated, Keyword, title, uri From UrIWordEngineering (NoLock) Order by Title";  

  public static void Main(string[] args)
  {
   int              argumentCount     =  args.Length;
   String           exceptionMessage  =  null;
   OleDbConnection  oleDbConnection   =  null;
   
   //Open the database connection.
   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize( DatabaseConnectionString, ref exceptionMessage );
   
   TableProcessURI
   ( 
     ref oleDbConnection,
         selectQueryUriChrist,          
         filenameUriHtmlChrist,
         filenameUriTextChrist,
         filenameUriXsdChrist,          
         filenameUriXmlChrist,
         filenameUriXmlChrist2,
         filenameUriXsltChrist
   );
   
   TableProcessURI
   ( 
     ref oleDbConnection,
         selectQueryUriWordEngineering, 
         filenameUriHtmlWordEngineering,
         filenameUriTextWordEngineering,  
         filenameUriXsdWordEngineering,                       
         filenameUriXmlWordEngineering,
         filenameUriXmlWordEngineering2,     
         filenameUriXsltWordEngineering
   );
  
   //Close the database connection.
   UtilityDatabase.DatabaseConnectionHouseKeeping( oleDbConnection, ref exceptionMessage );
   
  }//Main()
  
  public static void TableProcessURI
  (
   ref OleDbConnection  oleDbConnection,
       String           selectQuery,
       String           filenameHtml,
       String           filenameText,   
       String           filenameXsd,
       String           filenameXml,
       String           filenameXml2,
       String           filenameStylesheet
  )
  {
   DataColumn                dataColumnDated               =  null;
   DataColumn                dataColumnKeyword             =  null;  
   DataColumn                dataColumnTitle               =  null;
   DataColumn                dataColumnURI                 =  null;
   DataSet                   dataSet                       =  null;
   DataTable                 dataTable                     =  null;

   String                    exceptionMessage              =  null;
   String                    keyword                       =  null;   
   String                    title                         =  null;
   String                    uri                           =  null;
   String                    xmlProcessingInstructionText  =  null;

   OleDbCommand              oleDbCommand                  =  null;
   IDataAdapter              oleDataAdapter                =  null;
   IDataReader               dataReader                    =  null;
   //System.IO.FileStream    fileStream                    =  null;                
   TextWriter                objTextWriterHtml             =  null;
   TextWriter                objTextWriterText             =  null;
   UniqueConstraint          uniqueConstraint              =  null;   
   Uri                       objUri                        =  null;
   XmlNode                   xmlNodeDocumentType           =  null;   
   XmlNode                   xmlNodeRoot                   =  null;      
   XmlDocument               xmlDocument                   =  null;
   XmlProcessingInstruction  xmlProcessingInstruction      =  null;
   XmlTextWriter             xmlTextWriter                 =  null;

   try
   {

    UtilityDatabase.DatabaseQuery
    (
         DatabaseConnectionString,
     ref exceptionMessage,
     ref dataSet,
         selectQuery,
         CommandType.Text
    );

    dataSet.DataSetName         = "addresses";
    dataSet.Tables[0].TableName = "address";

    UtilityXml.WriteXml
    (
         dataSet,
     ref exceptionMessage,
     ref filenameXml,
     ref filenameStylesheet
    );
          
   }//try
   catch ( XmlException exception )
   {
    System.Console.WriteLine("Uri: {0} | Exception: {1}", title, exception.Message);
   }//catch
   catch ( Exception exception )
   {
    System.Console.WriteLine("Uri: {0} | Exception: {1}", title, exception.Message);
   }//catch
   finally
   {
   }//finally
  }//TableProcessURI
  
 }//URIExport class.
}//WordEngineering Namespace.
