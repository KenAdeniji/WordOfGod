using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>IISLogPage</summary>
 public class IISLogPage : Page
 {

  /// <summary>Log</summary>
  protected System.Web.UI.WebControls.DropDownList           Log;

  /// <summary>WebSite</summary>
  protected System.Web.UI.WebControls.DropDownList           WebSite;

  /// <summary>IISLog</summary>
  protected System.Web.UI.HtmlControls.HtmlGenericControl    IISLog;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>Computer</summary>
  protected System.Web.UI.WebControls.TextBox                Computer;
  
  /// <summary>WebSiteDefault</summary>
  public static string[] WebSiteDefault = new string[] { "W3SVC1", "W3SVC2" };

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  )
  {
   Ajax.Utility.RegisterTypeForAjax( typeof ( IISLogPage ) ); 
   WebSite.DataSource = WebSiteDefault;
   WebSite.DataBind();
   //Computer.Attributes.Add("onchange", "LoadSite(this);");
  }

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
  }//public String public String Feedback

  /// <summary>LoadLog</summary>
  [Ajax.AjaxMethod]
  public string[] LoadLog( string computer, string site )
  {
   List<string> log = new List<string>();
   UtilityIISLogArgument utilityIISLogArgument;
   utilityIISLogArgument = new UtilityIISLogArgument( computer, null, site );
   UtilityIISLog.LoadLog
   (
        utilityIISLogArgument,
    out log
   );
   return ( log.ToArray() );
  }
   
  /// <summary>LoadSite</summary>
  [Ajax.AjaxMethod]
  public string[] LoadSite( string computer )
  {
   List<string> site = new List<string>();
   UtilityIISLogArgument utilityIISLogArgument;
   utilityIISLogArgument = new UtilityIISLogArgument( computer, null, null );
   UtilityIISLog.LoadSite
   (
        utilityIISLogArgument,
    out site
   );
   return ( site.ToArray() );
  }

  /// <summary>ParseLog</summary>
  [Ajax.AjaxMethod]
  public DataTable ParseLog( string computer, string log, string site )
  {
   DataTable dataTable; 
   UtilityIISLogArgument utilityIISLogArgument;
   utilityIISLogArgument = new UtilityIISLogArgument( computer, log, site );
   UtilityIISLog.ParseLog
   (
        utilityIISLogArgument,
    out dataTable
   );
   return ( dataTable );
  }
  
 }//IISLogPage class.
}//WordEngineering namespace.
