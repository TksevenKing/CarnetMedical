using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/**************************************************************
 * Fichier        : MesDocuments.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère l'affichage et l'importation de documents médicaux pour l'utilisateur connecté
 * Date           : Juin 2025
 *************************************************************/

namespace CarnetMedical.CarnetMedical
{
    public partial class MesDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            ChargerDocuments(); // méthode pour afficher les documents

        }

        // Fonction pour importer un document médical
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!fileUpload.HasFile || Path.GetExtension(fileUpload.FileName).ToLower() != ".pdf")
            {
                lblMessage.Text = "Veuillez sélectionner un fichier PDF valide.";
                return;
            }

            int patientId = Convert.ToInt32(Session["UserId"]);
            string fileName = Path.GetFileName(fileUpload.FileName);
            string folder = Server.MapPath("CarnetMedical/Documents/");
            Directory.CreateDirectory(folder); // s'assure que le dossier existe

            string filePath = folder + fileName;
            fileUpload.SaveAs(filePath);

            string virtualPath = "CarnetMedical/Documents/" + fileName;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string insert = "INSERT INTO DocumentMedical (NomFichier, Chemin, PatientId) VALUES (@Nom, @Chemin, @PatientId)";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@Nom", fileName);
                cmd.Parameters.AddWithValue("@Chemin", virtualPath);
                cmd.Parameters.AddWithValue("@PatientId", patientId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Document importé avec succès.";
            ChargerDocuments(); // méthode pour afficher les documents
        }


        // Fonction pour charger les documents médicaux de l'utilisateur
        private void ChargerDocuments()
        {
            int patientId = Convert.ToInt32(Session["UserId"]);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string query = "SELECT * FROM DocumentMedical WHERE PatientId = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", patientId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvDocuments.DataSource = dt;
                gvDocuments.DataBind();
            }
        }

    }
}