<%@ Page Title="Register Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CarnetMedical.CarnetMedical.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">   


        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card shadow p-4">
                        <h3 class="text-center text-success">Inscription</h3>
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />

                        <div class="mb-3">
                            <label class="form-label">Nom complet</label>
                            <asp:TextBox ID="txtNom" runat="server" CssClass="form-control" placeholder="Nom complet" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Adresse e-mail" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Mot de passe</label>
                            <asp:TextBox ID="txtMotDePasse" runat="server" CssClass="form-control" TextMode="Password" placeholder="Mot de passe" />
                        </div>

                        <asp:Button ID="btnRegister" runat="server" Text="S'inscrire" CssClass="btn btn-success w-100" OnClick="btnRegister_Click" />
                    </div>
                </div>
            </div>
        </div>


    
</asp:Content>



