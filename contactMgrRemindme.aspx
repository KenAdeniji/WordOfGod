<%@ Page 
 Language="C#" 
%>
 
<html>
 <head>
  <title>Contact GridView</title>
 </head>
 <body>
 
  <form 
  	id="frmContactMgr"
  	runat="server">
  	
       <asp:SqlDataSource 
        RunAt="server"
        ID="SqlDataSourceContact" 
        ProviderName="System.Data.OleDb"        
        SelectCommand="SELECT top 5 [contactIdentifier], [contact] FROM Contacts" 
        UpdateCommand="update dbo.contacts set [contact] = [contact] where 1 = 0 and [contact] = @contact "
       > 

              
       </asp:SqlDataSource> 
              
       <asp:GridView 
        RunAt="server" 
        ID="GridViewContact"
        DataSourceID="SqlDataSourceContact" 
        AutoGenerateColumns="false"
        AutoGenerateEditButton="true"
        DataKeyNames="contactIdentifier"            
       >
       
       		<Columns>

	   		<asp:BoundField
	   			DataField="contactIdentifier"
	   			ReadOnly="true"
	   			Visible="True"
			/>	   				   
			
			
	   		<asp:BoundField
	   			DataField="contact"
	   			ReadOnly="false"
			/>	   				

			       		
       		</Columns>
       		                
       </asp:GridView>        
                	
  >
  
  </form>
  
 </body>
</html>