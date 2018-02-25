using System;

/* http://www.jaggersoft.com/csharp_course/20_Delegates_files/frame.htm */
namespace WordEngineering
{
 delegate void Func(string s);
 
 sealed class Eg
 {
  public static void Main(string[] argv)
  {
   ForAll(argv, DelegateFunction);
  }
  
  public static void ForAll(string[] argv, Func call)
  {
   if (call != null)
   {
    foreach(string arg in argv)
    {
     call(arg);
    }
   }	 
  }
  
  public static void DelegateFunction(string argv)
  {
   System.Console.WriteLine("{0}", argv);
  }
 } 
}