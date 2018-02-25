<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.ContactGridViewPage" 
%>
 
<html>
 <head>
  <title>Contact GridView</title>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>
    
     <tr>
      <td align="left" colspan="4">
      
       <asp:SqlDataSource 
        RunAt="server"
        ID="SqlDataSourceContact" 
        ConnectionString="server=localhost;database=WordEngineering;Integrated Security=SSPI;"
        ProviderName="System.Data.OleDb"
        SelectCommand="SELECT SequenceOrderId, FirstName, LastName, OtherName, Company FROM Contact ORDER BY SequenceOrderId" 
        UpdateCommand="UPDATE Contact SET FirstName=@FirstName, LastName=@LastName, Company=@Company WHERE SequenceOrderId=@SequenceOrderId"
       /> 
       
       <asp:GridView 
        RunAt="server" 
        ID="GridViewContact"
        AutoGenerateColumns=false
        AutoGenerateEditButton=true
        DataKeyField="SequenceOrderId"
        AllowPaging="true"
        AllowSorting="true"
       >

        <HeaderStyle
         BackColor='#CCCC99'/>

        <RowStyle
         BackColor='#eeeeee'/>
			
        <AlternatingRowStyle
         BackColor='#ffffe8'/>
         
        <Columns>

         <asp:HyperLinkField
          DataTextField="SequenceOrderId" 
          DataNavigateURLFields="SequenceOrderId, FirstName, LastName, OtherName"
          DataNavigateURLFormatString="ContactDetailsViewWebForm.aspx?SequenceOrderId={0}&FirstName={1}&LastName={2}&OtherName={3}"
          Target="_blank"
         />

         <asp:BoundField
          DataField="FirstName" 
          HeaderText="FirstName" 
          SortExpression="FirstName"
         />

         <asp:BoundField
          DataField="LastName" 
          HeaderText="LastName" 
          SortExpression="LastName"
         />

         <asp:BoundField
          DataField="OtherName" 
          HeaderText="OtherName" 
          SortExpression="OtherName"
         />

         <asp:BoundField
          DataField="Company" 
          HeaderText="Company" 
          SortExpression="Company"
         />

        </Columns>

       </asp:GridView>
      </td>
     </tr>
     
     <tr>
      <td align="left" colspan="4"><asp:Literal id="LiteralFeedback" runat="server" /></td>
     </tr>    

    </tbody>    
   </table>    
  </form>
 </body>
</html>