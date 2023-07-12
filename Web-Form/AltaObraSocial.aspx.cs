using Dominio;
using Helpers;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Form
{
    public partial class AltaObraSocial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Seguridad.EsAdmin(Session["Persona"]) || Seguridad.EsEmpleado(Session["Persona"]))
            {
                ObraSocialNegocio obraSocialNegocio = new ObraSocialNegocio();
                ObraSocial nuevaObraSocial = new ObraSocial();
                nuevaObraSocial.Nombre = txtNombre.Text;
                if (!obraSocialNegocio.AgregarObraSocial(nuevaObraSocial))
                {
                    Response.Redirect("Error.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}