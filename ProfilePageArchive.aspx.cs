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
using System.Web;
using System.Web.Profile;
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
 /// <summary>ProfilePage</summary>
 public class ProfilePage : Page
 {
  /// <summary>ButtonRevert</summary>
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>PanelContact</summary>
  protected System.Web.UI.WebControls.Panel                  PanelContact;

  /// <summary>TextBoxFirstName</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxFirstName;

  /// <summary>TextBoxLastName</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxLastName;
  
  ProfileBase profile = null;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   profile = HttpContext.Current.Profile as ProfileBase;

   if (Page.IsPostBack == false)
   {
		TextBoxFirstName.Text = profile["FirstName"].ToString();		 
		TextBoxLastName.Text = profile["LastName"].ToString();
   } // On initial load, get data from db
  }

  /// <summary>ButtonReset_Click()</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   TextBoxFirstName.Text = null;
   TextBoxLastName.Text = null;
  }

  /// <summary>ButtonSubmit_Click()</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
	profile["FirstName"] = TextBoxFirstName.Text;
    profile["LastName"] = TextBoxLastName.Text;
  }

 }
}