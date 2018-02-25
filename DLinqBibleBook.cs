using System;
using System.Query;

namespace WordEngineering
{
    /// <summary>
    /// Summary description for BibleBook
    /// bookId      bookTitle   chapters    chapterLastVerseLast verseIdSequenceFirst verseIdSequenceLast
    /// </summary>
    [Table(Name="BibleBook")]
    public partial class DLinqBibleBook
    {
        public const string ConnectionString = "server=.;initial catalog=WordEngineering";
        
        [Column(Id=true)]
        int bookID;

        [Column]
        string bookTitle;

        /// <summary>
        /// The number of chapters in this bible book.
        /// </summary>
        [Column]
        int chapters;

        /// <summary>
        /// The last chapter's last verse.
        /// </summary>
        [Column]
        int chapterLastVerseLast;

        /// <summary>
        /// The verse ID sequence for the first chapter in this bible book.
        /// </summary>
        [Column]
        int verseIdSequenceFirst;

        /// <summary>
        /// The verse ID sequence for the last chapter and last verse in this bible book.
        /// </summary>
        [Column]
        int verseIdSequenceLast;

        /// <summary>The entry point for the application.</summary>
        /// <param name="argv">A list of command line arguments</param>
        public static void Main
        (
          String[] argv
        )
        {
            // DataContext takes a connection string
            DataContext db = new DataContext(ConnectionString);

            // Get a typed table to run queries
            Table<BibleBook> bibleBooks = db.GetTable<BibleBook>();

            //Query for book title equal to King
            var q =
                from b in BibleBooks
                where b.bookTitle == "1 Kings"
                select b;

            foreach (var book in q)
            {
                System.Console.WriteLine
                (
                    "ID: {0} | Title: {1}",
                    book.bookID,
                    book.bookTitle
                );
            }
        }

    }
}