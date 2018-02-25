namespace WordEngineering
{
 public enum Suit {Club=0, Diamond=1, Heart=2, Space=3}

 public class Card 
 { 
  public static void Main(string[] argv) 
  { 
   Suit suit = Suit.Club; 
   System.Console.WriteLine("Suit: {0}", suit); 
  } 
 }
}