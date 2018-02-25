using System;
using System.Collections;
using System.Text;
using System.Web;

namespace WordEngineering
{

 /// <summary>Scripture Reference Book, Chapter, Verse Pre, Post.</summary>
 public class ScriptureReferenceBookChapterVersePrePost
 {

  /// <summary>The column name for the bible book Id.</summary>
  public const string ColumnNameBookId = "bookId";

  /// <summary>The column name for the bible chapter Id.</summary>
  public const string ColumnNameChapterId = "chapterId";

  /// <summary>The column name for the bible verse Id.</summary>
  public const string ColumnNameVerseId = "verseId";

  /// <summary>The scripture reference contains an error.</summary>
  public const int SonInLawError = -1;

  /// <summary>The scripture reference: book title pre and chapter pre.</summary>
  public const int SonInLawPreBookTitlePreChapter = 0;

  /// <summary>The scripture reference: book title pre, chapter pre, verse pre.</summary>
  public const int SonInLawPreBookTitlePreChapterPreVerse = 1;

  /// <summary>The scripture reference: book title pre, chapter pre, verse pre, verse post.</summary>
  public const int SonInLawPreBookTitlePreChapterPreVersePostVerse = 2;

  /// <summary>The scripture reference: book title pre, chapter pre, verse pre, chapter post, verse post.</summary>
  public const int SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse = 3;

  /// <summary>The scripture reference: book title pre, chapter pre, verse pre, book title post, chapter post, verse post.</summary>
  public const int SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse = 4;

  /// <summary>The SQL And Clause</summary>
  public const string SQLAnd = " AND ";

  /// <summary>The SQL And Clause</summary>
  public const string SQLBetween = " BETWEEN ";

  /// <summary>The SQL Or Clause</summary>
  public const string SQLOr = " OR ";

  /// <summary>The URI Crosswalk delimiter between the book, chapter verse, pre and post.</summary>
  public const string URICrosswalkDelimiterBookChapterVersePrePost = "%2C+";

  /// <summary>The URI Crosswalk delimiter between the book title and chapter.</summary>
  public const char URICrosswalkDelimiterBookTitleChapter = '+';

  /// <summary>The URI Crosswalk delimiter between the chapter and verse.</summary>
  public const string URICrosswalkDelimiterChapterVerse = "%3A";

  /// <summary>The URI Crosswalk delimiter between the pre and the post.</summary>
  public const char URICrosswalkDelimiterPrePost = '-';

  /// <summary>The URI Crosswalk pre.</summary>
  public const string URICrosswalkPre = "http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=";

  /// <summary>The URI Crosswalk post.</summary>
  public const string URICrosswalkPost = "&section=0&version=nkj&language=en";

  /// <summary>The book title, pre.</summary>
  private string preBookTitle;

  /// <summary>The book title, post.</summary>
  private string postBookTitle;

  /// <summary>The chapter, pre.</summary>
  private int preChapter;

  /// <summary>The chapter, post.</summary>
  private int postChapter;

  /// <summary>The verse, pre.</summary>
  private int preVerse;

  /// <summary>The verse, post.</summary>
  private int postVerse;

  /// <summary>The son-in-law.</summary>
  private int sonInLaw = -1;

  /// <summary>The class constructor.</summary>
  public ScriptureReferenceBookChapterVersePrePost
  (
   string[] scriptureReferenceArray
  ) 
  :this
  (
   scriptureReferenceArray[ScriptureReference.ScriptureReferenceBookPre],
   scriptureReferenceArray[ScriptureReference.ScriptureReferenceChapterPre],
   scriptureReferenceArray[ScriptureReference.ScriptureReferenceVersePre],
   scriptureReferenceArray[ScriptureReference.ScriptureReferenceBookPost],
   scriptureReferenceArray[ScriptureReference.ScriptureReferenceChapterPost],
   scriptureReferenceArray[ScriptureReference.ScriptureReferenceVersePost]
  )
  {}
  
  /// <summary>The class constructor.</summary>
  public ScriptureReferenceBookChapterVersePrePost
  (
   string  preBookTitle,
   string  preChapter,
   string  preVerse,
   string  postBookTitle,
   string  postChapter,
   string  postVerse   
  ) 
  {
   this.preBookTitle  = preBookTitle;
   this.preChapter    = System.Convert.ToInt16( preChapter );
   this.preVerse      = System.Convert.ToInt16( preVerse );
   this.postBookTitle = postBookTitle;
   this.postChapter   = System.Convert.ToInt16( postChapter );
   this.postVerse     = System.Convert.ToInt16( postVerse );
   if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle == null && postChapter == null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapter;
   }//if ( bookTitle != null && preChapter != null && preVerse == null && postBookTitle == null && postChapter == null && postVerse == null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter == null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVerse;
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter == null && postVerse == null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter == null && postVerse != null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVersePostVerse;
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter == null && postVerse != null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter != null && postVerse != null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse;
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter != null && postVerse != null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle != null && postChapter != null && postVerse != null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse;
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle != null && postChapter != null && postVerse != null )
   else
   {
    sonInLaw = SonInLawError;
   } 	
  }//ScriptureReferenceBookChapterVersePrePost

  ///<summary>BookTitlePre property</summary>
  ///<value>A value tag is used to describe the property value</value>
  public string BookTitlePre
  {
   get 
   {
    return (preBookTitle);
   }//get
  }//public string BookTitlePre

  ///<summary>BookTitlePost property</summary>
  ///<value>A value tag is used to describe the property value</value>
  public string BookTitlePost
  {
   get 
   {
    return (postBookTitle);
   }//get
  }//public string BookTitlePre

  ///<summary>ChapterPre property</summary>
  ///<value>A value tag is used to describe the property value</value>
  public int ChapterPre
  {
   get 
   {
    return (preChapter);
   }//get
  }//public int ChapterPre

  ///<summary>ChapterPost property</summary>
  ///<value>A value tag is used to describe the property value</value>
  public int ChapterPost
  {
   get 
   {
    return (postChapter);
   }//get
  }//public int ChapterPost

  ///<summary>VersePre property</summary>
  ///<value>A value tag is used to describe the property value</value>
  public int VersePre
  {
   get 
   {
    return (preVerse);
   }//get
  }//public int VersePre

  ///<summary>VersePost property</summary>
  ///<value>A value tag is used to describe the property value</value>
  public int VersePost
  {
   get 
   {
    return (postVerse);
   }//get
  }//public int VersePost

  ///<summary>SonInLaw property</summary>
  ///<value>A value tag is used to describe the property value</value>
  public int SonInLaw
  {
   get 
   {
    return (sonInLaw);
   }//get
  }//public int SonInLaw
  
  /// <summary>The string representation.</summary>
  public override string ToString()
  {
   StringBuilder sb = new StringBuilder( preBookTitle );
   sb.Append(' ');
   sb.Append( preChapter );
      
   switch ( sonInLaw )
   {
    case SonInLawPreBookTitlePreChapter:
     break;

    case SonInLawPreBookTitlePreChapterPreVerse:
     sb.Append(':');
     sb.Append( preVerse );     
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostVerse:
     sb.Append(':');
     sb.Append( preVerse );     
     sb.Append('-');
     sb.Append( postVerse );
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse:
     sb.Append(':');
     sb.Append( preVerse );
     sb.Append('-');
     sb.Append( postChapter );
     sb.Append(':');
     sb.Append( postVerse );
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse:
     sb.Append(':');
     sb.Append( preVerse );
     sb.Append('-');
     sb.Append( preBookTitle );
     sb.Append(' ');     
     sb.Append( postChapter );
     sb.Append(':');
     sb.Append( postVerse );
     break;
     
    default:
     sb = new StringBuilder();
     break; 
         
   }//switch ( sonInLaw )
   	
   return sb.ToString();
   
  }//public static string ToString()	

  /// <summary>The URI Crosswalk HTML.</summary>
  public static StringBuilder URICrosswalkHtml
  (
   ScriptureReferenceBookChapterVersePrePost scriptureReferenceBookChapterVersePrePost
  )
  {
   StringBuilder sb = new StringBuilder( scriptureReferenceBookChapterVersePrePost.preBookTitle );
   sb.Append( URICrosswalkDelimiterBookTitleChapter );
   sb.Append( scriptureReferenceBookChapterVersePrePost.preChapter );
      
   switch ( scriptureReferenceBookChapterVersePrePost.sonInLaw )
   {
    case SonInLawPreBookTitlePreChapter:
     break;

    case SonInLawPreBookTitlePreChapterPreVerse:
     sb.Append( URICrosswalkDelimiterChapterVerse );
     sb.Append( scriptureReferenceBookChapterVersePrePost.preVerse );     
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostVerse:
     sb.Append( URICrosswalkDelimiterChapterVerse );
     sb.Append( scriptureReferenceBookChapterVersePrePost.preVerse );     
     sb.Append( URICrosswalkDelimiterPrePost );
     sb.Append( scriptureReferenceBookChapterVersePrePost.postVerse );
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse:
     sb.Append( URICrosswalkDelimiterChapterVerse );
     sb.Append( scriptureReferenceBookChapterVersePrePost.preVerse );     
     sb.Append( URICrosswalkDelimiterPrePost );
     sb.Append( scriptureReferenceBookChapterVersePrePost.postChapter );
     sb.Append( URICrosswalkDelimiterChapterVerse );
     sb.Append( scriptureReferenceBookChapterVersePrePost.postVerse );
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse:
     sb.Append( URICrosswalkDelimiterChapterVerse );
     sb.Append( scriptureReferenceBookChapterVersePrePost.preVerse );     
     sb.Append( URICrosswalkDelimiterPrePost );
     sb.Append( scriptureReferenceBookChapterVersePrePost.postBookTitle );
     sb.Append( URICrosswalkDelimiterBookTitleChapter );
     sb.Append( scriptureReferenceBookChapterVersePrePost.postChapter );
     sb.Append( URICrosswalkDelimiterChapterVerse );
     sb.Append( scriptureReferenceBookChapterVersePrePost.postVerse );
     break;
     
    default:
     sb = new StringBuilder();
     break; 
         
   }//switch ( sonInLaw )
   	
   return ( sb );
   
  }//public static StringBuilder URICrosswalkHtml( ScriptureReferenceBookChapterVersePrePost scriptureReferenceBookChapterVersePrePost )

  /// <summary>The URI Crosswalk HTML.</summary>
  public static StringBuilder URICrosswalkHtml
  (
   ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost
  )
  {
   int scriptureReferenceBookChapterVersePrePostCount; 
   int scriptureReferenceBookChapterVersePrePostTotal = scriptureReferenceBookChapterVersePrePost.Length;
   StringBuilder sb = new StringBuilder( URICrosswalkPre );
   for 
   ( 
    scriptureReferenceBookChapterVersePrePostCount = 0; 
    scriptureReferenceBookChapterVersePrePostCount < scriptureReferenceBookChapterVersePrePostTotal;
    ++scriptureReferenceBookChapterVersePrePostCount
   )
   {
    sb.Append( URICrosswalkHtml( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterVersePrePostCount] ) );	
    if ( scriptureReferenceBookChapterVersePrePostCount + 1 < scriptureReferenceBookChapterVersePrePostTotal )
    {
     sb.Append( URICrosswalkDelimiterBookChapterVersePrePost );	
    }//if ( scriptureReferenceBookChapterVersePrePostCount + 1 < scriptureReferenceBookChapterVersePrePostTotal )    	
   }//for ( scriptureReferenceBookChapterVersePrePostCount = 0; scriptureReferenceBookChapterVersePrePostCount < scriptureReferenceBookChapterVersePrePostTotal; ++scriptureReferenceBookChapterVersePrePostCount );
   sb.Append( URICrosswalkPost );
   sb.Replace(' ', '+');
   return ( sb );  
  }//public static string URICrosswalkHtml( ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost )

  /// <summary>The URI Crosswalk XML.</summary>
  public static StringBuilder URICrosswalkXml
  (
   ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost
  )
  {
   StringBuilder sb = new StringBuilder( (URICrosswalkHtml(scriptureReferenceBookChapterVersePrePost)).ToString() );
   sb.Replace("&", "&amp;");
   return ( sb );  
  }//public static string URICrosswalkHtml( ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost )

  /// <summary>The URI Crosswalk XML.</summary>
  public static void SQLStatementWhere
  (
   ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost
   StringBuilder                               sqlStatementWhere
  )
  {
   int           preBibleBookId                                 = -1;
   int           postBibleBookId                                = -1;   
   int           scriptureReferenceBookChapterVersePrePostCount = -1;
   int           scriptureReferenceBookChapterVersePrePostTotal = scriptureReferenceBookChapterVersePrePost.Length;
   StringBuilder sb = new StringBuilder( );
   for 
   ( 
    scriptureReferenceBookChapterVersePrePostCount = 0; 
    scriptureReferenceBookChapterVersePrePostCount < scriptureReferenceBookChapterVersePrePostTotal;
    ++scriptureReferenceBookChapterVersePrePostCount
   )
   {
   preBibleBookId  = BibleBookTitle.IndexOf( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterVersePrePostCount].preBookTitle );
   postBibleBookId = BibleBookTitle.IndexOf( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterVersePrePostCount].postBookTitle );   
   switch ( scriptureReferenceBookChapterVersePrePost.sonInLaw )
   {
    case SonInLawPreBookTitlePreChapter:
     sb.Append( ColumnNameBookId );
     sb.Append('=');
     sb.Append( preBibleBookId );
     sb.Append( SQLAnd );
     sb.Append( ColumnNameChapterId );
     sb.Append('=');
     sb.Append( preChapter );
     break;

    case SonInLawPreBookTitlePreChapterPreVerse:
     sb.Append( ColumnNameBookId );
     sb.Append('=');
     sb.Append( preBibleBookId );
     sb.Append( SQLAnd );
     sb.Append( ColumnNameChapterId );
     sb.Append('=');
     sb.Append( preChapter );
     sb.Append( SQLAnd );
     sb.Append( ColumnNameVerseId );
     sb.Append('=');
     sb.Append( preVerse );
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostVerse:
     sb.Append( ColumnNameBookId );
     sb.Append('=');
     sb.Append( preBibleBookId );
     sb.Append( SQLAnd );
     sb.Append( ColumnNameChapterId );
     sb.Append('=');
     sb.Append( preChapter );
     sb.Append( SQLAnd );
     sb.Append( ColumnNameVerseId );
     sb.Append( SQLBetween );
     sb.Append( preVerse );
     sb.Append( SQLAnd );     
     sb.Append( postVerse );     
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse:
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse:
     break;
     
    default:
     sb = new StringBuilder();
     break; 
   }//switch ( sonInLaw )
        
   }//for ( scriptureReferenceBookChapterVersePrePostCount = 0; scriptureReferenceBookChapterVersePrePostCount < scriptureReferenceBookChapterVersePrePostTotal; ++scriptureReferenceBookChapterVersePrePostCount );    
   return ( sb );  
  }//public static string URICrosswalkHtml( ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost )
    
 }//public class ScriptureReferenceBookChapterVersePrePost
}//namespace WordEngineering