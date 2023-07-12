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

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if(!IsPostBack)
                {
                    //if (Seguridad.SesionActiva(Session["Persona"]))
                    //{
                        PacienteNegocio negocioPas = new PacienteNegocio();
                        Session.Add("Pacientes", negocioPas.ListaPacientes());
                        dgvPacientes.DataSource = Session["Pacientes"];
                        dgvPacientes.DataBind();
                    //}

                    ProfesionalNegocio negocioProf = new ProfesionalNegocio();
                    Session.Add("Profesionales", negocioProf.ListaProfesionales());
                    dgvProfesionales.DataSource = Session["Profesionales"];
                    dgvProfesionales.DataBind();

                    EmpleadoNegocio negocioEmp = new EmpleadoNegocio();
                    Session.Add("Empleados", negocioEmp.ListaEmpleados());
                    dgvEmpleados.DataSource = Session["Empleados"];
                    dgvEmpleados.DataBind();


                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }


        protected void chkPacientes_CheckedChanged(object sender, EventArgs e)
        {

            checkPacientes = chkPacientes.Checked;

        }

        protected void chkProfesionales_CheckedChanged(object sender, EventArgs e)
        {
            checkProfesionales = chkProfesionales.Checked;
        }

        protected void chkEmpleados_CheckedChanged(object sender, EventArgs e)
        {
            checkEmpleados = chkEmpleados.Checked;
        }

        protected void txtFiltroRapidoPaciente_TextChanged(object sender, EventArgs e)
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
    }
}