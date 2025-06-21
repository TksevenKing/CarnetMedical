using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/**************************************************************
 * Fichier        : ModifierCarnet.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère la modification et la suppression du carnet médical de l'utilisateur connecté
 * Date           : Juin 2025
 *************************************************************/

namespace CarnetMedical.CarnetMedical
{
    public partial class ModifierCarnet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Protection de la page grace a la session ici je refuse l'acces si la personne n'est pas connecter i.e na pas de session en cours
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {

                // Charger les informations médicales de l'utilisateur 
                int userId = Convert.ToInt32(Session["UserId"]);

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
                {
                    string query = "SELECT GroupeSanguin, Allergies, MaladiesChroniques, Medicaments FROM CarnetMedical WHERE UtilisateurId = @UserId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtGroupeSanguin.Text = reader["GroupeSanguin"].ToString();
                        txtAllergies.Text = reader["Allergies"].ToString();
                        txtMaladies.Text = reader["MaladiesChroniques"].ToString();
                        txtMedicaments.Text = reader["Medicaments"].ToString();
                    }

                    reader.Close();
                }
            }
        }
        // Fonction pour enregistrer les modifications du carnet médical
        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            string groupe = txtGroupeSanguin.Text.Trim();
            string allergies = txtAllergies.Text.Trim();
            string maladies = txtMaladies.Text.Trim();
            string medicaments = txtMedicaments.Text.Trim();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                // Vérifier si un carnet existe déjà
                string checkQuery = "SELECT COUNT(*) FROM CarnetMedical WHERE UtilisateurId = @UserId";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();
                int count = (int)checkCmd.ExecuteScalar();

                string query;

                // Si un carnet existe déjà, on sauvegarde dans l'historique avant de modifier
                if (count > 0)
                {

                    // Sauvegarde dans l'historique AVANT modification
                    string sauvegardeQuery = "INSERT INTO CarnetMedicalHistorique (UtilisateurId, GroupeSanguin, Allergies, MaladiesChroniques, Medicaments) " +
                                             "SELECT UtilisateurId, GroupeSanguin, Allergies, MaladiesChroniques, Medicaments FROM CarnetMedical WHERE UtilisateurId = @UserId";

                    SqlCommand sauvegardeCmd = new SqlCommand(sauvegardeQuery, conn);
                    sauvegardeCmd.Parameters.AddWithValue("@UserId", userId);
                    sauvegardeCmd.ExecuteNonQuery();

                    // Mise à jour
                    query = "UPDATE CarnetMedical SET GroupeSanguin=@Groupe, Allergies=@Allergies, MaladiesChroniques=@Maladies, Medicaments=@Medicaments, DateDerniereMiseAJour=GETDATE() WHERE UtilisateurId=@UserId";
                }
                else
                {
                    // Insertion
                    query = "INSERT INTO CarnetMedical (UtilisateurId, GroupeSanguin, Allergies, MaladiesChroniques, Medicaments) VALUES (@UserId, @Groupe, @Allergies, @Maladies, @Medicaments)";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Groupe", groupe);
                cmd.Parameters.AddWithValue("@Allergies", allergies);
                cmd.Parameters.AddWithValue("@Maladies", maladies);
                cmd.Parameters.AddWithValue("@Medicaments", medicaments);

                cmd.ExecuteNonQuery();
                lblMessage.Text = "✅ Modifications enregistrées avec succès.";
            }
        }
        // / Fonction pour supprimer le carnet médical
        protected void btnSupprimerCarnet_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            string connStr = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "DELETE FROM CarnetMedical WHERE UtilisateurId = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", userId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    lblSuppression.Text = "✅ Votre carnet médical a été supprimé avec succès.";
                    
                    txtGroupeSanguin.Text = "";
                    txtAllergies.Text = "";
                    txtMaladies.Text = "";
                    txtMedicaments.Text = "";
                }
                else
                {
                    lblSuppression.Text = "❌ Aucun carnet trouvé à supprimer.";
                }
            }
        }


    }
}