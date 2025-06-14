using Microsoft.Ajax.Utilities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CarnetMedical
{
    public partial class DoctorsPublic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Role"]?.ToString() != "Utilisateur")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
                ChargerListeDocteurs();
        }

        private void ChargerListeDocteurs()
        {
            int patientId = Convert.ToInt32(Session["UserId"]);
            string connStr = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
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
