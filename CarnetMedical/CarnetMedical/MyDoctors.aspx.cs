using CarnetMedical.CarnetMedical;
using Microsoft.Ajax.Utilities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CarnetMedical
{
    public partial class MyDoctors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Role"]?.ToString() != "Utilisateur")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                ChargerMesDocteurs();
            }
        }

        private void ChargerMesDocteurs()
        {
            int patientId = Convert.ToInt32(Session["UserId"]);
            string connStr = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT d.Id AS DocteurId, d.Nom, d.Email, d.Specialite
                    FROM Docteur d
                    JOIN PatientDocteur pd ON d.Id = pd.DocteurId
                    WHERE pd.PatientId = @PatientId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvMyDoctors.DataSource = dt;
                gvMyDoctors.DataBind();

                if (dt.Rows.Count == 0)
                    lblInfo.Text = "Vous n'avez autorisé aucun docteur pour le moment.";
            }
        }

        protected void gvMyDoctors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Supprimer")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int docteurId = Convert.ToInt32(gvMyDoctors.DataKeys[index].Value);
                int patientId = Convert.ToInt32(Session["UserId"]);

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
                {
                    string deleteQuery = "DELETE FROM PatientDocteur WHERE PatientId = @PatientId AND DocteurId = @DocteurId";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@PatientId", patientId);
                    cmd.Parameters.AddWithValue("@DocteurId", docteurId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                ChargerMesDocteurs(); // Refresh
            }
        }

        protected void gvMyDoctors_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Attributes["style"] = "width: 100px;";
        }
    }
}
