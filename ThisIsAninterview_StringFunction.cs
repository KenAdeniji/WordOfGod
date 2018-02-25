using System;
public class ThisIsAninterview
{
 public static void Main(string[] argv)
 {
  int lastIndexOf = -1;
  String currentWord;
  String currentSentence;

  foreach (String arg in argv)
  {
   currentSentence = arg;
   for (;;)
   {
    lastIndexOf = currentSentence.LastIndexOf(' ');
    currentWord = currentSentence.Substring(lastIndexOf + 1);
    System.Console.Write("{0} ", currentWord);
    if ( lastIndexOf != -1)
    {
     currentSentence = currentSentence.Substring(0, lastIndexOf);
    }
    else { break; }
    }
   }
  }
}