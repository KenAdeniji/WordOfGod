using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Xml;

namespace WordEngineering
{
 /// <summary>SQLServerManagementObjectsSMOPage</summary>
 public class SQLServerManagementObjectsSMOPage : Page
 {

  /// <summary>The database connection String.</summary>
  public String   DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=ImageCarbon;";

  /// <summary>DatabaseName</summary>
  public String[] DatabaseName                   = UtilitySQLServerManagementObjectsSMO.DatabaseName;

  /// <summary>DefaultName</summary>
  public String[] DefaultName                    = UtilitySQLServerManagementObjectsSMO.DefaultName;

  /// <summary>DirectoryBackup</summary>
  public String   DirectoryBackup                = UtilitySQLServerManagementObjectsSMO.DirectoryBackup;

  /// <summary>DirectoryMaintenance</summary>
  public String   DirectoryMaintenance           = UtilitySQLServerManagementObjectsSMO.DirectoryMaintenance;

  /// <summary>DirectoryScript</summary>
  public String   DirectoryScript                = UtilitySQLServerManagementObjectsSMO.DirectoryScript;

  /// <summary>The configuration XML filename.</summary>
  public String   FilenameConfigurationXml       = UtilitySQLServerManagementObjectsSMO.FilenameConfigurationXml;

  /// <summary>The server map path.</summary>
  public String   ServerMapPath                  = null;

  /// <summary>ServerMachineName</summary>
  public string   ServerMachineName              = null;

  /// <summary>RuleName</summary>
  public String[] RuleName                       = UtilitySQLServerManagementObjectsSMO.RuleName;

  /// <summary>ServerName</summary>
  public String[] ServerName                     = UtilitySQLServerManagementObjectsSMO.ServerName;

  /// <summary>SqlServerLoginUserName</summary>
  public string   SqlServerLoginUserName         = UtilitySQLServerManagementObjectsSMO.SqlServerLoginUserName;

  /// <summary>SqlServerPassword</summary>
  public string   SqlServerPassword              = UtilitySQLServerManagementObjectsSMO.SqlServerPassword;

  /// <summary>StoredProcedureName</summary>
  public String[] StoredProcedureName            = UtilitySQLServerManagementObjectsSMO.StoredProcedureName;

  /// <summary>TableName</summary>
  public String[] TableName                      = UtilitySQLServerManagementObjectsSMO.TableName;

  /// <summary>TriggerName</summary>
  public String[] TriggerName                    = UtilitySQLServerManagementObjectsSMO.TriggerName;

  /// <summary>UserDefinedDataTypeName</summary>
  public String[] UserDefinedDataTypeName        = UtilitySQLServerManagementObjectsSMO.UserDefinedDataTypeName;

  /// <summary>UserDefinedFunctionName</summary>
  public String[] UserDefinedFunctionName        = UtilitySQLServerManagementObjectsSMO.UserDefinedFunctionName;

  /// <summary>ViewName</summary>
  public String[] ViewName                       = UtilitySQLServerManagementObjectsSMO.ViewName;

  /// <summary>ButtonReset.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonReset;

  /// <summary>ButtonSubmit.</summary>  
  protected System.Web.UI.WebControls.Button             ButtonSubmit;

  /// <summary>CheckBoxBackup</summary>  
  protected System.Web.UI.WebControls.CheckBox           CheckBoxBackup;

  /// <summary>CheckBoxMaintenance</summary>  
  protected System.Web.UI.WebControls.CheckBox           CheckBoxMaintenance;

  /// <summary>CheckBoxScript</summary>  
  protected System.Web.UI.WebControls.CheckBox           CheckBoxScript;

  /// <summary>CheckBoxSystem</summary>  
  protected System.Web.UI.WebControls.CheckBox           CheckBoxSystem;

  /// <summary>CheckBoxUser</summary>  
  protected System.Web.UI.WebControls.CheckBox           CheckBoxUser;

  /// <summary>ListBoxDatabase</summary>
  protected System.Web.UI.WebControls.ListBox            ListBoxDatabase;

  /// <summary>ListBoxDefault</summary>
  protected System.Web.UI.WebControls.ListBox            ListBoxDefault;

  /// <summary>ListBoxRule</summary>  
  protected System.Web.UI.WebControls.ListBox            ListBoxRule;

  /// <summary>ListBoxServer</summary>  
  protected System.Web.UI.WebControls.ListBox            ListBoxServer;

  /// <summary>ListBoxStoredProcedure</summary>  
  protected System.Web.UI.WebControls.ListBox            ListBoxStoredProcedure;

  /// <summary>ListBoxTable</summary>
  protected System.Web.UI.WebControls.ListBox            ListBoxTable;

  /// <summary>ListBoxTrigger</summary>
  protected System.Web.UI.WebControls.ListBox            ListBoxTrigger;

  /// <summary>ListBoxUserDefinedDataType</summary>  
  protected System.Web.UI.WebControls.ListBox            ListBoxUserDefinedDataType;

  /// <summary>ListBoxUserDefinedFunction</summary>  
  protected System.Web.UI.WebControls.ListBox            ListBoxUserDefinedFunction;

  /// <summary>ListBoxView</summary>  
  protected System.Web.UI.WebControls.ListBox            ListBoxView;

  /// <summary>Feedback</summary>
  protected System.Web.UI.WebControls.Literal            LiteralFeedback;

  /// <summary>TextBoxBackupDirectory</summary>
  protected System.Web.UI.WebControls.TextBox            TextBoxBackupDirectory;

  /// <summary>TextBoxMaintenanceDirectory</summary>
  protected System.Web.UI.WebControls.TextBox            TextBoxMaintenanceDirectory;

  /// <summary>TextBoxScriptDirectory</summary>
  protected System.Web.UI.WebControls.TextBox            TextBoxScriptDirectory;

  /// <summary>TextBoxSqlServerLoginUserName</summary>
  protected System.Web.UI.WebControls.TextBox            TextBoxSqlServerLoginUserName;

  /// <summary>TextBoxSqlServerPassword</summary>
  protected System.Web.UI.WebControls.TextBox            TextBoxSqlServerPassword;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String  exceptionMessage  =  null;

   try
   {
    Server.ScriptTimeout = 60 * 60 * 12; //12 hours  
    ServerMachineName = Server.MachineName;

    ServerMapPath = this.MapPath("");

    /* 
    FilenameConfigurationXml = Server.MapPath( FilenameConfigurationXml );
    */

    if ( ServerMapPath != null)
    {
     FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
    }//if ( ServerMapPath != null)

    if ( !Page.IsPostBack )
    {
     UtilitySQLServerManagementObjectsSMO.SQLServerList
     (
      ref ServerName,
      ref exceptionMessage
     );
     if ( exceptionMessage != null )
     {
      Feedback = exceptionMessage;
      return;
     }//if ( exceptionMessage != null )
     UtilitySQLServerManagementObjectsSMO.ConfigurationXml
     (
          FilenameConfigurationXml,
      ref exceptionMessage,
      ref DatabaseConnectionString,
      ref DatabaseName,
      ref DefaultName,
      ref DirectoryBackup,
      ref DirectoryMaintenance,
      ref DirectoryScript,
      ref RuleName,
      ref ServerName,
      ref SqlServerLoginUserName,
      ref SqlServerPassword,
      ref StoredProcedureName,
      ref TableName,
      ref TriggerName,
      ref UserDefinedDataTypeName,
      ref UserDefinedFunctionName,
      ref ViewName
     );
     if ( exceptionMessage != null )
     {
      Feedback = exceptionMessage;
      return;
     }//if ( exceptionMessage != null )
     ListBoxServer.DataSource = ServerName;
     ListBoxServer.DataBind();
     if 
     ( 
      Array.BinarySearch
      ( 
       ServerName, 
       ServerMachineName,
       System.Collections.CaseInsensitiveComparer.DefaultInvariant
       ) >= 0
     )
     {
      UtilityWebControl.SelectItem
      (
       ListBoxServer,
       ServerMachineName
      );
      ServerSelected();
     }//if ( Array.BinarySearch( ServerName, ServerMachineName, System.Collections.CaseInsensitiveComparer.DefaultInvariant ) >= 0 )
     BackupDirectory         = DirectoryBackup;
     MaintenanceDirectory    = DirectoryMaintenance;
     ScriptDirectory         = DirectoryScript;
     if ( !string.IsNullOrEmpty( SqlServerLoginUserName ) )
     {
      SQLServerLoginUserName  =  SqlServerLoginUserName;
     }
     if ( !string.IsNullOrEmpty( SqlServerPassword ) )
     {
      SQLServerPassword       =  SqlServerPassword;
     }
    }//if ( !Page.IsPostBack )
   }//try
   catch ( System.Exception exception )
   {
    exceptionMessage = "System.Exception: " + exception.Message;
   }
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )
  }//Page_Load

  /// <summary>BackupDirectory</summary>
  public String BackupDirectory
  {
   get
   {
    return ( TextBoxBackupDirectory.Text );
   } 
   set
   {
    TextBoxBackupDirectory.Text = value;
   }
  }//public String public String BackupDirectory

  /// <summary>MaintenanceDirectory</summary>
  public String MaintenanceDirectory
  {
   get
   {
    return ( TextBoxMaintenanceDirectory.Text );
   } 
   set
   {
    TextBoxMaintenanceDirectory.Text = value;
   }
  }//public String public String MaintenanceDirectory

  /// <summary>ScriptDirectory</summary>
  public String ScriptDirectory
  {
   get
   {
    return ( TextBoxScriptDirectory.Text );
   } 
   set
   {
    TextBoxScriptDirectory.Text = value;
   }
  }//public String public String ScriptDirectory

  /// <summary>SQLServerLoginUserName</summary>
  public String SQLServerLoginUserName
  {
   get
   {
    return ( TextBoxSqlServerLoginUserName.Text );
   } 
   set
   {
    TextBoxSqlServerLoginUserName.Text = value;
   }
  }//public String public String SQLServerLoginUserName

  /// <summary>SQLServerPassword</summary>
  public String SQLServerPassword  
  {
   get
   {
    return ( TextBoxSqlServerPassword.Text );
   } 
   set
   {
    TextBoxSqlServerPassword.Attributes.Add("value", value);
   }
  }//public String public String SQLServerPassword
  
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

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   string[]                                       defaultName                                    =  null;
   string[]                                       database                                       =  null;
   String                                         exceptionMessage                               =  null;
   string[]                                       rule                                           =  null;
   string[]                                       server                                         =  null;
   string[]                                       storedProcedure                                =  null;
   string[]                                       table                                          =  null;
   string[]                                       trigger                                        =  null;   
   string[]                                       userDefinedDataType                            =  null;
   string[]                                       userDefinedFunction                            =  null;
   string[]                                       view                                           =  null;

   UtilitySQLServerManagementObjectsSMOArgument   UtilitySQLServerManagementObjectsSMOArgument   =  null;
   
   /*
   if( sender == ButtonSubmit )
   {
    Response.Write ( "ButtonSubmit" );
    Feedback = "ButtonSubmit";
   }
   */

   try
   {
    UtilityWebControl.SelectedItem
    ( 
         ListBoxServer,
     ref server
    );

    UtilityWebControl.SelectedItem
    ( 
         ListBoxDatabase,
     ref database
    );

    UtilityWebControl.SelectedItem
    ( 
         ListBoxDefault,
     ref defaultName
    );

    UtilityWebControl.SelectedItem
    ( 
         ListBoxRule,
     ref rule
    );

    UtilityWebControl.SelectedItem
    ( 
         ListBoxStoredProcedure,
     ref storedProcedure
    );

    UtilityWebControl.SelectedItem
    ( 
         ListBoxTable,
     ref table
    );

    UtilityWebControl.SelectedItem
    ( 
         ListBoxTrigger,
     ref trigger
    );

    UtilityWebControl.SelectedItem
    ( 
         ListBoxUserDefinedDataType,
     ref userDefinedDataType
    );

    UtilityWebControl.SelectedItem
    ( 
         ListBoxUserDefinedFunction,
     ref userDefinedFunction
    );

    UtilityWebControl.SelectedItem
    ( 
         ListBoxView,
     ref view
    );

    UtilitySQLServerManagementObjectsSMOArgument = new UtilitySQLServerManagementObjectsSMOArgument
    (
     CheckBoxBackup.Checked,
     database,
     defaultName,
     BackupDirectory,
     MaintenanceDirectory,
     ScriptDirectory,
     CheckBoxMaintenance.Checked,
     rule,
     CheckBoxScript.Checked,
     server,
     SQLServerLoginUserName,
     SQLServerPassword,
     storedProcedure,
     CheckBoxSystem.Checked,
     table,
     trigger,
     CheckBoxUser.Checked,
     userDefinedDataType,
     userDefinedFunction,
     view
    );

    UtilitySQLServerManagementObjectsSMO.UtilitySMO
    (
     ref UtilitySQLServerManagementObjectsSMOArgument,
     ref exceptionMessage
    );

    if ( exceptionMessage != null )
    {
     Feedback = exceptionMessage;
     return;
    }//if ( exceptionMessage != null )

   }//try
   catch ( System.Exception exception )
   {
   	exceptionMessage = exception.Message;
   }
   
   Feedback = exceptionMessage;
   
  }//public void ButtonSubmit_Click()

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback         =  null;
   
   UtilityJavaScript.SetFocus
   ( 
    this,
    ListBoxServer
   );
  }//public void ButtonReset_Click()

  /// <summary>Server_Index_Changed()</summary>
  public void Server_Index_Changed(Object sender, EventArgs e) 
  {
   ServerSelected();
  }//public void Server_Index_Changed(Object sender, EventArgs e) 

  /// <summary>ServerSelected()</summary>
  public void ServerSelected()
  {
   bool      system                  =  false;
   bool      user                    =  false;
   string[]  database                =  null;
   string    exceptionMessage        =  null;
   string[]  selectedServer          =  null;
   string    sqlServerLoginUserName  =  null;
   string    sqlServerPassword       =  null;
   
   try
   {
    UtilityWebControl.SelectedItem
    ( 
         ListBoxServer,
     ref selectedServer
    );
    if ( selectedServer == null || selectedServer.Length != 1 )
    {
   	 return;
    }	
    ViewState["SQLServerManagementObjectsSMOPage_ServerSelectedFirst"] = selectedServer[0];
    sqlServerLoginUserName = SQLServerLoginUserName;
    sqlServerPassword      = SQLServerPassword;
    system                 = CheckBoxSystem.Checked;
    user                   = CheckBoxUser.Checked;
    UtilitySQLServerManagementObjectsSMO.DatabaseList
    (
     ref selectedServer[0],
     ref exceptionMessage,
     ref database,
     ref sqlServerLoginUserName,
     ref sqlServerPassword,
     ref system,
     ref user
    );
    if ( exceptionMessage != null )
    {
     Feedback = exceptionMessage;
     return;
    }//if ( exceptionMessage != null )
    if ( database == null || database.Length < 1 )
    {
     return;
    }//if ( database == null || database.Length < 1 )
    ListBoxDatabase.DataSource = database;
    ListBoxDatabase.DataBind();
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
  }//public void ServerSelected(Object sender, EventArgs e) 

  /// <summary>Database_Index_Changed()</summary>
  public void Database_Index_Changed(Object sender, EventArgs e) 
  {
   DatabaseSelected();
  }//public void Database_Index_Changed(Object sender, EventArgs e) 

  /// <summary>DatabaseSelected()</summary>
  public void DatabaseSelected()
  {
   bool      system                  =  false;
   bool      user                    =  false;
   string    serverSelectedFirst     =  null;
   string    exceptionMessage        =  null;
   string[]  defaultName             =  null;
   string[]  rule                    =  null;
   string[]  selectedDatabase        =  null;
   string    sqlServerLoginUserName  =  null;
   string    sqlServerPassword       =  null;
   string[]  storedProcedure         =  null;   
   string[]  table                   =  null;
   string[]  trigger                 =  null;
   string[]  userDefinedDataType     =  null;
   string[]  userDefinedFunction     =  null;
   string[]  view                    =  null;

   try
   {
    serverSelectedFirst = (string) ViewState["SQLServerManagementObjectsSMOPage_ServerSelectedFirst"];
    if ( string.IsNullOrEmpty( serverSelectedFirst ) )
    {
     return;
    }     	
    UtilityWebControl.SelectedItem
    ( 
         ListBoxDatabase,
     ref selectedDatabase
    );
    if ( selectedDatabase == null || selectedDatabase.Length != 1 )
    {
     return;
    }
    sqlServerLoginUserName  =  SQLServerLoginUserName;  
    sqlServerPassword       =  SQLServerPassword;
    system                  =  CheckBoxSystem.Checked;
    user                    =  CheckBoxUser.Checked;    
    UtilitySQLServerManagementObjectsSMO.DatabaseResource
    (
     ref serverSelectedFirst,
     ref selectedDatabase[0],
     ref exceptionMessage,
     ref sqlServerLoginUserName,
     ref sqlServerPassword,
     ref system,
     ref user,
     ref defaultName,
     ref rule,
     ref storedProcedure,
     ref table,
     ref trigger,
     ref userDefinedDataType,
     ref userDefinedFunction,
     ref view
    );
    if ( exceptionMessage != null )
    {
     Feedback = exceptionMessage;
     return;
    }//if ( exceptionMessage != null )
    ListBoxDefault.DataSource = defaultName;
    ListBoxDefault.DataBind();
    ListBoxRule.DataSource = rule;
    ListBoxRule.DataBind();
    ListBoxStoredProcedure.DataSource = storedProcedure;
    ListBoxStoredProcedure.DataBind();
    ListBoxTable.DataSource = table;
    ListBoxTable.DataBind();
    ListBoxTrigger.DataSource = trigger;
    ListBoxTrigger.DataBind();
    ListBoxUserDefinedDataType.DataSource = userDefinedDataType;
    ListBoxUserDefinedDataType.DataBind();
    ListBoxUserDefinedFunction.DataSource = userDefinedFunction;
    ListBoxUserDefinedFunction.DataBind();
    ListBoxView.DataSource = view;
    ListBoxView.DataBind();
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
  }//public void DatabaseSelected()
  
 }//SQLServerManagementObjectsSMOPage class.
}//WordEngineering namespace.