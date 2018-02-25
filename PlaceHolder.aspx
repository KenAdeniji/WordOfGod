<%@ Page Language="C#" AutoEventWireup="True" %>

<html>
<head>

   <script runat="server">

      void Page_Load(Object sender, EventArgs e)
      {
         HtmlButton myButton = new HtmlButton();

         myButton.InnerText = "Button 1";
         PlaceHolder1.Controls.Add(myButton);

         myButton = new HtmlButton();
         myButton.InnerText = "Button 2";
         PlaceHolder1.Controls.Add(myButton);

         myButton = new HtmlButton();
         myButton.InnerText = "Button 3";
         PlaceHolder1.Controls.Add(myButton);

         myButton = new HtmlButton();
         myButton.InnerText = "Button 4";
         PlaceHolder1.Controls.Add(myButton);
      }

   </script>

</head>
<body>
   <form runat="server">
      <h3>PlaceHolder Example</h3>

      <asp:PlaceHolder id="PlaceHolder1" 
           runat="server"/>
   </form>
</body>
</html>