using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WordEngineering 
{
 public class PostCache : System.Web.UI.Page
 {
  protected System.Web.UI.WebControls.Label CreatedTime;
  protected System.Web.UI.WebControls.Label UpdatedTime;
  protected System.Web.UI.WebControls.AdRotator Ads;

  private void InitializeComponent()  
  {
   this.Load += new System.EventHandler(this.Page_Load);
  }

  private void Page_Load(object sender, System.EventArgs e) 
  {
   CreatedTime.Text = DateTime.Now.ToShortTimeString();  
  }

  protected String uncachedUpdate()
  {
   return DateTime.Now.ToShortTimeString();
  }
  
 }//public class PostCache : System.Web.UI.Page
 
}//namespace WordEngineering