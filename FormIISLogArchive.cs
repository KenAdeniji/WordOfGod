using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace WordEngineering
{
 ///<summary>FormIISLog</summary>
 public class FormIISLog : Form
 {
  ///<summary>LogParser</summary>
  public DataGridView LogParser;

  ///<summary>lblComputer</summary>
  public Label lblComputer;

  ///<summary>lblLog</summary>
  public Label lblLog;

  ///<summary>lblSite</summary>
  public Label lblSite;

  ///<summary>Computer</summary>
  public TextBox Computer;

  ///<summary>Log</summary>
  public ListBox IISLog;

  ///<summary>Site</summary>
  public ListBox IISSite;
 
  ///<summary>Main</summary>
  [STAThread]
  public static void Main(string[] argv)
  {
   Application.Run( new FormIISLog() );
  }

  ///<summary>Constructor</summary>
  public FormIISLog()
  {
   this.Text = "IIS Log";
   this.AutoScaleBaseSize = new Size(5,13);
   this.ClientSize = new Size(392, 300);
   this.MinimumSize = new Size(392, (300 + SystemInformation.CaptionHeight)); 

   lblComputer = new Label(); 
   lblComputer.Location = new Point(100, 25);
   lblComputer.Size = new Size(75, 20);
   lblComputer.Text = "Computer:";
   
   lblComputer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

   Computer = new TextBox(); 
   Computer.Location = new Point(200, 25);
   Computer.Size = new Size(100, 20);
   Computer.TabIndex = 1;
   Computer.LostFocus += new System.EventHandler(Computer_LostFocus);
   Computer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

   /*
   lblComputer.Dock = DockStyle.Bottom;
   */

   lblSite = new Label(); 
   lblSite.Location = new Point(100, 75);
   lblSite.Size = new Size(75, 20);
   lblSite.Text = "Site:";
   lblSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

   IISSite = new ListBox();
   IISSite.Location = new Point(200, 75);
   IISSite.Size = new Size(100, 20);
   IISSite.TabIndex = 2;
   IISSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
   IISSite.SelectedIndexChanged += new System.EventHandler(IISSite_SelectedIndexChanged);

   lblLog = new Label(); 
   lblLog.Location = new Point(100, 125);
   lblLog.Size = new Size(75, 20);
   lblLog.Text = "Log:";
   lblLog.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

   IISLog = new ListBox();
   IISLog.Location = new Point(200, 125);
   IISLog.Size = new Size(100, 20);
   IISLog.TabIndex = 3;
   IISLog.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
   IISLog.SelectedIndexChanged += new System.EventHandler(IISLog_SelectedIndexChanged);

   LogParser = new DataGridView();
   LogParser.Location = new Point(20, 175);
   LogParser.Size = new Size(350, 100);
   LogParser.TabIndex = 4;
   LogParser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
   
   this.Controls.Add(lblComputer);
   this.Controls.Add(Computer);
   this.Controls.Add(lblSite);
   this.Controls.Add(IISSite);
   this.Controls.Add(lblLog);
   this.Controls.Add(IISLog);
   this.Controls.Add(LogParser);

  }

  ///<summary>Computer_LostFocus</summary>
  public void Computer_LostFocus(object sender, EventArgs evArgs) 
  {
    List<string> site;
    UtilityIISLogArgument utilityIISLogArgument = new UtilityIISLogArgument(Computer.Text, null, null);
    UtilityIISLog.LoadSite
    (
         utilityIISLogArgument,
     out site
    );
    IISSite.DataSource = site;
  }

  ///<summary>IISLog_SelectedIndexChanged</summary>
  public void IISLog_SelectedIndexChanged(object sender, EventArgs evArgs)
  {
      String iisLog = (string)IISLog.SelectedItem;
      String iisSite = (string)IISSite.SelectedItem;
      DataTable parseLog;
      UtilityIISLogArgument utilityIISLogArgument = new UtilityIISLogArgument(Computer.Text, iisLog, iisSite);
      UtilityIISLog.ParseLog
      (
           utilityIISLogArgument,
       out parseLog
      );
      LogParser.DataSource = parseLog;
  }

  ///<summary>IISSite_SelectedIndexChanged</summary>
  public void IISSite_SelectedIndexChanged(object sender, EventArgs evArgs)
  {
      List<string> log;
      String iisSite = (string)IISSite.SelectedItem;
      UtilityIISLogArgument utilityIISLogArgument = new UtilityIISLogArgument(Computer.Text, null, iisSite);
      UtilityIISLog.LoadLog
      (
           utilityIISLogArgument,
       out log
      );
      IISLog.DataSource = log;
  }
 }
}