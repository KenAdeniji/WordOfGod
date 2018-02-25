using  System;
using  System.Collections;
using  System.Collections.Specialized;
using  System.Data;
using  System.Data.OleDb;
using  System.Data.SqlClient;
using  System.Drawing;
using  System.Drawing.Imaging;
using  System.Text;
using  System.Web;
using  System.Web.UI;
using  System.Web.UI.HtmlControls;
using  System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>Graph Chart Page.</summary>
 public class GraphChartPage : Page
 {
  /// <summary>Page Load.</summary>
  /// <param name="sender">Sender</param>
  /// <param name="e">The event arguments.</param>  
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {

   String  chartGraphType  = null;
   String  xAxis           = null;
   String  yAxis           = null;

   DataSet dataSet         = null;   

   UtilityGraphChart.GraphChart
   (
    ref dataSet,
    ref chartGraphType,
    ref xAxis,
    ref yAxis
   );
   
   switch ( chartGraphType )
   {
   	case "Bar":
   	 GraphChartBar
   	 (
   	  dataSet,
   	  xAxis,
   	  yAxis
   	 );
   	 break;

   	case "Pie":
   	 break;
   }//switch ( chartGraphType )
   
  }//Page_Load

  /// <summary>GraphChartBar.</summary>
  /// <param name="dataSet">The dataset.</param>
  /// <param name="xAxis">The xAxis.</param>
  /// <param name="yAxis">The yAxis.</param>    
  public static void GraphChartBar
  (
   DataSet 	  dataSet,
   String     xAxis,
   String     yAxis
  )
  {
   int            recordNumber          = 0;
   float          yAxisValue            = 0;   
   Bitmap         bitmap                = null; 
   Graphics       graphics              = null;

   HttpContext    httpContext           = HttpContext.Current;
   Pen            pen                   = null;

   PointF   pointFSymbolLeg;
   PointF   pointFDescriptionLeg;

   bitmap   = new Bitmap
   (
    UtilityGraphChart.BitMapPixelsWidth, 
    UtilityGraphChart.BitMapPixelsHeight
   );
   graphics = Graphics.FromImage( bitmap );
   pen      = new Pen(Color.Black, 2); 

   httpContext.Response.Clear();

   /*
    Set canvas color.
   */ 
   graphics.Clear(Color.Snow);

   /*
    Display graph title.
    Create point for upper-left corner of drawing.
   */ 
   graphics.DrawString
   (
    dataSet.Tables[0].TableName, 
    new Font("Tahoma", 16), 
    Brushes.Black, 
    new PointF(0.0F, 0.0F)
   );

   /*
    Display graph legends.
   */
   pointFSymbolLeg      = new PointF(285, 20);
   pointFDescriptionLeg = new PointF(310, 16);

   recordNumber         = 0;
   foreach(DataTable dataTable in dataSet.Tables)
   {
    foreach(DataRow dataRow in dataTable.Rows)
    {
     ++recordNumber;    	
     graphics.FillRectangle
     (
      new SolidBrush(UtilityGraphChart.GetColor(recordNumber % 8 )), 
      pointFSymbolLeg.X, 
      pointFSymbolLeg.Y, 
      20, 
      10
     );
     graphics.DrawRectangle
     (
      Pens.Black, 
      pointFSymbolLeg.X, 
      pointFSymbolLeg.Y, 
      20, 
      10
     );
     graphics.DrawString
     (
      System.Convert.ToString( dataRow[xAxis] ),
      new Font("Arial", 10), 
      Brushes.Black, 
      pointFDescriptionLeg
     );
     pointFSymbolLeg.Y += 15;
     pointFDescriptionLeg.Y += 15;
    }//foreach(DataRow dataRow in dataTable.Rows)
   }//foreach(DataTable dataTable in dataSet.Tables) 

   /*
    Display bars
   */ 
   recordNumber         = 0;
   foreach(DataTable dataTable in dataSet.Tables)
   {
    foreach(DataRow dataRow in dataTable.Rows)
    {
     ++recordNumber;
     yAxisValue = (float) Convert.ToDouble( dataRow[yAxis] );
     graphics.FillRectangle
     (
      new SolidBrush(UtilityGraphChart.GetColor(recordNumber % 8 )), 
      (recordNumber * UtilityGraphChart.XAxisSpaceBetweenBars) + 15, 
      200 - (yAxisValue * UtilityGraphChart.YAxisScale), 
      20, 
      (yAxisValue * UtilityGraphChart.YAxisScale) + 5
     );
     graphics.DrawRectangle
     (
      Pens.Black, 
      (recordNumber * UtilityGraphChart.XAxisSpaceBetweenBars) + 15, 
      200 - (yAxisValue * UtilityGraphChart.YAxisScale), 
      20, 
      (yAxisValue * UtilityGraphChart.YAxisScale) + 5
     );
    }//foreach(DataRow dataRow in dataTable.Rows)
   }//foreach(DataTable dataTable in dataSet.Tables) 

   graphics.DrawRectangle(pen, 1, 1, 398, 198);
   bitmap.Save(httpContext.Response.OutputStream, ImageFormat.Jpeg);
   	
  }//GraphChartBar()

 }//GraphChartPage class.
 
}//WordEngineering namespace.