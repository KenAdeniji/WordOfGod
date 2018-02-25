<%@ 
 Control 
 Language="C#" 
 Inherits="WordEngineering.DisplayModeMenuUserControl"  
%>
 
<div>
 <asp:Panel ID="Panel1" runat="server" 
  Borderwidth="1" 
  Width="230" 
  BackColor="lightgray"
  Font-Names="Verdana, Arial, Sans Serif" 
 >
  
  <asp:Label 
   ID="Label1" 
   runat="server" 
   Text="&nbsp;Display Mode" 
   Font-Bold="true"
   Font-Size="8"
   Width="120" 
  />
  
  <asp:DropDownList 
   ID="DropDownListDisplayMode" 
   runat="server"  
   AutoPostBack="true" 
   EnableViewState="false" 
   Width="120"
   OnSelectedIndexChanged="DropDownListDisplayMode_SelectedIndexChanged" 
  />
  
  <asp:LinkButton 
   ID="LinkButton1" 
   runat="server"
   Text="Reset User State" 
   ToolTip="Reset the current user's personalization data for the page."
   Font-Size="8" 
   OnClick="LinkButton1_Click" 
  />
  
  <asp:Panel 
   ID="PanelPersonalizationScope" 
   runat="server" 
   GroupingText="Personalization Scope"
   Font-Bold="true"
   Font-Size="8" 
   Visible="false" 
  >
  
   <asp:RadioButton 
    ID="RadioButtonUser" 
    runat="server" 
    Text="User" 
    AutoPostBack="true"
    GroupName="Scope" 
    OnCheckedChanged="RadioButtonUser_CheckedChanged" 
   />
  
   <asp:RadioButton 
    ID="RadioButtonShared" 
    runat="server" 
    Text="Shared" 
    AutoPostBack="true"
    GroupName="Scope" 
    OnCheckedChanged="RadioButtonShared_CheckedChanged" 
   />
  </asp:Panel>
 </asp:Panel>
</div>