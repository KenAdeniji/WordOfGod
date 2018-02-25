using System;
using System.Text;
using System.Net.Sockets;

namespace WordEngineering
{
 ///<summary>ScreenOne</summary>
 ///<remarks>
 /// Louisville.edu/~djchan01/cecs640/tcp.pdf Dar-jen Chang: CECS640 The Internet, TCP/IP Protocol, Socket and Client-Server Computing August 25, 2003
 ///</remarks>
 public static class ScreenOne
 {
  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main(string[] argv)
  {
  }
  
  ///<summary>Daytime</summary>
  public static string Daytime()
  {
   return( SetupScreen("time.nist.gov", 13, "hello") );
  }

  ///<summary>DSP</summary>
  ///<remarks>Display Support Protocol</remarks>
  public static string DSP()
  {
   return( SetupScreen(13) );
  }

  ///<summary>Echo</summary>
  public static string Echo()
  {
   return( SetupScreen(7, "Echo") );
  }

  ///<summary>Finger</summary>
  public static string Finger()
  {
   return( SetupScreen(79) );
  }

  ///<summary>Name</summary>
  public static string Name()
  {
   return( SetupScreen(42) );
  }

  ///<summary>NNTP</summary>
  ///<remarks>
  /// Network News Transfer Protocol (NNTP)
  /// %SystemRoot%\Help\News.chm
  ///</remarks>
  public static string NNTP()
  {
   return( SetupScreen(119, "list") );
  }

  ///<summary>Qotd</summary>
  ///<remarks>Quote of the Day</remarks>
  public static string Qotd()
  {
   return( SetupScreen(17) );
  }

  ///<summary>Systat</summary>
  ///<remarks>Active Users</remarks>
  public static string Systat()
  {
   return( SetupScreen(11) );
  }

  ///<summary>SetupScreen</summary>
  public static string SetupScreen( int port )
  {
   return( SetupScreen( "localhost", port, null ) );
  }

  ///<summary>SetupScreen</summary>
  public static string SetupScreen( int port, string request )
  {
   return( SetupScreen( "localhost", port, request ) );
  }

  ///<summary>SetupScreen</summary>
  public static string SetupScreen
  ( 
   string hostname, 
   int port,
   string request 
  )
  {
   string returndata = null; // bytes returned from server
   TcpClient tcpClient = null;
   
   try
   {
    tcpClient = new TcpClient( hostname, port );
    NetworkStream networkStream = tcpClient.GetStream();
    if ( request != null )
    {
     Byte[] sendBytes = Encoding.ASCII.GetBytes(request);
     // Send to the timeserver
     networkStream.Write(sendBytes, 0, sendBytes.Length);
     System.Console.WriteLine( request );
    }
    byte[] recBytes = new byte[tcpClient.ReceiveBufferSize];
    // Receive time from the timeserver
    int length = networkStream.Read (recBytes, 0, (int) tcpClient.ReceiveBufferSize);
    returndata = Encoding.ASCII.GetString(recBytes, 0, length);
   }
   catch(Exception ex)
   {
    returndata = ex.Message;
   }
   finally
   {
    if ( tcpClient != null )
    { 
     // Close the socket
     tcpClient.Close ();
    }
   }
   return( returndata );  
  }

  ///<summary>Time</summary>
  public static string Time()
  {
   return( SetupScreen(37) );
  }

 }
}