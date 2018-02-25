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
using System.Text.RegularExpressions;
using System.Xml;

namespace WordEngineering
{
 /// <summary>AJAXMichaelSchwarzPage</summary>
 public class AJAXMichaelSchwarzPage : Page
 {

  /// <summary>The configuration XML filename.</summary>
  public String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The server map path.</summary>
  public String ServerMapPath                  = null;

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

   if ( !Page.IsPostBack )
   {
   }//if ( !Page.IsPostBack )
   	
   Ajax.Utility.RegisterTypeForAjax( typeof ( AJAXMichaelSchwarzPage ) );

  }//Page_Load

  /// <summary>ServerSideAdd()</summary>
  [Ajax.AjaxMethod()]
  public int ServerSideAdd(int firstNumber, int secondNumber)
  {
   return firstNumber + secondNumber;
  }

 }//AJAXMichaelSchwarzPage class.
}//WordEngineering namespace.