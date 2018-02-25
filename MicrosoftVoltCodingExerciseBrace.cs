using System;
using System.Text;

public class MicrosoftVoltCodingExerciseBrace
{
 public static char[][] Brace = {
									new char[]	{	'(', ')'	},
									new char[]	{	'[', ']'	},
									new char[]	{ 	'{', '}'	}
								};
								
 public static String[] Equations = {
										"[(1+2)-{3+1}]",
										"[1+2)-{3+1}]",
										"[(1+2)-{3+1}]-[(3+2)]",
										"[(1+2)-{3+1}]-(5+2)]",										
										"[(1+2)*(3-2)-{3+1}]",										
									};
 public static void Main(string[] argv)
 {
  foreach(string equation in Equations)
  {
	System.Console.WriteLine("{0} = {1}", equation, Equation(equation));
  }		
 } 
 public static bool Equation(string equation)
 {
  int braceIndexOf = -1;
  int equationBraceIndex = 0;
  int oppositeIndexOf = -1;
  String braces;
  String equationBraces;
  StringBuilder brace = new StringBuilder();
  StringBuilder equationBrace = new StringBuilder();
  for (int braceRow = 0; braceRow < Brace.Length; ++braceRow )
  {
   for (int braceColumn = 0; braceColumn < Brace[braceRow].Length; ++braceColumn)
   {
    brace.Append(Brace[braceRow][braceColumn]);
   }
  }
  braces = brace.ToString();
  for (int index = 0; index < equation.Length; ++index)
  {
   //Check for braces
   braceIndexOf = braces.IndexOf(equation[index]);
   //If not a brace, continue
   if ( braceIndexOf == -1 ) 
   { 
	continue; 
   }
   equationBrace.Append(equation[index]);
  }
  equationBraces = equationBrace.ToString();
  if ((equationBraces.Length % 2) == 1) { return false; }
  equationBraceIndex = 0;
  while ( true )
  {
   if ( equationBraces == "" ) {break;}
   braceIndexOf = braces.IndexOf(equationBraces[equationBraceIndex]);
   if ( braceIndexOf % 2 == 1 )
   {
    return false;
   }
   oppositeIndexOf = equationBraces.IndexOf(braces[braceIndexOf+1], equationBraceIndex);
   if ( oppositeIndexOf == -1 )
   {
    return false;
   }
   equationBraces = equationBraces.Remove( equationBraceIndex, 1 );
   equationBraces = equationBraces.Remove( oppositeIndexOf - 1, 1 );
  }
  return( true );
 }
}