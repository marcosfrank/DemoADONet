﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Demo.UI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnExecuteSelect" runat="server" Text="Select" OnClick="btnExecuteSelect_Click" />
            <asp:Button ID="btnExecuteUpdate" runat="server" Text="Update" OnClick="btnExecuteUpdate_Click" />
            <asp:Button ID="btnExecuteInsert" runat="server" Text="Insert" OnClick="btnExecuteInsert_Click" />
            <asp:Button ID="btnExecuteDelete" runat="server" Text="Delete" OnClick="btnExecuteDelete_Click" />
            <asp:Button ID="btnClean" runat="server" Text="Limpiar" OnClick="btnClean_Click" />
            <a href="StoreProcedure.aspx">Store Procedures</a>
        </div>
        <br />
        <div>
            <asp:GridView ID="dgvResultados" runat="server" OnRowCommand="dgvResultados_RowCommand">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" HeaderText="Seleccionar" />
                </Columns>
            </asp:GridView>
            <label>RegionID</label>
            <asp:TextBox ID="txtRegionId" runat="server" Enabled="false"></asp:TextBox><br />
            <label>Description</label>
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox><br />
        </div>
        <div>
            <asp:Label ID="lblError" ForeColor="Red" Text="" runat="server" />
        </div>
    </form>
</body>
</html>