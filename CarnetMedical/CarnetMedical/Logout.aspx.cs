using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/**************************************************************
 * Fichier        : Logout.aspx.cs
 * Projet         : Carnet Médical Personnel (MediCard)
 * Auteur         : Oumar
 * Rôle           : Gère la deconnexion de l'utilisateur en supprimant la session et en le redirigeant vers la page de connexion
 * Date           : Juin 2025
 *************************************************************/


namespace CarnetMedical.CarnetMedical
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();        // Supprime toutes les données de session
            Session.Abandon();      // Termine la session
            Response.Redirect("Login.aspx");  // Redirection
        }
    }
}