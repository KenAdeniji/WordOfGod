namespace WordEngineering
{ 
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    

    public class frmContactBrowse : System.Web.UI.Page
    {
       
        static String strDBConnectionString = "SERVER=(local);DATABASE=WordEngineering;UID=WordEngineering;PWD=khouse;";
        
		public static SqlDataReader getContacts()
		{
			
			SqlConnection conn = new SqlConnection(strDBConnectionString);
			String strSQLSelect = "select * from dbo.Contact";
			SqlCommand sqlCmd = new SqlCommand(strSQLSelect, conn);
			
			conn.Open();
			
			SqlDataReader dtr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
			
			return dtr;
			
				
		}       
       
       
       public static void updateContact(int original_SequenceOrderId, String FirstName, String LastName)
       {
       	
			SqlConnection conn = new SqlConnection(strDBConnectionString);
			String strSQLUpdate = "usp_ContactUpdate";
			SqlCommand sqlCmd = new SqlCommand(strSQLUpdate, conn);
			sqlCmd.CommandType = CommandType.StoredProcedure;
			sqlCmd.Parameters.AddWithValue("@SequenceOrderId", original_SequenceOrderId);
			sqlCmd.Parameters.AddWithValue("@FirstName", FirstName);
			sqlCmd.Parameters.AddWithValue("@LastName", LastName);
									
			conn.Open();
			
			sqlCmd.ExecuteNonQuery();
			
			conn.Close();			
			       	
       }
                  

    }

}
