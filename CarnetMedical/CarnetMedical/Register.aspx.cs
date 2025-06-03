using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography; // Pour le hashage du MDP
using System.Text;
//using System.Net.Mail; // Pour l'envoi du mail de bienvenue  a ajouter apres
//using System.Net;



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

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string query = "INSERT INTO Utilisateur (Nom, Email, MotDePasse) VALUES (@Nom, @Email, @MotDePasse)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nom", nom);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MotDePasse", motDePasse);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Inscription réussie. <a href='Login.aspx'>Se connecter</a>";
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = "Erreur : " + ex.Message;
                }
            }
        }

        // Fonciton d'envoi du mail de bienvenue
        //private void EnvoyerEmailBienvenue(string email, string nom)
        //{
        //    MailMessage message = new MailMessage();
        //    message.To.Add(email);
        //    message.Subject = "Bienvenue sur Carnet Médical !";
        //    message.Body = $"Bonjour {nom},\n\nMerci de vous être inscrit sur notre plateforme.\n\nVotre carnet médical est maintenant accessible en ligne.\n\nCordialement,\nL'équipe Médicale";
        //    message.IsBodyHtml = false;
        //    message.From = new MailAddress("oumarciss300@gmail.com");

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Send(message);
        //}


    }
}