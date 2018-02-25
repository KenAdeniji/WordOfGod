using System;

namespace WordEngineering
{
 delegate void Del(string statement);

 public class TrialMulticastDelegate
 {
  public static void Hello(string statement)
  {
   System.Console.WriteLine("{0} Hello", statement);
  }
  public static void Bye(string statement)
  {
   System.Console.WriteLine("{0} Bye", statement);
  }
  public static void Main(string[] argv)
  {
   Del hello, bye, helloBye, helloNoBye;
   hello = Hello;
   bye = Bye;
   helloBye = hello + bye;
   helloNoBye = helloBye - bye;
   hello("Hello delegate");
   bye("Bye delegate");
   helloBye("HelloBye delegate");
   helloNoBye("HelloNoBye delegate");
  }
 }
}