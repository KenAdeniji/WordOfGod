using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;

namespace WordEngineering
{

 ///public class ContactGridViewObjectDataSourceTypeName
 public class ContactGridViewObjectDataSourceTypeName
 {

  ///SELECT  * FROM Contact Where lastname like '%" + lastname + "%'
  static string ContactSelect           = "SELECT * FROM Contact WHERE LastName LIKE '%{0}%' AND FirstName LIKE '%{1}%' AND OtherName LIKE '%{2}%' AND LastName LIKE '%{3}%'"; 

  /// <summary>The database connection string.</summary>
  static String DatabaseConnectionString = "Provider=SQLOLEDB;server=comfort;database=WordEngineering;Trusted_Connection=True;Integrated Security=SSPI;";

  /// <summary>SelectMethodContactDataSet()</summary>
  public static DataSet SelectMethodContactDataSet()
  {
   string           exceptionMessage          =  null;
   DataSet          dataSet                   =  null;
	   
   UtilityDatabase.DatabaseQuery
   (
	    DatabaseConnectionString,
	ref exceptionMessage,
	ref dataSet,
	    "SELECT * FROM Contact",
	    CommandType.Text
   );

   return ( dataSet );
	   
  }//public static DataSet SelectMethodContactDataSet()
   
   
  /// <summary>SelectMethodContactDataSet()</summary>
  public static DataSet SelectMethodContactDataSet
  (
   string lastName,
   string firstName,
   string otherName,
   string company
  )
  {
   string           exceptionMessage          =  "";
   string 			strSQLQuery               =  "";
   string           SQLAnd                    =  "  Where  ";

   DataSet          dataSet                   =  null;
     
   strSQLQuery = "SELECT  * FROM Contact ";	
     	  
   if (lastName != null)
   {
    lastName = lastName.Trim();
    strSQLQuery = strSQLQuery + SQLAnd + " (lastName like '%" + lastName + "%') ";	
    SQLAnd = " AND ";
   }   

   if (firstName != null)
   {
    firstName = firstName.Trim();
    strSQLQuery = strSQLQuery + SQLAnd + " (firstName like '%" + firstName + "%') ";	
    SQLAnd = " AND ";
   }

   if (otherName != null)
   {
    otherName = otherName.Trim();
    strSQLQuery = strSQLQuery + SQLAnd + " (otherName like '%" + otherName + "%') ";	
    SQLAnd = " AND ";
   }

   if (company != null)
   {
    company = company.Trim();
    strSQLQuery = strSQLQuery + SQLAnd + " (company like '%" + company + "%') ";	
    SQLAnd = " AND ";
   }
   
   UtilityDatabase.DatabaseQuery
   (
	    DatabaseConnectionString,
	ref exceptionMessage,
	ref dataSet,
	    strSQLQuery,
	    CommandType.Text
   );

   return ( dataSet );
	   
  }//public static DataSet SelectMethodContactDataSet()
  
     
  /// <summary>SelectMethodContactIDataReader()</summary>
  public static IDataReader SelectMethodContactIDataReader()
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
	   
  }//public static IDataReader SelectMethodContactIDataReader()

  /// <summary>UpdateMethodContact()</summary>
  public static void UpdateMethodContact(string FirstName, String LastName, string Company, string OtherName, int Original_SequenceOrderId)
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
  }//public static void updateContact(string FirstName, String LastName, string Company, string OtherName, int Original_SequenceOrderId)	  

  /// <summary>getContacts()</summary>
  public static SqlDataReader getContacts()
  {
		
   SqlConnection conn = new SqlConnection(DatabaseConnectionString);
   String strSQLSelect = "select * from dbo.Contact";
   SqlCommand sqlCmd = new SqlCommand(strSQLSelect, conn);
		
   conn.Open();
   SqlDataReader dtr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
		
   return dtr;
  }       
	  
  /// <summary>updateContactSQL()</summary>
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
	  
 }// public class ContactGridViewObjectDataSourceTypeName
}//namespace WordEngineering  
  