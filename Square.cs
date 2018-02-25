using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

public class Square : System.Windows.Forms.Form
{
 private System.Windows.Forms.Button Calculate;
 private System.Windows.Forms.Label Result;
 
 [STAThread]
 public static void Main()
 {
  Application.Run( new Square() );
 }
 private void Calculate_Click(object sender, System.EventArgs e)
 {
  Result.Text = "";
  for ( int counter = 1; counter <= 10; counter++ )
  {
   Result.Text += counter + " ^ 2 = " + Math.Pow( counter, 2 );
  }
 } 
}