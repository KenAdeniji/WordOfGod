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
 /// <summary>ContactGridView page.</summary>
 public class ContactGridViewPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>GridViewContact</summary>  
  protected System.Web.UI.WebControls.GridView  GridViewContact;

  /// <summary>LiteralFeedback</summary>  
  protected System.Web.UI.WebControls.Literal   LiteralFeedback;

  /// <summary>SqlDataSourceContact</summary>  
  protected SqlDataSource                       SqlDataSourceContact;

  /// <summary>Feedback</summary>
  public String Feedback
  {
   get
   {
    return ( LiteralFeedback.Text.Trim() );
   }//get 
   set
   {
    LiteralFeedback.Text = value;
   }//set
  }//public String Feedback

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String          exceptionMessage          =  null;

   SqlDataSource   sqlDataSourceCurrent      =  null;
   
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
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )
   
   try
   {
    SqlDataSourceContact.ConnectionString = DatabaseConnectionString;
    GridViewContact.DataSourceID = SqlDataSourceContact.ID;
    //GridViewContact.DataBind();
        
    /*
    sqlDataSourceCurrent  =  new SqlDataSource();
    sqlDataSourceCurrent.ConnectionString =  DatabaseConnectionString;
    sqlDataSourceCurrent.DataSourceMode   =  SqlDataSourceMode.DataSet;
    sqlDataSourceCurrent.ProviderName     =  "System.Data.OleDb";
    sqlDataSourceCurrent.SelectCommand    =  Contact.SQLSelectContact;
    sqlDataSourceCurrent.UpdateCommand    =  Contact.SQLUpdateContact;
    //sqlDataSourceCurrent.SelectParameters.Add("parameterName", "parameterValue);
    
    GridViewContact.DataSourceID          =  sqlDataSourceCurrent.ID;
    GridViewContact.DataBind();
    */

   }
   catch ( Exception exception )
   {
   	exceptionMessage = exception.Message;
   }
   
   if ( exceptionMessage != null )
   {
    Response.Write ( exceptionMessage );
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

  }//Page_Load

 }//ContactGridViewPage class.
}//WordEngineering namespace.