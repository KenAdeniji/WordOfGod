<%@ Page Language="c#" %>
<script runat="server">
    void GridViewUpdated(Object s, GridViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblError.Text = "Could not update row";
            e.ExceptionHandled = true;
        }
    }
</script>

<html>
<head runat="server">
    <title>Display GridView</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:DetailsView
        DataSourceID="TitlesSource"
        Runat="Server" 
        AllowSorting="true"
        AllowPaging="true"
        PageSize="4"
        AutoGenerateEditButton="true"
        DataKeyNames="SequenceOrderId"
   
        OnRowUpdated="GridViewUpdated"
    />
    
    <asp:Label 
        ID="lblError" 
        ForeColor="Red"
        EnableViewState="false" 
        Runat="Server" />
    
    <asp:SqlDataSource 
        ID="TitlesSource"
        ConnectionString="SERVER=(local);DATABASE=WordEngineering;UID=WordEngineering;PWD=khouse;"
        SelectCommand="SELECT * FROM Contact Order By FirstName, LastName"
        UpdateCommand="Update Contact
            SET 
                FirstName=@FirstName,
                LastName=@LastName,
                OtherName=@OtherName,
                Company=@Company,
                Prefix=@Prefix,
                Suffix=@Suffix,
                Commentary=@Commentary.
                ScriptureReference=@ScriptureReference
            WHERE 
                SequenceOrderId=@SequenceOrderId"
        Runat="Server" /> 
    </form>
</body>
</html>