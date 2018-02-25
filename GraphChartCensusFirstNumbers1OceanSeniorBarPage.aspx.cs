using  System;
using  System.Collections;
using  System.Collections.Specialized;
using  System.Web.UI;
using  System.Web.UI.HtmlControls;
using  System.Web.UI.WebControls;
using  System.Data;
using  System.Data.OleDb;
using  System.Data.SqlClient;
using  System.Drawing;
using  System.Drawing.Imaging;
using  System.Text;


using  WordEngineering;

namespace WordEngineering
{
 /// <summary>Graph Chart Census First Numbers 1 Ocean Senior Bar Page.</summary>
 public class GraphChartCensusFirstNumbers1OceanSeniorBarPage : Page
 {

   static int[] yAxis = new int[]
   { 
    12, 
    7,
    4,
    10,
    3,
    11,
    9
   };

   static String[] xAxis = new String[]
   { 
    "Monday", 
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
    "Sunday"
   };

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   int i;
   int spacebetbars = 35;
   int scale        = 10;

   string   filenameXml           = null;

   Bitmap   bitmap                = null; 
   Graphics graphics              = null;

   Pen      pen                   = null;

   PointF   pointFSymbolLeg;
   PointF   pointFDescriptionLeg;

   int loop1, loop2;
 
   // Load NameValueCollection object.
   NameValueCollection coll=Request.QueryString; 
   // Get names of all keys into a string array.
   String[] arr1 = coll.AllKeys; 
   for (loop1 = 0; loop1 < arr1.Length; loop1++) 
   {
    Response.Write("Key: " + Server.HtmlEncode(arr1[loop1]) + "<br>");
    String[] arr2 = coll.GetValues(arr1[loop1]);
    for (loop2 = 0; loop2 < arr2.Length; loop2++) 
    {
      Response.Write("Value " + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
    }
   }
   
   if ( loop1 >= 0 || loop2 >= 0 )
   {
   	return;
   }	

   bitmap   = new Bitmap(400, 200);
   graphics = Graphics.FromImage( bitmap );
   pen      = new Pen(Color.Black, 2); 

   /*
    Set canvas color.
   */ 
   graphics.Clear(Color.Snow);

   /*
    Display graph title.
   */ 
   graphics.DrawString
   (
    "Hours per day", 
    new Font("Tahoma", 16), 
    Brushes.Black, 
    new PointF(5, 5)
   );


   /*
    Display graph legends.
   */
   pointFSymbolLeg      = new PointF(285, 20);
   pointFDescriptionLeg = new PointF(310, 16);

   for (i = 0; i < xAxis.Length; ++i )
   {
    graphics.FillRectangle
    (
     new SolidBrush(GetColor(i)), 
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
     System.Convert.ToString( xAxis[i] ),
     new Font("Arial", 10), 
     Brushes.Black, 
     pointFDescriptionLeg
    );
    pointFSymbolLeg.Y += 15;
    pointFDescriptionLeg.Y += 15;
   }
   
   /*
    Display bars
   */ 
   for (i = 0; i < yAxis.Length; ++i )
   {
    graphics.FillRectangle
    (
     new SolidBrush(GetColor(i)), 
     (i * spacebetbars) + 15, 
     200 - (yAxis[i] * scale), 
     20, 
     (yAxis[i] * scale) + 5
    );
    graphics.DrawRectangle
    (
     Pens.Black, 
     (i * spacebetbars) + 15, 
     200 - (yAxis[i] * scale), 
     20, 
     (yAxis[i] * scale) + 5
    );
   }

   graphics.DrawRectangle(pen, 1, 1, 398, 198);
   bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
   
  }//Page_Load

  /// <summary>Page Load.</summary>
  public Color GetColor
  (
   int indexColor 
  )
  {
   Color color = Color.Blue;
   
   switch( indexColor )
   {
   	case 0:
   	 color = Color.Blue;
   	 break;

   	case 1:
   	 color = Color.Red;
   	 break;

   	case 2:
   	 color = Color.Yellow;
   	 break;

   	case 3:
   	 color = Color.Peru;
   	 break;

   	case 4:
   	 color = Color.Orange;
   	 break;

   	case 5:
   	 color = Color.Coral;
   	 break;

   	case 6:
   	 color = Color.Gray;
   	 break;

   	case 7:
   	 color = Color.Maroon;
   	 break;

   	case 8:
   	 color = Color.Green;
   	 break;
   	 
   }//switch( indexColor )
   
   return ( color );
   
  }//public Color GetColor()	 

 }//BarChart class.
 
}//WordEngineering namespace.