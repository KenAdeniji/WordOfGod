<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.SacredTextGridViewPage"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadSacredText">
  <title runat="Server" id="TitleSacredText">Sacred Text</title>
 </head>
 <body runat="server" id="BodySacredText">
  <form 
   ID="FormSacredText" 
   runat="server"
   enctype="multipart/form-data"    
   autocomplete="on"
  >
   <asp:SqlDataSource
    ID="SqlDataSourceSacredText"
    Runat="server"
    ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
    DeleteCommand="DELETE SacredText WHERE sequenceOrderId = @sequenceOrderId"
    InsertCommand="EXEC uspSacredTextInsert @sequenceOrderId, @dated, @title, @scriptureReference, @commentary"
    SelectCommand="SELECT sequenceOrderId, dated, title, scriptureReference, commentary FROM SacredText ORDER BY title, scriptureReference"
    UpdateCommand="UPDATE SacredText SET dated = @dated, title = @title, scriptureReference = @scriptureReference, commentary = @commentary WHERE sequenceOrderId = @sequenceOrderId"
   >
    <insertparameters>
     <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull="true" Type="Int32" />
     <asp:parameter name="dated" ConvertEmptyStringToNull="true" Type="DateTime" />
     <asp:parameter name="title" ConvertEmptyStringToNull="true" Type="string" />
     <asp:parameter name="scriptureReference" ConvertEmptyStringToNull="true" Type="string" />
     <asp:parameter name="commentary" ConvertEmptyStringToNull="true" Type="string" />
    </insertparameters>

   </asp:SqlDataSource>

   <table>
    <tbody>
     <tr>
      <td>
    <asp:GridView
     id="GridViewSacredText" 
     runat="server" 
     AllowPaging=True
     AllowSorting=True 
     AutoGenerateColumns=False
     AutoGenerateDeleteButton=True
     AutoGenerateEditButton=True
     AutoGenerateSelectButton=True        
     DataKeyNames="sequenceOrderId"
     DataSourceID="SqlDataSourceSacredText"
     SelectedIndex=0
     ShowFooter=True
    >
     <HeaderStyle BackColor='#CCCC99'/>
     <RowStyle BackColor='#eeeeee'/>
     <AlternatingRowStyle BackColor='#ffffe8'/>

     <Columns>
               
      <asp:TemplateField
       HeaderText="Title"
       SortExpression="Title"
      >
       <ItemTemplate>
        <asp:Label
         Runat="Server"
         id="LabelGridViewSacredTextItemTemplateTitle" 
         Text='<%# Eval("Title") %>'
        />
        </ItemTemplate>
        <EditItemTemplate>
         <asp:TextBox 
          Runat="Server"
          id="TextBoxGridViewSacredTextEditItemTemplateTitle" 
          Text='<%# Bind("Title") %>'
        />
        </EditItemTemplate>
         <FooterTemplate>
          <asp:TextBox 
           Runat="Server"
           id="TextBoxGridViewSacredTextFooterTemplateTitle"
           Text='<%# Bind("Title") %>'
          />
         </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField
         HeaderText="ScriptureReference"
         SortExpression="ScriptureReference"
        >
         <ItemTemplate>
          <asp:Label
           Runat="Server"
           id="LabelGridViewSacredTextItemTemplateScriptureReference" 
           Text='<%# Eval("ScriptureReference") %>'
           />
          </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewSacredTextEditItemTemplateScriptureReference" 
             Text='<%# Bind("ScriptureReference") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewSacredTextFooterTemplateScriptureReference"
             Text='<%# Bind("ScriptureReference") %>'
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
             id="LabelGridViewSacredTextItemTemplateCommentary" 
             Text='<%# Eval("Commentary") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewSacredTextEditItemTemplateCommentary" 
             Text='<%# Bind("Commentary") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewSacredTextFooterTemplateCommentary"
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
             id="LabelGridViewSacredTextItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewSacredTextEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewSacredTextFooterTemplateDated"
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
             id="LabelGridViewSacredTextItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewSacredTextEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewSacredTextFooterTemplateSequenceOrderId"
             Text='<%# Bind("SequenceOrderId") %>'
            />
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewSacredTextFooterTemplateAdd"
             OnClick="GridViewSacredTextInsert"
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

   <table>
    <tbody>
     <tr>
      <td>
       <asp:Literal runat="server" ID="LiteralFeedback" />
      </td>
     </tr>
    </tbody>
   </table>

      		
  </form>
 </body>
</html>
