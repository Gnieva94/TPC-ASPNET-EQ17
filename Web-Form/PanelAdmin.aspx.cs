using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Helpers;
using Negocio;

namespace Web_Form
{
    public partial class Panel : System.Web.UI.Page
    {
        public bool checkPacientes { get; set; }
        public bool checkProfesionales { get; set; }
        public bool checkEmpleados { get; set; }
        public bool checkEspecialidades { get; set; }
        public bool checkObrasSociales { get; set; }
        public bool checkHorarios { get; set; }
        public bool checkTurnos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    chkPacientes.Visible = false;
                    chkProfesionales.Visible = false;
                    chkEmpleados.Visible = false;
                    chkEspecialidades.Visible = false;
                    chkObrasSociales.Visible = false;
                    chkHorarios.Visible = false;
                    chkTurnos.Visible = false;


                    if (Seguridad.SesionActiva(Session["Persona"]) && Seguridad.EsAdmin(Session["Persona"]))
                    {
                    PacienteNegocio negocioPas = new PacienteNegocio();
                    Session.Add("Pacientes", negocioPas.ListaPacientes());
                    dgvPacientes.DataSource = Session["Pacientes"];
                    dgvPacientes.DataBind();
                    

                    ProfesionalNegocio negocioProf = new ProfesionalNegocio();
                    Session.Add("Profesionales", negocioProf.ListaProfesionales());
                    dgvProfesionales.DataSource = Session["Profesionales"];
                    dgvProfesionales.DataBind();

                    EmpleadoNegocio negocioEmp = new EmpleadoNegocio();
                    Session.Add("Empleados", negocioEmp.ListaEmpleados());
                    dgvEmpleados.DataSource = Session["Empleados"];
                    dgvEmpleados.DataBind();

                    EspecialidadNegocio negocioEsp = new EspecialidadNegocio();
                    Session.Add("Especialidades", negocioEsp.ListaEspecialidades());
                    dgvEspecialidades.DataSource = Session["Especialidades"];
                    dgvEspecialidades.DataBind();

                    ObraSocialNegocio negocioObra = new ObraSocialNegocio();
                    Session.Add("ObrasSociales", negocioObra.ListaObrasSociales());
                    dgvObrasSociales.DataSource = Session["ObrasSociales"];
                    dgvObrasSociales.DataBind();

                    HorarioNegocio negocioHor = new HorarioNegocio();
                    Session.Add("Horarios", negocioHor.ListaHorarios());
                    dgvHorarios.DataSource = Session["Horarios"];
                    dgvHorarios.DataBind();

                    }
                    lblUsuarioLogueado.Text = Session["Persona"] != null ? ((Persona)Session["Persona"]).Credencial.NombreUsuario : " ";

                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }


        protected void chkPacientes_CheckedChanged(object sender, EventArgs e)
        {

            //checkPacientes = chkPacientes.Checked;

        }

        protected void chkProfesionales_CheckedChanged(object sender, EventArgs e)
        {
            //checkProfesionales = chkProfesionales.Checked;
        }

        protected void chkEmpleados_CheckedChanged(object sender, EventArgs e)
        {
            //checkEmpleados = chkEmpleados.Checked;
        }

        protected void txtFiltroRapidoPacientes_TextChanged(object sender, EventArgs e)
        {
            List<Paciente> listaPacientes = (List<Paciente>)Session["Pacientes"];
            List<Paciente> listaFiltrada = listaPacientes.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapidoPaciente.Text.ToUpper()) ||
            x.Apellido.ToUpper().Contains(txtFiltroRapidoPaciente.Text.ToUpper()) || x.Dni.ToUpper().Contains(txtFiltroRapidoPaciente.Text.ToUpper()) ||
            x.ObraSocial.Nombre.ToUpper().Contains(txtFiltroRapidoPaciente.Text.ToUpper()));

            checkPacientes = chkPacientes.Checked;
            dgvPacientes.DataSource = listaFiltrada;
            dgvPacientes.DataBind();

        }

        protected void txtFiltroRapidoProfesionales_TextChanged(object sender, EventArgs e)
        {
            List<Profesional> listaProfesionales = (List<Profesional>)Session["Profesionales"];
            List<Profesional> listaFiltrada = listaProfesionales.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapidoProfesionales.Text.ToUpper()) ||
            x.Apellido.ToUpper().Contains(txtFiltroRapidoProfesionales.Text.ToUpper()) || x.Dni.ToUpper().Contains(txtFiltroRapidoProfesionales.Text.ToUpper()) ||
            x.Matricula.ToUpper().Contains(txtFiltroRapidoProfesionales.Text.ToUpper()));

            checkProfesionales = chkProfesionales.Checked;
            dgvProfesionales.DataSource = listaFiltrada;
            dgvProfesionales.DataBind();

        }

        protected void txtFiltroRapidoEmpleados_TextChanged(object sender, EventArgs e)
        {

            List<Empleado> listaEmpleados = (List<Empleado>)Session["Empleados"];
            List<Empleado> listaFiltrada = listaEmpleados.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapidoEmpleados.Text.ToUpper()) ||
                       x.Apellido.ToUpper().Contains(txtFiltroRapidoEmpleados.Text.ToUpper()) || x.Dni.ToUpper().Contains(txtFiltroRapidoEmpleados.Text.ToUpper()) ||
                                  x.Permiso.Descripcion.ToUpper().Contains(txtFiltroRapidoEmpleados.Text.ToUpper()));

            checkEmpleados = chkEmpleados.Checked;
            dgvEmpleados.DataSource = listaFiltrada;
            dgvEmpleados.DataBind();



        }

        protected void btnPacientes_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg active";
            btnProfesionales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEmpleados.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEspecialidades.CssClass = "btn btn-dark btn-radio btn-lg";
            btnObrasSociales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg";
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg";

            chkPacientes.Checked = !chkPacientes.Checked;
            chkProfesionales.Checked = false;
            chkEmpleados.Checked = false;
            chkEspecialidades.Checked = false;
            chkObrasSociales.Checked = false;
            chkHorarios.Checked = false;
            chkTurnos.Checked = false;
        }

        protected void btnProfesionales_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg";
            btnProfesionales.CssClass = "btn btn-dark btn-radio btn-lg active";
            btnEmpleados.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEspecialidades.CssClass = "btn btn-dark btn-radio btn-lg";
            btnObrasSociales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg";
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg";

            chkProfesionales.Checked = !chkProfesionales.Checked;
            chkPacientes.Checked = false;
            chkEmpleados.Checked = false;
            chkEspecialidades.Checked = false;
            chkObrasSociales.Checked = false;
            chkHorarios.Checked = false;
            chkTurnos.Checked = false;
        }

        protected void btnEmpleados_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg";
            btnProfesionales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEmpleados.CssClass = "btn btn-dark btn-radio btn-lg active";
            btnEspecialidades.CssClass = "btn btn-dark btn-radio btn-lg";
            btnObrasSociales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg";
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg";


            chkEmpleados.Checked = !chkEmpleados.Checked;
            chkPacientes.Checked = false;
            chkProfesionales.Checked = false;
            chkEspecialidades.Checked = false;
            chkObrasSociales.Checked = false;
            chkHorarios.Checked = false;
            chkTurnos.Checked = false;
        }

        protected void txtFiltroRapidoEspecialidades_TextChanged(object sender, EventArgs e)
        {

            List<Especialidad> listaEspecialidades = (List<Especialidad>)Session["Especialidades"];
            List<Especialidad> listaFiltrada = listaEspecialidades.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapidoEspecialidades.Text.ToUpper()));

            dgvEspecialidades.DataSource = listaFiltrada;
            dgvEspecialidades.DataBind();

        }

        protected void btnEspecialidades_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg";
            btnProfesionales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEmpleados.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEspecialidades.CssClass = "btn btn-dark btn-radio btn-lg active";
            btnObrasSociales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg";
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg";

            chkEspecialidades.Checked = !chkEspecialidades.Checked;
            chkPacientes.Checked = false;
            chkProfesionales.Checked = false;
            chkEmpleados.Checked = false;
            chkObrasSociales.Checked = false;
            chkHorarios.Checked = false;
            chkTurnos.Checked = false;

        }

        protected void chkEspecialidades_CheckedChanged(object sender, EventArgs e)
        {
            //checkEspecialidades = chkEspecialidades.Checked;
        }

        protected void btnObrasSociales_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg";
            btnProfesionales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEmpleados.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEspecialidades.CssClass = "btn btn-dark btn-radio btn-lg";
            btnObrasSociales.CssClass = "btn btn-dark btn-radio btn-lg active";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg";
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg";

            chkObrasSociales.Checked = !chkObrasSociales.Checked;
            chkPacientes.Checked = false;
            chkProfesionales.Checked = false;
            chkEmpleados.Checked = false;
            chkEspecialidades.Checked = false;
            chkHorarios.Checked = false;
            chkTurnos.Checked = false;



        }

        protected void chkObrasSociales_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnHorarios_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg";
            btnProfesionales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEmpleados.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEspecialidades.CssClass = "btn btn-dark btn-radio btn-lg";
            btnObrasSociales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg active";
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg";

            chkHorarios.Checked = !chkHorarios.Checked;
            chkPacientes.Checked = false;
            chkProfesionales.Checked = false;
            chkEmpleados.Checked = false;
            chkEspecialidades.Checked = false;
            chkObrasSociales.Checked = false;
            chkTurnos.Checked = false;

        }

        protected void chkHorarios_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnTurnos_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg";
            btnProfesionales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEmpleados.CssClass = "btn btn-dark btn-radio btn-lg";
            btnEspecialidades.CssClass = "btn btn-dark btn-radio btn-lg";
            btnObrasSociales.CssClass = "btn btn-dark btn-radio btn-lg";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg";
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg active";

            chkTurnos.Checked = !chkTurnos.Checked;
            chkPacientes.Checked = false;
            chkProfesionales.Checked = false;
            chkEmpleados.Checked = false;
            chkEspecialidades.Checked = false;
            chkObrasSociales.Checked = false;
            chkHorarios.Checked = false;


        }

        protected void chkTurnos_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtFiltroRapidoObrasSociales_TextChanged(object sender, EventArgs e)
        {
            List<ObraSocial> listaObrasSociales = (List<ObraSocial>)Session["ObrasSociales"];
            List<ObraSocial> listaFiltrada = listaObrasSociales.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapidoObrasSociales.Text.ToUpper()));
            dgvObrasSociales.DataSource = listaFiltrada;
            dgvObrasSociales.DataBind();
        }

        protected void txtFiltroRapidoHorarios_TextChanged(object sender, EventArgs e)
        {
            List<Horario> listaHorarios = (List<Horario>)Session["Horarios"];
            List<Horario> listaFiltrada = listaHorarios.FindAll(x => x.Profesional.Nombre.ToUpper().Contains(txtFiltroRapidoHorarios.Text.ToUpper()) ||
            x.Profesional.Apellido.ToUpper().Contains(txtFiltroRapidoHorarios.Text.ToUpper()) || x.Especialidad.Nombre.ToUpper().Contains(txtFiltroRapidoHorarios.Text.ToUpper()) );

            dgvHorarios.DataSource = listaFiltrada;
            dgvHorarios.DataBind();
        }
    }
}