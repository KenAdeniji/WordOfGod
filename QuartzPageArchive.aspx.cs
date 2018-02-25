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

using QuartzTypeLib;

namespace WordEngineering
{
 /// <summary>Quartz page.</summary>
 /// <remarks>Quartz page.</remarks>
 public class QuartzPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string databaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";
  
  /// <summary>The configuration XML filename.</summary>
  public string filenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string serverMapPath                  = null;

  /// <summary>The literal feedback.</summary>  
  protected System.Web.UI.WebControls.Literal     LiteralFeedback;

  /// <summary>The textbox FilenameQuartz.</summary>  
  protected System.Web.UI.WebControls.TextBox     TextBoxFilenameQuartz;

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
    UtilityQuartz.ConfigurationFile();

    databaseConnectionString  =  UtilityQuartz.DatabaseConnectionString;
   
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

  /// <summary>FilenameQuartz.</summary>
  public string FilenameQuartz
  {
   get
   {
    return ( TextBoxFilenameQuartz.Text.Trim() );
   } 
   set
   {
    TextBoxFilenameQuartz.Text = value;
   }
  }//public string FilenameQuartz

  /// <summary>ButtonPause_Click().</summary>
  public void ButtonPause_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   string   exceptionMessage         = null;
   
   UtilityQuartz.QuartzPause
   (
    ref exceptionMessage
   );
  }

  /// <summary>ButtonPlay_Click().</summary>
  public void ButtonPlay_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   PageSubmit();
  }

  /// <summary>ButtonStop_Click().</summary>
  public void ButtonStop_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   string   exceptionMessage         = null;
   
   UtilityQuartz.QuartzStop
   (
    ref exceptionMessage
   );
  }

  /// <summary>ButtonCancel_Click().</summary>
  public void ButtonCancel_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   PageCancel();
  }
  
  /// <summary>PageCancel().</summary>
  public void PageCancel()
  {

   Feedback       = "";
   FilenameQuartz = "";
   
  }//PageCancel()	

  /// <summary>PageSubmit().</summary>
  public void PageSubmit()
  {
   string[] filenameQuartzCurrent    = null;
   string   exceptionMessage         = null;
   
   filenameQuartzCurrent = new string[] { FilenameQuartz }; 
   Feedback   = "";
   
   UtilityQuartz.QuartzPlay
   (
    ref filenameQuartzCurrent,
    ref exceptionMessage
   );
   
  }//PageSubmit()	
  
 }//QuartzPage class.
}//WordEngineering namespace.