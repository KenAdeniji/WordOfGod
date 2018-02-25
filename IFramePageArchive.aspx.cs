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
 /// <summary>IFramePage</summary>
 public class IFramePage : Page
 {
  /// <summary>IFrameGeneric</summary>
  protected System.Web.UI.HtmlControls.HtmlControl  IFrameGeneric; 

  /*
  /// <summary>ButtonHideFrame</summary>
  protected System.Web.UI.WebControls.Button        ButtonHideFrame;
  */

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  )
  {
   //ButtonHideFrame.Attributes.Add("OnClientClick", "HideFrame();");
   //ButtonHideFrame.Attributes.Add("onclick", "HideFrame();");
   IFrameSource();
  }//Page_Load

  /// <summary>IFrameSource</summary>
  public void IFrameSource()
  {
   int  sequenceOrderId  =  -1;
   Int32.TryParse( Request.QueryString["SequenceOrderId"], out sequenceOrderId );
   if ( sequenceOrderId == -1 ) { return; }
   IFrameGeneric.Attributes["src"] = "Render.aspx?SourceColumn=ImageSource&ContentColumn=ImageContent&DataSource=ContactImage&SequenceOrderId=" +
   sequenceOrderId.ToString();
  }	 
 }//IFramePage class.
}//WordEngineering namespace.