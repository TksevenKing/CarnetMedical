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
    public partial class AdminUtilisateur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"]?.ToString() != "Admin") Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
                {
                    string query = "SELECT Id, Nom, Email, Role FROM Utilisateur";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    gvUsers.DataSource = cmd.ExecuteReader();
                    gvUsers.DataBind();
                }
            }
        }

    }
}