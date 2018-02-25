/*
 csc /out:bin/ScriptureReferenceAlphabetSequence.dll /target:library ScriptureReferenceAlphabetSequence.cs
*/

using System;
using System.Text;

namespace WordEngineering
{
 /// <summary>Scripture Reference Alphabet Sequence.</summary>
 /// <remarks>Scripture Reference Alphabet Sequence.</remarks>
 public class ScriptureReferenceAlphabetSequence
 {
 
  private int           alphabetSequence                    = -1;   
  private int           sequenceOrderId                     = -1;        
  private int           theWordId                           = -1;

  private string        chapterForward                      = null;  
  private string        chapterBackward                     = null;    
  private string        commentary                          = null;
  private string        verseBackward                       = null; 
  private string        verseForward                        = null; 
  private string        word                                = null;

  private string        scriptureReferenceAssociates        = null;
  private string        scriptureReferenceChapterForward    = null;
  private string        scriptureReferenceChapterBackward   = null;
  private string        scriptureReferenceCurrent           = null;
  private string        scriptureReferenceVerseBackward     = null;      
  private string        scriptureReferenceVerseForward      = null;

  /// <summary>The class constructor.</summary>  
  public ScriptureReferenceAlphabetSequence
  (
   string        word,
   string        scriptureReferenceAssociates,
   int           alphabetSequence,
   string        scriptureReferenceVerseForward,
   string        scriptureReferenceChapterForward,
   string        scriptureReferenceChapterBackward,
   string        scriptureReferenceVerseBackward,
   string        scriptureReferenceCurrent,
   string        verseForward,
   string        chapterForward,
   string        chapterBackward,
   string        verseBackward
  ) 
  {
   this.alphabetSequence = alphabetSequence;
   this.scriptureReferenceAssociates = scriptureReferenceAssociates;
   this.word = word;
   this.scriptureReferenceVerseForward = scriptureReferenceVerseForward;
   this.scriptureReferenceChapterForward = scriptureReferenceChapterForward;   
   this.scriptureReferenceChapterBackward = scriptureReferenceChapterBackward;      
   this.scriptureReferenceVerseBackward = scriptureReferenceVerseBackward;   
   this.scriptureReferenceCurrent = scriptureReferenceCurrent;
   this.verseForward = verseForward;
   this.chapterForward = chapterForward;   
   this.chapterBackward = chapterBackward;
   this.verseBackward = verseBackward;   
  }//ScriptureReferenceAlphabetSequence

  /// <summary>The class constructor.</summary>  
  public ScriptureReferenceAlphabetSequence
  (
   string        word,
   string        scriptureReferenceAssociates,
   int           alphabetSequence,
   string        scriptureReferenceVerseForward,
   string        scriptureReferenceChapterForward,
   string        scriptureReferenceChapterBackward,
   string        scriptureReferenceVerseBackward,
   string        scriptureReferenceCurrent,
   string        verseForward,
   string        chapterForward,
   string        chapterBackward,
   string        verseBackward,
   int           sequenceOrderId
  ) 
  {
   this.alphabetSequence = alphabetSequence;
   this.scriptureReferenceAssociates = scriptureReferenceAssociates;
   this.word = word;
   this.scriptureReferenceVerseForward = scriptureReferenceVerseForward;
   this.scriptureReferenceChapterForward = scriptureReferenceChapterForward;   
   this.scriptureReferenceChapterBackward = scriptureReferenceChapterBackward;      
   this.scriptureReferenceVerseBackward = scriptureReferenceVerseBackward;   
   this.scriptureReferenceCurrent = scriptureReferenceCurrent;
   this.verseForward = verseForward;
   this.chapterForward = chapterForward;   
   this.chapterBackward = chapterBackward;
   this.verseBackward = verseBackward;   
   this.sequenceOrderId = sequenceOrderId;
  }//ScriptureReferenceAlphabetSequence

  /// <summary>The class constructor.</summary>  
  public ScriptureReferenceAlphabetSequence
  (
   string        word,
   string        scriptureReferenceAssociates,
   int           alphabetSequence,
   string        scriptureReferenceVerseForward,
   string        scriptureReferenceChapterForward,
   string        scriptureReferenceChapterBackward,
   string        scriptureReferenceVerseBackward,
   string        scriptureReferenceCurrent,
   string        verseForward,
   string        chapterForward,
   string        chapterBackward,
   string        verseBackward,
   string        commentary,
   int           theWordId,
   int           sequenceOrderId
  ) 
  {
   this.alphabetSequence = alphabetSequence;
   this.scriptureReferenceAssociates = scriptureReferenceAssociates;
   this.word = word;
   this.scriptureReferenceVerseForward = scriptureReferenceVerseForward;
   this.scriptureReferenceChapterForward = scriptureReferenceChapterForward;   
   this.scriptureReferenceChapterBackward = scriptureReferenceChapterBackward;      
   this.scriptureReferenceVerseBackward = scriptureReferenceVerseBackward;   
   this.scriptureReferenceCurrent = scriptureReferenceCurrent;
   this.verseForward = verseForward;
   this.chapterForward = chapterForward;   
   this.chapterBackward = chapterBackward;
   this.verseBackward = verseBackward;
   this.commentary    = commentary;
   this.sequenceOrderId = sequenceOrderId;   
   this.theWordId = theWordId;

  }//ScriptureReferenceAlphabetSequence

  ///<summary>AlphabetSequence property</summary>
  ///<value>The alphabet sequence.</value>
  public int AlphabetSequence
  {
   get 
   {
    return alphabetSequence;
   }
   set 
   {
    alphabetSequence = value;
   }
  }//AlphabetSequence

  ///<summary>Chapter Backward property</summary>
  ///<value>The chapter backward.</value>
  public string ChapterBackward
  {
   get 
   {
    return chapterBackward;
   }
   set 
   {
    chapterBackward = value;
   }
  }//ChapterBackward

  ///<summary>Chapter Forward property</summary>
  ///<value>The chapter forward.</value>
  public string ChapterForward
  {
   get 
   {
    return chapterForward;
   }
   set 
   {
    chapterForward = value;
   }
  }//ChapterForward

  ///<summary>Scripture Reference Associates property</summary>
  ///<value>The scripture reference associates.</value>
  public string ScriptureReferenceAssociates
  {
   get 
   {
    return scriptureReferenceAssociates;
   }
   set 
   {
    scriptureReferenceAssociates = value;
   }
  }//ScriptureReferenceAssociates

  ///<summary>Scripture Reference Verse Forward property</summary>
  ///<value>The scripture reference verse forward.</value>
  public string ScriptureReferenceVerseForward
  {
   get 
   {
    return scriptureReferenceVerseForward;
   }
   set 
   {
    scriptureReferenceVerseForward = value;
   }
  }//ScriptureReferenceVerseForward

  ///<summary>Scripture Reference Chapter Forward property</summary>
  ///<value>The scripture reference chapter forward.</value>
  public string ScriptureReferenceChapterForward
  {
   get 
   {
    return scriptureReferenceChapterForward;
   }
   set 
   {
    scriptureReferenceChapterForward = value;
   }
  }//ScriptureReferenceChapterForward

  ///<summary>Scripture Reference Chapter Backward property</summary>
  ///<value>The scripture reference chapter backward.</value>
  public string ScriptureReferenceChapterBackward
  {
   get 
   {
    return scriptureReferenceChapterBackward;
   }
   set 
   {
    scriptureReferenceChapterBackward = value;
   }
  }//ScriptureReferenceChapterBackward

  ///<summary>Scripture Reference Verse Forward property</summary>
  ///<value>The scripture reference verse forward.</value>
  public string ScriptureReferenceVerseBackward
  {
   get 
   {
    return scriptureReferenceVerseBackward;
   }
   set 
   {
    scriptureReferenceVerseBackward = value;
   }
  }//ScriptureReferenceVerseBackward

  ///<summary>Scripture Reference Current</summary>
  ///<value>The scripture reference current.</value>
  public string ScriptureReferenceCurrent
  {
   get 
   {
    return scriptureReferenceCurrent;
   }
   set 
   {
    scriptureReferenceCurrent = value;
   }//set
  }//ScriptureReferenceCurrent

  /*
  ///<summary>SequenceOrderIndex.</summary>
  ///<value>The Sequence Order Id.</value>
  public int SequenceOrderId
  {
   get 
   {
    return sequenceOrderId;
   }
   set 
   {
    sequenceOrderId = value;
   }//set
  }//SequenceOrderId
  */

  ///<summary>Scripture Reference Verse Backward property</summary>
  ///<value>The scripture reference verse backward.</value>
  public string VerseBackward
  {
   get 
   {
    return verseBackward;
   }
   set 
   {
    verseBackward = value;
   }
  }//verseBackward

  ///<summary>Verse Forward property</summary>
  ///<value>The verse forward.</value>
  public string VerseForward
  {
   get 
   {
    return verseForward;
   }
   set 
   {
    verseForward = value;
   }
  }//VerseForward

  ///<summary>Word property</summary>
  ///<value>The word.</value>
  public string Word
  {
   get 
   {
    return word;
   }
   set 
   {
    word = value;
   }
  }//Word

  ///<summary>SequenceOrderId property</summary>
  ///<value>The SequenceOrderId.</value>
  public int SequenceOrderId
  {
   get 
   {
    return sequenceOrderId;
   }
   set 
   {
    sequenceOrderId = value;
   }
  }//sequenceOrderId

  /// <summary>The string representation.</summary>
  public override string ToString()
  {
   try
   {
    //return scriptureReferenceCurrent.ToString();
    return String.Format
    (
     "SequenceOrderId: {0} | Word: {1} | Alphabet Sequence: {2} | Scripture Reference Verse Forward: {3} | Scripture Reference Chapter Forward: {4} | Scripture Reference Chapter Backward: {5} | Scripture Reference Verse Backward: {6} |Scripture Reference: {7} | Verse Forward {8} | Chapter Forward {9} | Chapter Backward {10} | Verse Backward {11}", 
     sequenceOrderId,
     word,
     alphabetSequence,
     scriptureReferenceVerseForward,
     scriptureReferenceChapterForward,
     scriptureReferenceChapterBackward,
     scriptureReferenceVerseBackward,
     scriptureReferenceCurrent,
     verseForward,
     chapterForward,
     chapterBackward,
     verseBackward
    );
   }
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception);
    return null;
   }
  }//ToString()

 }//ScriptureReferenceAlphabetSequence Class. 

}//namespace WordEngineering
  