using System;
using System.Collections;

namespace WordEngineering
{
 ///<summary>Sieve</summary>
 ///<remarks>
 /// Microsoft.com/mspress/books/5728.asp
 /// Developing Microsoft® ASP.NET Server Controls and Components  
 /// Author  Nikhil Kothari and Vandana Datye  
 /// Pages 752 
 /// Disk N/A  
 /// Level Int/Adv  
 /// Published 08/28/2002 
 /// ISBN 0-7356-1582-9 
 /// Sieve is a utility class that uses the sieve of Eratosthenes
 /// algorithm to compute primes less than or equal to
 /// a given positive integer.
 ///</remarks>
 internal sealed class Sieve 
 {
  private Sieve() 
  {
  }

  ///<summary>GetPrimes</summary>
  public static int[] GetPrimes( int n )
  {     
   // Use an array of n+1 bits to correspond to
   // the numbers from 0 to n. Initially, set all the bits to true.
   // The goal of the computation is to cycle through
   // the bit array using the sieve of Eratosthenes algorithm
   // and to set the bits corresponding to nonprimes to false.
   // The remaining true bits represent primes.             
   BitArray flags = new BitArray(n+1, true); 
   for ( int i=2; i <= (int)Math.Sqrt(n); i++)
   {         
    if (flags[i])
    {
     for (int j = i; j*i <= n; j++) 
     {
      flags[i*j]= false;                  
     }
    }
   }

   // Count the number of primes <= n.
   int count = 0;    
   for (int i=2; i <= n; i++) 
   {         
    if (flags[i]) count++;
   }
            
   // Create an int array to store the primes.
   int[] primes = new int[count];

   // Check bit flags and populate primes 
   // array with numbers corresponding to  
   // true bits.
   for ( int i=2, j = 0; j < count; i++ )
   {       
    if (flags[i]) primes[j++] = i;
   }//for ( int i=2, j = 0; j < count; i++ )
   
   return primes;
  }//public static int[] GetPrimes( int n )  
 }//internal sealed class Sieve
}//WordEngineering
