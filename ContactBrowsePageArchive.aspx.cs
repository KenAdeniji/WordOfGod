using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Xml;

namespace WordEngineering
{
 /// <summary>ContactBrowse page.</summary>
 public class ContactBrowsePage : Page
 {

  /// <summary>The database connection string.</summary>
  public string DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>RepeaterContact.</summary>  
  protected System.Web.UI.WebControls.Repeater  RepeaterContact;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String  exceptionMessage          =  null;
   
   ServerMapPath = this.MapPath("");
   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        UtilityContact.XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );

   if ( exceptionMessage != null )
   {
    Response.Write ( exceptionMessage );
    return;
   }//if ( exceptionMessage != null )
   
   ContactQuery();

  }//Page_Load

  /// <summary>ContactQuery()</summary>
  public void ContactQuery()
  {
   String       exceptionMessage = null;
   IDataReader  iDataReader      = null;

   UtilityContact.ContactQuery
   (
    ref DatabaseConnectionString,
    ref exceptionMessage,
    ref iDataReader
   );

   RepeaterContact.DataSource = iDataReader;
   RepeaterContact.DataBind();

   if ( exceptionMessage != null )
   {
    Response.Write ( exceptionMessage );
    return;
   }//if ( exceptionMessage != null )
   
  }//public void RSSFeed()

  /// <summary>FormatForXML.</summary>
  protected String FormatForXML(object input)
  {
   string data = input.ToString();      // cast the input to a string

   // replace those characters disallowed in XML documents
   data = data.Replace("&", "&amp;");
   data = data.Replace("\"", "&quot;");
   data = data.Replace("'", "&apos;");
   data = data.Replace("<", "&lt;");
   data = data.Replace(">", "&gt;");

   return data;
  }//protected String FormatForXML(object input)
  
 }//ContactBrowsePage class.
}//WordEngineering namespace.