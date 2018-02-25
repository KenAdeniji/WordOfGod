using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.IO;
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
 /// <summary>Honed page.</summary>
 public class HonedPage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Honed;";

  /// <summary>The DatabaseFile.</summary>
  public String DatabaseFile                   = null;

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonReset;

  /// <summary>ButtonSubmit.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonSubmit;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal            LiteralFeedback;

  /// <summary>DataGridHoned.</summary>  
  protected System.Web.UI.WebControls.DataGrid           DataGridHoned;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   ServerMapPath = this.MapPath("");

   /* 
   FilenameConfigurationXml = Server.MapPath( FilenameConfigurationXml );
   */

   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)
   
   Honed();
   
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
  }//public String public String Feedback

  /// <summary>Honed().</summary>
  public void Honed()
  {

   String          exceptionMessage  =  null;
  
   DirectoryInfo   directoryInfo     =  null;

   try
   {
    directoryInfo = new DirectoryInfo( ServerMapPath );
    DataGridHoned.DataSource = directoryInfo.GetFiles();
    DataGridHoned.DataBind();
   }
   catch ( Exception exception )
   {
    exceptionMessage = exception.Message;           	
   }//catch ( Exception exception )   	

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )
   
  }//Honed()
  
  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Honed();
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback        =  null;
 
   UtilityJavaScript.SetFocus
   ( 
    this,
    DataGridHoned
   );

  }//public void ButtonReset_Click()
  
  /// <summary>WindowOpen().</summary>
  public static String WindowOpen
  (
   String URI,
   String Option
  )
  {
   return
   ( 
    UtilityJavaScript.WindowOpen(URI, Option)
   ); 
  }
  
 }//HonedPage class.
}//Honed namespace.