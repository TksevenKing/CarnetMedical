<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminHistorique.aspx.cs" Inherits="CarnetMedical.CarnetMedical.AdminHistorique" %>







<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Ton contenu ici : cards, graphiques, données, etc. -->
    <div class="text-center">
        <h3>Bienvenue dans votre espace Administrateur</h3>
    </div>

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card border-success shadow">
                    <div class="card-header bg-success text-white">
                        <h5 class="mb-0">📚 Historique médical de tous les utilisateurs</h5>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="gvAllHistoriques" runat="server" CssClass="table table-bordered table-hover" />
                        <a href="AdminDashboard.aspx" class="btn btn-outline-secondary mt-3">⬅ Retour</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
