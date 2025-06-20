﻿using iTextSharp.text; // Pour gerer la generation du pdf
using iTextSharp.text.pdf;
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
 * Fichier        : MonCarnet.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère l'affichage du carnet médical de l'utilisateur connecté et permet l'export en PDF
 * Date           : Juin 2025
 *************************************************************/

namespace CarnetMedical.CarnetMedical
{
    public partial class MonCarnet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Protection de la page grace a la session ici je refuse l'acces si la personne n'est pas connecter i.e n'a pas de session en cours
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
            {
                // Charger les informations médicales de l'utilisateur
                ChargerDocuments();


                int userId = Convert.ToInt32(Session["UserId"]);

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
                {
                    string query = "SELECT GroupeSanguin, Allergies, MaladiesChroniques, Medicaments, DateDerniereMiseAJour FROM CarnetMedical WHERE UtilisateurId = @UserId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblGroupeSanguin.Text = reader["GroupeSanguin"].ToString();
                        lblAllergies.Text = reader["Allergies"].ToString();
                        lblMaladies.Text = reader["MaladiesChroniques"].ToString();
                        lblMedicaments.Text = reader["Medicaments"].ToString();
                        lblDerniereMaj.Text = Convert.ToDateTime(reader["DateDerniereMiseAJour"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        lblGroupeSanguin.Text = "Aucune information médicale enregistrée.";
                    }

                    reader.Close();
                }
            }
        }

        // Fonction pour charger les documents médicaux de l'utilisateur
        private void ChargerDocuments()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string query = "SELECT Id, NomFichier, Chemin, DateAjout FROM DocumentMedical WHERE PatientId = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", userId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvDocs.DataSource = dt;
                gvDocs.DataBind();
            }
        }


        // Fonction de generation du PDF
        protected void btnExportPDF_Click(object sender, EventArgs e)
        {

            int userId = Convert.ToInt32(Session["UserId"]);

            // Récupérer les données médicales
            string groupe = "", allergies = "", maladies = "", medicaments = "";
            DateTime? maj = null;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString))
            {
                string query = "SELECT GroupeSanguin, Allergies, MaladiesChroniques, Medicaments, DateDerniereMiseAJour FROM CarnetMedical WHERE UtilisateurId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    groupe = reader["GroupeSanguin"].ToString();
                    allergies = reader["Allergies"].ToString();
                    maladies = reader["MaladiesChroniques"].ToString();
                    medicaments = reader["Medicaments"].ToString();
                    maj = Convert.ToDateTime(reader["DateDerniereMiseAJour"]);
                }
                reader.Close();
            }

            // Création du document PDF
            Document pdfDoc = new Document(PageSize.A4);
            MemoryStream ms = new MemoryStream();
            PdfWriter.GetInstance(pdfDoc, ms);

            pdfDoc.Open();
            // Titre
            var titre = new Paragraph("Mon Carnet Médical By MEDICARD", FontFactory.GetFont("Arial", 18, Font.BOLD));
            titre.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(titre);
            pdfDoc.Add(new Paragraph("\n"));


            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Paragraph("🩸 Groupe sanguin : " + groupe));
            pdfDoc.Add(new Paragraph("🤧 Allergies : " + allergies));
            pdfDoc.Add(new Paragraph("🏥 Maladies chroniques : " + maladies));
            pdfDoc.Add(new Paragraph("💊 Médicaments : " + medicaments));
            pdfDoc.Add(new Paragraph("🕒 Dernière mise à jour : " + (maj.HasValue ? maj.Value.ToString("dd/MM/yyyy") : "Aucune")));
            pdfDoc.Close();



            // Téléchargement
            byte[] fileBytes = ms.ToArray();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=CarnetMedical.pdf");
            Response.BinaryWrite(fileBytes);
            Response.End();
        }

    }
}