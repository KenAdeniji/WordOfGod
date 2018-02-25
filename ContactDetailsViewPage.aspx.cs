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
 /// <summary>ContactDetailsView page.</summary>
 public class ContactDetailsViewPage : Page
 {

  /// <summary>The database connection string.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>DetailsViewContact</summary>  
  protected System.Web.UI.WebControls.DetailsView           DetailsViewContact;

  /// <summary>GridViewContactEmail</summary>  
  protected System.Web.UI.WebControls.GridView              GridViewContactEmail;

  /// <summary>GridViewContactURI</summary>  
  protected System.Web.UI.WebControls.GridView              GridViewContactURI;

  /// <summary>GridViewStreetAddress</summary>  
  protected System.Web.UI.WebControls.GridView              GridViewStreetAddress;

  /// <summary>GridViewContactTelephone</summary>  
  protected System.Web.UI.WebControls.GridView              GridViewTelephone;

  /// <summary>LiteralFeedback</summary>  
  protected System.Web.UI.WebControls.Label      MessageLabel;

  /// <summary>LiteralFeedback</summary>  
  protected System.Web.UI.WebControls.Literal      LiteralFeedback;

  /// <summary>SqlDataSourceContact</summary>  
  protected SqlDataSource                          SqlDataSourceContact;

  /// <summary>SqlDataSourceContactEmail</summary>  
  protected SqlDataSource                          SqlDataSourceContactEmail;

  /// <summary>SqlDataSourceContactURI</summary>
  protected SqlDataSource                          SqlDataSourceContactURI;

  /// <summary>SqlDataSourceStreetAddress</summary>
  protected SqlDataSource                          SqlDataSourceStreetAddress;

  /// <summary>SqlDataSourceTelephone</summary>
  protected SqlDataSource                          SqlDataSourceTelephone;

  /// <summary>TextBoxSequenceOrderId</summary>
  protected System.Web.UI.WebControls.TextBox      TextBoxSequenceOrderId;

  /// <summary>TextBoxFirstName</summary>
  protected System.Web.UI.WebControls.TextBox      TextBoxFirstName;

  /// <summary>TextBoxLastName</summary>
  protected System.Web.UI.WebControls.TextBox      TextBoxLastName;

  /// <summary>TextBoxOtherName</summary>
  protected System.Web.UI.WebControls.TextBox      TextBoxOtherName;

  /// <summary>TextBoxPrefix</summary>
  protected System.Web.UI.WebControls.TextBox      TextBoxPrefix;

  /// <summary>TextBoxSuffix</summary>
  protected System.Web.UI.WebControls.TextBox      TextBoxSuffix;

  /// <summary>TextBoxCompany</summary>
  protected System.Web.UI.WebControls.TextBox      TextBoxCompany;

  /// <summary>TextBoxCommentary</summary>
  protected System.Web.UI.WebControls.TextBox      TextBoxCommentary;

  /// <summary>TextBoxScriptureReference</summary>
  protected System.Web.UI.WebControls.TextBox      TextBoxScriptureReference;

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
    return ( System.Convert.ToInt32( TextBoxSequenceOrderId.Text.Trim() ) );
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

  /// <summary>ScriptureReference</summary>
  public String ScriptureReference
  {
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
  
   DataPage();
   
  }
   
  /// <summary>DataPage</summary>
  public void DataPage()
  {
   int             SequenceOrderIdContact    =  System.Convert.ToInt32( Request.QueryString["SequenceOrderId"] );
   String          exceptionMessage          =  null;
   StringBuilder   sb                        =  null;
   
   DataSet         dataSet                   =  new DataSet();
   
   Contact         contact                   =  new Contact( SequenceOrderIdContact );
   
   try
   {
    sb = new StringBuilder();
    sb.AppendFormat
    (    
     Contact.SQLSelectContactWhereClause,
     SequenceOrderIdContact
    );
    SqlDataSourceContact.ConnectionString =  DatabaseConnectionString;
    SqlDataSourceContact.SelectCommand = sb.ToString();
    DetailsViewContact.DataSourceID    =  SqlDataSourceContact.ID;
    
    Contact.DatabaseSelect
    (
     ref  DatabaseConnectionString,
     ref  exceptionMessage,
     ref  contact,
     ref  dataSet
    );
    
    SequenceOrderId     =  contact.SequenceOrderId;
    FirstName           =  contact.FirstName;
    LastName            =  contact.LastName;
    OtherName           =  contact.OtherName;
    Company             =  contact.Company;
    Prefix              =  contact.Prefix;
    Suffix              =  contact.Suffix;
    Commentary          =  contact.Commentary;
    ScriptureReference  =  contact.ScriptureReference;

    sb = new StringBuilder();
    sb.AppendFormat
    (    
     Contact.SQLSelectContactEmailWhereClause,
     SequenceOrderIdContact
    );
    SqlDataSourceContactEmail.ConnectionString =  DatabaseConnectionString;
    SqlDataSourceContactEmail.SelectCommand = sb.ToString();
    GridViewContactEmail.DataSourceID       = SqlDataSourceContactEmail.ID;

    sb = new StringBuilder();
    sb.AppendFormat
    (    
     Contact.SQLSelectContactURIWhereClause,
     SequenceOrderIdContact
    );
    SqlDataSourceContactURI.ConnectionString =  DatabaseConnectionString;
    SqlDataSourceContactURI.SelectCommand = sb.ToString();
    GridViewContactURI.DataSourceID    = SqlDataSourceContactURI.ID;

    sb = new StringBuilder();
    sb.AppendFormat
    (    
     Contact.SQLSelectStreetAddressWhereClause,
     SequenceOrderIdContact
    );
    SqlDataSourceStreetAddress.ConnectionString =  DatabaseConnectionString;
    SqlDataSourceStreetAddress.SelectCommand = sb.ToString();
    GridViewStreetAddress.DataSourceID    = SqlDataSourceStreetAddress.ID;
    
    sb = new StringBuilder();
    sb.AppendFormat
    (    
     Contact.SQLSelectTelephoneWhereClause,
     SequenceOrderIdContact
    );
    SqlDataSourceTelephone.ConnectionString =  DatabaseConnectionString;
    SqlDataSourceTelephone.SelectCommand = sb.ToString();
    GridViewTelephone.DataSourceID    = SqlDataSourceTelephone.ID;
        
    //DetailsViewContact.DataBind();
        
    /*
    sqlDataSourceCurrent  =  new SqlDataSource();
    sqlDataSourceCurrent.ConnectionString =  DatabaseConnectionString;
    sqlDataSourceCurrent.DataSourceMode   =  SqlDataSourceMode.DataSet;  //DataReader
    sqlDataSourceCurrent.ProviderName     =  "System.Data.OleDb";  //System.Data.SqlClient //System.Data.OracleClient
    sqlDataSourceCurrent.SelectCommand    =  Contact.SQLSelectContact;
    sqlDataSourceCurrent.UpdateCommand    =  Contact.SQLUpdateContact;
    //sqlDataSourceCurrent.SelectParameters.Add("parameterName", "parameterValue);
    
    DetailsViewContact.DataSourceID          =  sqlDataSourceCurrent.ID;
    DetailsViewContact.DataBind();
    */

   }
   catch ( Exception exception )
   {
   	exceptionMessage = exception.Message;
   }
   
   if ( exceptionMessage != null )
   {
    //Response.Write ( exceptionMessage );
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

  }//DataPage()

  /// <summary>ButtonSubmitDetailsView_Click().</summary>
  public void ButtonSubmitDetailsView_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   String  fieldName   =  null;
   String  fieldValue  =  null;
   
   DetailsViewRow      detailsViewContactCurrent  =  null;

   LiteralFeedback.Text = "";
       
   foreach (DetailsViewRow detailsViewRow in DetailsViewContact.Rows)
   {
    // Use the Text property to access the value of 
    // each cell. In this example, the cells in the 
    // first column (index 0) contains the field names, 
    // while the cells in the second column (index 1)
    // contains the field value. 
    // LiteralFeedback.Text += row.Cells[0].Text + " = " + row.Cells[1].Text + "<br/>";
    
    fieldName   =  detailsViewRow.Cells[0].Text;
    if ( fieldName == null )
    {
     fieldName = "";
    }    	

    fieldValue  =  detailsViewRow.Cells[1].Text;
    if ( fieldValue == null )
    {
     fieldValue = "";
    }
    
    //LiteralFeedback.Text += fieldName + ": "  + fieldValue + " | ";
    
    if ( fieldName == "ScriptureReference" )
    {
     break;
    }
   
   }//foreach (DetailsViewRow row in ItemDetailsView.Rows)
   
  }//public void ButtonSubmitDetailsView_Click()

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   String   exceptionMessage  =  null;
   
   Contact  contact           =  new Contact
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
   
   Contact.DatabaseUpdate
   (
    ref  DatabaseConnectionString,
    ref  exceptionMessage,
    ref  contact
   );	
  }
  

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   DataPage();
   Feedback             =  null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    DetailsViewContact
   );
  }//public void ButtonReset_Click()
  
 }//ContactDetailsViewPage class.
}//WordEngineering namespace.