<%@ Page 
 MasterPageFile="~/MasterSimple.master" 
 Language="C#" 
 Inherits="WordEngineering.ContentSimplePage" 
 Title="Simple Content Page"
 Debug="true" 
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