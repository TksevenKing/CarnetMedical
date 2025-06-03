<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifierCarnet.aspx.cs" Inherits="CarnetMedical.CarnetMedical.ModifierCarnet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Modifier mon carnet médical</h2>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" /><br />
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtGroupeSanguin" runat="server" Placeholder="Groupe sanguin" /><br />
            <asp:TextBox ID="txtAllergies" runat="server" TextMode="MultiLine" Rows="3" Columns="50" Placeholder="Allergies" /><br />
            <asp:TextBox ID="txtMaladies" runat="server" TextMode="MultiLine" Rows="3" Columns="50" Placeholder="Maladies chroniques" /><br />
            <asp:TextBox ID="txtMedicaments" runat="server" TextMode="MultiLine" Rows="3" Columns="50" Placeholder="Médicaments" /><br />
            <br />

            <asp:Button ID="btnEnregistrer" runat="server" Text="💾 Enregistrer" OnClick="btnEnregistrer_Click" /><br />
            <a href="Historique.aspx">Voir l'Historique des Modificationss</a>
            <br />
            <a href="Dashboard.aspx">⬅ Retour</a>

        </div>
    </form>
</body>
</html>
