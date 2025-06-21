using CarnetMedical.CarnetMedical;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography; // Pour le hashage du MDP
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
    *Fichier        : Register.apsx.cs
    * Rôle           : Gere l'inscription des utilisateurs sauf pour l'admin dont on insere le compte directement dans la base de donnees dans MSSQL en specifiant le Role = "admin"
    * Auteur         : Oumar Cissé
  
 */

namespace CarnetMedical.CarnetMedical
{
    public partial class Register : System.Web.UI.Page
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
            string motDePasse = HashPassword(txtMotDePasse.Text); // je hash le MDP avant de le stocker

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(motDePasse))
            {
                lblMessage.Text = "Veuillez remplir tous les champs!";
                return;                     // stoppe la méthode ici
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string query = "INSERT INTO Utilisateur (Nom, Email, MotDePasse) VALUES (@Nom, @Email, @MotDePasse)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nom", nom);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MotDePasse", motDePasse);

                /*************************************************************************************************************************************************************************
                 *Note: Le Role par défaut est 'Utilisateur' car on ne le spécifie pas ici, l'admin est inséré manuellement dans la base de données au premier lancement de l'application*
                 *************************************************************************************************************************************************************************/
                //string queryAdmin = "INSERT INTO Utilisateur (Nom, Email, MotDePasse, Role) VALUES (@Nom, @Email, @MotDePasse, @Role)";
                //SqlCommand cmdAdmin = new SqlCommand(queryAdmin, conn);
                //cmdAdmin.Parameters.AddWithValue("@Nom", "admin");
                //cmdAdmin.Parameters.AddWithValue("@Email", "admin@gmail.com");
                //cmdAdmin.Parameters.AddWithValue("@MotDePasse", "123Admin");
                //cmdAdmin.Parameters.AddWithValue("@Role", "Admin");

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //cmdAdmin.ExecuteNonQuery(); // Insertion de l'admin


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