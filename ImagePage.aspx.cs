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
 /// <summary>ImagePage page.</summary>
 public class ImagePage : Page
 {

  /// <summary>The database connection string.</summary>
  public string ConnectionStringDatabase       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonReset;

  /// <summary>ButtonSubmit.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonSubmit;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal            LiteralFeedback;

  /// <summary>HtmlInputFileURI.</summary>  
  protected System.Web.UI.HtmlControls.HtmlImage         HtmlImageURI;

  /// <summary>HtmlInputFileURI.</summary>  
  protected System.Web.UI.HtmlControls.HtmlInputFile     HtmlInputFileURI;

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

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

  }//Page_Load

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
  }//public string public string Feedback

  /// <summary>ImageURI.</summary>
  public String ImageURI
  {
   get
   {
    return ( HtmlImageURI.Src );
   } 
   set
   {
    HtmlImageURI.Src = value;
   }
  }//public String ImageURI

  /// <summary>FileURI.</summary>
  public String FileURI
  {
   get
   {
    return ( HtmlInputFileURI.PostedFile.FileName  );
   } 
   set
   {
    //HtmlInputFileURI.PostedFile.FileName = value;
   }
  }//public String FileURI

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   try
   {
    ImageURI = FileURI;
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
   FileURI   =  null;
   ImageURI  =  null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    HtmlInputFileURI
   );
  }//public void ButtonReset_Click()
  
 }//ImagePage class.
}//WordEngineering namespace.