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
 /// <summary>PieChartPage page.</summary>
 public class PieChartPage : Page
 {

  /// <summary>The database connection string.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>HtmlInputPieChart</summary>  
  protected System.Web.UI.HtmlControls.HtmlImage           HtmlImagePieChart;

  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button               ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button               ButtonSubmit;

  /// <summary>ImagePieChart</summary>  
  protected System.Web.UI.WebControls.Image                ImagePieChart;

  /// <summary>The exception message</summary>
  protected System.Web.UI.WebControls.Literal              LiteralFeedback;

  /// <summary>TextBoxSQLSelectStatement</summary>  
  protected System.Web.UI.WebControls.TextBox              TextBoxSQLSelectStatement;

  /// <summary>TextBoxPieChartTitle</summary>  
  protected System.Web.UI.WebControls.TextBox              TextBoxPieChartTitle;

  /// <summary>TextBoxPieChartWidth</summary>  
  protected System.Web.UI.WebControls.TextBox              TextBoxPieChartWidth;

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

   PieChart.ConfigurationXml
   (
        FilenameConfigurationXml,
    ref exceptionMessage,
    ref DatabaseConnectionString
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

  }//Page_Load

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
  }//public string public string Feedback

  /// <summary>PieChartTitle.</summary>
  public String PieChartTitle
  {
   get
   {
    return ( TextBoxPieChartTitle.Text);
   } 
   set
   {
    TextBoxPieChartTitle.Text = value;
   }
  }//public String PieChartTitle

  /// <summary>PieChartWidth</summary>
  public String PieChartWidth
  {
   get
   {
    return ( TextBoxPieChartWidth.Text);
   } 
   set
   {
    TextBoxPieChartWidth.Text = value;
   }
  }//public String PieChartWidth

  /// <summary>PieChartWidthInt</summary>
  public int PieChartWidthInt
  {
   get
   {
   	String  pieChartWidth     =  PieChartWidth;
   	int     pieChartWidthInt  =  -1;
   	
   	pieChartWidth             =  pieChartWidth.Trim();

    if ( pieChartWidth != null && PieChartWidth != "")
    {
     pieChartWidthInt  =  System.Convert.ToInt32( pieChartWidth );
    }//if ( pieChartWidth != null && PieChartWidth != "")
    
    return ( pieChartWidthInt );
   } 
   set
   {
   	String  pieChartWidth     =  System.Convert.ToString( value );
    TextBoxPieChartWidth.Text =  pieChartWidth;
   }
  }//public Int PieChartWidthInt

  /// <summary>SQLSelectStatement.</summary>
  public String SQLSelectStatement
  {
   get
   {
    return ( TextBoxSQLSelectStatement.Text);
   } 
   set
   {
    TextBoxSQLSelectStatement.Text = value;
   }
  }//public String TextBoxSQLSelectStatement

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object    sender, 
   EventArgs e
  )
  {

   String   exceptionMessage  =  null;
   DataSet  dataSet           =  null;

   try
   {

    PieChart.CreatePieChart
    (
     ref  DatabaseConnectionString,
          SQLSelectStatement,
          Title,
          PieChartWidthInt,
     ref  dataSet,
     ref  exceptionMessage
    );
    
   }//try
   catch ( Exception exception )
   {
   	System.Console.WriteLine("Exception: " + exception.Message);
   }   	
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback  =  null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxSQLSelectStatement
   );
  }//public void ButtonReset_Click()
  
 }//PieChartPage class.
}//WordEngineering namespace.