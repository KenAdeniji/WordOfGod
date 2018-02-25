using System;
using System.Text;

namespace WordEngineering
{
 /// <summary>Scripture Reference Text.</summary>
 /// <remarks>Scripture Reference Text</remarks>
 public class ScriptureReferenceText
 {
  private int     databaseColumnBookId          =  -1;
  private int     databaseColumnChapterId       =  -1;
  private int     databaseColumnResultSet       =  -1;
  private int     databaseColumnVerseId         =  -1;          
  private string  databaseColumnVerseText       =  null;

  /// <summary>The class constructor.</summary>
  public ScriptureReferenceText
  (
   int    databaseColumnResultSet,
   int    databaseColumnBookId,
   int    databaseColumnChapterId,
   int    databaseColumnVerseId,
   string databaseColumnVerseText
  ) 
  {
   this.databaseColumnResultSet  = databaseColumnResultSet;
   this.databaseColumnBookId     = databaseColumnBookId;    
   this.databaseColumnChapterId  = databaseColumnChapterId;        
   this.databaseColumnVerseId    = databaseColumnVerseId;            
   this.databaseColumnVerseText  = databaseColumnVerseText;                
  }

  ///<summary>Book Id.</summary>
  ///<value>1..66</value>
  public int DatabaseColumnBookId
  {
   get 
   {
    return databaseColumnBookId;
   }
  }//DatabaseColumnBookId

  ///<summary>Book Title.</summary>
  ///<value>Genesis..Revelation</value>
  public string DatabaseColumnBookTitle
  {
   get 
   {
    /*
    BibleBookTitle bibleBookTitle = new BibleBookTitle();
    return (string) bibleBookTitle[databaseColumnBookId-1];
    */
    /*
    return (string) ((new BibleBookTitle()[databaseColumnBookId-1]));
    */
    return ( BibleBookTitle.BookTitle( databaseColumnBookId ) );
   }
  }//DatabaseColumnBookTitle

  ///<summary>Book Chapter.</summary>
  ///<value>1..150</value>
  public int DatabaseColumnChapterId
  {
   get 
   {
    return databaseColumnChapterId;
   }
  }//DatabaseColumnChapterId

  ///<summary>Scripture Reference Count.</summary>
  ///<value>1..</value>
  public int DatabaseColumnResultSet 
  {
   get 
   {
    return databaseColumnResultSet;
   }
  }//DatabaseColumnResultSet     

  ///<summary>Book Verse.</summary>
  ///<value>1..176</value>
  public int DatabaseColumnVerseId
  {
   get 
   {
    return databaseColumnVerseId;
   }
  }//DatabaseColumnVerseId

  ///<summary>Verse Text.</summary>
  ///<value>In the beginning...</value>
  public string DatabaseColumnVerseText
  {
   get 
   {
    return databaseColumnVerseText;
   }
  }//DatabaseColumnVerseId
 }//ScriptureReferenceText Class. 
}//namespace WordEngineering