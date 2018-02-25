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
 /// <summary>Login page.</summary>
 public class LoginPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>LiteralFeedback</summary>  
  protected System.Web.UI.WebControls.Literal  LiteralFeedback;

  /// <summary>LoginUser</summary>  
  protected System.Web.UI.WebControls.Login    LoginUser;

  /// <summary>Feedback</summary>
  public String Feedback
  {
   get
   {
    return ( LiteralFeedback.Text.Trim() );
   }//get 
   set
   {
    LiteralFeedback.Text = value;
   }//set
  }//public String Feedback

  /// <summary>OnLoggedIn</summary>
  public void OnLoggedIn
  (
   object     sender, 
   EventArgs  e
  )
  {
   String userNamePassword = "UserName: " + LoginUser.UserName + " | " + "Password: " + LoginUser.Password;

   Response.Write( userNamePassword );
  
   Feedback = userNamePassword;
   
  }//public void OnLoggedIn()
  
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String     exceptionMessage          =  null;
   
   ServerMapPath = this.MapPath("");
   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)

   /*
   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        UtilityContact.XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );
   */

   if ( exceptionMessage != null )
   {
    Response.Write ( exceptionMessage );
    return;
   }//if ( exceptionMessage != null )

   LoginUser.DestinationPageUrl = string.Format
   (
    "Comforter_-_WordEngineeringIndex.xml?{0}", 
    Request.QueryString.ToString()
   );
   
  }//Page_Load

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   UtilityJavaScript.SetFocus
   ( 
    this,
    LoginUser
   );
  }//public void ButtonReset_Click()

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   
  }//ButtonSubmit_Click()
  
 }//LoginPage class.
}//WordEngineering namespace.