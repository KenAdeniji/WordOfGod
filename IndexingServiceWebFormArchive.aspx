<%@ Page 
 Language="C#" 
 Inherits="WordEngineering.IndexingServicePage" 
 debug="true"
%>

<html>
 <head>
  <title>Indexing Service Web Form</title>
 </head>
 <body>
  <form runat="server">
   <table align="center" border="0">
    <tbody>
     <tr align="center">
      <td align="center" colspan="1">
       Catalog Name:
       <asp:TextBox id="TextBoxCatalogName" runat="server" text="TheWord" />
      </td>
     </tr>
     <tr align="center">
      <td align="center" colspan="1">
       Free Text:
       <asp:TextBox id="TextBoxFreeTextSearch" runat="server" />
      </td>
     </tr>
     <tr align="center">
      <td align="center" colspan="1">
       <asp:Button id="ButtonSubmit"  onclick="ButtonSubmit_Click"     runat="server"   Text="Submit"/>
       <asp:Button id="ButtonReset"   onclick="ButtonReset_Click"      runat="server"   Text="Reset"/>
      </td>      
     </tr>        
     <tr>
      <td align="center" colspan="1"><asp:Literal id="LiteralFeedback" runat="server"/></td>
     </tr>    
     <tr align="center">
      <td align="center" colspan="1">
       <asp:Repeater
        id="RepeaterIndexingServiceDocument"
        runat="server"
       >
        <ItemTemplate>
         <asp:HyperLink 
          id="HyperLinkIndexingServiceDocument"
          NavigateUrl=<%# Eval("URL") %>
          Text=<%# Eval("Filename") %>
          Target="_new"
          runat="server"
         />
        </ItemTemplate>
       </asp:Repeater>
      </td>
     </tr>

     <tr align="center">
      <td colspan="2">
       <asp:GridView
        id="GridViewIndexingServiceDocument" 
        runat="server" 
        AutoGenerateColumns=False
       >
        <HeaderStyle
         BackColor='#CCCC99'/>

        <RowStyle
         BackColor='#eeeeee'/>
			
        <AlternatingRowStyle
         BackColor='#ffffe8'/>

        <Columns>
         <asp:HyperLinkField
          Runat="Server"
          DataTextField="Filename"
          DataNavigateURLFields="URL"
          DataNavigateURLFormatString="{0}"
          HeaderText="Filename"
          Target="_blank"
         />
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
     <tr>
     
    </tbody>    
   </table>    
  </form>
 </body>
</html>

<script language="javascript">
 document.forms[0].TextBoxCatalogName.focus();
</script>
