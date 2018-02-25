<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Imaging" %>
<%@ Import Namespace="System.IO" %>

<html>
  <body>
    <asp:DynamicImage ID="PieChart" DynamicImageType="ImageBytes"
      RunAt="server" />
  </body>
</html>

<script language="C#" runat="server">
void Page_Load (Object sender, EventArgs e)
{
    // Create a bitmap and draw a pie chart
    Bitmap bitmap = new Bitmap (240, 180, PixelFormat.Format32bppArgb);
    Graphics g = Graphics.FromImage (bitmap);
    DrawPieChart (g, Color.White, new decimal[]
        { 100.0m, 200.0m, 300.0m, 400.0m }, 240, 180);
    g.Dispose();

    // Attach the image to the DynamicImage control
    MemoryStream stream = new MemoryStream ();
    bitmap.Save (stream, ImageFormat.Gif);
    bitmap.Dispose();
    PieChart.ImageBytes = stream.ToArray ();
}

void DrawPieChart (Graphics g, Color bkgnd, decimal[] vals,
    int width, int height)
{
    // Erase the background
    SolidBrush br = new SolidBrush (bkgnd);
    g.FillRectangle (br, 0, 0, width, height);
    br.Dispose ();

    // Create an array of brushes
    SolidBrush[] brushes = new SolidBrush[6];
    brushes[0] = new SolidBrush (Color.Red);
    brushes[1] = new SolidBrush (Color.Yellow);
    brushes[2] = new SolidBrush (Color.Blue);
    brushes[3] = new SolidBrush (Color.Cyan);
    brushes[4] = new SolidBrush (Color.Magenta);
    brushes[5] = new SolidBrush (Color.Green);

    // Sum the inputs
    decimal total = 0.0m;
    foreach (decimal val in vals)
        total += val;

    // Draw the chart
    float start = 0.0f;
    float end = 0.0f;
    decimal current = 0.0m;

    for (int i=0; i<vals.Length; i++) {
        current += vals[i];
        start = end;
        end = (float) (current / total) * 360.0f;
        g.FillPie (brushes[i % 6], 0.0f, 0.0f, width, height,
            start, end - start);
    }

    // Clean up and return
    foreach (SolidBrush brush in brushes)
        brush.Dispose ();
}
</script>