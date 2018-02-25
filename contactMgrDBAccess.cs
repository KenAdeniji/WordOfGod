namespace WordEngineering
{ 
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    

    public class contactMgrDBAccess : System.Web.UI.Page
    {
       
        //static String strDBConnectionString = "SERVER=(local);DATABASE=WordEngineering;UID=sa;PWD=gregU;";
        static String strDBConnectionString = "server=comfort;database=WordEngineering;Trusted_Connection=True;Integrated Security=SSPI;";
        
		public static SqlDataReader getContacts()
		{
			
			SqlConnection conn = new SqlConnection(strDBConnectionString);
			String strSQLSelect = "select * from dbo.Contact";
			SqlCommand sqlCmd = new SqlCommand(strSQLSelect, conn);
			
			conn.Open();
			
			SqlDataReader dtr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
			
			return dtr;
			
				
		}       
       
       
       public static void updateContact(string FirstName, String LastName, string Company, string OtherName, int original_SequenceOrderId)
       {
       	
			SqlConnection conn = new SqlConnection(strDBConnectionString);
			
			String strSQLUpdate = "usp_ContactUpdate";
			SqlCommand sqlCmd = new SqlCommand(strSQLUpdate, conn);
			sqlCmd.CommandType = CommandType.StoredProcedure;
			sqlCmd.Parameters.AddWithValue("@SequenceOrderId", original_SequenceOrderId);
			sqlCmd.Parameters.AddWithValue("@FirstName", FirstName);
			sqlCmd.Parameters.AddWithValue("@LastName", LastName);
			sqlCmd.Parameters.AddWithValue("@OtherName", OtherName);			
			sqlCmd.Parameters.AddWithValue("@Company", Company);
												
			conn.Open();
			
			sqlCmd.ExecuteNonQuery();
			
			conn.Close();			
			       	
       }
                  

    }

}
