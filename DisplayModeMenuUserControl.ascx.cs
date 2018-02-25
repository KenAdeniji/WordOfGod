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
using System.Web.UI.WebControls.WebParts;
using System.Net;
using System.Text;
using System.Xml;

namespace WordEngineering
{
 /// <summary>DisplayModeMenuUserControl</summary>
 public partial class DisplayModeMenuUserControl : System.Web.UI.UserControl
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

  /// <summary>ButtonSearch</summary>  
  protected System.Web.UI.WebControls.Button              ButtonSearch;

  /// <summary>DropDownListDisplayMode</summary>  
  protected System.Web.UI.WebControls.DropDownList        DropDownListDisplayMode;

  /// <summary>PanelPersonalizationScope</summary>  
  protected System.Web.UI.WebControls.Panel               PanelPersonalizationScope;

  /// <summary>RadioButtonShared</summary>  
  protected System.Web.UI.WebControls.RadioButton         RadioButtonShared;

  /// <summary>RadioButtonUser</summary>  
  protected System.Web.UI.WebControls.RadioButton         RadioButtonUser;

  /// <summary>TextBoxInput</summary>  
  protected System.Web.UI.WebControls.TextBox             TextBoxInput;

  /// <summary>Use a field to reference the current WebPartManager control.</summary>
  WebPartManager webPartManager;

  /// <summary>Page_Init</summary>
  public void Page_Init
  (
   object    sender, 
   EventArgs e
  )
  {
   Page.InitComplete += new EventHandler(InitComplete);
  }//void Page_Init()  

  /// <summary>InitComplete</summary>
  public void InitComplete
  (
   object           sender, 
   System.EventArgs e
  )
  {
   webPartManager = WebPartManager.GetCurrentWebPartManager(Page);

   string browseModeName = WebPartManager.BrowseDisplayMode.Name;

   // Fill the drop-down list with the names of supported display modes.
   foreach 
   (
    WebPartDisplayMode webPartDisplayMode in 
    webPartManager.SupportedDisplayModes
   )
   {
    string webPartDisplayModeName = webPartDisplayMode.Name;
    // Make sure a webPartDisplayMode is enabled before adding it.
    if (webPartDisplayMode.IsEnabled(webPartManager))
    {
     ListItem item = new ListItem(webPartDisplayModeName, webPartDisplayModeName);
     DropDownListDisplayMode.Items.Add(item);
    }//if (webPartDisplayMode.IsEnabled(webPartManager))
   }//foreach ( WebPartDisplayMode webPartDisplayMode in webPartManager.SupportedDisplayModes )

   // If Shared scope is allowed for this user, display the 
   // scope-switching UI and select the appropriate radio 
   // button for the current user scope.
   if ( webPartManager.Personalization.CanEnterSharedScope )
   {
    PanelPersonalizationScope.Visible = true;
    if ( webPartManager.Personalization.Scope == PersonalizationScope.User )
    {
     RadioButtonUser.Checked = true;
    }//if ( webPartManager.Personalization.Scope == PersonalizationScope.User ) 
    else
    {
     RadioButtonShared.Checked = true;
    }//else ( webPartManager.Personalization.Scope == PersonalizationScope.User ) 
   }//if (webPartManager.Personalization.CanEnterSharedScope)

  }//void InitComplete( object sender, System.EventArgs e )
 
  /// <summary>DropDownListDisplayMode_SelectedIndexChanged</summary>
  /// <remarks>Change the page to the selected display mode.</remarks>
  public void DropDownListDisplayMode_SelectedIndexChanged
  (
   object    sender, 
   EventArgs e
  )
  {
   string selectedMode = DropDownListDisplayMode.SelectedValue;

   WebPartDisplayMode mode = webPartManager.SupportedDisplayModes[selectedMode];
   
   if ( mode != null )
   {
    webPartManager.DisplayMode = mode;
   }//if ( mode != null )
   
  }//void DropDownListDisplayMode_SelectedIndexChanged()

  /// <summary>Page_PreRender</summary>
  /// <remarks>Set the selected item equal to the current display mode.</remarks>
  public void Page_PreRender
  (
   object sender, 
   EventArgs e
  )
  {
   ListItemCollection items = DropDownListDisplayMode.Items;
   int selectedIndex = items.IndexOf(items.FindByText(webPartManager.DisplayMode.Name));
   DropDownListDisplayMode.SelectedIndex = selectedIndex;
  }//void Page_PreRender()

  /// <summary>LinkButton1_Click</summary>
  /// <remarks>Reset all of a user's personalization data for the page.</remarks>
  public void LinkButton1_Click
  (
   object    sender, 
   EventArgs e
  )
  {
   webPartManager.Personalization.ResetPersonalizationState();
  }//protected void LinkButton1_Click()

  /// <summary>RadioButtonUser_CheckedChanged</summary>
  /// <remarks>If not in User personalization scope, toggle into it.</remarks>
  public void RadioButtonUser_CheckedChanged
  (
   object    sender, 
   EventArgs e
  )
  {
   if (webPartManager.Personalization.Scope == PersonalizationScope.Shared )
   {
   	webPartManager.Personalization.ToggleScope();
   }//if (webPartManager.Personalization.Scope == PersonalizationScope.Shared )	
  }//protected void RadioButtonUser_CheckedChanged()

  /// <summary>RadioButtonShared_CheckedChanged</summary>
  /// <remarks>If not in Shared scope, and if user has permission, toggle the scope.</remarks>
  public void RadioButtonShared_CheckedChanged
  (
   object sender, 
   EventArgs e
  )
  {
   if 
   (
    webPartManager.Personalization.CanEnterSharedScope &&       
    webPartManager.Personalization.Scope == PersonalizationScope.User
   )
   {
   	webPartManager.Personalization.ToggleScope();
   }//if ( webPartManager.Personalization.CanEnterSharedScope && webPartManager.Personalization.Scope == PersonalizationScope.User )
	
  }//protected void RadioButtonShared_CheckedChanged()

 }//DisplayModeMenuUserControl class.
}//WordEngineering namespace.