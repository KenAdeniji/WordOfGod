using  System;
using  System.Collections;
using  System.Web.UI;
using  System.Web.UI.HtmlControls;
using  System.Web.UI.WebControls;
using  System.Data;
using  System.Data.OleDb;
using  System.Data.SqlClient;
using  System.Text;

using  WordEngineering;

namespace WordEngineering
{
 /// <summary>Google: Advanced search page.</summary>
 public class GoogleAdvancedSearchPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string databaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Bible;";
  
  /// <summary>The configuration XML filename.</summary>
  public string filenameConfigurationXml = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public string serverMapPath                  = null;

  /// <summary>The search button.</summary>
  protected Button                  ButtonSearch;
 
  /// <summary>The max results DropDownList.</summary>
  protected DropDownList            DropDownListMaxResults;

  /// <summary>The Search result.</summary>
  protected HtmlGenericControl      HtmlGenericControlSearchResult;

  /// <summary>The exception message.</summary>  
  protected Literal                 LiteralFeedback;

  /// <summary>With all of the words.</summary>  
  protected TextBox                 TextBoxWithAllOfTheWords;

  /// <summary>With at least one of the words.</summary>  
  protected TextBox                 TextBoxWithAtLeastOneOfTheWords;

  /// <summary>With the exact phrase.</summary>  
  protected TextBox                 TextBoxWithTheExactPhrase;

  /// <summary>Without the words.</summary>  
  protected TextBox                 TextBoxWithoutTheWords;
 
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   string              exceptionMessage                = null;
 
   serverMapPath = this.MapPath("");
   if ( serverMapPath != null)
   {
    filenameConfigurationXml = serverMapPath + @"\" + filenameConfigurationXml;
   }//if ( serverMapPath != null)
   UtilityGoogle.ConfigurationXml
   (
        filenameConfigurationXml,
    ref exceptionMessage
   );
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 
  }//Page_Load

  /// <summary>ButtonSearch_Click().</summary>
  public void ButtonSearch_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   PageSubmit();
  }
  
  /// <summary>PageSubmit().</summary>
  public void PageSubmit()
  {
   int           maxResults         =  MaxResults;
   string        exceptionMessage   =  null;
   string        withAllOfTheWords  =  WithAllOfTheWords;
   StringBuilder sbResultElement    =  null;
   
   UtilityGoogle.Search
   (
    ref withAllOfTheWords,
    ref maxResults,
    ref exceptionMessage,
    ref sbResultElement
   );
   
   if ( exceptionMessage == null )
   {
   	SearchResult = sbResultElement.ToString();
   }//if ( exceptionMessage == null )	
   else
   {
    Feedback = exceptionMessage;
   }//if ( exceptionMessage != null ) 
   
  }//public void PageSubmit()

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

  /// <summary>With all of the words.</summary>
  public int MaxResults
  {
   get
   {
    int  maxResults  =  UtilityGoogle.MaxResults;
    Int32.TryParse( DropDownListMaxResults.SelectedValue, out maxResults );
    return ( maxResults );
   } 
   set
   {
    DropDownListMaxResults.SelectedValue = value.ToString();
   }
  }//public string public string WithAllOfTheWords

  /// <summary>Search Result.</summary>
  public string SearchResult
  {
   get
   {
    return ( HtmlGenericControlSearchResult.InnerHtml.Trim() );
   } 
   set
   {
    HtmlGenericControlSearchResult.InnerHtml = value;
   }
  }//public string SearchResult

  /// <summary>With all of the words.</summary>
  public string WithAllOfTheWords
  {
   get
   {
    return (TextBoxWithAllOfTheWords.Text);
   } 
   set
   {
    TextBoxWithAllOfTheWords.Text = value;
   }
  }//public string public string WithAllOfTheWords

  /// <summary>With at least one of the words.</summary>
  public string WithAtLeastOneOfTheWords
  {
   get
   {
    return (TextBoxWithAtLeastOneOfTheWords.Text);
   } 
   set
   {
    TextBoxWithAtLeastOneOfTheWords.Text = value;
   }
  }//public string public string WithAllOfTheWords

  /// <summary>With the exact phrase.</summary>
  public string WithTheExactPhrase
  {
   get
   {
    return (TextBoxWithTheExactPhrase.Text);
   } 
   set
   {
    TextBoxWithTheExactPhrase.Text = value;
   }
  }//public string public string WithTheExactPhrase

  /// <summary>Without the words.</summary>
  public string WithoutTheWords
  {
   get
   {
    return (TextBoxWithoutTheWords.Text);
   } 
   set
   {
    TextBoxWithoutTheWords.Text = value;
   }
  }//public string public string WithoutTheWords
 }//GoogleAdvancedSearchPage class.
}//WordEngineering namespace.