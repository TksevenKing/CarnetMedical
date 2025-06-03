<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="CarnetMedical.CarnetMedical.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdminDashboard</title>
</head>
<body>
    <div>
        <h2>Tableau de bord - Administrateur</h2>

        <ul>
            <li><a href="AdminUtilisateur.aspx">👤 Gérer les utilisateurs</a></li>
            <li><a href="AdminHistorique.aspx">📋 Voir tous les historiques</a></li>
            <li><a href="Logout.aspx">🚪 Se déconnecter</a></li>
        </ul>

    </div>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
