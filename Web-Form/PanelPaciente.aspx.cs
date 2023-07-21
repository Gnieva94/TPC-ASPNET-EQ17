using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Helpers;

namespace Web_Form
{
    public partial class PanelPaciente : System.Web.UI.Page
    {
        public bool checkTurnos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
             
                    chkTurnos.Visible = false;
                    if (Seguridad.SesionActiva(Session["Persona"]))
                    {
                        int paciente = Session["Persona"] != null ? ((Persona)Session["Persona"]).Id : 0;
                        PacienteNegocio negocio = new PacienteNegocio();
                        List<Paciente> lista = negocio.ListaPacientes().FindAll(x => x.Id == paciente);
                        Session.Add("Pacientes", lista);

                    TurnoAsignadoNegocio negocio2 = new TurnoAsignadoNegocio();
                    Session.Add("Turnos", negocio2.ListaTurnoAsignado(lista[0].IdPaciente));
                    dgvTurnos.DataSource = Session["Turnos"];
                    dgvTurnos.DataBind();
                                
                 }

                  


                    lblUsuarioLogueado.Text = Session["Persona"] != null ? ((Persona)Session["Persona"]).Credencial.NombreUsuario : " ";



                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }

        }

        protected void btnTurnos_Click(object sender, EventArgs e)
        {
            btnTurnos.CssClass = "btn btn-dark btn-radio btn-lg active";
            chkTurnos.Checked = false;
        }

        protected void chkTurnos_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtFiltroRapidoTurnos_TextChanged(object sender, EventArgs e)
        {
            List<TurnoAsignado> lista = (List<TurnoAsignado>)Session["Turnos"];
            List<TurnoAsignado> listaFiltrada = lista.FindAll(x => x.Profesional.Nombre.ToUpper().Contains(txtFiltroRapidoTurnos.Text.ToUpper()) ||
            x.Profesional.Apellido.ToUpper().Contains(txtFiltroRapidoTurnos.Text.ToUpper()) || x.Especialidad.Nombre.ToUpper().Contains(txtFiltroRapidoTurnos.Text.ToUpper()));

            dgvTurnos.DataSource = listaFiltrada;
            dgvTurnos.DataBind();
        }

        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
                int id = Convert.ToInt32(dgvTurnos.SelectedDataKey.Value);
    
                try
                {
                    TurnoAsignadoNegocio negocio = new TurnoAsignadoNegocio();
                    negocio.CancelarTurno(id);
                    TurnoAsignadoNegocio negocio2 = new TurnoAsignadoNegocio();
                    Session.Add("Turnos", negocio2.ListaTurnoAsignado(1));
                    dgvTurnos.DataSource = Session["Turnos"];
                    dgvTurnos.DataBind();
                //Response.Redirect("PanelPaciente.aspx", false);
                    

                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                }
            


        }

        protected void btnNuevoTurno_Click(object sender, EventArgs e)
        {

            Persona persona = (Persona)Session["Persona"];
            Response.Redirect("AltaTurno.aspx");
         

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }

        protected void dgvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CancelarTurno")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                try
                {
                    TurnoAsignadoNegocio negocio = new TurnoAsignadoNegocio();
                    negocio.CancelarTurno(id);
                    dgvTurnos.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                }
            }
        }
    }
}