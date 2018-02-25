<%@ Page Language="C#" %>
<html>
  <head runat="server">
    <title>Updating Data Using GridView</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:GridView ID="GridView1" AllowSorting="true" AllowPaging="true" Runat="server"
        DataSourceID="SqlDataSource1" AutoGenerateEditButton="true" DataKeyNames="au_id"
        AutoGenerateColumns="False">
        <Columns>
          <asp:BoundField ReadOnly="true" HeaderText="ID" DataField="au_id" SortExpression="au_id" />
          <asp:BoundField HeaderText="Last Name" DataField="au_lname" SortExpression="au_lname" />
          <asp:BoundField HeaderText="First Name" DataField="au_fname" SortExpression="au_fname" />
          <asp:BoundField HeaderText="Phone" DataField="phone" SortExpression="phone" />
          <asp:BoundField HeaderText="Address" DataField="address" SortExpression="address" />
          <asp:BoundField HeaderText="City" DataField="city" SortExpression="city" />
          <asp:BoundField HeaderText="State" DataField="state" SortExpression="state" />
          <asp:BoundField HeaderText="Zip Code" DataField="zip" SortExpression="zip" />
          <asp:CheckBoxField HeaderText="Contract" SortExpression="contract" DataField="contract" />
        </Columns>
      </asp:GridView>
      
      <asp:SqlDataSource
      		ID="SqlDataSource1" 
      		Runat="server" 
      		SelectCommand="SELECT [au_id], [au_lname], [au_fname], [phone], [address], [city], [state], [zip], [contract] FROM [authors]"
        	UpdateCommand="UPDATE [authors] SET [au_lname] = @au_lname WHERE [au_id] = '10' "
        	ProviderName="System.Data.OleDb"                
   	        ConnectionString="Provider=SQLOLEDB;server=guidance;database=pubs;uid=sa;pwd=eTHan701"
        >
        
        <UpdateParameters>
	        <asp:Parameter Type="String" Name="au_lname" Value="10" />
	        <asp:Parameter Type="String" Name="au_fname" />
	        <asp:Parameter Type="String" Name="phone" />
	        <asp:Parameter Type="String" Name="address" />
	        <asp:Parameter Type="String" Name="city" />
	        <asp:Parameter Type="String" Name="state" />
	        <asp:Parameter Type="String" Name="zip" />
	        <asp:Parameter Type="Boolean" Name="contract" />
	        <asp:Parameter Name="original_au_id" />
         </UpdateParameters>
      
      </asp:SqlDataSource>
            
    </form>
  </body>
</html>
