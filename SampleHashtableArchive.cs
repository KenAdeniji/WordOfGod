using System;
using System.Collections;

namespace WordEngineering
{
 public class SampleHashtable
 {
  public static int containKey = 42;
  public static Hashtable hashtable;
  public static void Main(string[] argv)
  {
   hashtable = new Hashtable();
   hashtable.Add(40, "Matthew");
   hashtable.Add(41, "Mark");
   hashtable.Add(42, "Luke");
   hashtable.Add(43, "John");
   if ( hashtable.ContainsKey(containKey) )
   {
    System.Console.WriteLine("Key: {0} | Value: {1}", containKey, hashtable[containKey]);
   }
   else
   {
    System.Console.WriteLine("Key: {0} not found");   
   }
   foreach(int key in hashtable.Keys)
   {
    System.Console.WriteLine("Key: {0} | Value: {1}", key, hashtable[key]);   
   }
  }
 }
}