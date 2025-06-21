using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**************************************************************
 * Fichier        : AdminUtilisateur.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère l'affichage des Utilisateurs et Docteurs, ainsi que leur suppression avec leurs données associées
 * Date           : Juin 2025
 *************************************************************/


namespace CarnetMedical.CarnetMedical
{
    public partial class AdminUtilisateur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Vérifier que l'utilisateur est connecté et a le rôle "Admin"
            if (Session["Role"]?.ToString() != "Admin") Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {

                    ChargerUtilisateurs();
                    ChargerDocteurs();
                
            }
        }


        // GridView d'affichage et de suppression des utilisateurs
        protected void gvUtilisateurs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Supprimer")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32(gvUtilisateurs.DataKeys[index].Value);

                string cs = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    // Supprimer les documents
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM DocumentMedical WHERE PatientId = @Id", conn);
                    cmd1.Parameters.AddWithValue("@Id", userId);
                    cmd1.ExecuteNonQuery();

                    // Supprimer les liens avec docteurs
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM PatientDocteur WHERE PatientId = @Id", conn);
                    cmd2.Parameters.AddWithValue("@Id", userId);
                    cmd2.ExecuteNonQuery();

                    // Supprimer le carnet
                    SqlCommand cmd3 = new SqlCommand("DELETE FROM CarnetMedical WHERE UtilisateurId = @Id", conn);
                    cmd3.Parameters.AddWithValue("@Id", userId);
                    cmd3.ExecuteNonQuery();

                    // Supprimer l'utilisateur
                    SqlCommand cmd4 = new SqlCommand("DELETE FROM Utilisateur WHERE Id = @Id", conn);
                    cmd4.Parameters.AddWithValue("@Id", userId);
                    int affected = cmd4.ExecuteNonQuery();

                    lblInfo.Text = affected > 0
                        ? "✅ Utilisateur supprimé avec succès."
                        : "⚠️ Suppression échouée.";

                    conn.Close();
                }

                ChargerUtilisateurs(); // Recharge la liste après suppression
            }
        }

        private void ChargerUtilisateurs()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string query = "SELECT Id, Nom, Email, Role FROM Utilisateur";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvUtilisateurs.DataSource = dt;
                gvUtilisateurs.DataBind();
            }
        }

        // GridView d'affichage et de suppression de Docteur
        protected void gvDocteurs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Supprimer")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int doctorId = Convert.ToInt32(gvDocteurs.DataKeys[index].Value);

                string cs = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    // Supprimer les liens Patient/Docteur
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM PatientDocteur WHERE DocteurId = @Id", conn);
                    cmd1.Parameters.AddWithValue("@Id", doctorId);
                    cmd1.ExecuteNonQuery();

                    // Supprimer le docteur
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM Docteur WHERE Id = @Id", conn);
                    cmd2.Parameters.AddWithValue("@Id", doctorId);
                    int affected = cmd2.ExecuteNonQuery();

                    conn.Close();
                    lblInfoDoc.Text = affected > 0
                        ? "✅ Docteur supprimé avec succès."
                        : "⚠️ Suppression échouée.";

                    ChargerDocteurs(); // Rechargement de la liste
                }
            }
        }


        private void ChargerDocteurs()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string query = "SELECT Id, Nom, Email, Specialite, Role FROM Docteur";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvDocteurs.DataSource = dt;
                gvDocteurs.DataBind();
            }
        }





    }
}