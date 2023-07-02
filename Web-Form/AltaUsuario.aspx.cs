using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using DataBase;

namespace Web_Form
{
    public partial class AltaUsuario1 : System.Web.UI.Page
    {
        //public Persona UsuarioActivo = new Persona();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PermisoNegocio permisoNegocio = new PermisoNegocio();
                ddlTipoUsuario.DataSource = permisoNegocio.ListarPermisos();
                ddlTipoUsuario.DataTextField = "Descripcion";
                ddlTipoUsuario.DataValueField = "Id";
                ddlTipoUsuario.DataBind();

                

            }

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                Paciente nuevoUsuario = new Paciente();
                nuevoUsuario.Nombre = txbNombre.Text;
                nuevoUsuario.Apellido = txbApellido.Text;
                nuevoUsuario.Dni = txbDNI.Text;
                nuevoUsuario.Credencial.NombreUsuario = txbMail.Text;
                nuevoUsuario.DatosContacto.Email = txbMail.Text;
                nuevoUsuario.DatosContacto.Celular = txbCelu.Text;
                nuevoUsuario.Credencial.Password = txbPass.Text;
                nuevoUsuario.Permiso.Id = ddlTipoUsuario.SelectedIndex+1;
                nuevoUsuario.FechaNacimiento = DateTime.Parse(txbFechaNacimiento.Text);
                pacienteNegocio.AgregarPaciente(nuevoUsuario);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
    }
}