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
                    //if (Seguridad.SesionActiva(Session["Persona."]))
                    //{
                    //listar turnos del paciente
                    TurnoAsignadoNegocio negocio = new TurnoAsignadoNegocio();
                    Session.Add("Turnos", negocio.ListaTurnoAsignado(1));
                    dgvTurnos.DataSource = Session["Turnos"];
                    dgvTurnos.DataBind();
              
                 
                   
                    //}

                  


                    //lblUsuarioLogueado.Text = Session["Persona"] != null ? ((Persona)Session["Persona"]).Credencial.NombreUsuario : " ";



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
            List<TurnoAsignado> lista = (List<TurnoAsignado>)Session["Turnos"];
           // List<TurnoAsignado> listaFiltrada = lista.FindAll(x => x.Profesional.Nombre.ToUpper().Contains(txtFiltroRapidoTurnos.Text.ToUpper()) ||
           // x.Profesional.Apellido.ToUpper().Contains(txtFiltroRapidoTurnos.Text.ToUpper()) || x.Especialidad.Nombre.ToUpper().Contains(txtFiltroRapidoTurnos.Text.ToUpper()));

            //dgvTurnos.DataSource = listaFiltrada;
            //dgvTurnos.DataBind();

        }

        protected void txtFiltroRapidoTurnos_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNuevoTurno_Click(object sender, EventArgs e)
        {

            Persona persona = (Persona)Session["Persona"];
            Response.Redirect("AltaTurno.aspx");
         

        }
    }
}