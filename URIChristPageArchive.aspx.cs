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
 /// <summary>Bible Book page.</summary>
 public class URIChristPage : Page
 {

  /// <summary>The database connection string.</summary>
  public string DatabaseConnectionString       = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=URI;";

  /// <summary>The database SQL Select.</summary>
  public string DatabaseSQLSelect              = "Select URI, Title, Keyword, Dated FROM URIChrist";
  
  /// <summary>The configuration XML filename.</summary>
  public string FilenameConfigurationXml       = @"WordEngineering.config";

  /// <summary>The XML filename stylesheet.</summary>
  public string FilenameXmlStylesheet  = @"Comforter_-_URI.xslt";

  /// <summary>The server map path.</summary>
  public string ServerMapPath                  = null;

  /// <summary>The XPath database connection string.</summary>
  const  string XPathDatabaseConnectionString  = @"/word/database/sqlServer/bible/databaseConnectionString";  

  /// <summary>The XPath SQL Select.</summary>
  const  string XPathSQLSelect                 = @"/word/URI/URIChrist/SQLSelect";  

  /// <summary>The XPath XML Stylesheet.</summary>
  public const  string  XPathXmlStylesheet     = @"/word/URI/XmlStylesheet";  

  /// <summary>ButtonInsert.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonInsert;

  /// <summary>ButtonOpen.</summary>  
  protected System.Web.UI.WebControls.Button       ButtonOpen;

  /// <summary>ButtonOpen.</summary>  
    protected System.Web.UI.WebControls.Button     ButtonSave;

  /// <summary>DataGridURI.</summary>  
    protected System.Web.UI.WebControls.DataGrid   DataGridURI;

  /// <summary>HtmlInputFileURI.</summary>  
  protected HtmlInputFile  HtmlInputFileURI;

  /// <summary>The exception message.</summary>
  protected Literal        LiteralFeedback;

  /// <summary>DataSetDataGrid.</summary>
  DataSet                  DataSetDataGrid;
  
  // The Cart and CartView objects temporarily store the data source
  // for the DataList control while the page is being processed.
  DataTable Cart = new DataTable();
  DataView CartView;
  
  /// <summary>Page Load.</summary>
  public void Page_Load
  (
   object     sender, 
   EventArgs  e
  ) 
  {
   string              tableName                       = null;
   string              exceptionMessage                = null;

   ArrayList           columnName                      = null;
 
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

   if ( !Page.IsPostBack )
   {
    UtilityDatabase.DataSetTableColumn
    (
     ref DatabaseSQLSelect,
     ref DataSetDataGrid,
     ref exceptionMessage,
     ref tableName,
     ref columnName
    );
    
    DataSourceBind();
 
   }//if ( !Page.IsPostBack )
   else
   {
    DataSetDataGrid = (DataSet) Session["DataSetDataGrid"];
   }//else ( Page.IsPostBack )
   
  }//Page_Load

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
  }//public string public string Feedback

  /// <summary>URIFile.</summary>
  public string URIFile
  {
   get
   {
    return ( HtmlInputFileURI.Value );
   } 
   set
   {
    HtmlInputFileURI.Value = value;
   }
  }//public string URIFile

  /// <summary>SetFocus().</summary>
  private void SetFocus(System.Web.UI.Control ctrl)
  {
    // Define the JavaScript function for the specified control.
    string focusScript = "<script language='javascript'>" +
        "document.getElementById('" + ctrl.ClientID +
        "').focus();</script>";

    // Add the JavaScript code to the page.
    Page.RegisterStartupScript("FocusScript", focusScript);
  }

  /// <summary>DataSourceBind().</summary>
  public void DataSourceBind()
  {
   String                  exceptionMessage     =  null;
   String[]                primaryKey           =  null;
   DataTableCollection     dataTableCollection  =  null;
   DataColumn[][]          dataColumnPrimaryKey =  null;

   // Store the cookies received in the session state for future retrieval by this session.
   Session["DataSetDataGrid"] = DataSetDataGrid;

   DataGridURI.DataSource = DataSetDataGrid;
   DataGridURI.DataBind();
   
   UtilityDatabase.DataSetTablePrimaryKey
   (
    ref DataSetDataGrid,
    ref exceptionMessage,
    ref dataTableCollection,
    ref dataColumnPrimaryKey,
    ref primaryKey
   );

   DataGridURI.DataKeyField = primaryKey[0];
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
     ref DataSetDataGrid,
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
    //DataGridURI.EditItemIndex = dataRowCount;
    SetFocus( DataGridURI );
   }
   else   	
   {
    Feedback = exceptionMessage;
   }   	
  }//public void ButtonAdd_Click()

  /// <summary>ButtonInsert_Open().</summary>
  public void ButtonOpen_Click
  (
   Object sender, 
   EventArgs e
  )
  {
   string exceptionMessage = null;
   string filenameXml      = null;
   
   filenameXml = URIFile;
   
   UtilityXml.ReadXml
   (
    ref DataSetDataGrid,
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
   Object sender, 
   EventArgs e
  )
  {
   string exceptionMessage   = null;
   string filenameXml        = null;
   
   filenameXml = URIFile;

   UtilityXml.WriteXml
   (
        DataSetDataGrid,
    ref exceptionMessage,
    ref filenameXml,
    ref FilenameXmlStylesheet
   );

   if ( exceptionMessage != null )
   {
   	Feedback = exceptionMessage;
   }
  }//public void ButtonSave_Click()
  
  /// <summary>DataGridURI_Edit().</summary>
  public void DataGridURI_Edit(Object sender, DataGridCommandEventArgs e) 
  {
   // Set the EditItemIndex property to the index of the item clicked 
   // in the DataGrid control to enable editing for that item. Be sure
   // to rebind the DateGrid to the data source to refresh the control.
   DataGridURI.EditItemIndex = e.Item.ItemIndex;
   DataSourceBind();
  }
 
  /// <summary>DataGridURI_Cancel().</summary>
  public void DataGridURI_Cancel(Object sender, DataGridCommandEventArgs e) 
  {
   // Set the EditItemIndex property to -1 to exit editing mode. 
   // Be sure to rebind the DateGrid to the data source to refresh
   // the control.
   DataGridURI.EditItemIndex = -1;
   DataSourceBind();
  }

  /// <summary>DataGridURI_Delete().</summary>
  public void DataGridURI_Delete(Object sender, DataGridCommandEventArgs e) 
  {
   DataRow  dataRowFind  =  null;

   //Retrieve the data row to delete from the data table. 
   //Use the DataKeys property of the DataGrid control to get 
   //the primary key value of the selected row. 
   // Search the Rows collection of the data table for this value. 

   dataRowFind =  DataSetDataGrid.Tables[0].Rows.Find(DataGridURI.DataKeys[e.Item.ItemIndex]);

   // Delete the item selected in the DataGrid from the data source.
   if( dataRowFind != null)
   {
    DataSetDataGrid.Tables[0].Rows.Remove( dataRowFind );
   }
  
   DataSourceBind();
  }

  /// <summary>DataGridURI_Update().</summary>
  public void DataGridURI_Update(Object sender, DataGridCommandEventArgs e) 
  {

   int                                cellId                  = 0;
   string                             cellText                = null;

   DataColumn[]                       dataColumnPrimaryKey    = null;
   System.Web.UI.WebControls.TextBox  textBoxCurrent          = null;

   dataColumnPrimaryKey = DataSetDataGrid.Tables[0].PrimaryKey;

   // Retrieve the text boxes that contain the values to update.
   // For bound columns, the edited value is stored in a TextBox.
   // The TextBox is the 0th control in a cell's Controls collection.
   // Each cell in the Cells collection of a DataGrid item represents
   // a column in the DataGrid control.

   foreach(DataColumn dataColumn in DataSetDataGrid.Tables[0].Columns)
   {
    ++cellId;
    textBoxCurrent = (System.Web.UI.WebControls.TextBox)e.Item.Cells[cellId].Controls[0];
    cellText       = textBoxCurrent.Text;
    
    Response.Write( dataColumn );
    Response.Write( cellText );
   }

   // Set the EditItemIndex property to -1 to exit editing mode. 
   // Be sure to rebind the DateGrid to the data source to refresh
   // the control.
   DataGridURI.EditItemIndex = -1;
   DataSourceBind();

  }
  
  /// <summary>DataGridURI_Update().</summary>
  public void DataGridURI_UpdateArchive(Object sender, DataGridCommandEventArgs e) 
  {

   // Retrieve the text boxes that contain the values to update.
   // For bound columns, the edited value is stored in a TextBox.
   // The TextBox is the 0th control in a cell's Controls collection.
   // Each cell in the Cells collection of a DataGrid item represents
   // a column in the DataGrid control.

   System.Web.UI.WebControls.TextBox qtyText = (System.Web.UI.WebControls.TextBox)e.Item.Cells[3].Controls[0];
   System.Web.UI.WebControls.TextBox priceText = (System.Web.UI.WebControls.TextBox)e.Item.Cells[4].Controls[0];
 
         // Retrieve the updated values.
         String item = e.Item.Cells[2].Text;
         String qty = qtyText.Text;
         String price = priceText.Text;
        
         DataRow dr;
 
         // With a database, use an update command to update the data.
         // Because the data source in this example is an in-memory  
         // DataTable, delete the old row and replace it with a new one.
 
         // Remove the old entry and clear the row filter.
         CartView.RowFilter = "Item='" + item + "'";
         if (CartView.Count > 0)
         {
            CartView.Delete(0);
         }
         CartView.RowFilter = "";
 
         // ***************************************************************
         // Insert data validation code here. Make sure to validate the
         // values entered by the user before converting to the appropriate
         // data types and updating the data source.
         // ***************************************************************

         // Add the new entry.
         dr = Cart.NewRow();
         dr[0] = Convert.ToInt32(qty);
         dr[1] = item;

         // If necessary, remove the '$' character, from the price before
         // converting it to a Double.
         if(price[0] == '$')
         {
            dr[2] = Convert.ToDouble(price.Substring(1));
         }
         else
         {
            dr[2] = Convert.ToDouble(price);
         }

         Cart.Rows.Add(dr);
 
         // Set the EditItemIndex property to -1 to exit editing mode. 
         // Be sure to rebind the DateGrid to the data source to refresh
         // the control.
         DataGridURI.EditItemIndex = -1;
         //BindGrid();

      }
 
  /// <summary>DataGridURI_Command().</summary>
  public void DataGridURI_Command(Object sender, DataGridCommandEventArgs e)
  {
   switch(((LinkButton)e.CommandSource).CommandName)
   {
    case "Delete":
         DeleteItem(e);
         break;

    // Add other cases here, if there are multiple ButtonColumns in 
    // the DataGrid control.
    default:
         // Do nothing.
         break;
   }
  }

  /// <summary>DataGridURI_Command().</summary>
  public void DeleteItem(DataGridCommandEventArgs e)
  {

    // e.Item is the table row where the command is raised. For bound
    // columns, the value is stored in the Text property of a TableCell.
    TableCell itemCell = e.Item.Cells[2];
    string item = itemCell.Text;


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
  
 }//URIChristPage class.
}//WordEngineering namespace.