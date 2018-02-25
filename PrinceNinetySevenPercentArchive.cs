using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WordEngineering
{

 /// <summary>Obliterate</summary>
 public enum Obliterate : int
 {
  /// <summary>Day</summary>
  Day   = 0,
  
  /// <summary>Month</summary>
  Month = 1,
  
  /// <summary>Year</summary>  
  Year  = 2
 }

 /// <summary>PrinceNinetySevenPercentArgument</summary>
 public class PrinceNinetySevenPercentArgument
 {

  ///<summary>beans</summary>
  public int      beans                        =  PrinceNinetySevenPercent.BeansDefault;

  ///<summary>percentFrom</summary>
  public int      percentFrom                  =  0;

  ///<summary>percentUntil</summary>
  public int      percentUntil                 =  100;

  ///<summary>datedFrom</summary>
  public String   datedFrom                    =  PrinceNinetySevenPercent.DatedYearFrom.ToString();

  ///<summary>datedUntil</summary>
  public String   datedUntil                   =  PrinceNinetySevenPercent.DatedYearUntil.ToString();

  ///<summary>percentUntil</summary>
  public Obliterate  obliterateMasters         =  PrinceNinetySevenPercent.ObliterateDefault;

  /// <summary>Constructor.</summary>
  public PrinceNinetySevenPercentArgument():this
  (
   PrinceNinetySevenPercent.DatedYearFrom.ToString(),
   PrinceNinetySevenPercent.DatedYearUntil.ToString(),
   0,
   100,
   (int) PrinceNinetySevenPercent.ObliterateDefault,
   PrinceNinetySevenPercent.BeansDefault   
  )
  {
  }//public PrinceNinetySevenPercentArgument()
  
  /// <summary>Constructor.</summary>
  public PrinceNinetySevenPercentArgument
  (
   String      datedFrom,
   String      datedUntil,
   int         percentFrom,
   int         percentUntil,
   int         obliterateMasters,
   int         beans
  )
  {
   datedFrom  = datedFrom.Trim();
   datedUntil = datedUntil.Trim();
   
   if
   (
    ( 
     ( datedFrom  == null || datedFrom  == String.Empty ) && 
     ( datedUntil == null || datedUntil == String.Empty ) 
    )
    &&  
    (
     percentFrom  > 0 ||
     percentUntil < 100 
    )
   ) 
   {
    datedFrom  = System.Convert.ToString
                 (
                  PrinceNinetySevenPercent.DatedYearFrom.AddDays
                  (   
                   percentFrom / PrinceNinetySevenPercent.Percent100 *
                   PrinceNinetySevenPercent.DatedYearUntil.Subtract( PrinceNinetySevenPercent.DatedYearFrom ).Days
                  )
                 );

    datedUntil = System.Convert.ToString
                 (
                  PrinceNinetySevenPercent.DatedYearFrom.AddDays
                  (   
                   percentUntil / PrinceNinetySevenPercent.Percent100 *
                   PrinceNinetySevenPercent.DatedYearUntil.Subtract( PrinceNinetySevenPercent.DatedYearFrom ).Days
                  )
                 );
   }
  	
   this.datedFrom          =  datedFrom;
   this.datedUntil         =  datedUntil;
   this.percentFrom        =  percentFrom;
   this.percentUntil       =  percentUntil;
   this.obliterateMasters  =  (Obliterate) obliterateMasters;
   this.beans              =  beans;
   
  }//public PrinceNinetySevenPercentArgument()

  ///<summary>Property.</summary>
  ///<value>Beans.</value>
  public int Beans
  {
   get 
   {
    return ( beans );
   }//get
   set 
   {
    beans = value;
   }//set
  }//Beans

  ///<summary>Property.</summary>
  ///<value>DatedFrom.</value>
  public String DatedFrom
  {
   get 
   {
    return ( datedFrom );
   }//get
   set 
   {
    datedFrom = value;
   }//set
  }//DatedFrom

  ///<summary>Property.</summary>
  ///<value>DatedUntil.</value>
  public String DatedUntil
  {
   get 
   {
    return ( datedUntil );
   }//get
   set 
   {
    datedUntil = value;
   }//set
  }//DatedUntil

  ///<summary>Property.</summary>
  ///<value>ObliterateMasters.</value>
  public Obliterate ObliterateMasters
  {
   get 
   {
    return ( obliterateMasters );
   }//get
   set 
   {
    obliterateMasters = value;
   }//set
  }//ObliterateMasters

  ///<summary>Property.</summary>
  ///<value>PercentFrom.</value>
  public int PercentFrom
  {
   get 
   {
    return ( percentFrom );
   }//get
   set 
   {
    percentFrom = value;
   }//set
  }//PercentFrom

  ///<summary>Property.</summary>
  ///<value>PercentUntil.</value>
  public int PercentUntil
  {
   get 
   {
    return ( percentUntil );
   }//get
   set 
   {
    percentUntil = value;
   }//set
  }//PercentUntil

 }//public class PrinceNinetySevenPercentArgument

 ///<summary>PrinceNinetySevenPercent</summary>
 ///<remarks>PrinceNinetySevenPercent /theWordId:539 /dated:20040701</remarks>
 public class PrinceNinetySevenPercent
 {

  /// <summary>BeansDefault.</summary>
  public const  int         BeansDefault   = 1;

  /// <summary>Percent100.</summary>
  public const  double      Percent100     = 100.00;
  
  /// <summary>DatedYearFrom.</summary>
  public static DateTime    DatedYearFrom  = new DateTime( DateTime.Now.Year, 1, 1);

  /// <summary>DatedYearUntil.</summary>
  public static DateTime    DatedYearUntil = new DateTime( DateTime.Now.Year, 12, 31);
  
  /// <summary>ObliterateDefault.</summary>
  public const  Obliterate  ObliterateDefault       = Obliterate.Day;
  
  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main
  (
   String[] argv
  )
  {
   Boolean                           booleanParseCommandLineArguments  =  false;
   String                            exceptionMessage                  =  null;

   DataSet                           dataSet                           =  null;
   PrinceNinetySevenPercentArgument  princeNinetySevenPercentArgument  =  null;
   
   princeNinetySevenPercentArgument = new PrinceNinetySevenPercentArgument();
   
   booleanParseCommandLineArguments =  UtilityParseCommandLineArgument.ParseCommandLineArguments
   ( 
    argv, 
    princeNinetySevenPercentArgument
   );

   if ( booleanParseCommandLineArguments == false )
   {
    // error encountered in arguments. Display usage message
    System.Console.Write
    (
     UtilityParseCommandLineArgument.CommandLineArgumentsUsage( typeof ( PrinceNinetySevenPercentArgument ) )
    );
    return;
   }//if ( booleanParseCommandLineArguments == false )

   UtilityPrinceNinetySevenPercent
   (
    ref princeNinetySevenPercentArgument,
    ref dataSet,
    ref exceptionMessage
   );

  }//static void Main( String[] argv ) 

  ///<summary>UtilityPrinceNinetySevenPercent</summary>
  public static void UtilityPrinceNinetySevenPercent
  (
   ref PrinceNinetySevenPercentArgument  princeNinetySevenPercentArgument,
   ref DataSet                           dataSet,
   ref String                            exceptionMessage      
  )
  {
  
   double      percent          =  0.00;
   DateTime    yearFrom         =  new DateTime(DateTime.Now.Year, 1, 1);
   DateTime    yearUntil        =  new DateTime(DateTime.Now.Year, 12, 31);
      
   try
   {
    DateTime    dated            =  System.Convert.ToDateTime( princeNinetySevenPercentArgument.DatedFrom );
    DateTime    datedFrom        =  System.Convert.ToDateTime( princeNinetySevenPercentArgument.DatedFrom );
    DateTime    datedUntil       =  System.Convert.ToDateTime( princeNinetySevenPercentArgument.DatedUntil );

    DataTable   dataTable          =  new DataTable();
    DataColumn  dataColumnDated    =  new DataColumn( "Dated", System.Type.GetType("System.DateTime") );
    //DataColumn  dataColumnPercent  =  new DataColumn( "Percent", System.Type.GetType("System.TimeSpan"), "(new System.DateTime(2005,12,31)).Subtract(Dated)" );
    DataColumn  dataColumnPercent  =  new DataColumn( "Percent", System.Type.GetType("System.Decimal") );
    DataRow     dataRow            =  null;
   
    dataSet = new DataSet();
   
    dataTable.Columns.Add( dataColumnDated );
    dataTable.Columns.Add( dataColumnPercent );
   
    dataSet.Tables.Add( dataTable );
   
    /*
    UtilityDebug.Write(String.Format("princeNinetySevenPercentArgument.ObliterateMasters: {0}", princeNinetySevenPercentArgument.ObliterateMasters));
    UtilityDebug.Write(String.Format("princeNinetySevenPercentArgument.Beans: {0}", princeNinetySevenPercentArgument.Beans));
    UtilityDebug.Write(String.Format("princeNinetySevenDatedArgument.DatedFrom: {0}", princeNinetySevenPercentArgument.DatedFrom));
    UtilityDebug.Write(String.Format("princeNinetySevenDatedArgument.DatedUntil: {0}", princeNinetySevenPercentArgument.DatedUntil));
    UtilityDebug.Write(String.Format("princeNinetySevenPercentArgument.PercentFrom: {0}", princeNinetySevenPercentArgument.PercentFrom));
    UtilityDebug.Write(String.Format("princeNinetySevenPercentArgument.PercentUntil: {0}", princeNinetySevenPercentArgument.PercentUntil));
    */

    while ( true )
    {
     if ( dated > datedUntil )
     {
      break;    	
     }//if ( dated > datedUntil )

     dataRow = dataTable.NewRow();
     dataRow["Dated"]   = dated;
     yearFrom           = new DateTime(dated.Year, 1, 1);
     yearUntil          = new DateTime(dated.Year, 12, 31);
     percent            = dated.Subtract( yearFrom ).Days * Percent100 / yearUntil.Subtract( yearFrom ).Days; 
     dataRow["Percent"] = percent;
     dataTable.Rows.Add( dataRow );

     //UtilityDebug.Write(String.Format("Dated: {0} | Percent: {1}", dated, percent));
    
   	 switch( princeNinetySevenPercentArgument.ObliterateMasters )
   	 {
      case Obliterate.Day:
       dated = dated.AddDays( princeNinetySevenPercentArgument.Beans );
       break;
       
      case Obliterate.Month:
       dated = dated.AddMonths( princeNinetySevenPercentArgument.Beans );
       break;		
     
      case Obliterate.Year:
       dated = dated.AddYears( princeNinetySevenPercentArgument.Beans );
       break;
     }//switch( princeNinetySevenPercentArgument.ObliterateMasters )
    
    }//while ( true )
   }//try
   catch (Exception exception)
   {
    UtilityDebug.Write(String.Format("Exception: {0}", exception.Message));       	
   }//catch (Exception exception)
  }//public static void UtilityPrinceNinetySevenPercent()
  
  static PrinceNinetySevenPercent()
  {
  }//static PrinceNinetySevenPercent()
  
 }//public class PrinceNinetySevenPercent
 
}//namespace WordEngineering