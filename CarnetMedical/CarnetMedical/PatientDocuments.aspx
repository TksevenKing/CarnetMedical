<%@ Page Title="Documents du patient" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientDocuments.aspx.cs" Inherits="CarnetMedical.CarnetMedical.PatientDocuments" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="card border-primary shadow">
            <div class="card-header bg-success text-white">
                <h4 class="mb-0">📂 Documents médicaux du patient</h4>
            </div>
            <div class="card-body">

                <!-- Message d’erreur ou d’info -->
                <asp:Label ID="lblInfo" runat="server" CssClass="text-danger fw-bold d-block mb-3" />

                <!-- Table des PDF -->
                <asp:GridView ID="gvDocs" runat="server" AutoGenerateColumns="false"
                              CssClass="table table-bordered table-hover"
                              DataKeyNames="Id" 
                              OnRowCommand="gvDocs_RowCommand">
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

                <a href="MyPatients.aspx" class="btn btn-outline-secondary mt-3">⬅ Retour à la liste des patients</a>
            </div>
        </div>
    </div>
</asp:Content>

