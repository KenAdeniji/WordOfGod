using System.Data;
using System.IO;
using System.Text;

namespace WordEngineering
{
 ///<summary>Sterling</summary>
 public class Sterling
 {
  /// <summary>The database connection string</summary>
  public const string  DatabaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";

  ///<summary>FormatSelectInsertUpdate</summary>
  public const string FormatSelectInsertUpdate = @"IF NOT EXISTS (SELECT 1 FROM {0} WHERE sequenceOrderId = {1}) INSERT {0} (2) VALUES {3}";

  ///<summary>TheWord</summary>
  public const string TheWord = @"\TheWord";

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">Command-line parameters.</param>
  public static void Main(string[] argv)
  {
   GhanaTwin();      
  }

  ///<summary>GhanaTwin</summary>
  public static void GhanaTwin()
  {
   string[] filename;
   DataSet dataSet = new DataSet();
   StringBuilder insertColumn;
   StringBuilder insertValue;
   StringBuilder selectInsertUpdate;
   filename = Directory.GetFiles(TheWord,"*.xml");
   foreach(string filenameCurrent in filename)
   {
    if (filenameCurrent.IndexOf("Archive") > -1) {continue;}
    dataSet.ReadXml(filenameCurrent); 
    foreach(DataTable dataTable in dataSet.Tables)
    {
     foreach(DataRow dataRow in dataTable.Rows)
     {
      selectInsertUpdate = new StringBuilder();
      insertColumn = new StringBuilder();
      insertValue = new StringBuilder();
      for(int column = 0; column < dataTable.Columns.Count; ++column)
      {
       //System.Console.WriteLine(dataRow[column]);
       insertColumn.Append(dataTable.Columns[column].ColumnName);
       insertValue.Append(dataRow[column]);
      }
      selectInsertUpdate.AppendFormat
      (
       FormatSelectInsertUpdate, 
       dataTable.TableName,
       dataRow["sequenceOrderId"],
       insertColumn,
       insertValue
      );
      System.Console.WriteLine(selectInsertUpdate);
     }
    }
    break;
   }
  }

 }
}