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
         AssociatedControlId="queryCommentary"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="queryCommentary"
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
         AssociatedControlId="queryURI"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="queryURI"
         TabIndex="2"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="left">
        <asp:Label
         runat="server"       
         id="LabelKeyword"
         Text="Keyword:"
         AccessKey="K"
         AssociatedControlId="queryKeyword"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="queryKeyword"
         TabIndex="3"
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
         AssociatedControlId="queryDatedFrom"
        />
       </td>
       <td align="left">       
        <asp:TextBox
         runat="Server"
         ID="queryDatedFrom"
         TabIndex="4"
        />
        -
        <asp:TextBox
         runat="Server"
         ID="queryDatedTo"
         TabIndex="5"
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
         AssociatedControlId="querySource"
        />
       </td>
       <td align="left">
        <asp:FileUpload 
         Runat="server"
         ID="querySource"
         TabIndex="6"
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
         AssociatedControlId="queryContactId"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="queryContactId"
         TabIndex="7"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="center" colspan="4">
        <asp:Button runat="server" id="ButtonSubmit" onclick="ButtonSubmit_Click"  Text="Submit" TabIndex="8" />
        <asp:Button runat="server" id="ButtonReset"  onclick="ButtonReset_Click"   Text="Reset"  TabIndex="9" />
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
         InsertCommand="uspKnowledgeBaseInsert"
         InsertCommandType="StoredProcedure"
         SelectCommand="uspKnowledgeBaseSelect"
         SelectCommandType="StoredProcedure"
         UpdateCommand="UPDATE KnowledgeBase SET commentary = @commentary, contactId = @contactId, dated = @dated, keyword = @keyword, source = @source, uri = @uri WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="commentary" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="contactId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="keyword" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="source" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="URI" ConvertEmptyStringToNull=true Type="string" />
         </insertparameters>
         <selectparameters>
          <asp:controlparameter name="commentary" controlid="queryCommentary" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="Input" Defaultvalue="|" />
          <asp:controlparameter name="contactId" controlid="queryContactId" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="Input" Defaultvalue="-1" />
          <asp:controlparameter name="datedFrom" controlid="queryDatedFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="Input" DefaultValue = "1/1/1753" />
          <asp:controlparameter name="datedTo" controlid="queryDatedTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="Input" DefaultValue = "12/31/9999" />
          <asp:controlparameter name="keyword" controlid="queryKeyword" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="Input" Defaultvalue="|" />
          <asp:controlparameter name="uri" controlid="queryURI" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="Input" Defaultvalue="|" />
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
             Columns="50"
             id="TextBoxGridViewKnowledgeBaseEditItemTemplateCommentary" 
             Runat="Server"
             Text='<%# Bind("Commentary") %>'
             TextMode="multiline"
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox
             Columns="50"
             id="TextBoxGridViewKnowledgeBaseFooterTemplateCommentary"
             Runat="Server"
             Text='<%# Bind("Commentary") %>'
             TextMode="multiline"
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
           HeaderText="Keyword"
           SortExpression="Keyword"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewKnowledgeBaseItemTemplateKeyword" 
             Text='<%# Eval("Keyword") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Columns="50"
             id="TextBoxGridViewKnowledgeBaseEditItemTemplateKeyword" 
             Runat="Server"
             Text='<%# Bind("Keyword") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox
             Columns="50"
             id="TextBoxGridViewKnowledgeBaseFooterTemplateKeyword"
             Runat="Server"
             Text='<%# Bind("Keyword") %>'
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
  
     <script>
		//2015-02-19 http://stackoverflow.com/questions/4793955/how-to-add-a-confirm-delete-option-in-asp-net-gridview
		function confirmDelete()
		{
			var anchors=document.getElementsByTagName("a");
			for (var index = 0, count = anchors.length; index < count; ++index)
			{
				var currentElement = anchors[index];
				var elementName = currentElement.innerHTML;
				if (elementName === "Delete")
				{
					anchors[index].addEventListener
					(
						"click",
						function (event) 
						{ 
							if (!confirm("Are you sure you want to delete this record?"))
							{ 
								event.preventDefault(); 
							} 
						},
						false
					);					
				}	
			}	
		}
		
		window.addEventListener("load", confirmDelete, false);
	</script>
  
 </body>
</html>
