using System;

namespace WordEngineering
{
 delegate void Del(string statement);
 public class TempDelegate
 {
  static void Hello(string statement)
  {
   System.Console.WriteLine("{0} Hello", statement);
  }
  static void Bye(string statement)
  {
   System.Console.WriteLine("{0} Bye", statement);
  }
  static void Main(string[] argv)
  {
   Del hello, bye, helloBye, helloNoBye;
   hello = Hello;
   bye = Bye;
   helloBye = hello + bye;
   helloNoBye = helloBye - bye;
   hello("delegate hello");
   bye("delegate bye");
   helloBye("delegate helloBye");
   helloNoBye("delegate helloNoBye");
  }
 }
}