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
 /// <summary>SQLServer Enumerator page.</summary>
 /// <remarks>SQLServer Enumerator page.</remarks>
 public class SQLServerEnumeratorPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string databaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";
  
  /// <summary>The configuration XML filename.</summary>
  public string filenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string serverMapPath                  = null;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   foreach ( SqlServer sqlServer in UtilitySQLServerEnumerator._servers )
   {
    Response.Write( sqlServer.Name + "<br/>");
   }
  }//Page_Load
 }//SQLServerEnumeratorPage class.
}//WordEngineering namespace.