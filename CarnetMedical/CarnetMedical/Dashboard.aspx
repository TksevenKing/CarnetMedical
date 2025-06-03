<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CarnetMedical.CarnetMedical.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <div>
        <h2>Bienvenue dans votre espace personnel</h2>
        <asp:Label ID="lblNom" runat="server" Font-Bold="true" />

        <hr />

        <ul>
            <li><a href="MonCarnet.aspx">📄 Consulter mon carnet médical</a></li>
            <li><a href="ModifierCarnet.aspx">🖊️ Modifier mon carnet médical</a></li>
            <li><a href="Logout.aspx">🚪 Se déconnecter</a></li>
        </ul>

    </div>

</body>
</html>
