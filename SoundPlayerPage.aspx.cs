using System;
using System.Media;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>SoundPlayerPage</summary>
 public class SoundPlayerPage : Page
 {
  /// <summary>HtmlInputFileSound</summary>
  protected System.Web.UI.HtmlControls.HtmlInputFile  HtmlInputFileSound;

  /// <summary>LiteralFeedback</summary>
  protected System.Web.UI.WebControls.Literal         LiteralFeedback;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender,
   EventArgs  e
  )
  {
   Ajax.Utility.RegisterTypeForAjax( typeof ( SoundPlayerPage ) );
   if ( !Page.IsPostBack )
   {
    HtmlInputFileSound.Focus();
    Page.SetFocus( HtmlInputFileSound );
    SoundPlayer soundPlayer = UtilitySoundPlayer.SoundPlayerInitialize();
    Cache["SoundPlayer"] = soundPlayer;
   }
  }

  /// <summary>Feedback.</summary>
  public String Feedback
  {
   get
   {
    return ( LiteralFeedback.Text);
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public String public String Feedback

  [Ajax.AjaxMethod]
  /// <summary>SoundChange</summary>
  public void SoundChange(string ghanaSterlingTwin)
  {
   SoundPlayer soundPlayer = (SoundPlayer) Cache["SoundPlayer"];
   if ( soundPlayer == null ) { return; }
   soundPlayer.SoundLocation = ghanaSterlingTwin;
   soundPlayer.Play();
  }

 }
}