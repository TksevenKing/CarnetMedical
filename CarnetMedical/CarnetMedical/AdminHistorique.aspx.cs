using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/**************************************************************
 * Fichier        : AdminHistorique.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère l'affichage de l'historique des modifications du carnet médical de tous les Utilsateurs
 * Date           : Juin 2025
 *************************************************************/

namespace CarnetMedical.CarnetMedical
{
    public partial class AdminHistorique : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Vérifier que l'utilisateur est connecté et a le rôle "Admin"
            if (Session["Role"]?.ToString() != "Admin") Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                // Charger l'historique des modifications du carnet médical de tous les utilisateurs
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["carnetMedConnectionName"].ConnectionString))
                {
                    string query = "SELECT UtilisateurId, GroupeSanguin, Allergies, MaladiesChroniques, Medicaments, DateModification FROM CarnetMedicalHistorique ORDER BY DateModification DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    gvAllHistoriques.DataSource = cmd.ExecuteReader();
                    gvAllHistoriques.DataBind();
                }
            }
        }

    }
}