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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Fonction de Hashage du MDP
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }


        // Fonction de connexion et de creation de session pour proteger les autres pages
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string motDePasse = HashPassword(txtMotDePasse.Text); // Hashage du MDP avant la comparaison

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string query = "SELECT Id FROM Utilisateur WHERE Email = @Email AND MotDePasse = @MotDePasse";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MotDePasse", motDePasse); 

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    // Connexion réussie
                    Session["UserId"] = result.ToString();

                    // Récupérer le rôle
                    string roleQuery = "SELECT Role FROM Utilisateur WHERE Id = @Id";
                    SqlCommand roleCmd = new SqlCommand(roleQuery, conn);
                    roleCmd.Parameters.AddWithValue("@Id", result);
                    string role = roleCmd.ExecuteScalar()?.ToString();
                    Session["Role"] = role;

                    // Redirection selon le rôle
                    if (role == "Admin")
                        Response.Redirect("AdminDashboard.aspx");
                    else
                        Response.Redirect("Dashboard.aspx");

                }
                else
                {
                    lblMessage.Text = "Email ou mot de passe incorrect.";
                }
            }
        }
        protected void btnRegister1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

    }
}