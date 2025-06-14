<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarnetMedical._Default" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .landing {
            background: url('CarnetMedical/images/medical-bg.jpg') no-repeat center center;
            background-size: cover;
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            color: white;
            text-shadow: 0 1px 4px rgba(0,0,0,0.7);
        }

        .landing-overlay {
            background-color: rgba(0, 0, 0, 0.6); /* Assombrissement du fond */
            padding: 60px;
            border-radius: 15px;
        }

        @media (max-width: 768px) {
            .landing-overlay {
                padding: 30px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <!-- NavBAR -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-success">
            <div class="container-fluid">
                <a class="navbar-brand fw-bold fs-4" href="Default.aspx">MediCard 🩺</a>
            </div>
        </nav>




        <section class="landing">
            <div class="landing-overlay text-center">
                <h1 class="display-4 text-success fw-bold">Bienvenue sur MediCard 🩺</h1>
                <p class="lead mt-3 mb-4">
                    Gérez vos informations médicales en toute simplicité et sécurité.<br />
                    Consultez votre historique, suivez vos traitements, et accédez à votre dossier à tout moment.
                </p>

                <div class="d-grid gap-2 d-sm-flex justify-content-sm-center">
                    <a href="CarnetMedical/Login.aspx" class="btn btn-success btn-lg px-4 me-sm-3">Se connecter</a>
                    <a href="CarnetMedical/Register.aspx" class="btn btn-outline-light btn-lg px-4">Créer un compte</a>
                </div>
            </div>
        </section>

        <!-- ✅ Section infos en cartes -->
        <section class="py-5 bg-light">
            <div class="container">
                <h3 class="text-center mb-4 text-success fw-bold">Pourquoi choisir MediCard 🩺 ?</h3>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <div class="card h-100 border-success shadow-sm">
                            <div class="card-body text-center">
                                <h5 class="card-title">🩺 Votre santé, en ligne</h5>
                                <p class="card-text">Conservez toutes vos informations médicales dans un espace personnel et sécurisé.</p>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4 mb-4">
                        <div class="card h-100 border-success shadow-sm">
                            <div class="card-body text-center">
                                <h5 class="card-title">📊 Statistiques claires</h5>
                                <p class="card-text">Visualisez vos données médicales grâce à un tableau de bord simple et moderne.</p>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4 mb-4">
                        <div class="card h-100 border-success shadow-sm">
                            <div class="card-body text-center">
                                <h5 class="card-title">🔐 Confidentialité assurée</h5>
                                <p class="card-text">Vos données sont protégées et accessibles uniquement par vous.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>


        <!-- Footer -->
        <footer class="bg-success text-white text-center py-3 border-top mt-0">
            <p class="mb-0">&copy; <%: DateTime.Now.Year %> - MediCard 🩺 | By OumarKingDev - Tous droits réservés</p>
        </footer>


    </form>
    <!-- Bootstrap 5 JS (optionnel mais recommandé pour composants interactifs) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>







