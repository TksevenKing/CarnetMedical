<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHistorique.aspx.cs" Inherits="CarnetMedical.CarnetMedical.AdminHistorique" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Historique de tous les utilisateurs</h2>
            <asp:GridView ID="gvAllHistoriques" runat="server" AutoGenerateColumns="true" />
            <a href="AdminDashboard.aspx">⬅ Retour</a>

        </div>
    </form>
</body>
</html>
