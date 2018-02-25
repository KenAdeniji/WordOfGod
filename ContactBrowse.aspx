<%@ Page
 	Language="c#"     
%>
<html>
<head runat="server">
    <title>Display GridView</title>
</head>
<body>
    <form id="form1" runat="server">

    <asp:Label 
        ID="lblError" 
        ForeColor="Red"
        EnableViewState="false" 
        Runat="Server" />
            
    <asp:GridView 
        DataSourceID="DataSourceContact"
        Runat="Server" 
        AutoGenerateEditButton="true"
        DataKeyNames="SequenceOrderId"
        AutoGenerateColumns="false"
    >
        
        
		<Columns>
		
			<asp:BoundField  DataField="FirstName"/>
			<asp:BoundField  DataField="LastName"/>	
					        
		</Columns>
	
    </asp:GridView>	
	    
    <asp:ObjectDataSource 
        ID="DataSourceContact"
		TypeName="WordEngineering.frmContactBrowse"
		SelectMethod="getContacts"
		UpdateMethod="updateContact"		
        Runat="Server" > 
        
        <UpdateParameters>

	        <asp:Parameter Name="SequenceOrderId" Type="Int16"/>	                
	        <asp:Parameter Name="FirstName" Type="String"/>
	        <asp:Parameter Name="LastName" Type="String"/>

                                
        </UpdateParameters>
        					        
    </asp:ObjectDataSource>        
    
    </form>
</body>
</html>