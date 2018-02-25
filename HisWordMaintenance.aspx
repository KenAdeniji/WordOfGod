﻿<%@ Page 
	Language="C#"
	AutoEventWireup="true"
	CodeFile="HisWordMaintenance.aspx.cs"
	Inherits="HisWordMaintenance" 
	Debug="true"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HisWord Maintenance</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tbody>
                <tr>
					<td>Word:</td>
					<td>
                        <asp:TextBox runat="server" ID="word" Columns="50" />
                    </td>
                </tr>
                <tr>
					<td>Commentary:</td>
					<td>
                        <asp:TextBox runat="server" ID="commentary" Columns="50" />
                    </td>
                </tr>
                <tr>
					<td>Dated:</td>
					<td>
                        <asp:TextBox runat="server" ID="datedFrom" Columns="15" />
						-
                        <asp:TextBox runat="server" ID="datedUntil" Columns="15" />
                    </td>
                </tr>
                <tr>
					<td>Contact Id:</td>
					<td>
                        <asp:TextBox runat="server" ID="contactId" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button runat="server" ID="submit" Text="Submit" OnClick="Submit_Click" /> 
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
	<div align="center">
        <asp:GridView
			 id="hisWordGridView" 
			 runat="server" 
			 AllowPaging=True
			 AllowSorting=True 
			 AutoGenerateColumns=False
			 AutoGenerateDeleteButton=True
			 AutoGenerateEditButton=True
			 AutoGenerateSelectButton=True        
			 DataKeyNames="SequenceOrderId"
			 OnRowEditing="HisWordGridView_RowEditing"
			 OnRowUpdated="GridView_RowUpdated"
			 OnSorting="HisWordGridView_Sorting"
			 SelectedIndex=0
			 ShowFooter=True
        >
			<HeaderStyle BackColor='#CCCC99'/>
			<RowStyle BackColor='#eeeeee'/>
			<AlternatingRowStyle BackColor='#ffffe8'/>
			<Columns>
				<asp:TemplateField HeaderText="Word" SortExpression="Word">
					<ItemTemplate>
						<asp:Label
						 Runat="Server"
						 id="LabelGridViewHisWordItemTemplateWord" 
						 Text='<%# Eval("Word") %>'
						/>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordEditItemTemplateWord" 
						 Text='<%# Bind("Word") %>'
						/>
					</EditItemTemplate>
					<FooterTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordFooterTemplateWord"
						 Text='<%# Bind("Word") %>'
						/>
					</FooterTemplate>
				</asp:TemplateField>
				
				<asp:TemplateField HeaderText="Commentary" SortExpression="Commentary">
					<ItemTemplate>
						<asp:Label
						 Runat="Server"
						 id="LabelGridViewHisCommentaryItemTemplateCommentary" 
						 Text='<%# Eval("Commentary") %>'
						/>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisCommentaryEditItemTemplateCommentary" 
						 Text='<%# Bind("Commentary") %>'
						/>
					</EditItemTemplate>
					<FooterTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisCommentaryFooterTemplateCommentary"
						 Text='<%# Bind("Commentary") %>'
						/>
					</FooterTemplate>
				</asp:TemplateField>

				<asp:TemplateField HeaderText="Uri" SortExpression="Uri">
					<ItemTemplate>
						<asp:Label
						 Runat="Server"
						 id="LabelGridViewHisWordItemTemplateUri" 
						 Text='<%# Eval("Uri") %>'
						/>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordEditItemTemplateUri" 
						 Text='<%# Bind("Uri") %>'
						/>
					</EditItemTemplate>
					<FooterTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordFooterTemplateUri"
						 Text='<%# Bind("Uri") %>'
						/>
					</FooterTemplate>
				</asp:TemplateField>

				<asp:TemplateField HeaderText="ContactId" SortExpression="ContactId">
					<ItemTemplate>
						<asp:Label
						 Runat="Server"
						 id="LabelGridViewHisWordItemTemplateContactId" 
						 Text='<%# Eval("ContactId") %>'
						/>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordEditItemTemplateContactId" 
						 Text='<%# Bind("ContactId") %>'
						/>
					</EditItemTemplate>
					<FooterTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordFooterTemplateContactId"
						 Text='<%# Bind("ContactId") %>'
						/>
					</FooterTemplate>
				</asp:TemplateField>

				<asp:TemplateField HeaderText="ScriptureReference" SortExpression="ScriptureReference">
					<ItemTemplate>
						<asp:Label
						 Runat="Server"
						 id="LabelGridViewHisScriptureReferenceItemTemplateScriptureReference" 
						 Text='<%# Eval("ScriptureReference") %>'
						/>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordEditItemTemplateScriptureReference" 
						 Text='<%# Bind("ScriptureReference") %>'
						/>
					</EditItemTemplate>
					<FooterTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordFooterTemplateScriptureReference"
						 Text='<%# Bind("ScriptureReference") %>'
						/>
					</FooterTemplate>
				</asp:TemplateField>

				<asp:TemplateField HeaderText="FileName" SortExpression="FileName">
					<ItemTemplate>
						<asp:Label
						 Runat="Server"
						 id="LabelGridViewHisWordItemTemplateFileName" 
						 Text='<%# Eval("FileName") %>'
						/>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordEditItemTemplateFileName" 
						 Text='<%# Bind("FileName") %>'
						/>
					</EditItemTemplate>
					<FooterTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordFooterTemplateFileName"
						 Text='<%# Bind("FileName") %>'
						/>
					</FooterTemplate>
				</asp:TemplateField>
				
				<asp:TemplateField HeaderText="EnglishTranslation" SortExpression="EnglishTranslation">
					<ItemTemplate>
						<asp:Label
						 Runat="Server"
						 id="LabelGridViewHisWordItemTemplateEnglishTranslation" 
						 Text='<%# Eval("EnglishTranslation") %>'
						/>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordEditItemTemplateEnglishTranslation" 
						 Text='<%# Bind("EnglishTranslation") %>'
						/>
					</EditItemTemplate>
					<FooterTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordFooterTemplateEnglishTranslation"
						 Text='<%# Bind("EnglishTranslation") %>'
						/>
					</FooterTemplate>
				</asp:TemplateField>

				<asp:TemplateField HeaderText="Dated" SortExpression="Dated">
					<ItemTemplate>
						<asp:Label
						 Runat="Server"
						 id="LabelGridViewHisWordItemTemplateDated" 
						 Text='<%# Eval("Dated") %>'
						/>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordEditItemTemplateDated" 
						 Text='<%# Bind("Dated") %>'
						/>
					</EditItemTemplate>
					<FooterTemplate>
						<asp:TextBox 
						 Runat="Server"
						 id="TextBoxGridViewHisWordFooterTemplateDated"
						 Text='<%# Bind("Dated") %>'
						/>
					</FooterTemplate>
				</asp:TemplateField>

				<asp:TemplateField HeaderText="SequenceOrderId" SortExpression="SequenceOrderId">
					<ItemTemplate>
						<asp:Label
						 Runat="Server"
						 id="LabelGridViewHisWordItemTemplateSequenceOrderId" 
						 Text='<%# Eval("SequenceOrderId") %>'
						/>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:TextBox 
							Runat="Server"
							id="TextBoxGridViewHisWordEditItemTemplateSequenceOrderId" 
							Text='<%# Bind("SequenceOrderId") %>'
						/>
					</EditItemTemplate>
					<FooterTemplate>
						<asp:TextBox 
							 Runat="Server"
							 id="TextBoxGridViewHisWordFooterTemplateSequenceOrderId"
							 Text='<%# Bind("SequenceOrderId") %>'
						/>
			           <asp:Button 
							Runat="Server"           
							ID="ButtonGridViewURIFooterTemplateAdd"
							CommandName="ButtonGridViewURIFooterTemplateAdd" 
							Text="Add"
						/>
					</FooterTemplate>
				</asp:TemplateField>
				
			</Columns>
		</asp:GridView> 
		
		<asp:Literal 
			id="feedback" 
			runat="server" 
			EnableViewState="False"
		/>
	</div>
    </form>
	
    <script>
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