using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace Web_Form
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            PersonaNegocio personaNegocio = new PersonaNegocio();
            try
            {
                persona.Credencial.NombreUsuario = txbEmail.Text;
                persona.Credencial.Password = txbPass.Text;
                CredencialNegocio credencialNegocio = new CredencialNegocio();
                persona.Credencial.IdCredencial = credencialNegocio.BuscarIdCredencial(persona.Credencial);
                if (persona.Credencial.IdCredencial == 0)
                {
                    Session.Add("Error", "Usuario o contraseña invalido.");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    if (!(personaNegocio.Login(persona)))
                    {
                        Session.Add("Error", "Usuario o contraseña invalido.");
                        Response.Redirect("Error.aspx", false);
                    }
                    else
                    {
                        Session.Add("Persona", persona);
                        Response.Redirect("Default.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }


    }
}