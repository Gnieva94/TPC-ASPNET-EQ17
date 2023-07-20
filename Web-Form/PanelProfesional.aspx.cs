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


        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    chkPacientes.Visible = false;
                    chkHorarios.Visible = false;

                    //if (Seguridad.SesionActiva(Session["Persona."]))
                    //{
                    lblUsuarioLogueado.Text = Session["Persona"] != null ? ((Persona)Session["Persona"]).Credencial.NombreUsuario : " ";

                    PacienteNegocio negocioPas = new PacienteNegocio();
                    Session.Add("Pacientes", negocioPas.ListaPacientes());
                    dgvPacientes.DataSource = Session["Pacientes"];
                    dgvPacientes.DataBind();
                    //}
                    //if (Request.QueryString["id"] != null)
                    //{
                        int IdProfesional = 1;//int.Parse(Request.QueryString["id"].ToString());
                        Session.Add("idHorarioProfesionalUrl", IdProfesional);
                        ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
                        Profesional profesional = profesionalNegocio.traerRegistroPorId(IdProfesional);
                        profesional.IdProfesional = IdProfesional;
                        HorarioNegocio negocioHor = new HorarioNegocio();
                        List<Horario> horarios = negocioHor.BuscarHorarioPorProfesional(profesional.IdProfesional);
                        dgvHorarios.DataSource = horarios;
                        dgvHorarios.DataBind();
                        Session.Add("ListaHorarioProfesional", horarios);
                   // }

                    }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }

        protected void chkPacientes_CheckedChanged(object sender, EventArgs e)
        {

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

            chkPacientes.Checked = !chkPacientes.Checked;
            chkHorarios.Checked = false;
        }


        protected void btnHorarios_Click(object sender, EventArgs e)
        {
            btnPacientes.CssClass = "btn btn-dark btn-radio btn-lg";
            btnHorarios.CssClass = "btn btn-dark btn-radio btn-lg active";

            chkHorarios.Checked = !chkHorarios.Checked;
            chkPacientes.Checked = false;
        }

        protected void chkHorarios_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtFiltroRapidoHorarios_TextChanged(object sender, EventArgs e)
        {
            List<Horario> listaHorarios = (List<Horario>)Session["Horarios"];
            List<Horario> listaFiltrada = listaHorarios.FindAll(x => x.Profesional.Nombre.ToUpper().Contains(txtFiltroRapidoHorarios.Text.ToUpper()) ||
            x.Profesional.Apellido.ToUpper().Contains(txtFiltroRapidoHorarios.Text.ToUpper()) || 
            x.Especialidad.Nombre.ToUpper().Contains(txtFiltroRapidoHorarios.Text.ToUpper()));

            dgvHorarios.DataSource = listaFiltrada;
            dgvHorarios.DataBind();
        }

        protected void dgvHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("FormularioHorario.aspx?id=" + dgvHorarios.SelectedDataKey.Value.ToString(), false);
        }

        protected void dgvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("AltaTurno.aspx?id=" + dgvPacientes.SelectedDataKey.Value.ToString(), false); 
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}