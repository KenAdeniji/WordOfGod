/*
Date Created:     20030225
REFERENCE:
 Hanspeter Mossenbok University of Linz (Austria): An Overview of Microsoft .NET and C#  http://www.cs.tut.fi/tapahtumat/olio2002/moesse.pdf

 Compile: 
 csc /out:bin/ScriptureReference.dll /target:library ScriptureReference.cs BibleBookTitle.cs 
*/

using  System;
using  System.Collections;
using  System.Web.UI;
using  System.Web.UI.WebControls;
using  System.Data;
using  System.Data.OleDb;
using  System.Data.SqlClient;
using  System.Text;

using  WordEngineering;

namespace WordEngineering
{
 public class ScriptureReferenceTextRetrievalPage : Page
 {
  protected Button    ButtonQuery;
  
  protected Label     LabelExceptionMessage;
  protected Label     LabelScriptureReferenceCrosswalkURIHtml;
  protected Label     LabelScriptureReferenceCrosswalkURIXml;  
  protected Label     LabelScriptureReferenceTextRetrieval;
  
  protected TextBox   TextBoxScriptureReferenceCrosswalkURIHtml;
  protected TextBox   TextBoxScriptureReferenceCrosswalkURIXml;  
  protected TextBox   TextBoxScriptureReferenceTextRetrieval;
  
  protected Repeater  RepeaterScriptureReferenceTextRetrieval;

  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   if (!Page.IsPostBack) 
   {
   } 
  }//Page_Load

  public void ApplyFilter_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   string                         exceptionMessage                    = null;
   string[]                       scriptureReference                  = new string[] 
                                                                        { 
                                                                          TextBoxScriptureReferenceTextRetrieval.Text.Trim()
                                                                        };
                                                                     
   string                          scriptureReferenceCrosswalkURIHtml = null;
   string                          scriptureReferenceCrosswalkURIXml  = null;
      
   ScriptureReferenceTextSubset[]  scriptureReferenceTextSubset       = null;

   //scriptureReferenceCrosswalkURI = ScriptureReference.ScriptureReferenceURICrosswalk( new string[] {"Genesis 1"} );   
   scriptureReferenceCrosswalkURIHtml = ScriptureReference.ScriptureReferenceURICrosswalkHtml(scriptureReference);
   TextBoxScriptureReferenceCrosswalkURIHtml.Text = scriptureReferenceCrosswalkURIHtml;

   scriptureReferenceCrosswalkURIXml = ScriptureReference.ScriptureReferenceURICrosswalkXml(scriptureReference);
   TextBoxScriptureReferenceCrosswalkURIXml.Text = scriptureReferenceCrosswalkURIXml;

   //TextBoxScriptureReferenceCrosswalkURIXml.SelectAll();
    
   //scriptureReferenceTextSubset = ScriptureReference.ScriptureReferenceText( new string[] {"Genesis 1"} );
   scriptureReferenceTextSubset = ScriptureReference.ScriptureReferenceText( scriptureReference, exceptionMessage );
   LabelExceptionMessage.Text = exceptionMessage;
   RepeaterScriptureReferenceTextRetrieval.DataSource = scriptureReferenceTextSubset;
   RepeaterScriptureReferenceTextRetrieval.DataBind();
  }//ApplyFilter_Click
 }//BibleScriptureReferenceTextRetrievalPage
}//WordEngineering namespace.