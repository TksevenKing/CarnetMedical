using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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