using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 ///<summary>PageStubPage</summary>
 ///<remarks>
 /// Ken Cox authors.aspalliance.com/kenc/faq5.aspx
 ///</remarks>
 public class PageStubPage : Page
 {
  /// <summary>PageHead</summary>
  public System.Web.UI.HtmlControls.HtmlHead   PageHead;

  /// <summary>PageTitle</summary>
  public System.Web.UI.HtmlControls.HtmlTitle  PageTitle;
  
  /// <summary>ServerMapPath</summary>
  public String    ServerMapPath             =  null;

  ///<summary>Page_Load()</summary>
  public void Page_Load() 
  {
   if ( !Page.IsPostBack )
   {
    ServerMapPath = this.MapPath("");
    if ( ServerMapPath != null)
    {

    }//if ( ServerMapPath != null)
   }//if ( !Page.IsPostBack )
   PageInitialization();
  }//Page_Load()

  ///<summary>PageInitialization</summary>
  public void PageInitialization() 
  {
   // Create a Style object for the body of the page.
   Style styleBody = new Style();

   //Page.Header.Title = "Page.aspx";
   PageTitle.Text = "PageStub.aspx";
  
   styleBody.ForeColor = System.Drawing.Color.Blue;
   styleBody.BackColor = System.Drawing.Color.LightGray;

   // Add the style to the header of the current page.
   Page.Header.StyleSheet.CreateStyleRule( styleBody, null, "BODY" );
  }

 }//PageStubPage class.
}//WordEngineering namespace.