using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class TableSample : System.Web.UI.Page
{
 protected void Page_Load(Object sender, EventArgs e)
 {
  TblSample.BorderStyle = BorderStyle.Inset;
  TblSample.BorderWidth = Unit.Pixel(1);
 }

 protected void Create_Click(Object sender, EventArgs e)
 {
  int columns;
  int rows;

  TableCell tableCell;
  TableRow tableRow;

  TblSample.Controls.Clear();

  Int32.TryParse(TableRows.Text, out rows);
  Int32.TryParse(TableColumns.Text, out columns);

  for (int row=0; row < rows; row++)
  {
   tableRow = new TableRow();
   TblSample.Controls.Add(tableRow);
   for(int column=0; column < columns; column++)
   {
    tableCell = new TableCell();
    tableCell.Text = row.ToString() + ',' + column.ToString();
    if (TableBorder.Checked)
    {
     tableCell.BorderStyle = BorderStyle.Inset;
     tableCell.BorderWidth = Unit.Pixel(1);
    }
    tableRow.Controls.Add(tableCell);
   }
  }

 }
}