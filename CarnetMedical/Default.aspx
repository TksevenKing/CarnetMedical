<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarnetMedical._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">





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

    <section class="landing">
        <div class="landing-overlay text-center">
            <h1 class="display-4 text-success fw-bold">Bienvenue sur Carnet Médical 💚</h1>
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

    <hr class="my-5" />

    <div class="row mt-5">
        <div class="col-md-4">
            <h5>🩺 Votre santé, en ligne</h5>
            <p>Conservez toutes vos informations médicales dans un espace personnel et sécurisé.</p>
        </div>
        <div class="col-md-4">
            <h5>📊 Statistiques claires</h5>
            <p>Visualisez vos données médicales grâce à un tableau de bord simple et moderne.</p>
        </div>
        <div class="col-md-4">
            <h5>🔐 Confidentialité assurée</h5>
            <p>Vos données sont protégées et accessibles uniquement par vous.</p>
        </div>
    </div>
    





    

</asp:Content>
