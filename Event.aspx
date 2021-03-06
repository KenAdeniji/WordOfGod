<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.EventPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadEvent">
  <title runat="Server" id="TitleEvent">Event</title>
 </head>
 <body runat="server" id="BodyEvent">
  <asp:Panel
   runat="server"
   id="PanelEvent"
  >
   <form 
    ID="FormEvent" 
    runat="server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultbutton="ButtonSubmit"
    defaultfocus="TextBoxCommentary"
   >
    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td align="center" colspan=4>
        Search Query
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
         runat="Server"
         ID="TextBoxCommentary"
         TabIndex="1"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelContactId"
         Text="Contact Id:"
         AccessKey="I"
         AssociatedControlId="TextBoxContactId"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxContactId"
         TabIndex="2"
        />        
       </td>
      </tr>

      <tr align="center">       
       <td align="left">
        <asp:Label
         runat="server"
         id="LabelDated"
         Text="Dated:"
         AccessKey="D"
         AssociatedControlId="TextBoxDatedFrom"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="TextBoxDatedFrom"
         TabIndex="3"
        />
        -
        <asp:TextBox
         runat="Server"
         ID="TextBoxDatedTo"
         TabIndex="4"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="center" colspan="4">
        <asp:Button runat="server" id="ButtonSubmit"  onclick="ButtonSubmit_Click"  Text="Submit" TabIndex="5" />
        <asp:Button runat="server" id="ButtonReset"   onclick="ButtonReset_Click"   Text="Reset"  TabIndex="6" />
       </td>      
       </tr>
     </tbody>
    </table>

    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td>
        <asp:SqlDataSource
         ID="SqlDataSourceEvent"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE Event WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspEventInsert @sequenceOrderId, @dated, @commentary, @contactId"
         SelectCommand="EXEC uspEventSelect"
         UpdateCommand="UPDATE Event SET dated = @dated, commentary = @commentary, contactId = @contactId WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="Commentary" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="contactId" ConvertEmptyStringToNull=true Type="Int32" />
         </insertparameters>
         <selectparameters>
<%--
          <asp:controlparameter name="Commentary" controlid="TextBoxCommentary" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" />
          <asp:controlparameter name="DatedFrom" controlid="TextBoxDatedFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" />
          <asp:controlparameter name="DatedTo" controlid="TextBoxDatedTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" />
--%>          
         </selectparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewEvent" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         AutoGenerateDeleteButton=True
         AutoGenerateEditButton=True
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceEvent"
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
             id="LabelGridViewEventItemTemplateCommentary" 
             Text='<%# Eval("Commentary") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewEventEditItemTemplateCommentary" 
             Text='<%# Bind("Commentary") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewEventFooterTemplateCommentary"
             Text='<%# Bind("Commentary") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="ContactId"
           SortExpression="ContactId"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewEventItemTemplateContactId" 
             Text='<%# Eval("ContactId") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewEventEditItemTemplateContactId" 
             Text='<%# Bind("ContactId") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewEventFooterTemplateContactId"
             Text='<%# Bind("ContactId") %>'
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
             id="LabelGridViewEventItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewEventEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewEventFooterTemplateSequenceOrderId"
             Text='<%# Bind("SequenceOrderId") %>'
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
             id="LabelGridViewEventItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewEventEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewEventFooterTemplateDated"
             Text='<%# Bind("Dated") %>'
            />
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewEventFooterTemplateAdd"
             OnClick="GridViewEventInsert"
             Text="Add"
            />
           </FooterTemplate>

          </asp:TemplateField>
       
         </Columns>
         <pagersettings 
          mode="Numeric"
          position="Bottom"           
          pagebuttoncount="10"
         />
         <pagerstyle 
          backcolor="LightBlue"
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
  </asp:Panel>
 </body>
</html>