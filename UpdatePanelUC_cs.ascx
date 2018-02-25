<%@ Control Language="C#" ClassName="WebUserControl" %>

<script runat="server">

    public string Text
    {
        get
        {
            return myLabel.Text;
        }
        set
        {
            myLabel.Text = value;
        }
    }

</script>

<asp:Label runat="server" ID="myLabel" >Empty UserControl</asp:Label><br />