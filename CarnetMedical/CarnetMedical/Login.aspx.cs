using Org.BouncyCastle.Crypto.Macs;
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


/**************************************************************
 * Fichier        : Login.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère l'authentification de l'utilisateur et le redirige vers son dashboard en fonction du Role (Utilisateur, Docteur, admin)
 * Date           : Juin 2025
 *************************************************************/

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
            string motDePasse = HashPassword(txtMotDePasse.Text.Trim()); // Hashage du MDP avant la comparaison

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(motDePasse))
            {
                lblMessage.Text = "Veuillez saisir votre email et votre mot de passe.";
                return;                     
            }

            /* 1 seule requête UNION => Id + Rôle            *
             * ───────────────────────────────────────────── */
            const string sql = @"
                SELECT Id, Role FROM Utilisateur 
                WHERE Email = @Email AND MotDePasse = @Pwd
                UNION
                SELECT Id, 'Docteur' AS Role FROM Docteur
                WHERE Email = @Email AND MotDePasse = @Pwd";

            using (SqlConnection cn = new SqlConnection(
                       ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Pwd", motDePasse);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())          // identifiants trouvés
                    {
                        int id = rd.GetInt32(0);
                        string role = rd.GetString(1);   // 'Admin', 'Utilisateur' ou 'Docteur'

                        /* ---------- 3. Stockage session ---------- */
                        Session["UserId"] = id;
                        Session["Role"] = role;

                        /* ---------- 4. Redirection ---------- */
                        switch (role)
                        {
                            case "Admin":
                                Response.Redirect("AdminUtilisateur.aspx");
                                break;
                            case "Docteur":
                                Response.Redirect("MyPatients.aspx");   // page d’accueil docteur
                                break;
                            default:                                   // Utilisateur
                                Response.Redirect("Dashboard.aspx");
                                break;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Email ou mot de passe incorrect.";
                    }
                }
            }
        }
        protected void btnRegister1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

    }
}