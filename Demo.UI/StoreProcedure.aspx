<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreProcedure.aspx.cs" Inherits="Demo.UI.StoreProcedure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:Button ID="btnExecuteStoreProcedure" runat="server" Text="ExecuteSP" OnClick="btnExecuteStoreProcedure_Click" />
            <a href="Index.aspx">Volver</a>
            <br />
            <asp:GridView ID="dgvResultadosStoreProcedure" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>