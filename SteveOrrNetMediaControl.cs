using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text;

namespace MediaPlayers
{
	[DefaultProperty("Text"),
		ToolboxData("<{0}:MediaPlayer runat=server></{0}:MediaPlayer>")]
	public class MediaPlayer : System.Web.UI.UserControl
	{
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

		private bool _autoStart = true;

		[Bindable(true),
		Category("Behavior")]
		public bool autoStart
		{
			get
			{
				return _autoStart;
			}

			set
			{
				_autoStart=value;
			}
		}

		private bool _Enabled = true;

		[Bindable(true),
		Category("Behavior")]
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}

			set
			{
				_Enabled=value;
			}
		}

		private bool _enableContextMenu = true;

		[Bindable(true),
		Category("Behavior"),
		Description("Right-click menu visibility")]
		public bool EnableContextMenu
		{
			get
			{
				return _enableContextMenu;
			}

			set
			{
				_enableContextMenu=value;
			}
		}

		private bool _fullScreen = false;

		[Bindable(true),
		Category("Behavior")]
		public bool fullScreen
		{
			get
			{
				return _fullScreen;
			}

			set
			{
				_fullScreen=value;
			}
		}

		private int _Balance = 0;

		[Bindable(true),
		Category("Behavior"),
		Description("-100=left, 100=right, 0=balanced (default)")]
		public int Balance
		{
			get
			{
				return _Balance;
			}

			set
			{
				if (value>=-100 && value<=100) _Balance = value;
				else throw new ArgumentException("Value must be between -100 and 100");
			}
		}

		private int _Volume = 100;

		[Bindable(true),
		Category("Behavior"),
		Description("0=mute, 100=full volume (default)")]
		public int Volume
		{
			get
			{
				return _Volume;
			}

			set
			{
				if (value>=0 && value<=100) _Volume = value;
				else throw new ArgumentException("Volume must be between 0 and 100");
			}
		}

		private int _Loop = 1;

		[Bindable(true),
		Category("Behavior"),
		Description("How many times to replay.")]
		public int Loop
		{
			get
			{
				return _Loop;
			}

			set
			{
				if (value>=1 && value<=10000) _Loop = value;
				else throw new ArgumentException("Value must be between 1 and 10000");
			}
		}

		private double _Rate = 1;

		[Bindable(true),
		Category("Behavior"),
		Description("Playback speed, 0.5 to 2.0")]
		public double Rate
		{
			get
			{
				return _Rate;
			}

			set
			{
				if (value>=0.5 && value<=2) _Rate = value;
				else throw new ArgumentException("Value must be between 0.5 and 2.0");
			}
		}

		private bool _Invisible = false;

		[Bindable(true),
		Category("Appearance"),
		Description("If false player will be invisible but can still play.")]
		public bool Invisible
		{
			get
			{
				return _Invisible;
			}

			set
			{
				_Invisible=value;
			}
		}

		private bool _buttonsVisible = true;

		[Bindable(true),
		Category("Appearance")]
		public bool ButtonsVisible
		{
			get
			{
				return _buttonsVisible;
			}

			set
			{
				_buttonsVisible=value;
			}
		}

		private bool _stretchToFit = true;

		[Bindable(true),
		Category("Appearance")]
		public bool StretchToFit
		{
			get
			{
				return _stretchToFit;
			}

			set
			{
				_stretchToFit=value;
			}
		}

		private int _Height = 300;

		[Bindable(true),
		Category("Layout")]
		public int Height
		{
			get
			{
				return _Height;
			}

			set
			{
				if (value>=0 && value<=10000) _Height = value;
				else throw new ArgumentException("Value must be between 0 and 10000");
			}
		}

		private int _Width = 300;

		[Bindable(true),
		Category("Layout")]
		public int Width
		{
			get
			{
				return _Width;
			}

			set
			{
				if (value>=0 && value<=10000) _Width = value;
				else throw new ArgumentException("Value must be between 0 and 10000");
			}
		}
#endregion

		protected override void Render(HtmlTextWriter output)
		{
			//output begin object tag
			StringBuilder sb = new StringBuilder("<OBJECT ID='" + 
				this.ClientID + "' name='"+ this.ClientID + "' " +
				"CLASSID='CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6'" +
				"VIEWASTEXT" +
				"height="+_Height + " " + "width="+_Width +
				">");

			//Render properties as object parameters
			sb.Append("<PARAM name='URL' value='"+ 
				_fileName + "'>");
			sb.Append("<PARAM name='AutoStart' value='"+ 
				_autoStart.ToString() + "'>");
			sb.Append("<PARAM name='balance' value='"+ 
				_Balance + "'>");
			sb.Append("<PARAM name='enabled' value='"+ 
				_Enabled.ToString() + "'>");
			sb.Append("<PARAM name='fullScreen' value='"+ 
				_fullScreen.ToString() + "'>");
			sb.Append("<PARAM name='playCount' value='"+ 
				_Loop.ToString() + "'>");
			sb.Append("<PARAM name='volume' value='"+ 
				_Volume + "'>");
			sb.Append("<PARAM name='rate' value='"+ 
				_Rate + "'>");
			sb.Append("<PARAM name='StretchToFit' value='"+ 
				_stretchToFit.ToString() + "'>");
			sb.Append("<PARAM name='enabledContextMenu' value='" + 
				_enableContextMenu.ToString() + "'>");
			
			//Determine visibility
			if (_Invisible) 
			{
				sb.Append("<PARAM name='uiMode'");
				sb.Append(" value='invisible'>");
			}
			else 
			{
				if (_buttonsVisible) 
				{
					sb.Append("<PARAM name='uiMode'");
					sb.Append(" value='full'>");
				}
				else
				{
					sb.Append("<PARAM name='uiMode'");
					sb.Append(" value='none'>");
				}
			}

			//output ending object tag
			sb.Append("</OBJECT>");
			
			//flush everything to the output stream
			output.Write(sb.ToString());
		}
	}
}