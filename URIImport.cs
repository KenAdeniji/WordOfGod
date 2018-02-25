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
 ///<summary>URI Import.</summary>
 ///<remarks>Import the URI XML Files.</remarks>
 public class URIImport
 {
  
  ///<summary>The import configuration filename pattern.</summary>
  public const int ImportConfigurationFileNamePattern      =  0;  
  
  ///<summary>The import configuration stored procedure name.</summary>  
  public const int ImportConfigurationStoredProcedureName  =  1;  
  
  ///<summary>about:blank</summary>  
  public const string AboutBlank                           = "about:blank";

  ///<summary>The database column name for dated.</summary>    
  public const string NameDated              =  "dated";

  ///<summary>The database column name for Jehovah.</summary>    
  public const string NameJehovah            =  "jehovah";

  ///<summary>The database column name for the keyword.</summary>
  public const string NameKeyword            =  "keyword";
  
  ///<summary>The database column name for the title.</summary>  
  public const string NameTitle              =  "title";
  
  ///<summary>The database column name for the URI.</summary>    
  public const string NameURI                =  "uri";

  ///<summary>The database column name for the status.</summary>
  public const string NameStatus             =  "status";

  ///<summary>The database parameter name for dated.</summary>    
  public const string ParameterDated         =  "@dated";

  ///<summary>The database parameter name for Jehovah.</summary>    
  public const string ParameterJehovah       =  "@jehovah";
  
  ///<summary>The database parameter name for the keyword.</summary>      
  public const string ParameterKeyword       =  "@keyword";
  
  ///<summary>The database parameter name for the title.</summary>        
  public const string ParameterTitle         =  "@title";
  
  ///<summary>The database parameter name for the URI.</summary>          
  public const string ParameterURI           =  "@uri";

  ///<summary>The database parameter name for the URI Status.</summary>          
  public const string ParameterStatus        =  "@status";

  ///<summary>The database parameter name for the GUID (unique identifier).</summary>          
  public const string ParameterGuid          =  "@guid";

  ///<summary>The database column size for Jehovah.</summary>
  public const int    SizeJehovah            =  8000;
  
  ///<summary>The database column size for the keyword.</summary>  
  public const int    SizeKeyword            =  255;

  ///<summary>The database column size for the title.</summary>    
  public const int    SizeTitle              =  255;
  
  ///<summary>The database column size for the URI.</summary>      
  public const int    SizeURI                =  255;

  ///<summary>The database connection string.</summary>
  public const string DatabaseConnectionString         =  "Provider=SQLOLEDB; Data Source=localhost; Integrated Security=SSPI; Initial Catalog=URI";

  ///<summary>The database stored procedure name for Jehovah.</summary>       
  public const string DatabaseStoredProcedureNameJehovah   =  "PopulateJehovah";  

  ///<summary>The database stored procedure name for URIStatus.</summary>       
  public const string DatabaseStoredProcedureNameURIStatus =  "PopulateURIStatus";  

  ///<summary>The XPath expression for the address node.</summary>
  public const string XPathExpressionAddress               =  "descendant::address";

  ///<summary>The Import Configuration.</summary>
  public static string[][]   ImportConfiguration   = {
                                                       new string[] { "Christ",          "PopulateURIChrist" },
                                                       new string[] { "WordEngineering", "PopulateURIWordEngineering" }
                                                     };  

  ///<summary>HTTP 404 - File not found.</summary>
  public const int    URIStatusHTTP404FileNotFound = 404;
                                        
  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main(string[] argv)
  {
   URIImportFile( DatabaseConnectionString, argv );
  }//Main()
 
  ///<summary>The Import File.</summary>
  ///<param name="databaseConnectionString">The database connection string.</param>
  ///<param name="uriImportFileName">The file names to import.</param>
  public static void URIImportFile
  (
   string   databaseConnectionString,
   string[] uriImportFileName
  )
  {
   int                       importConfigurationCount       =  -1;
   int                       importConfigurationTotal       =  -1;
   int                       importType                     =  -1;

   int                       status                         =  -1;

   string                    exceptionMessage               = null;

   /*
   string                    navigatorLocalName             =  null;
   string                    navigatorValue                 =  null;
   */
   
   string                    nodeName                       =  null;
   string                    nodeValue                      =  null;
  
   DateTime                  dated                          =  DateTime.Now;
   
   Guid                      uriStatusGuid                  =  new Guid();
   
   String                    jehovah                        =  null;
   String                    keyword                        =  null;
   String                    title                          =  null;
   String                    uri                            =  null;
   
   OleDbCommand              oleDbCommandJehovah            =  null;
   OleDbCommand              oleDbCommandURI                =  null;
   OleDbCommand              oleDbCommandURIStatus          =  null;   
   
   OleDbConnection           oleDbConnection                = null;
   
   OleDbParameter            oleDbParameterJehovahDated     =  null;
   OleDbParameter            oleDbParameterJehovahJehovah   =  null;
   OleDbParameter            oleDbParameterJehovahURI       =  null;
   
   OleDbParameter            oleDbParameterURIDated         =  null;
   OleDbParameter            oleDbParameterURIKeyword       =  null;
   OleDbParameter            oleDbParameterURITitle         =  null;   
   OleDbParameter            oleDbParameterURIURI           =  null;

   OleDbParameter            oleDbParameterURIStatusDated   =  null;
   OleDbParameter            oleDbParameterURIStatusGuid    =  null;
   OleDbParameter            oleDbParameterURIStatusURI     =  null;
   OleDbParameter            oleDbParameterURIStatusStatus  =  null;   

   OleDbParameterCollection  oleDbParameterCollectionURI    = null;
   
   XmlDocument               xmlDocument                    =  null;
   XmlElement                xmlElementRoot                 =  null;
   XmlNodeList               xmlNodeListAddress             =  null;
   
   try
   {

     //Open the database connection.
     oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize( databaseConnectionString, ref exceptionMessage );

     importConfigurationTotal  =  ImportConfiguration.Length;

     foreach ( String uriImportFileNameCurrent in uriImportFileName )
     {
    
      //Determine the content of the import file based on the filename pattern for example URIChrist or URIWordEngineering
      importType  =  -1;
      for ( importConfigurationCount =  0; importConfigurationCount < importConfigurationTotal; ++importConfigurationCount )
      {
       if ( uriImportFileNameCurrent.IndexOf( ImportConfiguration[importConfigurationCount][ImportConfigurationFileNamePattern] ) > 0 )
       {
        importType = importConfigurationCount;
        break;
       }
      }
      if ( importType < 0 )
      {
       System.Console.WriteLine("{0} file name pattern.", uriImportFileNameCurrent);
       continue;
      }

      if ( !File.Exists(uriImportFileNameCurrent) )
      {
       System.Console.WriteLine("{0} Not Found.", uriImportFileNameCurrent);
       continue; 
      }      	
 
      oleDbCommandJehovah               =  new OleDbCommand( DatabaseStoredProcedureNameJehovah, oleDbConnection );
      oleDbCommandURI                   =  new OleDbCommand( ImportConfiguration[importType][ImportConfigurationStoredProcedureName], oleDbConnection );
      oleDbCommandURIStatus             =  new OleDbCommand( DatabaseStoredProcedureNameURIStatus, oleDbConnection );

      oleDbCommandJehovah.CommandType   =  CommandType.StoredProcedure;
      oleDbCommandURI.CommandType       =  CommandType.StoredProcedure;
      oleDbCommandURIStatus.CommandType =  CommandType.StoredProcedure;      
       
      oleDbParameterJehovahDated        =  oleDbCommandJehovah.Parameters.Add(ParameterDated,    OleDbType.Date);
      oleDbParameterJehovahJehovah      =  oleDbCommandJehovah.Parameters.Add(ParameterJehovah,  OleDbType.VarChar, SizeJehovah);
      oleDbParameterJehovahURI          =  oleDbCommandJehovah.Parameters.Add(ParameterURI,      OleDbType.VarChar, SizeURI);

      oleDbParameterURIDated            =  oleDbCommandURI.Parameters.Add(ParameterDated,        OleDbType.Date);
      oleDbParameterURIKeyword          =  oleDbCommandURI.Parameters.Add(ParameterKeyword,      OleDbType.VarChar, SizeKeyword);
      oleDbParameterURITitle            =  oleDbCommandURI.Parameters.Add(ParameterTitle,        OleDbType.VarChar, SizeTitle);
      oleDbParameterURIURI              =  oleDbCommandURI.Parameters.Add(ParameterURI,          OleDbType.VarChar, SizeURI);

      oleDbParameterURIStatusURI        =  oleDbCommandURIStatus.Parameters.Add(ParameterURI,    OleDbType.VarChar, SizeURI);
      oleDbParameterURIStatusDated      =  oleDbCommandURIStatus.Parameters.Add(ParameterDated,  OleDbType.Date);
      oleDbParameterURIStatusStatus     =  oleDbCommandURIStatus.Parameters.Add(ParameterStatus, OleDbType.Integer);
      oleDbParameterURIStatusGuid       =  oleDbCommandURIStatus.Parameters.Add(ParameterGuid,   OleDbType.Guid);      
    
      oleDbParameterURIStatusGuid.Direction = ParameterDirection.Output;

      oleDbParameterCollectionURI       =  oleDbCommandURI.Parameters;
      
      xmlDocument                       = new XmlDocument();
      xmlDocument.PreserveWhitespace    = false;
      xmlDocument.Load( uriImportFileNameCurrent );

      xmlElementRoot                    =  xmlDocument.DocumentElement;
      xmlNodeListAddress                =  xmlElementRoot.SelectNodes( XPathExpressionAddress );
      
      foreach ( XmlNode xmlNodeAddress in xmlNodeListAddress )
      {
       //Initialize the default values. 
       dated   = DateTime.Now;
       keyword = null;
       status  = URIStatusHTTP404FileNotFound;
       title   = null;
       uri     = AboutBlank;
       
       foreach (XmlNode xmlNodeAddressElement in xmlNodeAddress )
       {
        nodeName = xmlNodeAddressElement.Name;
        nodeValue = xmlNodeAddressElement.InnerText.Trim();
        switch (nodeName)
        {
         case NameDated: 
          if ( nodeValue != string.Empty )
          { 
           dated = XmlConvert.ToDateTime( nodeValue );
          } 
          oleDbParameterJehovahDated.Value = dated;
          oleDbParameterURIDated.Value = dated;
          oleDbParameterURIStatusDated.Value = dated;
          break;

         case NameJehovah: 
          jehovah = nodeValue;
          System.Console.WriteLine("URI: {0} | Jehovah: {1}", uri, jehovah);          
          oleDbParameterJehovahJehovah.Value  =  jehovah;
          oleDbCommandJehovah.ExecuteNonQuery();
          break;

         case NameStatus:
          if ( nodeValue != string.Empty )
          {
           status = XmlConvert.ToInt16( nodeValue );
          }            
          oleDbParameterURIStatusStatus.Value  = status;
          oleDbCommandURIStatus.ExecuteNonQuery();
          uriStatusGuid = new Guid( (oleDbParameterURIStatusGuid.Value).ToString() );
          System.Console.WriteLine
          (
           "URI: {0} | Dated: {1} | Status: {2} | Guid: {3}", 
           uri, 
           dated,
           status,
           uriStatusGuid
          );
          uri = AboutBlank;
          break;

         case NameKeyword: 
          keyword = nodeValue;
          oleDbParameterURIKeyword.Value  =  keyword;          
          break;

         case NameTitle: 
          title = nodeValue;
          oleDbParameterURITitle.Value    =  title;          
          break;

         case NameURI: 
          if ( nodeValue != string.Empty )
          {
           uri = nodeValue;
          } 
          oleDbParameterJehovahURI.Value   = uri;
          oleDbParameterURIURI.Value       = uri;
          oleDbParameterURIStatusURI.Value = uri;
          break;
        }//switch (nodeName) 	
       }//foreach (XmlNode xmlNodeAddressElement in xmlNodeAddress )
       
       if ( uri == AboutBlank ) { continue; }

       foreach ( OleDbParameter oleDbParameter in oleDbParameterCollectionURI )
       {
        System.Console.Write("{0}: {1}|", oleDbParameter, oleDbParameter.Value );
       }//foreach ( OleDbParameter oleDbParameter in oleDbParameterCollectionURI )
       System.Console.WriteLine();             
       oleDbCommandURI.ExecuteNonQuery();
       
      }//foreach ( XmlNode xmlNodeAddress in xmlNodeListAddress )
     }//for ( String URIImportFileNameCurrent in URIImportFileName )  

    //Close the database connection.
    UtilityDatabase.DatabaseConnectionHouseKeeping( oleDbConnection, ref exceptionMessage );

   }//try
   catch( OleDbException oleDbException )
   {
    exceptionMessage = UtilityEventLog.WriteEntryOleDbErrorCollection( oleDbException );
    System.Console.WriteLine("OleDbException: {0}", exceptionMessage);
   }//catch( OleDbException oleDbException )
   catch( IOException ioException )
   {
    System.Console.WriteLine("IOException: {0}", ioException.Message);
   }//catch( OleDbException oleDbException )
   catch( XPathException xPathException )
   {
     System.Console.WriteLine("XPathException: {0}", xPathException.Message );
   }//catch( XPathException xPathException )
   catch( XmlException xmlException )
   {
     System.Console.WriteLine("XMLException: {0}", xmlException.Message );
   }//catch( XmlException xmlException )
   catch( Exception exception )
   {
     System.Console.WriteLine("Exception: {0}", exception.Message );
   }//catch( Exception exception )
  }//URIImportFileName
  
 }//URIImport class.
 
}//WordEngineering Namespace.