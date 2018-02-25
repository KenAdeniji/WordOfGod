using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

using  WordEngineering;

namespace WordEngineering
{

 /// <summary>DataColumnField.</summary>
 public enum DataColumnField : int
 {   
  /// <summary>Bound</summary>
  Bound = 0,

  /// <summary>Template</summary>  
  Template = 1,

  /// <summary>TextBox</summary>
  TextBox = 2

 }  

 public class DataGridTemplate : ITemplate
 {
   ListItemType templateType;
   string columnName;
   
   public DataGridTemplate(ListItemType type, string colname)
   {
      templateType = type;
      columnName = colname;
   }

   public void InstantiateIn(System.Web.UI.Control container)
   {
      Literal                            literal = new Literal();
      System.Web.UI.WebControls.TextBox  textBox = new System.Web.UI.WebControls.TextBox();
      switch(templateType)
      {
         case ListItemType.Header:
            literal.Text = "<B>" + columnName + "</B>";
            container.Controls.Add(literal);
            break;
         case ListItemType.Item:
            /*
            literal.Text = "Item " + columnName;
            container.Controls.Add(literal);
            */
            
            textBox.Text = "<%# Bind(" + '"' + columnName + '"' + ")%>" ;
            container.Controls.Add(textBox);
            break;
         case ListItemType.EditItem:
            textBox.Text = "";

            textBox.Text = "<%# Bind(" + '"' + columnName + '"' + ")%>" ;

            container.Controls.Add(textBox);
            break;
         case ListItemType.Footer:
            literal.Text = "<I>" + columnName + "</I>";
            container.Controls.Add(literal);
            break;
      }
   }
 }

 /// <summary>TheWordPage page.</summary>
 /// <remarks>TheWordPage page.</remarks>
 public class TheWordPage : Page
 {

  /// <summary>DataColumnFieldGridView</summary>
  //public DataColumnField DataColumnFieldGridView        = DataColumnField.Bound;
  //public DataColumnField DataColumnFieldGridView        = DataColumnField.Template;
  public DataColumnField DataColumnFieldGridView          = DataColumnField.TextBox;

  /// <summary>The database connection string.</summary>
  public String          databaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=WordEngineering;";
  
  /// <summary>The configuration XML filename.</summary>
  public String          filenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The root node.</summary>
  public String          nodeRoot                       = @"wordOfGod";

  /// <summary>The server map path.</summary>
  public String          serverMapPath                  = null;

  /// <summary>The server map path.</summary>
  public String          CrosswalkBibleURI              = "http://bible.crosswalk.com";

  /// <summary>The button for new.</summary>
  protected System.Web.UI.WebControls.Button      ButtonNew;

  /// <summary>The button for open.</summary>
  protected System.Web.UI.WebControls.Button      ButtonOpen;

  /// <summary>The button for save.</summary>
  protected System.Web.UI.WebControls.Button      ButtonSave;

  /// <summary>The GridView.</summary>
  protected System.Web.UI.WebControls.GridView[]  GridViewTheWord;

  /// <summary>The LinkButton insert.</summary>
  protected System.Web.UI.WebControls.LinkButton[] linkButtonAdd;

  /// <summary>The exception message.</summary>  
  protected System.Web.UI.WebControls.Literal     LiteralFeedback;
  
  /// <summary>The Crosswalk URI HTML.</summary>  
  protected System.Web.UI.WebControls.LinkButton   LinkButtonTheWordScriptureReferenceCrosswalkURIHTML;
  
  /// <summary>The Crosswalk URI XML.</summary>
  protected System.Web.UI.WebControls.LinkButton   LinkButtonTheWordScriptureReferenceCrosswalkURIXML;  

  /// <summary>The PlaceHolder GridView.</summary>
  protected System.Web.UI.WebControls.PlaceHolder PlaceHolderGridView;  

  /// <summary>The TheWord.</summary>
  protected TheWord                               theWord = null;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
  
   String    exceptionMessage = null;
  
   serverMapPath = this.MapPath("");
   if ( serverMapPath != null)
   {
    filenameConfigurationXml = serverMapPath + @"\" + filenameConfigurationXml;
   }//if ( serverMapPath != null)
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,         
         TheWord.XPathDatabaseConnectionString,
     ref databaseConnectionString
   );
   UtilityXml.XmlDocumentNodeInnerText
   (
         filenameConfigurationXml,
     ref exceptionMessage,         
         TheWord.XPathNodeRoot,
     ref nodeRoot
   );
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 

   // Check to see if the cookies have already been saved for this session.
   if (Session["theWord"] == null)
   { 
    theWord = new TheWord();
   }
   else
   { 
    theWord = (TheWord) Session["theWord"];
   }

   switch ( DataColumnFieldGridView )
   {
   	case DataColumnField.Bound:
     PageBuild();
     break;

   	case DataColumnField.Template:
     PageBuild();
     break;

   	case DataColumnField.TextBox:
     PageBuildTextBox();
     break;
   }
   
   // Store the cookies received in the session state for future retrieval by this session.
   Session["theWord"] = theWord;

  }//Page_Load
  
  /// <summary>PageBuild().</summary>
  public void PageBuild()
  {

   int          dataTableCount                = -1;
   int          dataTableTotal                = -1;
   int          theWordIdColumnIndex          = 0;

   DateTime     dated                         = DateTime.Now;

   System.Web.UI.WebControls.Label            label  =  null;
   
   String       columnNameForeignKey          = null;
   String       exceptionMessage              = null;
   String[]     sourceName                    = null;
   String[]     sourceSQL                     = null;
   String       tableName                     = null;

   System.Web.UI.WebControls.TextBox          textBox  =  null;
   
   XmlNodeList  sourceXML                     = null;

   TheWord.SourceSQLQuery
   (
        filenameConfigurationXml,
    ref exceptionMessage,
    ref sourceXML,
    ref sourceSQL,
    ref sourceName
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 
   
   if ( !Page.IsPostBack )
   {

    theWord.DataSetInitialize
    (
         databaseConnectionString,
     ref exceptionMessage,
         nodeRoot,
         sourceSQL,
         sourceName
    );

    if ( exceptionMessage != null )
    {
     Feedback = exceptionMessage;
     return;
    }//if ( exceptionMessage != null ) 
          	
   }//if ( Page.IsPostBack )

    UtilityXml.XmlDocumentNodeInnerText
    (
         filenameConfigurationXml,
     ref exceptionMessage,         
         TheWord.XPathColumnForeign,
     ref columnNameForeignKey
    );

   dataTableTotal           = theWord.DataSetTheWord.Tables.Count;

   GridViewTheWord          = new System.Web.UI.WebControls.GridView[ dataTableTotal ];
   linkButtonAdd            = new System.Web.UI.WebControls.LinkButton[ dataTableTotal ];

   for( dataTableCount = 0; dataTableCount < theWord.DataSetTheWord.Tables.Count; ++dataTableCount )
   {
   	theWord.DataSetTheWord.Tables[dataTableCount].TableName = sourceName[dataTableCount];
   }

   dataTableCount = -1;

   foreach( DataTable dataTable in theWord.DataSetTheWord.Tables )
   {
    ++dataTableCount;
    
    GridViewTheWord[dataTableCount]                           = new System.Web.UI.WebControls.GridView();
    
    tableName                                                 = dataTable.TableName;

    GridViewTheWord[dataTableCount].BorderWidth               = 1;
    GridViewTheWord[dataTableCount].CellPadding               = 1;
    GridViewTheWord[dataTableCount].DataSource                = dataTable;

    GridViewTheWord[dataTableCount].AllowPaging               = true;
    GridViewTheWord[dataTableCount].AllowSorting              = true;    

    GridViewTheWord[dataTableCount].AutoGenerateColumns       = false;
      
    GridViewTheWord[dataTableCount].AutoGenerateDeleteButton  = true;    
    GridViewTheWord[dataTableCount].AutoGenerateEditButton    = true;
    GridViewTheWord[dataTableCount].AutoGenerateSelectButton  = true;

    switch ( DataColumnFieldGridView )
    {
     case DataColumnField.Bound:

      foreach( DataColumn dataColumn in dataTable.Columns )
      {
       BoundField boundField      = null;
       boundField                 = new BoundField();
       boundField.DataField       = dataColumn.ColumnName;
       boundField.HeaderText      = dataColumn.ColumnName;
       boundField.SortExpression  = dataColumn.ColumnName;
       GridViewTheWord[dataTableCount].Columns.Add( boundField );
      }
      break;

     case DataColumnField.Template:
      foreach( DataColumn dataColumn in dataTable.Columns )
      {
       TemplateField                    templateField    = null;
       //System.Web.UI.WebControls.Label  label            = null;
       
       templateField                     = new TemplateField();
      
       templateField.HeaderText          = dataColumn.ColumnName;
       templateField.SortExpression      = dataColumn.ColumnName;
       
       //templateField.EditItemTemplate    = new DataGridTemplate(ListItemType.EditItem,  dataColumn.ColumnName);       
       //templateField.FooterTemplate    = new DataGridTemplate(ListItemType.Footer,    dataColumn.ColumnName);
       //templateField.HeaderTemplate    = new DataGridTemplate(ListItemType.Header,    dataColumn.ColumnName);
       templateField.ItemTemplate      = new DataGridTemplate(ListItemType.Item,      dataColumn.ColumnName);

       GridViewTheWord[dataTableCount].Columns.Add( templateField );
      }
      break;

     case DataColumnField.TextBox:
      PlaceHolderGridView.Controls.Add
      ( 
       new LiteralControl
       (
        "<b>" + tableName + "</b><br />"
       ) 
      );

      foreach( DataColumn dataColumn in dataTable.Columns )
      {
       label         =  new System.Web.UI.WebControls.Label(); 
       //label.Id      =  dataColumn.ColumnName;
       label.Text    =  dataColumn.ColumnName + ": ";
       PlaceHolderGridView.Controls.Add( label );
                     
       textBox       =  new System.Web.UI.WebControls.TextBox();
       //textBox.Name  =  dataColumn.ColumnName;
       textBox.Text  =  dataColumn.ColumnName;
       PlaceHolderGridView.Controls.Add( textBox );
       
       label         =  new System.Web.UI.WebControls.Label(); 
       label.Text    =  "<br />";
       PlaceHolderGridView.Controls.Add( label );

      }
      break;

    }  

    GridViewTheWord[dataTableCount].DataBind();
    GridViewTheWord[dataTableCount].ID                        = tableName;

    theWordIdColumnIndex = UtilityDatabase.DataTableColumnIndex
    (
     theWord.DataSetTheWord.Tables[tableName],
     columnNameForeignKey  
    );
    
    if ( DataColumnFieldGridView <= DataColumnField.Template )
    {
     if ( theWordIdColumnIndex >= 0 )
     {     
      //UtilityDatabase.DataSetTableColumnVisible( GridViewTheWord[dataTableCount], theWordIdColumnIndex, false );
      GridViewTheWord[dataTableCount].Columns[theWordIdColumnIndex].Visible = false;
     }//if ( theWordIdColumnIndex >= 0 ) 

     //GridViewTheWord[dataTableCount].UserDeletingRow += new GridViewRowCancelEventHandler( GridViewDeleteEventArgs );

     PlaceHolderGridView.Controls.Add
     ( 
      new LiteralControl
      (
       "<b>" + GridViewTheWord[dataTableCount].ID + "</b>"
      ) 
     );
    }
    
    if ( dataTableCount != 0 )
    {
     linkButtonAdd[dataTableCount]                              = new System.Web.UI.WebControls.LinkButton();
     linkButtonAdd[dataTableCount].ID                           = dataTableCount + "|" + tableName + "|" + "Add";
     linkButtonAdd[dataTableCount].Text                         = "Add <br />";

     // Register the event-handling method for the Click event. 
     linkButtonAdd[dataTableCount].Click                       += new EventHandler(this.LinkButtonAdd_Click);

     PlaceHolderGridView.Controls.Add( linkButtonAdd[dataTableCount]  );
    } 

    if ( DataColumnFieldGridView <= DataColumnField.Template )
    {
     PlaceHolderGridView.Controls.Add(GridViewTheWord[dataTableCount]);
     PlaceHolderGridView.Controls.Add(new LiteralControl("<br />"));
    }

   }//foreach( DataTable dataTable in theWord.DataSetTheWord.Tables )

  }//public static void PageBuild()

  /// <summary>PageBuildTextBox().</summary>
  public void PageBuildTextBox()
  {

   int          dataTableCount                = -1;
   int          dataTableTotal                = -1;
   int          theWordIdColumnIndex          = 0;

   DateTime     dated                         = DateTime.Now;

   System.Web.UI.WebControls.Label            label  =  null;
   
   String       columnNameForeignKey          = null;
   String       exceptionMessage              = null;
   String[]     sourceName                    = null;
   String[]     sourceSQL                     = null;
   String       tableName                     = null;

   System.Web.UI.WebControls.TextBox          textBox  =  null;
   
   XmlNodeList  sourceXML                     = null;

   TheWord.SourceSQLQuery
   (
        filenameConfigurationXml,
    ref exceptionMessage,
    ref sourceXML,
    ref sourceSQL,
    ref sourceName
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 
   
   if ( !Page.IsPostBack )
   {

    theWord.DataSetInitialize
    (
         databaseConnectionString,
     ref exceptionMessage,
         nodeRoot,
         sourceSQL,
         sourceName
    );

    if ( exceptionMessage != null )
    {
     Feedback = exceptionMessage;
     return;
    }//if ( exceptionMessage != null ) 
          	
   }//if ( Page.IsPostBack )

    UtilityXml.XmlDocumentNodeInnerText
    (
         filenameConfigurationXml,
     ref exceptionMessage,         
         TheWord.XPathColumnForeign,
     ref columnNameForeignKey
    );

   dataTableTotal           = theWord.DataSetTheWord.Tables.Count;

   linkButtonAdd            = new System.Web.UI.WebControls.LinkButton[ dataTableTotal ];

   for( dataTableCount = 0; dataTableCount < theWord.DataSetTheWord.Tables.Count; ++dataTableCount )
   {
   	theWord.DataSetTheWord.Tables[dataTableCount].TableName = sourceName[dataTableCount];
   }

   dataTableCount = -1;

   foreach( DataTable dataTable in theWord.DataSetTheWord.Tables )
   {
    ++dataTableCount;
    tableName                                                 = dataTable.TableName;

    PlaceHolderGridView.Controls.Add
    ( 
     new LiteralControl
     (
      "<b>" + tableName + "</b>"
     ) 
    );

    foreach(DataRow dataRow in dataTable.Rows)
    {
     foreach(DataColumn dataColumn in dataTable.Columns)
     {
      label         =  new System.Web.UI.WebControls.Label(); 
      label.Id      =  "Label" + dataColumn.ColumnName;
      label.Text    =  dataColumn.ColumnName + ": ";
      PlaceHolderGridView.Controls.Add( label );
                     
      textBox       =  new System.Web.UI.WebControls.TextBox();
      textBox.ID    =  "TextBox" + dataColumn.ColumnName;
      textBox.Text  =  dataRow[dataColumn].ToString();
      PlaceHolderGridView.Controls.Add( textBox );
       
      label         =  new System.Web.UI.WebControls.Label(); 
      label.Text    =  "<br />";
      PlaceHolderGridView.Controls.Add( label );
     }//foreach(DataColumn dataColumn in dataTable.Columns)
    }//foreach(DataRow dataRow in dataTable.Rows)
    
    if ( dataTableCount == 0 )
    {
     PlaceHolderGridView.Controls.Add
     ( 
      new LiteralControl( "<br />" )
     );
    }
    else
    {
     linkButtonAdd[dataTableCount]                              = new System.Web.UI.WebControls.LinkButton();
     linkButtonAdd[dataTableCount].ID                           = dataTableCount + "|" + tableName + "|" + "Add";
     linkButtonAdd[dataTableCount].Text                         = "  Add <br />";

     // Register the event-handling method for the Click event. 
     linkButtonAdd[dataTableCount].Click                       += new EventHandler(this.LinkButtonAdd_Click);

     PlaceHolderGridView.Controls.Add( linkButtonAdd[dataTableCount]  );
    } 

   }//foreach( DataTable dataTable in theWord.DataSetTheWord.Tables )

  }//public static void PageBuildTextBox()
  
  /// <summary>Fredrik Normén's Blog - NSQUARED2 Update all GridView's rows http://normen.mine.nu/viewpost.aspx?PostID=202</summary>
  public void PageSave()
  {
   int          gridViewRowIndex  =  -1;
   String       primaryKeyValue   =  null;
   GridViewRow  gridViewRow       =  null;
  
   foreach (GridView gridView in GridViewTheWord )
   {
    for ( gridViewRowIndex = 0; gridViewRowIndex < gridView.Rows.Count; ++gridViewRowIndex )
    {
     gridViewRow      = gridView.Rows[gridViewRowIndex];
     //primaryKeyValue  = gridView.DataKeys[gridViewRowIndex].Value.ToString();
     primaryKeyValue  = ((System.Web.UI.WebControls.TextBox)gridViewRow.Cells[0].FindControl("TextBoxSequenceOrderId")).Text.Replace("'","''");
     Response.Write ( primaryKeyValue );
    }//foreach ( GridViewRow gridViewRow in gridView.Rows.Count )
   }//foreach (GridView gridView in GridViewTheWord )   	
  }//public void PageSave()

  /// <summary>Fredrik Normén's Blog - NSQUARED² Delete the Gridiew's selected rows http://fredrik.nsquared2.com/viewpost.aspx?PostID=254&showfeedback=true</summary>
  protected void DeleteSelectedRows_Click(object sender, EventArgs e)
  {
   GridViewRow  gridViewRow       =  null;
  
   //Iterate through all the GridView’s Rows
   foreach (GridView gridView in GridViewTheWord )
   {
    foreach (GridViewRow row in gridView.Rows )
    {
     //Get the first column from the row where the HtmlInputCheckBox is located
     TableCell cell = row.Cells[0];

     //Get the HtmlInputChecklBox control from the cells control collection
     HtmlInputCheckBox checkBox = cell.Controls[1] as HtmlInputCheckBox;

     //If the checkbox exists and are checked, execute the Delete command where the
     //value form the HtmlInputCheckBox’ Value property is set as the value of the 
     //delete command’s parameter.
     if (checkBox != null && checkBox.Checked)
     {
      //SqlDataSource1.DeleteParameters["CustomerID"].DefaultValue = checkBox.Value;
      //SqlDataSource1.Delete();
     }//if (checkBox != null && checkBox.Checked)
    }//foreach (GridViewRow row in GridViewTheWord.Rows.Count)
   }//foreach (GridView gridView in GridViewTheWord )
  }// 
  
  /// <summary>LinkButtonAdd_Click().</summary>
  public void LinkButtonAdd_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   int    dataRowCount     = -1;
   int    tableId          = -1;
   string exceptionMessage = null;
   String linkButtonId     = null;
   string tableName        = null;
   
   System.Web.UI.WebControls.LinkButton  linkButton;
   //Response.Write ( sender );
   linkButton = ( System.Web.UI.WebControls.LinkButton ) sender;
   linkButtonId = linkButton.ID;
   //Response.Write ( linkButton.ID );
   theWord.DataSetRowAdd
   ( 
        databaseConnectionString,
   ref  exceptionMessage,
        linkButtonId,
    ref tableId,
    ref tableName,
    ref dataRowCount
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 
   
   //place added row in edit mode
   //GridViewTheWord[tableId].EditItemIndex = dataRowCount;
   GridViewTheWord[tableId].DataBind();
   //SetFocus(GridViewTheWord[tableId]);

  }//LinkButtonAdd_Click().
  
  /// <summary>ButtonOpen_Click().</summary>
  public void ButtonOpen_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   string exceptionMessage = null;
   string filenameXml      = TheWordFilename;
   theWord.FileOpen
   (
         databaseConnectionString,
     ref exceptionMessage,
     ref filenameXml
   );
   
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 
  }//ButtonOpen_Click()

  /// <summary>ButtonNew_Click().</summary>
  public void ButtonNew_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   theWord.DataSetNew();
   foreach( System.Web.UI.WebControls.GridView GridView in GridViewTheWord )
   {
    GridView.DataBind();
   }//foreach( System.Web.UI.WebControls.GridView GridView in GridViewTheWord )

  }//public void ButtonNew_Click()

  /// <summary>ButtonSave_Click().</summary>
  public void ButtonSave_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {

   String exceptionMessage = null;
   String filenameXml      = null;
   String filenameXslt     = null;

   PageSave();

   /*
   theWord.FileSave
   (
         databaseConnectionString,
     ref exceptionMessage,
     ref filenameXml,
     ref filenameXslt
   );
   */

   theWord.TheWordDataSet
   (
         databaseConnectionString,
         filenameConfigurationXml,         
     ref exceptionMessage,
     ref filenameXml,
     ref filenameXslt
   );
   
   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null ) 
  
  }//  public void ButtonSave_Click()

  /// <summary>ButtonSave_Click().</summary>
  public void ButtonGridViewColumnIndex_Click
  (
   Object sender, 
   EventArgs e
  ) 
  {
   //UtilityDatabase.DataSetTableColumnIndex( GridViewTheWord[1], "TheWordId" );
  }

  /// <summary>DatabaseConnectionString.</summary>
  public string DatabaseConnectionString
  {
   get
   {
    return ( databaseConnectionString );
   }//get 
  }//public string DatabaseConnectionString

  /// <summary>TheWordCommentary.</summary>
  public string TheWordCommentary
  {
   get
   {
    /* 20031013
     return ( TextBoxTheWordCommentary.Text.Trim() );
    */
    return (string) 
    ( 
     UtilityDatabase.DataSetTableRowColumn
     ( 
      theWord.DataSetTheWord,
      "TheWord",
      0,
      "Commentary"
     )
    ); 
   }//get 
   set
   {
    /* 20031013
     TextBoxTheWordCommentary.Text = value;
    */
    UtilityDatabase.DataSetTableRowColumn
    ( 
     theWord.DataSetTheWord,
     "TheWord",
     0,
     "Commentary",
     value.ToString()
    ); 
   }//set
  }//public string TheWordCommentary

  /// <summary>TheWordDated.</summary>
  public DateTime TheWordDated
  {
   get
   {
    /* 20031013
     return ( Convert.ToDateTime( TextBoxTheWordDated.Text.Trim() ) );
    */ 
    return (DateTime) 
    ( 
     UtilityDatabase.DataSetTableRowColumn
     ( 
      theWord.DataSetTheWord,
      "TheWord",
      0,
      "Dated"
     )
    ); 
   }//get 
   set
   {
    /* 20031013
     TextBoxTheWordFilename.Text = value;
    */ 
    /*
    UtilityDatabase.DataSetTableRowColumn
    ( 
     theWord.DataSetTheWord,
     "TheWord",
     0,
     "Dated",
     value.ToString()
    ); 
    */
   }//set
  }//public string TheWordDated

  /// <summary>TheWordFilename.</summary>
  public string TheWordFilename
  {
   get
   {
    /* 20031013
     return ( TextBoxTheWordFilename.Text.Trim() );
    */ 
    return (string) 
    ( 
     UtilityDatabase.DataSetTableRowColumn
     ( 
      theWord.DataSetTheWord,
      "TheWord",
      0,
      "Filename"
     )
    ); 
   }//get 
   set
   {
    /* 20031013
     TextBoxTheWordFilename.Text = value;
    */ 
    UtilityDatabase.DataSetTableRowColumn
    ( 
     theWord.DataSetTheWord,
     "TheWord",
     0,
     "Filename",
     value.ToString()
    ); 
   }//set
  }//public string TheWordFilename

  /// <summary>TheWordKeyword.</summary>
  public string TheWordKeyword
  {
   get
   {
    /* 20031013
     return ( TextBoxTheWordKeyword.Text.Trim() );
    */ 
    return (string) 
    ( 
     UtilityDatabase.DataSetTableRowColumn
     ( 
      theWord.DataSetTheWord,
      "TheWord",
      0,
      "Keyboard"
     )
    ); 
   }//get 
   set
   {
    /* 20031013
     TextBoxTheWordKeyword.Text = value;
    */ 
    UtilityDatabase.DataSetTableRowColumn
    ( 
     theWord.DataSetTheWord,
     "TheWord",
     0,
     "Keyword",
     value.ToString()
    ); 
   }//set
  }//public string TheWordKeyword

  /// <summary>TheWordTitle.</summary>
  public string TheWordTitle
  {
   get
   {
    /* 20031013
     return ( TextBoxTheWordTitle.Text.Trim() );
    */ 
    return (string) 
    ( 
     UtilityDatabase.DataSetTableRowColumn
     ( 
      theWord.DataSetTheWord,
      "TheWord",
      0,
      "Dated"
     )
    ); 
   }//get 
   set
   {
    /* 20031013
     TextBoxTheWordTitle.Text = value;
    */ 
    UtilityDatabase.DataSetTableRowColumn
    ( 
     theWord.DataSetTheWord,
     "TheWord",
     0,
     "Title",
     value.ToString()
    ); 
   }//set
  }//public string TheWordTitle

  /// <summary>TheWordScriptureReference.</summary>
  public string TheWordScriptureReference
  {
   get
   {
    /* 20031013
     return ( TextBoxTheWordScriptureReference.Text.Trim() );
    */ 
    return (string) 
    ( 
     UtilityDatabase.DataSetTableRowColumn
     ( 
      theWord.DataSetTheWord,
      "TheWord",
      0,
      "ScriptureReference"
     )
    ); 
   }//get 
   set
   {
    /* 20031013
     TextBoxTheWordScriptureReference.Text = value;
    */ 
    UtilityDatabase.DataSetTableRowColumn
    ( 
     theWord.DataSetTheWord,
     "TheWord",
     0,
     "ScriptureReference",
     value.ToString()
    ); 
   }//set
  }//public string TheWordScriptureReference

  /// <summary>Feedback.</summary>
  public string Feedback
  {
   get
   {
    return ( LiteralFeedback.Text);
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public string Feedback
  
  /*
  private void SetFocus(System.Web.UI.Control ctrl)
  {
    // Define the JavaScript function for the specified control.
    string focusScript = "<script language='javascript'>" +
        "document.getElementById('" + ctrl.ClientID +
        "').focus();</script>";

    // Add the JavaScript code to the page.
    Page.RegisterStartupScript("FocusScript", focusScript);
  }
  */

 }//TheWordPage class.
}//WordEngineering namespace.