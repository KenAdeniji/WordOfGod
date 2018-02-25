using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Data.OleDb;
using System.Web;
using System.Text;
using System.Xml;

namespace WordEngineering
{
 /// <summary>Gutenberg Korean뾇nglish Dictionary.</summary>
 /// <remarks>Gutenberg Korean뾇nglish Dictionary.</remarks>
 public class GutenbergKoreanEnglishDictionary
 {

  /// <summary>consonantFirst</summary>
  const  String   consonantFirst                        = "ㄱ k";
  
  ///<summary>The database connection String.</summary>  
  public static String   DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=Gutenberg;Integrated Security=SSPI;";

  /// <summary>DirectorynameSource</summary>
  public static  String   DirectorynameSource                   = "..\\ProjectGutenberg";

  /// <summary>EnglishAlphabet</summary>
  public const  String   EnglishAlphabet                       = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
  
  /// <summary>EnglishAlphabetAnyOf</summary>
  public static char[]   EnglishAlphabetAnyOf                  = EnglishAlphabet.ToCharArray();

  /// <summary>ExceptionMessage</summary>
  public static String   ExceptionMessage                      = null;
  
  /// <summary>FileSearchPattern</summary>
  public const  String   FileSearchPattern                     = "ProjectGutenberg_-_KoreanEnglishDictionary*.txt";

  /// <summary>KoreanConsonant</summary>
  public static String[][] KoreanConsonant                     = new String [][]
                                                          {
                                                           new String[] { "ㄱ", "k"  },
                                                           new String[] { "ㄲ", "kk" },
                                                           new String[] { "ㄴ", "n"  },
                                                           new String[] { "ㄷ", "t"  },
                                                           new String[] { "ㄸ", "tt" }, 
                                                           new String[] { "ㄹ", "l"  }, 
                                                           new String[] { "ㅁ", "m"  }, 
                                                           new String[] { "ㅂ", "p"  }, 
                                                           new String[] { "ㅃ", "pp" },
                                                           new String[] { "ㅅ", "s"  }, 
                                                           new String[] { "ㅆ", "ss" },
                                                           new String[] { "ㅇ", null },
                                                           new String[] { "ㅈ", "u{c" }, 
                                                           new String[] { "ㅊ", "c^h" }, 
                                                           new String[] { "ㅋ", "k^h" }, 
                                                           new String[] { "ㅌ", "t^h" }, 
                                                           new String[] { "ㅍ", "p^h" }, 
                                                           new String[] { "ㅎ", "h" }
                                                          };

  /// <summary>KoreanConsonantLength</summary>
  public static int KoreanConsonantLength                      = KoreanConsonant.Length;

  /// <summary>Korean Table Header Consonant</summary>
  public static String     KoreanTableHeaderConsonant          = "Korean Consonant";

  /// <summary>Korean Table Header Vowel</summary>
  public static String     KoreanTableHeaderVowel              = "Korean Vowel";
  
  /// <summary>Korean Vowel</summary>
  public static String[][] KoreanVowel                         = new String [][]
                                                          {
                                                           new String[] { "아", "a"  },
                                                           new String[] { "애", "ae" },
                                                           new String[] { "야", "ya"  },
                                                           new String[] { "얘", "yae"  },
                                                           new String[] { "어", "o" }, 
                                                           new String[] { "에", "e"  }, 
                                                           new String[] { "여", "yo"  }, 
                                                           new String[] { "예", "ye"  }, 
                                                           new String[] { "오", "o" },
                                                           new String[] { "와", "wa"  }, 
                                                           new String[] { "왜", "wae" },
                                                           new String[] { "요", "yo" },
                                                           new String[] { "우", "u" }, 
                                                           new String[] { "워", "wo" }, 
                                                           new String[] { "위", "wi" }, 
                                                           new String[] { "유", "yu" }, 
                                                           new String[] { "의", "uy" }, 
                                                           new String[] { "이", "i" }
                                                          };

  /// <summary>Korean Vowel Length</summary>
  public static int KoreanVowelLength                          = KoreanVowel.Length;
  
  /// <summary>PunctuationSymbol</summary>
  public const  String   PunctuationSymbol                     = "*%[(\"";
  
  /// <summary>PunctuationSymbolAnyOf</summary>  
  public static char[]   PunctuationSymbolAnyOf                = PunctuationSymbol.ToCharArray();

  ///<summary>The XPath for database connection String.</summary>  
  public const  String XPathDatabaseConnectionString               = @"/word/database/sqlServer/gutenberg/databaseConnectionString";  

  /// <summary>The XML configuration file.</summary>
  public static   String FilenameConfigurationXml  = @"WordEngineering.config";  

  /// <summary>HTML Table.</summary>
  const  String   HTMLTable                      = "<TABLE></TABLE>;";
  
  /// <summary>HTML Column.</summary>  
  const  String   HTMLTableColumn                = "<TD>{0}</TD>;";
  
  /// <summary>HTML Row.</summary>  
  const  String   HTMLTableRow                   = "<TR></TR>;";  
  
  /// <summary>SQLStatementDictionaryInsert.</summary>
  const  String   SQLStatementDictionaryInsert   = "SET IDENTITY_INSERT KoreanEnglish ON; INSERT KoreanEnglish( SequenceOrderId, Korean, English ) VALUES ( {0}, '{1}', '{2}' ); SET IDENTITY_INSERT KoreanEnglish OFF;";

  /// <summary>SQLStatementDictionarySelect.</summary>
  const  String   SQLStatementDictionarySelect   = "SELECT Korean, English FROM KoreanEnglish ( NOLOCK ) WHERE Korean LIKE '{0}' OR English LIKE '{1}';";

  /// <summary>SQLStatementDictionaryTruncate.</summary>
  const  String   SQLStatementDictionaryTruncate = "TRUNCATE TABLE KoreanEnglish; DBCC CHECKIDENT (KoreanEnglish, RESEED, 1)";
  
  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of arguments</param>
  public static void Main( String[] argv )
  {
   String        directorynameSource = Directory.GetCurrentDirectory();
   String        dictionaryWordQuery = null;
   String        exceptionMessage    = null;

   StringBuilder sbResultElement     = null;

   System.Console.WriteLine
   (
    "�: {0}",
    Char.GetUnicodeCategory("ㄱ", 0)
   );

   System.Console.WriteLine
   (
    "�: {0}",
    Char.GetUnicodeCategory("ㄱ", 1)
   );

   System.Console.WriteLine
   (
    "*: {0}",
    Char.GetUnicodeCategory("*", 0)
   );

   DictionaryTextFile
   ( 
    directorynameSource,
    FileSearchPattern
   );

   /*
   if ( argv.Length > 0 )
   {
   	dictionaryWordQuery = argv[0];
    Search
    ( 
         dictionaryWordQuery,
     ref exceptionMessage,
     ref sbResultElement
    );
   };//if ( argv.length > 0 ) 
   */

  }//main()

  /// <summary>The dictionary text file.</summary>
  /// <param name="directorynameSource">The directory name, source, for example, ..\\ProjectGutenberg.</param>
  /// <param name="fileSearchPattern">The file search pattern, for example. *.txt.</param>
  public static void DictionaryTextFile
  ( 
   String directorynameSource,
   String fileSearchPattern
  )
  {
  	
   int                                lineMaximumEnglish                            = -1;
   int                                lineNumber                                    = 0;
   int                                sequenceOrderId                               = 0;
   String                             filenameDictionary                            = null;
   String                             exceptionMessage                              = null;
   String                             line                                          = null;
           
   StringBuilder                      sbDictionary                                  = null;    
   StringBuilder                      SQLStatement                                  = null;  
   ArrayList                          arrayListDirectoryname                        = null;
   ArrayList                          arrayListFilename                             = null; 
   System.Collections.IEnumerator     enumeratorFilename                            = null;
   
   OleDbConnection                    oleDbConnection                               = null;
   
   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
   ( 
        DatabaseConnectionString, 
    ref exceptionMessage 
   );

   UtilityDatabase.DatabaseNonQuery
   (
        oleDbConnection,
    ref exceptionMessage,
        SQLStatementDictionaryTruncate
   );
   
   UtilityDirectory.Dir
   (
    ref DirectorynameSource,
    ref fileSearchPattern,
    ref arrayListDirectoryname,
    ref arrayListFilename
   );//UtilityDirectory.Dir

   enumeratorFilename = arrayListFilename.GetEnumerator();

   while ( enumeratorFilename.MoveNext() )
   {
   	filenameDictionary = (String) enumeratorFilename.Current;
    System.Console.WriteLine("{0}", filenameDictionary );
    sbDictionary = new StringBuilder();

    try 
    {
     // Create an instance of StreamReader to read from a file.
     // The using statement also closes the StreamReader.
     using (StreamReader sr = new StreamReader(filenameDictionary)) 
     {
      bool                    nonEnglish            = false;
      bool                    wordTranslate         = false;
      
      int                     indexEnglishAlphabet  = -1;
      int                     lineLength            = -1;
      int                     linePosition          = -1;
      
      String                  charCurrent           = null;
      
      StringBuilder           wordEnglish           = null;
      StringBuilder           wordKorean            = null;
      
      UnicodeCategory         unicodeCategoryCurrent;
      // Read and display lines from the file until the end of 
      // the file is reached.
      while ((line = sr.ReadLine()) != null) 
      {
       ++lineNumber;
       /*
       #if (DEBUG)
        System.Console.WriteLine
        (
         "Line #: {0} | {1}",
         lineNumber,
         line
        );
       #endif
       */

       line = line.Trim();
       lineLength = line.Length;
       if ( lineLength == 0 )
       {
       	continue;
       }

       if ( Array.IndexOf( PunctuationSymbolAnyOf, line[0] ) >= 0 )
       {
       	continue;
       }
       else if ( line[0] == ' ')
       {
        continue;
       }
       else if ( Char.IsLetter( line[0] ) )
       {
        continue;
       }
       else if ( line[1] == '.' || line[2] == '.')
       {
        continue;
       }
       #if (DEBUG)
        System.Console.WriteLine
        (
         "Char.IsLetterOrDigit\nLine #: {0} | {1}",
         lineNumber,         
         line
        );
       #endif
       
       indexEnglishAlphabet = line.IndexOfAny(EnglishAlphabetAnyOf);
       
       if ( indexEnglishAlphabet < 1 )
       {
       	continue;
       }	

       #if (DEBUG)
        System.Console.WriteLine("indexEnglishAlphabet: {0}", indexEnglishAlphabet);
       #endif

       if ( indexEnglishAlphabet < 1 )
       {
        continue;
       }
       
       nonEnglish             = false;
       unicodeCategoryCurrent = Char.GetUnicodeCategory(line, 0);

       switch ( unicodeCategoryCurrent )
       {
        case UnicodeCategory.DecimalDigitNumber:
         break;

        case UnicodeCategory.LowercaseLetter:
         break;

        case UnicodeCategory.UppercaseLetter:
          break;
          
        default:
         nonEnglish = true;
         break;  
          
       }

       #if (DEBUG)
        System.Console.WriteLine("if ( nonEnglish == false )");
       #endif

       if ( nonEnglish == false )
       {
       	continue;
       }       	 

       wordEnglish   = new StringBuilder();
       wordKorean    = new StringBuilder();

       wordKorean.Append(  line.Substring( 0, indexEnglishAlphabet - 1 ) );
       wordEnglish.Append( line.Substring( indexEnglishAlphabet ) );
       wordEnglish = wordEnglish.Replace("'", "''");

       if ( wordEnglish.Length > lineMaximumEnglish )
       {
        lineMaximumEnglish = lineLength;
       }        
       
       /*
       wordEnglish   = new StringBuilder();
       wordKorean    = new StringBuilder();
       wordTranslate = false;

       for ( linePosition = 0; linePosition < lineLength; ++linePosition )
       {
       	charCurrent = line.Substring( linePosition, 1 );
       	
       	if ( KoreanConsonant.Contains( line.Substring( linePosition, 2 ) )
       	{
         ++linePosition;
        }
         
        unicodeCategoryCurrent = Char.GetUnicodeCategory(line, linePosition);

        switch ( unicodeCategoryCurrent )
        {
         case UnicodeCategory.DecimalDigitNumber:
          wordTranslate = true;
          break;

         case UnicodeCategory.LowercaseLetter:
          wordTranslate = true;
          break;

         case UnicodeCategory.UppercaseLetter:
          wordTranslate = true;
          break;
        }
        
        if ( wordTranslate == false )
        {
         wordKorean.Append( charCurrent );        	
        }
        else
        {
         wordEnglish.Append( charCurrent );
        }
	  
       }//for ( linePosition = 0; linePosition < lineLength; ++linePosition )	
       */
       
       if ( wordKorean.Length == 0 || wordEnglish.Length == 0 )
       {
        continue;
       }               	

       ++sequenceOrderId;

       #if (DEBUG)
        System.Console.WriteLine
        (
         "SequenceOrderId: {0} | Korean: {1} | English: {2}",
         sequenceOrderId,
         wordKorean,
         wordEnglish
        );
       #endif

       SQLStatement = new StringBuilder();
       SQLStatement.AppendFormat
       (
        SQLStatementDictionaryInsert,
        sequenceOrderId,
        wordKorean,
        wordEnglish
       );
       
       /*
       #if (DEBUG)
        System.Console.WriteLine("SQL Statement: {0}", SQLStatement.ToString() );
       #endif
       */

       UtilityDatabase.DatabaseNonQuery
       (
            oleDbConnection,
        ref exceptionMessage,
            SQLStatement.ToString()
       );
       
      }//while ((line = sr.ReadLine()) != null)
     }//using (StreamReader sr = new StreamReader("TestFile.txt")) 
    }//try 
    catch (Exception e) 
    {
     System.Console.WriteLine
     (
      "Line #:{0} | Line: {1} | Exception: {2}", 
      lineNumber, 
      line,
      e.Message
     );
    }//catch (Exception e) 
   }//while ( enumeratorFilename.MoveNext() )

   UtilityDatabase.DatabaseConnectionHouseKeeping
   (
        oleDbConnection,
    ref exceptionMessage
   );

   #if (DEBUG)
    System.Console.WriteLine
    (
     "Line Maximum: {0}", 
     lineMaximumEnglish
    );
   #endif
   
  }//DictionaryTextFile()

  ///<summary>Search: Display the number of results.</summary>
  ///<param name="dictionaryWord">The dictionary word.</param>
  ///<param name="exceptionMessage">The exception message.</param>
  ///<param name="sbResultElement">The result element.</param>  
  public static void Search
  (
       String        dictionaryWord,
   ref String        exceptionMessage,
   ref StringBuilder sbResultElement
  )
  {
   DataSet              dataSet              = null;
   HttpContext          httpContext          = HttpContext.Current;
   OleDbConnection      oleDbConnection      = null;
   StringBuilder        SQLStatement         = null;     
   
   sbResultElement                           = new StringBuilder();
   
   oleDbConnection = UtilityDatabase.DatabaseConnectionInitialize
   ( 
         DatabaseConnectionString, 
     ref exceptionMessage 
   );

   SQLStatement = new StringBuilder();
   SQLStatement.AppendFormat
   (
     SQLStatementDictionarySelect,
     dictionaryWord
   );   

   #if (DEBUG)
    System.Console.WriteLine("SQL Statement: {0}", SQLStatement.ToString() );      
   #endif
    
   UtilityDatabase.DatabaseQuery
   ( 
        DatabaseConnectionString, 
    ref exceptionMessage, 
    ref dataSet, 
        SQLStatement.ToString(), 
        CommandType.Text
   );

   if ( httpContext != null && exceptionMessage != null )
   {
	httpContext.Response.Write( exceptionMessage );
   }//if ( httpContext != null )      
    
   foreach(DataTable dataTable in dataSet.Tables)
   {
    sbResultElement.Append("<TABLE align='center'>");    	
    foreach(DataRow dataRow in dataTable.Rows)
    {
     sbResultElement.Append("<TR>");
     /*
     foreach (DataColumn dataColumn in dataTable.Columns)
     {
      sbResultElement.AppendFormat
      (
       HTMLTableColumn, 
       dataRow[dataColumn] 
      );
     }//foreach (DataColumn dataColumn in dataTable.Columns) 
     */
     sbResultElement.AppendFormat
     (
      HTMLTableColumn, 
      dataRow["Commentary"] 
     );
     sbResultElement.Append("</TR>");
    }//foreach(DataRow dataRow in dataTable.Rows)
    sbResultElement.Append("</TABLE>");    	    
   }//foreach(DataTable dataTable in dataSet.Tables)

   #if (DEBUG)
    System.Console.WriteLine("{0}", sbResultElement );
   #endif

  }//Search()

  /// <summary>KoreanEnglish</summary>
  public static void KoreanEnglish
  (
   ref String[][]    koreanEnglishArray,
   ref StringBuilder sbKoreanEnglish,
   ref String        tableHeader
  )
  {
   sbKoreanEnglish = new StringBuilder();
   sbKoreanEnglish.AppendFormat("<table align=center border=1>");
   sbKoreanEnglish.AppendFormat("<thead>");
   sbKoreanEnglish.AppendFormat
   (
    "<tr><th colspan=2>{0}</th></tr>",
    tableHeader
   );
   sbKoreanEnglish.AppendFormat
   (
    "<tr><th>Korean</th><th>English</th></tr>"
   );
   sbKoreanEnglish.AppendFormat("</thead>");
   sbKoreanEnglish.AppendFormat("<tbody align=center>");
   foreach ( String[] koreanEnglish in koreanEnglishArray )
   {
    sbKoreanEnglish.AppendFormat
    (
     "<tr align=center><td>{0}</td><td>{1}</td></tr>",
     koreanEnglish[0],
     koreanEnglish[1] 
    );
   }//foreach ( String[] koreanEnglish in koreanEnglishArray )
   sbKoreanEnglish.AppendFormat("</tbody>");
   sbKoreanEnglish.AppendFormat("</table>");
  }//KoreanEnglish 

  /// <summary>Read the XML Configuration file.</summary>
  public static void ConfigurationXml()
  {  
   ConfigurationXml
   (
    ref FilenameConfigurationXml,
    ref ExceptionMessage,
    ref DatabaseConnectionString
   );
  }//public static void ConfigurationXml()

  /// <summary>Read the XML Configuration file.</summary>
  /// <param name="filenameConfigurationXml">The configuration XML filename.</param>  
  /// <param name="exceptionMessage">The exception message.</param>  
  /// <param name="databaseConnectionString">The database connection String, for example, "Provider=SQLOLEDB;Data Source=localhost;user id=WordEngineering;password=WordEngineering;Initial Catalog=Bible;"</param>  
  public static void ConfigurationXml
  (
   ref String filenameConfigurationXml,
   ref String exceptionMessage,
   ref String databaseConnectionString
  )
  {
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,
         XPathDatabaseConnectionString,
     ref databaseConnectionString
    );//ConfigurationXml()
  }//ConfigurationXml	 

  static GutenbergKoreanEnglishDictionary()
  {
   String       filenameConfigurationXml = FilenameConfigurationXml;
   String       serverMapPath            = null;
   HttpContext  httpContext              = HttpContext.Current;   

   if ( httpContext != null )   
   {
    serverMapPath = httpContext.Request.MapPath("");
    filenameConfigurationXml = serverMapPath + @"\" + filenameConfigurationXml;
   }

   ConfigurationXml();

  }//static()
  
 }//public class GutenbergKoreanEnglishDictionary.
}//namespace WordEngineering
