<%@ Page Title="ModifierCarnet" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="ModifierCarnet.aspx.cs" Inherits="CarnetMedical.CarnetMedical.ModifierCarnet" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Ton contenu ici : cards, graphiques, données, etc. -->

    <div class="text-center">
        <h3>Bienvenue dans votre espace personnel</h3>
    </div>
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card border-success shadow">
                    <div class="card-header bg-success text-white text-center">
                        <h4>🖊️ Modifier mon carnet médical</h4>
                    </div>
                    <div class="card-body">
                        <asp:Label ID="Label1" runat="server" CssClass="text-success" /><br />

                        <div class="mb-3">
                            <label class="form-label">🩸 Groupe sanguin</label>
                            <asp:TextBox ID="txtGroupeSanguin" runat="server" CssClass="form-control" placeholder="Ex : O+, A-, AB-" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">🤧 Allergies</label>
                            <asp:TextBox ID="txtAllergies" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Entrez vos allergies ici..." />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">🏥 Maladies chroniques</label>
                            <asp:TextBox ID="txtMaladies" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Entrez vos maladies chroniques ici..." />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">💊 Médicaments</label>
                            <asp:TextBox ID="txtMedicaments" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Entrez vos traitements ou médicaments..." />
                        </div>

                        <div class="d-flex justify-content-between">
                            <a href="Dashboard.aspx" class="btn btn-outline-secondary">⬅ Retour</a>
                            <asp:Button ID="btnEnregistrer" runat="server" CssClass="btn btn-success" Text="💾 Enregistrer" OnClick="btnEnregistrer_Click" />
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" /><br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>



