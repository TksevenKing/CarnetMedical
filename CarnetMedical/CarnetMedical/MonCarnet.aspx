<%@ Page Title="MonCarnet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MonCarnet.aspx.cs" Inherits="CarnetMedical.CarnetMedical.MonCarnet" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--
     * Fichier        : MonCarnet.apsx
     * Rôle           : Affichage du carnet medical y compris les dossiers scannés qui ont été televersé
     * Auteur         : Oumar Cissé
    -->

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card border-success shadow">
                    <div class="card-header bg-success text-white text-center">
                        <h4>🩺 Mon Carnet Médical</h4>
                    </div>
                    <div class="card-body">
                        <dl class="row">
                            <dt class="col-sm-4">🩸 Groupe sanguin</dt>
                            <dd class="col-sm-8">
                                <asp:Label ID="lblGroupeSanguin" runat="server" /></dd>

                            <dt class="col-sm-4">🤧 Allergies</dt>
                            <dd class="col-sm-8">
                                <asp:Label ID="lblAllergies" runat="server" /></dd>

                            <dt class="col-sm-4">🏥 Maladies chroniques</dt>
                            <dd class="col-sm-8">
                                <asp:Label ID="lblMaladies" runat="server" /></dd>

                            <dt class="col-sm-4">💊 Médicaments</dt>
                            <dd class="col-sm-8">
                                <asp:Label ID="lblMedicaments" runat="server" /></dd>

                            <dt class="col-sm-4">🕒 Dernière mise à jour</dt>
                            <dd class="col-sm-8">
                                <asp:Label ID="lblDerniereMaj" runat="server" /></dd>
                        </dl>

                        <div class="d-flex justify-content-between mt-4">
                            <a href="MesDocuments.aspx" class="btn btn-outline-secondary">Téléverser Mes documents</a>

                            <a href="CreerCarnet.aspx" class="btn btn-outline-success">Créer un Carnet</a>

                            <asp:Button ID="btnExportPDF" runat="server" Text="📤 Exporter en PDF" CssClass="btn btn-success" OnClick="btnExportPDF_Click" />



                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr class="my-4" />

    <h5 class="text-success">📂 Documents médicaux joints</h5>

    <asp:GridView ID="gvDocs" runat="server" AutoGenerateColumns="false"
        CssClass="table table-bordered table-hover mt-3"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Nom du fichier" DataField="NomFichier" />
            <asp:BoundField HeaderText="Date d'ajout" DataField="DateAjout"
                DataFormatString="{0:dd/MM/yyyy HH:mm}" />
            <asp:TemplateField HeaderText="Voir">
                <ItemTemplate>
                    <a class="btn btn-outline-primary btn-sm"
                        href='<%# Eval("Chemin") %>' target="_blank">📄 Ouvrir</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
