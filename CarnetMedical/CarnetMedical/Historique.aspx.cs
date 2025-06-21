using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/**************************************************************
 * Fichier        : Historique.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère l'affichage de l'historique des modifications du carnet médical de l'utilisateur connecté
 * Date           : Juin 2025
 *************************************************************/

namespace CarnetMedical.CarnetMedical
{
    public partial class Historique : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                int userId = Convert.ToInt32(Session["UserId"]);

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
                {
                    string query = "SELECT GroupeSanguin, Allergies, MaladiesChroniques, Medicaments, DateModification FROM CarnetMedicalHistorique WHERE UtilisateurId = @UserId ORDER BY DateModification DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    gvHistorique.DataSource = reader;
                    gvHistorique.DataBind();
                }
            }
        }

    }
}