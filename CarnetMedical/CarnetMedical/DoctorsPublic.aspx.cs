using Microsoft.Ajax.Utilities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


/**************************************************************
 * Fichier        : DoctorsPublic.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar Cissé
 * Rôle           : Gère l'affichage des docteurs disponibles pour l'utilisateur connecté
 * Date           : Juin 2025
 *************************************************************/

namespace CarnetMedical
{
    public partial class DoctorsPublic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page uniquement accessible aux utilisateurs (patients) connectés
            if (Session["UserId"] == null || Session["Role"]?.ToString() != "Utilisateur")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
                ChargerListeDocteurs();
        }

        // Charge la liste des docteurs disponibles pour l'utilisateur connecté
        /*   Cette méthode récupère les docteurs depuis la base de données et vérifie s'ils sont déjà ajoutés par le patient.
         * Elle remplit un GridView avec les informations des docteurs.
         * Si aucun docteur n'est disponible, un message d'information est affiché.
         */
        private void ChargerListeDocteurs()
        {
            int patientId = Convert.ToInt32(Session["UserId"]);
            string connStr = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Requête pour récupérer les docteurs et vérifier s'ils sont déjà ajoutés par le patient
                string query = @"
                    SELECT d.Id, d.Nom, d.Email, d.Specialite,
                    CASE WHEN pd.Id IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS EstAjoute
                    FROM Docteur d
                    LEFT JOIN PatientDocteur pd ON pd.DocteurId = d.Id AND pd.PatientId = @PatientId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvDoctors.DataSource = dt;
                gvDoctors.DataBind();

                if (dt.Rows.Count == 0)
                    lblInfo.Text = "Aucun docteur n'est disponible pour le moment.";
            }
        }

        // Gestion de l'événement de commande du GridView pour ajouter un docteur
        protected void gvDoctors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ajouter")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int doctorId = Convert.ToInt32(gvDoctors.DataKeys[index].Value);
                int patientId = Convert.ToInt32(Session["UserId"]);

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
                {
                    // Vérifie si déjà lié
                    string checkQuery = "SELECT COUNT(*) FROM PatientDocteur WHERE PatientId = @PatientId AND DocteurId = @DocteurId";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@PatientId", patientId);
                    checkCmd.Parameters.AddWithValue("@DocteurId", doctorId);

                    conn.Open();
                    int exists = (int)checkCmd.ExecuteScalar();

                    // Si pas déjà lié, on ajoute la relation
                    if (exists == 0)
                    {
                        string insertQuery = "INSERT INTO PatientDocteur (PatientId, DocteurId) VALUES (@PatientId, @DocteurId)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@PatientId", patientId);
                        insertCmd.Parameters.AddWithValue("@DocteurId", doctorId);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                ChargerListeDocteurs(); // Refresh après ajout
            }
        }
    }
}
