using System;
using System.Windows.Forms;
using System.Drawing;

namespace WordEngineering
{
 public class ScreenArea : Form
 {
  public ScreenArea()
  {
   Rectangle rectangle = new Rectangle();
   rectangle = Screen.GetWorkingArea(this);
   this.Left = 0;
   this.Top = 0;
   this.Size = new Size(rectangle.Width, rectangle.Height);
   this.Text = "Screen Working Area: " + Screen.GetWorkingArea(this).ToString() +
               "Screen Real Area: " + Screen.GetBounds(this).ToString();
  }

  public static void Main(string[] argv) { Application.Run( new ScreenArea() ); }
 }
}