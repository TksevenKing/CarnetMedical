<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Historique.aspx.cs" Inherits="CarnetMedical.CarnetMedical.Historique" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Historique de mes modifications médicales</h2>
            <asp:GridView ID="gvHistorique" runat="server" AutoGenerateColumns="true" />
            <a href="Dashboard.aspx">⬅ Retour</a>

        </div>
    </form>
</body>
</html>
