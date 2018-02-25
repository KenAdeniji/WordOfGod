using System; 
using System.Collections; 
using System.ComponentModel; 
using System.Data; 
using System.Drawing; 
using System.Web; 
using System.Web.SessionState; 
using System.Web.UI; 
using System.Web.UI.WebControls; 
using System.Web.UI.HtmlControls; 
using System.Data.SqlClient; 

namespace WordEngineering
{ 
    public class CreateMultipleDynamicASPNETDataGridPage : System.Web.UI.Page 
    { 
        public static int numCtrls=0; 
        private void Page_Load(object sender, System.EventArgs e) 
        { 
       DataGrid DataGrid1 = new DataGrid(); 
       DataGrid DataGrid2=new DataGrid(); 
       DataGrid DataGrid3=new DataGrid(); 
            CreateGrid(DataGrid1,"select  * from customers where customerID like 'B%'"); 
            CreateGrid(DataGrid2,"select  * from customers where customerID like 'A%'"); 
            CreateGrid(DataGrid3,"select  * from customers where customerID like 'D%'"); 
            Page.DataBind(); 
        } 

        private  void CreateGrid( DataGrid GridName, string strSQL) 
        { 
            SqlDataReader dr = GetDataReader(strSQL); 
            DataGrid    DG = new DataGrid(); 
            DG.BorderWidth = Unit.Pixel(2); 
            DG.CellPadding = 2; 
            DG.GridLines = GridLines.Both; 
            DG.BorderColor = Color.Black; 
            DG.ShowHeader = true; 
            DG.AutoGenerateColumns = false; 
            DG.ShowFooter=true; 
            DG.ShowHeader=true; 
            DataTable dt =dr.GetSchemaTable(); 
            System.Int32 columncount = dr.FieldCount; 
            for ( System.Int32 iCol = 0; iCol < columncount; iCol ++ ) { 
                BoundColumn datagridcol = new BoundColumn(); 
                datagridcol.HeaderText =    dr.GetName( iCol ).ToString(); 
                datagridcol.DataField =      dr.GetName( iCol ).ToString(); 
                DG.Columns.Add(datagridcol); 
            }     
            GridName=DG; 
            //Page.Controls[1].Controls.Add(GridName); 
            Page.Controls.Add(GridName);
            GridName.DataSource = dr; 
        } 
        private SqlDataReader GetDataReader(string SQLString){ 
            SqlDataReader dr =null; 
            SqlConnection sConn=null; 
            SqlCommand myCommand=null; 
            try 
            { 
               string strSQL = SQLString; 
               sConn = new SqlConnection("Initial Catalog=Northwind;Data Source=localhost;Integrated Security=SSPI;"); 
               myCommand = new SqlCommand(strSQL,sConn); 
               sConn.Open(); 
               dr = myCommand.ExecuteReader(); 
            } 
            catch (Exception ex) 
            { throw new  Exception( ex.Message );} 
             return dr; 
            } 
        override protected void OnInit(EventArgs e) 
        { 
            InitializeComponent(); 
            base.OnInit(e); 
        } 
        private void InitializeComponent() 
        {     
            this.Load += new System.EventHandler(this.Page_Load); 
        } 
    } 
} 