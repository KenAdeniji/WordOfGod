using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class CurrencyConverter : System.Web.UI.Page
{
 protected void Page_Load(Object sender, EventArgs e)
 {
  if (this.IsPostBack == false)
  {
   Currency.Items.Add(new ListItem("Euros","0.85"));
   Currency.Items.Add(new ListItem("Japanese Yen","110.33"));
   Currency.Items.Add(new ListItem("Canadian Dollars","1.2"));
  }
 }

 protected void Convert_ServerClick(Object sender, EventArgs e)
 {
  decimal dollar = 0;
  decimal exchangeRate;
  decimal exchangeValue;
  ListItem listItem;
  if ( decimal.TryParse(US.Value, out dollar) )
  {
   listItem = Currency.Items[Currency.SelectedIndex];
   decimal.TryParse( listItem.Value, out exchangeRate );
   exchangeValue = dollar * exchangeRate;
   Result.InnerText = dollar.ToString() + " U.S. dollars = ";
   Result.InnerText += exchangeValue.ToString() + " " + listItem.Text;
  }
 }
}