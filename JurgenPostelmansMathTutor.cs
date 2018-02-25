using System; 
using System.Data; 
using System.Data.Sql; 
using System.Data.SqlTypes; 

namespace WordEngineering
{
 public class JurgenPostelmansMathTutor
 {
  public static SqlInt32 AddNumbers(SqlInt32 i, SqlInt32 j)
  {
   return i + j;
  }
 
  public static int SubtractNumbers(int i, int j)
  {
   return i - j;
  }

  public static SqlInt32 IncrementBy(SqlInt32 by, ref SqlInt32 number)
  {
   int retValue = 0;
 
   try
   {
    number += by;
   }
   catch (Exception ex)
   {
    retValue = 1;
   }
   return retValue;
  }
 }
} 