<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.ContactMaintenancePage"
%>

<%@ Register Assembly="UtilityProtocol" Namespace="WordEngineering" TagPrefix="UtilityProtocol" %>

<html>
 <head>
  <title>Contact</title>
 </head>
 <body>
  <form 
   ID="formContact" 
   runat="server"
   enctype="multipart/form-data"    
   autocomplete="on"
   defaultbutton="ButtonSubmit"
   defaultfocus="TextBoxFirstName"
  >

   <table align="center" border="0">
    <tbody>
     <asp:Panel
      runat="server"
      id="PanelSearchQuery"
     >
      <tr align="center">
       <td align="center" colspan=4>
        Search Query
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelFirstName"
         Text="First Name:"
         AccessKey="F"
         AssociatedControlId="TextBoxFirstName"
        />
       </td>
       <td align="left">
        <asp:TextBox
         ID="TextBoxFirstName"
         runat="Server"
        />        
       </td>
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelLastName"
         Text="Last Name:"
         AccessKey="L"
         AssociatedControlId="TextBoxLastName"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxLastName"
         runat="Server"
        />        
       </td>
      </tr>

      <tr align="center">       
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelOtherName"
         Text="Other Name:"
         AccessKey="O"
         AssociatedControlId="TextBoxOtherName"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxOtherName"
         runat="Server"
        />        
       </td>
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelCompany"
         Text="Company:"
         AccessKey="C"
         AssociatedControlId="TextBoxCompany"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxCompany"
         runat="Server"
        />        
       </td>
      </tr>
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelCommentary"
         Text="Commentary:"
         AccessKey="C"
         AssociatedControlId="TextBoxCommentary"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxCommentary"
         runat="Server"
        />        
       </td>
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelTelephoneNo"
         Text="Telephone No:"
         AccessKey="T"
         AssociatedControlId="TextBoxTelephoneNo"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxTelephoneNo"
         runat="Server"
        />        
       </td>
      </tr>
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelEmailAddress"
         Text="E-Mail Address:"
         AccessKey="E"
         AssociatedControlId="TextBoxEmailAddress"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxEmailAddress"
         runat="Server"
        />        
       </td>
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelInternetAddress"
         Text="Internet Address:"
         AccessKey="I"
         AssociatedControlId="TextBoxInternetAddress"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxInternetAddress"
         runat="Server"
        />        
       </td>
      </tr>

      <tr align="center">
      </tr>
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelStreetAddress"
         Text="Street Address:"
         AccessKey="S"
         AssociatedControlId="TextBoxAddressLine1"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxAddressLine1"
         runat="Server"
        />        
       </td>
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelCity"
         Text="City:"
         AccessKey="C"
         AssociatedControlId="TextBoxCity"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxCity"
         runat="Server"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelState"
         Text="State:"
         AccessKey="C"
         AssociatedControlId="TextBoxState"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxState"
         runat="Server"
        />        
       </td>
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelZipCode"
         Text="Zip Code:"
         AccessKey="Z"
         AssociatedControlId="TextBoxZipCode"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxZipCode"
         runat="Server"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelCountry"
         Text="Country:"
         AccessKey="C"
         AssociatedControlId="TextBoxCountry"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxCountry"
         runat="Server"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelDatedFrom"
         Text="Dated From:"
         AccessKey="D"
         AssociatedControlId="TextBoxDatedFrom"
        />
       </td>
       <td align="left">        
        <asp:TextBox
         ID="TextBoxDatedFrom"
         runat="Server"
        />
       </td>
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelDatedTo"
         Text="Dated To:"
         AccessKey="D"
         AssociatedControlId="TextBoxDatedTo"
        />
       </td>        
       <td align="left">
        <asp:TextBox
         ID="TextBoxDatedTo"
         runat="Server"
        />
       </td>
      </tr>
      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelSequenceOrderIdFrom"
         Text="Sequence Order Id From:"
         AccessKey="D"
         AssociatedControlId="TextBoxSequenceOrderIdFrom"
        />
       </td>
       <td align="left">        
        <asp:TextBox
         ID="TextBoxSequenceOrderIdFrom"
         runat="Server"
        />
       </td>        
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelSequenceOrderIdTo"
         Text="Sequence Order Id To:"
         AccessKey="D"
         AssociatedControlId="TextBoxSequenceOrderIdTo"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         ID="TextBoxSequenceOrderIdTo"
         runat="Server"
        />
       </td>
      </tr>
      <tr align="center">
       <td align="center" colspan="4">
        <asp:Button runat="server" id="ButtonSubmit"  onclick="ButtonSubmit_Click"  Text="Submit"/>
        <asp:Button runat="server" id="ButtonReset"   onclick="ButtonReset_Click"   Text="Reset"/>
       </td>      
      </tr>        
     </asp:Panel>
    </tbody>    
   </table>    

   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td>
       <asp:SqlDataSource
        ID="SqlDataSourceContact"
        Runat="server"
        ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
        DeleteCommand="DELETE Contact WHERE sequenceOrderId = @original_sequenceOrderId"
        InsertCommand="EXEC uspContactInsert @sequenceOrderId, @dated, @title, @firstName, @lastName, @otherName, @company, @commentary"
        SelectCommand="EXEC uspContactSelect @sequenceOrderIdFrom, @sequenceOrderIdTo, @datedFrom, @datedTo, @firstName, @lastName, @otherName, @company, @commentary, @telephoneNo, @emailAddress, @internetAddress, @addressLine1, @city, @state, @zipCode, @country"
        UpdateCommand="UPDATE Contact SET firstName = @firstName, lastName = @lastName, otherName = @otherName, title = @title, company = @company, commentary = @commentary WHERE sequenceOrderId = @original_sequenceOrderId"
       >
        <insertparameters>
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
         <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
         <asp:parameter name="title" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="firstName" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="lastName" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="otherName" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="company" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="commentary" ConvertEmptyStringToNull=true Type="string" />
        </insertparameters>
        <selectparameters>
         <asp:controlparameter name="sequenceOrderIdFrom" controlid="TextBoxSequenceOrderIdFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="InputOutput" />
         <asp:controlparameter name="sequenceOrderIdTo" controlid="TextBoxSequenceOrderIdTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="Int32" Direction="InputOutput" />
         <asp:controlparameter name="datedFrom" controlid="TextBoxDatedFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" />
         <asp:controlparameter name="datedTo" controlid="TextBoxDatedTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" />
         <asp:controlparameter name="firstName" controlid="TextBoxFirstName" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="lastName" controlid="TextBoxLastName" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="otherName" controlid="TextBoxOtherName" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="company" controlid="TextBoxCompany" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="commentary" controlid="TextBoxCommentary" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="telephoneNo" controlid="TextBoxTelephoneNo" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="emailAddress" controlid="TextBoxEmailAddress" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="internetAddress" controlid="TextBoxInternetAddress" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="addressLine1" controlid="TextBoxAddressLine1" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="city" controlid="TextBoxCity" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="state" controlid="TextBoxState" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="zipCode" controlid="TextBoxZipCode" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />
         <asp:controlparameter name="country" controlid="TextBoxCountry" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="InputOutput" />         
        </selectparameters>
       </asp:SqlDataSource>

       <asp:GridView
        id="GridViewContact" 
        runat="server" 
        AllowPaging=True
        AllowSorting=True 
        AutoGenerateColumns=False
        AutoGenerateDeleteButton=True
        AutoGenerateEditButton=True
        AutoGenerateSelectButton=True        
        DataKeyNames="sequenceOrderId"
        DataSourceID="SqlDataSourceContact"
        OnPreRender="GridView_PreRender"
        OnRowCommand="GridView_RowCommand"
        OnRowUpdated="GridView_RowUpdated"
        SelectedIndex=0
        ShowFooter=True
       >
        <HeaderStyle
         BackColor='#CCCC99'/>

        <RowStyle
         BackColor='#eeeeee'/>
			
        <AlternatingRowStyle
         BackColor='#ffffe8'/>

        <Columns>
               
         <asp:TemplateField
          HeaderText="First Name"
          SortExpression="FirstName"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactItemTemplateFirstName" 
            Text='<%# Eval("FirstName") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEditItemTemplateFirstName" 
            Text='<%# Bind("FirstName") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactFooterTemplateFirstName"
            Text='<%# Bind("FirstName") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Last Name"
          SortExpression="LastName"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactItemTemplateLastName" 
            Text='<%# Eval("LastName") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEditItemTemplateLastName" 
            Text='<%# Bind("LastName") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactFooterTemplateLastName"
            Text='<%# Bind("LastName") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Other Name"
          SortExpression="OtherName"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactItemTemplateOtherName" 
            Text='<%# Eval("OtherName") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEditItemTemplateOtherName" 
            Text='<%# Bind("OtherName") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactFooterTemplateOtherName"
            Text='<%# Bind("OtherName") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Title"
          SortExpression="Title"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactItemTemplateTitle" 
            Text='<%# Eval("Title") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEditItemTemplateTitle" 
            Text='<%# Bind("Title") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactFooterTemplateTitle"
            Text='<%# Bind("Title") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Company"
          SortExpression="Company"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactItemTemplateCompany" 
            Text='<%# Eval("Company") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEditItemTemplateCompany" 
            Text='<%# Bind("Company") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactFooterTemplateCompany"
            Text='<%# Bind("Company") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Commentary"
          SortExpression="Commentary"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactItemTemplateCommentary" 
            Text='<%# Eval("Commentary") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEditItemTemplateCommentary" 
            Text='<%# Bind("Commentary") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactFooterTemplateCommentary"
            Text='<%# Bind("Commentary") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Dated"
          SortExpression="Dated"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactItemTemplateDated" 
            Text='<%# Eval("Dated", "{0:d}") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEditItemTemplateDated" 
            Text='<%# Bind("Dated") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactFooterTemplateDated"
            Text='<%# Bind("Dated") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="SequenceOrderId"
          SortExpression="SequenceOrderId"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactItemTemplateSequenceOrderId" 
            Text='<%# Eval("SequenceOrderId") %>'
           />
          </ItemTemplate>
<%--
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEditItemTemplateSequenceOrderId" 
            Text='<%# Bind("SequenceOrderId") %>'
           />
          </EditItemTemplate>
--%>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactFooterTemplateSequenceOrderId"
            Text='<%# Bind("SequenceOrderId") %>'
           />
           <asp:Button 
            Runat="Server"           
            ID="ButtonGridViewContactFooterTemplateAdd"
            CommandName="ButtonGridViewContactFooterTemplateAdd" 
            Text="Add"
           />
          </FooterTemplate>
         </asp:TemplateField>
         
        </Columns>
        <pagersettings mode="Numeric"
         position="Bottom"           
         pagebuttoncount="10"
        />
        <pagerstyle backcolor="LightBlue"
         height="30px"
         verticalalign="Bottom"
         horizontalalign="Center"
        />
       </asp:GridView>
      </td>
     </tr>
    </tbody>
   </table>

   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
       <asp:SqlDataSource
        ID="SqlDataSourceContactEmail"
        Runat="server"
        ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
        DeleteCommand="DELETE ContactEmail WHERE sequenceOrderId = @original_sequenceOrderId"
        InsertCommand="EXEC uspContactEmailInsert @sequenceOrderId, @dated, @contactId, @emailAddress"
        SelectCommand="SELECT sequenceOrderId, dated, emailAddress FROM ContactEmail WHERE contactId = @contactId"
        UpdateCommand="UPDATE ContactEmail SET dated = @dated, emailAddress = @emailAddress WHERE sequenceOrderId = @original_sequenceOrderId"
       >
        <insertparameters>
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
         <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
         <asp:ControlParameter Name="contactId" ControlId="GridViewContact" PropertyName="SelectedValue" />
         <asp:parameter name="emailAddress" ConvertEmptyStringToNull=true Type="string" />
        </insertparameters>
        <selectparameters>
         <asp:ControlParameter Name="contactId" ControlId="GridViewContact" PropertyName="SelectedValue" />
        </selectparameters>
       </asp:SqlDataSource>

       <asp:GridView
        id="GridViewContactEmail" 
        runat="server" 
        AllowPaging=True
        AllowSorting=True 
        AutoGenerateColumns=False
        AutoGenerateDeleteButton=True
        AutoGenerateEditButton=True
        AutoGenerateSelectButton=True        
        DataKeyNames="sequenceOrderId"
        DataSourceID="SqlDataSourceContactEmail"
        OnPreRender="GridView_PreRender"
        OnRowCommand="GridView_RowCommand"
        OnRowUpdated="GridView_RowUpdated"
        SelectedIndex=0        
        ShowFooter=True
       >
        <HeaderStyle
         BackColor='#CCCC99'/>

        <RowStyle
         BackColor='#eeeeee'/>
			
        <AlternatingRowStyle
         BackColor='#ffffe8'/>

        <Columns>
               
         <asp:TemplateField
          HeaderText="E-mail"
          SortExpression="EmailAddress"
         >
          <ItemTemplate>
           <asp:HyperLink
            Runat="Server"
            id="HyperLinkGridViewContactEmailItemTemplateEmailAddress" 
            NavigateUrl='<%# "mailto:" + Eval("EmailAddress").ToString() %>'
            Text='<%# Eval("EmailAddress") %>'
            Target="_blank"
           />  
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEmailEditItemTemplateEmailAddress" 
            Text='<%# Bind("EmailAddress") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEmailFooterTemplateEmailAddress"
            Text='<%# Bind("EmailAddress") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Dated"
          SortExpression="Dated"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactEmailItemTemplateDated" 
            Text='<%# Eval("Dated", "{0:d}") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEmailEditItemTemplateDated" 
            Text='<%# Bind("Dated") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEmailFooterTemplateDated"
            Text='<%# Bind("Dated") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="SequenceOrderId"
          SortExpression="SequenceOrderId"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactEmailItemTemplateSequenceOrderId" 
            Text='<%# Eval("SequenceOrderId") %>'
           />
          </ItemTemplate>
<%--
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEmailEditItemTemplateSequenceOrderId" 
            Text='<%# Bind("SequenceOrderId") %>'
           />
          </EditItemTemplate>
--%>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactEmailFooterTemplateSequenceOrderId"
            Text='<%# Bind("SequenceOrderId") %>'
           />
           <asp:Button 
            Runat="Server"           
            ID="ButtonGridViewContactEmailFooterTemplateAdd"
            CommandName="ButtonGridViewContactEmailFooterTemplateAdd" 
            Text="Add"
           />
          </FooterTemplate>
         </asp:TemplateField>
         
        </Columns>
        <pagersettings mode="Numeric"
         position="Bottom"           
         pagebuttoncount="10"
        />
        <pagerstyle backcolor="LightBlue"
         height="30px"
         verticalalign="Bottom"
         horizontalalign="Center"
        />
       </asp:GridView>
      </td>
     </tr>
    </tbody>    
   </table>

   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
         <asp:FormView 
          runat="server"
          id="FormViewContactEmail"
          AllowPaging="true"
          DataKeyNames="sequenceOrderId"
          DataSourceID="SqlDataSourceContactEmail"
          DefaultMode="Insert"
          OnItemInserted="FormView_ItemInserted"
          OnItemInserting="FormView_ItemInserting"
          Visible=false
         >
          <InsertItemTemplate>
           <table>
            <theader>
             <tr>
              <th>Email Address</th>
              <th>Dated</th>
              <th>SequenceOrderId</th>
             </tr>
            </theader>
            <tbody>
             <tr>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewContactEmailInsertItemTemplateEmailAddress" 
                Text='<%# Bind("EmailAddress") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewContactEmailInsertItemTemplateDated" 
                Text='<%# Bind("Dated") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewContactEmailInsertItemTemplateSequenceOrderId" 
                Text='<%# Bind("SequenceOrderId") %>'
               />
              </td>
              <td>
               <asp:Button 
                runat="server"
                id="ButtonFormViewContactEmail"  
                onclick="ButtonFormViewContactEmailInsert_Click"
                Text="Add"
               />
               <%--
               <asp:linkbutton 
                runat="server"
                id="LinkButtonInsert"
                text="Insert"
                commandname="Insert"
               />
               <asp:linkbutton 
                runat="server"
                id="LinkButtonCancel"
                text="Cancel"
                commandname="Cancel"
               />
               --%>
              </td>
             </tr> 
            </tbody>
           </table>       
          </InsertItemTemplate>
         </asp:FormView>
      </td>
     </tr>
    </tbody>    
   </table>

   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
       <asp:SqlDataSource
        ID="SqlDataSourceContactURI"
        Runat="server"
        ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
        DeleteCommand="DELETE ContactURI WHERE sequenceOrderId = @original_sequenceOrderId"
        InsertCommand="EXEC uspContactURIInsert @sequenceOrderId, @dated, @contactId, @internetAddress"
        SelectCommand="SELECT sequenceOrderId, dated, internetAddress FROM ContactURI WHERE contactId = @contactId"
        UpdateCommand="UPDATE ContactURI SET dated = @dated, internetAddress = @internetAddress WHERE sequenceOrderId = @original_sequenceOrderId"
       >
        <insertparameters>
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
         <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
         <asp:ControlParameter Name="contactId" ControlId="GridViewContact" PropertyName="SelectedValue" />
         <asp:parameter name="internetAddress" ConvertEmptyStringToNull=true Type="string" />
        </insertparameters>
        <selectparameters>
         <asp:ControlParameter Name="contactId" ControlId="GridViewContact" PropertyName="SelectedValue" />
        </selectparameters>
       </asp:SqlDataSource>

       <asp:GridView
        id="GridViewContactURI" 
        runat="server" 
        AllowPaging=True
        AllowSorting=True 
        AutoGenerateColumns=False
        AutoGenerateDeleteButton=True
        AutoGenerateEditButton=True
        AutoGenerateSelectButton=True        
        DataKeyNames="sequenceOrderId"
        DataSourceID="SqlDataSourceContactURI"
        OnPreRender="GridView_PreRender"
        OnRowCommand="GridView_RowCommand"
        OnRowUpdated="GridView_RowUpdated"
        SelectedIndex=0        
        ShowFooter=True
       >
        <HeaderStyle
         BackColor='#CCCC99'/>

        <RowStyle
         BackColor='#eeeeee'/>
			
        <AlternatingRowStyle
         BackColor='#ffffe8'/>

        <Columns>
               
         <asp:TemplateField
          HeaderText="URI"
          SortExpression="InternetAddress"
         >
          <ItemTemplate>
           <asp:HyperLink
            Runat="Server"
            id="HyperLinkGridViewContactURIItemTemplateInternetAddress" 
            NavigateUrl='<%# UtilityProtocol.PrefixProtocol( Eval("InternetAddress").ToString() ) %>'
            Text='<%# Eval("InternetAddress") %>'
            Target="_blank"
           />  
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactURIEditItemTemplateInternetAddress" 
            Text='<%# Bind("InternetAddress") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactURIFooterTemplateInternetAddress"
            Text='<%# Bind("InternetAddress") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Dated"
          SortExpression="Dated"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactURIItemTemplateDated" 
            Text='<%# Eval("Dated", "{0:d}") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactURIEditItemTemplateDated" 
            Text='<%# Bind("Dated") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactURIFooterTemplateDated"
            Text='<%# Bind("Dated") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="SequenceOrderId"
          SortExpression="SequenceOrderId"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewContactURIItemTemplateSequenceOrderId" 
            Text='<%# Eval("SequenceOrderId") %>'
           />
          </ItemTemplate>
<%--
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactURIEditItemTemplateSequenceOrderId" 
            Text='<%# Bind("SequenceOrderId") %>'
           />
          </EditItemTemplate>
--%>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewContactURIFooterTemplateSequenceOrderId"
            Text='<%# Bind("SequenceOrderId") %>'
           />
           <asp:Button 
            Runat="Server"           
            ID="ButtonGridViewContactURIFooterTemplateAdd"
            CommandName="ButtonGridViewContactURIFooterTemplateAdd" 
            Text="Add"
           />
          </FooterTemplate>
         </asp:TemplateField>
         
        </Columns>
        <pagersettings mode="Numeric"
         position="Bottom"           
         pagebuttoncount="10"
        />
        <pagerstyle backcolor="LightBlue"
         height="30px"
         verticalalign="Bottom"
         horizontalalign="Center"
        />
       </asp:GridView>
      </td>
     </tr>
    </tbody>    
   </table>

   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
         <asp:FormView 
          runat="server"
          id="FormViewContactURI"
          AllowPaging="true"
          DataKeyNames="sequenceOrderId"
          DataSourceID="SqlDataSourceContactURI"
          DefaultMode="Insert"
          OnItemInserted="FormView_ItemInserted"
          OnItemInserting="FormView_ItemInserting"
          Visible=false
         >
          <InsertItemTemplate>
           <table>
            <theader>
             <tr>
              <th>Internet Address</th>
              <th>Dated</th>
              <th>SequenceOrderId</th>
             </tr>
            </theader>
            <tbody>
             <tr>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewContactURIInsertItemTemplateInternetAddress" 
                Text='<%# Bind("InternetAddress") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewContactURIInsertItemTemplateDated" 
                Text='<%# Bind("Dated") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewContactURIInsertItemTemplateSequenceOrderId" 
                Text='<%# Bind("SequenceOrderId") %>'
               />
              </td>
              <td>
               <asp:Button 
                runat="server"
                id="ButtonFormViewContactURI"  
                onclick="ButtonFormViewContactURIInsert_Click"
                Text="Add"
               />
               <%--
               <asp:linkbutton 
                runat="server"
                id="LinkButtonInsert"
                text="Insert"
                commandname="Insert"
               />
               <asp:linkbutton 
                runat="server"
                id="LinkButtonCancel"
                text="Cancel"
                commandname="Cancel"
               />
               --%>
              </td>
             </tr> 
            </tbody>
           </table>       
          </InsertItemTemplate>
         </asp:FormView>
      </td>
     </tr>
    </tbody>    
   </table>

   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
       <asp:SqlDataSource
        ID="SqlDataSourceTelephone"
        Runat="server"
        ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
        DeleteCommand="DELETE Telephone WHERE sequenceOrderId = @original_sequenceOrderId"
        InsertCommand="EXEC uspTelephoneInsert @sequenceOrderId, @dated, @contactId, @telephoneNo, @telephoneLocation"
        SelectCommand="SELECT sequenceOrderId, dated, telephoneNo, telephoneLocation FROM Telephone WHERE contactId = @contactId"
        UpdateCommand="UPDATE Telephone SET dated = @dated, telephoneNo = @telephoneNo, telephoneLocation = @telephoneLocation WHERE sequenceOrderId = @original_sequenceOrderId"
       >
        <insertparameters>
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
         <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
         <asp:ControlParameter Name="contactId" ControlId="GridViewContact" PropertyName="SelectedValue" />
         <asp:parameter name="telephoneNo" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="telephoneLocation" ConvertEmptyStringToNull=true Type="string" />
        </insertparameters>
        <selectparameters>
         <asp:ControlParameter Name="contactId" ControlId="GridViewContact" PropertyName="SelectedValue" />
        </selectparameters>
       </asp:SqlDataSource>

       <asp:GridView
        id="GridViewTelephone" 
        runat="server" 
        AllowPaging=True
        AllowSorting=True 
        AutoGenerateColumns=False
        AutoGenerateDeleteButton=True
        AutoGenerateEditButton=True
        AutoGenerateSelectButton=True        
        DataKeyNames="sequenceOrderId"
        DataSourceID="SqlDataSourceTelephone"
        OnPreRender="GridView_PreRender"
        OnRowCommand="GridView_RowCommand"
        OnRowUpdated="GridView_RowUpdated"
        SelectedIndex=0        
        ShowFooter=True
       >
        <HeaderStyle
         BackColor='#CCCC99'/>

        <RowStyle
         BackColor='#eeeeee'/>
			
        <AlternatingRowStyle
         BackColor='#ffffe8'/>

        <Columns>

         <asp:TemplateField
          HeaderText="Telephone No"
          SortExpression="TelephoneNo"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewTelephoneItemTemplateTelephoneNo" 
            Text='<%# Eval("TelephoneNo") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewTelephoneEditItemTemplateTelephoneNo" 
            Text='<%# Bind("TelephoneNo") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewTelephoneFooterTemplateTelephoneNo"
            Text='<%# Bind("TelephoneNo") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Telephone Location"
          SortExpression="TelephoneLocation"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewTelephoneItemTemplateTelephoneLocation" 
            Text='<%# Eval("TelephoneLocation") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewTelephoneEditItemTemplateTelephoneLocation" 
            Text='<%# Bind("TelephoneLocation") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewTelephoneFooterTemplateTelephoneLocation"
            Text='<%# Bind("TelephoneLocation") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Dated"
          SortExpression="Dated"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewTelephoneItemTemplateDated" 
            Text='<%# Eval("Dated", "{0:d}") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewTelephoneEditItemTemplateDated" 
            Text='<%# Bind("Dated") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewTelephoneFooterTemplateDated"
            Text='<%# Bind("Dated") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="SequenceOrderId"
          SortExpression="SequenceOrderId"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewTelephoneItemTemplateSequenceOrderId" 
            Text='<%# Eval("SequenceOrderId") %>'
           />
          </ItemTemplate>
<%--
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewTelephoneEditItemTemplateSequenceOrderId" 
            Text='<%# Bind("SequenceOrderId") %>'
           />
          </EditItemTemplate>
--%>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewTelephoneFooterTemplateSequenceOrderId"
            Text='<%# Bind("SequenceOrderId") %>'
           />
           <asp:Button 
            Runat="Server"           
            ID="ButtonGridViewTelephoneFooterTemplateAdd"
            CommandName="ButtonGridViewTelephoneFooterTemplateAdd" 
            Text="Add"
           />
          </FooterTemplate>
         </asp:TemplateField>
         
        </Columns>
        <pagersettings mode="Numeric"
         position="Bottom"           
         pagebuttoncount="10"
        />
        <pagerstyle backcolor="LightBlue"
         height="30px"
         verticalalign="Bottom"
         horizontalalign="Center"
        />
       </asp:GridView>
      </td>
     </tr>
    </tbody>    
   </table>

   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
         <asp:FormView 
          runat="server"
          id="FormViewTelephone"
          AllowPaging="true"
          DataKeyNames="sequenceOrderId"
          DataSourceID="SqlDataSourceTelephone"
          DefaultMode="Insert"
          OnItemInserted="FormView_ItemInserted"
          OnItemInserting="FormView_ItemInserting"
          Visible=false
         >
          <InsertItemTemplate>
           <table>
            <theader>
             <tr>
              <th>Telephone No</th>
              <th>Telephone Location</th>              
              <th>Dated</th>
              <th>SequenceOrderId</th>
             </tr>
            </theader>
            <tbody>
             <tr>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewTelephoneInsertItemTemplateTelephoneNo" 
                Text='<%# Bind("TelephoneNo") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewTelephoneInsertItemTemplateTelephoneLocation" 
                Text='<%# Bind("TelephoneLocation") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewTelephoneInsertItemTemplateDated" 
                Text='<%# Bind("Dated") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewTelephoneInsertItemTemplateSequenceOrderId" 
                Text='<%# Bind("SequenceOrderId") %>'
               />
              </td>
              <td>
               <asp:Button 
                runat="server"
                id="ButtonFormViewTelephone"  
                onclick="ButtonFormViewTelephoneInsert_Click"
                Text="Add"
               />
               <%--
               <asp:linkbutton 
                runat="server"
                id="LinkButtonInsert"
                text="Insert"
                commandname="Insert"
               />
               <asp:linkbutton 
                runat="server"
                id="LinkButtonCancel"
                text="Cancel"
                commandname="Cancel"
               />
               --%>
              </td>
             </tr> 
            </tbody>
           </table>       
          </InsertItemTemplate>
         </asp:FormView>
      </td>
     </tr>
    </tbody>    
   </table>

   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
       <asp:SqlDataSource
        ID="SqlDataSourceStreetAddress"
        Runat="server"
        ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
        DeleteCommand="DELETE StreetAddress WHERE sequenceOrderId = @original_sequenceOrderId"
        InsertCommand="EXEC uspStreetAddressInsert @sequenceOrderId, @dated, @contactId, @addressLine1, @city, @state, @zipCode, @country"
        SelectCommand="SELECT sequenceOrderId, dated, addressLine1, city, state, zipCode, country FROM StreetAddress WHERE contactId = @contactId"
        UpdateCommand="UPDATE StreetAddress SET dated = @dated, addressLine1 = @addressLine1, city = @city, state = @state, zipCode = @zipCode, country = @country WHERE sequenceOrderId = @original_sequenceOrderId"
       >
        <insertparameters>
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
         <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
         <asp:ControlParameter Name="contactId" ControlId="GridViewContact" PropertyName="SelectedValue" />
         <asp:parameter name="addressLine1" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="city" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="state" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="zipCode" ConvertEmptyStringToNull=true Type="string" />
         <asp:parameter name="country" ConvertEmptyStringToNull=true Type="string" />
        </insertparameters>
        <selectparameters>
         <asp:ControlParameter Name="contactId" ControlId="GridViewContact" PropertyName="SelectedValue" />
        </selectparameters>
       </asp:SqlDataSource>

       <asp:GridView
        id="GridViewStreetAddress" 
        runat="server" 
        AllowPaging=True
        AllowSorting=True 
        AutoGenerateColumns=False
        AutoGenerateDeleteButton=True
        AutoGenerateEditButton=True
        AutoGenerateSelectButton=True        
        DataKeyNames="sequenceOrderId"
        DataSourceID="SqlDataSourceStreetAddress"
        OnPreRender="GridView_PreRender"
        OnRowCommand="GridView_RowCommand"
        OnRowUpdated="GridView_RowUpdated"
        SelectedIndex=0        
        ShowFooter=True
       >
        <HeaderStyle
         BackColor='#CCCC99'/>

        <RowStyle
         BackColor='#eeeeee'/>
			
        <AlternatingRowStyle
         BackColor='#ffffe8'/>

        <Columns>

         <asp:TemplateField
          HeaderText="Address Line 1"
          SortExpression="AddressLine1"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewStreetAddressItemTemplateAddressLine1" 
            Text='<%# Eval("AddressLine1") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressEditItemTemplateAddressLine1" 
            Text='<%# Bind("AddressLine1") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressFooterTemplateAddressLine1"
            Text='<%# Bind("AddressLine1") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="City"
          SortExpression="City"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewStreetAddressItemTemplateCity" 
            Text='<%# Eval("City") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressEditItemTemplateCity" 
            Text='<%# Bind("City") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressFooterTemplateCity"
            Text='<%# Bind("City") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="State"
          SortExpression="State"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewStreetAddressItemTemplateState" 
            Text='<%# Eval("State") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressEditItemTemplateState" 
            Text='<%# Bind("State") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressFooterTemplateState"
            Text='<%# Bind("State") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Zip Code"
          SortExpression="ZipCode"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewStreetAddressItemTemplateZipCode" 
            Text='<%# Eval("ZipCode") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressEditItemTemplateZipCode" 
            Text='<%# Bind("ZipCode") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressFooterTemplateZipCode"
            Text='<%# Bind("ZipCode") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Country"
          SortExpression="Country"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewStreetAddressItemTemplateCountry" 
            Text='<%# Eval("Country") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressEditItemTemplateCountry" 
            Text='<%# Bind("Country") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressFooterTemplateCountry"
            Text='<%# Bind("Country") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>
               
         <asp:TemplateField
          HeaderText="Dated"
          SortExpression="Dated"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewStreetAddressItemTemplateDated" 
            Text='<%# Eval("Dated", "{0:d}") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressEditItemTemplateDated" 
            Text='<%# Bind("Dated") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressFooterTemplateDated"
            Text='<%# Bind("Dated") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="SequenceOrderId"
          SortExpression="SequenceOrderId"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewStreetAddressItemTemplateSequenceOrderId" 
            Text='<%# Eval("SequenceOrderId") %>'
           />
          </ItemTemplate>
<%--
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressEditItemTemplateSequenceOrderId" 
            Text='<%# Bind("SequenceOrderId") %>'
           />
          </EditItemTemplate>
--%>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewStreetAddressFooterTemplateSequenceOrderId"
            Text='<%# Bind("SequenceOrderId") %>'
           />
           <asp:Button 
            Runat="Server"           
            ID="ButtonGridViewStreetAddressFooterTemplateAdd"
            CommandName="ButtonGridViewStreetAddressFooterTemplateAdd" 
            Text="Add"
           />
          </FooterTemplate>
         </asp:TemplateField>
         
        </Columns>
        <pagersettings mode="Numeric"
         position="Bottom"           
         pagebuttoncount="10"
        />
        <pagerstyle backcolor="LightBlue"
         height="30px"
         verticalalign="Bottom"
         horizontalalign="Center"
        />
       </asp:GridView>
      </td>
     </tr>
    </tbody>    
   </table>

   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
         <asp:FormView 
          runat="server"
          id="FormViewStreetAddress"
          AllowPaging="true"
          DataKeyNames="sequenceOrderId"
          DataSourceID="SqlDataSourceStreetAddress"
          DefaultMode="Insert"
          OnItemInserted="FormView_ItemInserted"
          OnItemInserting="FormView_ItemInserting"
          Visible=false
         >
          <InsertItemTemplate>
           <table>
            <theader>
             <tr>
              <th>Address Line 1</th>
              <th>City</th>
              <th>State</th>
              <th>Zip Code</th>
              <th>Country</th>
              <th>Dated</th>
              <th>SequenceOrderId</th>
             </tr>
            </theader>
            <tbody>
             <tr>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewStreetAddressInsertItemTemplateAddressLine1" 
                Text='<%# Bind("AddressLine1") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewStreetAddressInsertItemTemplateCity" 
                Text='<%# Bind("City") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewStreetAddressInsertItemTemplateState" 
                Text='<%# Bind("State") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewStreetAddressInsertItemTemplateZipCode" 
                Text='<%# Bind("ZipCode") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewStreetAddressInsertItemTemplateCountry" 
                Text='<%# Bind("Country") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewStreetAddressInsertItemTemplateDated" 
                Text='<%# Bind("Dated") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewStreetAddressInsertItemTemplateSequenceOrderId" 
                Text='<%# Bind("SequenceOrderId") %>'
               />
              </td>
              <td>
               <asp:Button 
                runat="server"
                id="ButtonFormViewStreetAddress"  
                onclick="ButtonFormViewStreetAddressInsert_Click"
                Text="Add"
               />
               <%--
               <asp:linkbutton 
                runat="server"
                id="LinkButtonInsert"
                text="Insert"
                commandname="Insert"
               />
               <asp:linkbutton 
                runat="server"
                id="LinkButtonCancel"
                text="Cancel"
                commandname="Cancel"
               />
               --%>
              </td>
             </tr> 
            </tbody>
           </table>       
          </InsertItemTemplate>
         </asp:FormView>
      </td>
     </tr>
    </tbody>    
   </table>

   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
       <asp:SqlDataSource
        ID="SqlDataSourceCaseBasedReasoning"
        Runat="server"
        ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
        DeleteCommand="DELETE CaseBasedReasoning WHERE sequenceOrderId = @original_sequenceOrderId"
        InsertCommand="EXEC uspCaseBasedReasoningInsert @sequenceOrderId, @dated, @contactId, @commentary"
        SelectCommand="SELECT sequenceOrderId, dated, commentary FROM CaseBasedReasoning WHERE contactId = @contactId"
        UpdateCommand="UPDATE CaseBasedReasoning SET dated = @dated, commentary = @commentary WHERE sequenceOrderId = @original_sequenceOrderId"
       >
        <insertparameters>
         <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
         <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
         <asp:ControlParameter Name="contactId" ControlId="GridViewContact" PropertyName="SelectedValue" />
         <asp:parameter name="commentary" ConvertEmptyStringToNull=true Type="string" />
        </insertparameters>
        <selectparameters>
         <asp:ControlParameter Name="contactId" ControlId="GridViewContact" PropertyName="SelectedValue" />
        </selectparameters>
       </asp:SqlDataSource>

       <asp:GridView
        id="GridViewCaseBasedReasoning" 
        runat="server" 
        AllowPaging=True
        AllowSorting=True 
        AutoGenerateColumns=False
        AutoGenerateDeleteButton=True
        AutoGenerateEditButton=True
        AutoGenerateSelectButton=True        
        DataKeyNames="sequenceOrderId"
        DataSourceID="SqlDataSourceCaseBasedReasoning"
        OnPreRender="GridView_PreRender"
        OnRowCommand="GridView_RowCommand"
        OnRowUpdated="GridView_RowUpdated"
        SelectedIndex=0        
        ShowFooter=True
       >
        <HeaderStyle
         BackColor='#CCCC99'/>

        <RowStyle
         BackColor='#eeeeee'/>
			
        <AlternatingRowStyle
         BackColor='#ffffe8'/>

        <Columns>

         <asp:TemplateField
          HeaderText="Commentary"
          SortExpression="Commentary"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewCaseBasedReasoningItemTemplateCommentary" 
            Text='<%# Eval("Commentary") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewCaseBasedReasoningEditItemTemplateCommentary" 
            Text='<%# Bind("Commentary") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewCaseBasedReasoningFooterTemplateCommentary"
            Text='<%# Bind("Commentary") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="Dated"
          SortExpression="Dated"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewCaseBasedReasoningItemTemplateDated" 
            Text='<%# Eval("Dated", "{0:d}") %>'
           />
          </ItemTemplate>
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewCaseBasedReasoningEditItemTemplateDated" 
            Text='<%# Bind("Dated") %>'
           />
          </EditItemTemplate>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewCaseBasedReasoningFooterTemplateDated"
            Text='<%# Bind("Dated") %>'
           />
          </FooterTemplate>
         </asp:TemplateField>

         <asp:TemplateField
          HeaderText="SequenceOrderId"
          SortExpression="SequenceOrderId"
         >
          <ItemTemplate>
           <asp:Label
            Runat="Server"
            id="LabelGridViewCaseBasedReasoningItemTemplateSequenceOrderId" 
            Text='<%# Eval("SequenceOrderId") %>'
           />
          </ItemTemplate>
<%--
          <EditItemTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewCaseBasedReasoningEditItemTemplateSequenceOrderId" 
            Text='<%# Bind("SequenceOrderId") %>'
           />
          </EditItemTemplate>
--%>
          <FooterTemplate>
           <asp:TextBox 
            Runat="Server"
            id="TextBoxGridViewCaseBasedReasoningFooterTemplateSequenceOrderId"
            Text='<%# Bind("SequenceOrderId") %>'
           />
           <asp:Button 
            Runat="Server"           
            ID="ButtonGridViewCaseBasedReasoningFooterTemplateAdd"
            CommandName="ButtonGridViewCaseBasedReasoningFooterTemplateAdd" 
            Text="Add"
           />
          </FooterTemplate>
         </asp:TemplateField>
         
        </Columns>
        <pagersettings mode="Numeric"
         position="Bottom"           
         pagebuttoncount="10"
        />
        <pagerstyle backcolor="LightBlue"
         height="30px"
         verticalalign="Bottom"
         horizontalalign="Center"
        />
       </asp:GridView>
      </td>
     </tr>
    </tbody>    
   </table>

   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
         <asp:FormView 
          runat="server"
          id="FormViewCaseBasedReasoning"
          AllowPaging="true"
          DataKeyNames="sequenceOrderId"
          DataSourceID="SqlDataSourceCaseBasedReasoning"
          DefaultMode="Insert"
          OnItemInserted="FormView_ItemInserted"
          OnItemInserting="FormView_ItemInserting"
          Visible=false
         >
          <InsertItemTemplate>
           <table>
            <theader>
             <tr>
              <th>Commentary</th>
              <th>Dated</th>
              <th>SequenceOrderId</th>
             </tr>
            </theader>
            <tbody>
             <tr>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewCaseBasedReasoningInsertItemTemplateCommentary" 
                Text='<%# Bind("Commentary") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewCaseBasedReasoningInsertItemTemplateDated" 
                Text='<%# Bind("Dated") %>'
               />
              </td>
              <td>
               <asp:textbox 
                runat="server"
                id="TextBoxFormViewCaseBasedReasoningInsertItemTemplateSequenceOrderId" 
                Text='<%# Bind("SequenceOrderId") %>'
               />
              </td>
              <td>
               <asp:Button 
                runat="server"
                id="ButtonFormViewCaseBasedReasoning"  
                onclick="ButtonFormViewCaseBasedReasoningInsert_Click"
                Text="Add"
               />
               <%--
               <asp:linkbutton 
                runat="server"
                id="LinkButtonInsert"
                text="Insert"
                commandname="Insert"
               />
               <asp:linkbutton 
                runat="server"
                id="LinkButtonCancel"
                text="Cancel"
                commandname="Cancel"
               />
               --%>
              </td>
             </tr> 
            </tbody>
           </table>       
          </InsertItemTemplate>
         </asp:FormView>
      </td>
     </tr>
    </tbody>    
   </table>
   
   <table align="center" border="0">
    <tbody> 
     <tr align="center">
      <td align="center">
       <asp:Literal 
        id="LiteralFeedback" 
        runat="server" 
        EnableViewState=False
       />
      </td>
     </tr>    
    </tbody>    
   </table>
   
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxFirstName.focus();
</script>