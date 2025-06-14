<%@ Page Title="Mes Patients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyPatients.aspx.cs" Inherits="CarnetMedical.MyPatients" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-success mb-4">👥 Mes Patients</h2>

        <asp:Label ID="lblInfo" runat="server" CssClass="text-danger fw-bold" />

        <asp:GridView ID="gvPatients" runat="server"
                      AutoGenerateColumns="false"
                      CssClass="table table-bordered table-hover"
                      DataKeyNames="Id"
                      OnRowCommand="gvPatients_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Nom" DataField="Nom" />
                <asp:BoundField HeaderText="Email" DataField="Email" />

                <asp:TemplateField HeaderText="Dossier médical">
                    <ItemTemplate>
                        <asp:Button ID="btnVoir" runat="server"
                                    Text="👁️ Voir"
                                    CssClass="btn btn-outline-primary btn-sm"
                                    CommandName="Voir"
                                    CommandArgument='<%# Container.DataItemIndex %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

