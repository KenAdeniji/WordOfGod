using System;
using System.IO;
using System.Web;
using System.Web.UI;

using OWCTypeLib;

namespace WordEngineering
{
 ///<summary>OfficeWebComponentOWCColumnPage</summary>
 ///<remarks>
 /// csharphelp.com/archives4/archive623.html Alvin Bruney The Microsoft Office Web Components
 /// microsoft.public.office.developer.web.components
 /// %SystemDrive%\Program Files\Common Files\Microsoft Shared\Web Components\11\1033\OWCDCH11.chm
 /// Chart type: Area, Column, Bar, Line, SmoothLine, Column, Doughnut, Stock, XY (Scatter), Bubble, Radar, Polar
 /// west-wind.com/presentations/OWCCharting/OWCCharting.asp Rick Strahl Using the Office Web Components to create dynamic charts
 /// blogs.msdn.com/brada/archive/2004/10/26/248324.aspx Brad Adams: Whidbey Readiness Quiz Converting array values
 ///</remarks>
 public class OfficeWebComponentOWCColumnPage : Page
 {

  /// <summary>FilenameImage</summary>
  public string    FilenameImage             =  @"Image\OfficeWebComponentOWCColumn.gif";

  /// <summary>GraphCategory</summary>
  public static readonly string[]  GraphCategory             =  new string[] { "Cars", "Trucks", "Vans", "Big Rigs", "Motorcycles", "Mopeds" };

  /// <summary>GraphLegendSeriesData0</summary>
  public static readonly double[]  GraphLegendSeriesData0    =  new double[] { 13,12,31,43,23,15 };

  /// <summary>GraphLegendSeriesData1</summary>
  public static readonly double[]  GraphLegendSeriesData1    =  new double[] { 7,9,11,31,40,45 };

  /// <summary>The server map path.</summary>
  public String    ServerMapPath             =  null;

  ///<summary>Page_Load()</summary>
  public void Page_Load() 
  {
   if ( !Page.IsPostBack )
   {
    ServerMapPath = this.MapPath("");
    if ( ServerMapPath != null)
    {
     FilenameImage = System.IO.Path.Combine( ServerMapPath, FilenameImage );
    }//if ( ServerMapPath != null)
   }//if ( !Page.IsPostBack )
   ChartColumn();
  }//Page_Load()

  ///<summary>ChartColumn</summary>
  public void ChartColumn() 
  {
   string      exceptionMessage  =  null;

   ChartSpace  chartSpace        =  null;
   ChChart     chChart           =  null;
   
   try
   {
    //First create a ChartSpace object to hold the chart
    chartSpace = new ChartSpaceClass();
   
    //Add a chart and provide a type
    chChart = chartSpace.Charts.Add(0);
    chChart.Type = ChartChartTypeEnum.chChartTypeColumn3D;

    //add chart titles and legend
    chChart.HasTitle                 =  true;
    chChart.Title.Caption            =  "Office Web Components (OWC) Column";
    chChart.HasLegend                =  true;
    chChart.Legend.Border.DashStyle  =  OWCTypeLib.ChartLineDashStyleEnum.chLineDash;
    chChart.Legend.Position          =  OWCTypeLib.ChartLegendPositionEnum.chLegendPositionRight;
   
    //Add a series to the chart's series collection
    chChart.SeriesCollection.Add(0);
   
    //load the category and legendSeriesData1 data
    chChart.SeriesCollection[0].SetData 
    (
     ChartDimensionsEnum.chDimCategories,
     ( int ) ChartSpecialDataSourcesEnum.chDataLiteral, 
     string.Join( ",", GraphCategory )
    );
   
    chChart.SeriesCollection[0].SetData 
    (
     ChartDimensionsEnum.chDimValues,
     ( int ) ChartSpecialDataSourcesEnum.chDataLiteral,
     string.Join( ",", Array.ConvertAll<double, string>( GraphLegendSeriesData0, ConvertDoubleString ) )
    );

    //Add a series to the chart's series collection
    chChart.SeriesCollection.Add(1);
    chChart.SeriesCollection[1].SetData 
    (
     ChartDimensionsEnum.chDimValues,
     ( int ) ChartSpecialDataSourcesEnum.chDataLiteral,
     string.Join( ",", Array.ConvertAll<double, string>( GraphLegendSeriesData1, ConvertDoubleString ) )
    );

    //chartSpace.ExportPicture( FilenameImage, "gif", 500, 400 );
    
    //show the chart on the client
    Response.ContentType= "image/gif";
    Response.BinaryWrite( ( byte[] ) chartSpace.GetPicture( "gif", 500, 400 ) ); 
    Response.End();
  
   }
   catch ( Exception exception )
   {
   	exceptionMessage = exception.Message;
   }
   if ( exceptionMessage != null )
   {
   	Response.Write( exceptionMessage );
   }
  }//ChartColumn()

  ///<Summary>ConvertDoubleString</Summary>
  public static string ConvertDoubleString
  (
   double from
  )
  {
   return ( from.ToString() );
  }

 }//OfficeWebComponentOWCColumnPage class.
}//WordEngineering namespace.