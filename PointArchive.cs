using System;

namespace WordEngineering
{
 ///<summary>Point</summary>
 public class Point
 {
  ///<summary>x</summary>
  public int x;

  ///<summary>y</summary>
  public int y;

  ///<summary>Constructor</summary>  
  Point(int x, int y)
  {
   this.x = x;
   this.y = y;   
  }

  public static void Main(string[] argv)
  {
   Point p1 = new Point(90, 45);
   Point p2 = new Point(48, 24);
   System.Console.WriteLine(p1+p2);
   System.Console.WriteLine(p1-p2);
  }

  public override string ToString()
  {
   return(x.ToString() + ',' + y.ToString());
  }

  public static Point operator + ( Point p1, Point p2 )
  {
   return ( new Point(p1.x + p2.x, p1.y + p2.y) );
  }

  public static Point operator - ( Point p1, Point p2 )
  {
   return ( new Point(p1.x - p2.x, p1.y - p2.y) );
  }

  public override bool Equals(object o)
  {
   if ( this.x == ((Point) o).x && this.y == ((Point) o).y )
   { return true; } else { return false; }
  }
  
  public static bool operator == (Point p1, Point p2)
  {
   return p1.Equals(p2);
  }
 
  public static bool operator != (Point p1, Point p2)
  {
   return !p1.Equals(p2);
  }
  
  public override int GetHashCode()
  {
   return this.ToString().GetHashCode();
  }
 }
}