<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.ContactGridViewObjectDataSourcePage" 
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
      <td align="left">
       <asp:label>Lastname:</asp:label>
      </td>
      <td> 
       <asp:textbox id="TextboxLastName" runat="server" text="" />
      </td>
      <td>  
       <asp:label>Firstname:</asp:label>
      </td>
      <td> 
       <asp:textbox id="TextboxFirstName" runat="server" text="" />
      </td>
     </tr>
     <tr>
      <td> 
       <asp:label>Othername:</asp:label>
      </td>
      <td> 
       <asp:textbox id="TextboxOtherName" runat="server" text="" />
      </td>
      <td> 
       <asp:label>Company:</asp:label>
      </td>
      <td> 
       <asp:textbox id="TextboxCompany" runat="server" text="" />
      </td>
     </tr>
     
     <tr>
      <td colspan=3 />
      <td align=right> 
       <asp:Button 
        id="ButtonSearch" 
        runat="server" 
        value="Search" 
        text="Search" 
        OnServerClick="SearchBtnClick" 
       />
      </td>
     </tr>
            
     <tr>
      <td align="left" colspan="4">
      
       <asp:ObjectDataSource 
        RunAt="server"
        ID="ObjectDataSourceContact" 
		typename="WordEngineering.ContactGridViewObjectDataSourceTypeName"
        SelectMethod="SelectMethodContactDataSet"
		UpdateMethod="UpdateMethodContact"		
       > 

        <selectParameters>
         <asp:controlParameter
          type="String"
          name="lastName"
          controlId="TextBoxLastName"
          defaultValue=""
          propertyName="Text"
         /> 
         <asp:controlParameter
          type="String"
          name="firstName"
          controlId="TextBoxFirstName"
          defaultValue=""
          propertyName="Text"
         />
         <asp:controlParameter
          type="String"
          name="otherName"
          controlId="TextBoxOtherName"
          defaultValue=""
          propertyName="Text"
         />
         <asp:controlParameter
          type="String"
          name="company"
          controlId="TextBoxCompany"
          defaultValue=""
          propertyName="Text"
         />
        </selectParameters>

        <UpdateParameters>
         <asp:Parameter Name="SequenceOrderId" Type="Decimal"/>		       	
        </UpdateParameters>

       </asp:ObjectDataSource> 
       
       <asp:GridView 
        RunAt="server" 
        ID="GridViewContact"
        DataSourceID="ObjectDataSourceContact" 
        AutoGenerateColumns=false
        AutoGenerateEditButton=true
        DataKeyField="SequenceOrderId"
        DataKeyNames="SequenceOrderId"            
        AllowPaging="false"
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
          DataField="LastName" 
          HeaderText="LastName" 
          SortExpression="LastName"
         />

         <asp:BoundField
          DataField="FirstName" 
          HeaderText="FirstName" 
          SortExpression="FirstName"
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