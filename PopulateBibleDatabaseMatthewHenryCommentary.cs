using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;

// compile with: /r:system.dll /r:system.data.dll 
// To build this sample from the command line, use the command:
// csc /r:system.dll /r:system.data.dll /r:system.xml.dll PopulateBibleDatabaseMatthewHenryCommentary.cs

namespace WordEngineering
{
 public class PopulateBibleDatabaseMatthewHenryCommentary
 {
  
  public static int           CommandLineArgumentDatabaseConnectionStringSource      = 1;
  public static int           CommandLineArgumentDatabaseConnectionStringDestination = 2;  
  
  public static int           SqlSelectOrdinalDictionaryId                           = 0;
  public static int           SqlSelectOrdinalBibleBookId                            = 1;
  public static int           SqlSelectOrdinalBibleChapterId                         = 2;
  public static int           SqlSelectOrdinalBibleVerseId                           = 3;    
  public static int           SqlSelectOrdinalCommentary                             = 4;
  
  
  public const string         DatabaseConnectionStringSource                         = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\Bible\\BibleDatabase\\BibleDatabase_-_MatthewHenryCommentary.mdb";
  public const string         DatabaseConnectionStringDestination                    = "Data Source=localhost; Integrated Security=SSPI; Initial Catalog=BibleDictionary";
  public const string         SelectQuery                                            = "SELECT BIB_ID, bookNum, chapter, verse, narration  FROM b_mh";
  public const string         SourceTable                                            = "SourceTable";  
  public const string         StoredProcedure                                        = "PopulateBibleDatabaseMatthewHenryCommentary";  

  public static SqlCommand    sqlCommand                                             = null;
  public static SqlConnection sqlConnection                                          = null;
  public static SqlParameter  sqlParameterDictionaryId                               = null;
  public static SqlParameter  sqlParameterBibleBookId                                = null;  
  public static SqlParameter  sqlParameterBibleChapterId                             = null;
  public static SqlParameter  sqlParameterBibleVerseId                               = null;  
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
    
     sqlParameterDictionaryId          = sqlCommand.Parameters.Add("@dictionaryId",      SqlDbType.Int);
     sqlParameterBibleBookId           = sqlCommand.Parameters.Add("@BibleBookId",       SqlDbType.Int);
     sqlParameterBibleChapterId        = sqlCommand.Parameters.Add("@BibleChapterId",    SqlDbType.Int);;                    
     sqlParameterBibleVerseId          = sqlCommand.Parameters.Add("@BibleVerseId",      SqlDbType.Int);               
     sqlParameterCommentary            = sqlCommand.Parameters.Add("@commentary",        SqlDbType.Text);

     int            databaseColumnValueDictionaryId    = -1;
     int            databaseColumnValueBibleBookId     = -1;     
     int            databaseColumnValueBibleChapterId  = -1;   
     int            databaseColumnValueBibleVerseId    = -1;        
     StringBuilder  databaseColumnValueCommentary      = null;

     foreach (DataRow  dataRow in dataRowCollection )
     {
       //System.Console.WriteLine("Dictionary[{0}] is {1} {2} {3} {4}", dataRow[0], dataRow[1], dataRow[2], dataRow[3], dataRow[4]);

       databaseColumnValueDictionaryId    = Convert.ToInt32(dataRow[SqlSelectOrdinalDictionaryId]);
       databaseColumnValueBibleBookId     = Convert.ToInt32(dataRow[SqlSelectOrdinalBibleBookId]);       
       databaseColumnValueBibleChapterId  = Convert.ToInt32(dataRow[SqlSelectOrdinalBibleChapterId]);       
       databaseColumnValueBibleVerseId    = Convert.ToInt32(dataRow[SqlSelectOrdinalBibleVerseId]);              
       databaseColumnValueCommentary      = new StringBuilder();
       databaseColumnValueCommentary.Append( Convert.ToString(dataRow[SqlSelectOrdinalCommentary]) );

       /*
       object         databaseColumnValueTemp            = null;
       databaseColumnValueTemp            =   dataRow[SqlSelectOrdinalCommentary];
       if ( databaseColumnValueTemp       ==  DBNull.Value )
       {
         databaseColumnValueCommentary    =   null;
       }
       else
       {  
         databaseColumnValueCommentary    =   new StringBuilder();       
         databaseColumnValueCommentary.Append( databaseColumnValueTemp.ToString() );
       }  
       */
       
       DatabaseWrite
       (
         databaseColumnValueDictionaryId,
         databaseColumnValueBibleBookId,
         databaseColumnValueBibleChapterId,
         databaseColumnValueBibleVerseId,
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
   int            bibleBookId,
   int            bibleChapterId,
   int            bibleVerseId,      
   StringBuilder  commentary
  ) 
  {
   try
   {

    sqlParameterDictionaryId.Value    =  dictionaryId;
    sqlParameterBibleBookId.Value     =  bibleBookId;    
    sqlParameterBibleChapterId.Value  =  bibleChapterId;
    sqlParameterBibleVerseId.Value    =  bibleVerseId;    
    sqlParameterCommentary.Value      =  commentary.ToString();        
               
    sqlCommand.ExecuteNonQuery();
    
   }
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }
  }//DatabaseWrite()

 }//PopulateBibleDatabaseMatthewHenryCommentary class.
}//WordEngineering Namespace.
