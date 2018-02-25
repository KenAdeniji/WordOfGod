using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace WordEngineering
{
    public partial class AmazonSearchPage : System.Web.UI.Page
    {
        //protected System.Web.UI.WebControls.TextBox keyword;
        //protected System.Web.UI.WebControls.DropDownList locale;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Page.IsPostBack == false) { UserInterfaceInitialization(); }
        }

        public void UserInterfaceInitialization()
        {
            locale.DataSource = Request.UserLanguages;
            locale.DataBind();
        }
    }
}