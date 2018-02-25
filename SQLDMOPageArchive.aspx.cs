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

using SQLDMOTypeLib;

namespace WordEngineering
{
 /// <summary>SQLDMO page.</summary>
 /// <remarks>SQLDMO page.</remarks>
 public class SQLDMOPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string databaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";
  
  /// <summary>The configuration XML filename.</summary>
  public string filenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string serverMapPath                  = null;

  /// <summary>The literal feedback.</summary>  
  protected System.Web.UI.WebControls.Literal   LiteralFeedback;

  /// <summary>The textbox FilenameSQLDMO.</summary>  
  protected System.Web.UI.WebControls.ListBox   ListBoxSQLDMOAdmonish;

  /// <summary>The ButtonAdmonish.</summary>  
  protected System.Web.UI.WebControls.Button   ButtonAdmonish;

  /// <summary>The ButtonAdmonish.</summary>  
  protected System.Web.UI.WebControls.Button   ButtonAdminister;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
  
   string databaseConnectionString = null;
     
   serverMapPath = this.MapPath("");
   if ( serverMapPath != null)
   {
    filenameConfigurationXml = serverMapPath + @"\" + filenameConfigurationXml;
   }//if ( serverMapPath != null)

   if ( !Page.IsPostBack )
   {
    UtilitySQLDMO.ConfigurationFile();
    databaseConnectionString  =  UtilitySQLDMO.DatabaseConnectionString;

    ListBoxSQLDMOAdmonish.DataSource = UtilitySQLDMO.Admonish;
    ListBoxSQLDMOAdmonish.DataBind();
    ListBoxSQLDMOAdmonish.SelectedIndex = 0;
    
   }//if ( !Page.IsPostBack )
  }//Page_Load
  
  /// <summary>DatabaseConnectionString.</summary>
  public string DatabaseConnectionString
  {
   get
   {
    return ( databaseConnectionString );
   }//get 
  }//public string DatabaseConnectionString

  /// <summary>Feedback.</summary>
  public string Feedback
  {
   get
   {
    return ( LiteralFeedback.Text);
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public string Feedback

  /// <summary>SQLDMOAdmonish.</summary>
  public ArrayList SQLDMOAdmonish
  {
   get
   {
    ArrayList admonish = null;
    admonish = new ArrayList();

    foreach( System.Web.UI.WebControls.ListItem listItemCurrent in ListBoxSQLDMOAdmonish.Items )
    {
     admonish.Add( listItemCurrent.Text );
    }                 	
    return ( admonish );
   } 
   set
   {

   }
  }//public string SQLDMOAdmonish

  /// <summary>PageCancel().</summary>
  public void PageCancel()
  {
   Feedback       = "";
  }//PageCancel()	

  /// <summary>PageSubmit().</summary>
  public void PageSubmit()
  {
   string                 exceptionMessage      = null;
   ArrayList              taskList              = null;
   StringBuilder          sb                    = null;
   
   Feedback                                     = "";
   taskList                                     = SQLDMOAdmonish;
   
   UtilitySQLDMO.AdmonishAdminister
   (
    ref taskList,
    ref exceptionMessage,
    ref sb
   );
   
   Feedback = sb.ToString();   
   
  }//PageSubmit()	
  
  /// <summary>ListBoxSQLDMOAdmonish_SelectedIndexChanged(Object sender, EventArgs e).</summary>
  public void ListBoxSQLDMOAdmonish_SelectedIndexChanged(Object sender, EventArgs e) 
  {
     	
  }//void ListBoxSQLDMOAdmonish_SelectedIndexChanged(Object sender, EventArgs e) 

  /// <summary>ButtonAdmonish_Click().</summary>
  public void ButtonAdmonish_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   PageSubmit();  	
  }//public void ButtonAdmonish_Click()

  /// <summary>ButtonAdminister_Click().</summary>
  public void ButtonAdminister_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   PageCancel();
  }//public void ButtonAdminister_Click()
 
 }//SQLDMOPage class.
}//WordEngineering namespace.