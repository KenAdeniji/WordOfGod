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
 /// <summary>MasterSimplePage</summary>
 public partial class MasterSimplePage : System.Web.UI.MasterPage
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>MenuMaster</summary>  
  protected System.Web.UI.WebControls.Menu             MenuMaster;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String  exceptionMessage  =  null;

   ServerMapPath = this.MapPath("");

   /* 
   FilenameConfigurationXml = Server.MapPath( FilenameConfigurationXml );
   */

   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)

   /*
   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        UtilityImage.XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );
   */

   if ( exceptionMessage != null )
   {
    Response.Write( exceptionMessage );
    return;
   }//if ( exceptionMessage != null )

   if ( !Page.IsPostBack )
   {
    //MenuMaster.BackColor = System.Drawing.Color.LemonChiffon;
   }//if ( !Page.IsPostBack )
   	
  }//Page_Load
  
 }//MasterSimplePage class.
}//WordEngineering namespace.