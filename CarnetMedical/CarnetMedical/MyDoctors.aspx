<%@ Page Title="Mes Docteurs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyDoctors.aspx.cs" Inherits="CarnetMedical.MyDoctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4 text-success">👨‍⚕️ Mes Docteurs Autorisés</h2>

        <asp:Label ID="lblInfo" runat="server" CssClass="text-danger fw-bold" />

        <asp:GridView ID="gvMyDoctors" runat="server"
                      AutoGenerateColumns="false"
                      CssClass="table table-striped table-bordered mt-3"
                      DataKeyNames="DocteurId"
                      OnRowCommand="gvMyDoctors_RowCommand">

            <Columns>
                <asp:BoundField DataField="Nom" HeaderText="Nom" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Specialite" HeaderText="Spécialité" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="🗑️ Retirer"
                                    CssClass="btn btn-danger btn-sm"
                                    CommandName="Supprimer"
                                    CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <a href="DoctorsPublic.aspx" class="btn btn-outline-success mt-3">➕ Ajouter un nouveau docteur</a>
    </div>
</asp:Content>
