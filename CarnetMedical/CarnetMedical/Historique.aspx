<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historique.aspx.cs" Inherits="CarnetMedical.CarnetMedical.Historique" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Ton contenu ici : cards, graphiques, données, etc. -->
    <div class="text-center">
        <h3>Bienvenue dans votre espace personnel</h3>
    </div>

    <div>
        <h2>Historique de mes modifications médicales</h2>
        <asp:GridView ID="gvHistorique" runat="server" AutoGenerateColumns="true" />
        <a href="Dashboard.aspx">⬅ Retour</a>

    </div>
</asp:Content>

