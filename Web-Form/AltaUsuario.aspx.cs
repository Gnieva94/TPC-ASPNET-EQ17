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
                //if (Seguridad.EsEmpleado(Session["Persona"]) || Seguridad.EsAdmin(Session["Persona"]))
                //{
                PermisoNegocio permisoNegocio = new PermisoNegocio();
                ddlTipoUsuario.DataSource = permisoNegocio.ListarPermisos();
                ddlTipoUsuario.DataTextField = "Descripcion";
                ddlTipoUsuario.DataValueField = "Id";
                ddlTipoUsuario.DataBind();
                List<Horario> listaHorarios = new List<Horario>();
                Session.Add("ListaHorarios", listaHorarios);
                //}
            }
            //if (Seguridad.SesionActiva(Session["Persona"]))
            TipoUser = int.Parse(ddlTipoUsuario.SelectedItem.Value);  
        }
        private void cargarPersona(Persona nuevoUsuario)
        {
            try
            {
                nuevoUsuario.Nombre = txbNombre.Text;
                nuevoUsuario.Apellido = txbApellido.Text;
                nuevoUsuario.Dni = txbDNI.Text;
                nuevoUsuario.FechaNacimiento = DateTime.Parse(txbFechaNacimiento.Text);
                nuevoUsuario.Nacionalidad = ddlNacionalidad.SelectedValue;
                nuevoUsuario.DatosContacto.Email = txbMail.Text;
                nuevoUsuario.DatosContacto.Celular = txbCelu.Text;
                nuevoUsuario.DatosContacto.Direccion = txbDireccion.Text;
                nuevoUsuario.DatosContacto.Localidad = txbLocalidad.Text;
                nuevoUsuario.DatosContacto.Provincia = txbProvincia.Text;
                nuevoUsuario.DatosContacto.CodigoPostal = txbCodigoPostal.Text;
                nuevoUsuario.Credencial.NombreUsuario = txbMail.Text;
                nuevoUsuario.Credencial.Password = txbPass.Text;
            }
            catch (Exception ex)
            {
                Session.Add("Error",ex.ToString());
            }
        }

        private void cargarHorario(Horario horario)
        {
            try
            {
                horario.Id = ((List<Horario>)Session["ListaHorarios"]).Count + 1;
                horario.Especialidad.Id = ddlEspecialidad.SelectedIndex + 1;
                horario.Especialidad.Nombre = ddlEspecialidad.SelectedValue;
                horario.IdDia = int.Parse(ddlDia.SelectedValue);
                switch (horario.IdDia)
                {
                    case 1:
                        horario.Dia = "Lunes";
                        break;
                    case 2:
                        horario.Dia = "Martes";
                        break;
                    case 3:
                        horario.Dia = "Miercoles";
                        break;
                    case 4:
                        horario.Dia = "Jueves";
                        break;
                    case 5:
                        horario.Dia = "Viernes";
                        break;
                    case 6:
                        horario.Dia = "Sabado";
                        break;
                    case 7:
                        horario.Dia = "Domingo";
                        break;
                    default:
                        break;
                }
                horario.HorarioInicio = int.Parse(ddlHorarioInicio.SelectedValue);
                horario.HorarioFin = int.Parse(ddlHorarioFin.SelectedValue);
            }
            catch (Exception ex)
            {
                Session.Add("Error",ex.ToString());
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!(Seguridad.SesionActiva(Session["Persona"])) || TipoUser == 4)
                if (TipoUser==4)
                {
                    PacienteNegocio pacienteNegocio = new PacienteNegocio();
                    Paciente nuevoUsuario = new Paciente();
                    cargarPersona(nuevoUsuario);
                    nuevoUsuario.Permiso.Id = 4;
                    if (chkObraSocial.Checked)
                        nuevoUsuario.ObraSocial.IdObraSocial = ddlObraSocial.SelectedIndex + 1;
                    nuevoUsuario.NumeroAfiliado = int.Parse(txbNumeroAfiliado.Text);
                    pacienteNegocio.AgregarPaciente(nuevoUsuario);
                }
                if (TipoUser == 3)
                {
                    ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
                    Profesional nuevoUsuario = new Profesional();
                    cargarPersona(nuevoUsuario);
                    nuevoUsuario.Permiso.Id = 3;
                    nuevoUsuario.Matricula = txbMatricula.Text;
                    HorarioNegocio horarioNegocio = new HorarioNegocio();

                    nuevoUsuario.Horarios = (List<Horario>)Session["ListaHorarios"];
                    nuevoUsuario.IdProfesional = profesionalNegocio.AgregarProfesional(nuevoUsuario);
                    foreach (Horario h in nuevoUsuario.Horarios)
                    {
                        horarioNegocio.AgregarHorarios(h, nuevoUsuario.IdProfesional);
                    }
                }
                if (TipoUser == 2 || TipoUser == 1)
                {
                    EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                    Empleado nuevoUsuario = new Empleado();
                    cargarPersona(nuevoUsuario);
                    nuevoUsuario.Permiso.Id = ddlTipoUsuario.SelectedIndex + 1;
                    empleadoNegocio.AgregarEmpleado(nuevoUsuario);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void ddlTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoUser == 4)
            {
                ObraSocialNegocio obraSocialNegocio = new ObraSocialNegocio();
                ddlObraSocial.DataSource = obraSocialNegocio.ListaObrasSociales();
                ddlObraSocial.DataTextField = "Nombre";
                ddlObraSocial.DataValueField = "IdObraSocial";
                ddlObraSocial.DataBind();
            }
            if (TipoUser == 3)
            {
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                ddlEspecialidad.DataSource = especialidadNegocio.ListaEspecialidades();
                ddlEspecialidad.DataTextField = "Nombre";
                ddlEspecialidad.DataValueField = "Nombre";
                ddlEspecialidad.DataBind();
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
                ddlObraSocial.DataSource = obraSocialNegocio.ListaObrasSociales();
                ddlObraSocial.DataTextField = "Nombre";
                ddlObraSocial.DataValueField = "IdObraSocial";
                ddlObraSocial.DataBind();
            }
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarProfesional_Click(object sender, EventArgs e)
        {
            Horario horario = new Horario();
            cargarHorario(horario);
            ((List<Horario>)Session["ListaHorarios"]).Add(horario);
            dgvListaHorarios.DataSource = (List<Horario>)Session["ListaHorarios"];
            dgvListaHorarios.DataBind();
        }

        protected void dgvListaHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((List<Horario>)Session["ListaHorarios"]).Remove(((List<Horario>)Session["ListaHorarios"]).Find(x => x.Id == int.Parse(dgvListaHorarios.SelectedDataKey.Value.ToString())));
            dgvListaHorarios.DataSource = (List<Horario>)Session["ListaHorarios"];
            dgvListaHorarios.DataBind();
        }
    }
}