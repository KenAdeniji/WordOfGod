/*
 2003-12-10T00:00:00.0000000-08:00y
 Ressurection Lutheran Church 397 Euclid Avenue Oakland CA 94610.
 Church Calendar:
 1 Advent, commences on the first Sunday 4 weeks before Christmas. 2003-11-30T00:00:00.0000000-08:00 ... 2003-12-24T00:00:00.0000000-08:00.
 2 Christmas season 12 days 2003-12-25T00:00:00.0000000-08:00 ... 2004-01-06T00:00:00.0000000-08:00.
 3 Epiphany, Greek, short forth, make manifest, commences after the Christmas season and ends the day before Ash Wednesday, 2004-01-07T00:00:00.0000000-08:00 ... 2004-02-21T00:00:00.0000000-08:00.
 4 Ash Wednesday, the seventh Wednesday before Easter and the first day of Lent.
 5 Lent, 40 days before Easter Sunday 2004-03-09T00:00:00.0000000-08:00.
 6 Easter Sunday 2003-04-20T00:00:00.0000000-08:00. 2004-04-18T00:00:00.0000000-08:00.
 7 Pentecost, 50 days after Easter Sunday 2004-06-07T00:00:00.0000000-08:00.
 Asiana Airlines FlyAsiana.com. 3 sweets.
*/

using System;
using System.Data;
using System.Collections;

namespace WordEngineering
{
 /// <summary>ChurchCalendar.</summary>
 /// <remarks>ChurchCalendar.</remarks>
 public class ChurchCalendar
 {

  /// <summary>The rank for the season commentary.</summary>
  public const int RankSeasonCommentary = 1;

  /// <summary>The rank for the season title.</summary>
  public const int RankSeasonTitle      = 0;

  /// <summary>The 4 weeks prior to Christmas.</summary>
  public const int AdventChristmas      = -28;

  /// <summary>The Christmas season in days.</summary>
  public const int ChristmasSeasonDays  = 12;

  /// <summary>The lent days.</summary>
  public const int LentDays             = 40;

  /// <summary>The 50th day after Easter Sunday.</summary>
  public const int PentecostDays        = 50;

  /// <summary>The entry point for the application. List the titles of the books in the bible.</summary>
  /// <param name="argv">A list of command line arguments</param>
  public static void Main( string[] argv )
  {
   //SeasonPrint();
   Stub();
  }//public static void Main()

  /// <summary>Advent: Commences on the prior Sunday 4 weeks before Christmas.</summary>   
  public static void Advent()
  {
   DateTime adventFrom  = new DateTime();
   DateTime adventUntil = new DateTime();
   Advent
   ( 
        ChurchCalendarYearDefault(),
    ref adventFrom,
    ref adventUntil
   );
  }// Advent

  /// <summary>Advent: Commences on the prior Sunday 4 weeks before Christmas.</summary>   
  public static void Advent
  (
   int churchCalendarYear
  )
  {
   DateTime adventFrom  = new DateTime();
   DateTime adventUntil = new DateTime();
   Advent
   ( 
        churchCalendarYear,
    ref adventFrom,
    ref adventUntil
   );
  }

  /// <summary>Advent: Commences on the prior Sunday 4 weeks before Christmas.</summary>   
  public static void Advent
  (
   ref DateTime adventFrom,
   ref DateTime adventUntil
  )
  {
   Advent
   ( 
        ChurchCalendarYearDefault(),
    ref adventFrom,
    ref adventUntil
   );
  }

  /// <summary>Advent: Commences on the prior Sunday 4 weeks before Christmas.</summary>   
  public static void Advent
  (
       int      churchCalendarYear,
   ref DateTime adventFrom,
   ref DateTime adventUntil
  )
  {
   DateTime christmas  = Christmas( churchCalendarYear ); 
   adventFrom          = christmas.AddDays( AdventChristmas ); 
   adventUntil         = christmas.AddDays( -1 ); 
   while ( true )
   {
    if ( adventFrom.DayOfWeek == DayOfWeek.Sunday )
    {
     break;
    }
    adventFrom = adventFrom.AddDays( 1 ); 
   }//while ( true )

   #if (DEBUG)
    System.Console.WriteLine("Advent: {0} ... {1}", adventFrom, adventUntil);
   #endif
  }// Advent

  /// <summary>Ash Wednesday, the seventh Wednesday before Easter and the first day of Lent.</summary>   
  public static void AshWednesday()
  {
   DateTime ashWednesday = new DateTime();
   AshWednesday
   ( 
        ChurchCalendarYearDefault(),
    ref ashWednesday
   );
  }

  /// <summary>Ash Wednesday, the seventh Wednesday before Easter and the first day of Lent.</summary>   
  public static void AshWednesday
  (
   int churchCalendarYear
  )
  {
   DateTime ashWednesday = new DateTime();
   AshWednesday
   ( 
        churchCalendarYear,
    ref ashWednesday
   );
  }

  /// <summary>Ash Wednesday, the seventh Wednesday before Easter and the first day of Lent.</summary>   
  public static void AshWednesday
  (
   ref DateTime ashWednesday
  )
  {
   AshWednesday
   ( 
        ChurchCalendarYearDefault(),
    ref ashWednesday
   );
  }

  /// <summary>Ash Wednesday, the seventh Wednesday before Easter and the first day of Lent.</summary>   
  public static void AshWednesday
  (
       int      churchCalendarYear,
   ref DateTime ashWednesday
  )
  {
   if ( DateTime.IsLeapYear( churchCalendarYear ) )
   {
    ashWednesday = new DateTime( churchCalendarYear, 2, 29 );
   }
   else
   {
    ashWednesday = new DateTime( churchCalendarYear, 2, 28 );
   }

   while ( true )
   {
    if ( ashWednesday.DayOfWeek == DayOfWeek.Wednesday )
    {
     break;
    }
    ashWednesday = ashWednesday.AddDays( -1 ); 
   }//while ( true )

   #if (DEBUG)
    System.Console.WriteLine("Ash Wednesday: {0}", ashWednesday);
   #endif
  }
 
  /// <summary>Christmas: 25th of December.</summary>   
  public static DateTime Christmas
  (
   int churchCalendarYear
  )
  {
   return ( new DateTime( churchCalendarYear, 12, 25 ) );
  }// Christmas 25th of December.

  /// <summary>Christmas Season: 12 days 2003-12-25T00:00:00.0000000-08:00 ... 2004-01-05T00:00:00.0000000-08:00.</summary>   
  public static void ChristmasSeason()
  {
   DateTime christmasSeasonFrom  = new DateTime();
   DateTime christmasSeasonUntil = new DateTime();
   ChristmasSeason
   ( 
        ChurchCalendarYearDefault(),
    ref christmasSeasonFrom,
    ref christmasSeasonUntil
   );
  }

  /// <summary>Christmas Season: 12 days 2003-12-25T00:00:00.0000000-08:00 ... 2004-01-05T00:00:00.0000000-08:00.</summary>   
  public static void ChristmasSeason
  (
   int churchCalendarYear
  )
  {
   DateTime christmasSeasonFrom  = new DateTime();
   DateTime christmasSeasonUntil = new DateTime();
   ChristmasSeason
   ( 
        churchCalendarYear,
    ref christmasSeasonFrom,
    ref christmasSeasonUntil
   );
  }
    
  /// <summary>Christmas Season: 12 days 2003-12-25T00:00:00.0000000-08:00 ... 2004-01-05T00:00:00.0000000-08:00.</summary>   
  public static void ChristmasSeason
  (
   ref DateTime christmasSeasonFrom,
   ref DateTime christmasSeasonUntil
  )
  {
   ChristmasSeason
   ( 
        ChurchCalendarYearDefault(),
    ref christmasSeasonFrom,
    ref christmasSeasonUntil
   );
  }

  /// <summary>Christmas Season: 12 days 2003-12-25T00:00:00.0000000-08:00 ... 2004-01-05T00:00:00.0000000-08:00.</summary>   
  public static void ChristmasSeason
  (
       int      churchCalendarYear,
   ref DateTime christmasSeasonFrom,
   ref DateTime christmasSeasonUntil
  )
  {
   christmasSeasonFrom  = Christmas( churchCalendarYear ); 
   christmasSeasonUntil = christmasSeasonFrom.AddDays( ChristmasSeasonDays - 1 ); 

   #if (DEBUG)
    System.Console.WriteLine("Christmas Season: {0} ... {1}", christmasSeasonFrom, christmasSeasonUntil);
   #endif
  }

  /// <summary>The default church calendar year.</summary>   
  public static int ChurchCalendarYearDefault()
  {
   return ( DateTime.Today.Year);
  }// The default church calendar year. 

  /// <summary>Easter Sunday 2003-04-20T00:00:00.0000000-08:00. 2004-04-18T00:00:00.0000000-08:00.</summary>   
  public static void EasterSunday()
  {
   DateTime easterSunday = new DateTime();
   EasterSunday
   ( 
        ChurchCalendarYearDefault(),
    ref easterSunday
   );
  }

  /// <summary>Easter Sunday 2003-04-20T00:00:00.0000000-08:00. 2004-04-18T00:00:00.0000000-08:00.</summary>   
  public static void EasterSunday
  (
   int churchCalendarYear
  )
  {
   DateTime easterSunday = new DateTime();
   EasterSunday
   ( 
        churchCalendarYear,
    ref easterSunday
   );
  }

  /// <summary>Easter Sunday 2003-04-20T00:00:00.0000000-08:00. 2004-04-18T00:00:00.0000000-08:00.</summary>   
  public static void EasterSunday
  (
   ref DateTime easterSunday
  )
  {
   EasterSunday
   ( 
        ChurchCalendarYearDefault(),
    ref easterSunday
   );
  }

  /// <summary>EasterSunday: last Wednesday in February 2004-02-25T00:00:00.0000000-08:00.</summary>   
  public static void EasterSunday
  (
       int      churchCalendarYear,
   ref DateTime easterSunday
   
  )
  {
   bool lastSundayInApril = false;
   easterSunday = new DateTime( churchCalendarYear, 4, 30 );

   while ( true )
   {
    if ( easterSunday.DayOfWeek == DayOfWeek.Sunday )
    {
     if ( lastSundayInApril == false )
     {
      lastSundayInApril = true;
     }//if ( lastSundayInApril == false )
     else
     {
      break;
     }//else ( lastSundayInApril == true )
    }//if ( easterSunday.DayOfWeek == DayOfWeek.Sunday )
    easterSunday = easterSunday.AddDays( -1 ); 
   }//while ( true )

   #if (DEBUG)
    System.Console.WriteLine("Easter Sunday: {0}", easterSunday);
   #endif
  }

  /// <summary>Epiphany, Greek, short forth, make manifest, commences after the Christmas season and ends the day before Ash Wednesday, 2004-01-07T00:00:00.0000000-08:00 ... 2004-02-21T00:00:00.0000000-08:00.</summary>   
  public static void Epiphany()
  {
   DateTime epiphanyFrom  = new DateTime();
   DateTime epiphanyUntil = new DateTime();
   Epiphany
   ( 
        ChurchCalendarYearDefault(),
    ref epiphanyFrom,
    ref epiphanyUntil
   );
  }

  /// <summary>Epiphany, Greek, short forth, make manifest, commences after the Christmas season and ends the day before Ash Wednesday, 2004-01-07T00:00:00.0000000-08:00 ... 2004-02-21T00:00:00.0000000-08:00.</summary>   
  public static void Epiphany
  (
   int churchCalendarYear
  )
  {
   DateTime epiphanyFrom  = new DateTime();
   DateTime epiphanyUntil = new DateTime();
   Epiphany
   ( 
        churchCalendarYear,
    ref epiphanyFrom,
    ref epiphanyUntil
   );
  }

  /// <summary>Epiphany, Greek, short forth, make manifest, commences after the Christmas season and ends the day before Ash Wednesday, 2004-01-07T00:00:00.0000000-08:00 ... 2004-02-21T00:00:00.0000000-08:00.</summary>   
  public static void Epiphany
  (
       int      churchCalendarYear,
   ref DateTime epiphanyFrom,
   ref DateTime epiphanyUntil
  )
  {
   DateTime  ashWednesday = new DateTime();

   epiphanyFrom  = new DateTime( churchCalendarYear, 1, 6 );
   AshWednesday
   ( 
        churchCalendarYear, 
    ref ashWednesday 
   );
   epiphanyUntil = ashWednesday.AddDays( -1 ); 

   #if (DEBUG)
    System.Console.WriteLine("Epiphany: {0} ... {1}", epiphanyFrom, epiphanyUntil);
   #endif
  }

  /// <summary>Lent, 40 days before Easter Sunday 2004-03-09T00:00:00.0000000-08:00.</summary>   
  public static void Lent()
  {
   DateTime lentFrom  = new DateTime();
   DateTime lentUntil = new DateTime();
   Lent
   ( 
        ChurchCalendarYearDefault(),
    ref lentFrom,
    ref lentUntil
   );
  }

  /// <summary>Lent, 40 days before Easter Sunday 2004-03-09T00:00:00.0000000-08:00.</summary>   
  public static void Lent
  (
   int churchCalendarYear
  )
  {
   DateTime lentFrom  = new DateTime();
   DateTime lentUntil = new DateTime();
   Lent
   ( 
        churchCalendarYear,
    ref lentFrom,
    ref lentUntil
   );
  }

  /// <summary>Lent, 40 days before Easter Sunday 2004-03-09T00:00:00.0000000-08:00.</summary>   
  public static void Lent
  (
   ref DateTime lentFrom,
   ref DateTime lentUntil
  )
  {
   Lent
   ( 
        ChurchCalendarYearDefault(),
    ref lentFrom,
    ref lentUntil
   );
  }

  /// <summary>Lent, 40 days before Easter Sunday 2004-03-09T00:00:00.0000000-08:00.</summary>   
  public static void Lent
  (
       int      churchCalendarYear,
   ref DateTime lentFrom,
   ref DateTime lentUntil
  )
  {
   DateTime easterSunday = new DateTime();
   EasterSunday
   ( 
        churchCalendarYear, 
    ref easterSunday 
   ); 
   lentFrom     = easterSunday.AddDays( -LentDays ); 
   lentUntil    = easterSunday.AddDays( -1 ); 

   #if (DEBUG)
    System.Console.WriteLine("Lent: {0} ... {1}", lentFrom, lentUntil);
   #endif
  }

  /// <summary>Pentecost, 50th day after Easter Sunday, 2004-06-07T00:00:00.0000000-08:00.</summary>   
  public static void Pentecost()
  {
   DateTime pentecost = new DateTime();
   Pentecost
   ( 
        ChurchCalendarYearDefault(),
    ref pentecost
   );
  }

  /// <summary>Pentecost, 50th day after Easter Sunday, 2004-06-07T00:00:00.0000000-08:00.</summary>   
  public static void Pentecost
  (
   int churchCalendarYear
  )
  {
   DateTime pentecost = new DateTime();
   Pentecost
   ( 
        churchCalendarYear,
    ref pentecost
   );
  }

  /// <summary>Pentecost, 50th day after Easter Sunday, 2004-06-07T00:00:00.0000000-08:00.</summary>   
  public static void Pentecost
  (
       int      churchCalendarYear,
   ref DateTime pentecost
  )
  {
   DateTime easterSunday = new DateTime();
   EasterSunday
   ( 
        churchCalendarYear, 
    ref easterSunday 
   ); 
   pentecost = easterSunday.AddDays( PentecostDays ); 
   #if (DEBUG)
    System.Console.WriteLine("Pentecost: {0}", pentecost);
   #endif
  }

  /// <summary>Print the seasons.</summary>   
  public static void SeasonPrint()
  {
   for ( int seasonId = 0; seasonId < Seasons.Length; ++seasonId )
   {
    System.Console.WriteLine("{0}. {1}", Seasons[seasonId][RankSeasonTitle], Seasons[seasonId][RankSeasonCommentary]);
   }//foreach (string bibleBook in BibleBooks)
  }// Print the seasons.

  /// <summary>Stub.</summary>   
  public static void Stub()
  {
   for ( int churchCalendarYear = 2003; churchCalendarYear <= 2004; ++churchCalendarYear )
   {
    Advent( churchCalendarYear );
    ChristmasSeason( churchCalendarYear );
    /*
    Epiphany( churchCalendarYear);
    AshWednesday( churchCalendarYear ); 
    Lent( churchCalendarYear );
    EasterSunday( churchCalendarYear );
    Pentecost( churchCalendarYear );
    */
   }	
  } 

  /// <summary>The churchCalendar.</summary>   
  public static String[][] Seasons = 
  {
   new String[] { "Advent", "Commences on the first Sunday 4 weeks before Christmas."},
   new String[] { "Christmas Season", "12 days, between December 25 and January 6."},
   new String[] { "Epiphany", "Commences after the completion of the Christmas season, January 7; and ends the day prior to Ash Wednesday."},
   new String[] { "Ash Wednesday", "The last Wednesday in February"},
   new String[] { "Lent", "40 days before Easter Sunday."},
   new String[] { "Easter Sunday", "The Sunday before the last Sunday in April."},
   new String[] { "Pentecost", "The 50th day after Easter Sunday."}
  };

 }//ChurchCalendar Class. 
}//namespace WordEngineering.