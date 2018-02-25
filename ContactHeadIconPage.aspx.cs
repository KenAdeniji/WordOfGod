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

  /// <summary>STYLE_HTML_ANCHOR</summary>
  public const String STYLE_HTML_ANCHOR        = "COLOR: red; FONT_FAMILY: 'Courier New'; BACKGROUND-COLOR: grey";

  /// <summary>HtmlAnchorCardView</summary>
  public HtmlAnchor                                HtmlAnchorCardView;
  
  /// <summary>HtmlAnchorEdit</summary>
  public HtmlAnchor                                HtmlAnchorEdit;

  /// <summary>HtmlAnchorNew</summary>
  public HtmlAnchor                                HtmlAnchorNew;

  /// <summary>HtmlAnchorPutInGroup</summary>
  public HtmlAnchor                                HtmlAnchorPutInGroup;

  /// <summary>HtmlAnchorPrintView</summary>
  public HtmlAnchor                                HtmlAnchorPrintView;

  /// <summary>HtmlAnchorSend</summary>
  public HtmlAnchor                                HtmlAnchorSend;

  /// <summary>HtmlGenericControlTitle</summary>
  public HtmlGenericControl                        HtmlGenericControlTitle;
  
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
  
   if (!Page.IsPostBack)
   {
   	//HtmlGenericControlTitle.InnerText = "";
    //TextBox
    /*
    HtmlAnchorNew.Value                       =  "New";
    HtmlAnchorNew.Attributes["style"]         =  STYLE_HTML_ANCHOR;
    */

   }//if (!Page.IsPostBack)
  }//public void Page_Load

  /// <summary>Image_Click().</summary>
  public void Image_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   int        iSectionID  =  -1;
   String     strID       =  null;

   //strID = (String) ((Control) sender).ID;
   //strID = (String) ((HtmlImage) sender).ID;
   //strID = (String) ((HtmlGenericControl) sender).ID;
   strID = (String) ((System.Web.UI.Control) sender).ID;
	        
   /*
   if (strID.CompareTo(HtmlAnchorNew.ID) == 0)
   {
    iSectionID = 1;
   }
   */
   
   Feedback = strID;
	        
   switch ( strID )
   {
   	case "AnchorNew":
   	 //Response.Redirect( "ContactEditViewWebForm.aspx" );
   	 break;
   	default:
   	 break; 
   }   	
   
  }//public void Image_Click()

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

   /*
   UtilityJavaScript.SetFocus
   ( 
    this,
    DetailsViewContact
   );
   */
  }//public void ButtonReset_Click()
  
 }//ContactHeadIconPage class.
}//WordEngineering namespace.