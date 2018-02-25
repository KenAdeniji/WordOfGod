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
 /// <summary>PrimePage</summary>
 public class PrimePage : Page
 {
  /// <summary>ButtonReset</summary>
  protected System.Web.UI.WebControls.Button                 ButtonReset;

  /// <summary>ButtonSubmit</summary>  
  protected System.Web.UI.WebControls.Button                 ButtonSubmit;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal                LiteralFeedback;

  /// <summary>PanelPrime</summary>
  protected System.Web.UI.WebControls.Panel                  PanelPrime;

  /// <summary>TextBoxPrime</summary>
  protected System.Web.UI.WebControls.TextBox                TextBoxPrime;

  /// <summary>PrimeGenerator</summary>
  protected Prime                                  PrimeGenerator;
  
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   if ( !Page.IsPostBack )
   {
    TextBoxPrime.Focus();
    Page.SetFocus( TextBoxPrime );
   }//if ( !Page.IsPostBack )
  }//Page_Load

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
  }//public String Feedback

  /// <summary>Prime.</summary>
  public int Prime
  {
   get
   {
    int prime = -1;
    Int32.TryParse( TextBoxPrime.Text, out prime );
    return ( prime );
   } 
   set
   {
    TextBoxPrime.Text = value.ToString();
   }
  }//public int Prime

  /// <summary>ButtonReset_Click()</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   Feedback           =  null;
   TextBoxPrime.Text  =  null;
   TextBoxPrime.Focus();
  }//public void ButtonReset_Click()

  /// <summary>ButtonSubmit_Click()</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   GetPrimes();   
  }//public void ButtonSubmit_Click()

  /// <summary>GetPrimes</summary>
  public void GetPrimes()
  {
   PrimeGenerator.Number = Prime;  	
  }//public static void GetPrimes()
 
 }//PrimePage class.
}//WordEngineering namespace.