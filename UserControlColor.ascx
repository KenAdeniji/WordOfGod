<% @ Control Language="C#" ClassName="UserControlColor" %>
<script runat="server">
    protected int currentColorIndex;
    protected String[] colors = {"Red", "Blue", "Green", "Yellow"};
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            currentColorIndex = 
                Int16.Parse(ViewState["currentColorIndex"].ToString());
        }
        else
        {
            currentColorIndex = 0;
            DisplayColor();
        }
    }
    
    protected void DisplayColor()
    {
        textColor.Text = colors[currentColorIndex];
        ViewState["currentColorIndex"] = currentColorIndex.ToString();
    }
    
    protected void buttonUp_Click(object sender, EventArgs e)
    {
        if(currentColorIndex == 0)
        {
            currentColorIndex = colors.Length - 1;
        }
        else
        {
            currentColorIndex -= 1;
        }
        DisplayColor();
    }

    protected void buttonDown_Click(object sender, EventArgs e)
    {
        if(currentColorIndex == (colors.Length - 1))
        {
            currentColorIndex = 0;
        }    
        else
        {
            currentColorIndex += 1;
        }
        DisplayColor();
    }
</script>
<asp:TextBox ID="textColor" runat="server" 
    ReadOnly="True" />
<asp:Button Font-Bold="True" ID="buttonUp" runat="server" 
    Text="^" OnClick="buttonUp_Click" />
<asp:Button Font-Bold="True" ID="buttonDown" runat="server" 
    Text="v" OnClick="buttonDown_Click" />