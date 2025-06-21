using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


/**************************************************************
 * Fichier        : MyPatients.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar Cissé
 * Rôle           : Gère l'affichage des patients qui ont autorisés le docteur connecté  à consulter leur carnet médical
 * Date           : Juin 2025
 *************************************************************/

namespace CarnetMedical
{
    public partial class MyPatients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Role"]?.ToString() != "Docteur")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
                ChargerMesPatients();
        }

        // Charge la liste des patients qui ont autorisés le docteur connecté à consulter leur carnet médical
        private void ChargerMesPatients()
        {
            int docteurId = Convert.ToInt32(Session["UserId"]);
            string connStr = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Requête pour récupérer les patients qui ont autorisés le docteur connecté  à consulter leur carnet médical
                string query = @"
                    SELECT u.Id, u.Nom, u.Email
                    FROM Utilisateur u
                    JOIN PatientDocteur pd ON u.Id = pd.PatientId
                    WHERE pd.DocteurId = @DocteurId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DocteurId", docteurId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvPatients.DataSource = dt;
                gvPatients.DataBind();

                if (dt.Rows.Count == 0)
                    lblInfo.Text = "Aucun patient ne vous a encore autorisé l'accès.";
            }
        }
        // Gestion de la commande du GridView pour voir le carnet médical d'un patient
        protected void gvPatients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Voir")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int patientId = Convert.ToInt32(gvPatients.DataKeys[index].Value);

                Response.Redirect("ViewPatientCarnet.aspx?pid=" + patientId);
            }
        }
    }
}
