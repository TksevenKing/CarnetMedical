using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace CarnetMedical
{
    public partial class ViewPatientCarnet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["Role"]?.ToString() != "Docteur")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                int docteurId = Convert.ToInt32(Session["UserId"]);
                if (Request.QueryString["pid"] != null && int.TryParse(Request.QueryString["pid"], out int patientId))
                {
                    if (EstAutoriseAcces(docteurId, patientId))
                    {
                        ChargerCarnet(patientId);
                        ChargerDocuments(patientId);
                    }else
                        lblError.Text = "⛔ Accès refusé. Ce patient ne vous a pas autorisé l’accès à son carnet.";
                }
                else
                {
                    lblError.Text = "ID patient invalide.";
                }
            }
            

        }

        private bool EstAutoriseAcces(int docteurId, int patientId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM PatientDocteur WHERE DocteurId = @DocteurId AND PatientId = @PatientId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DocteurId", docteurId);
                cmd.Parameters.AddWithValue("@PatientId", patientId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void ChargerCarnet(int patientId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"SELECT GroupeSanguin, Allergies, MaladiesChroniques, Medicaments, DateDerniereMiseAJour 
                                 FROM CarnetMedical WHERE UtilisateurId = @PatientId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);


                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblGroupeSanguin.Text = reader["GroupeSanguin"].ToString();
                    lblAllergies.Text = reader["Allergies"].ToString();
                    lblMaladies.Text = reader["MaladiesChroniques"].ToString();
                    lblMedicaments.Text = reader["Medicaments"].ToString();

                    DateTime maj = reader["DateDerniereMiseAJour"] != DBNull.Value
                        ? Convert.ToDateTime(reader["DateDerniereMiseAJour"])
                        : DateTime.MinValue;

                    lblDateMaj.Text = maj == DateTime.MinValue ? "Non renseignée" : maj.ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    lblError.Text = "Carnet non disponible pour ce patient.";
                }
            }
        }

        private void ChargerDocuments(int patientId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT Id, NomFichier, Chemin, DateAjout FROM DocumentMedical WHERE PatientId = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", patientId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvDocs.DataSource = dt;
                gvDocs.DataBind();
            }
        }



        //Exportation du PDF
        protected void btnExportPDF_Click(object sender, EventArgs e)
        {

                // Vérifie que les infos sont bien présentes
                if (string.IsNullOrWhiteSpace(lblGroupeSanguin.Text))
            {
                lblError.Text = "Impossible d’exporter : données manquantes.";
                return;
            }

            // Création du document
            Document doc = new Document(PageSize.A4);
            MemoryStream stream = new MemoryStream();
            PdfWriter.GetInstance(doc, stream).CloseStream = false;
            doc.Open();

            // Titre
            var titre = new Paragraph("Carnet Médical du Patient", FontFactory.GetFont("Arial", 18, Font.BOLD));
            titre.Alignment = Element.ALIGN_CENTER;
            doc.Add(titre);
            doc.Add(new Paragraph("\n"));

            // Infos médicales
            doc.Add(new Paragraph("🩸 Groupe sanguin : " + lblGroupeSanguin.Text));
            doc.Add(new Paragraph("🤧 Allergies : " + lblAllergies.Text));
            doc.Add(new Paragraph("🏥 Maladies chroniques : " + lblMaladies.Text));
            doc.Add(new Paragraph("💊 Médicaments : " + lblMedicaments.Text));
            doc.Add(new Paragraph("📅 Dernière mise à jour : " + lblDateMaj.Text));

            doc.Close();

            // Envoi du fichier PDF au navigateur
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=CarnetMedical.pdf");
            Response.OutputStream.Write(stream.GetBuffer(), 0, stream.GetBuffer().Length);
            Response.Flush();
            Response.End();
        }
    }
}
