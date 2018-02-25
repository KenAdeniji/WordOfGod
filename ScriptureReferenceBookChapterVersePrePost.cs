using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;

namespace WordEngineering
{

 /// <summary>Scripture Reference Book, Chapter, Verse Pre, Post.</summary>
 public class ScriptureReferenceBookChapterVersePrePost
 {

  /// <summary>The column name for the bible book Id.</summary>
  public const string ColumnNameBookId = "bookId";

  /// <summary>The column name for the bible chapter Id.</summary>
  public const string ColumnNameChapterId = "chapterId";

  /// <summary>The column name for the result set.</summary>
  public const string ColumnNameResultSet = "resultSet";

  /// <summary>The column name for the bible verse Id.</summary>
  public const string ColumnNameVerseId = "verseId";

  /// <summary>The column name for the bible verse Id sequence.</summary>
  public const string ColumnNameVerseIdSequence = "verseIdSequence";

  /// <summary>The column name for the bible verse text.</summary>
  public const string ColumnNameVerseText = "verseText";

  /// <summary>The scripture reference contains an error.</summary>
  public const int SonInLawError = -1;

  /// <summary>The scripture reference: pre book title.</summary>
  public const int SonInLawPreBookTitle = 0; //1 Samuel.

  /// <summary>The scripture reference: pre book title, pre chapter.</summary>
  public const int SonInLawPreBookTitlePreChapter = 1; //2 Samuel 4.

  /// <summary>The scripture reference: pre book title, pre chapter, pre verse.</summary>
  public const int SonInLawPreBookTitlePreChapterPreVerse = 2; //3 John 1:4.

  /// <summary>The scripture reference: pre book title, post book title.</summary>
  public const int SonInLawPreBookTitlePostBookTitle = 3; //1 Peter - 1 John. 1 Peter 1-5, 2 Peter 1-3, 1 John 1-5.

  /// <summary>The scripture reference: pre book title, post book title, post chapter.</summary>
  public const int SonInLawPreBookTitlePostBookTitlePostChapter = 4; //1 Corinthians - Galatians 3.

  /// <summary>The scripture reference: pre book title, post book title, post chapter, post verse.</summary>
  public const int SonInLawPreBookTitlePostBookTitlePostChapterPostVerse = 5; //1 Kings - 2 Chronicles 3:4.

  /// <summary>The scripture reference: pre book title, pre chapter, post book title.</summary>
  public const int SonInLawPreBookTitlePreChapterPostBookTitle = 6; //1 Samuel 30 - 2 Chronicles.

  /// <summary>The scripture reference: pre book title, pre chapter, post book title, post chapter.</summary>
  public const int SonInLawPreBookTitlePreChapterPostBookTitlePostChapter = 7; //1 Thessalonians 5 - 2 Timothy 3.

  /// <summary>The scripture reference: pre book title, pre chapter, post book title, post chapter, post verse.</summary>
  public const int SonInLawPreBookTitlePreChapterPostBookTitlePostChapterPostVerse = 8; //Song of Solomon 8 - Jeremiah 4:13.

  /// <summary>The scripture reference: pre book title, pre chapter, pre verse, post book title.</summary>
  public const int SonInLawPreBookTitlePreChapterPreVersePostBookTitle = 9; //1 Chronicles 29:10 - Nehemiah.

  /// <summary>The scripture reference: pre book title, pre chapter, pre verse, post book title, post chapter.</summary>
  public const int SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapter = 10; //1 Corinthians 15:3 - Galatians 6.

  /// <summary>The scripture reference: pre book title, pre chapter, pre verse, post book title, post chapter, post verse.</summary>
  public const int SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse = 11; //1 Samuel 16:3 - Ezra 9:12.

  /// <summary>The scripture reference: pre book title, pre chapter, pre verse, post chapter, post verse.</summary>
  public const int SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse = 12; //Acts 1:1 - 5:16.

  /// <summary>The scripture reference: pre book title, pre chapter, pre verse, post verse.</summary>
  public const int SonInLawPreBookTitlePreChapterPreVersePostVerse = 13; //Exodus 20:1-21.

  /// <summary>The scripture reference: pre book title, pre chapter, post chapter.</summary>
  public const int SonInLawPreBookTitlePreChapterPostChapter = 14; //Deuteronomy 6-20.

  /// <summary>20030614 The scripture reference: pre book title, pre chapter, post chapter, post verse.</summary>
  public const int SonInLawPreBookTitlePreChapterPostChapterPostVerse = 15; //Job 15-16:4, 39 verses.

  /// <summary>20030713 The scripture reference: pre book title, pre chapter, pre verse, post chapter</summary>
  public const int SonInLawPreBookTitlePreChapterPreVersePostChapter = 16; //Ecclesiastes 1:18-12.

  /// <summary>The chapterIdSequence Maximum (Revelation 22).</summary>
  public const int ChapterIdSequenceMaximum = 1189;

  /// <summary>The verseIdSequence Maximum (Revelation 22:21).</summary>
  public const int VerseIdSequenceMaximum = 31102;

  /// <summary>The SQL And Clause</summary>
  public const string SQLAnd = " AND ";

  /// <summary>The SQL And Clause</summary>
  public const string SQLBetween = " BETWEEN ";

  /// <summary>The SQL Select Scripture Reference Without Bracket, VerseText.</summary>
  //public const string SQLSelectScriptureReferenceWithoutBracket_VerseText = " SELECT {0} As resultSet, bookTitle, chapterId, verseId, scriptureReferenceWithoutBracket, verseText, verseIdSequence FROM KJV (NoLock) WHERE {1} ";
  public const string SQLSelectScriptureReferenceWithoutBracket_VerseText = " SELECT {0} As resultSet, bookId, chapterId, verseId, verseText, verseIdSequence FROM KJV (NoLock) WHERE {1} ";

  /// <summary>The SQL Select Scripture Reference Without Bracket, VerseText.</summary>
  public const string SQLSelectScriptureReferenceClauseOrderBy = " ORDER BY resultSet, verseIdSequence ";

  /// <summary>The SQL And Clause</summary>
  public const string SQLSelectVerseIdSequence = " SELECT verseIdSequence From KJV ( NoLock ) WHERE ";
  
  /// <summary>The Verse Id Sequence Minimum.</summary>
  public const string SQLSelectVerseIdSequenceMinimum = " SELECT verseIdSequenceFirst From BibleBook ( NoLock ) WHERE bookId = {0}";

  /// <summary>The Verse Id Sequence Maximum.</summary>
  public const string SQLSelectVerseIdSequenceMaximum = " SELECT verseIdSequenceLast From BibleBook ( NoLock ) WHERE bookId = {0}";

  /// <summary>The SQL And Clause</summary>
  public const string SQLSelectChapterVerseIdSequenceMinimumMaximum = " SELECT MIN(verseIdSequence) AS verseIdSequenceMinimum, MAX(verseIdSequence) AS verseIdSequenceMaximum, MIN(chapterIdSequence) AS chapterIdSequenceMinimum, MAX(chapterIdSequence) AS chapterIdSequenceMaximum From KJV ( NoLock ) WHERE {0}";

  /// <summary>The SQL And Clause</summary>
  public const string ChapterVerseIdSequenceMinimumMaximumFormat = "Chapter sequence {0} of 1189, {1}%. Verse sequence {2} of 31102, {3}%.";

  /// <summary>The name of the bible table or view.</summary>
  public const string SQLSourceBible = " KJV ( NoLock ) ";

  /// <summary>The name of the bible table or view.</summary>
  public const string SQLSourceBibleBook = " BibleBook ( NoLock ) ";

  /// <summary>The SQL Union All Clause</summary>
  public const string SQLUnionAll = " UNION ALL ";

  /// <summary>The URI Crosswalk delimiter between the book, chapter verse, pre and post.</summary>
  public const string URICrosswalkDelimiterBookChapterPreVersePost = "%2C+";

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

  /// <summary>The book id, pre.</summary>
  private int preBookId;

  /// <summary>The book title, pre.</summary>
  private string preBookTitle;

  /// <summary>The book id, post.</summary>
  private int postBookId;

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
  /// <param name="scriptureReferenceArray">The array of scripture references.</param>
  public ScriptureReferenceBookChapterVersePrePost
  (
   string[] scriptureReferenceArray
  ) 
  :this
  (
   scriptureReferenceArray[ScriptureReference.ScriptureReferencePreBook],
   scriptureReferenceArray[ScriptureReference.ScriptureReferencePreChapter],
   scriptureReferenceArray[ScriptureReference.ScriptureReferencePreVerse],
   scriptureReferenceArray[ScriptureReference.ScriptureReferencePostBook],
   scriptureReferenceArray[ScriptureReference.ScriptureReferencePostChapter],
   scriptureReferenceArray[ScriptureReference.ScriptureReferencePostVerse]
  )
  {}
  
  /// <summary>The class constructor.</summary>
  /// <param name="preBookTitle">The pre book title.</param>  
  /// <param name="preChapter">The pre chapter.</param>
  /// <param name="preVerse">The pre verse.</param>    
  /// <param name="postBookTitle">The post book title.</param>  
  /// <param name="postChapter">The post chapter.</param>
  /// <param name="postVerse">The post verse.</param>    
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
   if ( String.Compare( preVerse, postVerse, true ) >= 1 )
   {
    postChapter = postVerse; 
    postVerse   = null;
   }	 

   this.preBookId     = BibleBookTitle.IndexOf( preBookTitle );
   this.preBookTitle  = preBookTitle;
   this.preChapter    = System.Convert.ToInt16( preChapter );
   this.preVerse      = System.Convert.ToInt16( preVerse );
   this.postBookId    = BibleBookTitle.IndexOf( postBookTitle );   
   this.postBookTitle = postBookTitle;
   this.postChapter   = System.Convert.ToInt16( postChapter );
   this.postVerse     = System.Convert.ToInt16( postVerse );

   if ( preBookTitle != null && preChapter == null && preVerse == null && postBookTitle == null && postChapter == null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitle; //1 Samuel.
   }//if ( preBookTitle != null && preChapter == null && preVerse == null && postBookTitle == null && postChapter == null && postVerse == null )
   else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle == null && postChapter == null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapter; //2 Samuel 4.
   }//else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle == null && postChapter == null && postVerse == null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter == null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVerse; //3 John 1:4.
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter == null && postVerse == null )
   else if ( preBookTitle != null && preChapter == null && preVerse == null && postBookTitle != null && postChapter == null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePostBookTitle; //1 Peter - 1 John. 1 Peter 1-5, 2 Peter 1-3, 1 John 1-5.
   }//if ( preBookTitle != null && preChapter == null && preVerse == null && postBookTitle != null && postChapter == null && postVerse == null )
   else if ( preBookTitle != null && preChapter == null && preVerse == null && postBookTitle != null && postChapter != null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePostBookTitlePostChapter; //1 Corinthians - Galatians 3.
   }//else if ( preBookTitle != null && preChapter == null && preVerse == null && postBookTitle != null && postChapter != null && postVerse == null )
   else if ( preBookTitle != null && preChapter == null && preVerse == null && postBookTitle != null && postChapter != null && postVerse != null )
   {
    sonInLaw = SonInLawPreBookTitlePostBookTitlePostChapterPostVerse; //1 Kings - 2 Chronicles 3:4.
   }//else if ( preBookTitle != null && preChapter == null && preVerse == null && postBookTitle != null && postChapter != null && postVerse != null )
   else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle != null && postChapter == null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPostBookTitle; //1 Samuel 30 - 2 Chronicles.
   }//else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle != null && postChapter == null && postVerse == null )
   else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle != null && postChapter != null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPostBookTitlePostChapter; //1 Thessalonians 5 - 2 Timothy 3.
   }//else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle != null && postChapter == null && postVerse == null )
   else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle != null && postChapter != null && postVerse != null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPostBookTitlePostChapterPostVerse; //Song of Solomon 8 - Jeremiah 4:13.
   }//else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle != null && postChapter != null && postVerse != null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle != null && postChapter == null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVersePostBookTitle; //1 Chronicles 29:10 - Nehemiah.
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle != null && postChapter == null && postVerse == null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle != null && postChapter != null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapter; //1 Corinthians 15:3 - Galatians 6.
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle != null && postChapter != null && postVerse == null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle != null && postChapter != null && postVerse != null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse; //1 Samuel 16:3 - Ezra 9:12.
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle != null && postChapter != null && postVerse != null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter != null && postVerse != null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse; //Acts 1:1 - 5:16.
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter != null && postVerse != null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter == null && postVerse != null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVersePostVerse; //Exodus 20:1-21.
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter == null && postVerse != null )
   else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle == null && postChapter != null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPostChapter; //Deuteronomy 6-20.
   }//else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle == null && postChapter != null && postVerse == null )
   else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle == null && postChapter != null && postVerse != null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPostChapterPostVerse; //Job 15-16:4.
   }//else if ( preBookTitle != null && preChapter != null && preVerse == null && postBookTitle == null && postChapter != null && postVerse != null )
   else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter != null && postVerse == null )
   {
    sonInLaw = SonInLawPreBookTitlePreChapterPreVersePostChapter; //Ecclesiastes 1:18-12.
   }//else if ( preBookTitle != null && preChapter != null && preVerse != null && postBookTitle == null && postChapter != null && postVerse == null )
   else
   {
    sonInLaw = SonInLawError;
   }//else
  }//ScriptureReferenceBookChapterVersePrePost
  
  ///<summary>PreBookId property</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public int PreBookId
  {
   get 
   {
    return (preBookId);
   }//get
  }//public string PreBookId

  ///<summary>PreBookTitle property</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public string PreBookTitle
  {
   get 
   {
    return (preBookTitle);
   }//get
  }//public string PreBookTitle

  ///<summary>PostBookId property</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public int PostBookId
  {
   get 
   {
    return (postBookId);
   }//get
  }//public string PostBookId

  ///<summary>PostBookTitle property</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public string PostBookTitle
  {
   get 
   {
    return (postBookTitle);
   }//get
  }//public string PreBookTitle

  ///<summary>PreChapter property</summary>
  ///<value>A value tag is used to describe the property value.</value>
  public int PreChapter
  {
   get 
   {
    return (preChapter);
   }//get
  }//public int PreChapter

  ///<summary>PostChapter property</summary>
  ///<value>A value tag is used to describe the property value</value>
  public int PostChapter
  {
   get 
   {
    return (postChapter);
   }//get
  }//public int PostChapter

  ///<summary>PreVerse property</summary>
  ///<value>A value tag is used to describe the property value</value>
  public int PreVerse
  {
   get 
   {
    return (preVerse);
   }//get
  }//public int PreVerse

  ///<summary>PostVerse property</summary>
  ///<value>A value tag is used to describe the property value</value>
  public int PostVerse
  {
   get 
   {
    return (postVerse);
   }//get
  }//public int PostVerse

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
   StringBuilder sb = new StringBuilder();

   switch ( sonInLaw )
   {
    case SonInLawPreBookTitle: //1 Samuel.
     sb.AppendFormat("{0}", preBookTitle);
     break;

    case SonInLawPreBookTitlePreChapter: //2 Samuel 4.
     sb.AppendFormat("{0} {1}", preBookTitle, preChapter);     
     break;

    case SonInLawPreBookTitlePreChapterPreVerse: //3 John 1:4.
     sb.AppendFormat("{0} {1}:{2}", preBookTitle, preChapter, preVerse);
     break;

    case SonInLawPreBookTitlePostBookTitle: //1 Peter - 1 John. 1 Peter 1-5, 2 Peter 1-3, 1 John 1-5.
     sb.AppendFormat("{0}-{1}", preBookTitle, postBookTitle);
     break;

    case SonInLawPreBookTitlePostBookTitlePostChapter: //1 Corinthians - Galatians 3.
     sb.AppendFormat("{0}-{1} {2}", preBookTitle, postBookTitle, postChapter);
     break;

    case SonInLawPreBookTitlePostBookTitlePostChapterPostVerse: //1 Kings - 2 Chronicles 3:4.
     sb.AppendFormat("{0}-{1} {2}:{3}", preBookTitle, postBookTitle, postChapter, postVerse);
     break;

    case SonInLawPreBookTitlePreChapterPostBookTitle: //1 Samuel 30 - 2 Chronicles.
     sb.AppendFormat("{0} {1}-{2}", preBookTitle, preChapter, postBookTitle);
     break;

    case SonInLawPreBookTitlePreChapterPostBookTitlePostChapter: //1 Thessalonians 5 - 2 Timothy 3.
     sb.AppendFormat("{0} {1}-{2} {3}", preBookTitle, preChapter, postBookTitle, postChapter);
     break;

    case SonInLawPreBookTitlePreChapterPostBookTitlePostChapterPostVerse: //Song of Solomon 8 - Jeremiah 4:13.
     sb.AppendFormat("{0} {1}-{2} {3}:{4}", preBookTitle, preChapter, postBookTitle, postChapter, postVerse);
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitle: //1 Chronicles 29:10 - Nehemiah.
     sb.AppendFormat("{0} {1}:{2}-{3}", preBookTitle, preChapter, preVerse, postBookTitle);
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapter: //1 Corinthians 15:3 - Galatians 6.
     sb.AppendFormat("{0} {1}:{2}-{3} {4}", preBookTitle, preChapter, preVerse, postBookTitle, postChapter);
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse: //1 Samuel 16:3 - Ezra 9:12.
     sb.AppendFormat("{0} {1}:{2}-{3} {4}:{5}", preBookTitle, preChapter, preVerse, postBookTitle, postChapter, postVerse);
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse: //Acts 1:1 - 5:16.
     sb.AppendFormat("{0} {1}:{2}-{3}:{4}", preBookTitle, preChapter, preVerse, postChapter, postVerse);
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostVerse: //Exodus 20:1-21.
     sb.AppendFormat("{0} {1}:{2}-{3}", preBookTitle, preChapter, preVerse, postVerse);
     break;

    case SonInLawPreBookTitlePreChapterPostChapter: //Deuteronomy 6-20.
     sb.AppendFormat("{0} {1}-{2}", preBookTitle, preChapter, postChapter);
     break;

    case SonInLawPreBookTitlePreChapterPostChapterPostVerse: //Job 15-16:4.
     sb.AppendFormat("{0} {1}-{2}:{3}", preBookTitle, preChapter, postChapter, postVerse);
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostChapter: //Ecclesiastes 1:18-12.
     sb.AppendFormat("{0} {1}:{2}-{3}", preBookTitle, preChapter, preVerse, postChapter);
     break;
     
    default:
     break; 
         
   }//switch ( sonInLaw )
   	
   return sb.ToString();
   
  }//public static string ToString()	

  /// <summary>The URI Crosswalk HTML.</summary>
  /// <param name="scriptureReferenceBookChapterVersePrePost">The array of scripture reference.</param>
  public static StringBuilder URICrosswalkHtml
  (
   ScriptureReferenceBookChapterVersePrePost scriptureReferenceBookChapterVersePrePost
  )
  {

   StringBuilder sb            = new StringBuilder();

   switch ( scriptureReferenceBookChapterVersePrePost.sonInLaw )
   {
    case SonInLawPreBookTitle: //1 Samuel. 1 Samuel 1-31. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Samuel+1-31&section=0&version=nkj&language=en
     sb.AppendFormat
     (
      "{0}+1-{1}", 
      scriptureReferenceBookChapterVersePrePost.preBookTitle,
      BibleBookTitle.Chapters( scriptureReferenceBookChapterVersePrePost.preBookId )
     );
     break;

    case SonInLawPreBookTitlePreChapter: //2 Samuel 4. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=2+Samuel+4&section=0&version=nkj&language=en
     sb.AppendFormat
     (
      "{0}+{1}", 
      scriptureReferenceBookChapterVersePrePost.preBookTitle, 
      scriptureReferenceBookChapterVersePrePost.preChapter
     );
     break;

    case SonInLawPreBookTitlePreChapterPreVerse: //3 John 1:4. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=3+John+1%3A4&section=0&version=nkj&language=en
     sb.AppendFormat
     (
      "{0}+{1}%3A{2}", 
      scriptureReferenceBookChapterVersePrePost.preBookTitle, 
      scriptureReferenceBookChapterVersePrePost.preChapter, 
      scriptureReferenceBookChapterVersePrePost.preVerse
     );
     break;

    case SonInLawPreBookTitlePostBookTitle: //1 Peter - 1 John. 1 Peter 1-5, 2 Peter 1-3, 1 John 1-5. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Peter+1-5%2C+2+Peter+1-3%2C+1+John+1-5&section=0&version=nkj&language=en
     URICrosswalkHtml
     ( 
          scriptureReferenceBookChapterVersePrePost,
      ref sb, 
          scriptureReferenceBookChapterVersePrePost.preBookId, 
          scriptureReferenceBookChapterVersePrePost.postBookId 
     );
     break;

    case SonInLawPreBookTitlePostBookTitlePostChapter: //1 Corinthians - Galatians 3. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Corinthians+1-16%2C+2+Corinthians+1-13%2C+Galatians+1-3&section=0&version=nkj&language=en
     URICrosswalkHtml
     ( 
          scriptureReferenceBookChapterVersePrePost,
      ref sb, 
          scriptureReferenceBookChapterVersePrePost.preBookId, 
          scriptureReferenceBookChapterVersePrePost.postBookId - 1 
     );
     sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
     sb.AppendFormat
     (
      "{0}+1-{1}", 
      scriptureReferenceBookChapterVersePrePost.postBookTitle, 
      scriptureReferenceBookChapterVersePrePost.postChapter
     );
     break;

    case SonInLawPreBookTitlePostBookTitlePostChapterPostVerse: //1 Kings - 2 Chronicles 3:4. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1%3A1-3%3A4&section=0&version=nkj&language=en
     URICrosswalkHtml
     ( 
          scriptureReferenceBookChapterVersePrePost,
      ref sb, 
          scriptureReferenceBookChapterVersePrePost.preBookId, 
          scriptureReferenceBookChapterVersePrePost.postBookId - 1 
     );
     sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
     sb.AppendFormat
     (
      "{0}+1%3A1-{1}%3A{2}", 
      scriptureReferenceBookChapterVersePrePost.postBookTitle, 
      scriptureReferenceBookChapterVersePrePost.postChapter,
      scriptureReferenceBookChapterVersePrePost.postVerse      
     );
     break;

    case SonInLawPreBookTitlePreChapterPostBookTitle: //1 Samuel 30 - 2 Chronicles. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Samuel+30-31%2C+2+Samuel+1-24%2C+1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1-36&section=0&version=nkj&language=en
     sb.AppendFormat
     (
      "{0}+{1}-{2}", 
      scriptureReferenceBookChapterVersePrePost.preBookTitle,
      scriptureReferenceBookChapterVersePrePost.preChapter,
      BibleBookTitle.Chapters( scriptureReferenceBookChapterVersePrePost.preBookId )
     );
     sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
     URICrosswalkHtml
     ( 
          scriptureReferenceBookChapterVersePrePost,
      ref sb, 
          scriptureReferenceBookChapterVersePrePost.preBookId + 1, 
          scriptureReferenceBookChapterVersePrePost.postBookId 
     );
     break;
          
    case SonInLawPreBookTitlePreChapterPostBookTitlePostChapter: //1 Thessalonians 5 - 2 Timothy 3. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Thessalonians+5-5%2C+2+Thessalonians+1-3%2C+1+Timothy+1-6%2C+2+Timothy+1-3&section=0&version=nkj&language=en
     sb.AppendFormat
     (
      "{0}+{1}-{2}", 
      scriptureReferenceBookChapterVersePrePost.preBookTitle,
      scriptureReferenceBookChapterVersePrePost.preChapter,
      BibleBookTitle.Chapters( scriptureReferenceBookChapterVersePrePost.preBookId )
     );
     if ( scriptureReferenceBookChapterVersePrePost.postBookId - 1 > scriptureReferenceBookChapterVersePrePost.preBookId )
     {
      sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
      URICrosswalkHtml
      ( 
          scriptureReferenceBookChapterVersePrePost,
       ref sb, 
          scriptureReferenceBookChapterVersePrePost.preBookId + 1, 
          scriptureReferenceBookChapterVersePrePost.postBookId - 1
      );
      sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
     }//if ( scriptureReferenceBookChapterVersePrePost.postBookId - 1 > scriptureReferenceBookChapterVersePrePost.preBookId + 1 ) 
     sb.AppendFormat
     (
      "{0}+1-{1}", 
      scriptureReferenceBookChapterVersePrePost.postBookTitle,
      scriptureReferenceBookChapterVersePrePost.postChapter
     );
     break;

    case SonInLawPreBookTitlePreChapterPostBookTitlePostChapterPostVerse: //Song of Solomon 8 - Jeremiah 4:13. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Song+of+Solomon+8-8%2C+Isaiah+1-66%2C+Jeremiah+1-4%3A13&section=0&version=nkj&language=en
     sb.AppendFormat
     (
      "{0}+{1}-{2}", 
      scriptureReferenceBookChapterVersePrePost.preBookTitle,
      scriptureReferenceBookChapterVersePrePost.preChapter,
      BibleBookTitle.Chapters( scriptureReferenceBookChapterVersePrePost.preBookId )
     );
     if ( scriptureReferenceBookChapterVersePrePost.postBookId - 1 > scriptureReferenceBookChapterVersePrePost.preBookId )
     {
      sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
      URICrosswalkHtml
      ( 
          scriptureReferenceBookChapterVersePrePost,
       ref sb, 
          scriptureReferenceBookChapterVersePrePost.preBookId + 1, 
          scriptureReferenceBookChapterVersePrePost.postBookId - 1
      );
      sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
     }//if ( scriptureReferenceBookChapterVersePrePost.postBookId - 1 > scriptureReferenceBookChapterVersePrePost.preBookId + 1 ) 
     sb.AppendFormat
     (
      "{0}+1-{1}%3A{2}", 
      scriptureReferenceBookChapterVersePrePost.postBookTitle,
      scriptureReferenceBookChapterVersePrePost.postChapter,
      scriptureReferenceBookChapterVersePrePost.postVerse
     );
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitle: //1 Chronicles 29:10 - Nehemiah. 
     sb.AppendFormat
     (
      "{0}+{1}%3A{2}-{3}%3A{4}",
      scriptureReferenceBookChapterVersePrePost.preBookTitle, 
      scriptureReferenceBookChapterVersePrePost.preChapter, 
      scriptureReferenceBookChapterVersePrePost.preVerse,       
      BibleBookTitle.Chapters( scriptureReferenceBookChapterVersePrePost.preBookId ),
      BibleBookTitle.LastChapterLastVerse( scriptureReferenceBookChapterVersePrePost.preBookId )      
     );
     if ( scriptureReferenceBookChapterVersePrePost.postBookId - 1 > scriptureReferenceBookChapterVersePrePost.preBookId )
     {
      sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
      URICrosswalkHtml
      ( 
          scriptureReferenceBookChapterVersePrePost,
       ref sb, 
          scriptureReferenceBookChapterVersePrePost.preBookId + 1, 
          scriptureReferenceBookChapterVersePrePost.postBookId
      );
     }//if ( scriptureReferenceBookChapterVersePrePost.postBookId - 1 > scriptureReferenceBookChapterVersePrePost.preBookId + 1 ) 
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapter: //1 Corinthians 15:3 - Galatians 6. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Corinthians+15%3A3-16%3A24%2C+2+Corinthians+1-13%2C+Galatians+1-6&section=0&version=nkj&language=en
    sb.AppendFormat
     (
      "{0}+{1}%3A{2}-{3}%3A{4}",
      scriptureReferenceBookChapterVersePrePost.preBookTitle, 
      scriptureReferenceBookChapterVersePrePost.preChapter, 
      scriptureReferenceBookChapterVersePrePost.preVerse,       
      BibleBookTitle.Chapters( scriptureReferenceBookChapterVersePrePost.preBookId ),
      BibleBookTitle.LastChapterLastVerse( scriptureReferenceBookChapterVersePrePost.preBookId )      
     );
     if ( scriptureReferenceBookChapterVersePrePost.postBookId - 1 > scriptureReferenceBookChapterVersePrePost.preBookId )
     {
      sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
      URICrosswalkHtml
      ( 
           scriptureReferenceBookChapterVersePrePost,
       ref sb, 
           scriptureReferenceBookChapterVersePrePost.preBookId  + 1, 
           scriptureReferenceBookChapterVersePrePost.postBookId - 1
      );
     }//if ( scriptureReferenceBookChapterVersePrePost.postBookId - 1 > scriptureReferenceBookChapterVersePrePost.preBookId + 1 ) 
     sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
     sb.AppendFormat
     (
      "{0}+1-{1}", 
      scriptureReferenceBookChapterVersePrePost.postBookTitle,
      scriptureReferenceBookChapterVersePrePost.postChapter
     );
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse: //1 Samuel 16:3 - Ezra 9:12. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Samuel+16%3A3-31%3A13%2C+2+Samuel+1-24%2C+1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1-36%2C+Ezra+1%3A1-9%3A12&section=0&version=nkj&language=en    
     sb.AppendFormat
     (
      "{0}+{1}%3A{2}-{3}%3A{4}",
      scriptureReferenceBookChapterVersePrePost.preBookTitle, 
      scriptureReferenceBookChapterVersePrePost.preChapter, 
      scriptureReferenceBookChapterVersePrePost.preVerse,       
      BibleBookTitle.Chapters( scriptureReferenceBookChapterVersePrePost.preBookId ),
      BibleBookTitle.LastChapterLastVerse( scriptureReferenceBookChapterVersePrePost.preBookId )      
     );
     if ( scriptureReferenceBookChapterVersePrePost.postBookId - 1 > scriptureReferenceBookChapterVersePrePost.preBookId )
     {
      sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
      URICrosswalkHtml
      ( 
           scriptureReferenceBookChapterVersePrePost,
       ref sb, 
           scriptureReferenceBookChapterVersePrePost.preBookId  + 1, 
           scriptureReferenceBookChapterVersePrePost.postBookId - 1
      );
     }//if ( scriptureReferenceBookChapterVersePrePost.postBookId - 1 > scriptureReferenceBookChapterVersePrePost.preBookId + 1 ) 
     sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
     sb.AppendFormat
     (
      "{0}+1%3A1-{1}%3A{2}", 
      scriptureReferenceBookChapterVersePrePost.postBookTitle,
      scriptureReferenceBookChapterVersePrePost.postChapter,
      scriptureReferenceBookChapterVersePrePost.postVerse
     );
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse: //Acts 1:1 - 5:16. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Acts+1%3A1-5%3A16&section=0&version=nkj&language=en
     sb.AppendFormat
     (
      "{0}+{1}%3A{2}-{3}%3A{4}",
      scriptureReferenceBookChapterVersePrePost.preBookTitle, 
      scriptureReferenceBookChapterVersePrePost.preChapter, 
      scriptureReferenceBookChapterVersePrePost.preVerse,       
      scriptureReferenceBookChapterVersePrePost.postChapter,
      scriptureReferenceBookChapterVersePrePost.postVerse
     );
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostVerse: //Exodus 20:1-21. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Exodus+20%3A1-21&section=0&version=nkj&language=en
     sb.AppendFormat
     (
      "{0}+{1}%3A{2}-{3}",
      scriptureReferenceBookChapterVersePrePost.preBookTitle, 
      scriptureReferenceBookChapterVersePrePost.preChapter, 
      scriptureReferenceBookChapterVersePrePost.preVerse,       
      scriptureReferenceBookChapterVersePrePost.postVerse
     );
     break;
  
    case SonInLawPreBookTitlePreChapterPostChapter: //Deuteronomy 6-20. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Deuteronomy+6-20&section=0&version=nkj&language=en
     sb.AppendFormat
     (
      "{0}+{1}-{2}",
      scriptureReferenceBookChapterVersePrePost.preBookTitle, 
      scriptureReferenceBookChapterVersePrePost.preChapter, 
      scriptureReferenceBookChapterVersePrePost.postChapter
     );
     break;

    case SonInLawPreBookTitlePreChapterPostChapterPostVerse: //Job 15-16:4.
     sb.AppendFormat
     (
      "{0}+{1}-{2}:{3}",
      scriptureReferenceBookChapterVersePrePost.preBookTitle, 
      scriptureReferenceBookChapterVersePrePost.preChapter, 
      scriptureReferenceBookChapterVersePrePost.postChapter,
      scriptureReferenceBookChapterVersePrePost.postVerse
     );
     break;

    case SonInLawPreBookTitlePreChapterPreVersePostChapter: //Ecclesiastes 1:18-12
     sb.AppendFormat
     (
      "{0}+{1}:{2}-{3}",
      scriptureReferenceBookChapterVersePrePost.preBookTitle, 
      scriptureReferenceBookChapterVersePrePost.preChapter, 
      scriptureReferenceBookChapterVersePrePost.preVerse,      
      scriptureReferenceBookChapterVersePrePost.postChapter
     );
     break;
      
    default:
     break; 
         
   }//switch ( sonInLaw )

   return ( sb );
   
  }//public static StringBuilder URICrosswalkHtml( ScriptureReferenceBookChapterVersePrePost scriptureReferenceBookChapterVersePrePost )

  /// <summary>The URI Crosswalk HTML.</summary>
  /// <param name="scriptureReferenceBookChapterVersePrePost">The array of scripture reference.</param>  
  public static StringBuilder URICrosswalkHtml
  (
   ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost
  )
  {
   int scriptureReferenceBookChapterPreVersePostCount; 
   int scriptureReferenceBookChapterPreVersePostTotal = scriptureReferenceBookChapterVersePrePost.Length;
   StringBuilder sb = new StringBuilder( URICrosswalkPre );
   for 
   ( 
    scriptureReferenceBookChapterPreVersePostCount = 0; 
    scriptureReferenceBookChapterPreVersePostCount < scriptureReferenceBookChapterPreVersePostTotal;
    ++scriptureReferenceBookChapterPreVersePostCount
   )
   {
    sb.Append( URICrosswalkHtml( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount] ) );	
    if ( scriptureReferenceBookChapterPreVersePostCount + 1 < scriptureReferenceBookChapterPreVersePostTotal )
    {
     sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );	
    }//if ( scriptureReferenceBookChapterPreVersePostCount + 1 < scriptureReferenceBookChapterPreVersePostTotal )    	
   }//for ( scriptureReferenceBookChapterPreVersePostCount = 0; scriptureReferenceBookChapterPreVersePostCount < scriptureReferenceBookChapterPreVersePostTotal; ++scriptureReferenceBookChapterPreVersePostCount );
   sb.Append( URICrosswalkPost );
   sb.Replace(' ', '+');
   return ( sb );  
  }//public static string URICrosswalkHtml( ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost )

  /// <summary>The URI Crosswalk HTML.</summary>
  /// <param name="scriptureReferenceBookChapterVersePrePost">The scripture reference book, chapter, verse, pre and post</param>
  /// <param name="sb">The string builder.</param>
  /// <param name="bookIdStart">The book Id start.</param>  
  /// <param name="bookIdEnd">The book Id end.</param>    
  public static void URICrosswalkHtml
  ( 
       ScriptureReferenceBookChapterVersePrePost scriptureReferenceBookChapterVersePrePost,
   ref StringBuilder                             sb,  
       int                                       bookIdStart,
       int                                       bookIdEnd
  )
  {
   for ( int bookIdCurrent =  bookIdStart; bookIdCurrent <= bookIdEnd; ++bookIdCurrent )
   { 
    sb.AppendFormat
    (
     "{0}+1-{1}", 
     BibleBookTitle.BookTitle( bookIdCurrent ),
     BibleBookTitle.Chapters( bookIdCurrent )
    );
    if ( bookIdCurrent < bookIdEnd )
    {
     sb.Append( URICrosswalkDelimiterBookChapterPreVersePost );
    }//if ( bookIdCurrent < scriptureReferenceBookChapterVersePrePost.postBookId )  
   }//for ( bookIdCurrent = scriptureReferenceBookChapterVersePrePost.preBookId; bookIdCurrent < scriptureReferenceBookChapterVersePrePost.postBookId; ++bookIdCurrent ) 
  }//public static void URICrosswalkHtml( ref StringBuilder sb, int preBookId, int postBookId )
  
  /// <summary>The URI Crosswalk XML.</summary>
  /// <param name="uriCrosswalkHtml">The URI Crosswalk HTML.</param>  
  public static StringBuilder URICrosswalkXml
  (
   StringBuilder uriCrosswalkHtml
  )
  {
   StringBuilder uriCrosswalkXml = new StringBuilder( uriCrosswalkHtml.ToString() );
   uriCrosswalkXml.Replace("&", "&amp;");
   return ( uriCrosswalkXml );  
  }//public static string URICrosswalkXml( StringBuilder uriCrosswalkHtml )

  /// <summary>The URI Crosswalk XML.</summary>
  /// <param name="scriptureReferenceBookChapterVersePrePost">The array of scripture reference.</param>  
  public static StringBuilder URICrosswalkXml
  (
   ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost
  )
  {
   StringBuilder sb = new StringBuilder( (URICrosswalkHtml(scriptureReferenceBookChapterVersePrePost)).ToString() );
   sb.Replace("&", "&amp;");
   return ( sb );  
  }//public static string URICrosswalkHtml( ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost )

  /// <summary>The SQLStatement Condition.</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>    
  /// <param name="exceptionMessage">The exception message.</param>      
  /// <param name="scriptureReferenceBookChapterVersePrePost">The array of scripture reference.</param>  
  /// <param name="scriptureReferenceBookChapterPreVersePostCondition">The condition for the scripture reference book, chapter, verse, pre and post.</param>  
  /// <param name="scriptureReferenceBookChapterPreVersePostSelect">The SQL statement for each scripture reference book, chapter, verse, pre and post.</param>  
  /// <param name="scriptureReferenceBookChapterPreVersePostQuery">The SQL statement for the scripture reference book, chapter, verse, pre and post.</param>    
  public static void SQLStatementCondition
  (
       string                                      databaseConnectionString,
   ref string                                      exceptionMessage,   
       ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost,
   ref StringBuilder[]                             scriptureReferenceBookChapterPreVersePostCondition,
   ref StringBuilder[]                             scriptureReferenceBookChapterPreVersePostSelect,
   ref StringBuilder                               scriptureReferenceBookChapterPreVersePostQuery   
  )
  {
   int           preBibleBookId                                 = -1;
   int           verseIdSequencePre                             = -1;
   int           postBibleBookId                                = -1;   
   int           verseIdSequencePost                            = -1;   
   int           scriptureReferenceBookChapterPreVersePostCount = -1;
   int           scriptureReferenceBookChapterPreVersePostTotal = scriptureReferenceBookChapterVersePrePost.Length;
   object        databaseReturnValue                            = null;
   
   StringBuilder sb                                             = null;
   scriptureReferenceBookChapterPreVersePostCondition           = new StringBuilder[scriptureReferenceBookChapterPreVersePostTotal];
   scriptureReferenceBookChapterPreVersePostSelect              = new StringBuilder[scriptureReferenceBookChapterPreVersePostTotal];   
   scriptureReferenceBookChapterPreVersePostQuery               = new StringBuilder();
   for 
   ( 
    scriptureReferenceBookChapterPreVersePostCount = 0; 
    scriptureReferenceBookChapterPreVersePostCount < scriptureReferenceBookChapterPreVersePostTotal;
    ++scriptureReferenceBookChapterPreVersePostCount
   )
   {
    scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount] = new StringBuilder();
    scriptureReferenceBookChapterPreVersePostSelect[scriptureReferenceBookChapterPreVersePostCount]    = new StringBuilder();    
    
    preBibleBookId  = BibleBookTitle.IndexOf( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].preBookTitle  );
    postBibleBookId = BibleBookTitle.IndexOf( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].postBookTitle );
    
    switch ( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].sonInLaw )
    {

     case SonInLawPreBookTitle: //1 Samuel. SELECT 0 As resultSet, chapterId, verseId, verseText, verseIdSequence FROM KJV (NoLock) WHERE bookId = 9 ORDER BY resultSet, verseIdSequence
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} = {1}", 
       ColumnNameBookId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId
      );     
      break;

     case SonInLawPreBookTitlePreChapter: //2 Samuel 4. SELECT 0 As resultSet, bookId, chapterId, verseId, verseText, verseIdSequence FROM KJV (NoLock) WHERE bookId=10 AND chapterId=4
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0}={1} AND {2}={3}", 
       ColumnNameBookId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId, 
       ColumnNameChapterId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter 
      );     
      break;

     case SonInLawPreBookTitlePreChapterPreVerse: //3 John 1:4. SELECT 0 As resultSet, bookId, chapterId, verseId, verseText, verseIdSequence FROM KJV (NoLock) WHERE bookId=64 AND chapterId=1 AND verseId=4    
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0}={1} AND {2}={3} AND {4}={5}", 
       ColumnNameBookId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId, 
       ColumnNameChapterId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter, 
       ColumnNameVerseId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreVerse 
      );           
      break;

     case SonInLawPreBookTitlePostBookTitle: //1 Peter - 1 John. 1 Peter 1-5, 2 Peter 1-3, 1 John 1-5.
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameBookId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostBookId 
      );           
      break;

     case SonInLawPreBookTitlePostBookTitlePostChapter: //1 Corinthians - Galatians 3. SELECT bookTitle, bookId, chapterId,  verseId, verseIdSequence, verseText FROM KJV ( NOLOCK ) WHERE verseIdSequence IN ( 28365, 29132 ) ORDER BY verseIdSequence
      verseIdSequencePre = BibleBookTitle.VerseIdSequenceFirst( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId );
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT TOP 1 {0} FROM {1} WHERE {2} = {3} AND {4} = {5} ORDER BY {6} DESC", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostChapter,
       ColumnNameVerseIdSequence
      );       
      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePost = (Int32) databaseReturnValue;
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );     
      break;

     case SonInLawPreBookTitlePostBookTitlePostChapterPostVerse: 
      //1 Kings - 2 Chronicles 3:4.
      //verseIdSequencePost SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock )  WHERE bookId = 14 AND chapterId = 3 AND verseId = 4
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence IN ( 8719, 11234 ) ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1%3A1-3%3A4&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1%3A1-3%3A4&amp;section=0&amp;version=nkj&amp;language=en
      verseIdSequencePre = BibleBookTitle.VerseIdSequenceFirst( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId );
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostVerse
      );       
      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePost SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif
      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePost = (Int32) databaseReturnValue;
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );     
      break;

     case SonInLawPreBookTitlePreChapterPostBookTitle: 
      //1 Samuel 30 - 2 Chronicles.
      //verseIdSequencePre SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 9 AND chapterId = 30 AND verseId 1
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence BETWEEN  7980 AND 12017 ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Samuel+30-31%2C+2+Samuel+1-24%2C+1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1-36&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=1+Samuel+30-31%2C+2+Samuel+1-24%2C+1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1-36&amp;section=0&amp;version=nkj&amp;language=en
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = 1", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePre SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePre  = (Int32) databaseReturnValue;
      verseIdSequencePost = BibleBookTitle.VerseIdSequenceLast( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostBookId );
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );
      break;

     case SonInLawPreBookTitlePreChapterPostBookTitlePostChapter: 
      //1 Thessalonians 5 - 2 Timothy 3. 1 Thessalonians 5 - 2 Timothy 3:17.
      //verseIdSequencePre  SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 52 AND chapterId = 5 AND verseId 1
      //verseIdSequencePost SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 55 AND chapterId = 3 ORDER BY verseIdSequence DESC
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence BETWEEN 29623 AND 29871 ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Samuel+30-31%2C+2+Samuel+1-24%2C+1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1-36&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=1+Samuel+30-31%2C+2+Samuel+1-24%2C+1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1-36&amp;section=0&amp;version=nkj&amp;language=en
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = 1", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePre SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePre  = (Int32) databaseReturnValue;

      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT TOP 1 {0} FROM {1} WHERE {2} = {3} AND {4} = {5} ORDER BY {6} DESC", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostChapter,
       ColumnNameVerseIdSequence
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePost SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePost = (Int32) databaseReturnValue;

      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );
      break;

     case SonInLawPreBookTitlePreChapterPostBookTitlePostChapterPostVerse: 
      //Song of Solomon 8 - Jeremiah 4:13.
      //verseIdSequencePre  SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 52 AND chapterId = 5 AND verseId 1
      //verseIdSequencePost SQL Statement: [0]: SELECT TOP 1 verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 55 AND chapterId = 3 ORDER BY verseIdSequence DESC
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence BETWEEN 17642 AND 19041 ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Song+of+Solomon+8-8%2C+Isaiah+1-66%2C+Jeremiah+1-4%3A13&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Song+of+Solomon+8-8%2C+Isaiah+1-66%2C+Jeremiah+1-4%3A13&amp;section=0&amp;version=nkj&amp;language=en
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = 1", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePre SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePre  = (Int32) databaseReturnValue;

      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT TOP 1 {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePost SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePost = (Int32) databaseReturnValue;

      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );
      break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitle: 
      //1 Chronicles 29:10 - Nehemiah.
      //verseIdSequencePre SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock )  WHERE bookId = 13 AND chapterId = 29 AND verseId = 10
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence BETWEEN 11175 AND 12703 ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Chronicles+29%3A10-29%3A30%2C+2+Chronicles+1-36%2C+Ezra+1-10%2C+Nehemiah+1-13&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=1+Chronicles+29%3A10-29%3A30%2C+2+Chronicles+1-36%2C+Ezra+1-10%2C+Nehemiah+1-13&amp;section=0&amp;version=nkj&amp;language=en
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePre SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePre  = (Int32) databaseReturnValue;

      verseIdSequencePost = BibleBookTitle.VerseIdSequenceLast( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostBookId );
      
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );
      break;

     case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapter: 
      //1 Corinthians 15:3 - Galatians 6.
      //verseIdSequencePre SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 46 AND chapterId = 15 AND verseId = 3
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence BETWEEN 28722 AND 29207 ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Corinthians+15%3A3-16%3A24%2C+2+Corinthians+1-13%2C+Galatians+1-6&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=1+Corinthians+15%3A3-16%3A24%2C+2+Corinthians+1-13%2C+Galatians+1-6&amp;section=0&amp;version=nkj&amp;language=en
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePre SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePre  = (Int32) databaseReturnValue;

      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT TOP 1 {0} FROM {1} WHERE {2} = {3} AND {4} = {5} ORDER BY {6} DESC", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostChapter,
       ColumnNameVerseIdSequence
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePost SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePost = (Int32) databaseReturnValue;

      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );
      break;

     case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse: 
      //1 Samuel 16:3 - Ezra 9:12.
      //verseIdSequencePre SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 9 AND chapterId = 16 AND verseId = 3
      //verseIdSequencePost SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 15 AND chapterId = 9 AND verseId = 12
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence BETWEEN 7599 AND 12250 ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=1+Samuel+16%3A3-31%3A13%2C+2+Samuel+1-24%2C+1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1-36%2C+Ezra+1%3A1-9%3A12&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=1+Samuel+16%3A3-31%3A13%2C+2+Samuel+1-24%2C+1+Kings+1-22%2C+2+Kings+1-25%2C+1+Chronicles+1-29%2C+2+Chronicles+1-36%2C+Ezra+1%3A1-9%3A12&amp;section=0&amp;version=nkj&amp;language=en
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePre SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePre  = (Int32) databaseReturnValue;

      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePost SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePost = (Int32) databaseReturnValue;

      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );
      break;

     case SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse: 
      //Acts 1:1 - 5:16.
      //verseIdSequencePre SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 44 AND chapterId = 1 AND verseId = 1
      //verseIdSequencePost SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 44 AND chapterId = 5 AND verseId = 16
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence BETWEEN 26925 AND 27076 ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Acts+1%3A1-5%3A16&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Acts+1%3A1-5%3A16&amp;section=0&amp;version=nkj&amp;language=en
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePre SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePre  = (Int32) databaseReturnValue;

      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePost SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePost = (Int32) databaseReturnValue;

      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );
      break;

     case SonInLawPreBookTitlePreChapterPreVersePostVerse: 
      //Exodus 20:1-21.
      //verseIdSequencePre SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 2 AND chapterId = 20 AND verseId = 1
      //verseIdSequencePost SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 2 AND chapterId = 20 AND verseId = 21
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence BETWEEN 2053 AND 2073 ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Exodus+20%3A1-21&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Exodus+20%3A1-21&amp;section=0&amp;version=nkj&amp;language=en
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePre SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif
      
      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePre  = (Int32) databaseReturnValue;

      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePost SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePost = (Int32) databaseReturnValue;

      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );
      
      break;

     case SonInLawPreBookTitlePreChapterPostChapter: //Deuteronomy 6-20. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Deuteronomy+6-20&section=0&version=nkj&language=en
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0}={1} AND {2} BETWEEN {3} AND {4}", 
       ColumnNameBookId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId, 
       ColumnNameChapterId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostChapter
      );           
      break;

    case SonInLawPreBookTitlePreChapterPostChapterPostVerse: //Job 15-16:4.
      //Job 15-16:4
      //verseIdSequencePre  SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 18 AND chapterId = 15 AND verseId = 1
      //verseIdSequencePost SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 18 AND chapterId = 16 AND verseId = 4 
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence BETWEEN 13205 AND 13243 ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Job+15-16:4&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Job+15-16:4&amp;section=0&amp;version=nkj&amp;language=en
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = 1", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePre SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePre  = (Int32) databaseReturnValue;

      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePost SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePost = (Int32) databaseReturnValue;

      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );
      break;
 
     case SonInLawPreBookTitlePreChapterPreVersePostChapter:
      //Ecclesiastes 1:18-12
      //verseIdSequencePre  SQL Statement: [0]: SELECT verseIdSequence FROM  KJV ( NoLock ) WHERE bookId = 21 AND chapterId = 1 AND verseId = 18
      //verseIdSequencePost SQL Statement: [0]: SELECT TOP 1 verseIdSequence FROM  KJV ( NoLock )  WHERE bookId = 21 AND chapterId = 12 ORDER BY verseId DESC
      //SELECT verseIdSequence FROM KJV ( NOLOCK ) WHERE verseIdSequence BETWEEN 17334 AND 17538 ORDER BY verseIdSequence
      //HTML: http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Ecclesiastes+1:18-12&section=0&version=nkj&language=en
      //XML:  http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Ecclesiastes+1:18-12&amp;section=0&amp;version=nkj&amp;language=en
      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT {0} FROM {1} WHERE {2} = {3} AND {4} = {5} AND {6} = {7}", 
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreChapter,
       ColumnNameVerseId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreVerse
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePre SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePre  = (Int32) databaseReturnValue;

      sb = new StringBuilder();
      sb.AppendFormat
      (
       "SELECT TOP 1 {0} FROM {1} WHERE {2} = {3} AND {4} = {5} ORDER BY {6} DESC",
       ColumnNameVerseIdSequence,
       SQLSourceBible,
       ColumnNameBookId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameChapterId,
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PostChapter,
       ColumnNameVerseId
      );       

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "verseIdSequencePost SQL Statement: [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        sb
       );   
      #endif

      databaseReturnValue = UtilityDatabase.DatabaseQuery( databaseConnectionString, ref exceptionMessage, sb.ToString(), CommandType.Text );
      verseIdSequencePost = (Int32) databaseReturnValue;

      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "{0} BETWEEN {1} AND {2}", 
       ColumnNameVerseIdSequence, 
       verseIdSequencePre,
       verseIdSequencePost  
      );
      break;
  
     default:
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount] = new StringBuilder();
      break; 
      
    }//switch ( sonInLaw )

    scriptureReferenceBookChapterPreVersePostSelect[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
    (
     SQLSelectScriptureReferenceWithoutBracket_VerseText,
     scriptureReferenceBookChapterPreVersePostCount,
     scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount].ToString()     
    );

    scriptureReferenceBookChapterPreVersePostQuery.Append
    ( 
     scriptureReferenceBookChapterPreVersePostSelect[scriptureReferenceBookChapterPreVersePostCount]
    );
    
    if ( scriptureReferenceBookChapterPreVersePostCount + 1 < scriptureReferenceBookChapterPreVersePostTotal )
    {
     scriptureReferenceBookChapterPreVersePostQuery.Append( SQLUnionAll );
    }//if ( scriptureReferenceBookChapterPreVersePostCount + 1 < scriptureReferenceBookChapterPreVersePostTotal )

    #if (DEBUG)   
     System.Console.WriteLine
     (
      "Scripture Reference Book Chapter Verse PrePost Condition [{0}]: {1}", 
      scriptureReferenceBookChapterPreVersePostCount,
      scriptureReferenceBookChapterPreVersePostCondition[scriptureReferenceBookChapterPreVersePostCount]
     );   
     System.Console.WriteLine
     (
      "Scripture Reference Book Chapter Verse PrePost Statement [{0}]: {1}", 
      scriptureReferenceBookChapterPreVersePostCount,
      scriptureReferenceBookChapterPreVersePostSelect[scriptureReferenceBookChapterPreVersePostCount]
     );   
    #endif
     
   }//for ( scriptureReferenceBookChapterPreVersePostCount = 0; scriptureReferenceBookChapterPreVersePostCount < scriptureReferenceBookChapterPreVersePostTotal; ++scriptureReferenceBookChapterPreVersePostCount );    

   scriptureReferenceBookChapterPreVersePostQuery.Append( SQLSelectScriptureReferenceClauseOrderBy );

   #if (DEBUG)   
    System.Console.WriteLine
    (
     "Scripture Reference Book Chapter Verse PrePost Query: {0}", 
     scriptureReferenceBookChapterPreVersePostQuery
    );   
   #endif
   
  }//public static string SQLStatementCondition( string databaseConnectionString, ref string exceptionMessage, ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost, ref StringBuilder[]                             scriptureReferenceBookChapterPreVersePostCondition, ref StringBuilder[] scriptureReferenceBookChapterPreVersePostSelect, ref StringBuilder scriptureReferenceBookChapterPreVersePostQuery ) 

  /// <summary>The SQLStatement Condition.</summary>
  /// <param name="databaseConnectionString">The database connection string.</param>    
  /// <param name="exceptionMessage">The exception message.</param>      
  /// <param name="scriptureReferenceBookChapterVersePrePost">The scripture reference book, chapter, verse, pre and post.</param>
  /// <param name="iDataReader">The data reader.</param>
  /// <param name="rowCount">Returns the number of rows affected by the last statement.</param>
  ///<param name="scriptureReferenceText">The scripture reference text.</param>
  /// <param name="scriptureReferenceBookChapterPreVersePostQuery">The SQL statement for the scripture reference book, chapter, verse, pre and post.</param>    
  /// <param name="commandType">The command type.</param>    
  public static void SQLStatementQuery
  (
       string                                       databaseConnectionString, 
   ref string                                       exceptionMessage,
   ref ScriptureReferenceBookChapterVersePrePost[]  scriptureReferenceBookChapterVersePrePost,
   ref IDataReader                                  iDataReader,
   ref int                                          rowCount,
   ref StringBuilder                                scriptureReferenceText,
       StringBuilder                                scriptureReferenceBookChapterPreVersePostQuery,
       CommandType                                  commandType
  )
  {

   int    resultSet                                      = -1;
   int    resultSetCurrent                               = -1;   

   int    scriptureReferenceBookChapterPreVersePostCount = 0;
   int    scriptureReferenceBookChapterPreVersePostTotal = scriptureReferenceBookChapterVersePrePost.Length;   

   string chapterIdVerseId                               = null;
   int    bookId                                         = -1;
   string bookTitleChapterId                             = null;   
   string bookTitleChapterIdCurrent                      = null;
   int    chapterId                                      = -1;
   int    verseId                                        = -1;
   string verseText                                      = null;
   
   scriptureReferenceText                                = new StringBuilder();

   UtilityDatabase.DatabaseQuery
   (
        databaseConnectionString,
    ref exceptionMessage,
    ref iDataReader,
        scriptureReferenceBookChapterPreVersePostQuery.ToString(),
        commandType
   );
   
   try
   {
    rowCount = 0;
    scriptureReferenceText.Append("<table align='center' border='0'><colgroup><col char=':'/></colgroup>");
    while ( iDataReader.Read() )
    {
     ++rowCount;
     resultSet                        = ( int )    iDataReader[ColumnNameResultSet];
     bookId                           = ( int )    iDataReader[ColumnNameBookId];
     chapterId                        = ( int )    iDataReader[ColumnNameChapterId];
     verseId                          = ( int )    iDataReader[ColumnNameVerseId];
     verseText                        = ( string ) iDataReader[ColumnNameVerseText];
  
     if ( resultSet != resultSetCurrent )
     {
      bookTitleChapterIdCurrent = null;
      resultSetCurrent = resultSet; 
      scriptureReferenceText.Append
      (
       System.String.Format
       (
        "<tr align='center'><th colspan='2'>{0}</th></tr>",
        scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount]
       )
      );  
      ++scriptureReferenceBookChapterPreVersePostCount;
     }//if ( resultSet != resultSetCurrent )     

     bookTitleChapterId = System.String.Format("{0} {1}", BibleBookTitle.BookTitle( bookId ), chapterId);

     if ( bookTitleChapterId != bookTitleChapterIdCurrent )
     {
      bookTitleChapterIdCurrent = bookTitleChapterId;
      scriptureReferenceText.Append
      (
       System.String.Format
       (
        "<tr align='left'><th colspan='2'>{0}</th><tr>",
        bookTitleChapterId
       )
      );  
     }//if ( bookTitleChapter != bookTitleChapterCurrent )

     chapterIdVerseId = System.String.Format("{0}:{1}", chapterId, verseId);
     scriptureReferenceText.Append
     (
      System.String.Format
      (
       "<tr><td>{0}</td><td>{1}</td><tr>",
       chapterIdVerseId,
       verseText
      )
     );  
    }//while ( iDataReader.Read() )    
   }//try
   catch (OleDbException exception)
   {
    //exceptionMessage = DisplayOleDbErrorCollection( exception );
    exceptionMessage = UtilityEventLog.WriteEntryOleDbErrorCollection( exception );
    System.Console.WriteLine("OLEDbException: {0}", exceptionMessage);
   }
   catch (Exception exception)
   {
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }//catch (Exception exception)
   scriptureReferenceText.Append("</table>");
   if ( rowCount == 0 )
   {
    scriptureReferenceText = new StringBuilder();
   }//if ( rowCount == 0 ) 
  }//public static string SQLStatementQuery( string databaseConnectionString, ref string exceptionMessage, ref IDataReader iDataReader, StringBuilder scriptureReferenceBookChapterPreVersePostQuery, CommandType commandType )

  /// <summary>XPath Condition.</summary>
  /// <param name="bibleXmlFilename">Bible XML filename.</param>
  /// <param name="exceptionMessage">The exception message.</param>      
  /// <param name="scriptureReferenceBookChapterVersePrePost">The array of scripture reference.</param>  
  public static void XPathCondition
  (
       string                                      bibleXmlFilename,   
   ref string                                      exceptionMessage,   
       ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost
  )
  {
   int                     preBibleBookId                                      = -1;
   int                     postBibleBookId                                     = -1;   
   int                     scriptureReferenceBookChapterPreVersePostCount      = -1;
   int                     scriptureReferenceBookChapterPreVersePostTotal      = scriptureReferenceBookChapterVersePrePost.Length;
   
   XmlAttributeCollection  xmlAttributeCollectionVerse                         = null;
   XmlDocument             xmlDocument                                         = null;
   XmlElement              xmlElementRoot                                      = null;
   XmlNodeList             xmlNodeListVerse                                    = null;
   
   StringBuilder[]         xPathScriptureReferenceBookChapterPreVersePost      = null;
   
   xPathScriptureReferenceBookChapterPreVersePost                              = new StringBuilder[scriptureReferenceBookChapterPreVersePostTotal];

   for 
   ( 
    scriptureReferenceBookChapterPreVersePostCount = 0; 
    scriptureReferenceBookChapterPreVersePostCount < scriptureReferenceBookChapterPreVersePostTotal;
    ++scriptureReferenceBookChapterPreVersePostCount
   )
   {

    xPathScriptureReferenceBookChapterPreVersePost[scriptureReferenceBookChapterPreVersePostCount] = new StringBuilder();
    
    preBibleBookId  = BibleBookTitle.IndexOf( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].preBookTitle  );
    postBibleBookId = BibleBookTitle.IndexOf( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].postBookTitle );
    
    switch ( scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].sonInLaw )
    {

     case SonInLawPreBookTitle: //1 Samuel. SELECT 0 As resultSet, chapterId, verseId, verseText, verseIdSequence FROM KJV (NoLock) WHERE bookId = 9 ORDER BY resultSet, verseIdSequence

      xPathScriptureReferenceBookChapterPreVersePost[scriptureReferenceBookChapterPreVersePostCount].AppendFormat
      (
       "//book[@{0} = '{1}']//verse[@{2}]", //"//book[@{0} = '{1}']//verse[@{2}]"
       ColumnNameBookId, 
       scriptureReferenceBookChapterVersePrePost[scriptureReferenceBookChapterPreVersePostCount].PreBookId,
       ColumnNameVerseText
      );
      #if (DEBUG)   
       System.Console.WriteLine
       (
        "Scripture Reference Book Chapter Verse PrePost XPath [{0}]: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        xPathScriptureReferenceBookChapterPreVersePost[scriptureReferenceBookChapterPreVersePostCount]
       );   
      #endif

      xmlDocument = new XmlDocument();
      xmlDocument.Load(bibleXmlFilename);

      xmlElementRoot   = xmlDocument.DocumentElement;
      xmlNodeListVerse = xmlElementRoot.SelectNodes(xPathScriptureReferenceBookChapterPreVersePost[scriptureReferenceBookChapterPreVersePostCount].ToString());

      #if (DEBUG)   
       System.Console.WriteLine
       (
        "Scripture Reference Book Chapter Verse PrePost XPath [{0}] Total: {1}", 
        scriptureReferenceBookChapterPreVersePostCount,
        xmlNodeListVerse.Count
       );   
      #endif

      foreach (XmlNode xmlNodeVerse in xmlNodeListVerse)
      {
       #if (DEBUG)   
        //System.Console.WriteLine( xmlNodeVerse.Attributes.Item(ColumnNameVerseText).Value );
        //System.Console.WriteLine( xmlNodeVerse.Attributes.Item(2).Value );
        xmlAttributeCollectionVerse = xmlNodeVerse.Attributes;
        foreach ( XmlAttribute xmlAttribute in xmlAttributeCollectionVerse )
        {
         if ( xmlAttribute.Name == ColumnNameVerseText )
         {
          System.Console.WriteLine( xmlAttribute.Value );
         }//if ( xmlAttribute.Name == ColumnNameVerseText )
        }//foreach ( XmlAttribute xmlAttribute in xmlAttributeCollection ) 	
       #endif
      }//foreach (XmlNode xmlNodeVerse in nodeList)
      break;

     case SonInLawPreBookTitlePreChapter: //2 Samuel 4. SELECT 0 As resultSet, bookId, chapterId, verseId, verseText, verseIdSequence FROM KJV (NoLock) WHERE bookId=10 AND chapterId=4
      break;

     case SonInLawPreBookTitlePreChapterPreVerse: //3 John 1:4. SELECT 0 As resultSet, bookId, chapterId, verseId, verseText, verseIdSequence FROM KJV (NoLock) WHERE bookId=64 AND chapterId=1 AND verseId=4    
      break;

     case SonInLawPreBookTitlePostBookTitle: //1 Peter - 1 John. 1 Peter 1-5, 2 Peter 1-3, 1 John 1-5.
      break;

     case SonInLawPreBookTitlePostBookTitlePostChapter: //1 Corinthians - Galatians 3. SELECT bookTitle, bookId, chapterId,  verseId, verseIdSequence, verseText FROM KJV ( NOLOCK ) WHERE verseIdSequence IN ( 28365, 29132 ) ORDER BY verseIdSequence
      break;

     case SonInLawPreBookTitlePostBookTitlePostChapterPostVerse: 
      break;

     case SonInLawPreBookTitlePreChapterPostBookTitle: 
      break;

     case SonInLawPreBookTitlePreChapterPostBookTitlePostChapter: 
      break;

     case SonInLawPreBookTitlePreChapterPostBookTitlePostChapterPostVerse: 
      break;

    case SonInLawPreBookTitlePreChapterPreVersePostBookTitle: 
      break;

     case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapter: 
      break;

     case SonInLawPreBookTitlePreChapterPreVersePostBookTitlePostChapterPostVerse: 
      break;

     case SonInLawPreBookTitlePreChapterPreVersePostChapterPostVerse: 
      break;

     case SonInLawPreBookTitlePreChapterPreVersePostVerse: 
      break;

     case SonInLawPreBookTitlePreChapterPostChapter: //Deuteronomy 6-20. http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&word=Deuteronomy+6-20&section=0&version=nkj&language=en
      break;

    case SonInLawPreBookTitlePreChapterPostChapterPostVerse: //Job 15-16:4.
      break;
 
     case SonInLawPreBookTitlePreChapterPreVersePostChapter:
      break;
  
     default:
      xPathScriptureReferenceBookChapterPreVersePost[scriptureReferenceBookChapterPreVersePostCount] = new StringBuilder();
      break; 
      
    }//switch ( sonInLaw )
   }//for ( scriptureReferenceBookChapterPreVersePostCount = 0; scriptureReferenceBookChapterPreVersePostCount < scriptureReferenceBookChapterPreVersePostTotal; ++scriptureReferenceBookChapterPreVersePostCount )
  }//public static string XPathCondition( ref string exceptionMessage, ScriptureReferenceBookChapterVersePrePost[] scriptureReferenceBookChapterVersePrePost ) 
  
 }//public class ScriptureReferenceBookChapterVersePrePost
}//namespace WordEngineering