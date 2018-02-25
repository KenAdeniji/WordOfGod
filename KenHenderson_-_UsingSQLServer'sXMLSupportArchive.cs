using System.Xml;

namespace WordEngineering
{
	public static partial class KenHendersonUsingSQLServersXMLSupport
	{
		public static string Songs = @"<Songs> " +
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
	            
        	}

		public static void Stub
		(
			ref string xmlFragment,
			ref string xPathExpression;
		)
		{		
			/*
			XmlDocument xmlDoc = new XmlDocument();
			XmlNode root = xmlDocument.DocumentElement;
			XmlNodeList nodeList;						
			XmlNode root = doc.DocumentElement;
			*/

			/*
			if (xmlFragment.Length == 0)
			{
				xmlFragment = Songs;
			}
			xmlDoc.LoadXml(doc);
			if (xPathExpression.Length == 0)
			{
				xPathExpression = XPathExpression;
			}
			nodeList=root.SelectNodes(xPathExpression);
			*/
		}
	}
}


/*
   XmlDocument doc = new XmlDocument();
    doc.Load("booksort.xml");

    XmlNodeList nodeList;
    XmlNode root = doc.DocumentElement;

    nodeList=root.SelectNodes("descendant::book[author/last-name='Austen']");
*/
/*
 If Not xmlDoc.loadXML(Text1.Text) Then
    MsgBox "Error loading document"
  Else
    Dim oNodes As IXMLDOMNodeList
    Dim oNode As IXMLDOMNode

    If Len(Text2.Text) = 0 Then
      Text2.Text = "//Song"
    End If
    Set oNodes = xmlDoc.selectNodes(Text2.Text)

    For Each oNode In oNodes
      If Not (oNode Is Nothing) Then
        sName = oNode.nodeName
        sData = oNode.xml
        MsgBox "Node <" + sName + ">:" _
            + vbNewLine + vbTab + sData + vbNewLine
      End If
    Next

    Set xmlDoc = Nothing
  End If
*/