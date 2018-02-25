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
 /// <summary>InEve page.</summary>
 public class InEvePage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=InEve;";

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

  /// <summary>HtmlInputFileHoned.</summary>  
  protected System.Web.UI.HtmlControls.HtmlInputFile     HtmlInputFileHoned;

  /// <summary>LabelFileInEve</summary>
  protected System.Web.UI.WebControls.Label              LabelInEve;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal            LiteralFeedback;

  /// <summary>DataGridInEve.</summary>  
  protected System.Web.UI.WebControls.DataGrid           DataGridInEve;

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
   
   FileOpen();
   
   //ButtonSubmit.Attributes("onclick") = GetCloseWindowScript()
   
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
  }//public String Feedback

  /// <summary>Honed.</summary>
  public String Honed
  {
   get
   {
    return ( HtmlInputFileHoned.PostedFile.FileName );
   } 
   set
   {
    //HtmlInputFileHoned.Text = value;
   }
  }//public String Honed

  /// <summary>InEve.</summary>
  public String InEve
  {
   get
   {
    return ( LabelInEve.Text);
   } 
   set
   {
    LabelInEve.Text = value;
   }
  }//public String InEve

  /// <summary>FileOpen().</summary>
  public void FileOpen()
  {

   String          exceptionMessage  =  null;
   String          filenameHoned     =  null;
   String          fileText          =  null;
   
   StreamReader    streamReader      =  null;

   filenameHoned = Honed;
   
   if ( filenameHoned == null || filenameHoned == String.Empty )
   {
    filenameHoned = ServerMapPath + @"\" + Request.QueryString["FileName"];
   }
   
   if ( filenameHoned != null )
   {
    filenameHoned = filenameHoned.Trim();
   }//if ( filenameHoned != null )
   
   if ( !File.Exists( filenameHoned ) )
   {
    return;   	
   }//if ( !File.Exists( filenameHoned ) )   	

   try
   {
   	streamReader = File.OpenText( filenameHoned );

    if ( streamReader != null )
    {
     fileText     = streamReader.ReadToEnd();
   	 streamReader.Close();
   	}//if ( streamReader != null ) 

  	if ( fileText != null )
   	{
   	 InEve    = "<pre>" + fileText + "</pre>";
   	}//if ( fileText != null )

   }//try
   catch ( Exception exception )
   {
    exceptionMessage = exception.Message;           	
   }//catch ( Exception exception )   	

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )
   
  }//FileOpen()
  
  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   FileOpen();
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback        =  null;
   Honed           =  null;
   InEve           =  null;  
 
   UtilityJavaScript.SetFocus
   ( 
    this,
    HtmlInputFileHoned
   );

  }//public void ButtonReset_Click()
  
 }//InEvePage class.
}//InEve namespace.