using System;
using System.Drawing;
using System.Windows.Forms;

public class MyForm : System.Windows.Forms.Form
{
 public MyForm()
 {
  //Set the form's title
  Text = "Image Viewer"; 

  //Set the form's size
  ClientSize = new Size(640, 480);

  MainMenu menu = new MainMenu();
  MenuItem item = menu.MenuItems.Add("&Options");
  item.MenuItems.Add(new MenuItem("E&xit", new EventHandler(OnExit)));

  Menu = menu;
 }

 public static void Main(string[] argv)
 {
  Application.Run( new MyForm() );
 }

 private void OnExit(object sender, EventArgs e)
 {
  Close();
 }

}