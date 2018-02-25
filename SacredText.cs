using System;
using System.Collections;

namespace WordEngineering
{
 ///<summary>SacredText</summary>
 ///<remarks>http://support.microsoft.com/default.aspx?scid=kb;en-us;309357 How to work with the HashTable collection in Visual C#</remarks>
 public class SacredText
 {
  ///<summary>title</summary>
  public static Hashtable sacredText;

  ///<summary>title</summary>
  public string title;

  ///<summary>scriptureReference</summary>
  public string scriptureReference;

  ///<summary>Constructor</summary>
  public SacredText(string title, string scriptureReference)
  {
   this.title = title;
   this.scriptureReference = scriptureReference;
  }

  ///<summary>ToString</summary> 
  ///<remarks>System.Console.WriteLine(sacredText["Priestly Benediction"]);</remarks>
  public override string ToString()
  {
   return title + " (" + scriptureReference + ")";
  }

  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of command line arguments</param>
  public static void Main
  (
   String[] argv
  )
  {
   IDictionaryEnumerator enumerator;
   
   System.Console.WriteLine(sacredText["Priestly Benediction"]);
   
   enumerator = sacredText.GetEnumerator();
   while ( enumerator.MoveNext() )
   {
    System.Console.WriteLine(enumerator.Value.ToString());
   }
   
   foreach(object key in sacredText.Keys)
   {
    System.Console.WriteLine(key);
   }

   foreach(object value in sacredText.Values)
   {
    System.Console.WriteLine(value);
   }
  }

  static SacredText()
  {
   sacredText = new Hashtable();
   sacredText.Add
   (
    "Godesh Godashin Holy of Holies", 
    new SacredText
    (
     "Godesh Godashin Holy of Holies", 
     "Isaiah 52:13-15, Isaiah 53:1-12"
    )
   );

   sacredText.Add
   (
    "Leper's Anointing", 
    new SacredText
    (
     "Leper's Anointing", 
     "Leviticus 14"
    )
   );

   sacredText.Add
   (
    "Priestly Benediction", 
    new SacredText
    (
     "Priestly Benediction", 
     "Numbers 6:24-26"
    )
   );

   sacredText.Add
   (
    "Sabbatical Year", 
    new SacredText
    (
     "Sabbatical Year", 
     "Leviticus 25:22, Leviticus 26, Deuteronomy 15, Exodus 23"
    )
   );

   sacredText.Add
   (
    "Shema", 
    new SacredText
    (
     "Shema", 
     "Deuteronomy 6:4-9"
    )
   );

   sacredText.Add
   (
    "Shepherd's Psalm", 
    new SacredText
    (
     "Shepherd's Psalm", 
     "Psalm 23"
    )
   );

   sacredText.Add
   (
    "The Seven Penitential Psalms", 
    new SacredText
    (
     "The Seven Penitential Psalms", 
     "Psalm 6, Psalm 32, Psalm 38, Psalm 51, Psalm 102, Psalm 130, Psalm 143"
    )
   );

   sacredText.Add
   (
    "Triumphal Entry", 
    new SacredText
    (
     "Triumphal Entry", 
     "Matthew 21, Mark 11, Luke 19, John 12"
    )
   );
   
  }	
 }
}