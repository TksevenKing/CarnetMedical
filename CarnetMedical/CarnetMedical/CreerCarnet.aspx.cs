using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/**************************************************************
 * Fichier        : CreerCarnet.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère la creation d'un carnet médical pour l'utilisateur connecté
 * Date           : Juin 2025
 *************************************************************/

namespace CarnetMedical.CarnetMedical
{
    public partial class CreerCarnet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Protection de la page grace a la session ici je refuse l'acces si la personne n'est pas connecter i.e na pas de session en cours
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }


        }

        // Fonction pour enregistrer le carnet médical de l'utilisateur
        
        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            string groupe = txtGroupeSanguin.Text.Trim();
            string allergies = txtAllergies.Text.Trim();
            string maladies = txtMaladies.Text.Trim();
            string medicaments = txtMedicaments.Text.Trim();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {


                conn.Open();
               

                string query;

    
                    // Insertion
                    query = "INSERT INTO CarnetMedical (UtilisateurId, GroupeSanguin, Allergies, MaladiesChroniques, Medicaments) VALUES (@UserId, @Groupe, @Allergies, @Maladies, @Medicaments)";
               

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Groupe", groupe);
                cmd.Parameters.AddWithValue("@Allergies", allergies);
                cmd.Parameters.AddWithValue("@Maladies", maladies);
                cmd.Parameters.AddWithValue("@Medicaments", medicaments);

                cmd.ExecuteNonQuery();
                lblMessage.Text = "✅ Votre carnet créer  avec succès.";
            }
        }
    }
}