using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text;

namespace MediaPlayers
{
	/// <summary>
	/// Summary description for WebCustomControl1.
	/// </summary>
	[ToolboxData("<{0}:Audio runat=server></{0}:Audio>")]
	public class Audio : System.Web.UI.Control
	{

		//Properties go here
		#region Public Properties
		private string _fileName = "";

		[Bindable(true), Category("Appearance"),
			Description("URL to a sound file"),
			Editor(typeof(System.Web.UI.Design.UrlEditor), 
			typeof(System.Drawing.Design.UITypeEditor))]
		public string Filename
		{
			get
			{
				return _fileName;
			}

			set
			{
				_fileName = value;
			}
		}

		private int _Volume = 0;

		[Bindable(true),
		Category("Appearance"),
		Description("-10000=mute, 0=full volume (default)")]
		public int Volume
		{
			get
			{
				return _Volume;
			}

			set
			{
				if (value>=-10000 && value<=0) _Volume = value;
				else throw new ArgumentException
						 ("Volume must be between -1000 and 0");
			}
		}

		private int _Balance = 0;

		[Bindable(true),
		Category("Behavior"),
		Description("-10000=left, 10000=right, 0=balanced (default)")]
		public int Balance
		{
			get
			{
				return _Balance;
			}

			set
			{
				if (value>=-10000 && value<=10000) _Balance = value;
				else throw new ArgumentException("Value must be between -10000 and 10000");
			}
		}

		private int _Loop = 0;

		[Bindable(true),
		Category("Behavior"),
		Description("How many times to replay.  -1=infinite")]
		public int Loop
		{
			get
			{
				return _Loop;
			}

			set
			{
				if (value>=-1 && value<=10000) _Loop = value;
				else throw new ArgumentException("Value must be between -1 and 10000");
			}
		}

		#region Button Visibility
        
		private bool _PlayButtonVisible = true;

		[Bindable(true),
		Category("Appearance")]
		public bool PlayButtonVisible
		{
			get
			{
				return _PlayButtonVisible;
			}

			set
			{
				_PlayButtonVisible=value;
			}
		}

		private bool _StopButtonVisible = true;

		[Bindable(true),
		Category("Appearance")]
		public bool StopButtonVisible
		{
			get
			{
				return _StopButtonVisible;
			}

			set
			{
				_StopButtonVisible=value;
			}
		}

		private bool _InfoButtonVisible = true;

		[Bindable(true),
		Category("Appearance")]
		public bool InfoButtonVisible
		{
			get
			{
				return _InfoButtonVisible;
			}

			set
			{
				_InfoButtonVisible=value;
			}
		}
		#endregion

		#endregion

		protected override void Render(HtmlTextWriter output)
		{
			StringBuilder sb = new StringBuilder("<BGSOUND ");
			sb.Append("id='"+ this.ClientID + "' ");
			sb.Append("name='"+ this.ClientID + "' ");
			sb.Append("SRC='"+ _fileName + "' ");
			sb.Append("VOLUME='" + _Volume.ToString() + "' ");
			sb.Append("BALANCE='" + _Balance.ToString() + "' ");
			sb.Append("LOOP='" + _Loop.ToString() + "' ");
			sb.Append("/>");

			GenerateButtons(sb);

			output.Write(sb.ToString());
		}

		private StringBuilder GenerateButtons(StringBuilder sb)
		{
			string TempID = "BG"+ this.ClientID;
			sb.Append("<script language=javascript>var " + 
				TempID + "=document.getElementById('"+ 
				this.ClientID + "');</script>");
			
			if (PlayButtonVisible) 
			{
				sb.Append("<INPUT type='button' ");
				sb.Append("style='font-family:Webdings;' value='4' ");
				sb.Append("title='Play' onClick=\""+ TempID + 
					".src='"+ _fileName + "'\">");
			}
			
			if (StopButtonVisible) 
			{
				sb.Append("<INPUT type='button' ");
				sb.Append("style='font-family:Webdings;' value='<' ");
				sb.Append("title='Stop' onClick=" + TempID + ".src=''>");
			}

			if (InfoButtonVisible) 
			{
				sb.Append("<INPUT type='button' ");
				sb.Append("style='font-family:Webdings;' value='i' ");
				sb.Append("title='Info' onClick='alert(" + TempID + ".src)'>");
			}

			return sb;
		}
	}
}
