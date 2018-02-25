using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

using  WordEngineering;

namespace WordEngineering
{
 /// <summary>Control page.</summary>
 public class ControlPage : Page
 {
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   UtilityControl.SetTextBoxBackColor(this, Color.Red);
  }//Page_Load
 }//ControlPage class.
}//WordEngineering namespace.