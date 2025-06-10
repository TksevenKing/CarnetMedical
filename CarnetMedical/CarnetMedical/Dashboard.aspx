<%@ Page Title="dashboard" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CarnetMedical.CarnetMedical.Dashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h3>Bienvenue dans votre espace personnel</h3>
    </div>
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card border-success shadow">
                    <div class="card-header bg-success text-white text-center">
                        <h4>👋 Bienvenue sur votre tableau de bord</h4>
                    </div>
                    <div class="card-body text-center">
                        <h5>
                            <asp:Label ID="lblNom" runat="server" CssClass="text-success" />
                        </h5>
                        <p class="mb-4">Utilisez les liens ci-dessous pour accéder à vos informations médicales.</p>

                        <div class="d-grid gap-3">
                            <a href="MonCarnet.aspx" class="btn btn-outline-success btn-lg">📄 Consulter mon carnet médical</a>
                            <a href="ModifierCarnet.aspx" class="btn btn-outline-success btn-lg">🖊️ Modifier mon carnet médical</a>
                            <a href="Historique.aspx" class="btn btn-outline-success btn-lg">🕒 Voir l’historique</a>
                            <a href="Logout.aspx" class="btn btn-danger btn-lg">🚪 Se déconnecter</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

