<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.KnowledgeBasePage"
 validateRequest=false
%>

<%@ Register Assembly="UtilityProtocol" Namespace="WordEngineering" TagPrefix="UtilityProtocol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadKnowledgeBase">
  <title runat="Server" id="TitleKnowledgeBase">Knowledge Base</title>
 </head>
 <body runat="server" id="BodyKnowledgeBase">
  <asp:Panel
   runat="server"
   id="PanelKnowledgeBase"
  >
   <form 
    ID="FormKnowledgeBase" 
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
         id="LabelURI"
         Text="URI:"
         AccessKey="U"
         AssociatedControlId="TextBoxURI"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxURI"
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
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelSource"
         Text="Source:"
         AccessKey="S"
         AssociatedControlId="FileUploadSource"
        />
       </td>
       <td align="left">
        <asp:FileUpload 
         Runat="server"
         ID="FileUploadSource"
         TabIndex="5"
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
         TabIndex="6"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="center" colspan="4">
        <asp:Button runat="server" id="ButtonSubmit" onclick="ButtonSubmit_Click"  Text="Submit" TabIndex="6" />
        <asp:Button runat="server" id="ButtonReset"  onclick="ButtonReset_Click"   Text="Reset"  TabIndex="7" />
       </td>      
       </tr>
     </tbody>
    </table>

    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td>
        <asp:SqlDataSource
         ID="SqlDataSourceKnowledgeBase"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE KnowledgeBase WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspKnowledgeBaseInsert @sequenceOrderId, @dated, @commentary, @uri, @Source, @contactId"
         SelectCommand="EXEC uspKnowledgeBaseSelect @commentary, @uri, @datedFrom, @datedTo, @contactId"
         UpdateCommand="UPDATE KnowledgeBase SET dated = @dated, commentary = @commentary, uri = @uri, source = @source, contactId = @contactId WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="commentary" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="URI" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="Source" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="contactId" ConvertEmptyStringToNull=true Type="Int32" />
         </insertparameters>
         <selectparameters>
          <asp:controlparameter name="commentary" controlid="TextBoxCommentary" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" Defaultvalue="|" />
          <asp:controlparameter name="uri" controlid="TextBoxURI" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" Defaultvalue="|" />
          <asp:controlparameter name="datedFrom" controlid="TextBoxDatedFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "1/1/1753" />
          <asp:controlparameter name="datedTo" controlid="TextBoxDatedTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" DefaultValue = "12/31/9999" />
          <asp:controlparameter name="contactId" controlid="TextBoxContactId" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" Defaultvalue="-1" />
         </selectparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewKnowledgeBase" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         AutoGenerateDeleteButton=True
         AutoGenerateEditButton=True
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceKnowledgeBase"
         OnRowDataBound="GridView_RowDataBound"
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
             id="LabelGridViewKnowledgeBaseItemTemplateCommentary" 
             Text='<%# Eval("Commentary") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKnowledgeBaseEditItemTemplateCommentary" 
             Text='<%# Bind("Commentary") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKnowledgeBaseFooterTemplateCommentary"
             Text='<%# Bind("Commentary") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="URI"
           SortExpression="URI"
          >
           <ItemTemplate>
            <asp:HyperLink  
             Runat="Server"
             id="HyperLinkKnowledgeBaseItemTemplateURI" 
             NavigateUrl='<%# UtilityProtocol.PrefixProtocol( Eval("URI").ToString() ) %>'
             Text='<%# Eval("URI") %>'
             Target="_blank"
            />  
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKnowledgeBaseEditItemTemplateURI" 
             Text='<%# Bind("URI") %>'
            />
           </EditItemTemplate>          
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKnowledgeBaseFooterTemplateURI"
             Text='<%# Bind("URI") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Source"
           SortExpression="Source"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewKnowledgeBaseItemTemplateSource" 
             Text='<%# Eval("Source") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:FileUpload 
             Runat="server"
             ID="FileUploadGridViewKnowledgeBaseEditItemTemplateSource"
             FileName="<%# Bind('Source') %>"
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:FileUpload 
             Runat="server"
             ID="FileUploadGridViewKnowledgeBaseFooterTemplateSource"
             FileName="<%# Bind('Source') %>"
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
             id="LabelGridViewKnowledgeBaseItemTemplateContactId" 
             Text='<%# Eval("ContactId") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKnowledgeBaseEditItemTemplateContactId" 
             Text='<%# Bind("ContactId") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKnowledgeBaseFooterTemplateContactId"
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
             id="LabelGridViewKnowledgeBaseItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKnowledgeBaseEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKnowledgeBaseFooterTemplateSequenceOrderId"
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
             id="LabelGridViewKnowledgeBaseItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKnowledgeBaseEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKnowledgeBaseFooterTemplateDated"
             Text='<%# Bind("Dated") %>'
            />
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewKnowledgeBaseFooterTemplateAdd"
             OnClick="GridViewKnowledgeBaseInsert"
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
