using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Web_Form
{
    public partial class PanelProfesional : System.Web.UI.Page
    {
        public bool checkPacientes { get; set; }
        public bool checkHorarios { get; set; }
        public bool checkTurnos { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    chkPacientes.Visible = false;
   
                    chkHorarios.Visible = false;
                    chkTurnos.Visible = false;
                    //if (Seguridad.SesionActiva(Session["Persona."]))
                    //{
                    PacienteNegocio negocioPas = new PacienteNegocio();
                    Session.Add("Pacientes", negocioPas.ListaPacientes());
                    dgvPacientes.DataSource = Session["Pacientes"];
                    dgvPacientes.DataBind();
                    //}
              
                    HorarioNegocio negocioHor = new HorarioNegocio();
                    Session.Add("Horarios", negocioHor.ListaHorarios());
                    dgvHorarios.DataSource = Session["Horarios"];
                    dgvHorarios.DataBind();






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

        protected void btnPacientes_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg active";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg";
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg";

            chkPacientes.Checked = !chkPacientes.Checked;
            chkHorarios.Checked = false;
            chkTurnos.Checked = false;
        }


        protected void btnHorarios_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg active";
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg";

            chkHorarios.Checked = !chkHorarios.Checked;
            chkPacientes.Checked = false;
            chkTurnos.Checked = false;

        }

        protected void chkHorarios_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnTurnos_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg";
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg active";

            chkTurnos.Checked = !chkTurnos.Checked;
            chkPacientes.Checked = false;
            chkHorarios.Checked = false;


        }

        protected void chkTurnos_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtFiltroRapidoHorarios_TextChanged(object sender, EventArgs e)
        {
            List<Horario> listaHorarios = (List<Horario>)Session["Horarios"];
            List<Horario> listaFiltrada = listaHorarios.FindAll(x => x.Profesional.Nombre.ToUpper().Contains(txtFiltroRapidoHorarios.Text.ToUpper()) ||
            x.Profesional.Apellido.ToUpper().Contains(txtFiltroRapidoHorarios.Text.ToUpper()) || x.Especialidad.Nombre.ToUpper().Contains(txtFiltroRapidoHorarios.Text.ToUpper()));

            dgvHorarios.DataSource = listaFiltrada;
            dgvHorarios.DataBind();
        }
    }
}