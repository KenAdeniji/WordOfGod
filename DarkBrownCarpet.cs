using System;

namespace WordEngineering
{
 ///<summary>DarkBrownCarpet</summary>
 public class DarkBrownCarpet
 {
  /// <summary>The delimiter in character array format for the DarkBrownCarpet subset</summary>
  public static char[] DelimiterCharDarkBrownCarpetSubset = null;

  /// <summary>The delimiter string for the DarkBrownCarpet subset.</summary>
  public const string DelimiterStringDarkBrownCarpet = " ";

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main
  (
   String[] argv
  )
  {
   foreach( string argvCurrent in argv )
   {
    System.Console.WriteLine
    (
     "{0}: {1}",
     argvCurrent,
     UpstairsLowerBasement( argvCurrent )
    );
   }
  }

  ///<summary>RollNorthEast</summary>
  public static int RollNorthEast( string countPaul )
  {
   int darkBrownCarpet = 0;
   for ( int index = 0; index < countPaul.Length; ++index )
   {
    if ( countPaul[index] >= 65 && countPaul[index] <= 90 )
    {
     darkBrownCarpet += countPaul[index] - 64;
    }
    else if ( countPaul[index] >= 97 && countPaul[index] <= 122 )
    {
     darkBrownCarpet += countPaul[index] - 96;
    }
   }
   return ( darkBrownCarpet );
  }

  ///<summary>RollNorthEast</summary>
  public static int RollNorthEast( string[] countPaul )
  {
   return( RollNorthEast( String.Join(" ", countPaul) ) );
  }

  ///<summary>RoyalLeadership</summary>
  ///<remarks>
  /// 20051005
  /// System.Console.WriteLine("{0}",RoyalLeadership("Royal leadership"));
  /// System.Console.WriteLine("{0}",RoyalLeadership("0 to 15 minutes"));
  /// System.Console.WriteLine("{0}",RoyalLeadership("Zizou")); //Zenedine Zidane Zidane.fr
  /// System.Console.WriteLine("{0}",RoyalLeadership("Their is no regard for no expectation.")); //NorthEast
  /// Male in white shirt lurking from the equator West.
  /// System.Console.WriteLine("{0}",RoyalLeadership("Its called the set up screen of screen one."));
  ///</remarks>
  public static int RoyalLeadership( string zeroToFifteenMinutes )
  {
   return( ( ( ( RollNorthEast( zeroToFifteenMinutes ) % 26 ) * 60 / 26 ) ) );
  }

  ///<summary>UliJohnPaulineBeshay</summary>
  ///<remarks>
  /// 20051019
  /// System.Console.WriteLine("{0}",UliJohnPaulineBeshay("Do I sponsor my obedience?", 97));
  /// SharpDevelop. Smart &amp; Final Food Supplies Business Home OtisSpunkMeyer Muffins 1701 47269 www.SpunkMeyer.com 1-888-ASK-OTIS WILD BLUEBERRY NET WT 4 oz (113g) 0 9175 2 00100 1 San Leandro, CA 94577 Product of U.S.A. Conn License #03004 4T2267 The Smaller Faster Warehouse Store #435 www.smartandfinal.com SmartAdvantage 866-411-SMART 1 (510) 623-1183
  /// Purpose under utilization. 
  /// Blue sweat. I Develop.
  /// SELECT DATEDIFF( day, '20041102', '20051019' ) --351
  ///</remarks>
  public static int UliJohnPaulineBeshay( string countPaul, double princeNinetySevenPercent )
  {
   int index;
   int rollNorthEast = RollNorthEast( countPaul );
   double princeNinetySeven = princeNinetySevenPercent / 100;
   double uliJohnPaulineBeshay = 0;
   for( index = 0; index < countPaul.Length; ++index )
   {
    if ( countPaul[index] >= 65 && countPaul[index] <= 90 )
    {
     uliJohnPaulineBeshay += countPaul[index] - 64;
    }
    else if ( countPaul[index] >= 97 && countPaul[index] <= 122 )
    {
     uliJohnPaulineBeshay += countPaul[index] - 96;
    }
    if ( uliJohnPaulineBeshay / rollNorthEast >= princeNinetySeven ) { break; }
   }
   return (index);
  }
   
  ///<summary>UpstairsLowerBasement</summary>
  ///<remarks>
  /// Farah. How do the administrate the cost in marginalizing? If the size is lower than all the other sizes, get out.
  /// Radio Shack. Interior guidance.
  /// I had prior knowledge but no disadvantage. Ibo woman typewriter.
  /// Umuahia 20 miles. She should strength not trangression. Benue Middle belt. Sagamu 65.
  /// God I sought your presence not your opportunity. Governed, God I sought your presence not your opportunity.
  /// Behind. Books are non revisable items. Tim Lahye. Left Behind. Jerry Jenkins.
  /// Creative tense (lower and upper case 1..26). 
  /// Serviceable redeemable. Little bit. You felt for him, you did not spent in her.
  /// Punctually, I have to increase my dependable.
  /// Persuation. Tim Finn. Crowded House. Volleyball. Sleeve broken at left shoulder. Our potential are our most viable attraction.
  /// Case Corp. Reprensentation. Each cloud does not represent the above calling. Macquarie Bank.
  /// Each read is unreachable. Reid. Physics. CPCC. Compass.
  /// Akowe. Zenedine Zidane. The trendsetters are not the least.
  /// Should I quit, while assuming the rest.
  /// Its still the predominant set.
  /// It is likely that upon the completion of the essay, you will find the answer.
  /// Each time you look above, I Am underneath you. Marcus. Westpac.
  /// If my fingerprint does not support my footprint, where is my ancestor?
  ///</remarks>
  public static int UpstairsLowerBasement( string countPaul )
  {
   bool serviceableRedeemable;
   int countPaulSubsetIndexOf = -1;
   string countPaulUpper = countPaul.ToUpper();
   string[] countPaulSubset = countPaulUpper.Split( DelimiterCharDarkBrownCarpetSubset );
   int[] present = new int[countPaulSubset.Length];
   if ( countPaulSubset.Length > 1 )
   {
    serviceableRedeemable = false;
    present = new int[countPaulSubset.Length];
    for ( int countPaulPosition = 0; countPaulPosition < countPaulSubset[0].Length; ++countPaulPosition )
    {
     present = new int[countPaulSubset.Length];
     present[0] = countPaulPosition;
     serviceableRedeemable = true;
     for ( int countPaulSubsetIndex = 1; countPaulSubsetIndex < countPaulSubset.Length; ++countPaulSubsetIndex )
     {
      countPaulSubsetIndexOf = countPaulSubset[countPaulSubsetIndex].IndexOf( countPaulSubset[0][countPaulPosition] );
      if ( countPaulSubsetIndexOf > -1 ) 
      { 
       present[countPaulSubsetIndex] = countPaulSubsetIndexOf;
       continue;
      }
      else
      {
       serviceableRedeemable = false;
       break;
      }
     }
     if ( serviceableRedeemable == true )
     {
      for ( int countPaulSubsetIndex = 0; countPaulSubsetIndex < countPaulSubset.Length; ++countPaulSubsetIndex )
      {
       countPaulSubset[countPaulSubsetIndex] = countPaulSubset[countPaulSubsetIndex].Substring(0, present[countPaulSubsetIndex]) + 
                                               countPaulSubset[countPaulSubsetIndex].Substring(present[countPaulSubsetIndex] + 1);
      }
     }
    }
   }
   return ( RollNorthEast( countPaulSubset ) );
  }

  ///<summary>YellowPurpleBlouse</summary>
  ///<remarks>
  /// 20051019
  /// System.Console.WriteLine("{0}",YellowPurpleBlouse("Yellow purple blouse", 50));
  ///</remarks>YellowPurpleBlouse
  public static char YellowPurpleBlouse( string countPaul, double princeNinetySevenPercent )
  {
   int index;
   int rollNorthEast = RollNorthEast( countPaul );
   double clockwise = 0;
   double princeNinetySeven = princeNinetySevenPercent / 100;
   double yellowPurpleBlouse = 0;
   for( index = 0; index < countPaul.Length; ++index )
   {
    if ( countPaul[index] >= 65 && countPaul[index] <= 90 )
    {
     yellowPurpleBlouse += countPaul[index] - 64;
    }
    else if ( countPaul[index] >= 97 && countPaul[index] <= 122 )
    {
     yellowPurpleBlouse += countPaul[index] - 96;
    }
    clockwise = yellowPurpleBlouse / rollNorthEast;
    if ( clockwise >= princeNinetySeven ) { break; }
   }
   return( (char) ( countPaul[index] - Math.Round( ( clockwise - princeNinetySeven ) * rollNorthEast ) ) );
  }

  /// <summary>DarkBrownCarpet</summary>
  static DarkBrownCarpet()
  {
   DelimiterCharDarkBrownCarpetSubset = DelimiterStringDarkBrownCarpet.ToCharArray();
  }

 }
}