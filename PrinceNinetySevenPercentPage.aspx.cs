using  System;
using  System.Collections;
using  System.Web.UI;
using  System.Web.UI.HtmlControls;
using  System.Web.UI.WebControls;
using  System.Data;
using  System.Data.OleDb;
using  System.Data.SqlClient;
using  System.Text;

using  WordEngineering;

namespace WordEngineering
{
 /// <summary>PrinceNinetySevenPercentPage.</summary>
 public class PrinceNinetySevenPercentPage : Page
 {

  /// <summary>The server map path.</summary>
  public string serverMapPath                  = null;

  /// <summary>TextBoxBeans.</summary>  
  protected TextBox   TextBoxBeans;

  /// <summary>TextBoxDatedFrom.</summary>  
  protected TextBox   TextBoxDatedFrom;

  /// <summary>TextBoxDatedUntil.</summary>  
  protected TextBox   TextBoxDatedUntil;

  /// <summary>ListBoxObliterate.</summary>  
  protected ListBox   ListBoxObliterate;

  /// <summary>TextBoxPercentFrom.</summary>  
  protected TextBox   TextBoxPercentFrom;

  /// <summary>TextBoxPercentUntil.</summary>  
  protected TextBox   TextBoxPercentUntil;

  /// <summary>GridViewPrinceNinetySevenPercent.</summary>  
  protected GridView  GridViewPrinceNinetySevenPercent;

  /// <summary>The exception message.</summary>  
  protected Literal   LiteralFeedback;
 
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   string              exceptionMessage                = null;
   serverMapPath = this.MapPath("");
   
   if ( !Page.IsPostBack )
   {
    Page_Default();
   }//if ( !Page.IsPostBack ) 
   
  }//Page_Load
  
  /// <summary>Page Default.</summary>
  public void Page_Default()
  {
   DatedFrom     =  PrinceNinetySevenPercent.DatedYearFrom.ToString();
   DatedUntil    =  PrinceNinetySevenPercent.DatedYearUntil.ToString();
   PercentFrom   =  "0";
   PercentUntil  =  "100";
   Beans         =  "1";
   Obliterate    =  (int) PrinceNinetySevenPercent.ObliterateDefault;
   
   ArrayList obliterate = new ArrayList();
   /*
   obliterate.Add( "Day" );
   obliterate.Add( "Month" );
   obliterate.Add( "Year" ); 
   */
   
   foreach( String metric in Enum.GetNames( typeof( Obliterate ) ) )
   {
    obliterate.Add( metric );
   }   	

   ListBoxObliterate.DataSource = obliterate;
   ListBoxObliterate.DataBind();
   
  }//public static void Page_Default()  	

  /// <summary>Beans.</summary>
  public String Beans
  {
   get
   {
    return ( TextBoxBeans.Text.Trim() );
   } 
   set
   {
    TextBoxBeans.Text = value;
   }
  }//public String Beans

  /// <summary>DatedFrom.</summary>
  public String DatedFrom
  {
   get
   {
    return ( TextBoxDatedFrom.Text.Trim() );
   } 
   set
   {
    TextBoxDatedFrom.Text = value;
   }
  }//public String DatedFrom

  /// <summary>DatedUntil.</summary>
  public String DatedUntil
  {
   get
   {
    return ( TextBoxDatedUntil.Text.Trim() );
   } 
   set
   {
    TextBoxDatedUntil.Text = value;
   }
  }//public String DatedUntil

  /// <summary>Obliterate.</summary>
  public int Obliterate  
  {
   get
   {
    return ( ListBoxObliterate.SelectedIndex );
   } 
   set
   {
    ListBoxObliterate.SelectedIndex = 0;
   }
  }//public String Obliterate

  /// <summary>PercentFrom.</summary>
  public String PercentFrom
  {
   get
   {
    return ( TextBoxPercentFrom.Text.Trim() );
   } 
   set
   {
    TextBoxPercentFrom.Text = value;
   }
  }//public String PercentFrom

  /// <summary>PercentUntil.</summary>
  public String PercentUntil
  {
   get
   {
    return ( TextBoxPercentUntil.Text.Trim() );
   } 
   set
   {
    TextBoxPercentUntil.Text = value;
   }
  }//public String PercentUntil
  
  /// <summary>Feedback.</summary>
  public String Feedback
  {
   get
   {
    return ( LiteralFeedback.Text.Trim() );
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public String Feedback

  /// <summary>ButtonSubmit_Click().</summary>
  public void ButtonSubmit_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   int beans         = 0;
   int obliterate    = 0;
   int percentFrom   = 0;
   int percentUntil  = 0;
   
   PrinceNinetySevenPercentArgument  princeNinetySevenPercentArgument  =  null;
   DataSet                           dataSet                           =  null;
   String                            exceptionMessage                  =  null;

   if ( PercentFrom == null || PercentFrom == String.Empty )
   {
    percentFrom = System.Convert.ToInt32( PercentFrom );
   }

   if ( PercentUntil == null || PercentUntil == String.Empty )
   {
    percentUntil = System.Convert.ToInt32( PercentUntil );
   }

   obliterate = System.Convert.ToInt32( Obliterate );

   if ( Beans == null || Beans == String.Empty )
   {
    beans = System.Convert.ToInt32( Beans );
   }	

   princeNinetySevenPercentArgument = new PrinceNinetySevenPercentArgument
   (
    DatedFrom,
    DatedUntil,
    System.Convert.ToInt32( PercentFrom ),
    System.Convert.ToInt32( PercentUntil ),
    System.Convert.ToInt32( Obliterate ),
    System.Convert.ToInt32( Beans )
   );   
  
   PrinceNinetySevenPercent.UtilityPrinceNinetySevenPercent
   (
    ref princeNinetySevenPercentArgument,
    ref dataSet,
    ref exceptionMessage      
   );
  
   GridViewPrinceNinetySevenPercent.DataSource = dataSet;
   GridViewPrinceNinetySevenPercent.DataBind();

  }//public void ButtonSubmit_Click

  /// <summary>ButtonReset_Click().</summary>
  public void ButtonReset_Click
  (
   Object sender, 
   EventArgs e
  )
  {

   Feedback             =  null;

   UtilityJavaScript.SetFocus
   ( 
    this,
    TextBoxDatedFrom
   );
  }//public void ButtonReset_Click()

  /*
  /// <summary>GridViewPrinceNinetySevenPercent_Page.</summary>  
  public void GridViewPrinceNinetySevenPercent_Page
  ( 
   object                                                  source, 
   System.Web.UI.WebControls.GridViewPageChangedEventArgs  e
  )
  {
   GridViewPrinceNinetySevenPercent.CurrentPageIndex = e.NewPageIndex;
   BindData();
  }
  */

  /*
  /// <summary>DataGridBibleBook_Sort.</summary>  
  public void GridViewPrinceNinetySevenPercent_Sort
  (
   object                                                  source, 
   System.Web.UI.WebControls.GridViewSortCommandEventArgs  e
  )
  {
   ViewState["SortExprValue"] = e.SortExpression;
   BindData(e.SortExpression);
  }//public void GridViewPrinceNinetySevenPercent_Sort
  */

 }//PrinceNinetySevenPercentPage class.
}//WordEngineering namespace.