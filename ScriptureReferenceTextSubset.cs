using System;
using System.Text;

namespace WordEngineering
{
 /// <summary>Scripture Reference Text Subset.</summary>
 /// <remarks>Scripture Reference Text Subset.</remarks>
 public class ScriptureReferenceTextSubset
 {
  private ScriptureReferenceSubset scriptureReference = null;
  private StringBuilder            scriptureText      = null;

  /// <summary>The class constructor.</summary>
  public ScriptureReferenceTextSubset() 
  :this
  (		
   new ScriptureReferenceSubset(),
   new StringBuilder()
  )
  {}

  /// <summary>The class constructor.</summary>
  public ScriptureReferenceTextSubset
  (
   ScriptureReferenceSubset scriptureReference
  ) 
  :this
  (		
   scriptureReference,
   new StringBuilder()
  )
  {}

  /// <summary>The class constructor.</summary>
  public ScriptureReferenceTextSubset
  (
   ScriptureReferenceSubset scriptureReference,
   StringBuilder            scriptureText
  ) 
  {
   this.scriptureReference = scriptureReference;
   this.scriptureText      = scriptureText;
  }

  ///<summary>ScriptureReference property.</summary>
  ///<value>Genesis 1.</value>
  public ScriptureReferenceSubset ScriptureReference
  {
   get 
   {
    return scriptureReference;
   }
   set
   {
    this.scriptureReference = scriptureReference;
   }
  }//ScriptureReference

  ///<summary>ScriptureText property.</summary>
  ///<value>In the beginning...</value>
  public StringBuilder ScriptureText
  {
   get 
   {
    return scriptureText;
   }
   set
   {
    this.scriptureText = value;
   }
  }//ScriptureReferenceText
   
  /// <summary>Append.</summary>
  /// <param name="verseText">Append the scriptural verse text.</param>
  public void Append( string verseText )
  {
   this.scriptureText.Append( verseText );
   this.scriptureText.Append( "  " );
  }//Append

  /// <summary>ToString</summary>
  public override string ToString()
  {
   return scriptureText.ToString();
  }
 }//ScriptureReferenceTextSubset Class. 
}//namespace WordEngineering
