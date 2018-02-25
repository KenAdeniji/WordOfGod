using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Services.Protocols;

using CommandLine;

namespace WordEngineering
{

    public class AmazonSearchArgument
    {
        public string accessKeyID;
        public string keyword;
        public string locale;
        public string mode;
        public string page;
        public string sort;
        public string type;

        [DefaultArgumentAttribute(ArgumentType.MultipleUnique)]
        public string[] files;

        public AmazonSearchArgument() : this
        (
            AmazonSearch.AccessKeyID,
            AmazonSearch.Keyword,
            AmazonSearch.Locale,
            AmazonSearch.Mode,
            null, //Page
            AmazonSearch.Sort,
            AmazonSearch.Type
        )
        {
        }

        public AmazonSearchArgument
        (
            string accessKeyID,
            string keyword,
            string locale,
            string mode,
            string page,
            string sort,
            string type
        )
        {
            this.accessKeyID = accessKeyID;
            this.keyword = keyword;
            this.locale = locale;
            this.mode = mode;
            this.page = page;
            this.sort = sort;
            this.type = type;
        }

        public string AccessKeyID
        {
            get { return accessKeyID; }
            set { accessKeyID = value; }
        }

        public string Keyword
        {
            get { return keyword; }
        }

        public string Locale
        {
            get { return locale; }
        }

        public string Mode
        {
            get { return mode; }
        }

        public string Page
        {
            get { return page; }
        }

        public string Sort
        {
            get { return sort; }
        }

        public string Type
        {
            get { return type; }
        }

        public override string ToString()
        {
            string amazonSearchArgument = String.Format
                (
                    "Access Key ID: {0} | Keyword: {1} | Locale: {2} | Mode: {3} | Page: {4} | Sort: {5} | Type: {6}",
                    AccessKeyID,
                    Keyword,
                    Locale,
                    Mode,
                    Page,
                    Sort,
                    this.Type
                );
            return amazonSearchArgument;
        }
    }

    /// <remarks>
    /// Download album art for free through a web service by Mads Kristensen http://www.madskristensen.dk/blog/CommentView,guid,e9bfbe23-0c1a-4e48-8df2-9a9e0885c950.aspx
    /// Peter Bernhardt Coding4Fun Using the Amazon Web Service http://msdn.microsoft.com/coding4fun/web/services/article.aspx?articleid=912260
    /// Amazon web service http://soap.amazon.com/schemas3/AmazonWebServices.wsdl
    /// Google Search: C#, Finding the Locale Request.UserLanguages http://www.kinlan.co.uk/2006/03/google-search-c-finding-locale.html
    ///     Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);
    ///     If it is a Winform or Service you could get the Current Culture just by inspecting either:
    ///         Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
    ///         Thread.CurrentThread.CurrentCulture.ThreeLetterISOLanguageName;
    ///         Thread.CurrentThread.CurrentCulture.ThreeLetterWindowsLanguageName
    ///         Thread.CurrentThread.CurrentCulture.EnglishName;
    ///         Thread.CurrentThread.CurrentCulture.DisplayName;
    /// </remarks>
    public class AmazonSearch
    {
        public static readonly string AccessKeyID;
        public const string Keyword = "Prince";
        public const string Locale = "us";
        public static readonly string[] Locales = { 
            "ja",
            "uk",
            "us" 
        };
        public const string Mode = "Music"; //Books, Music, DVDs
        public const string Sort = "reviewrank";
        public const string Type = "lite";

        static AmazonSearch()
        {
            AccessKeyID = ConfigurationManager.AppSettings["accessKeyID"];
        }

        /// <summary>The entry point for the application.</summary>
        /// <param name="argv">A list of arguments</param>
        public static void Main( string[] argv )
        {
            bool parseCommandLineArguments;
            AmazonSearchArgument amazonSearchArgument = new AmazonSearchArgument();
            parseCommandLineArguments = Parser.ParseArgumentsWithUsage(argv, amazonSearchArgument);
            if (parseCommandLineArguments == false) { return; }
            KeywordSearchRequestStub(amazonSearchArgument);
        }

        public static void KeywordSearchRequestStub(AmazonSearchArgument amazonSearchArgument)
        {
            KeywordRequest keywordRequest = new KeywordRequest();

            if (string.IsNullOrEmpty(amazonSearchArgument.AccessKeyID))
            {
                amazonSearchArgument.AccessKeyID = AccessKeyID;
            }

            System.Console.WriteLine(amazonSearchArgument);

            keywordRequest.devtag = amazonSearchArgument.AccessKeyID;
            keywordRequest.keyword = amazonSearchArgument.Keyword;
            keywordRequest.locale = amazonSearchArgument.Locale;
            keywordRequest.mode = amazonSearchArgument.Mode;
            keywordRequest.page = amazonSearchArgument.Page;
            keywordRequest.sort = amazonSearchArgument.Sort;
            //keywordRequest.tag
            keywordRequest.type = amazonSearchArgument.Type;
            
            return;

            using (AmazonSearchService amazonSearchService = new AmazonSearchService())
            {
                try
                {
                    ProductInfo productInfo = amazonSearchService.KeywordSearchRequest(keywordRequest);
                    if (productInfo.Details.Length > 0)
                    {
                        System.Console.WriteLine(productInfo.Details[0].ProductName);
                        String url = productInfo.Details[0].ImageUrlLarge;
                        using (WebClient webClient = new WebClient())
                        {
                            webClient.DownloadFile(url, @"c:" + "/" + "Prince" + ".jpg");
                            /*
                             WebRequest webReq = WebRequest.Create(productInfo.Details[0].ImageUrlMedium);
                             WebResponse webResp = webReq.GetResponse();
                             _image = Image.FromStream(webResp.GetResponseStream());* 
                            */
                        }
                    }
                }
                catch (SoapException)
                {
                }
            }
        }
    }
}
