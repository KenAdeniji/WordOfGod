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

 ///<summary>Contact</summary>
 public class Contact
 {

  /// <summary>OrdinalPositionContactSequenceOrderId</summary>
  public static  int        OrdinalPositionContactSequenceOrderId       = 0;

  /// <summary>OrdinalPositionContactFirstName</summary>
  public static  int        OrdinalPositionContactFirstName             = 1;

  /// <summary>OrdinalPositionContactLastName</summary>
  public static  int        OrdinalPositionContactLastName              = 2;

  /// <summary>OrdinalPositionContactOtherName</summary>
  public static  int        OrdinalPositionContactOtherName             = 3;

  /// <summary>OrdinalPositionContactPrefix</summary>
  public static  int        OrdinalPositionContactPrefix                = 4;

  /// <summary>OrdinalPositionContactSuffix</summary>
  public static  int        OrdinalPositionContactSuffix                = 5;

  /// <summary>OrdinalPositionContactCompany</summary>
  public static  int        OrdinalPositionContactCompany               = 6;

  /// <summary>OrdinalPositionContactCommentary</summary>
  public static  int        OrdinalPositionContactCommentary            = 7;

  /// <summary>OrdinalPositionContactScriptureReference</summary>
  public static  int        OrdinalPositionContactScriptureReference    = 8;

  /// <summary>SQLSelectContact</summary>
  public static  String     SQLSelectContact                            = @"SELECT SequenceOrderId, FirstName, LastName, OtherName, Prefix, Suffix, Company, Commentary, ScriptureReference FROM Contact ORDER BY SequenceOrderId";

  /// <summary>SQLSelectContactWhereClause</summary>
  public static  String     SQLSelectContactWhereClause                 = @"SELECT SequenceOrderId, FirstName, LastName, OtherName, Prefix, Suffix, Company, Commentary, ScriptureReference FROM Contact WHERE SequenceOrderId = {0}";

  /// <summary>SQLSelectContactEmailWhereClause</summary>
  public static  String     SQLSelectContactEmailWhereClause            = @"SELECT TheWordId, ContactId, SequenceOrderId, Dated, EmailAddress FROM ContactEmail WHERE ContactId = {0}";

  /// <summary>SQLSelectStreetAddressWhereClause</summary>
  public static  String     SQLSelectStreetAddressWhereClause           = @"SELECT TheWordId, ContactId, SequenceOrderId, Dated, AddressLine1, City, State, ZipCode, Country FROM StreetAddress WHERE ContactId = {0}";

  /// <summary>SQLSelectTelephoneWhereClause</summary>
  public static  String     SQLSelectTelephoneWhereClause               = @"SELECT TheWordId, ContactId, SequenceOrderId, Dated, TelephoneNo, TelephoneLocation FROM Telephone WHERE ContactId = {0}";

  /// <summary>SQLSelectContactURIWhereClause</summary>
  public static  String     SQLSelectContactURIWhereClause              = @"SELECT TheWordId, ContactId, SequenceOrderId, Dated, InternetAddress FROM ContactURI WHERE ContactId = {0}";

  /*
  public static  String     SQLSelectWhereClause[]                      = new String[]
                                                                          {
  "SELECT SequenceOrderId, FirstName, LastName, OtherName, Prefix, Suffix, Company, Commentary, ScriptureReference FROM Contact WHERE SequenceOrderId = {0}",
  "SELECT TheWordId, ContactId, SequenceOrderId, Dated, EmailAddress FROM ContactEmail WHERE ContactId = {0}",
  "SELECT TheWordId, ContactId, SequenceOrderId, Dated, AddressLine1, City, State, ZipCode, Country FROM StreetAddress WHERE ContactId = {0}",
  "SELECT TheWordId, ContactId, SequenceOrderId, Dated, TelephoneNo, TelephoneLocation FROM Telephone WHERE ContactId = {0}",
  "SELECT TheWordId, ContactId, SequenceOrderId, Dated, InternetAddress FROM ContactURI WHERE ContactId = {0}"  
                                                                          };    
  */                                                                          

  /// <summary>SQLUpdateContact</summary>
  public static  String     SQLUpdateContact                            = @"UPDATE Contact SET FirstName=@FirstName, LastName=@LastName, OtherName=@OtherName, Prefix=@Prefix, Suffix=@Suffix, Company=@Company, Commentary=@Commentary, ScripturePreference=@ScriptureReference WHERE SequenceOrderId=@SequenceOrderId";

  /// <summary>SQLUpdateContactArgument</summary>
  public static  String     SQLUpdateContactArgument                    = @"UPDATE Contact SET FirstName={1}, LastName={2}, OtherName={3}, Prefix={4}, Suffix={5}, Company={6}, Commentary={7}, ScripturePreference={8} WHERE SequenceOrderId={0}";

  /// <summary>The database connection string.</summary>
  public static  String     DatabaseConnectionString                    = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public static  String     FilenameConfigurationXml                    = @"WordEngineering.config";

  ///<summary>sequenceOrderId</summary>  
  public int    sequenceOrderId;
  
  ///<summary>firstName</summary>
  public String firstName = null;

  ///<summary>lastName</summary>
  public String lastName = null;

  ///<summary>otherName</summary>
  public String otherName = null;

  ///<summary>company</summary>
  public String company = null;
  
  ///<summary>prefix</summary>
  public String prefix = null;

  ///<summary>suffix</summary>
  public String suffix = null;
  
  ///<summary>commentary</summary>
  public String commentary = null;

  ///<summary>scriptureReference</summary>
  public String scriptureReference = null;

  /// <summary>The XPath database connection string.</summary>
  public const   String     XPathDatabaseConnectionString               = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";

  /// <summary>constructor.</summary>
  public Contact()
  {
  }

  /// <summary>constructor.</summary>
  public Contact
  (
   int sequenceOrderId
  ) 
  {
   this.sequenceOrderId = sequenceOrderId;
  } 

  /// <summary>constructor.</summary>
  public Contact
  (
   int      sequenceOrderId,
   String   firstName,
   String   lastName,
   String   otherName,
   String   prefix,
   String   suffix,
   String   company,   
   String   commentary,
   String   scriptureReference
  ) 
  {
   this.sequenceOrderId    =  sequenceOrderId;
   this.firstName          =  firstName;
   this.lastName           =  lastName;
   this.otherName          =  otherName;
   this.prefix             =  prefix;   
   this.suffix             =  suffix;
   this.company            =  company;
   this.commentary         =  commentary;   
   this.scriptureReference =  scriptureReference;
  }//Contact()
  
  /// <summary>SequenceOrderId</summary>
  public int SequenceOrderId
  {
   get
   {
    return ( sequenceOrderId );
   }//get 
   set
   {
    sequenceOrderId = value;
   }//set
  }//public int SequenceOrderId

  /// <summary>FirstName</summary>
  public String FirstName
  {
   get
   {
    return ( firstName.Trim() );
   }//get 
   set
   {
    firstName = value.Trim();
   }//set
  }//public String FirstName

  /// <summary>LastName</summary>
  public String LastName
  {
   get
   {
    return ( lastName.Trim() );
   }//get 
   set
   {
    lastName = value.Trim();
   }//set
  }//public String LastName

  /// <summary>OtherName</summary>
  public String OtherName
  {
   get
   {
    return ( otherName.Trim() );
   }//get 
   set
   
   {
    otherName = value.Trim();
   }//set
  }//public String OtherName

  /// <summary>FirstName</summary>
  public String Company
  {
   get
   {
    return ( company.Trim() );
   }//get 
   set
   {
    company = value.Trim();
   }//set
  }//public String company

  /// <summary>Prefix</summary>
  public String Prefix
  {
   get
   {
    return ( prefix.Trim() );
   }//get 
   set
   {
    prefix = value.Trim();
   }//set
  }//public String prefix

  /// <summary>Suffix</summary>
  public String Suffix
  {
   get
   {
    return ( suffix.Trim() );
   }//get 
   set
   {
    suffix = value.Trim();
   }//set
  }//public String suffix

  /// <summary>Commentary</summary>
  public String Commentary
  {
   get
   {
    return ( commentary.Trim() );
   }//get 
   set
   {
    commentary = value.Trim();
   }//set
  }//public String commentary

  /// <summary>ScriptureReference</summary>
  public String ScriptureReference
  {
   get
   {
    return ( scriptureReference.Trim() );
   }//get 
   set
   {
    scriptureReference = value.Trim();
   }//set
  }//public String scriptureReference

  /// <summary>DatabaseSelect</summary>
  public static void DatabaseSelect
  (
   ref  String   databaseConnectionString,
   ref  String   exceptionMessage,
   ref  Contact  contact,
   ref  DataSet  dataSet
  )
  {
   StringBuilder  sb          =  null;

   DataColumn     dataColumn  =  null;
   DataRow        dataRow     =  null;   
   DataTable      dataTable   =  null;
   
   sb = new StringBuilder();
   sb.AppendFormat
   (
    SQLSelectContactWhereClause,
    contact.SequenceOrderId
   );

   //UtilityDebug.Write(String.Format("SQL Contact: {0}", sb.ToString()));
   
   UtilityDatabase.DatabaseQuery
   (
         databaseConnectionString,
    ref  exceptionMessage,
    ref  dataSet,
         sb.ToString(),
         CommandType.Text
   );
   
   dataTable    =  dataSet.Tables[0];
   dataRow      =  dataTable.Rows[0];
   dataColumn   =  dataTable.Columns[0];
   //UtilityDebug.Write( String.Format("{0}", dataRow[dataColumn]) );
   
   contact      =  new Contact
   (
    System.Convert.ToInt32(  dataRow[ dataTable.Columns[OrdinalPositionContactSequenceOrderId] ] ), //SequenceOrderId
    System.Convert.ToString( dataRow[ dataTable.Columns[OrdinalPositionContactFirstName] ] ), //FirstName
    System.Convert.ToString( dataRow[ dataTable.Columns[OrdinalPositionContactLastName] ] ), //LastName
    System.Convert.ToString( dataRow[ dataTable.Columns[OrdinalPositionContactOtherName] ] ), //OtherName
    System.Convert.ToString( dataRow[ dataTable.Columns[OrdinalPositionContactPrefix] ] ), //Prefix
    System.Convert.ToString( dataRow[ dataTable.Columns[OrdinalPositionContactSuffix] ] ), //Suffix
    System.Convert.ToString( dataRow[ dataTable.Columns[OrdinalPositionContactCompany] ] ), //Company
    System.Convert.ToString( dataRow[ dataTable.Columns[OrdinalPositionContactCommentary] ] ), //Commentary
    System.Convert.ToString( dataRow[ dataTable.Columns[OrdinalPositionContactScriptureReference] ] )  //ScriptureReference
   );
  }//public void DatabaseSelect()

  /// <summary>DatabaseUpdate</summary>
  public static void DatabaseUpdate
  (
   ref  String   databaseConnectionString,
   ref  String   exceptionMessage,
   ref  Contact  contact   
  )
  {
   StringBuilder  sb  =  null;
   
   sb = new StringBuilder();
   sb.AppendFormat
   (
    SQLUpdateContactArgument,
    contact.SequenceOrderId,
    contact.FirstName,
    contact.LastName,
    contact.OtherName,
    contact.Prefix,
    contact.Suffix,
    contact.Company,
    contact.Commentary,
    contact.ScriptureReference
   );
   
   UtilityDatabase.DatabaseQuery
   (
         databaseConnectionString,
    ref  exceptionMessage,
         sb.ToString()
   );   

   UtilityDebug.Write(String.Format("SQL Contact: {0}", sb.ToString()));
  }//public void DatabaseUpdate()
    
 }//class Contact
}//namespace WordEngineering