<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.ContactDetailPage" 
%>
 
<html>
 <head>
  <title>Contact Detail</title>
 </head>
 <body>
  <form runat="server">
  
   <table align="center" border="0">
    <tbody>

     <tr>
      <td align="left" colspan="1">
       <asp:TextBox 
        id="TextBoxSequenceOrderId" 
        runat="server"
        Visible=false
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
      <td align="left" colspan="2"><asp:Literal id="LiteralFeedback" runat="server" /></td>
     </tr>    

    </tbody>    
   </table>    
  </form>
 </body>
</html>