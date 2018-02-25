using  System;
using  System.Collections;
using  System.Web.UI;
using  System.Web.UI.WebControls;
using  System.Data;
using  System.Data.OleDb;
using  System.Data.SqlClient;
using  System.Text;

using  WordEngineering;

namespace WordEngineering
{
 /// <summary>The TimeSpanPage class.</summary> 
 public class TimeSpanPage : Page
 {
  
  /// <summary>The query button.</summary>
  protected Button    ButtonQuery;

  /// <summary>The exception message label.</summary>
  protected Label     LabelExceptionMessage;  

  /// <summary>The datatime start label.</summary>
  protected Label     LabelDateTimeStart;

  /// <summary>The datatime end label.</summary>
  protected Label     LabelDateTimeEnd;
  
  /// <summary>The timespan label.</summary>
  protected Label     LabelTimeSpanStartEnd;  
  
  /// <summary>The datatime start textbox.</summary>  
  protected TextBox   TextBoxDateTimeStart;
  
  /// <summary>The datatime end textbox.</summary>    
  protected TextBox   TextBoxDateTimeEnd;
  
  ///<summary>Page_Load().</summary>
  ///<param name="sender">The event sender.</param>
  ///<param name="e">The event arguments.</param>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   if (!Page.IsPostBack) 
   {
   } 
  }//Page_Load

  ///<summary>Query_Click.</summary>
  ///<param name="sender">The event sender.</param>
  ///<param name="e">The event arguments.</param>
  public void Query_Click
  (
   Object     sender, 
   EventArgs  e
  ) 
  {
   string   dateTimeEnd      = DateTimeEnd;
   string   dateTimeStart    = DateTimeStart;   
   string   exceptionMessage = null;
   TimeSpan timeSpan         = new TimeSpan();
   UtilityDateTimeXml.TimeSpan( dateTimeStart, dateTimeEnd, ref timeSpan, ref exceptionMessage);
   if ( exceptionMessage == null )
   {
    TimeSpanStartEnd = string.Format
    (
     "Days: {0} | Hours: {1} | Minutes: {2}", 
     timeSpan.TotalDays, 
     timeSpan.TotalHours, 
     timeSpan.TotalMinutes
    );
   }//if ( exceptionMessage == null )
   else
   {
    TimeSpanStartEnd = null;
   }//if ( exceptionMessage != null )   	
   ExceptionMessage = exceptionMessage;
  }//Query_Click
  
  /// <summary>The DateTime start.</summary>
  public string DateTimeStart
  {
   get
   {
    return ( ( TextBoxDateTimeStart.Text ).Trim() );
   } 
   set
   {
    TextBoxDateTimeStart.Text = value;
   }
  }//public DateTime DateTimeStart
  
  /// <summary>The DateTime end.</summary>
  public string DateTimeEnd
  {
   get
   {
    return ( ( TextBoxDateTimeEnd.Text ).Trim() );
   } 
   set
   {
    TextBoxDateTimeEnd.Text = value;
   }
  }//public DateTime DateTimeEnd

  /// <summary>The ExceptionMessage.</summary>
  public string ExceptionMessage
  {
   get
   {
    return ( ( LabelExceptionMessage.Text ).Trim() );
   } 
   set
   {
    LabelExceptionMessage.Text = value;
   }
  }//public string ExceptionMessage

  /// <summary>The timeSpanStartEnd.</summary>
  public string TimeSpanStartEnd
  {
   get
   {
    return ( ( LabelTimeSpanStartEnd.Text ).Trim() );
   } 
   set
   {
    LabelTimeSpanStartEnd.Text = value;
   }
  }//public string TimeSpanStartEnd
  	
 }//TimeSpanPage
}//WordEngineering namespace.