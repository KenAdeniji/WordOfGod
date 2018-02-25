using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;

// compile with: /r:system.dll /r:system.data.dll 
// To build this sample from the command line, use the command:
// csc /r:system.dll /r:system.data.dll /r:system.xml.dll PopulateBibleDatabaseBiblicalName.cs

namespace WordEngineering
{
 ///<remarks>
 ///ms-help://MS.NETFrameworkSDK/csref/html/vcwlkADOTutorial.htm
 ///File Template
 ///  $$T0000001
 ///  \A\
 ///  Alpha, the first letter of the Greek alphabet, as Omega is the
 ///  last. These letters occur in the text of Rev. 1:8,11; 21:6;
 ///  22:13, and are represented by "Alpha" and "Omega" respectively
 ///  (omitted in R.V., 1:11). They mean "the first and last." (Comp.
 ///  Heb. 12:2; Isa. 41:4; 44:6; Rev. 1:11,17; 2:8.) In the symbols
 ///  of the early Christian Church these two letters are frequently
 ///  combined with the cross or with Christ's monogram to denote his
 ///  divinity.
 ///</remarks>
 public class PopulateBibleDatabaseBiblicalName
 {
  
  public static int           CommandLineArgumentDatabaseConnectionStringSource      = 1;
  public static int           CommandLineArgumentDatabaseConnectionStringDestination = 2;  
  
  public static int           SqlSelectOrdinalDictionaryId                           = 0;
  public static int           SqlSelectOrdinalDictionaryWord                         = 1;
  public static int           SqlSelectOrdinalCommentary                             = 2;
  
  
  public const string         DatabaseConnectionStringSource                         = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\Bible\\BibleDatabase\\BibleDatabase_-_BiblicalNames.mdb";
  public const string         DatabaseConnectionStringDestination                    = "Data Source=localhost; Integrated Security=SSPI; Initial Catalog=BibleDictionary";
  public const string         SelectQuery                                            = "SELECT * FROM b_names";
  public const string         SourceTable                                            = "SourceTable";  
  public const string         StoredProcedure                                        = "PopulateBibleDatabaseBiblicalName";  

  public static SqlCommand    sqlCommand                                             = null;
  public static SqlConnection sqlConnection                                          = null;
  public static SqlParameter  sqlParameterDictionaryId                               = null;
  public static SqlParameter  sqlParameterDictionaryWord                             = null;
  public static SqlParameter  sqlParameterCommentary                                 = null;

  public static void Main(string[] args)
  {
   int     argumentCount                        = args.Length;
   
   string  databaseConnectionStringSource       = null;
   string  databaseConnectionStringDestination  = null;   
   
   DataRowCollection  dataRowCollection         = null; 
   DataSet            dataSet                   = null;
   OleDbConnection    oleDbConnection           = null;
   OleDbCommand       oleDbCommand              = null;
   OleDbDataAdapter   oleDbDataAdapter          = null;

   //Retrieve the source directory from the command-line 
   //parameters, first argument.
   switch ( argumentCount )
   {
    case 0: 
    { 
     databaseConnectionStringSource      = DatabaseConnectionStringSource;
     databaseConnectionStringDestination = DatabaseConnectionStringDestination;
     break; 
    }
    case 1: 
    { 
     databaseConnectionStringSource      = args[CommandLineArgumentDatabaseConnectionStringSource]; break; 
    }
    case 2: 
    { 
     databaseConnectionStringDestination = args[CommandLineArgumentDatabaseConnectionStringDestination]; break; 
    }
   }// switch ( argumentCount ) 

   try
   {
     // Create Microsoft Access Database Objects
     oleDbConnection   =  new OleDbConnection(databaseConnectionStringSource);
     oleDbCommand      =  new OleDbCommand(SelectQuery, oleDbConnection);
     oleDbDataAdapter  =  new OleDbDataAdapter(oleDbCommand);

     // Create the dataset 
     dataSet = new DataSet();
     dataSet.Tables.Add(SourceTable);

     oleDbDataAdapter.Fill(dataSet, SourceTable);
     
     dataRowCollection = dataSet.Tables["SourceTable"].Rows;

     sqlConnection = new SqlConnection( DatabaseConnectionStringDestination );
     sqlConnection.Open();
    
     sqlCommand    = new SqlCommand( StoredProcedure, sqlConnection );
     sqlCommand.CommandType = CommandType.StoredProcedure;
    
     sqlParameterDictionaryId          = sqlCommand.Parameters.Add("@dictionaryId",     SqlDbType.Int);;
     sqlParameterDictionaryWord        = sqlCommand.Parameters.Add("@dictionaryWord",   SqlDbType.VarChar, 255);;    
     sqlParameterCommentary            = sqlCommand.Parameters.Add("@commentary",       SqlDbType.Text);

     int            databaseColumnValueDictionaryId    = -1;
     string         databaseColumnValueDictionaryWord  = null;   
     StringBuilder  databaseColumnValueCommentary      = null;        
     
     foreach (DataRow  dataRow in dataRowCollection )
     {
//       Console.WriteLine("Dictionary[{0}] is {1} {2}", dataRow[0], dataRow[2]);

       databaseColumnValueDictionaryId    = Convert.ToInt32(dataRow[SqlSelectOrdinalDictionaryId]);
       databaseColumnValueDictionaryWord  = Convert.ToString(dataRow[SqlSelectOrdinalDictionaryWord]);   
       databaseColumnValueCommentary      = new StringBuilder( Convert.ToString(dataRow[SqlSelectOrdinalDictionaryWord]) );
       databaseColumnValueCommentary.Append(".");

       DatabaseWrite
       (
         databaseColumnValueDictionaryId,
         databaseColumnValueDictionaryWord,
         databaseColumnValueCommentary
       );
       
     }//foreach (DataRow  dataRow in dataRowCollection )

    }//try
    catch( SqlException exception )
    {
     System.Console.WriteLine("Exception: {0)", exception.Message);
    }
    catch( Exception exception )
    {
     System.Console.WriteLine("Exception: {0)", exception.Message);
    }
    finally
    {
      if ( oleDbConnection != null )
      {
        oleDbConnection.Close();
      } 

      if ( sqlConnection != null ) 
      {
        sqlConnection.Close();
      } 
    }//finally
  }//main()
  
  
  public static void DatabaseWrite
  (
   int            dictionaryId,
   string         dictionaryWord,
   StringBuilder  commentary
  ) 
  {
   try
   {

    sqlParameterDictionaryId.Value    = dictionaryId;
    sqlParameterDictionaryWord.Value  = dictionaryWord;    
    sqlParameterCommentary.Value      = commentary.ToString();        
                
    sqlCommand.ExecuteNonQuery();
    
   }
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }
  }//DatabaseWrite()

 }//PopulateBibleDatabaseBiblicalName class.
}//WordEngineering Namespace.
