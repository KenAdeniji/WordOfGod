using System;

namespace WordEngineering
{
 public class LeapYear
 {
  public static void Main(string[] argv)
  {
   int year = DateTime.Today.Year;
   if ( argv.Length > 0 ) { Int32.TryParse( argv[0], out year ); }
   bool leapYear = ( year % 4 == 0 ) && ( ( year % 100 != 0 ) || (year % 400 == 0) ); 
   System.Console.WriteLine("Year: {0} | Leap year: {1}", year, leapYear);
  }
 }
}