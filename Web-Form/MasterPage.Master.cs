using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Form
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!(Page is Login || Page is Default || Page is AltaUsuario || Page is Contacto))
            //{
            //    if (!(Seguridad.SesionActiva(Session["Persona"])))
            //        Response.Redirect("Login.aspx", false);
            //}
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaUsuario.aspx");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //protected void btnSalir_Click(object sender, EventArgs e)
        //{
        //    Session.Clear();
        //    Response.Redirect("Default.aspx", false);
        //}
    }
}