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

namespace WordEngineering
{
 /// <summary>URIPage.</summary>
 public class URIPage : Page
 {

  /// <summary>The database connection String.</summary>
  public String DatabaseConnectionString                  = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=URI;";

  /// <summary>The database SQL Select.</summary>
  public String DatabaseSQLSelect                         = "Select URI, Title, Keyword, Dated FROM URIChrist";
  
  /// <summary>The configuration XML filename.</summary>
  public String            FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The XML filename stylesheet.</summary>
  public String            FilenameXmlStylesheet          = @"Comforter_-_URI.xslt";

  /// <summary>The server map path.</summary>
  public String            ServerMapPath                  = null;

  /// <summary>The XPath database connection String.</summary>
  public const  String     XPathDatabaseConnectionString  = @"/word/database/sqlServer/bible/databaseConnectionString";  

  /// <summary>The XPath SQL Select.</summary>
  public const  String     XPathSQLSelect                 = @"/word/URI/URIChrist/SQLSelect";  

  /// <summary>PrimaryKeyColumn.</summary>
  public static String[]   PrimaryKeyColumn               = new String[] { "URI" };

  /// <summary>The XPath XML Stylesheet.</summary>
  public const  String     XPathXmlStylesheet             = @"/word/URI/XmlStylesheet";  

  /// <summary>ButtonInsert.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonInsert;

  /// <summary>ButtonOpen.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonOpen;

  /// <summary>ButtonOpen.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonSave;

  /// <summary>GridViewURI.</summary>  
  protected System.Web.UI.WebControls.GridView     GridViewURI;

  /// <summary>BoundField.</summary>  
  protected System.Web.UI.WebControls.BoundField   BoundFieldURI;
  
  /// <summary>HtmlInputFileURI.</summary>  
  protected HtmlInputFile  HtmlInputFileURI;

  /// <summary>PlaceHolderURI.</summary>  
  protected System.Web.UI.WebControls.PlaceHolder  PlaceHolderURI;

  /// <summary>The exception message.</summary>
  protected Literal        LiteralFeedback;

  /// <summary>DataSetURI.</summary>
  DataSet                  DataSetURI;

  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   PageBuild();
  }//Page_Load

  /// <summary>PageBuild.</summary>
  public void PageBuild()
  {
   String              columnNameCurrent               =  null;
   String              exceptionMessage                =  null;
   String              tableName                       =  null;
   
   ArrayList           columnName                      =  null;

   GridViewURI = new System.Web.UI.WebControls.GridView();
    
   ServerMapPath = this.MapPath("");
   if ( ServerMapPath != null)
   {
    FilenameConfigurationXml = ServerMapPath + @"\" + FilenameConfigurationXml;
   }//if ( ServerMapPath != null)

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        XPathDatabaseConnectionString,
    ref DatabaseConnectionString
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        XPathSQLSelect,
    ref DatabaseSQLSelect
   );

   UtilityXml.XmlDocumentNodeInnerText
   (
        FilenameConfigurationXml,
    ref exceptionMessage,         
        XPathXmlStylesheet,
    ref FilenameXmlStylesheet
   );

   if ( exceptionMessage != null )
   {
    Feedback = exceptionMessage;
    return;
   }//if ( exceptionMessage != null )

   UtilityDatabase.DataSetTableColumn
   (
    ref DatabaseSQLSelect,
    ref DataSetURI,
    ref exceptionMessage,
    ref tableName,
    ref columnName
   );
    
   DataSourceBind();

   foreach( object columnNameObject in columnName )
   {
    columnNameCurrent              =  ( String ) columnNameObject;
    BoundFieldURI                  =  new BoundField();
    BoundFieldURI.DataField        =  columnNameCurrent;
    BoundFieldURI.HeaderText       =  columnNameCurrent;
    BoundFieldURI.SortExpression   =  columnNameCurrent;
     
    if ( String.Compare( columnNameCurrent, "Dated", true ) == 0 )
    {
     //BoundFieldURI.DataFormatString =  "{T}";  //"{0:c}"
    }//if ( String.Compare( columnNameCurrent, "Dated", true ) == 0 )

    GridViewURI.Columns.Add( BoundFieldURI );
     
   }//foreach( object columnNameObject in columnName )

   GridViewURI.AllowSorting              =  true;
   GridViewURI.AllowPaging               =  true;
   GridViewURI.AutoGenerateColumns       =  false;
   GridViewURI.AutoGenerateEditButton    =  true;
   GridViewURI.AutoGenerateSelectButton  =  true;
   
   GridViewURI.BorderWidth               =  1;
   GridViewURI.CellPadding               =  1;
   GridViewURI.DataKeyNames              =  PrimaryKeyColumn;
   GridViewURI.ID                        =  "URI";
   GridViewURI.SelectedIndex             =  0;

   // Manually register the event-handling methods.

   GridViewURI.RowCancelingEdit    += new GridViewCancelEditEventHandler( GridViewURI_RowCancelingEdit );
   GridViewURI.RowEditing          += new GridViewEditEventHandler( GridViewURI_RowEdit );
   GridViewURI.RowUpdating         += new GridViewUpdateEventHandler( GridViewURI_RowUpdating );
   
   /*
   GridViewURI.CancelCommand += new GridViewCommandEventHandler(dataGrid_Cancel);
   GridViewURI.DeleteCommand += new GridViewCommandEventHandler(dataGrid_Delete);
   GridViewURI.EditCommand   += new GridViewCommandEventHandler(dataGrid_Edit);
   GridViewURI.UpdateCommand += new GridViewCommandEventHandler(dataGrid_Update);
   */
   
   PlaceHolderURI.Controls.Add( GridViewURI );
 
  }//PageBuild()
  
  /// <summary>Feedback.</summary>
  public String Feedback
  {
   get
   {
    return ( LiteralFeedback.Text);
   } 
   set
   {
    LiteralFeedback.Text = value;
   }
  }//public String public String Feedback

  /// <summary>URIFile.</summary>
  public String URIFile
  {
   get
   {
    return ( HtmlInputFileURI.Value );
   } 
   set
   {
    HtmlInputFileURI.Value = value;
   }
  }//public String URIFile

  /// <summary>DataSourceBind().</summary>
  public void DataSourceBind()
  {
   String                  exceptionMessage     =  null;
   String[]                primaryKey           =  null;
   DataTableCollection     dataTableCollection  =  null;
   DataColumn[][]          dataColumnPrimaryKey =  null;

   // Store the cookies received in the session state for future retrieval by this session.
   Session["DataSetURI"] = DataSetURI;

   GridViewURI.DataSource = DataSetURI;
   GridViewURI.DataBind();
   
   UtilityDatabase.DataSetTablePrimaryKey
   (
    ref DataSetURI,
    ref exceptionMessage,
    ref dataTableCollection,
    ref dataColumnPrimaryKey,
    ref primaryKey
   );

   //GridViewURI.DataKeyField = primaryKey[0];
  }

  /// <summary>ButtonAdd_Click().</summary>
  public void ButtonAdd_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   int    dataRowCount     = -1;
   String exceptionMessage = null;
 
   try
   {
    UtilityDatabase.DataSetRowAdd
    (
     ref DataSetURI,
     ref exceptionMessage,
     ref dataRowCount
    );
   }
   catch ( Exception exception )
   {
    exceptionMessage = exception.Message;
   }
   if ( exceptionMessage == null )
   {
    DataSourceBind();
    //GridViewURI.EditItemIndex = dataRowCount;
    UtilityJavaScript.SetFocus( this, GridViewURI );
   }
   else   	
   {
    Feedback = exceptionMessage;
   }   	
  }//public void ButtonAdd_Click()

  /// <summary>ButtonNew_Click().</summary>
  public void ButtonNew_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   String     tableName        = null;
   String     exceptionMessage = null;

   ArrayList  columnName       = null;

   try
   {
    UtilityDatabase.DataSetTableColumn
    (
     ref DatabaseSQLSelect,
     ref DataSetURI,
     ref exceptionMessage,
     ref tableName,
     ref columnName
    );
    DataSourceBind();
   }
   catch ( Exception exception )
   {
    exceptionMessage = exception.Message;
   }
  }//public void ButtonNew_Click()

  /// <summary>ButtonInsert_Open().</summary>
  public void ButtonOpen_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   String exceptionMessage = null;
   String filenameXml      = null;
   
   filenameXml = URIFile;
   
   UtilityXml.ReadXml
   (
    ref DataSetURI,
    ref exceptionMessage,
    ref filenameXml
   );
   
   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   }	

   DataSourceBind();

  }

  /// <summary>ButtonInsert_Save().</summary>
  public void ButtonSave_Click
  (
   Object    sender, 
   EventArgs e
  )
  {
   String exceptionMessage   = null;
   String filenameXml        = null;
   
   filenameXml = URIFile;

   UtilityXml.WriteXml
   (
        DataSetURI,
    ref exceptionMessage,
    ref filenameXml,
    ref FilenameXmlStylesheet
   );

   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   }
  }//public void ButtonSave_Click()

  /// <summary>GridViewURI_RowCancelingEdit().</summary>
  public void GridViewURI_RowCancelingEdit
  (
   Object                          sender, 
   GridViewCancelEditEventArgs     e
  ) 
  {
   // Set the EditItemIndex property to the index of the item clicked 
   // in the GridView control to enable editing for that item. Be sure
   // to rebind the DateGrid to the data source to refresh the control.
   //GridViewURI.EditItemIndex = e.Item.ItemIndex;  //e.Keys(0)
   DataSourceBind();
  }

  /// <summary>GridViewURI_RowEdit().</summary>
  public void GridViewURI_RowEdit
  (
   Object                    sender, 
   GridViewEditEventArgs     e
  ) 
  {
   // Set the EditItemIndex property to the index of the item clicked 
   // in the GridView control to enable editing for that item. Be sure
   // to rebind the DateGrid to the data source to refresh the control.
   //GridViewURI.EditItemIndex = e.Item.ItemIndex;  //e.Keys(0)
   DataSourceBind();
   GridViewURI.EditIndex = 0;
  }

  /// <summary>GridViewURI_RowCancelingEdit.</summary>
  public void GridViewURI_RowCancelingEdit
  (
   Object     sender, 
   EventArgs  e
  ) 
  {
   // Set the EditItemIndex property to -1 to exit editing mode. 
   // Be sure to rebind the DateGrid to the data source to refresh
   // the control.
   GridViewURI.EditIndex = -1;
   DataSourceBind();
  }

  /// <summary>GridViewURI_Delete().</summary>
  public void GridViewURI_Delete(Object sender, GridViewCommandEventArgs e) 
  {
   DataRow  dataRowFind  =  null;

   //Retrieve the data row to delete from the data table. 
   //Use the DataKeys property of the GridView control to get 
   //the primary key value of the selected row. 
   // Search the Rows collection of the data table for this value. 

   //dataRowFind =  DataSetURI.Tables[0].Rows.Find(GridViewURI.DataKeys[e.Item.ItemIndex]);

   // Delete the item selected in the GridView from the data source.
   if( dataRowFind != null)
   {
    DataSetURI.Tables[0].Rows.Remove( dataRowFind );
   }
  
   DataSourceBind();
  }

  /// <summary>GridViewURI_RowUpdating().</summary>
  public void GridViewURI_RowUpdating
  (
   Object                   sender, 
   GridViewUpdateEventArgs  e
  ) 
  {
   int                                rowIndex     =  -1;
   
   DateTime                           dated;

   String                             keyword      =  null;
   String                             title        =  null;
   String                             uri          =  null;
      
   GridViewRow                        gridViewRow  =  null;
   System.Web.UI.WebControls.TextBox  textBox      =  null;

   /*
   gridViewRow = GridViewURI.Rows[e.RowIndex];

   if ( gridViewRow != null )
   {
    textBox = ( System.Web.UI.WebControls.TextBox ) gridViewRow.FindControl("URI");
    if ( gridViewRow != null )
    {
     Response.Write( textBox.Text );
    }//if ( gridViewRow != null )
   }//if ( gridViewRow != null )
   */

   rowIndex  =  e.RowIndex;
   
   uri       =  (String) e.Keys["URI"]; 

   dated     =  Convert.ToDateTime( e.NewValues["Dated"] );
   keyword   =  (String)   e.NewValues["Keyword"];
   title     =  (String)   e.NewValues["Title"];
   
   Feedback = "e.Keys[" + e.Keys.Count + ']';
   Feedback = Feedback + "| e.OldValues[" + e.OldValues.Count + ']';
   Feedback = Feedback + "| e.NewValues[" + e.NewValues.Count + ']';
   
   for ( int keyIndex = 0; keyIndex < e.Keys.Count; ++keyIndex )
   {
   	Feedback += e.Keys[ keyIndex ];
   	Feedback += '|';
   }//for ( int keyIndex = 0; keyIndex <= e.Keys.Count, ++keyIndex )

   for ( int newValuesIndex = 0; newValuesIndex < e.NewValues.Count; ++newValuesIndex )
   {
   	Feedback += e.NewValues[ newValuesIndex ];
   	Feedback += '|';
   }//for ( int newValuesIndex = 0; newValuesIndex < e.NewValues.Count; ++newValuesIndex )
 
  }//public void GridViewURI_RowUpdating    

  /// <summary>GridViewURI_Update().</summary>
  public void GridViewURI_Update(Object sender, GridViewCommandEventArgs e) 
  {

   int                                cellId                  = 0;
   String                             cellText                = null;

   DataColumn[]                       dataColumnPrimaryKey    = null;
   System.Web.UI.WebControls.TextBox  textBoxCurrent          = null;

   dataColumnPrimaryKey = DataSetURI.Tables[0].PrimaryKey;

   // Retrieve the text boxes that contain the values to update.
   // For bound columns, the edited value is stored in a TextBox.
   // The TextBox is the 0th control in a cell's Controls collection.
   // Each cell in the Cells collection of a GridView item represents
   // a column in the GridView control.

   foreach(DataColumn dataColumn in DataSetURI.Tables[0].Columns)
   {
    ++cellId;
    //textBoxCurrent = (System.Web.UI.WebControls.TextBox)e.Item.Cells[cellId].Controls[0];
    cellText       = textBoxCurrent.Text;
    
    Response.Write( dataColumn );
    Response.Write( cellText );
   }

   // Set the EditItemIndex property to -1 to exit editing mode. 
   // Be sure to rebind the DateGrid to the data source to refresh
   // the control.
   //GridViewURI.EditItemIndex = -1;
   DataSourceBind();
  }//public void GridViewURI_Update(Object sender, GridViewCommandEventArgs e)

  /// <summary>GridViewURI_Command().</summary>
  public void DeleteItem(GridViewCommandEventArgs e)
  {

    // e.Item is the table row where the command is raised. For bound
    // columns, the value is stored in the Text property of a TableCell.
    //TableCell itemCell = e.Item.Cells[2];
    //String item = itemCell.Text;


    // Remove the selected item from the data source.         
    /*
    CartView.RowFilter = "Item='" + item + "'";
    if (CartView.Count > 0) 
    {     
     CartView.Delete(0);
    }
    CartView.RowFilter = "";
   */
  }
  
 }//URIPage class.
}//WordEngineering namespace.