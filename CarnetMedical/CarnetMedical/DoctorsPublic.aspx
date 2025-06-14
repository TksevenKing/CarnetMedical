<%@ Page Title="Tous les Docteurs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorsPublic.aspx.cs" Inherits="CarnetMedical.DoctorsPublic" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-success mb-4">📋 Tous les docteurs disponibles</h2>

        <asp:Label ID="lblInfo" runat="server" CssClass="text-danger fw-bold" />

        <asp:GridView ID="gvDoctors" runat="server"
                      AutoGenerateColumns="False"
                      CssClass="table table-bordered table-hover"
                      OnRowCommand="gvDoctors_RowCommand"
                      DataKeyNames="Id">
            <Columns>
                <asp:BoundField HeaderText="Nom" DataField="Nom" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Spécialité" DataField="Specialite" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Label ID="lblAjoute" runat="server" Text="✔️ Ajouté"
                                   CssClass="text-success fw-bold"
                                   Visible='<%# (bool)Eval("EstAjoute") %>' />

                        <asp:Button ID="btnAjouter" runat="server"
                                    Text="Ajouter"
                                    CssClass="btn btn-success btn-sm"
                                    CommandName="Ajouter"
                                    CommandArgument='<%# Container.DataItemIndex %>'
                                    Visible='<%# !(bool)Eval("EstAjoute") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <a href="MyDoctors.aspx" class="btn btn-outline-secondary mt-3">⬅ Retour à mes docteurs</a>
    </div>
</asp:Content>
