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
 /// <summary>ContactHeadIcon page.</summary>
 public class ContactHeadIconPage : Page
 {

  /// <summary>The database connection string.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  public HtmlAnchor                                HtmlAnchorNew;
  
  /// <summary>LiteralFeedback</summary>  
  protected System.Web.UI.WebControls.Literal      LiteralFeedback;

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

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   int             SequenceOrderIdContact    =  System.Convert.ToInt32( Request.QueryString["SequenceOrderId"] );
  
   String          exceptionMessage          =  null;

   ServerMapPath = this.MapPath("");
   
   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,
        UtilityContact.XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );

   if ( exceptionMessage != null )
   {
    //Response.Write ( exceptionMessage );
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )
  
  }

  /// <summary>ButtonSubmitDetailsView_Click().</summary>
  public void ButtonSubmitDetailsView_Click()
  (
   Object sender, 
   EventArgs e
  )
  {
   int     iSectionID = -1;
   String  strID = null;
	        
	        
   strID = (String) ((Control) sender).ID;
	        
   if (strID.CompareTo(AnchorLookupMonitoringTool.ID) == 0)
   {
    iSectionID = 1;
   }
   
   Feedback = strID;
  }//public void ButtonSubmitDetailsView_Click()

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

  }
  

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback             =  null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    DetailsViewContact
   );
  }//public void ButtonReset_Click()
  
 }//ContactHeadIconPage class.
}//WordEngineering namespace.