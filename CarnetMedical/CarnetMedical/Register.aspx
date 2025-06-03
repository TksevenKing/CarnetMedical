<%@ page language="C#" autoeventwireup="true" codebehind="Register.aspx.cs" inherits="CarnetMedical.CarnetMedical.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Inscription</h2>
            <asp:TextBox ID="txtNom" runat="server" Placeholder="Nom" />
            <br />
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" />
            <br />
            <asp:TextBox ID="txtMotDePasse" runat="server" TextMode="Password" Placeholder="Mot de passe" />
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="S'inscrire" OnClick="btnRegister_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

        </div>
    </form>
</body>
</html>
