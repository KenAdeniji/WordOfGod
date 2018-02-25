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
 /// <summary>SearchUserControl</summary>
 public partial class SearchUserControl : System.Web.UI.UserControl
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>ButtonSearch</summary>  
  protected System.Web.UI.WebControls.Button              ButtonSearch;

  /// <summary>TextBoxInput</summary>  
  protected System.Web.UI.WebControls.TextBox             TextBoxInput;

  /// <summary>resultsPerPage</summary>  
  private int resultsPerPage;
  
  [Personalizable]
  public int ResultsPerPage
  {
   get
   {
    return resultsPerPage;
   }
    
   set
   {
    resultsPerPage = value;
   }
  }//public int ResultsPerPage    
  
 }//SearchUserControl class.
}//WordEngineering namespace.