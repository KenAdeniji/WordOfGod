using System.Xml;

namespace WordEngineering
{
	public static partial class KenHendersonUsingSQLServersXMLSupport
	{
		public static string XmlFragment = @"<Songs> " +
	                "<Song>One More Day</Song>" +
        	        "<Song>Hard Habit to Break</Song>" +
                	"<Song>Forever</Song>" +
	                "<Song>Boys of Summer</Song>" +
        	        "<Song>Cherish</Song>" +
                	"<Song>Dance</Song>" +
	                "<Song>I Will Always Love You</Song>" +
        		"</Songs>";

		public static string XPathExpression = @"//Song";

        	/// <summary>The entry point for the application.</summary>
        	/// <param name="argv">A list of command line arguments</param>
        	public static void Main
	        (
        	  string[] argv
	        )
        	{
                Stub(XmlFragment, XPathExpression);
        	}

		public static void Stub
		(
			string xmlFragment,
			string xPathExpression
		)
		{		
			XmlDocument xmlDocument = new XmlDocument();
			XmlNodeList nodeList;						

			if (xmlFragment.Length == 0)
			{
				xmlFragment = XmlFragment;
			}

			xmlDocument.LoadXml(xmlFragment);
			if (xPathExpression.Length == 0)
			{
				xPathExpression = XPathExpression;
			}
			nodeList=xmlDocument.SelectNodes(xPathExpression);
			foreach(XmlNode xmlNode in nodeList)
			{
				System.Console.WriteLine
				(
					"Node <{0}>:{1}{2}{3}",
					xmlNode.Name,
					System.Environment.NewLine,
					(char)9, //Horizontal tab
                    xmlNode.InnerXml
				);
			}
			
		}
	}
}