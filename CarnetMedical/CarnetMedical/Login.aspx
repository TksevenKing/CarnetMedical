<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CarnetMedical.CarnetMedical.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Connexion</h2>
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" /><br />
            <asp:TextBox ID="txtMotDePasse" runat="server" TextMode="Password" Placeholder="Mot de passe" /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Se connecter" OnClick="btnLogin_Click" /><br />
            <asp:Button ID="ButtonRegister" runat="server" Text="S'inscrire" OnClick="btnRegister1_Click" /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

        </div>
    </form>
</body>
</html>
