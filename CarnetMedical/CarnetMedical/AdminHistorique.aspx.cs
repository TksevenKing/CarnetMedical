using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetMedical.CarnetMedical
{
    public partial class AdminHistorique : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"]?.ToString() != "Admin") Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
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