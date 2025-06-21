using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**************************************************************
 * Fichier        : Login.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère le dashboard de l'utilisateur connecté en affichant son nom
 * Date           : Juin 2025
 *************************************************************/

namespace CarnetMedical.CarnetMedical
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                // Protection de la page grace a la session ici je refuse l'acces si la personne n'est pas connecter i.e na pas de session en cours
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    int userId = Convert.ToInt32(Session["UserId"]);

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
                    {
                        string query = "SELECT Nom FROM Utilisateur WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", userId);

                        conn.Open();
                        object nom = cmd.ExecuteScalar();

                        if (nom != null)
                        {
                            lblNom.Text = "Bonjour, " + nom.ToString() + " !";
                        }
                    }
                }
            }
        }

    }
}
