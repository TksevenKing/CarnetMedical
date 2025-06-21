<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CarnetMedical.CarnetMedical.Register" %>


<!--
     * Fichier        : Register.apsx
     * Rôle           : Gere l'inscription des utilisateurs sauf pour l'admin dont on insere l'email, le MDP et le Role directement dans la base de donnees dans MSSQL en specifiant le Role = "admin"
     * Auteur         : Oumar Cissé
    -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <!-- NavBAR -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-success text-center">
            <div class="container-fluid">
                <a class="navbar-brand fw-bold fs-4" href="Default.aspx">MediCard 🩺</a>
            </div>
        </nav>

        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card shadow p-4">
                        <h3 class="text-center text-success">Inscription</h3>


                        <div class="mb-3">
                            <label class="form-label">Nom complet</label>
                            <asp:TextBox ID="txtNom" runat="server" CssClass="form-control" placeholder="Nom complet" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Adresse e-mail" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Mot de passe</label>
                            <asp:TextBox ID="txtMotDePasse" runat="server" CssClass="form-control" TextMode="Password" placeholder="Mot de passe" />
                        </div>

                        <asp:Button ID="btnRegister" runat="server" Text="S'inscrire" CssClass="btn btn-success w-100" OnClick="btnRegister_Click" />

                        <!-- Pour un docteur ajouter le champ "Specialite" lors de l'inscriton -->
                        <a href="RegisterDoctor.aspx" class="btn btn-outline-success mt-1">Je suis un docteur</a>
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
                    </div>
                </div>
            </div>
        </div>



    </form>
    <!-- Bootstrap 5 JS (optionnel mais recommandé pour composants interactifs) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>

