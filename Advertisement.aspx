<%@ Page Language="C#" AutoEventWireup="true" %>
<html>
 <head runat="server">
  <title runat="server">Advertisement</title>
  <script runat="server" language="C#">
   protected void Ads_AdCreated(Object sender, AdCreatedEventArgs e)
   {
    Banner.NavigateUrl = e.NavigateUrl;
    Banner.Text = e.AlternateText;
   }
  </script>
 </head>
 <body>
  <form runat="server">
   <asp:AdRotator runat="server" id="Ads" AdvertisementFile="Advertisement.xml" Target="_blank" KeywordFilter="Computer" OnAdCreated="Ads_AdCreated" />
   <asp:HyperLink runat="server" id="Banner" />
  </form>
 </body>
</html>