using skmDataStructures.Graph;

namespace WordEngineering
{
 /// <summary>TreeGraph.</summary>
 /// <remarks>TreeGraph.</remarks>
 public class TreeGraph
 {
  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of arguments</param>
  public static void Main( string[] argv )
  {
   Graph graph = new Graph();
   graph.AddNode("Privacy.htm", null);
   graph.AddNode("People.aspx", null);
   graph.AddNode("About.htm", null);
   graph.AddNode("Index.htm", null);
   graph.AddNode("Products.aspx", null);
   graph.AddNode("Contact.aspx", null);
   
   graph.AddDirectedEdge("People.aspx", "Privacy.htm");  // People -> Privacy

   graph.AddDirectedEdge("Privacy.htm", "Index.htm");    // Privacy -> Index
   graph.AddDirectedEdge("Privacy.htm", "About.htm");    // Privacy -> About

   graph.AddDirectedEdge("About.htm", "Privacy.htm");    // About -> Privacy
   graph.AddDirectedEdge("About.htm", "People.aspx");    // About -> People
   graph.AddDirectedEdge("About.htm", "Contact.aspx");   // About -> Contact

   graph.AddDirectedEdge("Index.htm", "About.htm");      // Index -> About
   graph.AddDirectedEdge("Index.htm", "Contact.aspx");   // Index -> Contacts
   graph.AddDirectedEdge("Index.htm", "Products.aspx");  // Index -> Products

   graph.AddDirectedEdge("Products.aspx", "Index.htm");  // Products -> Index
   graph.AddDirectedEdge("Products.aspx", "People.aspx");// Products -> People
  }//public static void Main( string[] argv )
 }//public class TreeGraph
}//namespace WordEngineering 


