using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace WordEngineering
{
 /// <summary>URIXMLPage.</summary>
 public class URIXMLPage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString                  = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=URI;";

  /// <summary>The database SQL Select.</summary>
  public String DatabaseSQLSelect                         = "Select URI, Title, Keyword, Dated FROM URIChrist";
  
  /// <summary>The configuration XML filename.</summary>
  public String            FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The XML filename stylesheet.</summary>
  public String            FilenameXmlStylesheet          = @"Comforter_-_URI.xslt";

  /// <summary>The server map path.</summary>
  public String            ServerMapPath                  = null;

  /// <summary>The XPath database connection String.</summary>
  public const  String     XPathDatabaseConnectionString  = @"/word/database/sqlServer/bible/databaseConnectionString";  

  /// <summary>The XPath SQL Select.</summary>
  public const  String     XPathSQLSelect                 = @"/word/URI/URIChrist/SQLSelect";  

  /// <summary>PrimaryKeyColumn.</summary>
  public static String[]   PrimaryKeyColumn               = new String[] { "URI" };

  /// <summary>The XPath XML Stylesheet.</summary>
  public const  String     XPathXmlStylesheet             = @"/word/URI/XmlStylesheet";  

  /// <summary>ButtonInsert.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonInsert;

  /// <summary>ButtonOpen.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonOpen;

  /// <summary>ButtonOpen.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonSave;

  /// <summary>HtmlInputFileURI.</summary>  
  protected HtmlInputFile  HtmlInputFileURI;

  /// <summary>PlaceHolderURI.</summary>  
  protected System.Web.UI.WebControls.PlaceHolder  PlaceHolderURI;

  /// <summary>XmlURI.</summary>  
  protected System.Web.UI.WebControls.Xml          XmlURI;

  /// <summary>The exception message.</summary>
  protected Literal        LiteralFeedback;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   PageBuild();
  }//Page_Load

  /// <summary>PageBuild.</summary>
  public void PageBuild()
  {
   String              exceptionMessage                =  null;
   
   ServerMapPath = this.MapPath("");
   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        XPathSQLSelect,
    ref DatabaseSQLSelect
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        XPathXmlStylesheet,
    ref FilenameXmlStylesheet
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

  }//PageBuild()
  
  /// <summary>Feedback.</summary>
  public String Feedback
  {
   get
   {
    return ( LiteralFeedback.Text);
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public String public String Feedback

  /// <summary>URIFile.</summary>
  public String URIFile
  {
   get
   {
    return ( HtmlInputFileURI.Value );
   } 
   set
   {
    HtmlInputFileURI.Value = value;
   }
  }//public String URIFile

  /// <summary>ButtonAdd_Click().</summary>
  public void ButtonAdd_Click
  (
   Object sender, 
   EventArgs e
  )
  {
 
  }//public void ButtonAdd_Click()

  /// <summary>ButtonNew_Click().</summary>
  public void ButtonNew_Click
  (
   Object sender, 
   EventArgs e
  )
  {
  }//public void ButtonNew_Click()

  /// <summary>ButtonInsert_Open().</summary>
  public void ButtonOpen_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   
  }

  /// <summary>ButtonInsert_Save().</summary>
  public void ButtonSave_Click
  (
   Object    sender, 
   EventArgs e
  )
  {
  }//public void ButtonSave_Click()

  
 }//URIXMLPage class.
}//WordEngineering namespace.