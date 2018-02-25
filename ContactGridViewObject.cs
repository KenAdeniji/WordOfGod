using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WordEngineering
{

 public class ContactGridViewObject
 {

  	  /// <summary>The database connection string.</summary>
  	  static String DatabaseConnectionString = "Provider=SQLOLEDB;server=comfort;database=WordEngineering;Trusted_Connection=True;Integrated Security=SSPI;";
  	  //static String DatabaseConnectionString = "Provider=SQLOLEDB;server=guidance;database=WordEngineering;uid=sa;pwd=girg";  
  
	  /// <summary>SelectMethodContact()</summary>
	  public static IDataReader SelectMethodContact()
	  {
	   string           exceptionMessage          =  null;
	   IDataReader      iDataReader               =  null;
	   
	   UtilityDatabase.DatabaseQuery
	   (
	        DatabaseConnectionString,
	    ref exceptionMessage,
	    ref iDataReader,
	        "SELECT * FROM Contact",
	        CommandType.Text
	   );
	   
	   return ( iDataReader );
	   
	  }//public static IDataReader SelectMethodContact()


	  public static SqlDataReader getContacts()
	  {
		
		SqlConnection conn = new SqlConnection(DatabaseConnectionString);
		String strSQLSelect = "select * from dbo.Contact";
		SqlCommand sqlCmd = new SqlCommand(strSQLSelect, conn);
		
		conn.Open();
		
		SqlDataReader dtr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
		
		return dtr;
		
			
	  }       
	   


	  
	  public static void updateContactSQL(string FirstName, String LastName, string Company, string OtherName, int Original_SequenceOrderId)
	  {
	       	
	   SqlConnection conn = new SqlConnection(DatabaseConnectionString);
				
	   String strSQLUpdate = "usp_ContactUpdate";
	   SqlCommand sqlCmd = new SqlCommand(strSQLUpdate, conn);
	   sqlCmd.CommandType = CommandType.StoredProcedure;
	   

	   sqlCmd.Parameters.AddWithValue("@SequenceOrderId", Original_SequenceOrderId);
	   sqlCmd.Parameters.AddWithValue("@FirstName", FirstName);
	   sqlCmd.Parameters.AddWithValue("@LastName", LastName);
	   sqlCmd.Parameters.AddWithValue("@OtherName", OtherName);			
	   sqlCmd.Parameters.AddWithValue("@Company", Company);
	   													
	   conn.Open();
	   
	   	sqlCmd.ExecuteNonQuery();
	   
	   conn.Close();			
	   
	  }
	  
	  
	  public static void updateContact(string FirstName, String LastName, string Company, string OtherName, int Original_SequenceOrderId)
	  {
	       	
	   OleDbConnection  conn = new OleDbConnection(DatabaseConnectionString);
				
	   String strSQLUpdate = "usp_ContactUpdate";
	   OleDbCommand sqlCmd = new OleDbCommand(strSQLUpdate, conn);
       sqlCmd.CommandType = CommandType.StoredProcedure;
	   

	   sqlCmd.Parameters.AddWithValue("@SequenceOrderId", Original_SequenceOrderId);
	   sqlCmd.Parameters.AddWithValue("@FirstName", FirstName);
	   sqlCmd.Parameters.AddWithValue("@LastName", LastName);
	   sqlCmd.Parameters.AddWithValue("@OtherName", OtherName);			
	   sqlCmd.Parameters.AddWithValue("@Company", Company);
	   


/*
	   sqlCmd.Parameters.AddWithValue("@SequenceOrderId", OleDbType.Integer).Value = Original_SequenceOrderId;
	   sqlCmd.Parameters.AddWithValue("@FirstName", OleDbType.VarChar).Value = FirstName;
	   sqlCmd.Parameters.AddWithValue("@LastName",  OleDbType.VarChar).Value = LastName;
	   sqlCmd.Parameters.AddWithValue("@OtherName", OleDbType.VarChar).Value = OtherName;			
	   sqlCmd.Parameters.AddWithValue("@Company", OleDbType.VarChar).Value = Company;	   
*/
	   conn.Open();
	   
	   	sqlCmd.ExecuteNonQuery();
	   
	   conn.Close();			
	   
	  }	  

	  	  
	}	  
  
}  
  