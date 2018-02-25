using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SqlAdmin;
using System.Text;
using System.IO;

namespace WordEngineering
{
	/// <summary>
	/// Summary description for PeterABromberg.
	/// </summary>
	public class PeterABromberg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkDatabase;
		private System.Windows.Forms.CheckBox chkTableSchemas;
		private System.Windows.Forms.CheckBox chkTableData;
		private System.Windows.Forms.CheckBox chkStoredProcs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkDropCommands;
		private System.Windows.Forms.CheckBox chkDescriptiveComments;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.ComboBox ExportDatabaseList;
		private System.Windows.Forms.Button ExportButton;
		private string selectedDb =String.Empty;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.GroupBox Logon;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.IContainer components;

		public PeterABromberg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ExportDatabaseList = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chkDatabase = new System.Windows.Forms.CheckBox();
			this.chkTableSchemas = new System.Windows.Forms.CheckBox();
			this.chkTableData = new System.Windows.Forms.CheckBox();
			this.chkStoredProcs = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkDropCommands = new System.Windows.Forms.CheckBox();
			this.chkDescriptiveComments = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.ExportButton = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.lblResult = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.Logon = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// ExportDatabaseList
			// 
			this.ExportDatabaseList.Location = new System.Drawing.Point(216, 32);
			this.ExportDatabaseList.Name = "ExportDatabaseList";
			this.ExportDatabaseList.Size = new System.Drawing.Size(144, 21);
			this.ExportDatabaseList.TabIndex = 3;
			this.ExportDatabaseList.SelectedIndexChanged += new System.EventHandler(this.ExportDatabaseList_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(20, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Objects:";
			// 
			// chkDatabase
			// 
			this.chkDatabase.Checked = true;
			this.chkDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDatabase.Location = new System.Drawing.Point(92, 108);
			this.chkDatabase.Name = "chkDatabase";
			this.chkDatabase.Size = new System.Drawing.Size(108, 16);
			this.chkDatabase.TabIndex = 4;
			this.chkDatabase.Text = "Database";
			// 
			// chkTableSchemas
			// 
			this.chkTableSchemas.Checked = true;
			this.chkTableSchemas.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTableSchemas.Location = new System.Drawing.Point(92, 128);
			this.chkTableSchemas.Name = "chkTableSchemas";
			this.chkTableSchemas.Size = new System.Drawing.Size(104, 16);
			this.chkTableSchemas.TabIndex = 5;
			this.chkTableSchemas.Text = "Table Schemas";
			// 
			// chkTableData
			// 
			this.chkTableData.Checked = true;
			this.chkTableData.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTableData.Location = new System.Drawing.Point(92, 148);
			this.chkTableData.Name = "chkTableData";
			this.chkTableData.Size = new System.Drawing.Size(104, 16);
			this.chkTableData.TabIndex = 6;
			this.chkTableData.Text = "Table Data";
			// 
			// chkStoredProcs
			// 
			this.chkStoredProcs.Checked = true;
			this.chkStoredProcs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkStoredProcs.Location = new System.Drawing.Point(92, 168);
			this.chkStoredProcs.Name = "chkStoredProcs";
			this.chkStoredProcs.Size = new System.Drawing.Size(120, 16);
			this.chkStoredProcs.TabIndex = 7;
			this.chkStoredProcs.Text = "Stored Procedures";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 192);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Options:";
			// 
			// chkDropCommands
			// 
			this.chkDropCommands.Checked = true;
			this.chkDropCommands.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDropCommands.Location = new System.Drawing.Point(92, 196);
			this.chkDropCommands.Name = "chkDropCommands";
			this.chkDropCommands.Size = new System.Drawing.Size(152, 16);
			this.chkDropCommands.TabIndex = 8;
			this.chkDropCommands.Text = "Include Drop Commands";
			// 
			// chkDescriptiveComments
			// 
			this.chkDescriptiveComments.Checked = true;
			this.chkDescriptiveComments.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDescriptiveComments.Location = new System.Drawing.Point(92, 216);
			this.chkDescriptiveComments.Name = "chkDescriptiveComments";
			this.chkDescriptiveComments.Size = new System.Drawing.Size(180, 16);
			this.chkDescriptiveComments.TabIndex = 9;
			this.chkDescriptiveComments.Text = "Include Descriptive Comments";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "UserName";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(68, 36);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(124, 20);
			this.txtUserName.TabIndex = 1;
			this.txtUserName.Text = "sa";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Password";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(68, 60);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(88, 20);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Text = "";
			this.toolTip1.SetToolTip(this.txtPassword, "Enter Password and TAB out to fill DataBase listbox.");
			this.txtPassword.Leave += new System.EventHandler(this.txtPassword_TextChanged);
			// 
			// ExportButton
			// 
			this.ExportButton.Location = new System.Drawing.Point(44, 108);
			this.ExportButton.Name = "ExportButton";
			this.ExportButton.Size = new System.Drawing.Size(80, 24);
			this.ExportButton.TabIndex = 0;
			this.ExportButton.Text = "EXPORT!";
			this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 15;
			this.label6.Text = "Server";
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(68, 12);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(124, 20);
			this.txtServer.TabIndex = 0;
			this.txtServer.Text = "(local)";
			// 
			// lblResult
			// 
			this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblResult.Location = new System.Drawing.Point(8, 24);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(156, 28);
			this.lblResult.TabIndex = 17;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(4, 64);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(160, 23);
			this.progressBar1.TabIndex = 18;
			// 
			// Logon
			// 
			this.Logon.Location = new System.Drawing.Point(0, 0);
			this.Logon.Name = "Logon";
			this.Logon.Size = new System.Drawing.Size(204, 88);
			this.Logon.TabIndex = 19;
			this.Logon.TabStop = false;
			this.Logon.Text = "Logon";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(0, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 156);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Scripting Options";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(208, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(160, 88);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Databases";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lblResult);
			this.groupBox3.Controls.Add(this.progressBar1);
			this.groupBox3.Controls.Add(this.ExportButton);
			this.groupBox3.Location = new System.Drawing.Point(284, 88);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(168, 156);
			this.groupBox3.TabIndex = 22;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Actions";
			this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
			// 
			// PeterABromberg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 250);
			this.Controls.Add(this.txtServer);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.chkDescriptiveComments);
			this.Controls.Add(this.chkDropCommands);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkStoredProcs);
			this.Controls.Add(this.chkTableData);
			this.Controls.Add(this.chkTableSchemas);
			this.Controls.Add(this.chkDatabase);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ExportDatabaseList);
			this.Controls.Add(this.Logon);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Name = "PeterABromberg";
			this.Text = "DataBase Export Utility";
			this.Load += new System.EventHandler(this.PeterABromberg_Load);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new PeterABromberg());
		}

		private void txtPassword_TextChanged(object sender, System.EventArgs e)
		{
		

			SqlServer server = new SqlServer(this.txtServer.Text,this.txtUserName.Text, this.txtPassword.Text);

			server.Connect();
			SqlDatabaseCollection databases = server.Databases;
			server.Disconnect();

			// Clear out list and populate with database names
		

				for (int i = 0; i < databases.Count; i++) 
				{
			 
					ExportDatabaseList.Items.Add(databases[i].Name);
				}

	}

		private void PeterABromberg_Load(object sender, System.EventArgs e)
		{
		this.txtUserName.Focus();
		}

		private void ExportButton_Click(object sender, System.EventArgs e) 
		{			
			lblResult.Text="";
			string databaseName         = (string)ExportDatabaseList.SelectedItem.ToString();
			bool scriptDatabase         = chkDatabase.Checked;
			bool scriptDrop             = this.chkDropCommands.Checked;
			bool scriptTableSchema      = this.chkTableSchemas.Checked;
			bool scriptTableData        = this.chkTableData.Checked;
			bool scriptStoredProcedures = this.chkStoredProcs.Checked;
			bool scriptComments         = this.chkDescriptiveComments.Checked;
			SqlServer server = new SqlServer(this.txtServer.Text,this.txtUserName.Text, this.txtPassword.Text);
			server.Connect();
			SqlDatabase database = server.Databases[databaseName];
			if (database == null) 
			{
				server.Disconnect();
				// Database doesn't exist - break out and go to error page
			MessageBox.Show("connection error");
				return;
			}

			SqlTableCollection tables = database.Tables;
			SqlStoredProcedureCollection sprocs = database.StoredProcedures;
			StringBuilder scriptResult = new StringBuilder();
			scriptResult.EnsureCapacity(400000);
			scriptResult.Append(String.Format("/* Generated on {0} */\r\n\r\n", DateTime.Now.ToString()));
			scriptResult.Append("/* Options selected: ");
			if (scriptDatabase)         scriptResult.Append("database ");
			if (scriptDrop)             scriptResult.Append("drop-commands ");
			if (scriptTableSchema)      scriptResult.Append("table-schema ");
			if (scriptTableData)        scriptResult.Append("table-data ");
			if (scriptStoredProcedures) scriptResult.Append("stored-procedures ");
			if (scriptComments)         scriptResult.Append("comments ");
			scriptResult.Append(" */\r\n\r\n");


			// Script flow:
			// DROP and CREATE database
			// use [database]
			// GO
			// DROP sprocs
			// DROP tables
			// CREATE tables without constraints
			// Add table data
			// Add table constraints
			// CREATE sprocs


			// Drop and create database
			if (scriptDatabase)
				scriptResult.Append(database.Script(
					SqlScriptType.Create |
					(scriptDrop ? SqlScriptType.Drop : 0) |
					(scriptComments ? SqlScriptType.Comments : 0)));


			// Use database
			scriptResult.Append(String.Format("\r\nuse [{0}]\r\nGO\r\n\r\n", databaseName));
   progressBar1.Value=20;
			progressBar1.Refresh();

			// Drop stored procedures
			if (scriptStoredProcedures && scriptDrop) 
			{
				for (int i = 0; i < sprocs.Count; i++) 
				{
					if (sprocs[i].StoredProcedureType == SqlObjectType.User) 
					{
						scriptResult.Append(sprocs[i].Script(SqlScriptType.Drop | (scriptComments ? SqlScriptType.Comments : 0)));
					}
				}
			}

			progressBar1.Value=30;
			progressBar1.Refresh();
			// Drop tables (this includes schemas and data)
			if (scriptTableSchema && scriptDrop) 
			{
				for (int i = 0; i < tables.Count; i++) 
				{
					if (tables[i].TableType == SqlObjectType.User) 
					{
						scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.Drop | (scriptComments ? SqlScriptType.Comments : 0)));
					}
				}
			}

			progressBar1.Value=40;
			progressBar1.Refresh();
			// Create table schemas
			if (scriptTableSchema) 
			{
				// First create tables with no constraints
				for (int i = 0; i < tables.Count; i++) 
				{
					if (tables[i].TableType == SqlObjectType.User) 
					{
						scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.Create | (scriptComments ? SqlScriptType.Comments : 0)));
					}
				}
			}
			progressBar1.Value=50;
			progressBar1.Refresh();

			// Create table data
			if (scriptTableData) 
			{
				for (int i = 0; i < tables.Count; i++) 
				{
					if (tables[i].TableType == SqlObjectType.User) 
					{
						scriptResult.Append(tables[i].ScriptData(scriptComments ? SqlScriptType.Comments : 0));
					}
				}
			}

			progressBar1.Value=60;
			progressBar1.Refresh();
			if (scriptTableSchema) 
			{
				// Add defaults, primary key, and checks
				for (int i = 0; i < tables.Count; i++) 
				{
					if (tables[i].TableType == SqlObjectType.User) 
					{
						scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.Defaults | SqlScriptType.PrimaryKey | SqlScriptType.Checks | (scriptComments ? SqlScriptType.Comments : 0)));
					}
				}

				// Add foreign keys
				for (int i = 0; i < tables.Count; i++) 
				{
					if (tables[i].TableType == SqlObjectType.User) 
					{
						scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.ForeignKeys | (scriptComments ? SqlScriptType.Comments : 0)));
					}
				}
				progressBar1.Value=70;
				progressBar1.Refresh();
				// Add unique keys
				for (int i = 0; i < tables.Count; i++) 
				{
					if (tables[i].TableType == SqlObjectType.User) 
					{
						scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.UniqueKeys | (scriptComments ? SqlScriptType.Comments : 0)));
					}
				}

				// Add indexes
				for (int i = 0; i < tables.Count; i++) 
				{
					if (tables[i].TableType == SqlObjectType.User) 
					{
						scriptResult.Append(tables[i].ScriptSchema(SqlScriptType.Indexes | (scriptComments ? SqlScriptType.Comments : 0)));
					}
				}
			}

			progressBar1.Value=80;
			progressBar1.Refresh();
			// Create stored procedures
			if (scriptStoredProcedures) 
			{
				string tmpResult=String.Empty;
				 
				for (int i = 0; i < sprocs.Count; i++) 
				{
					if (sprocs[i].StoredProcedureType == SqlObjectType.User) 					{			
						tmpResult=sprocs[i].Script(SqlScriptType.Create | (scriptComments ? SqlScriptType.Comments : 0));
						scriptResult.Append(tmpResult);
						tmpResult="";
					}
				}
				       
			}
			server.Disconnect();
			progressBar1.Value=100;
			progressBar1.Refresh();
		scriptResult.Append( "/*-----END SCRIPT------*/");		

			saveFileDialog1.Filter= "Sql files (*.sql)|*.sql|All files (*.*)|*.*";
			saveFileDialog1.RestoreDirectory = true ; 
			Stream myStream ; 
			string theContent=scriptResult.ToString();
			if(saveFileDialog1.ShowDialog() == DialogResult.OK) 
			{ 
				if((myStream = saveFileDialog1.OpenFile()) != null) 
				{ 
					StreamWriter wText =new StreamWriter(myStream); 
					wText.Write(theContent); 
					wText.Flush();
					myStream.Close(); 
					lblResult.Text="File Saved!";
				} 
			} 			
		}

		private void ExportDatabaseList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.selectedDb =ExportDatabaseList.SelectedText;
		}

		private void groupBox3_Enter(object sender, System.EventArgs e)
		{
		
		}
	}
}
