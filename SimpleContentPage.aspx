<%@ Page 
 MasterPageFile="~/Simple.master" 
 Language="C#" 
 Inherits="WordEngineering.SimpleContentPage" 
 Title="Simple Content Page" 
%>

<asp:Content 
 ID="ContentMain" 
 Runat="server"
 ContentPlaceHolderID="ContentPlaceHolderTop" 
>
 Content in Column Top
</asp:Content>

<asp:Content 
 ID="ContentBottom" 
 Runat="server"
 ContentPlaceHolderID="ContentPlaceHolderBottom" 
>
 Content in Column Bottom
</asp:Content>