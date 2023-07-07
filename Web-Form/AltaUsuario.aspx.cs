using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using DataBase;
using Helpers;

namespace Web_Form
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        public int TipoUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Seguridad.EsEmpleado(Session["Persona"]) || Seguridad.EsAdmin(Session["Persona"]))
                {
                    PermisoNegocio permisoNegocio = new PermisoNegocio();
                    ddlTipoUsuario.DataSource = permisoNegocio.ListarPermisos();
                    ddlTipoUsuario.DataTextField = "Descripcion";
                    ddlTipoUsuario.DataValueField = "Id";
                    ddlTipoUsuario.DataBind();
                }
            }
            if (Seguridad.SesionActiva(Session["Persona"]))
                TipoUser = int.Parse(ddlTipoUsuario.SelectedItem.Value);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(Seguridad.SesionActiva(Session["Persona"])) || TipoUser == 4)
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
                    if (!(Seguridad.SesionActiva(Session["Persona"])))
                        nuevoUsuario.Permiso.Id = 4;
                    else
                        nuevoUsuario.Permiso.Id = ddlTipoUsuario.SelectedIndex + 1;
                    nuevoUsuario.FechaNacimiento = DateTime.Parse(txbFechaNacimiento.Text);
                    if (chkObraSocial.Checked)
                        nuevoUsuario.ObraSocial.IdObraSocial = ddlObraSocial.SelectedIndex + 1;
                    pacienteNegocio.AgregarPaciente(nuevoUsuario);
                }
                if (TipoUser == 3)
                {

                }
                if (TipoUser == 2 || TipoUser == 1)
                {
                    EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                    Empleado nuevoUsuario = new Empleado();
                    nuevoUsuario.Nombre = txbNombre.Text;
                    nuevoUsuario.Apellido = txbApellido.Text;
                    nuevoUsuario.Dni = txbDNI.Text;
                    nuevoUsuario.Credencial.NombreUsuario = txbMail.Text;
                    nuevoUsuario.DatosContacto.Email = txbMail.Text;
                    nuevoUsuario.DatosContacto.Celular = txbCelu.Text;
                    nuevoUsuario.Credencial.Password = txbPass.Text;
                    nuevoUsuario.Permiso.Id = ddlTipoUsuario.SelectedIndex + 1;
                    nuevoUsuario.FechaNacimiento = DateTime.Parse(txbFechaNacimiento.Text);
                    empleadoNegocio.AgregarEmpleado(nuevoUsuario);
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void ddlTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoUser == 4)
            {
                ObraSocialNegocio obraSocialNegocio = new ObraSocialNegocio();
                ddlObraSocial.DataSource = obraSocialNegocio.ListarObraSocial();
                ddlObraSocial.DataTextField = "Nombre";
                ddlObraSocial.DataValueField = "IdObraSocial";
                ddlObraSocial.DataBind();
            }
            if (TipoUser == 3)
            {

            }

        }

        protected void ddlObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chkObraSocial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkObraSocial.Checked)
            {
                ObraSocialNegocio obraSocialNegocio = new ObraSocialNegocio();
                ddlObraSocial.DataSource = obraSocialNegocio.ListarObraSocial();
                ddlObraSocial.DataTextField = "Nombre";
                ddlObraSocial.DataValueField = "IdObraSocial";
                ddlObraSocial.DataBind();
            }
        }

    }
}