using System;
using System.Text;

public class ThisIsAninterview
{
 public static void Main(string[] argv)
 {
  int index = -1;
  int len = -1;
  StringBuilder sb;

  foreach (String arg in argv)
  {
   len = arg.Length;
   sb = new StringBuilder();
   for(index = len - 1; index >= 0; --index)
   {
    if (arg[index] == ' ')
    {
     System.Console.Write("{0} ", sb);
     sb = new StringBuilder();
    }
    else
    {
     sb.Insert(0, arg[index]);
    }
   }
   System.Console.Write("{0}", sb);
  }
 } 
}
