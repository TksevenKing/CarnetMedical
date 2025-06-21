<%@ Page Title="Admin utilisateur" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUtilisateur.aspx.cs" Inherits="CarnetMedical.CarnetMedical.AdminUtilisateur" %>






<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Affichage des Utilisateurs avec la possibilte de les supprimer avec leurs donnees associes-->

    <div class="text-center">
        <h3>Bienvenue dans votre espace Administrateur</h3>
    </div>
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card border-success shadow">
                    <div class="card-header bg-success text-white">
                        <h5 class="mb-0">👥 Liste des utilisateurs</h5>
                    </div>
                    <div class="card-body">

                        
                        <!-- GridView pour l'affichage des utilisateurs -->
                        <asp:GridView ID="gvUtilisateurs" runat="server"
                            AutoGenerateColumns="false"
                            CssClass="table table-bordered"
                            DataKeyNames="Id"
                            OnRowCommand="gvUtilisateurs_RowCommand">

                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="Id" />
                                <asp:BoundField HeaderText="Nom" DataField="Nom" />
                                <asp:BoundField HeaderText="Email" DataField="Email" />
                                <asp:BoundField HeaderText="Rôle" DataField="Role" />

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSupprimer" runat="server" Text="🗑️ Supprimer"
                                            CssClass="btn btn-danger btn-sm"
                                            CommandName="Supprimer"
                                            CommandArgument='<%# Container.DataItemIndex %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <asp:Label ID="lblInfo" runat="server" CssClass="text-success mt-2 d-block" />

                        <!-- GridView pour l'affichage des Docteurs -->
                        <asp:GridView ID="gvDocteurs" runat="server"
                            AutoGenerateColumns="false"
                            CssClass="table table-bordered"
                            DataKeyNames="Id"
                            OnRowCommand="gvDocteurs_RowCommand">

                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="Id" />
                                <asp:BoundField HeaderText="Nom" DataField="Nom" />
                                <asp:BoundField HeaderText="Email" DataField="Email" />
                                <asp:BoundField HeaderText="Spécialité" DataField="Specialite" />
                                <asp:BoundField HeaderText="Role" DataField="Role" />

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSupprimer" runat="server" Text="🗑️ Supprimer"
                                            CssClass="btn btn-danger btn-sm"
                                            CommandName="Supprimer"
                                            CommandArgument='<%# Container.DataItemIndex %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <asp:Label ID="lblInfoDoc" runat="server" CssClass="text-success mt-2 d-block" />

                        <a href="AdminDashboard.aspx" class="btn btn-outline-secondary mt-3">⬅ Retour</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
