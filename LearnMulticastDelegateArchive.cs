using System;

namespace WordEngineering
{
 delegate void Del(string statement);
 public class LearnMulticastDelegate
 {
  public static void Hello(string statement)
  {
   System.Console.WriteLine("Hello delegate: {0}", statement);
  }
  public static void Bye(string statement)
  {
   System.Console.WriteLine("Bye delegate: {0}", statement);
  }
  public static void Main(string[] argv)
  {
   Del hello, bye, helloBye, helloNoBye;
   hello = Hello;
   bye = Bye;
   helloBye = hello + bye;
   helloNoBye = helloBye - bye;
   hello("hello");
   bye("bye");
   helloBye("helloBye");
   helloNoBye("helloNoBye");
  }
 }
}