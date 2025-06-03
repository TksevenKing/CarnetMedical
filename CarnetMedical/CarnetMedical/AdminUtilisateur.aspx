<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUtilisateur.aspx.cs" Inherits="CarnetMedical.CarnetMedical.AdminUtilisateur" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdminUtilisateur</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Liste des utilisateurs</h2>
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="true" />
            <a href="AdminDashboard.aspx">⬅ Retour</a>

        </div>
    </form>
</body>
</html>
