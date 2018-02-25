using System;
using System.Collections;
using System.Collections.Specialized;
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
using System.Text.RegularExpressions;
using System.Xml;

namespace WordEngineering
{
 /// <summary>EventLogPage</summary>
 /// <remarks>Written by: Christoph Wille Translated by: Bernhard Spuida http://www.aspheute.com/english/20000811.asp Displaying Event Log Entries the ASP.NET Way</remarks>
 public class EventLogPage : Page
 {
  /// <summary>LogList</summary>
  public static readonly String[] LogList             = new string[]
                                                        {
                                                         "Application",
                                                         "Security",
                                                         "System",
                                                         "DNS Server"  	
                                                        };                                                        	

  /// <summary>The server map path.</summary>
  public static string ServerMapPath                 = null;

  /// <summary>ButtonReset</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>DropDownListLogName</summary>
  protected System.Web.UI.WebControls.DropDownList           DropDownListLogName;

  /// <summary>GridViewEventLog</summary>
  protected System.Web.UI.WebControls.GridView               GridViewEventLog;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>TextBoxMachineName</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxMachineName;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   ServerMapPath = this.MapPath("");

   if ( !Page.IsPostBack )
   {
    if ( ServerMapPath != null)
    {
    }//if ( ServerMapPath != null)
    GridViewEventLog.Focus();
    Page.SetFocus( GridViewEventLog );
   }//if ( !Page.IsPostBack )
   	
  }//Page_Load

  /// <summary>DropDownListLogName_PreRender</summary>
  public void DropDownListLogName_PreRender
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   if ( !Page.IsPostBack )
   {
    if ( DropDownListLogName.Items.Count < 1 )
    {
     DropDownListLogName.DataSource = LogList;
     DropDownListLogName.DataBind();
    }//if ( DropDownListLogName.Items.Count < 1 )
    DropDownListLogName.SelectedValue = LogList[0];
   }//if ( !Page.IsPostBack ) 
  }//public void DropDownListLogName_PreRender()

  ///<summary>GridView_PageIndexChanging</summary>
  public void GridView_PageIndexChanging( Object sender, GridViewPageEventArgs e )
  {
   GridViewEventLog.PageIndex = e.NewPageIndex;
   EventLogEntries();
  }

  ///<summary>GridView_Sorting</summary>
  ///<remarks>DataSource CanSort = true</remarks>
  public void GridView_Sorting( Object sender, GridViewSortEventArgs e )
  {
   
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

  /// <summary>MachineName</summary>
  public String MachineName  
  {
   get
   {
    return ( TextBoxMachineName.Text );
   } 
   set
   {
    TextBoxMachineName.Text = value;
   }
  }//public String MachineName
  
  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   EventLogEntries();
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   DropDownListLogName.SelectedValue = LogList[0];
   MachineName = ".";
   Page.SetFocus( DropDownListLogName );
  }//public void ButtonReset_Click()

  /// <summary>EventLogEntries</summary>
  public void EventLogEntries()
  {
   string    exceptionMessage    =  null;
   EventLog  eventLog            =  new EventLog();
   
   try
   {
    eventLog.Log                 =  DropDownListLogName.SelectedValue;
    eventLog.MachineName         =  MachineName;
    GridViewEventLog.DataSource  =  eventLog.Entries;
    GridViewEventLog.DataBind();
   }
   catch ( Exception exception ) { exceptionMessage = exception.Message; }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
   }	
  }//public void EventLogEntries
 }//EventLogPage class.
}//WordEngineering namespace.