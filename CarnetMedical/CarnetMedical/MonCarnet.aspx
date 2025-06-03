<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonCarnet.aspx.cs" Inherits="CarnetMedical.CarnetMedical.MonCarnet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Mon Carnet Médical</h2>

    <asp:Label ID="lblGroupeSanguin" runat="server" /><br />
    <asp:Label ID="lblAllergies" runat="server" /><br />
    <asp:Label ID="lblMaladies" runat="server" /><br />
    <asp:Label ID="lblMedicaments" runat="server" /><br />
    <asp:Label ID="lblDerniereMaj" runat="server" /><br />
    <br />

    <form id="form1" runat="server">
        <asp:Button ID="btnExportPDF" runat="server" Text="📤 Exporter en PDF" OnClick="btnExportPDF_Click" />
    </form>



    <a href="Dashboard.aspx">⬅ Retour au tableau de bord</a>

</body>
</html>
