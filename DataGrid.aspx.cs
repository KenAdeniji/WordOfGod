In this article we will be illustrating one way to add a blank row to a DataGrid. Why would you want to do this? Who knows, maybe to enable a user to add a new record. This article will show you how to add a new row to a DataGrid by manipulating its DataSource - in this example a DataTable. Note that we will be simulating saving the new item back to the database.  
The original question was how to add a new blank row to a DataGrid. Well, in a short you can't add a blank row to a Datagrid. Well, that's not neccessarily true you can by dynamically adding a new DataGridItem - but the easy way to do it is to add a new row to it's DataSource - because what is a DataGridItem but row from its DataSource. So in actuality, this article discusses how to add a new row to a DataGrid's DataSource and how to use it to insert a new item. Beyond that, I'll also be demonstrating how to dynamically change the text of the DataGrid's EditCommandColumn to state something like "Insert New Product" instead of Edit in the blank row. This article introduces some neat tricks for the DataGrid and may help spawn some ideas of your own. So let's look at the code.  
default.aspx  
<%@ Page Language="C#" Debug="true" %>
<script language="C#" runat="server">

protected System.Data.DataSet ds;

protected void Page_Load( System.Object sender, System.EventArgs e ) {

if ( ! this.IsPostBack ) {

dg_bind( );
this.DataBind( );

}

}

protected void dg_ItemCreated( System.Object sender, System.Web.UI.WebControls.DataGridItemEventArgs e ) {

if ( e.Item.ItemIndex == 0 ) {

System.Web.UI.WebControls.LinkButton lb = ( System.Web.UI.WebControls.LinkButton )e.Item.Cells[ 0 ].Controls[ 0 ];

if ( lb.Text == "Edit" ) {

lb.Text = "Insert New Product";

} else if ( lb.Text == "Update" ) {

lb.Text = "Insert";

}

}

}

protected void dg_Update( System.Object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e ) {

System.String NewProductName = ( ( System.Web.UI.WebControls.TextBox )dg.Items[0].Cells[ 1 ].Controls[ 0 ] ).Text;
dg.EditItemIndex = - 1;
this.dg_bind( );
this.DataBind( );

if ( e.Item.ItemIndex == 0 ) {

System.Web.HttpContext.Current.Response.Write( "<BR>1. NEW RECORD VALUE: " + NewProductName );
System.Web.HttpContext.Current.Response.Write( "<BR>2. INSERT STATEMENT EXECUTED..." );
System.Web.HttpContext.Current.Response.Write( "<BR>3. RE-BIND DATAGRID - THE NEW RECORD IS ADDED AND DISPLAYED IN GRID");

}

}

protected void dg_Edit( System.Object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e ) {

dg.EditItemIndex = e.Item.ItemIndex;
this.dg_bind( );
this.DataBind( );

}

protected void dg_Cancel( System.Object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e) {

dg.EditItemIndex = - 1;
this.dg_bind( );
this.DataBind( );

}

protected void dg_bind() {

System.Data.SqlClient.SqlConnection SqlCon = new System.Data.SqlClient.SqlConnection( "server=localhost;database=northwind;trusted_connection=true;" );
System.Data.SqlClient.SqlDataAdapter SqlDa = new System.Data.SqlClient.SqlDataAdapter( "SELECT TOP 10 ProductName FROM Products", SqlCon );
ds = new System.Data.DataSet( );
SqlDa.Fill( ds, "Products" );
System.Data.DataRow BlankRow = ds.Tables[ "Products" ].NewRow( );
BlankRow[ "ProductName" ] = "<font color=\"red\">add new product</font>";
ds.Tables[ "Products" ].Rows.InsertAt( BlankRow, 0 );
dg.DataSource = ds.Tables[ "Products" ];

}

</script>

<html>
<body>
<form runat="server">

<asp:DataGrid id="dg"
runat="server"
font-size="8"
OnEditCommand="dg_Edit"
OnCancelCommand="dg_Cancel"
OnUpdateCommand="dg_Update"
OnItemCreated="dg_ItemCreated">

<Columns>

<asp:EditCommandColumn
EditText="Edit"
CancelText="Cancel"
UpdateText="Update"
HeaderText="Edit Command Column" />

</Columns>

</asp:DataGrid>

</form>
</body>
</html>

 
I know there looks to be a lot of code here, but most of it is used to simulate database insertions. We'll be going through the important parts of the code next. Lets first take a look at the dg_Bind() method:  
protected void dg_bind() {
System.Data.SqlClient.SqlConnection SqlCon = new System.Data.SqlClient.SqlConnection( "server=localhost;database=northwind;trusted_connection=true;" );
System.Data.SqlClient.SqlDataAdapter SqlDa = new System.Data.SqlClient.SqlDataAdapter( "SELECT TOP 10 ProductName FROM Products", SqlCon );
ds = new System.Data.DataSet( );
SqlDa.Fill( ds, "Products" );
System.Data.DataRow BlankRow = ds.Tables[ "Products" ].NewRow( );
BlankRow[ "ProductName" ] = "&alt;font color=\"red\"&agt;add new product&alt;/font&agt;";
ds.Tables[ "Products" ].Rows.InsertAt( BlankRow, 0 );
dg.DataSource = ds.Tables[ "Products" ];

}
 
Within this dg_bind method we add the blank row. We use the DataTable.NewRow method to create the new DataRow object. We use the DataTable.NewRow method because it creates a DataRow with the exact schema of the DataTable. Next we apply a value to the ProductName column - "your product goes here" - this is used to tell the user that this is a row that can be used to enter a new row. Next we insert the new DataRow into the DataTable by using the DataRowCollection.InsertAt method so we can insert the row at the beginning of the DataTable. This is done so we always know where the row is. 
The code within the other methods: EDIT, INSERT, CANCEL is strictly there to simulate an editable grid. The two methods I do want to call attention to are the dg_Update and dg_ItemCreated. 
 
dg_ItemCreated  
protected void dg_ItemCreated( System.Object sender, System.Web.UI.WebControls.DataGridItemEventArgs e ) {

if ( e.Item.ItemIndex == 0 ) {

System.Web.UI.WebControls.LinkButton lb = ( System.Web.UI.WebControls.LinkButton )e.Item.Cells[ 0 ].Controls[ 0 ];

if ( lb.Text == "Edit" ) {

lb.Text = "Insert New Product";

} else if ( lb.Text == "Update" ) {

lb.Text = "Insert";

}

}

}
 
The DataGrid.ItemCreated event, which is handled by my dg_ItemCreated method, is fired everytime a DataGridItem is added to the DataGrid. Because we are adding a new row that is for Inserting a new record rather than updating existing record I wanted to change the Text attribute of the rendered LinkButton in the EditCommandColumn to read something like "Insert New Record". I use this ItemCreated event to do this! Within the method you'll notice I check the ItemIndex of the created item. If the ItemIndex is 0, our blank row, then I get a handle to the LinkButton and change the Text attribute to "Insert New Product" if the original value is "Edit" and "Insert" if the original value is "Update". The following image contains the DataGrid both in "regular" mode and "edit" mode: 
  
dg_Update  
protected void dg_Update( System.Object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e ) {

System.String NewProductName = ( ( System.Web.UI.WebControls.TextBox )dg.Items[0].Cells[ 1 ].Controls[ 0 ] ).Text;
dg.EditItemIndex = - 1;
this.dg_bind( );
this.DataBind( );

if ( e.Item.ItemIndex == 0 ) {

System.Web.HttpContext.Current.Response.Write( "<BR>1. NEW RECORD VALUE: " + NewProductName );
System.Web.HttpContext.Current.Response.Write( "<BR>2. INSERT STATEMENT EXECUTED..." );
System.Web.HttpContext.Current.Response.Write( "<BR>3. RE-BIND DATAGRID - THE NEW RECORD IS ADDED AND DISPLAYED IN GRID");

}
 
Again, you'll notice I use an if...then statement to see if the ItemIndex of the Item is 0. I do this for one reason: Typically, this method will "UPDATE" an item in a database, but because this is an "INSERT" a different T-SQL Statment must be used or you'll get an exception. This way the same method can handle both insertions and updates.  
Well that's about it, if you have any questions please don't hesitate to e-mail me. I can always add more to this article or if warrented I can do a Part II to get a little more compilicated!  
