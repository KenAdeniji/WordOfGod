using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;

public partial class GreetingCard : System.Web.UI.Page
{
 protected void Page_Load(object sender, System.EventArgs e)
 {
  if (!this.IsPostBack)
  {
   string[] borderStyles = Enum.GetNames(typeof(BorderStyle));
   string[] colors = Enum.GetNames(typeof(System.Drawing.KnownColor));
   System.Drawing.Text.InstalledFontCollection fonts;

   BackgroundColor.DataSource = colors;
   BackgroundColor.DataBind();

   Border_Style.DataSource = borderStyles;
   Border_Style.DataBind();
   
   fonts = new System.Drawing.Text.InstalledFontCollection();
   foreach( FontFamily fontFamily in fonts.Families)
   {
    FontName.Items.Add(fontFamily.Name);
   }
  }
 }

 protected void Generate_Click(object sender, System.EventArgs e)
 {
  int fontSize = -1;
  TypeConverter typeConverterBorderStyle = TypeDescriptor.GetConverter(typeof(BorderStyle));
  pnlCard.BackColor = Color.FromName(BackgroundColor.SelectedItem.Text);
  Greet.Font.Name = FontName.SelectedItem.Text;
  Int32.TryParse(FontSize.Text, out fontSize);
  if (fontSize > 0)
  {
   Greet.Font.Size = FontUnit.Point(fontSize);  
  }
  pnlCard.BorderStyle = (BorderStyle) typeConverterBorderStyle.ConvertFromString(Border_Style.SelectedItem.Text);
  Greet.Text = Greeting.Text;
 }

}