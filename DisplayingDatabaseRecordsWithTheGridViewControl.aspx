<%@ Page Language="c#" %>

<html>
<head runat="server">
    <title>Display GridView</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:GridView 
        DataSourceID="TitlesSource"
        Runat="Server" 
        AllowSorting="true"
        AllowPaging="true"
        PageSize="4"
        AutoGenerateEditButton="true"
        DataKeyNames="SequenceOrderId"
    />
    
    <asp:Label 
        ID="lblError" 
        ForeColor="Red"
        EnableViewState="false" 
        Runat="Server" />
    
    <asp:SqlDataSource 
        ID="TitlesSource"
        ConnectionString="SERVER=(local);DATABASE=WordEngineering;UID=WordEngineering;PWD=khouse;"
        SelectCommand="SELECT SequenceOrderId, ContactId, FirstName, LastName, Dated FROM Contact Order By FirstName, LastName"
        UpdateCommand="dbo.usp_ContactUpdate"
        Runat="Server" > 
        
		<UpdateParameters>
			<asp:Parameter Type="String" Name="ContactId"></asp:Parameter>					
			<asp:Parameter Type="String" Name="FirstName"></asp:Parameter>
			<asp:Parameter Type="String" Name="LastName"></asp:Parameter>
		</UpdateParameters>		
						        
    </asp:SqlDataSource>        
    
    </form>
</body>
</html>