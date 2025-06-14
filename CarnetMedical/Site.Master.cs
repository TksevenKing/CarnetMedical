using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarnetMedical
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // personnalisation de la page et du sidebar en fonction du role de l'utilisateur
            if (!IsPostBack)
            {
                string role = Session["Role"]?.ToString();

                if (role == "Utilisateur")
                {
                    phPatient.Visible = true;
                }
                else if (role == "Docteur")
                {
                    phDocteur.Visible = true;
                }
                else if (role == "Admin")
                {
                    phAdmin.Visible = true;
                }
            }


            // Affichage du nom de l'utilisateur dont la session est en cours
            int userId = Convert.ToInt32(Session["UserId"]);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string role = Session["Role"]?.ToString();
                if (role == "Docteur")
                {
                    string queryDoc = "SELECT Nom FROM Docteur WHERE Id = @Id";
                    SqlCommand cmdDoc = new SqlCommand(queryDoc, conn);
                    cmdDoc.Parameters.AddWithValue("@Id", userId);
                    conn.Open();
                    object nomDoc = cmdDoc.ExecuteScalar();
                    if (nomDoc != null)
                    {
                        lblNom.Text = "Dr "+ nomDoc.ToString() ;
                    }
                }
                else
                {
                    string query = "SELECT Nom FROM Utilisateur WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", userId);

                    conn.Open();
                    object nom = cmd.ExecuteScalar();

                    if (nom != null)
                    {
                        lblNom.Text =  nom.ToString();
                    }
                }

            }

        }
    }
}