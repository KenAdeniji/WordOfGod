<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.TheWordAlphabetSequencePage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadTheWord">
  <title runat="Server" id="TitleTheWord">The Word</title>
 </head>
 <body runat="server" id="BodyTheWord">
  <asp:Panel
   runat="server"
   id="PanelTheWord"
  >
   <form 
    ID="FormTheWord" 
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
         id="LabelFilename"
         Text="Filename:"
         AccessKey="F"
         AssociatedControlId="TextBoxFilename"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxFilename"
         TabIndex="1"
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
         TabIndex="2"
        />
        -
        <asp:TextBox
         runat="Server"
         ID="TextBoxDatedTo"
         TabIndex="3"
        />        
       </td>
      </tr>

      <tr align="center">
       <td align="center" colspan="4">
        <asp:Button runat="server" id="ButtonSubmit"  onclick="ButtonSubmit_Click"  Text="Submit" TabIndex="10" />
        <asp:Button runat="server" id="ButtonReset"   onclick="ButtonReset_Click"   Text="Reset"  TabIndex="11" />
       </td>      
       </tr>
     </tbody>
    </table>

    <table align="center" border="0">
     <tbody>
      <tr align="center">
       <td>
        <asp:SqlDataSource
         ID="SqlDataSourceTheWord"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE TheWord WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspTheWordInsert @sequenceOrderId, @dated, @filename, @contactId, @title, @commentary, @keyword, @scriptureReference"
         SelectCommand="EXEC uspTheWordSelect"
         UpdateCommand="UPDATE TheWord SET Dated = @dated, filename = @filename, contactId = @contactId, commentary = @commentary, keyword = @keyword, title = @title, scriptureReference = @scriptureReference WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="filename" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="contactId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="commentary" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="keyword" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="title" ConvertEmptyStringToNull=true Type="string" />
          <asp:parameter name="scriptureReference" ConvertEmptyStringToNull=true Type="string" />
         </insertparameters>
         <selectparameters>
<%--
          <asp:controlparameter name="Filename" controlid="TextBoxFilename" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" />
          <asp:controlparameter name="DatedFrom" controlid="TextBoxDatedFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" />
          <asp:controlparameter name="DatedTo" controlid="TextBoxDatedTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" />
--%>          
         </selectparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewTheWord" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         AutoGenerateDeleteButton=True
         AutoGenerateEditButton=True
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceTheWord"
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
           HeaderText="Filename"
           SortExpression="Filename"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewTheWordItemTemplateFilename" 
             Text='<%# Eval("Filename") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordEditItemTemplateFilename" 
             Text='<%# Bind("Filename") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewTheWordFooterTemplateAdd"
             OnClick="GridViewTheWordInsert"
             Text="Add"
            />
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordFooterTemplateFilename"
             Text='<%# Bind("Filename") %>'
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
             id="LabelGridViewTheWordItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordFooterTemplateSequenceOrderId"
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
             id="LabelGridViewTheWordItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordFooterTemplateDated"
             Text='<%# Bind("Dated") %>'
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
             id="LabelGridViewTheWordItemTemplateContactId" 
             Text='<%# Eval("ContactId") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordEditItemTemplateContactId" 
             Text='<%# Bind("ContactId") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordFooterTemplateContactId"
             Text='<%# Bind("ContactId") %>'
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
             id="LabelGridViewTheWordItemTemplateKeyword" 
             Text='<%# Eval("Keyword") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordEditItemTemplateKeyword" 
             Text='<%# Bind("Keyword") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordFooterTemplateKeyword"
             Text='<%# Bind("Keyword") %>'
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
             id="LabelGridViewTheWordItemTemplateCommentary" 
             Text='<%# Eval("Commentary") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordEditItemTemplateCommentary" 
             Text='<%# Bind("Commentary") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordFooterTemplateCommentary"
             Text='<%# Bind("Commentary") %>'
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
             id="LabelGridViewTheWordItemTemplateTitle" 
             Text='<%# Eval("Title") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordEditItemTemplateTitle" 
             Text='<%# Bind("Title") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordFooterTemplateTitle"
             Text='<%# Bind("Title") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Scripture Reference"
           SortExpression="ScriptureReference"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewTheWordItemTemplateScriptureReference" 
             Text='<%# Eval("ScriptureReference") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordEditItemTemplateScriptureReference" 
             Text='<%# Bind("ScriptureReference") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewTheWordFooterTemplateScriptureReference"
             Text='<%# Bind("ScriptureReference") %>'
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