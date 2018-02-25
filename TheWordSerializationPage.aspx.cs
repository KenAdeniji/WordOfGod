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
 /// <summary>TheWordSerialization page.</summary>
 public class TheWordSerializationPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>HtmlInputFileFilenameXmlDocument.</summary>
  protected System.Web.UI.HtmlControls.HtmlInputFile     HtmlInputFileFilenameXmlDocument;

  /// <summary>HtmlInputFileFilenameXmlDocumentGenerate.</summary>
  protected System.Web.UI.HtmlControls.HtmlInputFile     HtmlInputFileFilenameXmlDocumentGenerate;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonReset;

  /// <summary>ButtonSubmit.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonSubmit;

  /// <summary>The exception message.</summary>
  protected System.Web.UI.WebControls.Literal            LiteralFeedback;

  /// <summary>TextBoxTheWordId.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxTheWordId;

  /// <summary>TextBoxTheWordDated.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxTheWordDated;

  /// <summary>TextBoxFilenameStylesheet.</summary>  
  protected System.Web.UI.WebControls.TextBox            TextBoxFilenameStylesheet;

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

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        TheWordSerialization.XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );

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

  /// <summary>FilenameXmlDocumentGenerate.</summary>
  public String FilenameXmlDocumentGenerate
  {
   get
   {
    return ( HtmlInputFileFilenameXmlDocumentGenerate.Value );
   }//get 
   set
   {
    HtmlInputFileFilenameXmlDocumentGenerate.Value = value;
   }//set
  }//public String FilenameXmlDocumentGenerate

  /// <summary>TheWordId.</summary>
  public string TheWordId
  {
   get
   {
    return ( TextBoxTheWordId.Text );
   }//get 
   set
   {
    value = null;
   }//set
  }//public string TheWordId

  /// <summary>TheWordDated.</summary>
  public string TheWordDated
  {
   get
   {
    return ( TextBoxTheWordDated.Text );
   }//get 
   set
   {
    value = null;
   }//set
  }//public string TheWordDated

  /// <summary>FilenameXmlDocument.</summary>
  public string FilenameXmlDocument
  {
   get
   {
    return ( HtmlInputFileFilenameXmlDocument.Value );
   }//get 
   set
   {
    HtmlInputFileFilenameXmlDocument.Value = value;
   }//set
  }//public string FilenameXmlDocument

  /// <summary>FilenameStylesheet.</summary>
  public string FilenameStylesheet
  {
   get
   {
    return ( TextBoxFilenameStylesheet.Text );
   }//get 
   set
   {
    value = null;
   }//set
  }//public string FilenameStylesheet

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   int                            theWordId                     =  -1;

   String                         exceptionMessage              =  null;

   DataSet                        dataSetTheWord                =  null;

   TheWordSerializationArgument   theWordSerializationArgument  =  null;

   if ( TheWordId != null && TheWordId != String.Empty )
   {
    theWordId = System.Convert.ToInt32( TheWordId );
   }

   theWordSerializationArgument  =  new TheWordSerializationArgument
   (
    theWordId,
    TheWordDated,
    FilenameXmlDocument,
    FilenameXmlDocumentGenerate,
    FilenameStylesheet
   );

   TheWord.UtilitySerialization
   (
    ref FilenameConfigurationXml,
    ref DatabaseConnectionString,
    ref theWordSerializationArgument,
    ref dataSetTheWord,
    ref exceptionMessage
   );

   Feedback = exceptionMessage;

  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback             =  null;
   TheWordId            =  null;
   TheWordDated         =  null;
   FilenameXmlDocument  =  null;
   FilenameStylesheet   =  null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxTheWordId
   );
  }//public void ButtonReset_Click()
  
 }//TheWordSerializationPage class.
}//WordEngineering namespace.