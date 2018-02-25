#region Using directives

using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;

#endregion

namespace async_callback
{
  class async_callback_demo
  {
    static void Main(string[] args)
    {
      // get DataReaders using the asynchronous "callback" 
      // method and then display the contents
      AsyncCallbackReader();

      // wait for a keypress then end
      Console.Write("\nPress a key...");
      Console.ReadKey(true);
    }
    // **************************************


    static void AsyncCallbackReader()
    {
      Console.WriteLine("Asynchronous Callback Example\n"
                      + "-----------------------------");

      // get database connection string from App.config file
      string sConnect = ConfigurationSettings.AppSettings["AdvWorksAsyncConnectString"];
      //String sConnect = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";
      
      //populate 3 SQL statement strings
      //String sSQL1 = "WAITFOR DELAY '00:00:05';SELECT AccountNumber, Name FROM Purchasing.Vendor WHERE AccountNumber LIKE 'AD%'";
      String sSQL1 = "WAITFOR DELAY '00:00:05';SELECT SequenceOrderId, FirstName + NOT ISNULL(FirstName, ' ') + NOT ISNULL(LastName, ' ') + Company FROM Contact";
      Console.WriteLine("SQL statement 1 contains a delay of 5 seconds");

      String sSQL2 = "WAITFOR DELAY '00:00:08';SELECT DISTINCT City, State FROM StreetAddress";
      Console.WriteLine("SQL statement 2 contains a delay of 8 seconds");

      //String sSQL3 = "WAITFOR DELAY '00:00:03';SELECT CardType, CardNumber FROM Sales.CreditCard WHERE CardNumber LIKE '%0234'";
      String sSQL3 = "WAITFOR DELAY '00:00:03';SELECT Dated, InternetAddress FROM ContactURI";      
      Console.WriteLine("SQL statement 3 contains a delay of 3 seconds");

      // create three connections and commands
      SqlConnection oConn1 = new SqlConnection(sConnect);
      SqlCommand oCmd1 = new SqlCommand(sSQL1, oConn1);

      SqlConnection oConn2 = new SqlConnection(sConnect);
      SqlCommand oCmd2 = new SqlCommand(sSQL2, oConn2);

      SqlConnection oConn3 = new SqlConnection(sConnect);
      SqlCommand oCmd3 = new SqlCommand(sSQL3, oConn3);

      try
      {
        // start async execution of all three Commands, specifying the
        // same callback delegate and the Command as the AsyncState
        oConn1.Open();
        oCmd1.BeginExecuteReader(new AsyncCallback(CommandCompleted), oCmd1, CommandBehavior.CloseConnection);
        Console.WriteLine("BeginExecuteReader completed for Command 1 at {0}", DateTime.Now.ToLongTimeString());

        oConn2.Open();
        oCmd2.BeginExecuteReader(new AsyncCallback(CommandCompleted), oCmd2, CommandBehavior.CloseConnection);
        Console.WriteLine("BeginExecuteReader completed for Command 2 at {0}", DateTime.Now.ToLongTimeString());

        oConn3.Open();
        oCmd3.BeginExecuteReader(new AsyncCallback(CommandCompleted), oCmd3, CommandBehavior.CloseConnection);
        Console.WriteLine("BeginExecuteReader completed for Command 3 at {0}", DateTime.Now.ToLongTimeString());
      }
      catch (Exception e)
      {
        oConn1.Close();
        oConn2.Close();
        oConn3.Close();
        Console.WriteLine("* ERROR: " + e.Message);
      }

      // now free to execute other code while waiting for each Command to complete
      // here we just display a "Waiting" message every second
      int iSecs = DateTime.Now.Second;
      while (oConn1.State == ConnectionState.Open
          || oConn2.State == ConnectionState.Open
          || oConn3.State == ConnectionState.Open)
      {
        if (DateTime.Now.Second != iSecs)
        {
          Console.Write("Waiting...");
          iSecs = DateTime.Now.Second;
        }
      }
      // all three connections are closed, so safe to exit
    }
    // *****************************************


    // callback handler used for all three Commands
    static void CommandCompleted(IAsyncResult oResult)
    {
      // get reference to original Command from AsyncState
      SqlCommand oCmd = (SqlCommand) oResult.AsyncState;
      try
      {
        // get DataReader and display results
        SqlDataReader oReader = oCmd.EndExecuteReader(oResult);
        Console.WriteLine("\n\nEndExecuteReader completed at {0}",
                          DateTime.Now.ToLongTimeString());
        DisplayRows(oReader);
      }
      catch (Exception e)
      {
        Console.WriteLine("* ERROR: " + e.Message);
      }
      oCmd.Connection.Close();
    }
    // **************************************


     static void DisplayRows(SqlDataReader oDR)
    {
      if (oDR.HasRows)
      {
        try
        {
          while (oDR.Read())
          {
            Console.WriteLine(oDR[0] + "\t" + oDR[1]);
          }
          Console.WriteLine();
        }
        catch (Exception e)
        {
          Console.WriteLine("* ERROR: " + e.Message);
        }
      }
      else
      {
        Console.WriteLine("No rows were returned.\n");
      }
      oDR.Close();
    }
    //**************************************
  }
}
