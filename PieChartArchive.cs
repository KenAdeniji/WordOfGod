using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 /// <summary>PieChart</summary>
 /// <remarks>PieChart</remarks>
 public class PieChart
 {

  ///<summary>BufferSpace</summary>
  public const int BufferSpace = 15;
  
  ///<summary>ColumnNumberData</summary>
  public const int ColumnNumberData  = 1;

  ///<summary>ColumnNumberLabel</summary>
  public const int ColumnNumberLabel = 0;

  ///<summary>pieChartWidth</summary>
  public const int PieChartWidth     = 300;

  /// <summary>The database connection string.</summary>
  public static String DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  /// <summary>The configuration XML filename.</summary>
  public static String FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The XPath database connection string.</summary>
  public const   String     XPathDatabaseConnectionString                            = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";

  ///<summary>CreatePieChart</summary>
  public static void CreatePieChart
  (
   ref String                           databaseConnectionString,
       String                           sqlSelectStatement,
       String                           title,
       int                              pieChartWidth,
   ref DataSet                          dataSet,
   ref String                           exceptionMessage
  )
  {


	int                  iLoop;
    
	float                total = 0.0F;
	float                tmp;

    // we need to create fonts for our legend and title
	Font fontLegend = new Font("Verdana", 10);
	Font fontTitle  = new Font("Verdana", 15, FontStyle.Bold);
	    
    HttpContext          httpContext          = HttpContext.Current;

    UtilityDatabase.DatabaseQuery
    (
           databaseConnectionString,
      ref  exceptionMessage,
      ref  dataSet,
           sqlSelectStatement,
           CommandType.Text
    );

	// find the total of the numeric data
	for (iLoop=0; iLoop < dataSet.Tables[0].Rows.Count; iLoop++)
	{
	 tmp = Convert.ToSingle(dataSet.Tables[0].Rows[iLoop][ColumnNumberData]);
	 total += tmp;
	}
	
	// We need to create a legend and title, how big do these need to be?
	// Also, we need to resize the height for the pie chart, respective to the
	// height of the legend and title
	int legendHeight = fontLegend.Height * (dataSet.Tables[0].Rows.Count+1) + BufferSpace;
	int titleHeight = fontTitle.Height + BufferSpace;
	int height = pieChartWidth + legendHeight + titleHeight + BufferSpace;
	int pieHeight = pieChartWidth;	// maintain a one-to-one ratio

	// Create a rectange for drawing our pie
	Rectangle pieRect = new Rectangle(0, titleHeight, pieChartWidth, pieHeight);

	// Create our pie chart, start by creating an ArrayList of colors
	ArrayList colors = new ArrayList();
	Random rnd = new Random();
	for (iLoop = 0; iLoop < dataSet.Tables[0].Rows.Count; iLoop++)
		colors.Add(new SolidBrush(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255))));
	
	float currentDegree = 0.0F;

	// Create a Bitmap instance	
	Bitmap objBitmap = new Bitmap(pieChartWidth, height);
	Graphics objGraphics = Graphics.FromImage(objBitmap);

	SolidBrush blackBrush = new SolidBrush(Color.Black);

	// Put a white backround in
	objGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, pieChartWidth, height);
	for (iLoop = 0; iLoop < dataSet.Tables[0].Rows.Count; iLoop++)
	{
		objGraphics.FillPie((SolidBrush) colors[iLoop], pieRect, currentDegree,
				Convert.ToSingle(dataSet.Tables[0].Rows[iLoop][ColumnNumberData]) / total * 360);

		// increment the currentDegree
		currentDegree += Convert.ToSingle(dataSet.Tables[0].Rows[iLoop][ColumnNumberData]) / total * 360;
	}

	// Create the title, centered
	StringFormat stringFormat = new StringFormat();
	stringFormat.Alignment = StringAlignment.Center;
	stringFormat.LineAlignment = StringAlignment.Center;

	objGraphics.DrawString(title, fontTitle, blackBrush, 
				 new Rectangle(0, 0, pieChartWidth, titleHeight), stringFormat);


	// Create the legend
	objGraphics.DrawRectangle(new Pen(Color.Black, 2), 0, height - legendHeight, pieChartWidth, legendHeight);
	for (iLoop = 0; iLoop < dataSet.Tables[0].Rows.Count; iLoop++)
	{
		objGraphics.FillRectangle((SolidBrush) colors[iLoop], 5, 
			height - legendHeight + fontLegend.Height * iLoop + 5, 10, 10);
		objGraphics.DrawString(((String) dataSet.Tables[0].Rows[iLoop][ColumnNumberLabel]) + " - " + 
				 Convert.ToString(dataSet.Tables[0].Rows[iLoop][ColumnNumberData]), fontLegend, blackBrush, 
				 20, height - legendHeight + fontLegend.Height * iLoop + 1);
	}

	// display the total
	objGraphics.DrawString("Total: " + Convert.ToString(total), fontLegend, blackBrush, 
			 5, height - fontLegend.Height - 5);

	// Since we are outputting a Jpeg, set the ContentType appropriately
	httpContext.Response.ContentType = "image/jpeg";

	// Save the image to a file
	objBitmap.Save(httpContext.Response.OutputStream, ImageFormat.Jpeg);

	// clean up...
    objGraphics.Dispose();
	objBitmap.Dispose();
  }
  
  /// <summary>Read the XML Configuration file.</summary>
  public static void ConfigurationXml()
  {  
   string exceptionMessage = null;
   
   ConfigurationXml
   (
        FilenameConfigurationXml,
    ref exceptionMessage,
    ref DatabaseConnectionString
   );
   
  }//public static void ConfigurationXml()

  /// <summary>Read the XML Configuration file.</summary>
  /// <param name="filenameConfigurationXml">The XML Configuration file.</param>
  /// <param name="exceptionMessage">The exception message.</param>
  /// <param name="databaseConnectionString">The database connection string.</param>  
  public static void ConfigurationXml
  (
       string filenameConfigurationXml,
   ref string exceptionMessage,
   ref string databaseConnectionString
  )
  {
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,
         XPathDatabaseConnectionString,
     ref databaseConnectionString
    );//ConfigurationXml()
  }//ConfigurationXml	 
  
 }//public class PieChart
}//namespace WordEngineering 