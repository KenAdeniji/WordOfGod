using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace WordEngineering
{
 /// <summary>ContactMaintenancePage</summary>
 public class ContactMaintenancePage : Page
 {
  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>The XPath database connection string.</summary>
  public string XPathDatabaseConnectionString  = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";

  /// <summary>ButtonRevert</summary>
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>FormViewCaseBasedReasoning</summary>
  protected System.Web.UI.WebControls.FormView               FormViewCaseBasedReasoning;

  /// <summary>FormViewContactEmail</summary>
  protected System.Web.UI.WebControls.FormView               FormViewContactEmail;

  /// <summary>FormViewContactImage</summary>
  protected System.Web.UI.WebControls.FormView               FormViewContactImage;

  /// <summary>FormViewContactURI</summary>
  protected System.Web.UI.WebControls.FormView               FormViewContactURI;

  /// <summary>FormViewStreetAddress</summary>
  protected System.Web.UI.WebControls.FormView               FormViewStreetAddress;

  /// <summary>FormViewTelephone</summary>
  protected System.Web.UI.WebControls.FormView               FormViewTelephone;

  /// <summary>GridViewCaseBasedReasoning</summary>
  protected System.Web.UI.WebControls.GridView               GridViewCaseBasedReasoning;

  /// <summary>GridViewContact</summary>
  protected System.Web.UI.WebControls.GridView               GridViewContact;

  /// <summary>GridViewContactEmail</summary>
  protected System.Web.UI.WebControls.GridView               GridViewContactEmail;

  /// <summary>GridViewContactImage</summary>
  protected System.Web.UI.WebControls.GridView               GridViewContactImage;

  /// <summary>GridViewContactURI</summary>
  protected System.Web.UI.WebControls.GridView               GridViewContactURI;

  /// <summary>GridViewStreetAddress</summary>
  protected System.Web.UI.WebControls.GridView               GridViewStreetAddress;

  /// <summary>GridViewTelephone</summary>
  protected System.Web.UI.WebControls.GridView               GridViewTelephone;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>LiteralReply</summary>
  protected System.Web.UI.WebControls.Literal                LiteralReply;

  /// <summary>PanelContact</summary>
  protected System.Web.UI.WebControls.Panel                  PanelContact;

  /// <summary>SqlDataSourceCaseBasedReasoning</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceCaseBasedReasoning;

  /// <summary>SqlDataSourceContact</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceContact;

  /// <summary>SqlDataSourceContactEmail</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceContactEmail;

  /// <summary>SqlDataSourceContactImage</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceContactImage;

  /// <summary>SqlDataSourceContactURI</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceContactURI;

  /// <summary>SqlDataSourceStreetAddress</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceStreetAddress;

  /// <summary>SqlDataSourceTelephone</summary>
  protected System.Web.UI.WebControls.SqlDataSource          SqlDataSourceTelephone;

  /// <summary>TextBoxAddressLine1</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxAddressLine1;

  /// <summary>TextBoxCity</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxCity;

  /// <summary>TextBoxCommentary</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxCommentary;

  /// <summary>TextBoxCompany</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxCompany;

  /// <summary>TextBoxCountry</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxCountry;

  /// <summary>TextBoxDatedFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDatedFrom;

  /// <summary>TextBoxDatedTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxDatedTo;

  /// <summary>TextBoxEmailAddress</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxEmailAddress;

  /// <summary>TextBoxEmailRecipient</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxEmailRecipient;

  /// <summary>TextBoxFirstName</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxFirstName;

  /// <summary>TextBoxInternetAddress</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxInternetAddress;

  /// <summary>TextBoxLastName</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxLastName;

  /// <summary>TextBoxOtherName</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxOtherName;

  /// <summary>TextBoxSequenceOrderIdFrom</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxSequenceOrderIdFrom;

  /// <summary>TextBoxSequenceOrderIdTo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxSequenceOrderIdTo;

  /// <summary>TextBoxState</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxState;

  /// <summary>TextBoxTelephoneNo</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxTelephoneNo;

  /// <summary>TextBoxZipCode</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxZipCode;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String  exceptionMessage  =  null;

   ServerMapPath = this.MapPath("");

   if ( ServerMapPath != null)
   {
   	FilenameConfigurationXml = Path.Combine( ServerMapPath, FilenameConfigurationXml );
   }//if ( ServerMapPath != null)

   UtilityXml.GetNodeValue
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

   if ( !Page.IsPostBack )
   {
    GridViewContact.Focus();
    Page.SetFocus( GridViewContact );
    GridViewContact.Attributes.Add("autocomplete", "on");
   }//if ( !Page.IsPostBack )
   	
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

  /// <summary>Feedback.</summary>
  public String Reply
  {
   get
   {
    return ( LiteralReply.Text);
   } 
   set
   {
    LiteralReply.Text = value;
   }
  }//public String Reply
  
  /// <summary>AddressLine1</summary>
  public String AddressLine1
  {
   get
   {
    return ( TextBoxAddressLine1.Text );
   } 
   set
   {
    TextBoxAddressLine1.Text = value;
   }
  }//public String AddressLine1

  /// <summary>City</summary>
  public String City
  {
   get
   {
    return ( TextBoxCity.Text );
   } 
   set
   {
    TextBoxCity.Text = value;
   }
  }//public String City

  /// <summary>Commentary</summary>
  public String Commentary
  {
   get
   {
    return ( TextBoxCommentary.Text );
   } 
   set
   {
    TextBoxCommentary.Text = value;
   }
  }//public String Commentary

  /// <summary>Company</summary>
  public String Company
  {
   get
   {
    return ( TextBoxCompany.Text );
   } 
   set
   {
    TextBoxCompany.Text = value;
   }
  }//public String Company

  /// <summary>Country</summary>
  public String Country
  {
   get
   {
    return ( TextBoxCountry.Text );
   } 
   set
   {
    TextBoxCountry.Text = value;
   }
  }//public String Country

  /// <summary>DatedFrom</summary>
  public String DatedFrom
  {
   get
   {
    return ( TextBoxDatedFrom.Text );
   } 
   set
   {
    TextBoxDatedFrom.Text = value;
   }
  }//public String DatedFrom

  /// <summary>DatedTo</summary>
  public String DatedTo
  {
   get
   {
    return ( TextBoxDatedTo.Text );
   } 
   set
   {
    TextBoxDatedTo.Text = value;
   }
  }//public String DatedTo

  /// <summary>EmailAddress</summary>
  public String EmailAddress
  {
   get
   {
    return ( TextBoxEmailAddress.Text );
   } 
   set
   {
    TextBoxEmailAddress.Text = value;
   }
  }//public String EmailAddress

  /// <summary>EmailRecipient</summary>
  public String EmailRecipient
  {
   get
   {
    return ( TextBoxEmailRecipient.Text );
   } 
   set
   {
    TextBoxEmailRecipient.Text = value;
   }
  }//public String EmailRecipient

  /// <summary>FirstName</summary>
  public String FirstName
  {
   get
   {
    return ( TextBoxFirstName.Text );
   } 
   set
   {
    TextBoxFirstName.Text = value;
   }
  }//public String FirstName

  /// <summary>InternetAddress</summary>
  public String InternetAddress
  {
   get
   {
    return ( TextBoxInternetAddress.Text );
   } 
   set
   {
    TextBoxInternetAddress.Text = value;
   }
  }//public String InternetAddress

  /// <summary>LastName</summary>
  public String LastName
  {
   get
   {
    return ( TextBoxLastName.Text );
   } 
   set
   {
    TextBoxLastName.Text = value;
   }
  }//public String LastName

  /// <summary>OtherName</summary>
  public String OtherName
  {
   get
   {
    return ( TextBoxOtherName.Text );
   } 
   set
   {
    TextBoxOtherName.Text = value;
   }
  }//public String OtherName

  /// <summary>SequenceOrderIdFrom</summary>
  public String SequenceOrderIdFrom
  {
   get
   {
    return ( TextBoxSequenceOrderIdFrom.Text );
   } 
   set
   {
    TextBoxSequenceOrderIdFrom.Text = value;
   }
  }//public String SequenceOrderIdFrom

  /// <summary>SequenceOrderIdTo</summary>
  public String SequenceOrderIdTo
  {
   get
   {
    return ( TextBoxSequenceOrderIdTo.Text );
   } 
   set
   {
    TextBoxSequenceOrderIdTo.Text = value;
   }
  }//public String SequenceOrderIdTo

  /// <summary>State</summary>
  public String State
  {
   get
   {
    return ( TextBoxState.Text );
   } 
   set
   {
    TextBoxState.Text = value;
   }
  }//public String State

  /// <summary>TelephoneNo</summary>
  public String TelephoneNo
  {
   get
   {
    return ( TextBoxTelephoneNo.Text );
   } 
   set
   {
    TextBoxTelephoneNo.Text = value;
   }
  }//public String TelephoneNo

  /// <summary>ZipCode</summary>
  public String ZipCode
  {
   get
   {
    return ( TextBoxZipCode.Text );
   } 
   set
   {
    TextBoxZipCode.Text = value;
   }
  }//public String ZipCode

  /// <summary>ButtonEmail_Click()</summary>
  public void ButtonEmail_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   MailSend();  	
  }

  /// <summary>ButtonReset_Click()</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Feedback             =  null;
   AddressLine1         =  null;
   City                 =  null;
   Commentary           =  null;
   Company				=  null;
   Country              =  null;
   DatedFrom            =  null;
   DatedTo              =  null;
   EmailAddress         =  null;
   FirstName            =  null;
   InternetAddress      =  null;
   LastName             =  null;
   OtherName            =  null;   
   SequenceOrderIdFrom  =  null;
   SequenceOrderIdTo    =  null;
   State                =  null;
   TelephoneNo          =  null;
   ZipCode              =  null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxFirstName
   );

  }//public void ButtonReset_Click()

  /// <summary>ButtonSubmit_Click()</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   GridViewContact.DataBind();
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonFormViewCaseBasedReasoningInsert_Click</summary>
  public void ButtonFormViewCaseBasedReasoningInsert_Click
  (
   Object     sender, 
   EventArgs  e
  )
  {
   decimal   expense;
   decimal   income;
   int       sequenceOrderId    =  -1;
   string    exceptionMessage   =  null;
   string    commentary         =  null;
   string    value;
   DateTime  dated;
   
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) FormViewCaseBasedReasoning.FindControl("TextBoxFormViewCaseBasedReasoningInsertItemTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceCaseBasedReasoning.InsertParameters["dated"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) FormViewCaseBasedReasoning.FindControl("TextBoxFormViewCaseBasedReasoningInsertItemTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceCaseBasedReasoning.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    commentary  =  ( ( System.Web.UI.WebControls.TextBox ) FormViewCaseBasedReasoning.FindControl("TextBoxFormViewCaseBasedReasoningInsertItemTemplateCommentary")).Text;
    SqlDataSourceCaseBasedReasoning.InsertParameters["commentary"].DefaultValue         =  commentary;
    value = (( System.Web.UI.WebControls.TextBox ) FormViewCaseBasedReasoning.FindControl("TextBoxFormViewCaseBasedReasoningInsertItemTemplateExpense")).Text;
    if ( Decimal.TryParse( value, out expense ) )
    {
     SqlDataSourceCaseBasedReasoning.InsertParameters["expense"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) FormViewCaseBasedReasoning.FindControl("TextBoxFormViewCaseBasedReasoningInsertItemTemplateIncome")).Text;
    if ( Decimal.TryParse( value, out income ) )
    {
     SqlDataSourceCaseBasedReasoning.InsertParameters["income"].DefaultValue = value;
    }
    SqlDataSourceCaseBasedReasoning.Insert();
    GridViewCaseBasedReasoning.DataBind();
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   } 
  }//ButtonFormViewCaseBasedReasoningInsert_Click()

  /// <summary>ButtonFormViewContactEmailInsert_Click</summary>
  public void ButtonFormViewContactEmailInsert_Click
  (
   Object     sender, 
   EventArgs  e
  )
  {
   int       sequenceOrderId   =  -1;
   string    emailAddress      =  null;
   string    exceptionMessage  =  null;
   DateTime  dated;
   
   try
   {
    DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewContactEmail.FindControl("TextBoxFormViewContactEmailInsertItemTemplateDated")).Text, out dated );
    Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewContactEmail.FindControl("TextBoxFormViewContactEmailInsertItemTemplateSequenceOrderId")).Text, out sequenceOrderId );
 
    emailAddress         =  ( ( System.Web.UI.WebControls.TextBox ) FormViewContactEmail.FindControl("TextBoxFormViewContactEmailInsertItemTemplateEmailAddress")).Text;
    if ( sequenceOrderId > 0 )
    {
     SqlDataSourceContactEmail.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
    }
    if ( dated != DateTime.MinValue )
    {
     SqlDataSourceContactEmail.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
    }
    SqlDataSourceContactEmail.InsertParameters["emailAddress"].DefaultValue      =  emailAddress;

    SqlDataSourceContactEmail.Insert();
    GridViewContactEmail.DataBind();
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   } 
  }//ButtonFormViewContactEmailInsert_Click()

  /// <summary>ButtonFormViewContactImageInsert_Click</summary>
  public void ButtonFormViewContactImageInsert_Click
  (
   Object     sender, 
   EventArgs  e
  )
  {
   byte[]            imageContent           =  null;
   int               contactId              =  -1;
   int               sequenceOrderId        =  -1;
   string            exceptionMessage       =  null;
   string            imageType              =  null;
   DateTime          dated;
   FileUpload        fileUploadImageSource  =  null;
   try
   {
   	Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) GridViewContact.SelectedRow.FindControl("LabelGridViewContactItemTemplateSequenceOrderId")).Text, out contactId );
    DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewContactImage.FindControl("TextBoxFormViewContactImageInsertItemTemplateDated")).Text, out dated );
    Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewContactImage.FindControl("TextBoxFormViewContactImageInsertItemTemplateSequenceOrderId")).Text, out sequenceOrderId );
    fileUploadImageSource  =  ( ( System.Web.UI.WebControls.FileUpload ) FormViewContactImage.FindControl("FileUploadFormViewContactImageInsertItemTemplateImageSource") );
    if ( fileUploadImageSource.HasFile == false ) { return; }
    /*
    if ( sequenceOrderId > 0 )
    {
     SqlDataSourceContactImage.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
    }
    if ( dated != DateTime.MinValue )
    {
     SqlDataSourceContactImage.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
    }
    SqlDataSourceContactImage.InsertParameters["imageSource"].DefaultValue       =  fileUploadImageSource.PostedFile.FileName;
    SqlDataSourceContactImage.Insert();
    */
    imageType  =  fileUploadImageSource.PostedFile.ContentType;
    UtilityContact.ContactImageUpdate
    (
     ref DatabaseConnectionString,
     ref exceptionMessage,
     ref sequenceOrderId,
     ref dated,   
     ref contactId,
     ref imageContent,
     ref fileUploadImageSource,
     ref imageType
    ); 
    GridViewContactImage.DataBind();
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   } 
  }//ButtonFormViewContactImageInsert_Click()

  /// <summary>ButtonFormViewContactURIInsert_Click</summary>
  public void ButtonFormViewContactURIInsert_Click
  (
   Object     sender, 
   EventArgs  e
  )
  {
   int       sequenceOrderId   =  -1;
   string    internetAddress   =  null;
   string    exceptionMessage  =  null;
   DateTime  dated;
   
   try
   {
    DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewContactURI.FindControl("TextBoxFormViewContactURIInsertItemTemplateDated")).Text, out dated );
    Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewContactURI.FindControl("TextBoxFormViewContactURIInsertItemTemplateSequenceOrderId")).Text, out sequenceOrderId );
 
    internetAddress         =  ( ( System.Web.UI.WebControls.TextBox ) FormViewContactURI.FindControl("TextBoxFormViewContactURIInsertItemTemplateInternetAddress")).Text;
    if ( sequenceOrderId > 0 )
    {
     SqlDataSourceContactURI.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
    }
    if ( dated != DateTime.MinValue )
    {
     SqlDataSourceContactURI.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
    }
    SqlDataSourceContactURI.InsertParameters["internetAddress"].DefaultValue      =  internetAddress;

    SqlDataSourceContactURI.Insert();
    GridViewContactURI.DataBind();
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   } 
  }//ButtonFormViewContactURIInsert_Click()

  /// <summary>ButtonFormViewStreetAddressInsert_Click</summary>
  public void ButtonFormViewStreetAddressInsert_Click
  (
   Object     sender, 
   EventArgs  e
  )
  {
   int       sequenceOrderId    =  -1;
   string    exceptionMessage   =  null;
   string    addressLine1       =  null;
   string    city               =  null;
   string    state              =  null;
   string    zipCode            =  null;
   string    country            =  null;
   DateTime  dated;
   
   try
   {
    DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewStreetAddress.FindControl("TextBoxFormViewStreetAddressInsertItemTemplateDated")).Text, out dated );
    Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewStreetAddress.FindControl("TextBoxFormViewStreetAddressInsertItemTemplateSequenceOrderId")).Text, out sequenceOrderId );
 
    addressLine1        =  ( ( System.Web.UI.WebControls.TextBox ) FormViewStreetAddress.FindControl("TextBoxFormViewStreetAddressInsertItemTemplateAddressLine1")).Text;
    city                =  ( ( System.Web.UI.WebControls.TextBox ) FormViewStreetAddress.FindControl("TextBoxFormViewStreetAddressInsertItemTemplateCity")).Text;
    state               =  ( ( System.Web.UI.WebControls.TextBox ) FormViewStreetAddress.FindControl("TextBoxFormViewStreetAddressInsertItemTemplateState")).Text;
    zipCode             =  ( ( System.Web.UI.WebControls.TextBox ) FormViewStreetAddress.FindControl("TextBoxFormViewStreetAddressInsertItemTemplateZipCode")).Text;
    country             =  ( ( System.Web.UI.WebControls.TextBox ) FormViewStreetAddress.FindControl("TextBoxFormViewStreetAddressInsertItemTemplateCountry")).Text;
    if ( sequenceOrderId > 0 )
    {
     SqlDataSourceStreetAddress.InsertParameters["sequenceOrderId"].DefaultValue   =  System.Convert.ToString( sequenceOrderId );
    }
    if ( dated != DateTime.MinValue )
    {
     SqlDataSourceStreetAddress.InsertParameters["dated"].DefaultValue             =  System.Convert.ToString( dated );
    }
    SqlDataSourceStreetAddress.InsertParameters["addressLine1"].DefaultValue       =  addressLine1;
    SqlDataSourceStreetAddress.InsertParameters["city"].DefaultValue               =  city;
    SqlDataSourceStreetAddress.InsertParameters["state"].DefaultValue              =  state;
    SqlDataSourceStreetAddress.InsertParameters["zipCode"].DefaultValue            =  zipCode;
    SqlDataSourceStreetAddress.InsertParameters["country"].DefaultValue            =  country;

    SqlDataSourceStreetAddress.Insert();
    GridViewStreetAddress.DataBind();
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   } 
  }//ButtonFormViewStreetAddressInsert_Click()

  /// <summary>ButtonFormViewTelephoneInsert_Click</summary>
  public void ButtonFormViewTelephoneInsert_Click
  (
   Object     sender, 
   EventArgs  e
  )
  {
   int       sequenceOrderId    =  -1;
   string    exceptionMessage   =  null;
   string    telephoneNo        =  null;
   string    telephoneLocation  =  null;   
   DateTime  dated;
   
   try
   {
    DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewTelephone.FindControl("TextBoxFormViewTelephoneInsertItemTemplateDated")).Text, out dated );
    Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewTelephone.FindControl("TextBoxFormViewTelephoneInsertItemTemplateSequenceOrderId")).Text, out sequenceOrderId );
 
    telephoneNo        =  ( ( System.Web.UI.WebControls.TextBox ) FormViewTelephone.FindControl("TextBoxFormViewTelephoneInsertItemTemplateTelephoneNo")).Text;
    telephoneLocation  =  ( ( System.Web.UI.WebControls.TextBox ) FormViewTelephone.FindControl("TextBoxFormViewTelephoneInsertItemTemplateTelephoneLocation")).Text;
    if ( sequenceOrderId > 0 )
    {
     SqlDataSourceTelephone.InsertParameters["sequenceOrderId"].DefaultValue   =  System.Convert.ToString( sequenceOrderId );
    }
    if ( dated != DateTime.MinValue )
    {
     SqlDataSourceTelephone.InsertParameters["dated"].DefaultValue             =  System.Convert.ToString( dated );
    }
    SqlDataSourceTelephone.InsertParameters["telephoneNo"].DefaultValue        =  telephoneNo;
    SqlDataSourceTelephone.InsertParameters["telephoneLocation"].DefaultValue  =  telephoneLocation;

    SqlDataSourceTelephone.Insert();
    GridViewTelephone.DataBind();
   }//try
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   } 
  }//ButtonFormViewTelephoneInsert_Click()

  /// <summary>FormView_ItemInserted</summary>
  public void FormView_ItemInserted
  (
   Object                     sender, 
   FormViewInsertedEventArgs  formViewInsertedEventArgs
  )
  {
   // Use the Exception property to determine whether an exception
   // occurred during the insert operation.
   if ( formViewInsertedEventArgs.Exception != null )
   {
    // Insert the code to handle the exception.
    Feedback = formViewInsertedEventArgs.Exception.Message;

    // Use the ExceptionHandled property to indicate that the 
    // exception is already handled.
    formViewInsertedEventArgs.ExceptionHandled = true;

    // When an exception occurs, keep the GridView
    // control in edit mode.
    formViewInsertedEventArgs.KeepInInsertMode = true;
   }//if ( formViewInsertedEventArgs.Exception != null )
  }//public void FormView_ItemInserted()

  /// <summary>FormView_ItemInserting</summary>
  public void FormView_ItemInserting
  (
   Object                   sender, 
   FormViewInsertEventArgs  e
  )
  {
   int       sequenceOrderId   =  -1;
   string    emailAddress      =  null;
   string    exceptionMessage  =  null;
   DateTime  dated;
   
   try
   {
    DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewContactEmail.FindControl("TextBoxFormViewContactEmailInsertItemTemplateDated")).Text, out dated );
    Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) FormViewContactEmail.FindControl("TextBoxFormViewContactEmailInsertItemTemplateSequenceOrderId")).Text, out sequenceOrderId );
 
    emailAddress         =  ( ( System.Web.UI.WebControls.TextBox ) FormViewContactEmail.FindControl("TextBoxFormViewContactEmailInsertItemTemplateEmailAddress")).Text;
    if ( sequenceOrderId > 0 )
    {
     SqlDataSourceContactEmail.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
    }
    if ( dated != DateTime.MinValue )
    {
     SqlDataSourceContactEmail.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
    }
    SqlDataSourceContactEmail.InsertParameters["emailAddress"].DefaultValue      =  emailAddress;

    SqlDataSourceContactEmail.Insert();
    GridViewContactEmail.DataBind();
   }
   catch ( Exception exception )
   {
   	exceptionMessage = "Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   } 
  }//FormView_ItemInserting()

  /// <summary>GridView_PreRender</summary>
  public void GridView_PreRender
  (
   object     sender,
   EventArgs  eventArgs
  )
  {
   if ( sender == GridViewCaseBasedReasoning )
   {
    if ( GridViewCaseBasedReasoning.Rows.Count == 0 && GridViewContact.Rows.Count > 0 )
    {
     FormViewCaseBasedReasoning.Visible     = true;
   	 FormViewCaseBasedReasoning.DefaultMode = FormViewMode.Insert;
    }//if ( GridViewCaseBasedReasoning.Rows.Count == 0 )
    else
    {
     FormViewCaseBasedReasoning.Visible     = false;
    }
   }//if ( sender == GridViewCaseBasedReasoning )
   else if ( sender == GridViewContactEmail )
   {
    if ( GridViewContactEmail.Rows.Count == 0 && GridViewContact.Rows.Count > 0 )
    {
     FormViewContactEmail.Visible     = true;
   	 FormViewContactEmail.DefaultMode = FormViewMode.Insert;
    }//if ( GridViewContactEmail.Rows.Count == 0 )
    else
    {
     FormViewContactEmail.Visible     = false;
    }
   }//else if ( sender == GridViewContactEmail )
   else if ( sender == GridViewContactImage )
   {
    if ( GridViewContactImage.Rows.Count == 0 && GridViewContact.Rows.Count > 0 )
    {
     FormViewContactImage.Visible     = true;
   	 FormViewContactImage.DefaultMode = FormViewMode.Insert;
    }//if ( GridViewContactImage.Rows.Count == 0 )
    else
    {
     FormViewContactImage.Visible     = false;
    }
   }//else if ( sender == GridViewContactImage )
   else if ( sender == GridViewContactURI )
   {
    if ( GridViewContactURI.Rows.Count == 0 && GridViewContact.Rows.Count > 0 )
    {
     FormViewContactURI.Visible     = true;
   	 FormViewContactURI.DefaultMode = FormViewMode.Insert;
    }//if ( GridViewContactURI.Rows.Count == 0 )
    else
    {
     FormViewContactURI.Visible     = false;
    }
   }//if ( sender == GridViewContactURI )
   else if ( sender == GridViewTelephone )
   {
    if ( GridViewTelephone.Rows.Count == 0 && GridViewContact.Rows.Count > 0 )
    {
     FormViewTelephone.Visible     = true;
   	 FormViewTelephone.DefaultMode = FormViewMode.Insert;
    }//if ( GridViewTelephone.Rows.Count == 0 )
    else
    {
     FormViewTelephone.Visible     = false;
    }
   }//if ( sender == GridViewTelephone )
   else if ( sender == GridViewStreetAddress )
   {
    if ( GridViewStreetAddress.Rows.Count == 0 && GridViewContact.Rows.Count > 0 )
    {
     FormViewStreetAddress.Visible     = true;
   	 FormViewStreetAddress.DefaultMode = FormViewMode.Insert;
    }//if ( GridViewStreetAddress.Rows.Count == 0 )
    else
    {
     FormViewStreetAddress.Visible     = false;
    }
   }//if ( sender == GridViewStreetAddress )
  }//public void GridView_PreRender()

  /// <summary>GridViewCaseBasedReasoningInsert</summary>
  public void GridViewCaseBasedReasoningInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   decimal   expense;
   decimal   income;
   DateTime  dated;
   string    commentary;
   string    exceptionMessage = null;
   string    value;   
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewCaseBasedReasoning.FooterRow.FindControl("TextBoxGridViewCaseBasedReasoningFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceCaseBasedReasoning.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewCaseBasedReasoning.FooterRow.FindControl("TextBoxGridViewCaseBasedReasoningFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceCaseBasedReasoning.InsertParameters["dated"].DefaultValue = value;
    }
    commentary = ( ( System.Web.UI.WebControls.TextBox ) GridViewCaseBasedReasoning.FooterRow.FindControl("TextBoxGridViewCaseBasedReasoningFooterTemplateCommentary")).Text;
    SqlDataSourceCaseBasedReasoning.InsertParameters["commentary"].DefaultValue = commentary;
    value = (( System.Web.UI.WebControls.TextBox ) GridViewCaseBasedReasoning.FooterRow.FindControl("TextBoxGridViewCaseBasedReasoningFooterTemplateExpense")).Text;
    if ( Decimal.TryParse( value, out expense ) )
    {
     SqlDataSourceCaseBasedReasoning.InsertParameters["expense"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewCaseBasedReasoning.FooterRow.FindControl("TextBoxGridViewCaseBasedReasoningFooterTemplateIncome")).Text;
    if ( Decimal.TryParse( value, out income ) )
    {
     SqlDataSourceCaseBasedReasoning.InsertParameters["Income"].DefaultValue = value;
    }
    SqlDataSourceCaseBasedReasoning.Insert();
    GridViewCaseBasedReasoning.DataBind();
   }
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }
  }

  /// <summary>GridViewContactInsert</summary>
  public void GridViewContactInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   string    commentary;
   string    company;
   string    exceptionMessage = null;
   string    firstname;
   string    lastname;
   string    othername;
   string    title;
   string    value;   
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceContact.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceContact.InsertParameters["dated"].DefaultValue = value;
    }
    title = ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateTitle")).Text;
    SqlDataSourceContact.InsertParameters["title"].DefaultValue = title;
    firstname = ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateFirstname")).Text;
    SqlDataSourceContact.InsertParameters["firstname"].DefaultValue = firstname;
    lastname = ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateLastname")).Text;
    SqlDataSourceContact.InsertParameters["lastname"].DefaultValue = lastname;
    othername = ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateOthername")).Text;
    SqlDataSourceContact.InsertParameters["othername"].DefaultValue = othername;
    company = ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateCompany")).Text;
    SqlDataSourceContact.InsertParameters["company"].DefaultValue = company;
    commentary = ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateCommentary")).Text;
    SqlDataSourceContact.InsertParameters["commentary"].DefaultValue = commentary;
    SqlDataSourceContact.Insert();
    GridViewContact.DataBind();
   }
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }
  }

  /// <summary>GridViewContactEmailInsert</summary>
  public void GridViewContactEmailInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   string    emailAddress;
   string    exceptionMessage = null;
   string    value;   
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewContactEmail.FooterRow.FindControl("TextBoxGridViewContactEmailFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceContactEmail.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewContactEmail.FooterRow.FindControl("TextBoxGridViewContactEmailFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceContactEmail.InsertParameters["dated"].DefaultValue = value;
    }
    emailAddress = ( ( System.Web.UI.WebControls.TextBox ) GridViewContactEmail.FooterRow.FindControl("TextBoxGridViewContactEmailFooterTemplateemailAddress")).Text;
    SqlDataSourceContactEmail.InsertParameters["emailAddress"].DefaultValue = emailAddress;
    SqlDataSourceContactEmail.Insert();
    GridViewContactEmail.DataBind();
   }
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }
  }

  /// <summary>GridViewContactImageInsert</summary>
  public void GridViewContactImageInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   byte[]      fileUploadImageContent = null;
   int         contactId;
   int         sequenceOrderId;
   DateTime    dated;
   string      exceptionMessage = null;
   string      fileUploadImageType;
   string      value;   
   FileUpload  fileUploadImageSource;
 
   try
   {
    Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) GridViewContact.SelectedRow.FindControl("LabelGridViewContactItemTemplateSequenceOrderId")).Text, out contactId );
    value = (( System.Web.UI.WebControls.TextBox ) GridViewContactImage.FooterRow.FindControl("TextBoxGridViewContactImageFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceContactImage.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewContactImage.FooterRow.FindControl("TextBoxGridViewContactImageFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceContactImage.InsertParameters["dated"].DefaultValue = value;
    }
    fileUploadImageSource  =  ( ( System.Web.UI.WebControls.FileUpload )GridViewContactImage.FooterRow.FindControl("FileUploadGridViewContactImageFooterTemplateImageSource") );
    if ( fileUploadImageSource.HasFile == false ) { return; }
    fileUploadImageType  =  fileUploadImageSource.PostedFile.ContentType;
    UtilityContact.ContactImageUpdate
    (
     ref DatabaseConnectionString,
     ref exceptionMessage,
     ref sequenceOrderId,
     ref dated,   
     ref contactId,
     ref fileUploadImageContent,
     ref fileUploadImageSource,
     ref fileUploadImageType
    );
    GridViewContactImage.DataBind();
   }
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }
  }


  /// <summary>GridViewContactURIInsert</summary>
  public void GridViewContactURIInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   string    exceptionMessage = null;
   string    internetAddress;
   string    value;   
 
   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewContactURI.FooterRow.FindControl("TextBoxGridViewContactURIFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceContactURI.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewContactURI.FooterRow.FindControl("TextBoxGridViewContactURIFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceContactURI.InsertParameters["dated"].DefaultValue = value;
    }
    internetAddress = ( ( System.Web.UI.WebControls.TextBox ) GridViewContactURI.FooterRow.FindControl("TextBoxGridViewContactURIFooterTemplateInternetAddress")).Text;
    SqlDataSourceContactURI.InsertParameters["internetAddress"].DefaultValue = internetAddress;
    SqlDataSourceContactURI.Insert();
    GridViewContactURI.DataBind();
   }
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }
  }

  /// <summary>GridViewStreetAddressInsert</summary>
  public void GridViewStreetAddressInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   string    addressLine1;
   string    city;
   string    country;
   string    exceptionMessage = null;
   string    state;
   string    zipCode;
   string    value;   

   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceStreetAddress.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceStreetAddress.InsertParameters["dated"].DefaultValue = value;
    }
    addressLine1 = ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateAddressLine1")).Text;
    SqlDataSourceStreetAddress.InsertParameters["addressLine1"].DefaultValue = addressLine1;
    city = ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateCity")).Text;
    SqlDataSourceStreetAddress.InsertParameters["city"].DefaultValue = city;
    state = ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateState")).Text;
    SqlDataSourceStreetAddress.InsertParameters["state"].DefaultValue = state;
    zipCode = ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateZipCode")).Text;
    SqlDataSourceStreetAddress.InsertParameters["zipCode"].DefaultValue = zipCode;
    country = ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateCountry")).Text;
    SqlDataSourceStreetAddress.InsertParameters["country"].DefaultValue = country;
    SqlDataSourceStreetAddress.Insert();
    GridViewStreetAddress.DataBind();
   }
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }
  }

  /// <summary>GridViewTelephoneInsert</summary>
  public void GridViewTelephoneInsert
  (
   Object sender, 
   EventArgs e
  )
  {
   int       sequenceOrderId;
   DateTime  dated;
   string    exceptionMessage = null;
   string    telephoneNo;
   string    telephoneLocation;
   string    value;   

   try
   {
    value = (( System.Web.UI.WebControls.TextBox ) GridViewTelephone.FooterRow.FindControl("TextBoxGridViewTelephoneFooterTemplateSequenceOrderId")).Text;
    if ( Int32.TryParse( value, out sequenceOrderId ) )
    {
     SqlDataSourceTelephone.InsertParameters["sequenceOrderId"].DefaultValue = value;
    }
    value = (( System.Web.UI.WebControls.TextBox ) GridViewTelephone.FooterRow.FindControl("TextBoxGridViewTelephoneFooterTemplateDated")).Text;
    if ( DateTime.TryParse( value, out dated ) )
    {
     SqlDataSourceTelephone.InsertParameters["dated"].DefaultValue = value;
    }
    telephoneNo = ( ( System.Web.UI.WebControls.TextBox ) GridViewTelephone.FooterRow.FindControl("TextBoxGridViewTelephoneFooterTemplateTelephoneNo")).Text;
    SqlDataSourceTelephone.InsertParameters["telephoneNo"].DefaultValue = telephoneNo;
    telephoneLocation = ( ( System.Web.UI.WebControls.TextBox ) GridViewTelephone.FooterRow.FindControl("TextBoxGridViewTelephoneFooterTemplateTelephoneLocation")).Text;
    SqlDataSourceTelephone.InsertParameters["telephoneLocation"].DefaultValue = telephoneLocation;
    SqlDataSourceTelephone.Insert();
    GridViewTelephone.DataBind();
   }
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }
  }

  /// <summary>GridView_RowCommand</summary>
  public void GridView_RowCommand
  (
   Object                    sender, 
   GridViewCommandEventArgs  gridViewCommandEventArgs
  )
  { 
   byte[]      fileUploadImageContent  =  null;
   int         contactId               =  -1;
   int         rowIndex                =  -1;
   int         sequenceOrderId         =  -1;
   DateTime    dated;
   string      exceptionMessage        =  null;
   string      commentary              =  null;
   string      company                 =  null;
   string      firstName               =  null;
   string      lastName                =  null;
   string      otherName               =  null;
   string      title                   =  null;

   string      emailAddress            =  null;
   
   string      internetAddress         =  null;
 
   string      addressLine1            =  null;
   string      city                    =  null;
   string      state                   =  null;
   string      zipCode                 =  null;
   string      country                 =  null;

   string      telephoneNo             =  null;
   string      telephoneLocation       =  null;   
   
   string      fileUploadImageType     =  null;
   FileUpload  fileUploadImageSource   =  null;


   try
   {
    switch ( gridViewCommandEventArgs.CommandName  )
    {
   	 case "ButtonFieldGridViewContactRender":
      // Convert the row index stored in the CommandArgument
      // property to an Integer.
      rowIndex = Convert.ToInt32( gridViewCommandEventArgs.CommandArgument );
      Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) GridViewContactImage.Rows[rowIndex].FindControl("LabelGridViewContactImageItemTemplateSequenceOrderId")).Text, out sequenceOrderId );
      /*
      UtilityContact.ContactImageRender
      (
       ref DatabaseConnectionString,
       ref exceptionMessage,
       ref sequenceOrderId,
       ref fileUploadImageContent
      );
      */
      if ( exceptionMessage != null ) { Feedback = exceptionMessage; return; }
   	  break;
   	  
   	 case "ButtonGridViewContactFooterTemplateAdd":
      DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateDated")).Text, out dated );
      Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateSequenceOrderId")).Text, out sequenceOrderId );
      
      commentary    =  ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateCommentary")).Text;
      company       =  ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateCompany")).Text;
      firstName     =  ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateFirstName")).Text;
      lastName      =  ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateLastName")).Text;
      otherName     =  ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateOtherName")).Text;
      title         =  ( ( System.Web.UI.WebControls.TextBox ) GridViewContact.FooterRow.FindControl("TextBoxGridViewContactFooterTemplateTitle")).Text;
      
      if ( sequenceOrderId > 0 )
      {
       SqlDataSourceContact.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
      }
      if ( dated != DateTime.MinValue )
      {
       SqlDataSourceContact.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
      }
      SqlDataSourceContact.InsertParameters["title"].DefaultValue             =  title;
      SqlDataSourceContact.InsertParameters["firstName"].DefaultValue         =  firstName;
      SqlDataSourceContact.InsertParameters["lastName"].DefaultValue          =  lastName;
      SqlDataSourceContact.InsertParameters["otherName"].DefaultValue         =  otherName;
      SqlDataSourceContact.InsertParameters["company"].DefaultValue           =  company;
      SqlDataSourceContact.InsertParameters["commentary"].DefaultValue        =  commentary;
      SqlDataSourceContact.Insert();      
      break;

   	 case "ButtonGridViewContactEmailFooterTemplateAdd":
      DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewContactEmail.FooterRow.FindControl("TextBoxGridViewContactEmailFooterTemplateDated")).Text, out dated );
      Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewContactEmail.FooterRow.FindControl("TextBoxGridViewContactEmailFooterTemplateSequenceOrderId")).Text, out sequenceOrderId );
 
      emailAddress         =  ( ( System.Web.UI.WebControls.TextBox ) GridViewContactEmail.FooterRow.FindControl("TextBoxGridViewContactEmailFooterTemplateEmailAddress")).Text;

      if ( sequenceOrderId > 0 )
      {
       SqlDataSourceContactEmail.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
      }
      if ( dated != DateTime.MinValue )
      {
       SqlDataSourceContactEmail.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
      }
      SqlDataSourceContactEmail.InsertParameters["emailAddress"].DefaultValue      =  emailAddress;
      SqlDataSourceContactEmail.Insert();
      break;

   	 case "ButtonGridViewContactImageFooterTemplateAdd":
      Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) GridViewContact.SelectedRow.FindControl("LabelGridViewContactItemTemplateSequenceOrderId")).Text, out contactId );
      DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewContactImage.FooterRow.FindControl("TextBoxGridViewContactImageFooterTemplateDated")).Text, out dated );
      Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewContactImage.FooterRow.FindControl("TextBoxGridViewContactImageFooterTemplateSequenceOrderId")).Text, out sequenceOrderId );
      fileUploadImageSource  =  ( ( System.Web.UI.WebControls.FileUpload )GridViewContactImage.FooterRow.FindControl("FileUploadGridViewContactImageFooterTemplateImageSource") );
      if ( fileUploadImageSource.HasFile == false ) { return; }
      fileUploadImageType  =  fileUploadImageSource.PostedFile.ContentType;
      UtilityContact.ContactImageUpdate
      (
       ref DatabaseConnectionString,
       ref exceptionMessage,
       ref sequenceOrderId,
       ref dated,   
       ref contactId,
       ref fileUploadImageContent,
       ref fileUploadImageSource,
       ref fileUploadImageType
      );
      GridViewContactImage.DataBind();
      break;
    
   	 case "ButtonGridViewContactURIFooterTemplateAdd":
      DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewContactURI.FooterRow.FindControl("TextBoxGridViewContactURIFooterTemplateDated")).Text, out dated );
      Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewContactURI.FooterRow.FindControl("TextBoxGridViewContactURIFooterTemplateSequenceOrderId")).Text, out sequenceOrderId );
 
      internetAddress         =  ( ( System.Web.UI.WebControls.TextBox ) GridViewContactURI.FooterRow.FindControl("TextBoxGridViewContactURIFooterTemplateInternetAddress")).Text;

      if ( sequenceOrderId > 0 )
      {
       SqlDataSourceContactURI.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
      }
      if ( dated != DateTime.MinValue )
      {
       SqlDataSourceContactURI.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
      }
      SqlDataSourceContactURI.InsertParameters["internetAddress"].DefaultValue   =  internetAddress;
      SqlDataSourceContactURI.Insert();
      break;

   	 case "ButtonGridViewTelephoneFooterTemplateAdd":
      DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewTelephone.FooterRow.FindControl("TextBoxGridViewTelephoneFooterTemplateDated")).Text, out dated );
      Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewTelephone.FooterRow.FindControl("TextBoxGridViewTelephoneFooterTemplateSequenceOrderId")).Text, out sequenceOrderId );
 
      telephoneNo        =  ( ( System.Web.UI.WebControls.TextBox ) GridViewTelephone.FooterRow.FindControl("TextBoxGridViewTelephoneFooterTemplateTelephoneNo")).Text;
      telephoneLocation  =  ( ( System.Web.UI.WebControls.TextBox ) GridViewTelephone.FooterRow.FindControl("TextBoxGridViewTelephoneFooterTemplateTelephoneLocation")).Text;

      if ( sequenceOrderId > 0 )
      {
       SqlDataSourceTelephone.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
      }
      if ( dated != DateTime.MinValue )
      {
       SqlDataSourceTelephone.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
      }
      SqlDataSourceTelephone.InsertParameters["telephoneNo"].DefaultValue       =  telephoneNo;
      SqlDataSourceTelephone.InsertParameters["telephoneLocation"].DefaultValue =  telephoneLocation;
      SqlDataSourceTelephone.Insert();
      break;

   	 case "ButtonGridViewStreetAddressFooterTemplateAdd":
      DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateDated")).Text, out dated );
      Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateSequenceOrderId")).Text, out sequenceOrderId );
 
      addressLine1  =  ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateAddressLine1")).Text;
      city          =  ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateCity")).Text;
      state         =  ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateState")).Text;
      zipCode       =  ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateZipCode")).Text;
      country       =  ( ( System.Web.UI.WebControls.TextBox ) GridViewStreetAddress.FooterRow.FindControl("TextBoxGridViewStreetAddressFooterTemplateCountry")).Text;

      if ( sequenceOrderId > 0 )
      {
       SqlDataSourceStreetAddress.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
      }
      if ( dated != DateTime.MinValue )
      {
       SqlDataSourceStreetAddress.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
      }
      SqlDataSourceStreetAddress.InsertParameters["addressLine1"].DefaultValue      =  addressLine1;
      SqlDataSourceStreetAddress.InsertParameters["city"].DefaultValue              =  city;
      SqlDataSourceStreetAddress.InsertParameters["state"].DefaultValue             =  state;
      SqlDataSourceStreetAddress.InsertParameters["zipCode"].DefaultValue           =  zipCode;
      SqlDataSourceStreetAddress.InsertParameters["country"].DefaultValue           =  country;
      SqlDataSourceStreetAddress.Insert();
      break;

   	 case "ButtonGridViewCaseBasedReasoningFooterTemplateAdd":
      DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewCaseBasedReasoning.FooterRow.FindControl("TextBoxGridViewCaseBasedReasoningFooterTemplateDated")).Text, out dated );
      Int32.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewCaseBasedReasoning.FooterRow.FindControl("TextBoxGridViewCaseBasedReasoningFooterTemplateSequenceOrderId")).Text, out sequenceOrderId );
 
      commentary  =  ( ( System.Web.UI.WebControls.TextBox ) GridViewCaseBasedReasoning.FooterRow.FindControl("TextBoxGridViewCaseBasedReasoningFooterTemplateCommentary")).Text;

      if ( sequenceOrderId > 0 )
      {
       SqlDataSourceCaseBasedReasoning.InsertParameters["sequenceOrderId"].DefaultValue  =  System.Convert.ToString( sequenceOrderId );
      }
      if ( dated != DateTime.MinValue )
      {
       SqlDataSourceCaseBasedReasoning.InsertParameters["dated"].DefaultValue            =  System.Convert.ToString( dated );
      }
      SqlDataSourceCaseBasedReasoning.InsertParameters["commentary"].DefaultValue        =  commentary;
      SqlDataSourceCaseBasedReasoning.Insert();
      break;

    }//switch ( gridViewCommandEventArgs.CommandName  )
   }//try
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }//catch ( System.Exception exception )
   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   	return;
   }//if ( exceptionMessage != null )
   //GridViewContact.DataBind();
  }//public void GridView_RowCommand()

  /// <summary>GridView_RowUpdated</summary>
  public void GridView_RowUpdated
  (
   Object                    sender, 
   GridViewUpdatedEventArgs  gridViewUpdatedEventArgs
  )
  {
   // Use the Exception property to determine whether an exception
   // occurred during the insert operation.
   if ( gridViewUpdatedEventArgs.Exception != null )
   {
    // Insert the code to handle the exception.
    Feedback = gridViewUpdatedEventArgs.Exception.Message;

    // Use the ExceptionHandled property to indicate that the 
    // exception is already handled.
    gridViewUpdatedEventArgs.ExceptionHandled = true;

    // When an exception occurs, keep the GridView
    // control in edit mode.
    gridViewUpdatedEventArgs.KeepInEditMode = true;
   }//if ( gridViewUpdatedEventArgs.Exception != null )
  }//public void GridView_RowUpdated

  /// <summary>GridView_RowUpdating</summary>
  /// <remarks>
  ///  Forums.asp.net/837823/ShowPost.aspx  How to access uploaded file in gridview? Thanks!
  ///  msdn2.microsoft.com/en-us/library/xcfst372 GridViewRow Class (System.Web.UI.WebControls)
  ///  fredrik.nsquared2.com/viewpost.aspx?PostID=292  Add a FileUpload control to your GridView 
  /// </remarks>
  public void GridView_RowUpdating
  (
   Object                    sender, 
   GridViewUpdateEventArgs   e
  )
  {
   byte[]       fileUploadImageContent    =  null;
   int          contactId                 =  -1;
   int          sequenceOrderId           =  -1;
   string       exceptionMessage          =  null;
   string       fileUploadImageType       =  null;
   DateTime     dated                     =  DateTime.Now;
   FileUpload   fileUploadImageSource     =  null;
   GridViewRow  gridViewRow               =  null;
   if ( sender == GridViewContactImage )
   {
    try
    {
     gridViewRow  =  GridViewContactImage.Rows[e.RowIndex];
     Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) GridViewContactImage.Rows[e.RowIndex].FindControl("LabelGridViewContactImageItemTemplateSequenceOrderId")).Text, out sequenceOrderId );
     DateTime.TryParse( ( ( System.Web.UI.WebControls.TextBox ) GridViewContactImage.Rows[e.RowIndex].FindControl("TextBoxGridViewContactImageEditItemTemplateDated")).Text, out dated );
     Int32.TryParse( ( ( System.Web.UI.WebControls.Label ) GridViewContact.SelectedRow.FindControl("LabelGridViewContactItemTemplateSequenceOrderId")).Text, out contactId );
     fileUploadImageSource  =  ( FileUpload ) GridViewContactImage.Rows[e.RowIndex].FindControl("FileUploadGridViewContactImageEditItemTemplateImageSource");
     if ( fileUploadImageSource.HasFile == false ) { e.Cancel = false; return; }
     fileUploadImageType  =  fileUploadImageSource.PostedFile.ContentType;
     UtilityContact.ContactImageUpdate
     (
      ref DatabaseConnectionString,
      ref exceptionMessage,
      ref sequenceOrderId,
      ref dated,
      ref contactId,
      ref fileUploadImageContent,
      ref fileUploadImageSource,
      ref fileUploadImageType      
     ); 
     SqlDataSourceContactImage.UpdateParameters["dated"].DefaultValue       = dated.ToString();
     SqlDataSourceContactImage.UpdateParameters["imageSource"].DefaultValue = fileUploadImageSource.PostedFile.FileName;
    }//try
    catch ( Exception exception ) { UtilityException.ExceptionLog( exception, exception.GetType().Name, ref exceptionMessage ); }
    if ( exceptionMessage != null ) { Feedback = exceptionMessage; }
   }//if ( sender == GridViewContactImage ) 
  }//public void GridView_RowUpdating

  /// <summary>MailSend</summary>
  public void MailSend()
  {
   string  emailRecipient    =  null;
   string  exceptionMessage  =  null;
   emailRecipient            =  EmailRecipient;
   UtilityMail.MailSend
   (
        this,
    ref emailRecipient,
    ref exceptionMessage
   );
  }//public static void MailSend()

  /// <summary>SqlDataSource_Selected</summary>
  /// <remarks>Fredrik.NSquared2.com/viewpost.aspx?PostID=336&amp;showfeedback=true</remarks>
  public void SqlDataSource_Selected(object sender, SqlDataSourceStatusEventArgs e)
  {
   int rowCount = e.AffectedRows;
  }
	
 }//ContactMaintenancePage class.
}//WordEngineering namespace.
