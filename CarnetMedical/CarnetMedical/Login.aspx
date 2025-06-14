<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CarnetMedical.CarnetMedical.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">


        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card shadow p-4">
                        <h3 class="text-center text-success">Connexion</h3>
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />

                        <div class="mb-3">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" />

                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtMotDePasse" runat="server" TextMode="Password" CssClass="form-control" placeholder="Mot de passe" />
 
                        </div>
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success w-100" Text="Se connecter" OnClick="btnLogin_Click" />
                        <asp:Button ID="ButtonRegister" runat="server" CssClass="btn btn-outline-success w-100 mt-1" Text="S'inscrire" OnClick="btnRegister1_Click" /><br />

                    </div>
                </div>
            </div>
        </div>



    </form>
    <!-- Bootstrap 5 JS (optionnel mais recommandé pour composants interactifs) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>
