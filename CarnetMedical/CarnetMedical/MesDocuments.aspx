<%@ Page Title="Mes documents" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MesDocuments.aspx.cs" Inherits="CarnetMedical.CarnetMedical.MesDocuments" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Importation des document medicaux scannee au format PDF -->

    <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" />
    <asp:Button ID="btnUpload" runat="server" Text="📤 Importer le document"
        CssClass="btn btn-success mt-2" OnClick="btnUpload_Click" />
    <asp:Label ID="lblMessage" runat="server" CssClass="text-success fw-bold d-block mt-2" />

    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="false"
        CssClass="table table-bordered mt-4"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Nom du fichier" DataField="NomFichier" />
            <asp:BoundField HeaderText="Date d'ajout" DataField="DateAjout" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a class="btn btn-outline-primary btn-sm" href='<%# Eval("Chemin") %>' target="_blank">📄 Voir</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
