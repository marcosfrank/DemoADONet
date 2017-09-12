<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Demo.UI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnExecuteSelect" runat="server" Text="Select" OnClick="btnExecuteSelect_Click" />
            <asp:Button ID="btnExecuteStoreProcedure" runat="server" Text="ExecuteSP" OnClick="btnExecuteStoreProcedure_Click" />
            <asp:Button ID="btnExecuteUpdate" runat="server" Text="Update" OnClick="btnExecuteUpdate_Click" />
            <asp:Button ID="btnExecuteInsert" runat="server" Text="Insert" OnClick="btnExecuteInsert_Click" />
            <asp:Button ID="btnExecuteDelete" runat="server" Text="Delete" />
        </div>
        <div>
            <asp:GridView ID="dgvResultados" runat="server">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <label>RegionID</label>
            <asp:TextBox ID="txtRegionId" runat="server"></asp:TextBox><br />
            <label>Description</label>
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox><br />
        </div>
    </form>
</body>
</html>