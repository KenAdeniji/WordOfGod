<%@ Page Language="C#" AutoEventWireup="true" %>
<html>
 <head runat="server">
  <title runat="server">Calendar</title>
  <script runat="server" language="C#">
   protected void Submit_Click(Object sender, EventArgs e)
   {
    Feedback.Text = "Selected date: ";
    foreach(DateTime dt in Dated.SelectedDates)
    {
     Feedback.Text += dt.ToLongDateString();
    }
   }
   protected void DayRender(Object source, DayRenderEventArgs e)
   {
    if (e.Day.IsWeekend || e.Day.Date.Year > 2010)
    {
     e.Day.IsSelectable = false;
    }
   }
  </script>
 </head>
 <body>
  <form runat="server">
   <asp:Calendar runat="server" id="Dated" SelectionMode="DayWeekMonth" OnDayRender="DayRender" />
   <asp:Button runat="server" id="Submit" Text="Submit" OnClick="Submit_Click" />
   <asp:Literal runat="server" id="Feedback" />
  </form>
 </body>
</html>