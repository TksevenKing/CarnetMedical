<%@ Page Title="Historiques" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historique.aspx.cs" Inherits="CarnetMedical.CarnetMedical.Historique" %>






<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- affichage de l'historique des modifications du carnet médical de l'utilisateur connecté -->

    <div class="container mt-5">
        <div class="card shadow border-success">
            <div class="card-header bg-success text-white">
                <h4 class="mb-0">📜 Historique de mes modifications médicales</h4>
            </div>
            <div class="card-body">

                <asp:Label ID="lblInfo" runat="server" CssClass="text-danger fw-bold mb-3 d-block" />

                <asp:GridView ID="gvHistorique" runat="server" AutoGenerateColumns="true"
                              CssClass="table table-bordered table-striped table-hover"
                              GridLines="None">
                </asp:GridView>

                <a href="Dashboard.aspx" class="btn btn-outline-secondary mt-3">⬅ Retour au tableau de bord</a>
            </div>
        </div>
    </div>

</asp:Content>

