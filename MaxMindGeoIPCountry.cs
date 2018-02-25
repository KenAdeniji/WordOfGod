using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace WordEngineering
{
 ///<summary>MaxMindGeoIPCountry</summary>
 public class MaxMindGeoIPCountry
 {

  ///<summary>DatabaseConnectionString</summary>
  public const string DatabaseConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=WordEngineering;Integrated Security=SSPI;";

  ///<summary>FilenameSource</summary>
  public const string FilenameSource = @"D:\Documentation\MaxMind.com\MaxMind.com_-_GeoIPCountryWhois.csv";

  ///<summary>SQLInsert</summary>
  public const string SQLInsert = "INSERT MaxMindGeoIPCountry( IPAddressFirst, IPAddressLast, IPNumberFirst, IPNumberLast, CountryCodeISO3166, CountryName ) " +
                                  "VALUES ( '{0}', '{1}', {2}, {3}, '{4}', '{5}' )";

  ///<summary>SQLTruncate</summary>
  public const string SQLTruncate = "TRUNCATE TABLE MaxMindGeoIPCountry";
  
  ///<summary>Main</summary>
  public static void Main(string[] argv)
  {
   string  filenameSource = FilenameSource;
   if ( argv.Length > 0 ) { filenameSource = argv[0]; }
   Populate( filenameSource );
  }//public static void Main(string[] argv)

  ///<summary>Populate</summary>
  public static void Populate( string filenameSource )
  {
   string[]         column                    =  null;
   string           commandText               =  null;
   string           countryName               =  null;
   string           line                      =  null;
   StreamReader     streamReader              =  null;
   StringBuilder    stringBuilderCountryName  =  null;
   OleDbCommand     oleDbCommand              =  null;
   OleDbConnection  oleDbConnection           =  null;
   try
   {
    streamReader     =  new StreamReader( filenameSource );
    oleDbConnection  =  new OleDbConnection( DatabaseConnectionString );
    oleDbConnection.Open();
    oleDbCommand = new OleDbCommand( SQLTruncate, oleDbConnection );
    oleDbCommand.ExecuteNonQuery();
    while ( streamReader != StreamReader.Null )
    {
     line = streamReader.ReadLine();
     if ( line == null ) { break; }
     column = line.Split(',');
     for ( int indexColumn = 0; indexColumn < 5; ++indexColumn )
     {
      column[indexColumn] = column[indexColumn].Substring(1, column[indexColumn].Length - 2);
     }
     stringBuilderCountryName = new StringBuilder();
     for ( int indexColumn = 5; indexColumn < column.Length; ++indexColumn )
     {
      stringBuilderCountryName.Append( column[indexColumn] );
     }
     countryName  = stringBuilderCountryName.ToString();
     countryName  = countryName.Replace("\"", "");
     countryName  = countryName.Replace("'", "''");     
     commandText  = string.Format( SQLInsert, column[0], column[1], column[2], column[3], column[4], countryName );
     System.Console.WriteLine( commandText );
     oleDbCommand = new OleDbCommand( commandText, oleDbConnection );
     oleDbCommand.ExecuteNonQuery();
    }//while ( streamReader != StreamReader.Null )
   }//try
   catch ( Exception exception )
   {
    System.Console.WriteLine( exception.Message );
   }
   if ( streamReader != null ) { streamReader.Close(); }
   if ( oleDbConnection != null ) { oleDbConnection.Close(); }
  }//Populate()
 }//public class MaxMindGeoIPCountry
}//namespace WordEngineering
