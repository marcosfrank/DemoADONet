﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Demo.UI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtInit" runat="server"></asp:TextBox>
            <asp:Button ID="btnExecuteSelect" runat="server" Text="Select" OnClick="btnExecuteSelect_Click" />
            <asp:Button ID="btnExecuteStoreProcedure" runat="server" Text="ExecuteSP" OnClick="btnExecuteStoreProcedure_Click" />
            <asp:Button ID="btnExecuteUpdate" runat="server" Text="Update" OnClick="btnExecuteUpdate_Click" />
            <asp:Button ID="btnExecuteInsert" runat="server" Text="Insert" />
            <asp:Button ID="btnExecuteDelete" runat="server" Text="Delete" />
        </div>
        <div>
            <asp:GridView ID="dgvDatos" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>