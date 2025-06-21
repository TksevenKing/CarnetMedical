using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**************************************************************
 * Fichier        : PatientDocuments.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère l'affichage des documents médicaux d'un patient pour un docteur autorisé
 * Date           : Juin 2025
 *************************************************************/

namespace CarnetMedical.CarnetMedical
{
    public partial class PatientDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* 1. Vérifier que l’utilisateur est un docteur connecté */
            if (Session["UserId"] == null || Session["Role"]?.ToString() != "Docteur")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            /* 2. Vérifier que l’ID patient est valide dans la query‑string */
            if (Request.QueryString["pid"] == null ||
                !int.TryParse(Request.QueryString["pid"], out int patientId))
            {
                lblInfo.Text = "ID de patient invalide.";
                return;
            }

            int docteurId = Convert.ToInt32(Session["UserId"]);

            /* 3. Contrôle d’accès : le patient a‑t‑il autorisé ce docteur ? */
            if (!EstAutorise(docteurId, patientId))
            {
                lblInfo.Text = "⛔ Accès refusé : ce patient ne vous a pas autorisé l’accès à ses documents.";
                return;
            }

            /* 4. Charger et afficher la liste des documents */
            if (!IsPostBack)
                ChargerDocuments(patientId);
        }

        /**************************************************************
         * Vérifie si le docteur a l'autorisation d'accéder aux documents du patient
         * docId L'ID du docteur
         * patientId L'ID du patient
         * Retourne true si autorisé, false sinon
         *************************************************************/
        private bool EstAutorise(int docId, int patientId)
        {
            string cs = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                string sql = "SELECT COUNT(*) FROM PatientDocteur WHERE DocteurId=@Doc AND PatientId=@Pat";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Doc", docId);
                cmd.Parameters.AddWithValue("@Pat", patientId);

                cn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        /**************************************************************
         * Charge les documents médicaux du patient dans le GridView
         * patientId L'ID du patient dont on charge les documents
         *************************************************************/
        private void ChargerDocuments(int patientId)
        {
            string cs = ConfigurationManager.ConnectionStrings["CarnetMedConnectionName"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                string sql = "SELECT Id, NomFichier, Chemin, DateAjout FROM DocumentMedical WHERE PatientId=@Pat";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Pat", patientId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvDocs.DataSource = dt;
                gvDocs.DataBind();

                if (dt.Rows.Count == 0)
                    lblInfo.Text = "Ce patient n’a pas encore partagé de documents.";
            }
        }


    }
}