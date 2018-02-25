<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.ContactDetailsViewPage" 
%>
 
<html>
 <head>
  <title>Contact Web Form</title>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>
    
     <asp:SqlDataSource 
      RunAt="server"
      ID="SqlDataSourceContact" 
      ConnectionString="server=localhost;database=WordEngineering;Integrated Security=SSPI;"
      ProviderName="System.Data.OleDb"
      SelectCommand="SELECT SequenceOrderId, FirstName, LastName, OtherName, Prefix, Suffix, Company, Commentary, ScriptureReference FROM Contact ORDER BY SequenceOrderId" 
      UpdateCommand="UPDATE Contact SET FirstName=@FirstName, LastName=@LastName, OtherName=@OtherName, Prefix=@Prefix, Suffix=@Suffix, Company=@Company, Commentary=@Commentary, ScripturePreference=@ScriptureReference WHERE SequenceOrderId=@SequenceOrderId"
     > 
      <UpdateParameters>
       <asp:Parameter Name="SequenceOrderId" Type="String"></asp:Parameter>
       <asp:Parameter Name="FirstName" Type="String"></asp:Parameter>
      </UpdateParameters>
     </asp:SqlDataSource>

     <asp:SqlDataSource
      RunAt="server"
      ID="SqlDataSourceContactEmail" 
      ProviderName="System.Data.OleDb"
     /> 

     <asp:SqlDataSource
      RunAt="server"
      ID="SqlDataSourceContactURI" 
      ProviderName="System.Data.OleDb"
     /> 

     <asp:SqlDataSource
      RunAt="server"
      ID="SqlDataSourceStreetAddress" 
      ProviderName="System.Data.OleDb"
     /> 

     <asp:SqlDataSource
      RunAt="server"
      ID="SqlDataSourceTelephone" 
      ProviderName="System.Data.OleDb"
     /> 

     <!--
     
     <tr align="center">
      <td align="center" colspan="2">

       <asp:detailsview runat="server" id="DetailsViewContact" 
        defaultmode="Edit"  
        autogeneraterows="false"
        autogenerateeditbutton="true"
        datasourceid="SqlDataSourceContact">
      
        <Fields>
      
         <asp:BoundField
          DataField="SequenceOrderId" 
          HeaderText="SequenceOrderId" 
          ReadOnly=true
         />

         <asp:BoundField
          DataField="FirstName" 
          HeaderText="FirstName" 
         />

         <asp:BoundField
          DataField="LastName" 
          HeaderText="LastName" 
         />

         <asp:BoundField
          DataField="OtherName" 
          HeaderText="OtherName" 
         />

         <asp:BoundField
          DataField="Prefix" 
          HeaderText="Prefix" 
         />

         <asp:BoundField
          DataField="Suffix" 
          HeaderText="Suffix" 
          />

         <asp:BoundField
          DataField="Company" 
          HeaderText="Company" 
         />

         <asp:BoundField
          DataField="Commentary" 
          HeaderText="Commentary"
         />

         <asp:BoundField
          DataField="ScriptureReference" 
          HeaderText="ScriptureReference"
         />
         
        </Fields>
        
       </asp:detailsview>
       
      </td>
     </tr>
     -->

     <tr>
      <td align="left" colspan="1">
       <asp:Label
        id="LabelSequenceOrderId"
        runat="server"
        text="Sequence Order Id: "
       />
      </td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxSequenceOrderId" 
        runat="server"
       />
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:Label
        id="LabelFirstName"
        runat="server"
        text="First Name: "
       />
      </td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxFirstName" 
        runat="server"
        Columns="50"
        MaxLength="50"
       />
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:Label
        id="LabelLastName" 
        text="Last Name: "
        runat="server"
       />
      </td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxLastName" 
        runat="server"
        Columns="50"
        MaxLength="50"
       />
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:Label
        id="LabelOtherName" 
        text="Other Name: "
        runat="server"
       />
      </td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxOtherName" 
        runat="server"
        Columns="50"
        MaxLength="50"
       />
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:Label
        id="LabelPrefix" 
        text="Prefix: "
        runat="server"
       />
      </td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxPrefix"
        runat="server"
        Columns="50"
        MaxLength="50"
       />
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:Label
        id="LabelSuffix" 
        text="Suffix: "
        runat="server"
       />
      </td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxSuffix" 
        runat="server"
        Columns="50"
        MaxLength="50"
       />
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:Label
        id="LabelCompany" 
        text="Company: "
        runat="server"
       />
      </td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxCompany" 
        runat="server"
        Columns="50"
        MaxLength="50"
       />
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:Label
        id="LabelCommentary" 
        text="Commentary: "
        runat="server"
       />
      </td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxCommentary" 
        runat="server"
        Columns="50"
        MaxLength="1000"
        TextMode="MultiLine"
        Rows="5"
       />
      </td>
     </tr>

     <tr>
      <td align="left" colspan="1">
       <asp:Label
        id="LabelScriptureReference" 
        text="ScriptureReference: "
        runat="server"
       />
      </td>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxScriptureReference" 
        runat="server"
        Columns="50"
        MaxLength="1000"
       />
      </td>
     </tr>
     
     <tr align="center">
      <td align="center" colspan="2">
       <asp:GridView 
        id="GridViewContactEmail" 
        runat="server" 
        allowPaging="true"
        allowSorting="true"
        AutoGenerateColumns=false
        AutoGenerateEditButton=true
        DataKeyField="SequenceOrderId"
       >
        <Columns>
         <asp:HyperLinkField
          DataTextField="SequenceOrderId" 
          DataNavigateURLFields="SequenceOrderId, EmailAddress"
          DataNavigateURLFormatString="ContactEmailDetailWebForm.aspx?SequenceOrderId={0}&EmailAddress={1}"
          Target="_blank"
         />
         <asp:BoundField
          DataField="EmailAddress" 
          HeaderText="EmailAddress" 
          SortExpression="EmailAddress"
         />
        </Columns>
       </asp:GridView>
      </td>
     </tr>

     <tr align="center">
      <td align="center" colspan="2">
       <asp:GridView 
        id="GridViewContactURI"
        runat="server" 
        allowPaging="true"
        allowSorting="true"
        AutoGenerateColumns=false
        AutoGenerateEditButton=true        
        DataKeyField="SequenceOrderId"
       >
        <Columns>
         <asp:HyperLinkField
          DataTextField="SequenceOrderId" 
          DataNavigateURLFields="SequenceOrderId, InternetAddress"
          DataNavigateURLFormatString="ContactInternetAddressDetailWebForm.aspx?SequenceOrderId={0}&InternetAddress={1}"
          Target="_blank"
         />
         <asp:BoundField
          DataField="InternetAddress" 
          HeaderText="InternetAddress" 
          SortExpression="InternetAddress"
         />
        </Columns>
       </asp:GridView>
      </td>
     </tr>

     <tr align="center">
      <td align="center" colspan="2">
       <asp:GridView 
        id="GridViewTelephone"
        runat="server" 
        allowPaging="true"
        allowSorting="true"
        AutoGenerateColumns=false
        AutoGenerateEditButton=true
        DataKeyField="SequenceOrderId"        
       >
        <Columns>
         <asp:HyperLinkField
          DataTextField="SequenceOrderId" 
          DataNavigateURLFields="SequenceOrderId, TelephoneNo, TelephoneLocation"
          DataNavigateURLFormatString="ContactTelephoneDetailWebForm.aspx?SequenceOrderId={0}&TelephoneNo={1}&TelephoneLocation={2}"
          Target="_blank"
         />
         <asp:BoundField
          DataField="TelephoneNo"
          HeaderText="TelephoneNo" 
          SortExpression="TelephoneNo"
         />
         <asp:BoundField
          DataField="TelephoneLocation"
          HeaderText="TelephoneLocation" 
          SortExpression="TelephoneLocation"
         />
        </Columns>
       </asp:GridView>
      </td>
     </tr>

     <tr align="center">
      <td align="center" colspan="2">
       <asp:GridView 
        id="GridViewStreetAddress"
        runat="server" 
        allowPaging="true"
        allowSorting="true"
        AutoGenerateColumns=false
        AutoGenerateEditButton=true
        DataKeyField="SequenceOrderId"        
       >
        <Columns>
         <asp:HyperLinkField
          DataTextField="SequenceOrderId" 
          DataNavigateURLFields="SequenceOrderId, AddressLine1, City, State, ZipCode, Country"
          DataNavigateURLFormatString="ContactStreetAddressDetailWebForm.aspx?SequenceOrderId={0}&AddressLine1={1}&City={2}&State={3}&Country={4}"
          Target="_blank"
         />
         <asp:BoundField
          DataField="AddressLine1"
          HeaderText="AddressLine1" 
          SortExpression="AddressLine1"
         />
         <asp:BoundField
          DataField="City"
          HeaderText="City" 
          SortExpression="City"
         />
         <asp:BoundField
          DataField="State"
          HeaderText="State" 
          SortExpression="State"
         />
         <asp:BoundField
          DataField="ZipCode"
          HeaderText="ZipCode" 
          SortExpression="ZipCode"
         />
         <asp:BoundField
          DataField="Country"
          HeaderText="Country" 
          SortExpression="Country"
         />
        </Columns>
       </asp:GridView>
      </td>
     </tr>

     <tr align="center">
      <td align="center" colspan="2">
       <asp:Button id="ButtonSubmit"  onclick="ButtonSubmit_Click"     runat="server"   Text="Submit"/>
       <asp:Button id="ButtonReset"   onclick="ButtonReset_Click"      runat="server"   Text="Reset"/>
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