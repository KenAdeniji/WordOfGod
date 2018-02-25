using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WordEngineering
{
 ///<summary>Prime</summary>
 ///<remarks>
 /// Microsoft.com/mspress/books/5728.asp
 /// Developing Microsoft® ASP.NET Server Controls and Components  
 /// Author  Nikhil Kothari and Vandana Datye  
 /// Pages 752 
 /// Disk N/A  
 /// Level Int/Adv  
 /// Published 08/28/2002 
 /// ISBN 0-7356-1582-9 
 ///</remarks>
 [
  DefaultProperty("Number"),
  ToolboxData("<{0}:Prime Number=\"0\" runat=\"server\"></{0}:Prime>")
 ]
 public class Prime : WebControl
 {
  ///<summary>number</summary>
  public int number;
  
  ///<summary>Number</summary>
  public int Number
  {
   get
   {
   	return number;
   }
   set
   {
   	number = value;
   }
  }//public int Number
  
  ///<summary>RenderContents</summary>
  protected override void RenderContents( HtmlTextWriter writer )
  {
   int[] primes = Sieve.GetPrimes( Number );
   writer.Write("Primes less than or equal to:  ");
   writer.Write(Number);
   writer.Write("<br/>");
   for (int i=0; i<primes.Length; i++)
   {
   	writer.Write( primes[i] );
    writer.Write(" ");
   }//for (int i=0; i<primes.Length; i++)
   writer.Write("<br/>");
  }//public override void RenderContents( HtmlTextWriter writer )
 }//public class Prime : WebControl
}//namespace WordEngineering
