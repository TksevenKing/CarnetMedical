using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetMedical.CarnetMedical
{
    public partial class RegisterDoctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Fonction de hashage du MDP
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }


        // Fonction pour l'inscription
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string email = txtEmail.Text.Trim();
            string specialite = txtSpecialite.Text.Trim();
            string motDePasse = HashPassword(txtMotDePasse.Text); // je hash le MDP avant de le stocker


            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(motDePasse) || string.IsNullOrEmpty(specialite))
            {
                lblMessage.Text = "Veuillez remplir tous les champs!";
                return;                     // stoppe la méthode ici
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string query = "INSERT INTO Docteur (Nom, Email,Specialite , MotDePasse) VALUES (@Nom, @Email, @Specialite, @MotDePasse)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nom", nom);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Specialite", specialite);
                cmd.Parameters.AddWithValue("@MotDePasse", motDePasse);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //lblMessage.Text = "Inscription réussie. <a href='Login.aspx' class='btn btn-primary'>Se connecter</a>";

                    Response.Redirect("Login.aspx");
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = "Erreur : " + ex.Message;
                }
            }
        }
    }
}