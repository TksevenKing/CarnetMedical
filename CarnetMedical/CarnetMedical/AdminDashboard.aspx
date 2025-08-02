<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="CarnetMedical.CarnetMedical.AdminDashboard" %>


<!-- Dashboard de l'admin -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card border-success shadow">
                    <div class="card-header bg-success text-white text-center">
                        <h4>🔐 Tableau de bord – Administrateur</h4>
                    </div>
                    <div class="card-body text-center">
                        <p class="mb-4">Bienvenue administrateur. Choisissez une action :</p>

                        <div class="d-grid gap-3">
                            <a href="AdminUtilisateur.aspx" class="btn btn-outline-success btn-lg">👤 Gérer les utilisateurs</a>
                            <a href="AdminHistorique.aspx" class="btn btn-outline-success btn-lg">📋 Voir tous les historiques</a>
                          
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <!-- Bootstrap 5 JS (optionnel mais recommandé pour composants interactifs) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
