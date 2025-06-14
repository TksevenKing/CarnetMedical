<%@ Page Title="Carnet du Patient" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPatientCarnet.aspx.cs" Inherits="CarnetMedical.ViewPatientCarnet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="card border-primary shadow">
            <div class="card-header bg-success text-white text-center">
                <h4>📖 Carnet Médical du Patient</h4>
            </div>
            <div class="card-body">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger fw-bold" />

                <dl class="row">
                    <dt class="col-sm-4">🩸 Groupe Sanguin</dt>
                    <dd class="col-sm-8">
                        <asp:Label ID="lblGroupeSanguin" runat="server" /></dd>

                    <dt class="col-sm-4">🤧 Allergies</dt>
                    <dd class="col-sm-8">
                        <asp:Label ID="lblAllergies" runat="server" /></dd>

                    <dt class="col-sm-4">🏥 Maladies Chroniques</dt>
                    <dd class="col-sm-8">
                        <asp:Label ID="lblMaladies" runat="server" /></dd>

                    <dt class="col-sm-4">💊 Médicaments</dt>
                    <dd class="col-sm-8">
                        <asp:Label ID="lblMedicaments" runat="server" /></dd>

                    <dt class="col-sm-4">📅 Dernière mise à jour</dt>
                    <dd class="col-sm-8">
                        <asp:Label ID="lblDateMaj" runat="server" /></dd>
                </dl>

                <hr class="my-4" />

<h5 class="text-primary">📂 Documents médicaux joints</h5>

<asp:GridView ID="gvDocs" runat="server" AutoGenerateColumns="false"
              CssClass="table table-bordered table-hover mt-3"
              DataKeyNames="Id">
    <Columns>
        <asp:BoundField HeaderText="Nom du fichier" DataField="NomFichier" />
        <asp:BoundField HeaderText="Date d'ajout" DataField="DateAjout" 
                        DataFormatString="{0:dd/MM/yyyy HH:mm}" />
        <asp:TemplateField HeaderText="Voir">
            <ItemTemplate>
                <a class="btn btn-outline-success btn-sm"
                   href='<%# Eval("Chemin") %>' target="_blank">📄 Ouvrir</a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


                <div class="d-flex justify-content-between">
                                    <a href="MyPatients.aspx" class="btn btn-outline-secondary">⬅ Retour</a>

                <asp:Button ID="btnExportPDF" runat="server" Text="📤 Exporter en PDF"
                    CssClass="btn btn-primary"
                    OnClick="btnExportPDF_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
