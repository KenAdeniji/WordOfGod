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

using  WordEngineering;

namespace WordEngineering
{

 /// <summary>CatalogNorthWindProductsPage page.</summary>
 /// <remarks>CatalogNorthWindProductsPage page.</remarks>
 public class CatalogNorthWindProductsPage : Page
 {

  /// <summary>The database connection string.</summary>
  public String          databaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";
  
  /// <summary>The configuration XML filename.</summary>
  public String          filenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The root node.</summary>
  public String          nodeRoot                       = @"wordOfGod";

  /// <summary>The server map path.</summary>
  public String          serverMapPath                  = null;

  /// <summary>The GridView.</summary>
  protected System.Web.UI.WebControls.GridView          GridViewCatalogNorthWindProducts;

  /// <summary>The LiteralFeedback.</summary>
  protected System.Web.UI.WebControls.Literal           LiteralFeedback;

  /// <summary>The XPath database connection String.</summary>
  public static String   XPathDatabaseConnectionString  = @"/word/database/sqlServer/northWind/databaseConnectionString";

  private void BindGrid()
  {
   String   exceptionMessage  =  null;
   DataSet  dataSet           =  null;
   
   UtilityDatabase.DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,
    ref dataSet,
        "Select * from NorthWind..products",
        CommandType.Text
   );
   
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;   	
   }

   GridViewCatalogNorthWindProducts.DataSource=dataSet;
   GridViewCatalogNorthWindProducts.DataBind();
   
  }

  private void Page_Load
  (
   object sender, 
   System.EventArgs e
  )
  {
   String    exceptionMessage = null;
  
   serverMapPath = this.MapPath("");
   if ( serverMapPath != null)
   {
    filenameConfigurationXml = serverMapPath + @"\" + filenameConfigurationXml;
   }//if ( serverMapPath != null)
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,         
         XPathDatabaseConnectionString,
     ref databaseConnectionString
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;   	
   }

   if ( !Page.IsPostBack )
   {
    BindGrid();
   }//if ( !Page.IsPostBack )

  }//private void Page_Load()

  /// <summary>Feedback.</summary>
  public String Feedback
  {
   get
   {
    return ( LiteralFeedback.Text.Trim() );
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public String Feedback

  private void GridViewCatalogNorthWindProducts_SelectedIndexChanged
  (
   object sender, 
   System.EventArgs e
  )
  {
   System.Web.HttpCookie  httpCookie   =  null;
   String                 itemdetails  =  null;   
   if ( HttpContext.Current.Request.Cookies["shoppingcart"] == null )
   {
   	httpCookie  =  new System.Web.HttpCookie("shoppingcart");
   }	 
   else
   {
    httpCookie  =  HttpContext.Current.Request.Cookies["shoppingcart"];
   } 
   itemdetails  =  GridViewCatalogNorthWindProducts.SelectedItem.Cells[1].Text + "|" + GridViewCatalogNorthWindProducts.SelectedItem.Cells[2].Text + "|" + GridViewCatalogNorthWindProducts.SelectedItem.Cells[3].Text;
   httpCookie.Values[GridViewCatalogNorthWindProducts.SelectedItem.Cells[1].Text]=itemdetails;
   Response.Cookies.Add( httpCookie );
  }
 }//public class CatalogNorthWindProductsPage : Page()

}
  