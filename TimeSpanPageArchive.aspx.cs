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
 public class TimeSpanPage : Page
 {
  protected Button    ButtonQuery;
  protected Label     LabelExceptionMessage;  
  protected Label     LabelDateTimeStart;
  protected Label     LabelDateTimeEnd;
  protected Label     LabelTimeSpan;  
  protected TextBox   TextBoxDateTimeStart;
  protected TextBox   TextBoxDateTimeEnd;
  
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

  public void Query_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   string   dateTimeEnd      = DateTimeEnd;
   string   dateTimeStart    = DateTimeStart;   
   string   exceptionMessage = null;
   TimeSpan timeSpan;
   UtilityDateTimeXml( dateTimeStart, dateTimeEnd, ref timeSpan, ref exceptionMessage);   	
   if ( exceptionMessage != null )
   {
    TimeSpan = timeSpan;           	
   }//if ( exceptionMessage != null )
   else
   {
    ExceptionMessage = exceptionMessage;	
   }//else ( exceptionMessage == null )
  }//Query_Click
  
  /// <summary>The DateTime start.</summary>
  public string DateTimeStart
  {
   get
   {
    return ( TextBoxDateTimeStart.Trim() )
   } 
   set
   {
    TextBoxDateTimeStart = value;
   }
  }//public DateTime DateTimeStart
  
  /// <summary>The DateTime end.</summary>
  public DateTime DateTimeEnd
  {
   get
   {
    return ( TextBoxDateTimeEnd.Trim() )
   } 
   set
   {
    TextBoxDateTimeEnd = value;
   }
  }//public DateTime DateTimeEnd

  /// <summary>The ExceptionMessage.</summary>
  public string ExceptionMessage
  {
   get
   {
    return ( LabelExceptionMessage.Trim() )
   } 
   set
   {
    LabelExceptionMessage = value;
   }
  }//public string ExceptionMessage

  /// <summary>The TimeSpan.</summary>
  public TimeSpan timeSpan
  {
   get
   {
    return ( LabelTimeSpan.Trim() )
   } 
   set
   {
    LabelTimeSpan = value;
   }
  }//public TimeSpan timeSpan
  	
 }//TimeSpanPage
}//WordEngineering namespace.