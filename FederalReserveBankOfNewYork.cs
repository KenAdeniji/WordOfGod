using System;
using System.IO;
using System.Net;
using System.Xml;

namespace WordEngineering
{
    /// <summary>http://devdistrict.com/codedetails.aspx?A=401</summary>
    public class FederalReserveBankOfNewYork
    {
        /// <summary>The entry point for the application.</summary>
        /// <param name="argv">A list of command line arguments</param>
        public static void Main(string[] argv)
        {
            GetXMLCurrencyRateData();
        }

        /// <summary>
        /// Get the noonrate for a huge list of currency types.
        /// The Federal Reserve Bank of New York offers currency rates in XML. You can easily grab them and use them in your applications with a bit of XML parsing. 
        /// The Federal Reserve Bank of New York offers currency information for USD, BRL, CAD, CNY, DKK, HKD, INR, JPY, MXN, NOK, SGD, ZAR, KRW, LKR, SEK, CHF, TWD, THB, and VEB. 
        /// </summary>
        public static void GetXMLCurrencyRateData()
        {
            //The URL needs the current month value so parse it to build the URL.            
            string month = (DateTime.Today.Month.ToString().Length==1?"0" + DateTime.Today.Month.ToString():DateTime.Today.Month.ToString());

            //Build the URL
            string url = "http://www.ny.frb.org/markets/fxrates/FXtoXML.cfm?FEXdate=" + DateTime.Today.Year.ToString() +"%2D" + month + "%2D" + DateTime.Today.Day.ToString() + "%2000%3A00%3A00%2E0&FEXtime=1200";

            //Create a WebClient to go get the XML.
            WebClient client = new WebClient();

            //Download the XML
            string xml = client.DownloadString(new Uri(url));

            //Load an XML document with the XML
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            //Create the namespace manager and populate it with each namespace from the XML document
            XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
            mgr.AddNamespace("msg", "http://www.SDMX.org/resources/SDMXML/schemas/v1_0/message");
            mgr.AddNamespace("common", "http://www.SDMX.org/resources/SDMXML/schemas/v1_0/common");
            mgr.AddNamespace("compact", "http://www.SDMX.org/resources/SDMXML/schemas/v1_0/compact");
            mgr.AddNamespace("cross", "http://www.SDMX.org/resources/SDMXML/schemas/v1_0/cross");
            mgr.AddNamespace("generic", "http://www.SDMX.org/resources/SDMXML/schemas/v1_0/generic");
            mgr.AddNamespace("query", "http://www.SDMX.org/resources/SDMXML/schemas/v1_0/query");
            mgr.AddNamespace("structure", "http://www.SDMX.org/resources/SDMXML/schemas/v1_0/structure");
            mgr.AddNamespace("utility", "http://www.SDMX.org/resources/SDMXML/schemas/v1_0/utility");
            mgr.AddNamespace("frbny", "http://www.newyorkfed.org/xml/schemas/FX/utility");

            //Find the series node
            XmlNodeList seriesNodes = doc.SelectNodes("//msg:UtilityData/frbny:DataSet/frbny:Series", mgr);

            //loop though each series node to get the values
            foreach (XmlNode series in seriesNodes)
            {
                //Pull out the values
                string to = series.SelectSingleNode("@UNIT", mgr).InnerText;
                string from = series.SelectSingleNode("frbny:Key/frbny:CURR", mgr).InnerText;
                decimal curValue = Convert.ToDecimal(series.SelectSingleNode("frbny:Obs/frbny:OBS_VALUE", mgr).InnerText);

                //Write the values to the console.
                Console.WriteLine("Currency Name: {0}  =  {1}", to, curValue);
            }
        }    
    }
} 








