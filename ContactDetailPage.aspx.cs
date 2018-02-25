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
 /// <summary>ContactDetail page.</summary>
 public class ContactDetailPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>GridViewContactEmail</summary>  
  protected System.Web.UI.WebControls.GridView  GridViewContactEmail;

  /// <summary>GridViewURI</summary>  
  protected System.Web.UI.WebControls.GridView  GridViewContactURI;
  
  /// <summary>GridViewStreetAddress</summary>  
  protected System.Web.UI.WebControls.GridView  GridViewStreetAddress;
  
  /// <summary>GridViewTelephone</summary>  
  protected System.Web.UI.WebControls.GridView  GridViewTelephone;

  /// <summary>LiteralFeedback</summary>  
  protected System.Web.UI.WebControls.Literal  LiteralFeedback;

  /// <summary>TextBoxSequenceOrderId</summary>  
  protected System.Web.UI.WebControls.TextBox  TextBoxSequenceOrderId;

  /// <summary>TextBoxFirstName</summary>  
  protected System.Web.UI.WebControls.TextBox  TextBoxFirstName;

  /// <summary>TextBoxLastName</summary>  
  protected System.Web.UI.WebControls.TextBox  TextBoxLastName;

  /// <summary>TextBoxOtherName</summary>  
  protected System.Web.UI.WebControls.TextBox  TextBoxOtherName;

  /// <summary>TextBoxCompany</summary>  
  protected System.Web.UI.WebControls.TextBox  TextBoxCompany;

  /// <summary>TextBoxPrefix</summary>  
  protected System.Web.UI.WebControls.TextBox  TextBoxPrefix;

  /// <summary>TextBoxSuffix</summary>  
  protected System.Web.UI.WebControls.TextBox  TextBoxSuffix;

  /// <summary>TextBoxCommentary</summary>  
  protected System.Web.UI.WebControls.TextBox  TextBoxCommentary;

  /// <summary>TextBoxScriptureReference</summary>  
  protected System.Web.UI.WebControls.TextBox  TextBoxScriptureReference;

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

  /// <summary>SequenceOrderId</summary>
  public int SequenceOrderId  
  {
   get
   {
    return ( System.Convert.ToInt32(TextBoxSequenceOrderId.Text.Trim() ) );
   }//get 
   set
   {
    TextBoxSequenceOrderId.Text = value.ToString();
   }//set
  }//public int SequenceOrderId
  
  /// <summary>FirstName</summary>
  public String FirstName
  {
   get
   {
    return ( TextBoxFirstName.Text.Trim() );
   }//get 
   set
   {
    TextBoxFirstName.Text = value;
   }//set
  }//public String FirstName

  /// <summary>LastName</summary>
  public String LastName
  {
   get
   {
    return ( TextBoxLastName.Text.Trim() );
   }//get 
   set
   {
    TextBoxLastName.Text = value;
   }//set
  }//public String LastName

  /// <summary>OtherName</summary>
  public String OtherName
  {
   get
   {
    return ( TextBoxOtherName.Text.Trim() );
   }//get 
   set
   {
    TextBoxOtherName.Text = value;
   }//set
  }//public String OtherName

  /// <summary>Company</summary>
  public String Company
  {
   get
   {
    return ( TextBoxCompany.Text.Trim() );
   }//get 
   set
   {
    TextBoxCompany.Text = value;
   }//set
  }//public String Company

  /// <summary>Prefix</summary>
  public String Prefix
  {
   get
   {
    return ( TextBoxPrefix.Text.Trim() );
   }//get 
   set
   {
    TextBoxPrefix.Text = value;
   }//set
  }//public String Prefix

  /// <summary>Suffix</summary>
  public String Suffix
  {
   get
   {
    return ( TextBoxSuffix.Text.Trim() );
   }//get 
   set
   {
    TextBoxSuffix.Text = value;
   }//set
  }//public String Suffix

  /// <summary>Commentary</summary>
  public String Commentary
  {
   get
   {
    return ( TextBoxCommentary.Text.Trim() );
   }//get 
   set
   {
    TextBoxCommentary.Text = value;
   }//set
  }//public String Commentary

  /// <summary>Commentary</summary>
  public String ScriptureReference  {
   get
   {
    return ( TextBoxScriptureReference.Text.Trim() );
   }//get 
   set
   {
    TextBoxScriptureReference.Text = value;
   }//set
  }//public String ScriptureReference
  
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String     exceptionMessage          =  null;
   
   int        sequenceOrderId           =  System.Convert.ToInt32( Request.QueryString["SequenceOrderId"] );
   
   DataSet    dataSetContact            =  null;
   DataSet[]  dataSetMultiple           =  new DataSet[ UtilityContact.SQLSelectContactDetailGridView.Length ];
      
   Contact    contact                   =  null;
   
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
    Response.Write ( exceptionMessage );
    return;
   }//if ( exceptionMessage != null )
   
   UtilityContact.ContactDetail
   (
        DatabaseConnectionString,
    ref exceptionMessage,
    ref dataSetContact,
    ref sequenceOrderId,
    ref contact,
    ref dataSetMultiple
   );

   Session["contact"] = contact;
   Session["dataSetMultiple"] = dataSetMultiple;   

   if ( exceptionMessage != null )
   {
    Response.Write ( exceptionMessage );
    return;
   }//if ( exceptionMessage != null )

   /*
   UtilityDatabase.PrintValues( dataSet );
   
   Response.Write( dataSet.Tables.Count );
   Response.Write( dataSet.Tables["Table"].Rows.Count );
   */
   
   if ( Page.IsPostBack )
   {
   	return;
   }

   PageRefresh();
  
  }//Page_Load

  /// <summary>PageRefresh().</summary>
  public void PageRefresh()
  {

   DataSet[]  dataSetMultiple       =  (DataSet[]) Session["dataSetMultiple"];

   Contact contact = (Contact) Session["contact"];
   
   SequenceOrderId = contact.SequenceOrderId;
   FirstName = contact.FirstName;
   LastName = contact.LastName;
   OtherName = contact.OtherName;
   Company = contact.Company;
   Prefix = contact.Prefix;
   Suffix = contact.Suffix;
   Commentary = contact.Commentary;
   ScriptureReference = contact.ScriptureReference;
   
   GridViewContactEmail.DataSource  =  dataSetMultiple[0];
   GridViewContactEmail.DataBind();

   GridViewContactURI.DataSource    =  dataSetMultiple[1];
   GridViewContactURI.DataBind();

   GridViewTelephone.DataSource     =  dataSetMultiple[2];
   GridViewTelephone.DataBind();

   GridViewStreetAddress.DataSource =  dataSetMultiple[3];
   GridViewStreetAddress.DataBind();
   
   Feedback = null;
  }  	
  
  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   PageRefresh();

   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxFirstName
   );
  }//public void ButtonReset_Click()

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   String   exceptionMessage  =  null;
   Contact  contact           =  null;

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        UtilityContact.XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );
   
   contact = new Contact
   (
    SequenceOrderId,
    FirstName,
    LastName,
    OtherName,
    Company,
    Prefix,
    Suffix,
    Commentary,
    ScriptureReference
   );
   
   Session["contact"] = contact;
      
   UtilityContact.ContactDetailSave
   (
        DatabaseConnectionString,
    ref exceptionMessage,
    ref contact
   );
   
  }//ButtonSubmit_Click()
  
 }//ContactDetailPage class.
}//WordEngineering namespace.