using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;

using SpeechTypeLib;

namespace WordEngineering
{
    public static partial class ScriptureAudio
	{
		/// <summary>The database connection string.</summary>
		public static string DatabaseConnectionString           		= @"Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Bible;";

		/// <summary>The configuration XML filename.</summary>
		public static string filenameConfigurationXml                   = @"WordEngineering.config";

		/// <summary>The XPath database connection string.</summary>
		public const string   XPathDatabaseConnectionString             = @"/word/database/sqlServer/wordEngineering/databaseConnectionString";
		
		public static void Main(string[] argv)
		{
			int                                          scriptureReferenceVerseCount                       = -1;
			string                                       exceptionMessage                                   = null;
			string                                       scriptureReference                                 = null;
			string[][]                                   scriptureReferenceArray                            = null;

			StringBuilder                                scriptureReferenceText                             = null;  
			StringBuilder                                uriCrosswalkHtml                                   = null;
			StringBuilder                                uriCrosswalkXml                                    = null;   
			StringBuilder[]                              scriptureReferenceBookChapterVersePrePostCondition = null;
			StringBuilder[]                              scriptureReferenceBookChapterVersePrePostSelect    = null;
			StringBuilder                                scriptureReferenceBookChapterVersePrePostQuery     = null;

			IDataReader                                  iDataReader                                        = null;
			ScriptureReferenceBookChapterVersePrePost[]  scriptureReferenceBookChapterVersePrePost          = null;
			
			if ( argv.Length < 1 ) 
			{ 
				return;
			} 
			else
			{
				scriptureReference = argv[0];
			}
			
			ScriptureReference.ConfigurationXml
			(
				filenameConfigurationXml,
				ref exceptionMessage,
				ref DatabaseConnectionString
			);
			
			System.Console.WriteLine(DatabaseConnectionString);
			
			ScriptureReference.ScriptureReferenceParser
			(  
				new string[] { scriptureReference },
				DatabaseConnectionString,
				ref exceptionMessage,
				ref scriptureReferenceBookChapterVersePrePost,
				ref scriptureReferenceArray,
				ref uriCrosswalkHtml,
				ref uriCrosswalkXml
			);
			
			ScriptureReference.ScriptureReferenceQuery
			(
					DatabaseConnectionString,
				ref exceptionMessage,
				ref scriptureReferenceBookChapterVersePrePost,
				ref iDataReader,
				ref scriptureReferenceVerseCount,
				ref scriptureReferenceText,
				ref scriptureReferenceBookChapterVersePrePostCondition,
				ref scriptureReferenceBookChapterVersePrePostSelect,
				ref scriptureReferenceBookChapterVersePrePostQuery
			);

			if ( iDataReader != null )
			{
				iDataReader.Close();
			}

			DataSet dataSet = new DataSet();
			
			UtilityDatabase.DatabaseQuery
			(
					DatabaseConnectionString,
				ref exceptionMessage,
				ref dataSet,
					scriptureReferenceBookChapterVersePrePostQuery.ToString(),
					CommandType.Text
			);
			
			StringBuilder sbScriptureReferenceVerseText = new StringBuilder();
			
			foreach ( DataTable dataTable in dataSet.Tables )
			{
				foreach ( DataRow dataRow in dataTable.Rows )
				{
					sbScriptureReferenceVerseText.Append(dataRow["verseText"]);
				}
			}			
			
			System.Console.WriteLine(sbScriptureReferenceVerseText);
						
			SpVoice spVoice = new SpVoice();
			spVoice.Speak
			(
				sbScriptureReferenceVerseText.ToString(),
				SpeechVoiceSpeakFlags.SVSFlagsAsync
			);
			spVoice.WaitUntilDone(Timeout.Infinite);
		}
	}
}
/*
SpVoice objSpeech = new SpVoice();
objSpeech.Speak(textBox1.Text,SpeechVoiceSpeakFlags.SVSFlagsAsync);
objSpeech.WaitUntilDone(Timeout.Infinite); 
*/