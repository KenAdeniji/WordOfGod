<%@ Page 
 Language="C#" 
 debug=true
 Inherits="WordEngineering.KarlSeguinPage"
%>

<%@ Register Assembly="DarkBrownCarpet" Namespace="WordEngineering" TagPrefix="DarkBrownCarpet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="Server" id="HeadKarlSeguin">
  <title runat="Server" id="TitleKarlSeguin">Karl Seguin</title>
 </head>
 <body runat="server" id="BodyKarlSeguin">
  <asp:Panel
   runat="server"
   id="PanelKarlSeguin"
  >
   <form 
    ID="FormKarlSeguin" 
    runat="server"
    enctype="multipart/form-data"    
    autocomplete="on"
    defaultbutton="ButtonSubmit"
    defaultfocus="TextBoxEastBorderZeroDatabaseImplementationStephenKeshi"
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
         id="LabelEastBorderZeroDatabaseImplementationStephenKeshi"
         Text="East Border Zero Database Implementation Stephen Keshi:"
         AccessKey="H"
         AssociatedControlId="TextBoxEastBorderZeroDatabaseImplementationStephenKeshi"
        />
       </td>
       <td align="left">
        <asp:TextBox
         runat="Server"
         ID="TextBoxEastBorderZeroDatabaseImplementationStephenKeshi"
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
         AccessKey="R"
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
         ID="SqlDataSourceKarlSeguin"
         Runat="server"
         ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
         DeleteCommand="DELETE KarlSeguin WHERE sequenceOrderId = @sequenceOrderId"
         InsertCommand="EXEC uspKarlSeguinInsert @sequenceOrderId, @dated, @EastBorderZeroDatabaseImplementationStephenKeshi"
         SelectCommand="EXEC uspKarlSeguinSelect"
         UpdateCommand="UPDATE KarlSeguin SET Dated = @dated, EastBorderZeroDatabaseImplementationStephenKeshi = @EastBorderZeroDatabaseImplementationStephenKeshi WHERE sequenceOrderId = @sequenceOrderId"
        >
         <insertparameters>
          <asp:parameter name="sequenceOrderId" ConvertEmptyStringToNull=true Type="Int32" />
          <asp:parameter name="dated" ConvertEmptyStringToNull=true Type="DateTime" />
          <asp:parameter name="EastBorderZeroDatabaseImplementationStephenKeshi" ConvertEmptyStringToNull=true Type="string" />
         </insertparameters>
         <selectparameters>
<%--
          <asp:controlparameter name="EastBorderZeroDatabaseImplementationStephenKeshi" controlid="TextBoxEastBorderZeroDatabaseImplementationStephenKeshi" PropertyName="Text" ConvertEmptyStringToNull=true Type="String" Direction="InputOutput" />
          <asp:controlparameter name="DatedFrom" controlid="TextBoxDatedFrom" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" />
          <asp:controlparameter name="DatedTo" controlid="TextBoxDatedTo" PropertyName="Text" ConvertEmptyStringToNull=true Type="DateTime" Direction="InputOutput" />
--%>          
         </selectparameters>
        </asp:SqlDataSource>

        <asp:GridView
         id="GridViewKarlSeguin" 
         runat="server" 
         AllowPaging=True
         AllowSorting=True 
         AutoGenerateColumns=False
         AutoGenerateDeleteButton=True
         AutoGenerateEditButton=True
         DataKeyNames="sequenceOrderId"
         DataSourceID="SqlDataSourceKarlSeguin"
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
           HeaderText="East Border Zero Database Implementation Stephen Keshi"
           SortExpression="EastBorderZeroDatabaseImplementationStephenKeshi"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewKarlSeguinItemTemplateEastBorderZeroDatabaseImplementationStephenKeshi" 
             Text='<%# Eval("EastBorderZeroDatabaseImplementationStephenKeshi") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKarlSeguinEditItemTemplateEastBorderZeroDatabaseImplementationStephenKeshi" 
             Text='<%# Bind("EastBorderZeroDatabaseImplementationStephenKeshi") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKarlSeguinFooterTemplateEastBorderZeroDatabaseImplementationStephenKeshi"
             Text='<%# Bind("EastBorderZeroDatabaseImplementationStephenKeshi") %>'
            />
           </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField 
           HeaderText="Dark Brown Carpet"
           SortExpression="DarkBrownCarpet"
          >
           <itemtemplate>
            <asp:Label id="LabelGridViewKarlSeguinItemTemplateDarkBrownCarpet"
             runat="server"
             text= '<%# DarkBrownCarpet.RollNorthEast( Eval("EastBorderZeroDatabaseImplementationStephenKeshi").ToString() ) %>'
             runat="server"
            />
           </itemtemplate>
          </asp:TemplateField>

          <asp:TemplateField
           HeaderText="Dated"
           SortExpression="Dated"
          >
           <ItemTemplate>
            <asp:Label
             Runat="Server"
             id="LabelGridViewKarlSeguinItemTemplateDated" 
             Text='<%# Eval("Dated", "{0:d}") %>'
            />
           </ItemTemplate>
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKarlSeguinEditItemTemplateDated" 
             Text='<%# Bind("Dated") %>'
            />
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKarlSeguinFooterTemplateDated"
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
             id="LabelGridViewKarlSeguinItemTemplateSequenceOrderId" 
             Text='<%# Eval("SequenceOrderId") %>'
            />
           </ItemTemplate>
<%--
           <EditItemTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKarlSeguinEditItemTemplateSequenceOrderId" 
             Text='<%# Bind("SequenceOrderId") %>'
            />
           </EditItemTemplate>
--%>
           <FooterTemplate>
            <asp:TextBox 
             Runat="Server"
             id="TextBoxGridViewKarlSeguinFooterTemplateSequenceOrderId"
             Text='<%# Bind("SequenceOrderId") %>'
            />
            <asp:Button 
             Runat="Server"           
             ID="ButtonGridViewKarlSeguinFooterTemplateAdd"
             OnClick="GridViewKarlSeguinInsert"
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