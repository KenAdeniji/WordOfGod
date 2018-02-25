using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>ExcelPage</summary>
 public class ExcelPage : Page
 {

  /// <summary>The database connection String.</summary>
  public static String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public static String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public static String ServerMapPath                  = null;

  /// <summary>ButtonOpen</summary>  
  protected System.Web.UI.WebControls.Button  ButtonOpen;

  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button  ButtonReset;

  /// <summary>ButtonSave</summary>  
  protected System.Web.UI.WebControls.Button  ButtonSave;

  /// <summary>FilenameExcel</summary>
  protected System.Web.UI.WebControls.FileUpload  FilenameExcel;

  /// <summary>GridViewExcel</summary>
  protected System.Web.UI.WebControls.GridView  GridViewExcel;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal  LiteralFeedback;

  /// <summary>SQL</summary>
  protected System.Web.UI.WebControls.TextBox  SQL;

  /// <summary>ExcelFilename</summary>
  protected System.Web.UI.WebControls.FileUpload  ExcelFilename;

  /// <summary>Page Load</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  )
  {
   string exceptionMessage;

   ServerMapPath = this.MapPath("");

   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = Path.Combine( ServerMapPath, FilenameConfigurationXml );
   }

   UtilityExcel.ConfigurationXml
   (
        FilenameConfigurationXml,
    out exceptionMessage,
    ref DatabaseConnectionString
   );
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }
  }

  /// <summary>Feedback</summary>
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
  }

  /// <summary>ButtonOpen_Click</summary>
  public void ButtonOpen_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   OpenExcel();
  }

  /// <summary>ButtonReset_Click</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   SQL.Text = null;
   Feedback = null;
   Page.SetFocus(SQL);
  }

  /// <summary>ButtonSave_Click</summary>
  public void ButtonSave_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   SQLExcel();
  }

  /// <summary>OpenExcel</summary>
  public void OpenExcel()
  {
   string exceptionMessage;
   DataSet dataSet;
   UtilityExcel.ExcelOpen
   (
    FilenameExcel.PostedFile.FileName,
    UtilityExcel.ExcelConnectionType.OLEDB,
    out dataSet,
    out exceptionMessage
   );
   if ( exceptionMessage != null ) { Feedback = exceptionMessage; return; }
   GridViewExcel.DataSource = dataSet;
   GridViewExcel.DataBind();
  }


  /// <summary>SQLExcel</summary>
  public void SQLExcel()
  {
   string exceptionMessage;
   UtilityExcel.SQLExcel
   (
    DatabaseConnectionString,
    SQL.Text,
    FilenameExcel.PostedFile.FileName,
    out exceptionMessage
   );
   if ( exceptionMessage != null ) { Feedback = exceptionMessage; }
  }

 }
}